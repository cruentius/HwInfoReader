using HwInfoReader.Abstractions;
using HwInfoReader.Abstractions.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace HwInfoReader
{
    public class HwInfoReader : IHwInfoReader
    {
        [DllImport("HwInfoLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ReadAllSensors(out uint sizeOut);

        [DllImport("HwInfoLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ReadAllSensorReadings(out uint sizeOut);

        [DllImport("HwInfoLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ReleasePtr(IntPtr p);

        private readonly ILogger<HwInfoReader> _logger;

        public HwInfoReader(ILogger<HwInfoReader> logger)
        {
            _logger = logger;
        }

        public IEnumerable<HwInfoSensorElement> ReadSensors()
        {
            var list = new List<HwInfoSensorElement>();

            var ptr = ReadAllSensors(out var sizeOut);

            try
            {
                for (var i = 0; i < sizeOut; i++)
                {
                    var offset = Marshal.SizeOf(typeof(HwInfoSensorElement)) * i;
                    var sensor = (HwInfoSensorElement)Marshal.PtrToStructure(IntPtr.Add(ptr, offset), typeof(HwInfoSensorElement));

                    list.Add(sensor);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError("Could not read sensor data", ex);
            }
            finally
            {
                ReleasePtr(ptr);
            }

            return list;
        }

        public IEnumerable<HwInfoSensorReadingElement> ReadSensorReadings()
        {
            var list = new List<HwInfoSensorReadingElement>();

            var ptr = ReadAllSensorReadings(out var sizeOut);

            try
            {
                for (var i = 0; i < sizeOut; i++)
                {
                    var offset = Marshal.SizeOf(typeof(HwInfoSensorReadingElement)) * i;
                    var sensor = (HwInfoSensorReadingElement)Marshal.PtrToStructure(IntPtr.Add(ptr, offset), typeof(HwInfoSensorReadingElement));

                    list.Add(sensor);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not read sensor reading data", ex);
            }
            finally
            {
                ReleasePtr(ptr);
            }

            return list;
        }
    }
}
