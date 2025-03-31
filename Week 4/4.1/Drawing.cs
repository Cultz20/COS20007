using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Kiet;
using SplashKitSDK;

namespace Kiet
{
    internal class Drawing
    {
        private readonly List<Shape> _shapes;
        Color _background;
        public Drawing() : this(Color.Black)
        {

        }
        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }
        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }
        public int ShapeCount
        {
            get { return _shapes.Count; }

        }
        public void AddShape(Shape s)
        {
            _shapes.Add(s);
        }
        public void RemoveShape(Shape s)
        {
            _shapes.Remove(s);
        }
        public void Draw()
        {
            foreach (var shape in _shapes)
            {
                shape.Color = _background;
                shape.Draw();
            }
        }
        public Shape selectShapeAt(Point2D pt)
        {
            foreach (Shape shape in _shapes)
            {
                if (shape.IsAt(pt))
                {
                    return shape;
                }
            }
            return null;
        }

        public List<Shape> SelectedShape
        {

            get
            {
                List<Shape> result = new List<Shape>();
                foreach (var shape in _shapes)

                    if (shape.Selected)
                        result.Add(shape);
                return result;
            }
        }
    }
}

