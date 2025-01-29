using System.Diagnostics;
using ClassSchedule.Models;
using ClassSchedule.Models.DataLayer;
using ClassSchedule.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace ClassSchedule.Controllers
{
	public class HomeController : Controller
	{
		private Repository<Class> classes { get; set; }
		private Repository<Day> days { get; set; }
		public HomeController(ClassScheduleContext context)
		{
			classes = new Repository<Class>(context);
			days = new Repository<Day>(context);
		}

		public IActionResult Index(int id)
		{
			var dayOptions = new QueryOptions<Day>
			{
				OrderBy = d => d.DayId
			};
			var classOptions = new QueryOptions<Class>
			{
				Includes = "Teacher,Day"
			};

			if (id == 0)
			{
				classOptions.OrderBy = c => c.DayId;
				classOptions.ThenOrderBy = c => c.MilitaryTime;
			}
			else
			{
				classOptions.Where = c => c.DayId == id;
				classOptions.OrderBy = c => c.MilitaryTime;
			}

			// Executing the queries
			var dayList = days.List(dayOptions);
			var classList = classes.List(classOptions);

			// Sending the data to the view
			ViewBag.Id = id;
			ViewBag.Days = dayList;

			return View(classList);
		}
	}
}
