using HwInfoReader.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HwInfoReader.Tests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HwInfoController : ControllerBase
    {
        private readonly IHwInfoReader _hwInfoReader;

        public HwInfoController(IHwInfoReader hwInfoReader)
        {
            _hwInfoReader = hwInfoReader;
        }

        [Route("sensorData")]
        [HttpGet]
        public IActionResult GetSensorData()
        {
            var grouped = _hwInfoReader.ReadSensorReadings()
                .GroupBy(g => g.tReading)
                .Select(s => new { Sensor = s.Key.ToString(), data = s.ToList() });

            return Ok(grouped);
        }
    }
}
