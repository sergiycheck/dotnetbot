using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace WebAppBot.Models.Commands
{
    public class InlineButtonReplyCommandSecond : MyBotCommand
    {
        public override string Name => "callback2buttoon";

        public override async Task<Message> Execute(Message message, CallbackQuery query)
        {
            await Bot.BotClient.AnswerCallbackQueryAsync(query.Id, $"second option {query.Data}", true);
            return await Bot.BotClient.SendTextMessageAsync(query.Message.Chat.Id, "this is reply",
                replyToMessageId: query.Message.MessageId);
        }
    }
}
