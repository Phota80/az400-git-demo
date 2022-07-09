using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerPlantSampleApi.Models
{
    public class MeasurementInfo
    {
        public int MeasurementId { get; set; }
        public int Speed { get; set; }
        public decimal Vibration { get; set; }
        public decimal? Acceleration { get; set; }
        public decimal Temperature { get; set; }
        public string State { get; set; }
        public string RecordedBy { get; set; }
        public string RecordedByEmail { get; set; }
        public string DateCreated { get; set; }
    }
}
