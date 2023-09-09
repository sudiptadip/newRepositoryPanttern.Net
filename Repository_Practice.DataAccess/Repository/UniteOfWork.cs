using Repository_Practice.DataAccess.Data;
using Repository_Practice.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Practice.DataAccess.Repository
{
    public class UniteOfWork : IUniteOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository category { get; private set; }
        public ICompanyRepository company { get; private set; }

        public IProductRepository product { get; private set; }

        public UniteOfWork(ApplicationDbContext db)
        {
            _db = db;
            category = new CategoryRepository(_db);
            product = new ProductReository(_db);
            company = new CompanyRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}