using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using AsyncMVCOld.NewsServiceReference;
using System.Collections.Generic;

namespace AsyncMVCOld.Controllers
{
	public class OldAsyncController : AsyncController
	{
		private readonly Stopwatch _timer = new Stopwatch();

		public void IndexAsync()
		{
			AsyncManager.OutstandingOperations.Increment(3);
			var service = new NewsServiceClient();
			service.GetWorldNewsCompleted += service_GetWorldNewsCompleted;
			service.GetSportNewsCompleted += service_GetSportNewsCompleted;
			service.GetFunNewsCompleted += service_GetFunNewsCompleted;

			service.GetWorldNewsAsync();
			service.GetSportNewsAsync();
			service.GetFunNewsAsync();

			_timer.Start();
		}

		void service_GetFunNewsCompleted(object sender, GetFunNewsCompletedEventArgs e)
		{
			AsyncManager.OutstandingOperations.Decrement();
			var localResult = e.Result;

			if(!AsyncManager.Parameters.ContainsKey("result"))
			{
				AsyncManager.Parameters["result"] = localResult.Convert();
			}
			else
			{
				var result = AsyncManager.Parameters["result"] as IEnumerable<NewsModel>;
				AsyncManager.Parameters["result"] = result.Union(localResult.Convert());
			}
		}

		void service_GetSportNewsCompleted(object sender, GetSportNewsCompletedEventArgs e)
		{
			AsyncManager.OutstandingOperations.Decrement();
			var localResult = e.Result;

			if (!AsyncManager.Parameters.ContainsKey("result"))
			{
				AsyncManager.Parameters["result"] = localResult.Convert();
			}
			else
			{
				var result = AsyncManager.Parameters["result"] as IEnumerable<NewsModel>;
				AsyncManager.Parameters["result"] = result.Union(localResult.Convert());
			}
		}

		void service_GetWorldNewsCompleted(object sender, GetWorldNewsCompletedEventArgs e)
		{
			AsyncManager.OutstandingOperations.Decrement();
			var localResult = e.Result;

			if (!AsyncManager.Parameters.ContainsKey("result"))
			{
				AsyncManager.Parameters["result"] = localResult.Convert();
			}
			else
			{
				var result = AsyncManager.Parameters["result"] as IEnumerable<NewsModel>;
				AsyncManager.Parameters["result"] = result.Union(localResult.Convert());
			}
		}

		public ActionResult IndexCompleted(IEnumerable<NewsModel> result)
		{
			_timer.Stop();
			var model = new ViewModel{ News = result, Elapsed = _timer.Elapsed};

			return View(model);
		}
	}
}
