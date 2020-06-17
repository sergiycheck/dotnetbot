using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using File = System.IO.File;

namespace WebAppBot.Models.Commands
{
    public class PictureCommand : MyBotCommand
    {
        public override string Name => "picture";//some name to trigger command

        public override async Task<Message> Execute(Message message, CallbackQuery query)
        {
            var chatId = message.Chat.Id;
            string path = "..\\..\\..\\..\\WebAppBot\\Resources\\honda-nsx_1.jpg";
            string absolutePath = @"E:\filesFromCDisk\TelegramBot\WebAppBot\Resources\honda-nsx_1.jpg";
            string url2 = "https://wallpaperset.com/w/full/f/3/3/396056.jpg";
            using (FileStream fileStream = File.Open(absolutePath,FileMode.Open))
            {
                InputOnlineFile photo = new InputOnlineFile(fileStream);
                photo.FileName = Path.GetFileName(absolutePath);
                if(photo.Content!=null) await Bot.BotClient.SendPhotoAsync(chatId, photo, "Car from disk");
                return await Bot.BotClient.SendPhotoAsync(chatId, url2, "Revolution!");
            }


        }
    }
}
