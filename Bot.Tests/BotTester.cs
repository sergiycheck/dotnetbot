using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Telegram.Bot;
using WebAppBot.Models.Commands;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Bot.Tests
{
    [TestFixture]
    public class BotTester
    {
        [Test]
        public async Task TestReplyCommand()
        {
            Message mes = new Message()
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
            PictureCommand command = new PictureCommand();
            var botClient = await WebAppBot.Models.Bot.GetBotClientAsync();
            try
            {
                await command.Execute(mes, botClient);
            }
            catch (Exception ex)
            {
                Assert.IsNull(ex);
            }
            
        }
    }
}
