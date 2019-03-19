using System;
using System.Collections.Generic;
using System.Text;
using Kuzey.BLL.Repository.Abstracts;
using Kuzey.DAL;
using Kuzey.MODELS.Entities;

namespace Kuzey.BLL.Repository
{
    public class ProductRepo : RepoBase<Product, string>
    {
        private readonly MyContext _dbContext;
        public ProductRepo(MyContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
