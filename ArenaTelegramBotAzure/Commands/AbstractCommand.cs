using System.Threading.Tasks;
using ArenaTelegramBotAzure.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using User = ArenaTelegramBotAzure.DAL.Models.User;

namespace ArenaTelegramBotAzure.Commands
{
    public abstract class AbstractCommand
    {
        protected static readonly ITelegramBotClient Bot = HandleUpdateService.Bot;
        public static string Name { get; set; }
        public virtual string Text { get; set; }
        public virtual async Task<Message> Execute(User user)
        {
            return await Bot.SendTextMessageAsync(chatId: user.Chat.Id,
                text: Text,
                replyMarkup: new ReplyKeyboardRemove());
        }
    }
}
