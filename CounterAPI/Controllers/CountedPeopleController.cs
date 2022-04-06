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

        [HttpGet("{Date}")]
        public ActionResult<CountDay> Get(string date)
        {
            var countedDay = _countedService.Get(date);

            if (countedDay == null)
            {
                return NotFound();
            }

            return countedDay;
        }

        [HttpPost]
        public ActionResult<CountDay> Create(CountDay countedDay)
        {
            _countedService.Create(countedDay);

            return CreatedAtRoute("GetDay", new { date = countedDay.Date }, countedDay);
        }

        [HttpPut("{date}")]
        public IActionResult Update(string date, CountDay countedDayIn)
        {
            var countedDay = _countedService.Get(date);

            if (countedDay == null)
            {
                return NotFound();
            }

            _countedService.Update(date, countedDayIn);

            return NoContent();
        }

        [HttpDelete("{date}")]
        public IActionResult Delete(string date)
        {
            var countedDay = _countedService.Get(date);

            if (countedDay == null)
            {
                return NotFound();
            }

            _countedService.Remove(date);

            return NoContent();
        }
    }
}