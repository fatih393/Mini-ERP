using Microsoft.EntityFrameworkCore;
using Mini_ERP.Application.Repostories;
using Mini_ERP.Domain.Entities.Common;
using Mini_ERP.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Persistence.Repostories
{
    public class ReadRepository<T> : IReadRepostory<T> where T : BaseEntitiy
    {
        readonly Mini_ErpAPIContext _context;

        public ReadRepository(Mini_ErpAPIContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public  IQueryable<T> GetAll(bool tracking = true)
        {
           var query = Table.AsQueryable();
            if(!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetByIdAsync(int id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == id);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
           var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if(!tracking)
                query = query.AsNoTracking();
            return query;
        }
    }
}
