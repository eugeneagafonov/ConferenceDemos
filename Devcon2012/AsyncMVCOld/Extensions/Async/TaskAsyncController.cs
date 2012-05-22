using System.Web.Mvc;

namespace AsyncMVCOld
{
	[NoAsyncTimeout]
	public class TaskAsyncController : AsyncController
	{
		protected override IActionInvoker CreateActionInvoker()
		{
			return new TaskAsyncActionInvoker();
		}
	}
}