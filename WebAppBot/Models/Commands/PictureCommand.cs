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
    public class PictureCommand : IBotCommand
    {
        public string Name => "picture";//some name to trigger command
        public bool Contains(Message message)
        {
            var typeTxt = MessageType.Text;
            if (message == null) return false;
            if (message.Type != typeTxt)
                return false;

            return message.Text.Contains(this.Name);
        }

        public async Task Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            //await client.SendTextMessageAsync(chatId, $"Hello {message.Chat.FirstName}", parseMode: ParseMode.Markdown);
            //object img = Resource.ResourceManager.GetObject("honda-nsx_1.jpg");
            string path = "..\\..\\..\\..\\WebAppBot\\Resources\\honda-nsx_1.jpg";
            string absolutePath = @"E:\filesFromCDisk\TelegramBot\WebAppBot\Resources\honda-nsx_1.jpg";
            string url2 = "https://wallpaperset.com/w/full/f/3/3/396056.jpg";
            using (FileStream fileStream = File.Open(absolutePath,FileMode.Open))
            {
                
                //byte[] arr = new byte[fileStream.Length];
                //fileStream.Read(arr, 0, arr.Length);
                //MemoryStream memStream = new MemoryStream((int)fileStream.Length);
                //memStream.Write(arr, 0, arr.Length);
                InputOnlineFile photo = new InputOnlineFile(fileStream);
                photo.FileName = Path.GetFileName(absolutePath);
                if(photo.Content!=null) await client.SendPhotoAsync(chatId, photo, "Car from disk");
                await client.SendPhotoAsync(chatId, url2, "Revolution!");
            }


        }
    }
}
