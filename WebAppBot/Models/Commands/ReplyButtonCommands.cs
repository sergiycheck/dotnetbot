using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace WebAppBot.Models.Commands
{
    public class ReplyButtonCommands : MyBotCommand
    {
        public override string Name => "reply_buttons";
        public static string FirstRepButOp = "first button option";
        public static string SecondRepButOp = "second button option";
        public override async Task<Message> Execute(Message message, CallbackQuery query)
        {
            var keyboard = new ReplyKeyboardMarkup()
            {
                Keyboard = new []
                {
                    new[] //first row
                    {
                        new KeyboardButton(FirstRepButOp),
                        new KeyboardButton(SecondRepButOp), 
                    },
                },
                ResizeKeyboard = true,
                OneTimeKeyboard = true
            };
            return await Bot.BotClient.SendTextMessageAsync(message.Chat.Id, "Reply buttons text", replyMarkup: keyboard);
        }
    }
}