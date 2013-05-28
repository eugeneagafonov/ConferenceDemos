using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpServer
{
	internal class Program
	{
		private static bool KeepGoing = true;

		private static void Main(string[] args)
		{
			HttpListener listener = new HttpListener();
			listener.Prefixes.Add("http://+:8088/");
			listener.Start();
			ProcessAsync(listener);

			var cmd = Console.ReadLine();

			if (null != cmd && cmd.Equals("q", StringComparison.OrdinalIgnoreCase))
			{
				KeepGoing = false;
			}

			Console.ReadLine();
		}

		private static async Task ProcessAsync(HttpListener listener)
		{
			while (KeepGoing)
			{
				HttpListenerContext context = await listener.GetContextAsync();
				HandleRequestAsync(context);
			}
		}

		private static async Task HandleRequestAsync(HttpListenerContext context)
		{
			Perform(context);
		}

		private static void Perform(HttpListenerContext ctx)
		{
			HttpListenerResponse response = ctx.Response;
			string responseString = "<html><body>Hello world!</body></html>";
			byte[] buffer = Encoding.UTF8.GetBytes(responseString);

			// Get a response stream and write the response to it.
			response.ContentLength64 = buffer.Length;
			Stream output = response.OutputStream;
			output.Write(buffer, 0, buffer.Length);

			// You must close the output stream.
			output.Close();
		}
	}
}