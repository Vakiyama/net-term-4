namespace Lab1;

public class DesignPatternsTest
{
    [Fact]
    public void TestSingleton()
    {
        // Tests the singleton property: only one instance should exist.
        var firstInstance = DatabaseConnector.GetInstance();
        var secondInstance = DatabaseConnector.GetInstance();

        // xUnit's equivalent of Assert.AreSame:
        Assert.Same(firstInstance, secondInstance);
    }

    [Fact]
    public void TestAdapter()
    {
        // Tests the adapter functionality: should correctly convert measurements.
        var metric = new MetricSystemConverter();
        var adapter = new ImperialAdapter(metric);

        // For floating-point comparisons with a delta, one common approach is:
        double actual = adapter.ConvertMetersToYards(10);
        double expected = 10.9361;
        double tolerance = 0.0001;

        Assert.True(
            Math.Abs(actual - expected) < tolerance,
            $"10 meters should convert to yards correctly {Math.Abs(actual - expected)}, {tolerance})"
        );
    }

    [Fact]
    public void TestCommand()
    {
        // Tests command execution and undo functionality.
        var editor = new TextEditor();
        var history = new CommandHistory();
        var invoker = new Invoker(history);

        invoker.ExecuteCommand(new AddTextCommand(editor, "Hello"));
        Assert.Equal("Hello", editor.GetText());

        invoker.UndoCommand();
        Assert.Equal(string.Empty, editor.GetText());
    }

    [Fact]
    public void TestFactory()
    {
        // Tests factory for producing correct object types.
        var factory = new ShapeFactory();
        var circle = factory.GetShape("circle", 5);

        // xUnit’s “IsType” is often clearer than “circle is Circle”:
        Assert.IsType<Circle>(circle);
    }

    [Fact]
    public void TestObserver()
    {
        // Tests the update propagation and subscription management.
        var station = new WeatherStation();
        var display = new Display();

        station.Subscribe(display);
        station.SetMeasurements(25.0, 65.0);

        // For floating-point checks with a tolerance:
        Assert.True(
            Math.Abs(display.GetTemperature() - 25.0) < 0.01,
            "Display should receive updates"
        );

        station.Unsubscribe(display);
        station.SetMeasurements(30.0, 70.0);

        // The display should NOT have changed after unsubscribe
        Assert.True(
            Math.Abs(display.GetTemperature() - 25.0) < 0.01,
            "Display should not receive updates after unsubscribe"
        );
    }
}
