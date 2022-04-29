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

		[HttpGet("{date}")]
		public ActionResult<List<CountDay>> Get(string date)
		{
			var countedDay = _countedService.Get(date);

			if (countedDay == null)
			{
				return NotFound();
			}

			return countedDay;
		}

		[HttpGet("{date}/peoplecount")]
		public ActionResult<PeopleCount> Get(string date, string peoplecount)
		{
			
			int peopleCounted = 0;
			int maxPeopleCounted = 0;
			var countedDay = _countedService.Get(date);

			foreach (var day in countedDay) {
				if(day.personIn == true)
                {
					peopleCounted++;
					maxPeopleCounted++;
					continue;
                }
				peopleCounted--;
			}

			if (countedDay == null)
			{
				return NotFound();
			}
			if (peopleCounted < 0) {
				peopleCounted = 0;
			}

			return new PeopleCount(peopleCounted, maxPeopleCounted);
		}

		[HttpPost]
		public ActionResult<CountDay> Create(CountDay countedDay)
		{
			//if statement to check if ID(date) alrdy exists 
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