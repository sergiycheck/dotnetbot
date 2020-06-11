using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HttpTelegBot
{
    public class BotConfiguration
    {
        private readonly HttpClient _client;
        public static string Url = 
            "https://api.telegram.org/bot1286361652:AAHbNsjhcb2Y9zEP9eGBgIXwCQu9dpcP8Zg/";

        public static string WebHookUrl = "https://14cd7a31a876.ngrok.io";

        public BotConfiguration()
        {
            _client = new HttpClient();
        }

        public async Task<string> SetWebHook()
        {
            var response = string.Empty;

            var payload = new Dictionary<string,string>
            {
                {"url",WebHookUrl}
            };
            string strPayLoad = JsonConvert.SerializeObject(payload);
            HttpContent content = 
                new StringContent(strPayLoad, Encoding.UTF8,"application/json");
            var mess = await _client.PostAsync($"{Url}setWebhook",content);
            if (mess.IsSuccessStatusCode)
            {
                response = mess.StatusCode.ToString();
            }

            return response;
        }
    }
}
