using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AsyncMVCOld.Controllers
{
    public class HomeController : TaskAsyncController
    {
        //
        // GET: /Home/
			public ActionResult Index()
			{
				return View();
			}

			public Task<ViewResult> IndexAsync()
			{
				return Task<ViewResult>.Factory.StartNew(() => View("Index"));
			}

    }
}
