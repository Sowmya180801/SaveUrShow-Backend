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
    public class feedbacksController : ControllerBase
    {
        private readonly SaveUrShowUsingCFADbContext _context;

        public feedbacksController(SaveUrShowUsingCFADbContext context)
        {
            _context = context;
        }

        // GET: api/feedbacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<feedback>>> Getfeedback()
        {
            return await _context.feedback.ToListAsync();
        }

        // GET: api/feedbacks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<feedback>> Getfeedback(int id)
        {
            var feedback = await _context.feedback.FindAsync(id);

            if (feedback == null)
            {
                return NotFound();
            }

            return feedback;
        }

        // PUT: api/feedbacks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putfeedback(int id, feedback feedback)
        {
            if (id != feedback.feedid)
            {
                return BadRequest();
            }

            _context.Entry(feedback).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!feedbackExists(id))
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

        // POST: api/feedbacks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<feedback>> Postfeedback(feedback feedback)
        {
            _context.feedback.Add(feedback);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getfeedback", new { id = feedback.feedid }, feedback);
        }

        // DELETE: api/feedbacks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletefeedback(int id)
        {
            var feedback = await _context.feedback.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }

            _context.feedback.Remove(feedback);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool feedbackExists(int id)
        {
            return _context.feedback.Any(e => e.feedid == id);
        }
    }
}



//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.EntityFrameworkCore;
//using SaveUrShowUsingCFA.Models;

//namespace SaveUrShowUsingCFA.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class feedbacksController : ControllerBase
//    {

//        private readonly SaveUrShowUsingCFADbContext _context;

//        public feedbacksController(SaveUrShowUsingCFADbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/<feedbacksController>
//        [HttpGet]
//        //public IEnumerable<string> Get()
//        //{
//        //    return new string[] { "value1", "value2" };
//        //}

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<feedback>>> Getfeedback()
//        {
//            return await _context.feedback.ToListAsync();
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<feedback>> Getfeedback(int feedid)
//        {
//            var feedback = await _context.feedback.FindAsync(feedid);

//            if (feedback == null)
//            {
//                return NotFound();
//            }

//            return feedback;
//        }
//        // GET api/<feedbacksController>/5


//        // POST api/<feedbacksController>
//        [HttpPost]
//        public async Task<ActionResult<feedback>> Postfeedback(feedback feedback)
//        {
//            _context.feedback.Add(feedback);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("Getfeedback", new { id = feedback.feedid }, feedback);
//        }

//        public void Post([FromBody] string value)
//        {
//        }

//        // PUT api/<feedbacksController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE api/<feedbacksController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
