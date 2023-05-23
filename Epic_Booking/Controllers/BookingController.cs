using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Epic_Booking.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Epic_Booking.Controllers
{
    [Route("api/bookings")]
    public class BookingController : Controller
    {
        [HttpGet]
        public List<Booking> GetBookings()
        {
            return new List<Booking> {
                new Booking { Id = 123, Title = "Booking 1", Start = DateTime.Now, End = DateTime.Now.AddHours(2) },
                new Booking { Id = 456, Title = "Booking 2", Start = DateTime.Now.AddDays(1), End = DateTime.Now.AddDays(1).AddHours(2) }
            };
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

