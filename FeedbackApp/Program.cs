using FeedbackApp;
using FeedbackApp.Commands;
internal class Program
{
    private static void Main(string[] args)
    {
        //Добавить условие уникальности никнейма
        Bot bot = new Bot();
        bot.Run();

        Console.ReadLine();
    }
}