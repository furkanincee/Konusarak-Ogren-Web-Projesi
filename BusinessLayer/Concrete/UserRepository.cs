using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserRepository : GenericRepository<User>
    {
        public int GetBrandId(int userId)
        {          
            Brand brand = _db.Brands.First(x => x.AdminList.Contains(x.AdminList.First(y=>y.Id == userId)) == true);
            return brand.BrandId;
        }
    }
}
