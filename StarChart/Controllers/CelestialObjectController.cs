using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarChart.Data;
using StarChart.Models;

namespace StarChart.Controllers
{
    [ApiController]
    [Route("")]
    public class CelestialObjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CelestialObjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}", Name = "GetById")]
        public IActionResult GetById(int id)
        {
            var celestialObject = _context.CelestialObjects.Find(id);
            if (celestialObject == null)
                return NotFound();
            celestialObject.Satellites = _context.CelestialObjects.Where(e => e.OrbitedObjectId == celestialObject.Id).ToList();

            return Ok(celestialObject);
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            var celestialObject = _context.CelestialObjects.Where(e => e.Name == name);
            if (celestialObject == null)
                return NotFound();
            foreach (var co in celestialObject)
            {
                co.Satellites = _context.CelestialObjects.Where(e => e.OrbitedObjectId == co.Id).ToList();
            }

            return Ok(celestialObject);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var celestialObject = _context.CelestialObjects;

            foreach (var co in celestialObject)
            {
                co.Satellites = _context.CelestialObjects.Where(e => e.OrbitedObjectId == co.Id).ToList();
            }

            return Ok(celestialObject);
        }
    }
}
