using System;
using System.Collections;
using System.Collections.Generic;

namespace OOP.Shapes.Triangles
{
	/// <summary>
	/// triangle where all edges are equal
	/// </summary>
    public class EquilateralTriangle : Triangle
	{
	    public override string ShapeName { get; }

        public EquilateralTriangle(double edge) : this(new Dictionary<ParamKeys,object>
       {
           { ParamKeys.Edge1, edge },
           { ParamKeys.Edge2, edge },
           { ParamKeys.Edge3, edge },
           { ParamKeys.CoordX, 0 },
           { ParamKeys.CoordY, 0 }
       })
        {
        }

	    public EquilateralTriangle(IDictionary<ParamKeys, object> parametrs) : base(parametrs)
	    {
            ShapeName = "EquilateralTriangle";
        }

	    public override double GetPerimeter()
	    {
	        return Edge1 * 3;
	    }

	    public override void Move(int deltaX, int deltaY)
	    {
	        CoordX += deltaX;
	        CoordY += deltaY;
	    }

	    protected override double Area()
	    {
	        return Math.Sqrt(3)/4*Math.Sqrt(Edge1);
	    }
	}
}