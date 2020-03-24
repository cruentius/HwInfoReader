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
        private readonly ILogger<HwInfoReader> _logger;

        public HwInfoReader(ILogger<HwInfoReader> logger)
        {
            _logger = logger;
        }

        public IEnumerable<HwInfoSensorElement> ReadSensors()
        {
            var list = new List<HwInfoSensorElement>();

            var ptr = IntPtr.Zero;

            try
            {
                ptr = HwInfoLibraryWrapper.ReadAllSensors(out var sizeOut);

                for (var i = 0; i < sizeOut; i++)
                {
                    var offset = Marshal.SizeOf<HwInfoSensorElement>() * i;
                    var sensor = Marshal.PtrToStructure<HwInfoSensorElement>(IntPtr.Add(ptr, offset));

                    list.Add(sensor);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Could not read sensor data");
            }
            finally
            {
                HwInfoLibraryWrapper.ReleasePtr(ptr);
            }

            return list;
        }

        public IEnumerable<HwInfoSensorReadingElement> ReadSensorReadings()
        {
            var list = new List<HwInfoSensorReadingElement>();

            var ptr = IntPtr.Zero;

            try
            {
                ptr = HwInfoLibraryWrapper.ReadAllSensorReadings(out var sizeOut);

                for (var i = 0; i < sizeOut; i++)
                {
                    var offset = Marshal.SizeOf<HwInfoSensorReadingElement>() * i;
                    var sensor = Marshal.PtrToStructure<HwInfoSensorReadingElement>(IntPtr.Add(ptr, offset));

                    list.Add(sensor);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Could not read sensor reading data");
            }
            finally
            {
                HwInfoLibraryWrapper.ReleasePtr(ptr);
            }

            return list;
        }
    }
}
