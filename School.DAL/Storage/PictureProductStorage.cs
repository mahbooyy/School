using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Domain.ModelsDb;
using School.DAL.Interface;
using School.DAL;

namespace School.DAL.Storage
{
    public class PictureProductStorage : IBaseStorage<PictureProductDb>
    {
        public readonly ApplicationDbContext _db;

        public PictureProductStorage(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Add(PictureProductDb item)
        {
            await _db.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(PictureProductDb item)
        {
            _db.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<PictureProductDb> Get(Guid id)
        {
            return await _db.PictureProductDb.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<PictureProductDb> GetAll()
        {
            return _db.PictureProductDb;
        }

        public async Task<PictureProductDb> Update(PictureProductDb item)
        {
            _db.PictureProductDb.Update(item);
            await _db.SaveChangesAsync();

            return item;

        }



    }
}
