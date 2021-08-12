using ArenaTelegramBotAzure.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ArenaTelegramBotAzure.Domain.Models
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
