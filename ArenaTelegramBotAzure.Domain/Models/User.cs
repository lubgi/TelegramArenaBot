using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using ArenaTelegramBotAzure;
using ArenaTelegramBotAzure.DAL;
using ArenaTelegramBotAzure;
using ArenaTelegramBotAzure.Domain.Menus;
using ArenaTelegramBotAzure.Domain.Models;

namespace ArenaTelegramBotAzure.DAL.Models
{
    //#nullable enable
    public class User : IEquatable<User>
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public long ChatId  => Chat.Id; 
        public decimal Points { get; set; } = 0;
        public bool IsAuthorized { get; set; } = false;
        public string State { get; set; } = States.Auth;
        public int Nonce { get; set; } = 0;
        public Chat Chat { get; set; }
        public ICollection<Fight> Fights { get; set; } = new List<Fight>();
        public static class States
        {
            public const string Auth = "AuthMenu";
            public const string MainMenu = "MainMenu";
            public const string Fight = "Fight";

        }

        //public User(int id, string username, decimal points = 0, bool isAuthorized = false)
        //{
        //    Id = id;
        //    Username = username;
        //    Points = points;
        //    IsAuthorized = isAuthorized;
        //}
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
            await menu.Execute(Chat.Id);
        }
        
        //public void Update()
    }
}
