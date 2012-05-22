using System;
using System.Collections.Generic;

namespace AsyncMVC
{
	public class ViewModel
	{
		public IEnumerable<NewsModel> News { get; set; }

		public TimeSpan Elapsed { get; set; }
	}
}