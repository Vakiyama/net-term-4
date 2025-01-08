namespace Lab1
{
    public class Circle : Shape
    {
        private int _radius;

        public Circle(int radius)
        {
            _radius = radius;
        }

        public string Draw()
        {
            return $"Circle with radius {_radius} drawn.";
        }
    }
}
