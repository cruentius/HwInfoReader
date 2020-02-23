using System.Runtime.InteropServices;

namespace HwInfoReader.Abstractions.Models
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct HwInfoSensorElement
    {
        public uint dwSensorID;
        public uint dwSensorInst;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szSensorNameOrig;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szSensorNameUser;
    };
}
