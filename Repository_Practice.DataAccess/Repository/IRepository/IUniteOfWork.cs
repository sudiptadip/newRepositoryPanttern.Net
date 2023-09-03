using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Practice.DataAccess.Repository.IRepository
{
    public interface IUniteOfWork
    {
        ICategoryRepository category { get; }
        IProductRepository product { get; }
        void Save();
    }
}
