using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AsyncMVC.WCF
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INewsServiceMVC4" in both code and config file together.
	[ServiceContract]
	public interface INewsServiceMVC4
	{
		[OperationContract]
		IEnumerable<NewsModel> GetWorldNews();

		[OperationContract]
		IEnumerable<NewsModel> GetSportNews();

		[OperationContract]
		IEnumerable<NewsModel> GetFunNews();
	}
}
