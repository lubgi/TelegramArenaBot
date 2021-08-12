using ArenaTelegramBotAzure.DAL.Models;
using Telegram.Bot.Types.ReplyMarkups;
using ArenaTelegramBotAzure;
namespace ArenaTelegramBotAzure.Domain.Menus
{
    public class AuthMenu : AbstractMenu
    {
        
        public override string Text => "Please auth via Wax Wallet";

        //Auth URL
        public override InlineKeyboardMarkup InlineKeyboard =>
            new(InlineKeyboardButton.WithUrl("Auth", "https://www.google.com/"));

        public override string State => "AuthMenu";

        public AuthMenu(User user)
        {
            
            
            
        }
        
    }
}