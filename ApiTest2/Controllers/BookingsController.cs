using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTest2.Models;
using System.Net.Mail;

namespace ApiTest2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly busprojectContext _context;

        public BookingsController(busprojectContext context)
        {
            _context = context;
        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBooking()
        {
            return await _context.Booking.ToListAsync();
        }
        [HttpGet("getallbyid")]
        public async Task<ActionResult<IEnumerable<Booking>>> getallbyid(int id)
        {
            var bookings = await _context.Booking.Where(b => b.UserId == id).ToListAsync();
            if (bookings == null)
            {
                return NotFound();
            }
            return bookings;
        }
        // GET: api/Bookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var booking = await _context.Booking.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        // PUT: api/Bookings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, Booking booking)
        {
            if (id != booking.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
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

        // POST: api/Bookings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
             _context.Booking.Add(booking);
            _context.SaveChanges();
            int busid = (from s in _context.Schedule where s.ScheduleId == booking.ScheduleId select s.BusId).First();
            int routeid = (from b in _context.Bus where b.BusId == busid select b.RouteId).First();
            string starting = (from b in _context.Routes where b.RouteId == routeid select b.StartingPoint).First();

            string destination = (from b in _context.Routes where b.RouteId == routeid select b.Destination).First();
            string body = "Booking Confirmed!!!\nThank you for using our service. Have a safe journey.\n Details:\n total fare:" + booking.TotalAmount + "\n Seats:" + booking.NumberOfSeats + "\n Starting Point:" + starting + "\n Destination :" + destination + "\n Departure Time:" + (from b in _context.Schedule where b.ScheduleId == booking.ScheduleId select b.Time ).First() + "\n Estimated Arrival Time:" + (from b in _context.Schedule where b.ScheduleId == booking.ScheduleId select b.EstimatedArrivalTime).First();
            
            if(booking.UserId != null)
            {
                string val = (from u in _context.User
                             where u.UserId == booking.UserId
                             select u.EmailAddress).First();
                SendMail("busreservationsystem1@gmail.com", val, "Ticket Confirmation", body);
            }
            else
            {
                SendMail("busreservationsystem1@gmail.com", booking.CustomerEmail, "Ticket Confirmation", body);
            }
            return CreatedAtAction("GetBooking", new { id = booking.BookingId }, booking);
        }
        public void SendMail(string from, string To, String Subject, string Body)
        {
            MailMessage mail = new MailMessage(from, To);
            mail.Subject = Subject;
            mail.Body = Body;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "busreservationsystem1@gmail.com",
                Password = "qwerty@1234"
            };
            client.EnableSsl = true;
            client.Send(mail);
        }
    
    // DELETE: api/Bookings/5
    [HttpDelete("{id}")]
        public async Task<ActionResult<Booking>> DeleteBooking(int id)
        {
            var booking = (from b in _context.Booking where b.BookingId == id select b).First();
            int busid = (from s in _context.Schedule where s.ScheduleId == booking.ScheduleId select s.BusId).First();
            int routeid = (from b in _context.Bus where b.BusId == busid select b.RouteId).First();
            string starting = (from b in _context.Routes where b.RouteId == routeid select b.StartingPoint).First();

            string destination = (from b in _context.Routes where b.RouteId == routeid select b.Destination).First();
            string body = "Booking Cancelled!!!\n Your refund has been processed.\nUse our service again.";

            if (booking.UserId != null)
            {
                string val = (from u in _context.User
                              where u.UserId == booking.UserId
                              select u.EmailAddress).First();
                SendMail("busreservationsystem1@gmail.com", val, "Ticket Confirmation", body);
            }
            else
            {
                SendMail("busreservationsystem1@gmail.com", booking.CustomerEmail, "Ticket Cancelled!", body);
            }
            var bookings = await _context.Booking.FindAsync(id);
            if (bookings == null)
            {
                return NotFound();
            }

            _context.Booking.Remove(bookings);
            await _context.SaveChangesAsync();

            return booking;
        }
        [HttpGet("getlastbookingid")]
        public async Task<ActionResult<int>> getlastbookingid()
        {
            int bookingid = (from b in _context.Booking
                            orderby b.BookingId descending
                            select b.BookingId).FirstOrDefault();
            if (bookingid == null)
            {
                return NotFound();
            }
            return bookingid + 1;
        }
        
        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.BookingId == id);
        }
    }
}
