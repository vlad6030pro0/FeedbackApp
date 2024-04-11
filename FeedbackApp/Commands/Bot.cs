using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using FeedbackApp.Commands;

namespace FeedbackApp.Commands
{
    public class Bot
    {
        public const int adminChatId = 1327824167;
        public static TelegramBotClient bot = new TelegramBotClient("6784449161:AAGBOu_YNeGSXcFjYYcarNctFz3L9PuxHi4");

        public void Run()
        {
            bot.StartReceiving(HandlerUpdateAsync,HandlerErrorAsync);

            Console.WriteLine("[BOT]: Бот запущен!");

            Console.ReadLine();
            Console.WriteLine("[BOT]: Бот остановлен!");
        }

        private Task HandlerErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            Console.WriteLine($"[EXCEPTION]: {exception.Message}");
            return null;
        }

        private async Task HandlerUpdateAsync(ITelegramBotClient client, Update update, CancellationToken token)
        {
            /*
            for (int i = 0; i < 10; i++)
            {
                await client.SendTextMessageAsync(1327824167, "axaxaxaxa");
                Thread.Sleep(1000);
            }*/

            Message message = update.Message;
            if(message != null)
            {
                string username = message.Chat.Username;
                string messagetext = message.Text;

                DBMethods.AddUser(username, (int)message.Chat.Id);
                FeedbackApp.Models.Models.User user = DBMethods.FindUserByUsername(username);
                DBMethods.AddMessage(messagetext, user.Id);

                await Console.Out.WriteLineAsync($"[{username}]: {message.Text}");
                
                await SendMessage(client, message, "Спасибо за отзыв!");

                if(message.Chat.Id!=adminChatId)
                {
                    string result = $"@{username}:\n" + messagetext;
                    await SendMessage(client, adminChatId, result); 
                }
            }
        }

        private async Task SendMessage(ITelegramBotClient client,Message message, string text)
        {
            await client.SendTextMessageAsync(message.Chat.Id,text);
        }
        private async Task SendMessage(ITelegramBotClient client,int chatId, string text)
        {
            await client.SendTextMessageAsync(chatId, text);
        }
    }
}
