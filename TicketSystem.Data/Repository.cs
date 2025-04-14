using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Entitites;

namespace TicketSystem.Data
{
    public class Repository<T> where T : class, IIdEntity
    {
        TicketSystemContext ctx;

        public Repository(TicketSystemContext ctx)
        {
            this.ctx = ctx;
        }

        public IQueryable<T> GetAll()
        {
            return ctx.Set<T>();
        }

        public void Create(T entity)
        {
            ctx.Set<T>().Add(entity);
            ctx.SaveChanges();

        }
     
    }
}
