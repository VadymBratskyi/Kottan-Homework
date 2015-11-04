using System.Collections;
using System.Collections.Generic;

namespace OOP.Shapes
{
    public class Rectangle : ShapeBase
    {
        private double _edge1;
        private double _edge2;
        public override string ShapeName { get; }

        protected double Edge1 => _edge1 * Multiplier;
        protected double Edge2 => _edge2 * Multiplier;

        public Rectangle(double edge1, double edge2) 
            : this( new Dictionary<ParamKeys, object>
            {
                { ParamKeys.Edge1,edge1},
                { ParamKeys.Edge2,edge2},
                { ParamKeys.CoordX,0},
                { ParamKeys.CoordY,0}
            } )
        {
        }

        public Rectangle(IDictionary<ParamKeys, object> parameter)
            : base(parameter)
        {
            _edge1 = (double) parameter[ParamKeys.Edge1];
            _edge2 = (double) parameter[ParamKeys.Edge2];
            ShapeName = "Rectangle";
        }

        public override double GetPerimeter()
        {
            return 2*(Edge1 + Edge2);
        }

        public override void Move(int deltaX, int deltaY)
        {
            CoordX += deltaX;
            CoordY += deltaY;
        }

        protected override double Area()
        {
            return Edge1 * Edge2;
        }
    }
}