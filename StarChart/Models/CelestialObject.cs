using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarChart.Models
{
    public class CelestialObject
    {
        public int Id;
        public int OrbitedObjectId;
        [Required]
        public string Name;
        [NotMapped]
        List<CelestialObject> Satellites;
        public TimeSpan OrbitalPeriod;
    }
}
