using AdventOfCode2020.Enums;

namespace AdventOfCode2020.Models
{
    public record HeightData
    {
        public double Height { get; }

        public MeasurementUnit MeasurementUnit { get; }

        public HeightData(double height, MeasurementUnit measurementUnit) => (Height, MeasurementUnit) = (height, measurementUnit);

        public bool IsValidHeightData()
        {
            return MeasurementUnit != MeasurementUnit.Unspecified &&
                (MeasurementUnit == MeasurementUnit.Centimeter
                ? Height >= 150 && Height <= 193
                : Height >= 59 && Height <= 76);
        }
    }
}
