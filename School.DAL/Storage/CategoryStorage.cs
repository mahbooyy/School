using Microsoft.EntityFrameworkCore;
using School.DAL.Interface;
using School.Domain.ModelsDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DAL.Storage
{
    public class CategoryStorage : IBaseStorage<CategoryDb>
    {
        public readonly ApplicationDbContext _db;

        public CategoryStorage(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Add(CategoryDb item)
        {
            await _db.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(CategoryDb item)
        {
            _db.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<CategoryDb> Get(Guid id)
        {
            return await _db.CategoryDb.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<CategoryDb> GetAll()
        {
            return _db.CategoryDb;
        }

        public async Task<CategoryDb> Update(CategoryDb item)
        {
            _db.CategoryDb.Update(item);
            await _db.SaveChangesAsync();

            return item;

        }


    }
}
