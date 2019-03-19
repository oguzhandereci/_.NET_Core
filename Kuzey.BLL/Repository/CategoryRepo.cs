using System;
using System.Collections.Generic;
using System.Text;
using Kuzey.BLL.Repository.Abstracts;
using Kuzey.DAL;
using Kuzey.MODELS.Entities;

namespace Kuzey.BLL.Repository
{
    public class CategoryRepo : RepoBase<Category, int>
    {
        private readonly MyContext _dbContext;
        public CategoryRepo(MyContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
