using System;
using System.Collections.Generic;
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

		public Task<ViewResult> Index2()
		{
			var tcs = new TaskCompletionSource<ViewResult>();

			var client = new ServiceDecorator(new NewsServiceClient());

			var timer = new Stopwatch();
			timer.Start();

			var worldNews = client.GetWorldNewsTaskAsync();
			var sportNews = client.GetSportNewsTaskAsync();
			var funNews = client.GetFunNewsTaskAsync();

			var allNews = Task.WhenAll(worldNews, sportNews, funNews);

			allNews.ContinueWith(r =>
			{
				IEnumerable<NewsModel> result = new List<NewsModel>();
				result = r.Result.Aggregate(result,
					(current, news) => current.Concat(news.Convert()));
				var model = new ViewModel { News = result, Elapsed = timer.Elapsed };
				tcs.SetResult(View("Index", model));
				timer.Stop();
			});	

			return tcs.Task;
		}

		public Task<ViewResult> Index3()
		{
			var service = new NewsServiceClient();
			var client = new ServiceDecorator(service);

			return
				from w in client.GetWorldNewsTaskAsync()
				from s in client.GetSportNewsTaskAsync()
				from f in client.GetFunNewsTaskAsync()
				let all = w.Union(s).Union(f).Convert()
				select View("Index",
					new ViewModel { News = f.Convert(), Elapsed = TimeSpan.FromSeconds(2) });
		}



		private class ServiceDecorator
		{
			private readonly NewsServiceClient _client;
			public ServiceDecorator(NewsServiceClient client)
			{
				_client = client;
			}

			public Task<IEnumerable<NewsServiceReference.NewsModel>> GetWorldNewsTaskAsync()
			{
				return Task<IEnumerable<NewsServiceReference.NewsModel>>.Factory.FromAsync(
					_client.BeginGetWorldNews, _client.EndGetWorldNews, null);
			}

			public Task<IEnumerable<NewsServiceReference.NewsModel>> GetSportNewsTaskAsync()
			{
				return Task<IEnumerable<NewsServiceReference.NewsModel>>.Factory.FromAsync(
					_client.BeginGetSportNews, _client.EndGetSportNews, null);
			}

			public Task<IEnumerable<NewsServiceReference.NewsModel>> GetFunNewsTaskAsync()
			{
				return Task<IEnumerable<NewsServiceReference.NewsModel>>.Factory.FromAsync(
					_client.BeginGetFunNews, _client.EndGetFunNews, null);
			}
		}
	}
}