using System.Threading.Tasks;
using Telegram.Bot.Types;
using User = ArenaTelegramBotAzure.DAL.Models.User;

namespace ArenaTelegramBotAzure.Commands
{
    public class Start:ICommand
    {
        public static string Name
        {
            get => "/start";
        }
        public static string Text
        {
            get => "Welcome!"; }
        public static async Task<Message> Execute(User user)
        {
            return await ICommand.Execute(user);
        }
    }

}
