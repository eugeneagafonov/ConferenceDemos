using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using AsyncMVCOld.NewsServiceReference;

namespace AsyncMVCOld.Controllers
{
	public class HomeController : Controller
	{
		//
		// GET: /Home/
		public ActionResult Index()
		{
			using(var client = new NewsServiceClient())
			{
				var timer = new Stopwatch();
				timer.Start();

				var worldNews = client.GetWorldNews();
				var sportNews = client.GetSportNews();
				var funNews = client.GetFunNews();

				var result = worldNews
					.Union(sportNews)
					.Union(funNews)
					.Convert();

				timer.Stop();

				var model = new ViewModel 
				{ News = result, Elapsed = timer.Elapsed };

				return View(model);
			}
		}
	}
}