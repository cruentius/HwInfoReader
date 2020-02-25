using System.Runtime.InteropServices;

namespace HwInfoReader.Abstractions.Models
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct HwInfoSensorElement
    {
        public uint dwSensorID;
        public uint dwSensorInst;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ElementConstants.HwInfoSensorsStringLen)]
        public string szSensorNameOrig;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ElementConstants.HwInfoSensorsStringLen)]
        public string szSensorNameUser;
    };
}
