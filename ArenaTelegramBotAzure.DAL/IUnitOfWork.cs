using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArenaTelegramBotAzure.DAL
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();

    }
}
