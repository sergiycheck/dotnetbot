using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace WebAppBot.Models.Commands
{
    public class StartCommand : MyBotCommand
    {
        public  override string Name => @"/start";

        public override async Task<Message> Execute(Message message, CallbackQuery query)
        {
            var chatId = message.Chat.Id;
            return await Bot.BotClient.SendTextMessageAsync(chatId, "Hello I'm ASP.NET Core Bot", parseMode: ParseMode.Markdown);
        }
    }
}
