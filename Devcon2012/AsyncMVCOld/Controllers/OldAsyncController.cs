using System.Web.Mvc;

namespace AsyncMVCOld.Controllers
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
