using System;
namespace Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/Schedule")]
    public class ScheduleController : Controller
    {
        private readonly ScheduleController _context;

        public ScheduleController(ScheduleContext context)
        {
            _context = context;
        }

      
        [HttpGet]
        public IEnumerable<ScheduleController> GetSchedule()
        {
            return _context.GetSchedule;
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkout([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var schedule = await _context.Schedule.SingleOrDefaultAsync(m => m.Id == id);

            if (schedule == null)
            {
                return NotFound();
            }

            return Ok(schedule);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchedule([FromRoute] int id, [FromCalendar] ScheduleController schedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != schedule.Id)
            {
                return BadRequest();
            }

            _context.Entry(schedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleExists(id))
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

        [HttpPost]
        public async Task<IActionResult> PostSchedule([FromCalendar] ScheduleController schedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GetSchedule.Add(schedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSchedule", new { id = schedule.Id }, schedule);
        }

    
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var schedule = await _context.Schedule.SingleOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }

            _context.Schedule.Remove(Schedule);
            await _context.SaveChangesAsync();

            return Ok(Schedule);
        }

        private bool ScheduleExists(int id)
        {
            return _context.Schedule.Any(e => e.Id == id);
        }
    }
}
