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
        private static List<MyBotCommand> commandsList;
        public static IReadOnlyList<MyBotCommand> Commands => commandsList.AsReadOnly();

        public static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (BotClient != null) return BotClient;
            

            commandsList = new List<MyBotCommand>();
            commandsList.Add(new StartCommand());
            commandsList.Add(new PictureCommand());
            commandsList.Add(new ButtonCommands());
            commandsList.Add(new InlineButtonReplyCommand());
            commandsList.Add(new InlineButtonReplyCommandSecond());
            commandsList.Add(new ReplyButtonCommands());
            commandsList.Add(new ReplyButtonCommandFirst());
            commandsList.Add(new ReplyButtonCommandSecond());
            commandsList.Add(new ReplyCommand());
            
            
            //TODO: Add more commands

            
            BotClient = new TelegramBotClient(BotSettings.Key);//set key for our bot
            string hook = string.Format(BotSettings.Url, "api/message/update");
            await BotClient.SetWebhookAsync(hook);
            return BotClient;
        }
    }
}
