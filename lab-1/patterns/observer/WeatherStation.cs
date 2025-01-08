namespace Lab1
{
    public interface Subject
    {
        public void Subscribe(Display display);
        public void Unsubscribe(Display display);
    }

    public class WeatherStation : Subject
    {
        private List<Display> _observerList = new List<Display>();
        public double _temperature;
        public double _humidity;

        public void Subscribe(Display observer)
        {
            _observerList.Add(observer);
            observer.SetSubject(this);
        }

        public void Unsubscribe(Display observer)
        {
            _observerList.Remove(observer);
        }

        public void SetMeasurements(double temperature, double humidity)
        {
            _temperature = temperature;
            _humidity = humidity;

            _observerList.ForEach(observer => observer.Update(temperature, humidity));
        }
    }

    public interface Observer
    {
        public void Update(double temperature, double humidity);
    }

    public class Display : Observer
    {
        private double _displayedTemp = 0;
        private WeatherStation _weatherStation;

        public void SetSubject(WeatherStation weatherStation)
        {
            _weatherStation = weatherStation;
        }

        public void Update(double temperature, double humidity)
        {
            _displayedTemp = temperature;
        }

        public double GetTemperature() => _displayedTemp;
    }
}
