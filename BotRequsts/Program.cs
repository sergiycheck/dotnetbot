using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BotRequsts
{
    class Program
    {
        static async Task TestHttp()
        {
            HttpClient _httpClient = new HttpClient();
            HttpRequestMessage mess = new HttpRequestMessage(HttpMethod.Get, new Uri("https://api.telegram.org/bot1286361652:AAHbNsjhcb2Y9zEP9eGBgIXwCQu9dpcP8Zg/getUpdates"));
            var str = await _httpClient.GetStringAsync(
                "https://api.telegram.org/bot1286361652:AAHbNsjhcb2Y9zEP9eGBgIXwCQu9dpcP8Zg/getUpdates");
            Console.WriteLine(str);
        }
        static void Main(string[] args)
        {
            TestHttp().Wait();
        }
    }
}
