using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AsyncMVCOld.WCF
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INewsService" in both code and config file together.
	[ServiceContract]
	public interface INewsService
	{
		[OperationContract]
		IEnumerable<NewsModel> GetWorldNews();

		[OperationContract]
		IEnumerable<NewsModel> GetSportNews();

		[OperationContract]
		IEnumerable<NewsModel> GetFunNews();
	}
}
