using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Kiet
{
    public class MyLine : Shape
    {
        public MyLine() : this(Color.Red, 0.0f, 0.0f, 50) { }

        public MyLine(Color color, float x, float y, int width) : base(color, x, y, width, 2)
        {
            Width = width;
        }

        public override void Draw()
        {
            if (Selected)
            SplashKit.DrawLine(Color, X, Y, X + Width + 20, Y);
        }

        public override void DrawOutline()
        {
            SplashKit.DrawLine(Color.Black, X, Y - 1, X + Width + 20, Y - 1);
            SplashKit.DrawLine(Color.Black, X, Y + 1, X + Width + 20, Y + 1);
        }

        public override Boolean IsAt(Point2D pt)
        {
            float range = 2.0f;
            return (pt.X >= X && pt.X <= X + Width + 20) && (Math.Abs(pt.Y - Y) <= range);
        }
    }
}
