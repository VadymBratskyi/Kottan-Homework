using System;
using System.Collections.Generic;
namespace OOP.Shapes
{
	public class Circle : ShapeBase
	{
        double _radius;

        private const double  P = Math.PI;

	    protected double Radius => _radius * Multiplier;

	    public override string ShapeName { get; }

        public Circle(double radius)
            : this(new Dictionary<ParamKeys, object> { 
                {ParamKeys.Radius, radius},
                {ParamKeys.CoordX, 0},
                {ParamKeys.CoordY, 0}
            })
        {
        }
	   
        public Circle(IDictionary<ParamKeys, object> parameters) : base(parameters)
		{
            ShapeName = "Circle";
            _radius = (double) parameters[ParamKeys.Radius];
		}

        public override double GetPerimeter()
        {
            return 2 * P * Radius;
        }

        public override void Move(int deltaX, int deltaY)
        {
            CoordX += deltaX;
            CoordY += deltaY;
        }

        protected override double Area()
        {
            return P * Radius * Radius;
        }
    }
}