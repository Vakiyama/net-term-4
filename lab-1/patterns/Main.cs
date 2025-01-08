namespace Lab1
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            // Demonstration of the Singleton Pattern
            Console.WriteLine("Singleton Pattern Demonstration:");
            // Requesting the first instance of DatabaseConnector
            DatabaseConnector firstConnector = DatabaseConnector.GetInstance();
            Console.WriteLine("First instance created.");
            // Requesting the second instance of DatabaseConnector
            DatabaseConnector secondConnector = DatabaseConnector.GetInstance();
            Console.WriteLine("Second instance requested.");
            // Checking if both instances are the same
            Console.WriteLine("Both instances same? " + (firstConnector == secondConnector)); // Should be true
            Console.WriteLine(); // Adding a newline for clarity in output
            // Demonstration of the Adapter Pattern
            Console.WriteLine("Adapter Pattern Demonstration:");
            // Creating a metric converter
            MetricSystemConverter metricConverter = new MetricSystemConverter();
            // Adapting the metric converter to imperial standards
            ImperialSystemConverter adapter = new ImperialAdapter(metricConverter);
            // Performing a conversion from meters to yards
            Console.WriteLine(
                "Converting 10 meters to yards: " + adapter.ConvertMetersToYards(10) + " yards"
            );
            // Expected output might vary based on conversion logic
            Console.WriteLine(); // Adding a newline for clarity in output
            // Demonstration of the Command Pattern
            Console.WriteLine("Command Pattern Demonstration:");
            // Creating a text editor and command history
            TextEditor editor = new TextEditor();
            CommandHistory history = new CommandHistory();
            Invoker invoker = new Invoker(history);
            // Adding text to the editor
            invoker.ExecuteCommand(new AddTextCommand(editor, "Hello, "));
            invoker.ExecuteCommand(new AddTextCommand(editor, "world!"));
            // Current text in the editor
            Console.WriteLine("Current Text Editor Content: '" + editor.GetText() + "'"); // Should print "Hello, world!"
            // Undoing the last command
            invoker.UndoCommand();
            // Text after undo
            Console.WriteLine("Text after one undo: '" + editor.GetText() + "'"); // Should print "Hello, "
            Console.WriteLine(); // Adding a newline for clarity in output
            // Demonstration of the Factory Pattern
            Console.WriteLine("Factory Pattern Demonstration:");
            // Creating a shape factory
            ShapeFactory shapeFactory = new ShapeFactory();
            // Creating a circle with radius 5
            Shape circle = shapeFactory.GetShape("circle", 5);
            // Drawing the circle
            Console.WriteLine("Drawing a circle: " + circle.Draw()); // Output depends on your draw method's logic
            Console.WriteLine(); // Adding a newline for clarity in output
            // Demonstration of the Observer Pattern
            Console.WriteLine("Observer Pattern Demonstration:");
            // Creating a weather station
            WeatherStation weatherStation = new WeatherStation();
            // Creating a display
            Display display = new Display();
            // Subscribing the display to the weather station
            weatherStation.Subscribe(display);
            // Setting measurements
            weatherStation.SetMeasurements(25.0, 65.0);
            Console.WriteLine("Weather station updates: Temperature - 25.0, Humidity - 65.0");
            // Unsubscribing the display
            weatherStation.Unsubscribe(display);
            // Setting new measurements (which the display should not show)
            weatherStation.SetMeasurements(30.0, 70.0);
            Console.WriteLine(
                "Display unsubscribed, updates after this point should not be displayed."
            );
            Console.WriteLine("All patterns demonstrated.");
        }
    }
}
