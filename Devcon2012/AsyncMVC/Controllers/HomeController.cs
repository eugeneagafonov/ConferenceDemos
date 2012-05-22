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
	}
}