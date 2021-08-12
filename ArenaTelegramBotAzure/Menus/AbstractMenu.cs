using System.Threading.Tasks;
using ArenaTelegramBotAzure.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace ArenaTelegramBotAzure.Menus
{
    public interface IMenu
    {
        protected static readonly ITelegramBotClient Bot = HandleUpdateService.Bot;
        public static string Text { get; set; }
        public static InlineKeyboardMarkup InlineKeyboard { get; set; }
        public static ReplyKeyboardMarkup Keyboard { get; set; }
        public static string State { get; }

        private static async Task<Message> Execute(long ChatId)
        {
            return await Bot.SendTextMessageAsync(chatId: ChatId,
                text: Text,
                replyMarkup: InlineKeyboard);
        }
    }
}
