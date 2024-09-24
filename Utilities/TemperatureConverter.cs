namespace WeatherUpdates.Utilities
{
    public static class TemperatureConverter
    {
        public static double ConvertTemperature(double temperature, string fromUnit, string toUnit)
        {
 
            fromUnit = fromUnit.ToUpper();
            toUnit = toUnit.ToUpper();

            if (fromUnit == toUnit) return temperature;

            if (fromUnit == "C")
            {
                if (toUnit == "F")
                {
                    return (temperature * 9 / 5) + 32; 
                }
                else if (toUnit == "K")
                {
                    return temperature + 273.15; 
                }
            }

            else if (fromUnit == "F")
            {
                if (toUnit == "C")
                {
                    return (temperature - 32) * 5 / 9; 
                }
                else if (toUnit == "K")
                {
                    return (temperature - 32) * 5 / 9 + 273.15; 
                }
            }

            else if (fromUnit == "K")
            {
                if (toUnit == "C")
                {
                    return temperature - 273.15; 
                }
                else if (toUnit == "F")
                {
                    return (temperature - 273.15) * 9 / 5 + 32; 
                }
            }

            throw new ArgumentException($"Invalid temperature conversion from {fromUnit} to {toUnit}");
        }
    }
}
