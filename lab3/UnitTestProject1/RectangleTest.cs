using System;
using System.Dynamic;
using FirstEx;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting; 

namespace FirstExTests
{
    [TestClass]
    public class RectangleTest
    {
        [TestMethod]
        public void shouldCreateRectangle()
        {
            Rectangle rectangle=new Rectangle(10,10,"blue",10);
        }

        [TestMethod]
        public void shouldFailCreatingRectangleWidthLowerThanZero()
        {
            Action action = () => new Rectangle(-1, 10, "red", 10);
            action.ShouldThrow<ArgumentException>().WithMessage("width must be greater than 0");
        }

        [TestMethod]
        public void shouldFailCreatingRectangleHeightLowerThanZero()
        {
            Action action = () => new Rectangle(10, -1, "red", 10);
            action.ShouldThrow<ArgumentException>().WithMessage("height must be greater than 0");
        }

        [TestMethod]
        public void shouldFailCreatingRectangleTransparencyLowerThanZero()
        {
            Action action = () => new Rectangle(10, 10, "red", -1);
            action.ShouldThrow<ArgumentException>().WithMessage("transparency must be between 0 and 100");
        }

        [TestMethod]
        public void shouldReturnDrawRectangle()
        {
            Rectangle rectangle= new Rectangle(10, 10, "red", 10);
            rectangle.Draw().Should().Be("Draw Rectangle");
        }

        [TestMethod]
        public void shouldReturnOneHundredAsArea()
        {
            Rectangle rectangle = new Rectangle(10, 10, "red", 10);
            rectangle.ComputeArea().Should().Be(100);
        }

        [TestMethod]
        public void shouldReturnTrueVisible()
        {
            Rectangle rectangle = new Rectangle(10, 10, "red", 10);
            rectangle.isVisible().Should().Be(true);
        }

        [TestMethod]
        public void shouldReturnFalseVisible()
        {
            Rectangle rectangle = new Rectangle(10, 10, "red", 90);
            rectangle.isVisible().Should().Be(false);
        }

    }
}
