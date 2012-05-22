using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AsyncMVC.NewsServiceMVC4Reference;

namespace AsyncMVC.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			using (var client = new NewsServiceMVC4Client())
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

				var model = new ViewModel { News = result, Elapsed = timer.Elapsed };

				return View(model);
			}
		}
	}
}