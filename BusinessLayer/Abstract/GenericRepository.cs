using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        public ETradeDbContext _db = new ETradeDbContext();   
        public DbSet<T> table => _db.Set<T>();
        public void Delete(T model)
        {
            table.Remove(model);
            _db.SaveChanges();
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }

        public void Insert(T model)
        {
            table.Add(model);
            _db.SaveChanges();
        }

        public void Update(T model)
        {
            table.Update(model);
            _db.SaveChanges();
        }
    }
}
