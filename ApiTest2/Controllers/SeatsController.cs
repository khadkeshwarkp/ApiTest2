using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTest2.Models;

namespace ApiTest2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly busprojectContext _context;

        public SeatsController(busprojectContext context)
        {
            _context = context;
        }

        // GET: api/Seats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seat>>> GetSeat()
        {
            return await _context.Seat.ToListAsync();
        }
        [HttpGet("getallseatsbyid")]
        public async Task<ActionResult<IEnumerable<Seat>>> getallseatsbyid(int id)
        {
            var bookings = await _context.Seat.Where(b => b.BookingId == id).ToListAsync();
            if (bookings == null)
            {
                return NotFound();
            }
            return bookings;
        }
        [HttpGet("getFilledseats")]
        public async Task<ActionResult<IEnumerable<string>>> getFilledseats(int id)
        {
            var seatsids = (from s in _context.Seat.Where(s1 => s1.BusId== id) select s.Seatid).ToList();
            if (seatsids == null)
            {
                return NotFound();
            }
            return seatsids;
        }
        // GET: api/Seats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seat>> GetSeat(int id)
        {
            var seat = await _context.Seat.FindAsync(id);

            if (seat == null)
            {
                return NotFound();
            }

            return seat;
        }

        // PUT: api/Seats/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeat(int id, Seat seat)
        {
            if (id != seat.SeatNo)
            {
                return BadRequest();
            }

            _context.Entry(seat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeatExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpGet("getlastseatid")]
        public async Task<ActionResult<int>> getlastseatid()
        {
            int seatid = (from s in _context.Seat
                             orderby s.SeatNo descending
                             select s.SeatNo).FirstOrDefault();
            if (seatid == null)
            {
                return NotFound();
            }
            return seatid + 1;
        }
        // POST: api/Seats
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Seat>> PostSeat(Seat seat)
        {
            _context.Seat.Add(seat);
           
              _context.SaveChanges();
            

            return CreatedAtAction("GetSeat", new { id = seat.SeatNo }, seat);
        }

        // DELETE: api/Seats/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Seat>> DeleteSeat(int id)
        {
            var seat = await _context.Seat.FindAsync(id);
            if (seat == null)
            {
                return NotFound();
            }

            _context.Seat.Remove(seat);
            await _context.SaveChangesAsync();

            return seat;
        }

        private bool SeatExists(int id)
        {
            return _context.Seat.Any(e => e.SeatNo == id);
        }
    }
}
