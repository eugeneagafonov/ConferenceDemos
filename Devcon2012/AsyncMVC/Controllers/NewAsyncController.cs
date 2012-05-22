using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AsyncMVC.NewsServiceMVC4Reference;

namespace AsyncMVC.Controllers
{
	public class NewAsyncController : Controller
	{
		public async Task<ActionResult> Index()
		{
			using (var client = new NewsServiceMVC4Client())
			{
				var timer = new Stopwatch();
				timer.Start();

				var worldNews = await client.GetWorldNewsAsync();
				var sportNews = await client.GetSportNewsAsync();
				var funNews = await client.GetFunNewsAsync();

				var result = worldNews
					.Union(sportNews)
					.Union(funNews)
					.Convert();

				timer.Stop();

				var model = new ViewModel {News = result, Elapsed = timer.Elapsed};

				return View(model);
			}
		}

		public async Task<ActionResult> Index2()
		{
			using (var client = new NewsServiceMVC4Client())
			{
				var timer = new Stopwatch();
				timer.Start();

				var allNews = await Task.WhenAll(
					client.GetWorldNewsAsync(),
				  client.GetSportNewsAsync(),
				  client.GetFunNewsAsync()
				);

				IEnumerable<NewsModel> result = new List<NewsModel>();
				result = allNews.Aggregate(result, 
					(current, news) => current.Concat(news.Convert()));


				var model = new ViewModel {News = result, Elapsed = timer.Elapsed};
				timer.Stop();

				return View("Index", model);
			}
		}
	}
}