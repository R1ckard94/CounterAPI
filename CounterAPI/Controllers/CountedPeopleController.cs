using CounterAPI.Services;
using CounterAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CountedAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountedController : ControllerBase
    {
        private readonly CountedService _countedService;

        public CountedController(CountedService countedService)
        {
            _countedService = countedService;
        }

        [HttpGet]
        public ActionResult<List<CountDay>> Get() =>
            _countedService.Get();

        [HttpGet("{idDate}")]
        public ActionResult<CountDay> Get(string idDate)
        {
            var countedDay = _countedService.Get(idDate);

            if (countedDay == null)
            {
                return NotFound();
            }

            return countedDay;
        }

        [HttpPost]
        public ActionResult<CountDay> Create(CountDay countedDay)
        {
            if(_countedService.Get(countedDay.IdDate) != null) {
                return BadRequest();
            }
            _countedService.Create(countedDay);

            return CreatedAtRoute(new { idDate = countedDay.IdDate }, countedDay);
        }

        [HttpPut("{idDate}")]
        public IActionResult Update(string idDate, CountDay countedDayIn)
        {
            var countedDay = _countedService.Get(idDate);

            if (countedDay == null)
            {
                return NotFound();
            }

            _countedService.Update(idDate, countedDayIn);

            return NoContent();
        }

        [HttpDelete("{idDate}")]
        public IActionResult Delete(string idDate)
        {
            var countedDay = _countedService.Get(idDate);

            if (countedDay == null)
            {
                return NotFound();
            }

            _countedService.Remove(idDate);

            return NoContent();
        }
    }
}