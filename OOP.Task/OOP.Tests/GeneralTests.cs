using System;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using OOP.Shapes;
using FluentAssertions;
using OOP.Shapes.Triangles;

namespace OOP.Tests
{
    [TestFixture]
    public class GeneralTests
    {
        private const double _Radius = 5d;
        private const double _Edge1 = 3d;
        private const double _Edge2 = 4d;
        private const double _Edge3 = 5d;
        private const double _Hypotenuse = 5d;
        private const int _CoordX = 0;
        private const int _CoordY = 0;
        private const int _Multiplier = 3;

        [Test, Sequential]
        public void ShapeShouldBeMoved([Values(
            typeof(Circle)
        //     TODO: UNCOMMENT WHEN IMPLEMENTED ALL SHAPES
            ,typeof(Rectangle)
            ,typeof(Triangle)
            ,typeof(EquilateralTriangle)
            ,typeof(RightTriangle)
            )] Type targetType)
        {
            //declare
           var @params = GetParams();
            var target = GetShape(targetType, @params);
            var coordX = (int)@params[ParamKeys.CoordX];
            var coordY = (int)@params[ParamKeys.CoordY];
          //  act
            target.Move(1, 1);
          //  assert
            target.CoordX.Should().Be(coordX + 1);
            target.CoordY.Should().Be(coordY + 1);
        }

        [Test, Sequential]
        public void AreaShouldBeCalculated([Values(
               typeof(Circle)
                //TODO: UNCOMMENT WHEN IMPLEMENTED ALL SHAPES
               ,typeof(Rectangle)
               ,typeof(Triangle)
               ,typeof(RightTriangle)
               )] Type targetType,
            [Values(_Radius * _Radius * Math.PI
               // TODO: UNCOMMENT WHEN IMPLEMENTED ALL SHAPES
               ,_Edge1 * _Edge2
               ,6d
               ,6d
               )] double area)
        {
           // declare
           var @params = GetParams();
            var target = GetShape(targetType, @params);
            //act
           var actualArea = target.GetArea();
           // assert
            actualArea.Should().Be(area);
        }

        [Test, Sequential]
        public void PerimeterShouldBeCalculated([Values(
               typeof(Circle)
               // TODO: UNCOMMENT WHEN IMPLEMENTED ALL SHAPES
               ,typeof(Rectangle)
               ,typeof(Triangle)
               ,typeof(EquilateralTriangle)
               ,typeof(RightTriangle)
               )] Type targetType,
            [Values(2 * _Radius * Math.PI
               // TODO: UNCOMMENT WHEN IMPLEMENTED ALL SHAPES
               ,2*(_Edge1 + _Edge2)
               ,_Edge1 + _Edge2 + _Edge3
               ,_Edge1 * 3
               ,_Edge1 + _Edge2 + _Hypotenuse
               )] double perimeter)
        {
            // declare
            var @params = GetParams();
            var target = GetShape(targetType, @params);
            // act 
            var actualPerimeter = target.GetPerimeter();
            // assert
            actualPerimeter.Should().Be(perimeter);
        }

        [Test, Sequential]
        public void PerimeterShouldBeCalculatedWithMultiplier([Values(
               typeof(Circle)
               // TODO: UNCOMMENT WHEN IMPLEMENTED ALL SHAPES
               ,typeof(Rectangle)
               ,typeof(Triangle)
               ,typeof(EquilateralTriangle)
               ,typeof(RightTriangle)
               )] Type targetType,
            [Values(2 * _Radius * Math.PI * _Multiplier
               // TODO: UNCOMMENT WHEN IMPLEMENTED ALL SHAPES
               ,2*(_Edge1 + _Edge2) * _Multiplier
               ,(_Edge1 + _Edge2 + _Edge3) * _Multiplier
               ,(_Edge1) * 3 * _Multiplier
               ,(_Edge1 + _Edge2 + _Hypotenuse)* _Multiplier
               )] double perimeter)
        {
            // declare
            var @params = GetParams();
            var target = GetShape(targetType, @params);
            target.Multiplier = _Multiplier;
            // act 
            var actualPerimeter = target.GetPerimeter();
            // assert
            actualPerimeter.Should().Be(perimeter);
        }

        [Test, Sequential]
        public void ShouldReturnValidShapeName([Values(
               typeof(Circle)
               // TODO: UNCOMMENT WHEN IMPLEMENTED ALL SHAPES
               ,typeof(Rectangle)
               ,typeof(Triangle)
               ,typeof(EquilateralTriangle)
               ,typeof(RightTriangle)
               )] Type targetType,
            [Values("Circle"
              //  TODO: UNCOMMENT WHEN IMPLEMENTED ALL SHAPES
               , "Rectangle"
               ,"Triangle"
               ,"EquilateralTriangle"
               ,"RightTriangle"
               )] string shapeName)
        {
            // declare
            var @params = GetParams();
            var target = GetShape(targetType, @params);
            // act 
            var actualShapeName = target.ShapeName;
            // assert
            actualShapeName.Should().Be(shapeName);
        }

        private IShape GetShape(Type shapeActualType, IDictionary<ParamKeys, object> @params)
        {
            var instance = Activator.CreateInstance(shapeActualType, @params);
            return instance as IShape;
        }

        private IDictionary<ParamKeys, object> GetParams()
        {
            return new Dictionary<ParamKeys, object>
            {
                [ParamKeys.CoordX] = _CoordX,
                [ParamKeys.CoordY] = _CoordY,
                [ParamKeys.Edge1] = _Edge1,
                [ParamKeys.Edge2] = _Edge2,
                [ParamKeys.Edge3] = _Edge3,
                [ParamKeys.Radius] = _Radius,
            };
        }
    }
}