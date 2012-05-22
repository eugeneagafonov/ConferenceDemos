using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsyncMVCOld
{
	public static class NewsModelExtensions
	{
		public static IEnumerable<NewsModel> Convert(
			this IEnumerable<NewsServiceReference.NewsModel> result)
		{
			return from n in result
						 select new NewsModel
						 {
							 Date = n.Date,
							 Heading = n.Heading,
							 Text = n.Text
						 };
		}
	}
}