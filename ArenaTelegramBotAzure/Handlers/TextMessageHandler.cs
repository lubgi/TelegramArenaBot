using System.Linq;
using System.Threading.Tasks;
using ArenaTelegramBotAzure.Commands;
using ArenaTelegramBotAzure.DAL;
using ArenaTelegramBotAzure.DAL.Models;
using ArenaTelegramBotAzure.Domain.Menus;
using Telegram.Bot.Types;
using User = ArenaTelegramBotAzure.DAL.Models.User;

namespace ArenaTelegramBotAzure.Handlers
{
    public class TextMessageHandler
    {
        private static IRepository<User> _userRepository;
        public static async Task HandleMessageReceived(Message message, IRepository<User> userRepository)
        {
            _userRepository = userRepository;
            User user = userRepository.Get(message.From.Id).Result;
            if (user == null)
                user = new User(message);

            userRepository.Add(user);
            
            
            var action = (message.Text.Split(' ').First()) switch
            {
                "/start" => user.IsAuthorized ? user.MoveTo(new AuthMenu(user)) : Task.CompletedTask,
                "/help" => Help.Execute(user),
                "zalupa" => zalupaAuth(user),
                _ => Task.CompletedTask
            };

            await action;

        }

        public static Task zalupaAuth(User user)
        {
            user.IsAuthorized = true;
            _userRepository.Update(user);
            //db.SaveChangesAsync();
            return Task.CompletedTask;
        }
    }
}
