using System.Threading.Tasks;
using System.Web.Mvc;

namespace AsyncMVCOld.Controllers
{
	// uncomment taskasynccontroller
	public class NewAsyncController : AsyncController // TaskAsyncController
	{
		public Task<ViewResult> Index()
		{
			return Task<ViewResult>.Factory.StartNew(
					() => View()
				);
		}
	}
}