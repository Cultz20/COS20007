using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Kiet
{
    public class MyRectangle : Shape
    {
        public MyRectangle() : this(Color.Green, 0.0f, 0.0f, 100 + 51, 100 + 51) { }

        public MyRectangle(Color color, float x, float y, int width, int height) : base(color, x, y, width, height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;

        }

        public override void Draw()
        {
            if (Selected)
                DrawOutline();
            SplashKit.FillRectangle(Color, X, Y, Width, Height);
        }

        public override void DrawOutline()
        {
            SplashKit.DrawRectangle(Color.Black, X - 6, Y - 6, Width + 12, Height + 12);
        }

        public override Boolean IsAt(Point2D pt)
        {
            return (pt.X > X) && (pt.X < X + Width) && (pt.Y > Y) && (pt.Y < Y + Height);
        }
    }
}
