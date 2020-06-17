using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Telegram.Bot;
using WebAppBot.Models.Commands;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using WebAppBot.Controllers;

namespace Bot.Tests
{
    [TestFixture]
    public class BotTester
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
            Text = "/inline_buttons"//text doesn't matter as it is not checked
        };

        private static readonly Update Update = new Update()
        {
            Id = 650785974,
            Message = Mes
        };

        [Test]
        public async Task TestReplyCommand()
        {

            PictureCommand command = new PictureCommand();
            var botClient = await WebAppBot.Models.Bot.GetBotClientAsync();
            try
            {
                await command.Execute(Mes, botClient);
            }
            catch (Exception ex)
            {
                Assert.IsNull(ex);
            }
            
        }
    }
}
