using Telegram.Bot.Types.ReplyMarkups;

namespace ArenaTelegramBotAzure.Menus
{
    public class MainMenu : AbstractMenu
    {
        public static string Text =>
            "1. Me\n" +
            "2. Arena\n" +
            "";

        public static InlineKeyboardMarkup InlineKeyboard =>
            new(
                new[]
                {
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Me")
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Arena")
                    }
                });

        public static string State => "MainMenu";

        //public MainMenu(User user)
        //{
        //    user.State = User.UserState.MainMenu;
        //    //DB.Update(user);
        //}
    }
}
