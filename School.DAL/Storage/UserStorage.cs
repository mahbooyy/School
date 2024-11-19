using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using School.Domain.ModelsDb;

namespace School.DAL.Storage
{
    public class UserStorage : IBaseStorage<UserDb>
    {
        public readonly ApplicationDbContext _db;

        public UserStorage(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Add(UserDb item)
        {
            await _db.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(UserDb item)
        {
            _db.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<UserDb> Get(Guid id)
        {
            return await _db.userDb.FirstOrDefaultAsync(x => x.Id == id );
        }

        public IQueryable<UserDb> GetAll()
        {
            return _db.userDb;
        }

        public async Task<UserDb> Update(UserDb item)
        {
            _db.userDb.Update(item);
            await _db.SaveChangesAsync();

            return item;

        }

    }
}
