using BLL.Services.Interfaces;
 
using Telegram.Bot;

namespace BLL.Services
{
    public class TelegramBot : ITelegramBot
    {
        private readonly ITelegramBotClient _botClient;

        public TelegramBot(string apiKey)
        {
            _botClient = new TelegramBotClient(apiKey);
        }

        public async Task SendTaskNotificationAsync(string chatId, string message)
        {
            try
            {
                await _botClient.SendTextMessageAsync(chatId, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending message to Telegram: {ex.Message}");
            }
        }
    }
}
