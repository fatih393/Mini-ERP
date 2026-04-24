using Mini_ERP.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Repostories
{   public interface IReadRepostory<T> : IRepostory<T> where T : BaseEntitiy
    {
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method , bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func <T, bool>> method, bool tracking = true);
        Task<T> GetByIdAsync(int id , bool tracking = true);
    }
}
