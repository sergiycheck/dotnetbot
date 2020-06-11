using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using WebAppBot.Models.Commands;

namespace WebAppBot.Models
{
    public class Bot
    {
        public static TelegramBotClient BotClient;
        private static List<IBotCommand> commandsList;
        public static IReadOnlyList<IBotCommand> Commands => commandsList.AsReadOnly();

        public static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (BotClient != null) return BotClient;
            

            commandsList = new List<IBotCommand>();
            commandsList.Add(new StartCommand());
            commandsList.Add(new ReplyCommand());
            //TODO: Add more commands

            
            BotClient = new TelegramBotClient(BotSettings.Key);//set key for our bot
            string hook = string.Format(BotSettings.Url, "api/message/update");
            await BotClient.SetWebhookAsync(hook);
            return BotClient;
        }
    }
}
