
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;


namespace TelegramBot
{
    public class TelegBot
    {
        private  const string Token = "1286361652:AAHbNsjhcb2Y9zEP9eGBgIXwCQu9dpcP8Zg";
        private static TelegramBotClient _client;
        
        public TelegBot()
        {
            _client=new TelegramBotClient(Token);
            _client.OnMessageEdited += BotOnMessageReceived;
            _client.OnMessage += BotOnMessageReceived;
            //_client.SetWebhookAsync("https://6a348fe4095e.ngrok.io").Wait();

            _client.StartReceiving();
            Console.ReadLine();
            _client.StopReceiving();
            _client.DeleteWebhookAsync().Wait();

        }

        private async void BotOnMessageReceived(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            if (message?.Type == MessageType.Text)
            {
                await _client.SendTextMessageAsync(message.Chat.Id, message.Text);
            }
        }
    }

}
