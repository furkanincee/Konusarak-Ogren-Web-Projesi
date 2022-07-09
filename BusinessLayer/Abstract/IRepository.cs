using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        void Insert(T model);
        void Update(T model);
        void Delete(T model);
        T GetById(int id);
    }
}
