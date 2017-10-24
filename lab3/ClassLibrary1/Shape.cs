using System;

namespace FirstEx
{
    public abstract class Shape
    {
        public Guid Id { get; set; }
        public string Color { get; set; }
        public int Transparency { get; set; }

        public abstract double ComputeArea();

        public bool isVisible()
        {
            if (Transparency < 80)
                return true;
            return false;
        }

        public abstract string Draw();
    }
}