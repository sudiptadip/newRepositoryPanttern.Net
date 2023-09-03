using Repository_Practice.DataAccess.Data;
using Repository_Practice.DataAccess.Repository.IRepository;
using Repository_Practice.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Practice.DataAccess.Repository
{
    public class ProductReository : Repository<Product>, IProductRepository
    {
        private  ApplicationDbContext _db;
        public ProductReository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}
