using System;
using System.Collections.Generic;

namespace AsyncMVCOld
{
	public class ViewModel
	{
		public IEnumerable<NewsModel> News { get; set; }

		public TimeSpan Elapsed { get; set; }
	}
}