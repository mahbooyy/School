﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DAL.Interface
{
    public interface IBaseStorage<T>
    {
        Task Add(T item);

        Task Delete(T item);

        Task<T> Get(Guid id);

        Task<T> Update(T item);

        IQueryable<T> GetAll();
    }
}
