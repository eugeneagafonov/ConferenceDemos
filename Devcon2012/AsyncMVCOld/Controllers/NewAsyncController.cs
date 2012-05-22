using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AsyncMVCOld.NewsServiceReference;

namespace AsyncMVCOld.Controllers
{
	// uncomment taskasynccontroller
	public class NewAsyncController : TaskAsyncController // TaskAsyncController
	{
		public Task<ViewResult> Index()
		{
			return Task<ViewResult>.Factory.StartNew(() =>
			{
				using (var client = new NewsServiceClient())
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
			});
		}

		#region вариант 1
		//public Task<ViewResult> Index()
		//{
		//	return Task<ViewResult>.Factory.StartNew(
		//		() => View()
		//		);
		//}
		#endregion
	}
}