using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace AwaitAsyncTest1
{
	internal class Program
	{
		static Task<long> Sum()
		{
			return Task.Run(() =>
			{
				long sum = 0;
				for (long i = 0; i <= 1E09; i++)
				{
					sum += i;
				}
				return sum;
			});
		}


		static async void Main(string[] args)
		{
			//Sum().Wait();
			//long result = Sum().Result;

			long result = await Sum();

			Console.WriteLine("Result = {0}", result);

			using(StreamWriter writer = new StreamWriter("result.txt"))
			{
				for (int i = 0; i < 1000000; i++)
				{
					await writer.WriteLineAsync(i.ToString());
				}
			}

		}
	}
}