using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArenaTelegramBotAzure.Services;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using User = ArenaTelegramBotAzure.DAL.Models.User;

namespace ArenaTelegramBotAzure.Commands
{
    interface ICommand
    {
        protected static readonly ITelegramBotClient Bot = HandleUpdateService.Bot;
        public static string Name { get; set; }
        public static string Text { get; set; }
        public static async Task<Message> Execute(User user)
        {
            return await Bot.SendTextMessageAsync(chatId: user.Chat.Id,
                text: Text,
                replyMarkup: new ReplyKeyboardRemove());
        }
    }
}
