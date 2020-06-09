using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using WebAppBot.Models.Commands;

namespace WebAppBot.Models
{
    public class Bot
    {
        public static TelegramBotClient BotClient;
        private static List<BotCommand> commandsList;

        public static IReadOnlyList
            <BotCommand> 
            Commands => commandsList.AsReadOnly();

        public static async Task<TelegramBotClient> 
            GetBotClientAsync()
        {
            if (BotClient != null)
            {
                return BotClient;
            }

            commandsList = new List<BotCommand>();
            commandsList.Add(new StartCommand());
            //TODO: Add more commands

            BotClient = new TelegramBotClient(BotSettings.Key);
            string hook = string.
                Format
                    (BotSettings.Url, "api/message/update");
            await BotClient.SetWebhookAsync(hook);
            return BotClient;
        }
    }
}
