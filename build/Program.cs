using Microsoft.DocAsCode;

namespace ConsoleApp1
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			await Docset.Build("docfx.json");
		}
	}
}