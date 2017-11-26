namespace MeasureComplexInterface
{
    public class TurbineData
    {
        public string RotorType { get; set; }
        public string VaneHeight { get; set; }
        public string VaneWidth { get; set; }
        public string Diameter { get; set; }
    }
    enum DeviceDataType
    {
        UT372,
        UT61b,
        WE2107,
    }
}
