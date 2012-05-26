using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Mvc.Async;

namespace AsyncMVCOld
{
	public class TaskAsyncActionInvoker : AsyncControllerActionInvoker
	{
		protected override ControllerDescriptor GetControllerDescriptor(
			ControllerContext controllerContext)
		{
			return new TaskAsyncControllerDescriptor(
				controllerContext.Controller.GetType());
		}
	}
}