using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ArenaTelegramBotAzure.Services
{
    public class MessageSenderService
    {
        private ITelegramBotClient _bot;
        public MessageSenderService(ITelegramBotClient botClient)
        {
            _bot = botClient;
        }

    }
}
