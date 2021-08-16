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
    public class RoutesController : ControllerBase
    {
        private readonly busprojectContext _context;

        public RoutesController(busprojectContext context)
        {
            _context = context;
        }

        // GET: api/Routes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Routes>>> GetRoutes()
        {
            return await _context.Routes.ToListAsync();
        }

        // GET: api/Routes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Routes>> GetRoutes(int id)
        {
            var routes = await _context.Routes.FindAsync(id);

            if (routes == null)
            {
                return NotFound();
            }

            return routes;
        }
        [HttpGet("getroutebyscheduleid")]
        public async Task<ActionResult<Routes>> getroutebyscheduleid(int id)
        {
            var busid = (from s in _context.Schedule where s.ScheduleId == id select s.BusId).First();
            int routeid = (from b in _context.Bus where b.BusId == busid select b.RouteId).First();
            Routes starting = (from b in _context.Routes where b.RouteId == routeid select b).First();

            if (starting == null)
            {
                return NotFound();
            }

            return starting;
        }
        // PUT: api/Routes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoutes(int id, Routes routes)
        {
            if (id != routes.RouteId)
            {
                return BadRequest();
            }

            _context.Entry(routes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoutesExists(id))
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
        
        // POST: api/Routes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Routes>> PostRoutes(Routes routes)
        {
            _context.Routes.Add(routes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoutesExists(routes.RouteId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRoutes", new { id = routes.RouteId }, routes);
        }

        // DELETE: api/Routes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Routes>> DeleteRoutes(int id)
        {
            var routes = await _context.Routes.FindAsync(id);
            if (routes == null)
            {
                return NotFound();
            }

            _context.Routes.Remove(routes);
            await _context.SaveChangesAsync();

            return routes;
        }

        private bool RoutesExists(int id)
        {
            return _context.Routes.Any(e => e.RouteId == id);
        }
    }
}
