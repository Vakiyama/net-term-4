namespace Lab1
{
    public interface ImperialSystemConverter
    {
        public double ConvertMetersToYards(int meters);
    }

    public class ImperialAdapter : ImperialSystemConverter
    {
        private MetricSystemConverter _converter;
        private double CENTIMETER_TO_YARDS = 1 / 91.44;

        public ImperialAdapter(MetricSystemConverter converter)
        {
            _converter = converter;
        }

        public double ConvertMetersToYards(int meters) =>
            TruncateToDecimalPlaces(
                _converter.ConvertMetersToCentimeters(meters) * CENTIMETER_TO_YARDS,
                4
            );

        public static double TruncateToDecimalPlaces(double value, int decimalPlaces)
        {
            double factor = Math.Pow(10, decimalPlaces);
            return Math.Truncate(value * factor) / factor;
        }
    }
}
