using System.Threading.Tasks;
using System.Web.Mvc;

namespace AsyncMVC.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public Task<ViewResult> IndexAsync()
		{
			return Task<ViewResult>.Factory.StartNew(
				() => View("Index")
			);
		}
	}
}