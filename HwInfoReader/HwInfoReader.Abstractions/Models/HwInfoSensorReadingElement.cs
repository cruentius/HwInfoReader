using HwHwInfoReader.Abstractions.Enums;
using System.Runtime.InteropServices;

namespace HwInfoReader.Abstractions.Models
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct HwInfoSensorReadingElement
    {
        public SensorReadingType tReading;
        public uint dwSensorIndex;
        public uint dwReadingID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ElementConstants.HwInfoSensorsStringLen)]
        public string szLabelOrig;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ElementConstants.HwInfoSensorsStringLen)]
        public string szLabelUser;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ElementConstants.HwInfoUnitStringLen)]
        public string szUnit;
        public double Value;
        public double ValueMin;
        public double ValueMax;
        public double ValueAvg;
    };
}
