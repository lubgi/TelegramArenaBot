using ArenaTelegramBotAzure.DAL.Models;
using ArenaTelegramBotAzure.Handlers;
using Telegram.Bot.Types.ReplyMarkups;

namespace ArenaTelegramBotAzure.Menus
{
    public class AuthorizationMenu : IMenu
    {

        public static string Text => "Please auth via Wax Wallet";

        //Auth URL
        public static InlineKeyboardMarkup InlineKeyboard =>
            new(InlineKeyboardButton.WithUrl("Auth", "https://www.google.com/"));

        public static string State => "AuthorizationMenu";

        public AuthorizationMenu(User user)
        {
            //User.AddNewUser(user);
            new Check(user);
        }
        


        /// <summary>
        /// Not needed anymore
        /// </summary>
        public class Check : IMenu
        {
            public static string Text => "Press check after auth is done";

            public static InlineKeyboardMarkup InlineKeyboard => new(
                InlineKeyboardButton.WithCallbackData(CallbackQueryHandler.CallbackQueryState.CheckAuthorization));

            public Check(User user)
            {
                Bot.SendTextMessageAsync(user.Chat.Id,
                    Text,
                    replyMarkup: InlineKeyboard);
            }
        }
    }
}