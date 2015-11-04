using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace OOP.Shapes
{
     //TODO: use Heron's formula for area
    public class Triangle : ShapeBase
    {
        private double _edge1;
        private double _edge2;
        private double _edge3;

        public override string ShapeName { get; }

        protected double Edge1 => _edge1*Multiplier;
        protected double Edge2 => _edge2*Multiplier;
        protected double Edge3 => _edge3*Multiplier;

        public Triangle(double edge1,double edge2, double edge3):this(new Dictionary<ParamKeys, object>
        {
            { ParamKeys.Edge1, edge1},
            { ParamKeys.Edge2, edge2},
            { ParamKeys.Edge3, edge3},
            { ParamKeys.CoordX,0},
            { ParamKeys.CoordY,0}
        })
        {
        }

        public Triangle(IDictionary<ParamKeys, object> parametr) : base()
        {
            _edge1 = (double) parametr[ParamKeys.Edge1];
            _edge2 = (double) parametr[ParamKeys.Edge2];
            _edge3 = (double) parametr[ParamKeys.Edge3];
            ShapeName = "Triangle";
        }

        public override double GetPerimeter()
        {
            return Edge1 + Edge2 + Edge3;
        }

        public override void Move(int deltaX, int deltaY)
        {
            CoordX += deltaX;
            CoordY += deltaY;
        }

        protected override double Area()
        {
            double pivPer = GetPerimeter()/2;
            return Math.Sqrt(pivPer*(pivPer - Edge1)*(pivPer - Edge2)*(pivPer - Edge3));
        }
    }
}