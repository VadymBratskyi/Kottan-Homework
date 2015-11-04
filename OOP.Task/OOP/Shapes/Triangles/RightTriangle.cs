using System;
using System.Collections.Generic;

namespace OOP.Shapes.Triangles
{
    /// <summary>
    /// Triangle with one 90 degrees corner
    /// </summary>
    public class RightTriangle : Triangle
    {
        public override string ShapeName { get; }

        public RightTriangle(double edgeK1, double edgeK2) : this(new Dictionary<ParamKeys, object>
        {
            { ParamKeys.Edge1, edgeK1 },
            { ParamKeys.Edge2, edgeK2 },
            { ParamKeys.Edge3, Math.Sqrt(edgeK1 * edgeK1+edgeK2 * edgeK2)},
            { ParamKeys.CoordX, 0 },
            { ParamKeys.CoordY, 0 }
        })
        {
        }

        public RightTriangle(IDictionary<ParamKeys, object> parametrs) : base(parametrs)
        {
            ShapeName = "RightTriangle";
        }

        protected override double Area()
        {
            return 0.5d * Edge1 * Edge2;
        }
    }
}