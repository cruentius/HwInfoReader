using HwInfoReader.Abstractions.Models;
using System.Collections.Generic;

namespace HwInfoReader.Abstractions
{
    public interface IHwInfoReader
    {
        IEnumerable<HwInfoSensorElement> ReadSensors();

        IEnumerable<HwInfoSensorReadingElement> ReadSensorReadings();
    }
}
