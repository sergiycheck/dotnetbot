using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace WebAppBot.Models.Commands
{
    public class ButtonCommands : MyBotCommand
    {
        public override string Name => "/inline_buttons";//some name to trigger command

        public override async Task<Message> Execute(Message message, CallbackQuery query)
        {
            //1 creating keyboard
            //creating types arr of InlineKeyboardMarkup with first InlineKeyboardbutton column and second
            var keyboard = new InlineKeyboardMarkup(
                    new InlineKeyboardButton[][]
                    {
                        //first row
                        new []
                        {
                            // column 1
                            InlineKeyboardButton.WithCallbackData("first","callback1button"),
                            // column 1
                            InlineKeyboardButton.WithCallbackData("second","callback2buttoon"),
                        },
                    }
            );
            var chatId = message.Chat.Id;
            return await Bot.BotClient.SendTextMessageAsync
            (chatId,
                "Choose first or second",
                parseMode: ParseMode.Default,
                false,
                false,
                0,
                keyboard
            );
        }
    }
}
