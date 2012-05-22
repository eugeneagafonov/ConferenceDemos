using System;
using System.Collections.Generic;
using System.Threading;

namespace AsyncMVC.WCF
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NewsServiceMVC4" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select NewsServiceMVC4.svc or NewsServiceMVC4.svc.cs at the Solution Explorer and start debugging.
	public class NewsServiceMVC4 : INewsServiceMVC4
	{
		public IEnumerable<NewsModel> GetWorldNews()
		{
			Thread.Sleep(2000);
			return new[] {
				new NewsModel
			  {
					Date = DateTime.Now,
					Heading = "Срочные новости!",
					Text = "Евгений Агафонов выступает на конференции DevCon 2012!"
			  }
			};
		}

		public IEnumerable<NewsModel> GetSportNews()
		{
			Thread.Sleep(1000);
			return new[] {
				new NewsModel
			  {
					Date = DateTime.Now.AddDays(-3),
					Heading = "Red Machine is back!",
					Text = @"Сборная России выиграла чемпионат мира по хоккею. 
									В финальном матче наша команда одержала победу над
									сборной Словакии со счетом 6 : 2."
			  },
				new NewsModel
			  {
					Date = DateTime.Now.AddDays(-4),
					Heading = "И еще про футбол",
					Text = "Лондонский Челси выиграл финал Лиги Чемпионов"
			  }
			};
		}

		public IEnumerable<NewsModel> GetFunNews()
		{
			Thread.Sleep(1000);
			return new[] {
				new NewsModel
			  {
					Date = DateTime.Now,
					Heading = "Наш юмор",
					Text = @"висит на сцене в первом акте<br/>
									бензопила ведро и ёж<br/>
									заинтригован Станиславский<br/>
									боится выйти в туалет"
			  }
			};
		}
	}
}
