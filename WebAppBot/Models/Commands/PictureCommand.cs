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
            string relativePath = String.Empty;
            try
            {
                string dir = Directory.GetCurrentDirectory();
                var counter = 0;
                for (int i = dir.Length; i > 0; i--)
                {

                    if (dir[i - 1].Equals('\\'))
                    {
                        counter++;
                        if (counter == 4) break;

                    }

                    dir = dir.Remove(i - 1, 1);

                }

                relativePath = dir + "WebAppBot\\Resources\\honda-nsx_1.jpg";
                relativePath = relativePath.Replace(@"\", "/");
                using (FileStream fileStream = File.Open(relativePath, FileMode.Open))
                {
                    InputOnlineFile photo = new InputOnlineFile(fileStream);
                    photo.FileName = Path.GetFileName(relativePath);
                    if (photo.Content != null) await Bot.BotClient.SendPhotoAsync(chatId, photo, "Car from disk");

                }
            }
            catch (Exception e)
            {
                //relativePath = "../../../Resources/honda-nsx_1.jpg";
            }

            
            string radomPhotoUrl = "https://source.unsplash.com/random";
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


            return await Bot.BotClient.SendPhotoAsync(chatId, radomPhotoUrl, "Random photo!");

        }
    }
}
