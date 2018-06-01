namespace AreaCalculatorTests
{
    #region usings

    using System;

    using AreaCalculator;
    using AreaCalculator.Figures;

    using FluentAssertions;

    using NUnit.Framework;

    #endregion

    [TestFixture]
    public class TriangleTests
    {
        [TestCase(3, 4, 5)]
        [TestCase(2, 2, 2)]
        [TestCase(4, 4, 2)]
        [TestCase(1, 2, 1.5)]
        public void CreateTriangle_NormalEdges_Created(double a, double b, double c)
        {
            var factory = new FigureFactory();

            var triangle = factory.CreateTriangle(a, b, c);

            triangle.As<Triangle>().Should().NotBeNull();
        }

        [TestCase(3, 4, 5)]
        [TestCase(5, 4, 3)]
        [TestCase(3, 5, 4)]
        public void CreateTriangle_RightTriangleEdges_IsRight(double a, double b, double c)
        {
            var factory = new FigureFactory();

            var triangle = factory.CreateTriangle(a, b, c);

            triangle.Should().BeOfType<RightTriangle>().And.NotBeNull();
        }

        [TestCase(1, 2, 1.5)]
        [TestCase(2, 2, 2)]
        [TestCase(4, 4, 2)]
        public void CreateTriangle_NotRightTriangleEdges_IsNotRight(double a, double b, double c)
        {
            var factory = new FigureFactory();

            var triangle = factory.CreateTriangle(a, b, c);

            triangle.Should().NotBeOfType<RightTriangle>().And.NotBeNull();
        }

        [TestCase(3, 4, 5, 6)]
        [TestCase(2, 2, 2, 1.7320508075689)]
        [TestCase(4, 4, 2, 3.8729833462074)]
        [TestCase(1, 2, 1.5, 0.72618437741389)]
        public void CalculateArea_SomeValues_MatchResult(double a, double b, double c, double expected)
        {
            var factory = new FigureFactory();
            var circle = factory.CreateTriangle(a, b, c);

            var area = circle.CalculateArea();

            area.Should().BeApproximately(expected, 1e-10);
        }

        [TestCase(1, 1, 4)]
        [TestCase(1, 4, 1)]
        [TestCase(4, 1, 1)]
        [TestCase(1, 2, 30)]
        public void CreateTriangle_BreakTriangleRule_CantCreate(double a, double b, double c)
        {
            var factory = new FigureFactory();

            Assert.Throws<ArgumentException>(() => factory.CreateTriangle(a, b, c));
        }

        [TestCase(1, 1, 0)]
        [TestCase(1, 0, 1)]
        [TestCase(0, 1, 1)]
        [TestCase(1, 0, 0)]
        [TestCase(0, 0, 1)]
        [TestCase(0, 1, 0)]
        [TestCase(0, 0, 0)]
        [TestCase(1, 1, -1)]
        [TestCase(1, -1, 1)]
        [TestCase(-1, 1, 1)]
        [TestCase(1, -1, -1)]
        [TestCase(-1, -1, 1)]
        [TestCase(-1, 1, -1)]
        [TestCase(-1, -1, -1)]
        public void CreateTriangle_WrongEdge_CantCreate(double a, double b, double c)
        {
            var factory = new FigureFactory();

            Assert.Throws<ArgumentOutOfRangeException>(() => factory.CreateTriangle(a, b, c));
        }
    }
}