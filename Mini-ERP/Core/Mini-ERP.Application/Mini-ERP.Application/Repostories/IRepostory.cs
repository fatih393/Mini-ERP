using Mini_ERP.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Repostories
{
    public interface IRepostory<T> where T : BaseEntitiy
    {
        DbSet<T> Table { get; }

    }
}
