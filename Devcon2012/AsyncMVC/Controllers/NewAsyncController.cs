using System.Threading.Tasks;
using System.Web.Mvc;

namespace AsyncMVC.Controllers
{
	public class NewAsyncController : Controller
	{
		public Task<ViewResult> Index()
		{
			return Task<ViewResult>.Factory.StartNew(
				() => View()
			);
		}
	}
}