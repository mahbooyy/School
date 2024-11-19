using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Domain.ModelsDb;
using School.Domain;
using School.DAL;
using School.DAL.Interface;

namespace School.DAL.Storage
{
    public class ProductsStorage : IBaseStorage<ProductsDb>
    {
        public readonly ApplicationDbContext _db;

        public ProductsStorage(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Add(ProductsDb item)
        {
            await _db.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(ProductsDb item)
        {
            _db.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<ProductsDb> Get(Guid id)
        {
            return await _db.ProductDb.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<ProductsDb> GetAll()
        {
            return _db.ProductDb;
        }

        public async Task<ProductsDb> Update(ProductsDb item)
        {
            _db.ProductDb.Update(item);
            await _db.SaveChangesAsync();

            return item;

        }
    }
}
