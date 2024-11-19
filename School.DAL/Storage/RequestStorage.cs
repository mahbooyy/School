using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School.DAL.Interface;
using School.Domain.ModelsDb;

namespace School.DAL.Storage
{
    public class RequestStorage : IBaseStorage<RequestDb>
    {
        public readonly ApplicationDbContext _db;

        public RequestStorage(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Add(RequestDb item)
        {
            await _db.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(RequestDb item)
        {
            _db.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<RequestDb> Get(Guid id)
        {
            return await _db.RequestDb.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<RequestDb> GetAll()
        {
            return _db.RequestDb;
        }

        public async Task<RequestDb> Update(RequestDb item)
        {
            _db.RequestDb.Update(item);
            await _db.SaveChangesAsync();

            return item;

        }


    }
}
