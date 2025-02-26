using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Kiet
{
    internal class Shape
    {
        Color _color;
        float _x, _y;
        int _width, _height;
        Boolean _selected;

        public Shape(int param) { 
            _color = Color.Azure;
            _x = 0;
            _y = 0;
            _width = 100 + param;
            _height = 100 + param;
            _selected = false;
        }

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y
        {
            get { return _y; }
            set { _y = value; }

        }
        public int Width
        {
            get { return _width; } 
            set { _width = value; }
        }
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public Boolean Selected
        {
            get { return _selected; }
            set { _selected = value; }

        }
        public void Draw()
        {
            if (_selected) 
                DrawOutline();
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }
        public Boolean IsAt(Point2D pt)
        {
            if((pt.X > _x) && (pt.X < _x + _width) && (pt.Y > _y) && (pt.Y < _y + _height))
            return true;
            else return false;
        }
        public void DrawOutline()
        {
            Rectangle rt = new Rectangle();
            rt.X = _x - 6;
            rt.Y = _y - 6;
            rt.Width = _width + 12;
            rt.Height = _height + 12;
            SplashKit.DrawRectangle(Color.Black, rt);
        }
    }
}   
