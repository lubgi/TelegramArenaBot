using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ArenaTelegramBotAzure.DAL.Models;
using ArenaTelegramBotAzure.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ArenaTelegramBotAzure.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BotContext _db;

        public UnitOfWork(BotContext context)
        {
            _db = context;
        }
        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
