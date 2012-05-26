using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AsyncMVC.NewsServiceMVC4Reference;

namespace AsyncMVC.Controllers
{
	public class OldAsyncController : Controller
	{
		public Task<ViewResult> Index()
		{
			return Task<ViewResult>.Factory.StartNew(() =>
			{
				// неправильный способ
				using (var client = new NewsServiceMVC4Client())
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

		public Task<ViewResult> Index2()
		{
			var client = new NewsServiceMVC4Client();
			var timer = new Stopwatch();
			timer.Start();

			return
				from w in client.GetWorldNewsAsync()
				from s in client.GetSportNewsAsync()
				from f in client.GetFunNewsAsync()
				let all = w.Union(s).Union(f).Convert()
				let filtered = Filter(all)
				select View("Index",
					new ViewModel 
					{ News = filtered, Elapsed = timer.Elapsed });
		}

		public IEnumerable<NewsModel> Filter(
			IEnumerable<NewsModel> originalModel)
		{
			foreach(var n in originalModel)
			{
				if(n.Text.Contains("Агафонов"))
				{
					yield return new NewsModel
					{
						Date = n.Date,
						Heading = n.Heading,
						Text = n.Text.Replace("Агафонов", "<h2>Агафонов</h2>")
					};
				}
				yield return n;
			}
							
		}
	}
}