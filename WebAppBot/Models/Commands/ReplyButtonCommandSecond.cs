using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using WebAppBot.Models.Commands;

namespace WebAppBot.Models
{
    public class ReplyButtonCommandSecond : MyBotCommand
    {
        public override string Name =>ReplyButtonCommands.SecondRepButOp;

        public override async Task<Message> Execute(Message message, CallbackQuery query)
        {
            var chatId = message.Chat.Id;
            return await Bot.BotClient.SendTextMessageAsync(chatId, "option second", replyToMessageId: message.MessageId);
        }
    }
}