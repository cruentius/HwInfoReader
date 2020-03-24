using System;
using System.IO;

namespace HwInfoReader
{
    internal static class HwInfoLibraryWrapperConstants
    {
        public const string DllName = "HwInfoLibrary";
    }

    internal static class HwInfoLibraryWrapper
    {
        private delegate IntPtr ReadAllSensorsDelegate(out uint sizeOut);
        private delegate IntPtr ReadAllSensorReadingsDelegate(out uint sizeOut);
        private delegate void ReleasePtrDelegate(IntPtr ptr);

        private static readonly ReadAllSensorsDelegate _readAllSensorsFunc;
        private static readonly ReadAllSensorReadingsDelegate _readAllSensorReadingsFunc;
        private static readonly ReleasePtrDelegate _releasePtrFunc;

        static HwInfoLibraryWrapper()
        {
            var path = string.Empty;
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                    path = Path.Combine("runtimes", Environment.Is64BitProcess ? "win-x64" : "win-x86", "native", HwInfoLibraryWrapperConstants.DllName);
                    break;
            }
            _readAllSensorsFunc = FunctionLoader.LoadFunction<ReadAllSensorsDelegate>(path, nameof(ReadAllSensors));
            _readAllSensorReadingsFunc = FunctionLoader.LoadFunction<ReadAllSensorReadingsDelegate>(path, nameof(ReadAllSensorReadings));
            _releasePtrFunc = FunctionLoader.LoadFunction<ReleasePtrDelegate>(path, nameof(ReleasePtr));
        }

        public static IntPtr ReadAllSensors(out uint sizeOut) => _readAllSensorsFunc(out sizeOut);
        public static IntPtr ReadAllSensorReadings(out uint sizeOut) => _readAllSensorReadingsFunc(out sizeOut);
        public static void ReleasePtr(IntPtr ptr) => _releasePtrFunc(ptr);
    }
}
