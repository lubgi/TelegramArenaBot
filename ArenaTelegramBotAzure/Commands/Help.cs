using System.Threading.Tasks;
using Telegram.Bot.Types;
using User = ArenaTelegramBotAzure.DAL.Models.User;

namespace ArenaTelegramBotAzure.Commands
{
    public class Help:ICommand
    {
        public static string Name
        {
            get => "/help"; 
        }

        public static string Text
        {
            get => "Usage:\n" + "";
        }

        public static async Task<Message> Execute(User user)
        {
            return await ICommand.Execute(user);
        }


    }
}
