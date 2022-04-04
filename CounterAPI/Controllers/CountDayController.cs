using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CounterAPI.Models;

namespace CounterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountDayController : ControllerBase
    {
        private readonly CountDayContext _context;

        public CountDayController(CountDayContext context)
        {
            _context = context;
        }

        // GET: api/CountDay
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountDay>>> GetCounterAPIDays()
        {
            return await _context.CounterAPIDays.ToListAsync();
        }

        // GET: api/CountDay/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountDay>> GetCountDay(long id)
        {
            var countDay = await _context.CounterAPIDays.FindAsync(id);

            if (countDay == null)
            {
                return NotFound();
            }

            return countDay;
        }

        // PUT: api/CountDay/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountDay(long id, CountDay countDay)
        {
            if (id != countDay.Id)
            {
                return BadRequest();
            }

            _context.Entry(countDay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountDayExists(id))
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

        // POST: api/CountDay
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CountDay>> PostCountDay(CountDay countDay)
        {
            _context.CounterAPIDays.Add(countDay);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetCountDay", new { id = countDay.Id }, countDay);
            return CreatedAtAction(nameof(GetCountDay), new { id = countDay.Id }, countDay);
        }

        // DELETE: api/CountDay/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountDay(long id)
        {
            var countDay = await _context.CounterAPIDays.FindAsync(id);
            if (countDay == null)
            {
                return NotFound();
            }

            _context.CounterAPIDays.Remove(countDay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountDayExists(long id)
        {
            return _context.CounterAPIDays.Any(e => e.Id == id);
        }
    }
}
