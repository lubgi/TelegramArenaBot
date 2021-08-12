using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace ArenaTelegramBotAzure.Domain.Menus
{
    public abstract class AbstractMenu
    {
        public static ITelegramBotClient Bot;
        public virtual string Text { get; set; }
        public virtual InlineKeyboardMarkup InlineKeyboard { get; set; }
        public virtual ReplyKeyboardMarkup Keyboard { get; set; }
        public virtual string State { get; }

        public virtual async Task<Message> Execute(long ChatId)
        {
            return await Bot.SendTextMessageAsync(chatId: ChatId,
                text: Text,
                replyMarkup: InlineKeyboard);
        }
    }
}
