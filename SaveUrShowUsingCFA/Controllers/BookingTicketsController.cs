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
    public class BookingTicketsController : ControllerBase
    {
        private readonly SaveUrShowUsingCFADbContext _context;

        public BookingTicketsController(SaveUrShowUsingCFADbContext context)
        {
            _context = context;
        }

        // GET: api/BookTickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingTicket>>> GetBookTicket()
        {
            return await _context.BookingTicket.ToListAsync();
        }

        // GET: api/BookTickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingTicket>> GetBookTicket(long id)
        {
            var bookTicket = await _context.BookingTicket.FindAsync(id);

            if (bookTicket == null)
            {
                return NotFound();
            }

            return bookTicket;
        }

        // GET: api/BookTickets/user/{userid}
        [HttpGet("user/{userid}")]
        public async Task<ActionResult<IEnumerable<BookingTicket>>> GetBookingsByUserId(int userid)
        {
            // Retrieve and return booking history based on the userid
            var bookingHistory = await _context.BookingTicket
                .Where(b => b.Userid == userid)
                .ToListAsync();

            // Check if any booking history was found
            if (bookingHistory.Count == 0)
            {
                return NotFound("No booking history found for the user.");
            }

            return Ok(bookingHistory);
        }


        // PUT: api/BookTickets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookTicket(long id, BookingTicket bookTicket)
        {
            if (id != bookTicket.Bookid)
            {
                return BadRequest();
            }

            _context.Entry(bookTicket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookTicketExists(id))
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

        // POST: api/BookTickets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookingTicket>> PostBookTicket(BookingTicket bookTicket)
        {

            _context.BookingTicket.Add(bookTicket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookTicket", new { id = bookTicket.Bookid }, bookTicket);
        }

        

        // DELETE: api/BookTickets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookingTicket>> DeleteBookTicket(long id)
        {
            var bookTicket = await _context.BookingTicket.FindAsync(id);
            if (bookTicket == null)
            {
                return NotFound();
            }

            _context.BookingTicket.Remove(bookTicket);
            await _context.SaveChangesAsync();

            return bookTicket;
        }

        private bool BookTicketExists(long id)
        {
            return _context.BookingTicket.Any(e => e.Bookid == id);
        }
    }
}
