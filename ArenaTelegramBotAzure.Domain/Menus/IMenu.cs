using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace ArenaTelegramBotAzure.Domain.Menus
{
    public interface IMenu
    {
        public static string Text { get; set; }
        public static InlineKeyboardMarkup InlineKeyboard { get; set; }
        public static ReplyKeyboardMarkup Keyboard { get; set; }
        public static string State { get; }

        private static async Task<Message> Execute(long ChatId, ITelegramBotClient Bot)
        {
            return await Bot.SendTextMessageAsync(chatId: ChatId,
                text: Text,
                replyMarkup: InlineKeyboard);
        }
        
    }
}
