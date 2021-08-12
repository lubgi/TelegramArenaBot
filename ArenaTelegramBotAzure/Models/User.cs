using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Examples.WebHook.Menus;
using Telegram.Bot.Examples.WebHook.Services;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    //#nullable enable
    public class User : IEquatable<User>
    {
        //private static readonly TelegramBotClient Bot = Program.Bot;
        private static ITelegramBotClient Bot = HandleUpdateService.Bot;


        public long Id { get; set; }
        public string Username { get; set; }
        public long ChatId  => Chat.Id; 
        public decimal Points { get; set; } = 0;
        public bool IsAuthorized { get; set; } = false;
        public string State { get; set; } = States.Auth;
        public int Nonce { get; set; } = 0;
        public Chat Chat { get; set; }

        public static class States
        {
            public const string Auth = "AuthorizationMenu";
            public const string MainMenu = "MainMenu";
            public const string Fight = "Fight";

        }

        public User(int id, string username, decimal points = 0, bool isAuthorized = false)
        {
            Id = id;
            Username = username;
            Points = points;
            IsAuthorized = isAuthorized;
        }
        public User(Message message)
        {
            Id = message.From.Id;
            Chat = message.Chat;
            Username = message.From.Username;

        }
        public User()
        {
        }
        

        //public static User GetUser(Message message)
        //{
        //    users.TryGetValue(message.From.Id, out User user);
        //    return user;
        //}
        //public static User GetUser(CallbackQuery callbackQuery)
        //{
        //    if (!users.TryGetValue(callbackQuery.From.Id, out User user))
        //        user = null;

        //    return user;
        //}

        //public static void AddNewUser(Message message)
        //{
        //    User userToAdd = new User()
        //    {
        //        Id = message.From.Id,
        //        Username = message.From.Username,
        //        ChatID = message.Chat.Id,
        //        IsAuthorized = false,
        //        Points = 0,
        //        State = UserState.Auth
        //    };
        //    users.TryAdd(userToAdd.Id, userToAdd);
        //}

        //public static void AddNewUser(User user)
        //{
        //    users.TryAdd(user.Id, user);
        //}

        
        public bool Equals(User other)
        {
            return this.Id == other.Id;
        }

        public async Task MoveTo(AbstractMenu menu)
        {
            State = menu.State;
            menu.Execute(Chat.Id);
            
        }
        
        //public void Update()
    }
}
