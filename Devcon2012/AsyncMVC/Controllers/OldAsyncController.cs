using System.Web.Mvc;

namespace AsyncMVC.Controllers
{
	public class OldAsyncController : AsyncController
	{
		public void IndexAsync()
		{
		}

		public ActionResult IndexCompleted()
		{
			return View();
		}
	}
}