using System;
using System.Runtime.InteropServices;

namespace HwInfoReader
{
    internal static class HwInfoLibraryWrapperConstants
    {
        public const string LibraryPath = "Library/HwInfoLibrary.dll";
    }

    internal static class HwInfoLibraryWrapper
    {
        [DllImport(HwInfoLibraryWrapperConstants.LibraryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ReadAllSensors(out uint sizeOut);

        [DllImport(HwInfoLibraryWrapperConstants.LibraryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ReadAllSensorReadings(out uint sizeOut);

        [DllImport(HwInfoLibraryWrapperConstants.LibraryPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ReleasePtr(IntPtr ptr);
    }
}
