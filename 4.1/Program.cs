using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using Kiet;
using SplashKitSDK;

namespace Kiet
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle, Circle, Line
        }
        public static void Main()
        {
            Window wn = new Window("Shape Drawer", 800, 600);
            Drawing myDrawing = new Drawing();
            ShapeKind kindToAdd = ShapeKind.Circle;
            int lineCount = 5;
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape = null;
                    Shape lineShape;
                    switch (kindToAdd)
                    {

                        case ShapeKind.Circle:
                            newShape = new MyCircle();
                            break;

                        case ShapeKind.Rectangle:
                            newShape = new MyRectangle();
                            break;

                        case ShapeKind.Line:
                            for (int i = 0; i < lineCount; i++)
                            {
                                lineShape = new MyLine();
                                lineShape.X = SplashKit.MouseX();
                                lineShape.Y = SplashKit.MouseY() + (i * 10);
                                myDrawing.AddShape(lineShape);
                            }
                            newShape = null;
                        break;

                        default:
                        newShape = new MyRectangle();
                        break;

                    }
                    if (newShape != null)
                    {
                        newShape.X = SplashKit.MouseX();
                        newShape.Y = SplashKit.MouseY();
                        myDrawing.AddShape(newShape);
                    }
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    Point2D pt = new Point2D();
                    pt.X = SplashKit.MousePosition().X;
                    pt.Y = SplashKit.MousePosition().Y;
                    Shape selected = myDrawing.selectShapeAt(pt);

                    if (selected != null)
                    {
                        selected.Selected = !selected.Selected; 
                    }
                }
                
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomColor();
                }

                if (SplashKit.KeyTyped(KeyCode.BackspaceKey) || SplashKit.KeyTyped(KeyCode.DeleteKey))
                {
                    List<Shape> shapes = new List<Shape>();
                    shapes = myDrawing.SelectedShape;
                    foreach (var s in shapes)
                        myDrawing.RemoveShape(s);
                }

                myDrawing.Draw();
                SplashKit.RefreshScreen();
            } while (!wn.CloseRequested);
        }
    }
}