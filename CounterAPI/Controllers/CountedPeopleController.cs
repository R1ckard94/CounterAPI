using CounterAPI.Services;
using CounterAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CountedAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly CountedService _countedService;

        public BooksController(CountedService countedService)
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

            return CreatedAtRoute("GetBook", new { id = countedDay.Id.ToString() }, countedDay);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, CountDay countedDayIn)
        {
            var countedDay = _countedService.Get(id);

            if (countedDay == null)
            {
                return NotFound();
            }

            _countedService.Update(id, countedDayIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var countedDay = _countedService.Get(id);

            if (countedDay == null)
            {
                return NotFound();
            }

            _countedService.Remove(id);

            return NoContent();
        }
    }
}