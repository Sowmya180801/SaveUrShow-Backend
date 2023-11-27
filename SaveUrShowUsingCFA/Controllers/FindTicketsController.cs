using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaveUrShowUsingCFA.Models;

namespace SaveUrShowUsingCFA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindTicketsController : ControllerBase
    {
        private readonly SaveUrShowUsingCFADbContext _context;

        public FindTicketsController(SaveUrShowUsingCFADbContext context)
        {
            _context = context;
        }

        // GET: api/FindTickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FindTicket>>> GetFindTicket()
        {
            return await _context.FindTicket.ToListAsync();
        }

        [HttpGet("{Moviename}/{location}")]
        public async Task<ActionResult<FindTicket>> GetFindTicket(string Moviename, string location)
        {
            var findTicket = await _context.FindTicket.FirstOrDefaultAsync(record => record.Moviename == Moviename && record.Location == location);

            if (findTicket == null)
            {
                return NotFound();
            }

            return findTicket;
        }

        // GET: api/FindTickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FindTicket>> GetFindTicket(int id)
        {
            var findTicket = await _context.FindTicket.FindAsync(id);

            if (findTicket == null)
            {
                return NotFound();
            }

            return findTicket;
        }

        //[HttpGet("search")]
        //public IActionResult SearchMovies(string query)
        //{
        //    // Query your database to search for movies by name
        //    var results = _context.FindTicket
        //        .Where(movie => movie.Moviename.Contains(query))
        //        .ToList();

        //    return Ok(results);
        //}


        // PUT: api/FindTickets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFindTicket(int id, FindTicket findTicket)
        {
            if (id != findTicket.MovieId)
            {
                return BadRequest();
            }

            _context.Entry(findTicket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FindTicketExists(id))
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

        // POST: api/FindTickets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        [HttpPost]
        public async Task<ActionResult<FindTicket>> PostFindTicket(FindTicket findTicket)
        {
            _context.FindTicket.Add(findTicket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFindTicket", new { id = findTicket.MovieId }, findTicket);
        }

        //[HttpPost]
        //public string AddMovie(FindTicket findTicket)
        //{
        //    string response = string.Empty;
        //    _context.FindTicket.Add(findTicket);
        //    _context.SaveChanges();
        //    return "Movie added";
        //}

        // DELETE: api/FindTickets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FindTicket>> DeleteFindTicket(int id)
        {
            var findTicket = await _context.FindTicket.FindAsync(id);
            if (findTicket == null)
            {
                return NotFound();
            }

            _context.FindTicket.Remove(findTicket);
            await _context.SaveChangesAsync();

            return findTicket;
        }

        [HttpGet("booking/{movieId}")]
        public async Task<ActionResult<IEnumerable<int>>> GetBookedSeatsByMovieId(int movieId)
        {
            // Retrieve and return booked seats based on the movieId
            var bookedSeats = await _context.BookingTicket
                .Where(b => b.MovieId == movieId)
                .Select(b => b.Seatnum)
                .ToListAsync();

            // Check if any booked seats were found
            if (bookedSeats.Count == 0)
            {
                return NotFound("No booked seats found for the movie.");
            }

            // Convert comma-separated strings to list of integers
            var bookedSeatNumbers = bookedSeats
                .SelectMany(s => s.Split(',', StringSplitOptions.RemoveEmptyEntries))
                .Select(int.Parse)
                .ToList();

            return Ok(bookedSeatNumbers);
        }


        private bool FindTicketExists(int id)
        {
            return _context.FindTicket.Any(e => e.MovieId == id);
        }
    }
}
