using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace TravelAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private TravelAPIContext _db;

        public DestinationsController(TravelAPIContext db)
        {
            _db = db;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Destination>> Get()
        {
            return _db.Destinations.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Destination> Get(int id)
        {
            return _db.Destinations.FirstOrDefault(place => place.DestinationId == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Destination theDestination)
        {
            _db.Destinations.Add(theDestination);
            _db.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Destination theDestination)
        {
            theDestination.DestinationId = id;
            _db.Entry(theDestination).State = EntityState.Modified;            
            _db.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Destination deleteDestination = _db.Destinations.FirstOrDefault(place => place.DestinationId == id);
            _db.Destinations.Remove(deleteDestination);
            _db.SaveChanges();
        }
    }
}
