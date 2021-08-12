using System.Threading.Tasks;
using ArenaTelegramBotAzure.DAL.Models;
using ArenaTelegramBotAzure.Domain.Menus;
using ArenaTelegramBotAzure.Domain.Models;
using ArenaTelegramBotAzure.Services;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using User = ArenaTelegramBotAzure.DAL.Models.User;

namespace ArenaTelegramBotAzure.Handlers
{
    public class CallbackQueryHandler
    {
        private static ITelegramBotClient Bot = HandleUpdateService.Bot;
        private static BotContext db;

        public static class CallbackQueryState
        {
            public const string CheckAuthorization = "CheckAuth";

            public static class FightChance
            {
                public const string FightWinChance30 = "FightWinChance30";
                public const string FightWinChance50 = "FightWinChance50";
                public const string FightWinChance70 = "FightWinChance70";
            }

            public const string Me = "Me";
            public const string Arena = "Arena";

        }

        public static async Task HandleCallbackQuery(CallbackQuery CallbackQuery, [FromServices] BotContext botContext)
        {
            db = botContext;
            var action = CallbackQuery.Data switch
            {
                CallbackQueryState.CheckAuthorization => AuthorizationHandler(CallbackQuery),
                CallbackQueryState.Arena => MainMenuHandler(CallbackQuery),
                CallbackQueryState.FightChance.FightWinChance30 => FightHandler(CallbackQuery),
                CallbackQueryState.FightChance.FightWinChance50 => FightHandler(CallbackQuery),
                CallbackQueryState.FightChance.FightWinChance70 => FightHandler(CallbackQuery),
                _ => Task.CompletedTask 

            };

            await action;
        }
        private static async Task MainMenuHandler(CallbackQuery CallbackQuery)
        {
            User user = db.Users.FindAsync(CallbackQuery.From.Id).Result;
            //условия для захода в арену
            //await user.MoveTo(new FightMenu());

        }
        private static async Task FightHandler(CallbackQuery CallbackQuery)
        {
            User user = db.Users.FindAsync(CallbackQuery.From.Id).Result;
            //await FightMenu.StartFight(user, Int32.Parse(CallbackQuery.Data.Substring(14)));


        }
        private static async Task AuthorizationHandler(CallbackQuery CallbackQuery)
        {
            User user = db.Users.FindAsync(CallbackQuery.From.Id).Result;
            if (!user.IsAuthorized)
            {
                await Answer(CallbackQuery: CallbackQuery,
                                alert: "You are not authorized yet",
                                showAlert: false);
            }
            else if (!user.State.Equals(User.States.Auth))
            {
                await Answer(CallbackQuery: CallbackQuery,
                              alert: "You are already authorized",
                              showAlert: false);
            }
            else
            {

                await Bot.SendTextMessageAsync(chatId: CallbackQuery.Message.Chat.Id,
                                               text: "Welcome!");//+user info
                await user.MoveTo(new MainMenu());

                //await new MainMenu(User.GetUser(CallbackQuery));
            }
        }
        public static async Task Answer(CallbackQuery CallbackQuery, string alert, bool showAlert = false)
        {
            await Bot.AnswerCallbackQueryAsync(callbackQueryId: CallbackQuery.Id,
                                          text: alert,
                                          showAlert: showAlert);

        }
    }

}

