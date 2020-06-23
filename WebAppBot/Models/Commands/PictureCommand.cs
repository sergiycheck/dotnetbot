using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
            string url2 = "https://source.unsplash.com/random";
            string onlyUrl = "https://source.unsplash.com";
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(onlyUrl);
            var response = await httpClient.GetAsync("/random");
            response.EnsureSuccessStatusCode();
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                InputOnlineFile randomPhoto = new InputOnlineFile(responseStream);
                await Bot.BotClient.SendPhotoAsync(chatId, randomPhoto, " Random Photo from stream ");
            }

            using (FileStream fileStream = File.Open(absolutePath,FileMode.Open))
            {
                InputOnlineFile photo = new InputOnlineFile(fileStream);
                photo.FileName = Path.GetFileName(absolutePath);
                if(photo.Content!=null) await Bot.BotClient.SendPhotoAsync(chatId, photo, "Car from disk");
                return await Bot.BotClient.SendPhotoAsync(chatId, url2, "Random photo!");
            }


        }
    }
}
