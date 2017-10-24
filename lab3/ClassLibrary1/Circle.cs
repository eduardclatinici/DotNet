using System;
using System.Collections.Generic;
using System.Text;

namespace FirstEx
{
    public class Circle:Shape
    {
        public double Radius { get; private set; }

        private void checkTransparency(double transparency)
        {
            if (transparency < 0 || transparency > 100)
                throw new ArgumentException("transparency must be between 0 and 100");
        }

        private void checkRadius(double radius)
        {
            if(radius<=0)
                throw new ArgumentException("radius must be greater than 0");
        }

        private void checkArguments(double radius, int transparency)
        {
            checkRadius(radius);
            checkTransparency(transparency);
        }

        public Circle(double radius, string color, int transparency)
        {
            checkArguments(radius,transparency);
            Radius = radius;
            Transparency = transparency;
        }

        public override double ComputeArea()
        {
            return 3.14 * Radius * Radius;
        }

        public override string Draw()
        {
            return "Draw Circle";
        }
    }
}
