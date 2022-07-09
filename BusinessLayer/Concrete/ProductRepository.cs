using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductRepository : GenericRepository<Product>
    {
        public List<Comment> GetComments(int productId)
        {
            return _db.Comments.Where(c => c.ProductId == productId).ToList();
        }

        public List<Product> GetByBrand(int brandId)
        {
            
            return _db.Products.Where(p => p.BrandId == brandId).ToList();
        }
    }
}
