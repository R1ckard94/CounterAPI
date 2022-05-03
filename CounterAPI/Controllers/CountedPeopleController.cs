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
		public ActionResult<PeopleCount> GetPeopleCount(string date)
		{
			
			int peopleCounted = 0;
			int maxPeopleCounted = 0;
			var countedDay = _countedService.Get(date);

			if (countedDay == null)
			{
				return NotFound();
			}

			foreach (var day in countedDay) {
				if(day.personIn == true)
                {
					peopleCounted++;
					maxPeopleCounted++;
					continue;
                }
				if (peopleCounted > 0) { //så vi inte har minus i programmet
					peopleCounted--;
				}
				
			}

			


			return new PeopleCount(peopleCounted, maxPeopleCounted);
		}

		[HttpGet("{date}/details")]
		public ActionResult<PeopleCount> GetDetails(string date)
		{

			int peopleCounted = 0;
			int maxPeopleCounted = 0;
			double time = 06.00;
			int[] array = new int[15];
			int arrCount = 0;
			var countedDay = _countedService.Get(date);

			if (countedDay == null)
			{
				return NotFound();
			}

			foreach(var timestamp in countedDay) 
            {
				if (time > 20.00) { 
					break;
				}
                if (timestamp.date_and_time.Contains(time.ToString()))
                {
					if (timestamp.personIn == true) {
						peopleCounted++;
					}
					if (timestamp.personIn == false && peopleCounted > 0) {
						peopleCounted--;
					}
                }
				array[arrCount] = peopleCounted;
				arrCount++;
				time += 1.00;
            }

			return new PeopleCount(peopleCounted, maxPeopleCounted, array);
		}

		[HttpPost]
		public ActionResult<CountDay> Create(CountDay countedDay)
		{
			
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