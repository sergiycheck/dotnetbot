using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace WebAppBot.Models.Commands
{
    public class StartCommand : BotCommand
    {
        public override string Name => @"/start";

        public override bool Contains(Message message)
        {
            var typeTxt = Telegram.Bot.Types.Enums.MessageType.Text;
            if (message.Type != typeTxt)
                return false;

            return message.Text.Contains(this.Name);
        }

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;
            await botClient.
                SendTextMessageAsync
                    (chatId, "Hallo I'm ASP.NET Core Bot", 
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
