using System;
using System.Collections.Generic;
using Kiet;
using SplashKitSDK;

namespace Kiet
{
    public class Program
    {
        public static void Main()
        {
            Window wn = new Window("Shape Drawer", 800, 600);
            Drawing myDrawing = new Drawing();
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if(SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape sp = new Shape(51);
                    sp.X = (float)SplashKit.MousePosition().X;
                    sp.Y = (float)SplashKit.MousePosition().Y;
                    myDrawing.AddShape(sp);
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