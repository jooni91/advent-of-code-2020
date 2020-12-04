using AdventOfCode2020.Enums;

namespace AdventOfCode2020.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="MeasurementUnit"/>.
    /// </summary>
    public static class MeasurementUnitExtensions
    { 
        /// <summary>
        /// Parse the measurement unit from the end of an height string.
        /// </summary>
        /// <param name="heightString"></param>
        /// <returns></returns>
        public static MeasurementUnit ParseFromHeightString(this string heightString)
        {
            if (heightString.EndsWith("cm"))
            {
                return MeasurementUnit.Centimeter;
            }
            else if (heightString.EndsWith("in"))
            {
                return MeasurementUnit.Inch;
            }
            else
            {
                return MeasurementUnit.Unspecified;
            }
        }
    }
}
