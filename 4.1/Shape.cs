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
    public abstract class Shape
    {
        Color _color;
        protected float _x, _y;
        protected int _width, _height;

        Boolean _selected;

        public Shape(Color color, float x, float y, int width, int height) { 
            _color = Color.Azure;
            _x = 0.0f;
            _y = 0.0f;
            _width = width;
            _height = height;
            _color = color;
            _selected = false;  
        }
        public Shape(Color color) : this(color, 0.0f, 0.0f, 100, 100) { }

        public Shape() : this(Color.Yellow) { }

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
        public abstract void Draw();

        public abstract void DrawOutline();
        public abstract bool IsAt(Point2D pt);
    }
}   
