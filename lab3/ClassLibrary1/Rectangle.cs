using System;

namespace FirstEx
{
    public class Rectangle:Shape
    {
        public double Width { get; private set; }
        public double Height { get; private set; }

        private void checkWidth(double width)
        {
            if (width <= 0)
                throw new ArgumentException("width must be greater than 0");
        }

        private void checkHeight(double height)
        {
            if (height <= 0)
                throw new ArgumentException("height must be greater than 0");
        }

        private void checkTransparency(double transparency)
        {
            if (transparency < 0 || transparency > 100)
                throw new ArgumentException("transparency must be between 0 and 100");
        }

        private void checkArguments(double width, double height, int transparency)
        {
            checkWidth(width);
            checkHeight(height);
            checkTransparency(transparency);
        }

        public Rectangle(double width,double height,string color,int transparency)
        {
            checkArguments(width,height,transparency);
            Width = width;
            Height = height;
            Color = color;
            Transparency = transparency;
        }

        public override double ComputeArea()
        {
            return Width * Height;
        }

        public override string Draw()
        {
            return "Draw Rectangle";
        }
    }
}