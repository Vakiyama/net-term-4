namespace Lab1
{
    public interface Shape
    {
        public string Draw();
    }

    public class ShapeFactory
    {
        public Shape GetShape(string shape, int size)
        {
            switch (shape)
            {
                case "circle":
                    return new Circle(size);
                default:
                    throw new Exception($"No shape with name {shape} found.");
            }
        }
    }
}
