using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.UnitOfWork;
using UdemyNLayerProject.Data.Repositories;

namespace UdemyNLayerProject.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;

        public UnitOfWork(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_appDbContext);

        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(_appDbContext);

        public void Commit()
        {
            this._appDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await this._appDbContext.SaveChangesAsync();
        }
    }
}
