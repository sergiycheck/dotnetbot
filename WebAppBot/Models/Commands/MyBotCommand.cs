using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace WebAppBot.Models.Commands
{
    public abstract  class MyBotCommand
    {
        public abstract string Name { get; }//some name to trigger command

        public abstract Task<Message> Execute(Message message, CallbackQuery query );

        public virtual bool Contains(Message message)
        {
            var typeTxt = MessageType.Text;
            if (message == null) return false;
            if (message.Type != typeTxt)
                return false;

            return message.Text.Contains(this.Name);
        }

        public virtual bool Contains(CallbackQuery callback)
        {
            if (callback == null) 
                return false;
            return callback.Data.Contains(this.Name);
        }
    }
}
