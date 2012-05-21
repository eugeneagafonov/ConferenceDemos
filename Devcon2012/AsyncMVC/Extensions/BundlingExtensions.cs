using System.Web.Optimization;

namespace AsyncMVC
{
	public static class BundlingExtensions
	{
		public static void EnableBootstrapBundle(this BundleCollection bundles)
		{
			var bootstrapCss = new Bundle("~/bootstrap/css", new CssMinify());
			bootstrapCss.AddFile("~/content/bootstrap.css");
			bootstrapCss.AddFile("~/content/bootstrap-responsive.css");

			bundles.Add(bootstrapCss);

			var bootstrapJs = new Bundle("~/bootstrap/js", new JsMinify());
			bootstrapJs.AddFile("~/scripts/bootstrap.js");

			bundles.Add(bootstrapJs);
		}
	}
}