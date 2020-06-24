using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using WebAppBot.Controllers;
using WebAppBot.Models;
using Xunit;
using Xunit.Sdk;
using File = System.IO.File;

namespace XUnitTestsBot
{
    public class WebAppBotTests
    {
        private static readonly Message Mes = new Message()
        {
            MessageId = 650785965,
            Date = DateTime.Now,
            Chat = new Chat()
            {
                Id = 421413289,
                Type = ChatType.Private
            },
            Text = "picture"
        };

        private static readonly Update Update = new Update()
        {
            Id = 650785974,
            Message = Mes
        };

        private static readonly CallbackQuery query = new CallbackQuery()
        {
            
        };
        [Fact]
        public async Task TestMessageController()
        {
            
            var messController = new MessageController();
            var response = await messController.Post(Update);

            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public string TestStringRemoving()
        {
            string dir = Directory.GetCurrentDirectory();
            var counter = 0;
            for (int i = dir.Length; i > 0; i--)
            {

                if (dir[i-1].Equals('\\'))
                {
                    counter++;
                    if (counter == 4) break;

                }

                dir = dir.Remove(i-1, 1);

            }

            return dir;
        }
        //[Fact]
        //public async Task TestCallBackFromBot()
        //{
        //    using (StreamReader stream = new StreamReader("../../../test_data/ms_w_cb.json"))
        //    {
        //        string json = await stream.ReadToEndAsync();
        //        var updateWithCallBack = JsonConvert.DeserializeObject<Update>(json);
        //        var messController = new MessageController();
        //        var response = await messController.Post(updateWithCallBack);
        //    }
        //}
    }
}
