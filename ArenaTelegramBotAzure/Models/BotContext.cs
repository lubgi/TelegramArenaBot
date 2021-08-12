using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TelegramBot;

namespace ArenaTelegramBotAzure.Models
{
    public class BotContext:DbContext
    {
        public DbSet<User> Users { get; set; } 
        public DbSet<Fight> Fights { get; set; }

        public BotContext(DbContextOptions options) :
            base(options)
        {
            Database.EnsureCreatedAsync();
        }
    }
}
