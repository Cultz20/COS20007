using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Kiet
{
    internal class MyCircle : Shape
{
        int _radius;
        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public MyCircle() : this(Color.Blue, 0.0f, 0.0f, 50 + 51) { }

        public MyCircle(Color color, float x, float y, int radius) : base(color)
        {
            _radius = radius;
        }

        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, Radius + 2);
        }

        public override void Draw()
        {
            if (Selected)
            DrawOutline();
            SplashKit.FillCircle(Color, X, Y, Radius);
        }
        public override Boolean IsAt(Point2D pt)
        {
            return SplashKit.PointInCircle(pt, SplashKit.CircleAt(X, Y, Radius));
        }
    }
}
