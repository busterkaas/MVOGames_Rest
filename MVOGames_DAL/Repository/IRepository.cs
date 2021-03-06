﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVOGames_DAL.Repository
{
    public interface IRepository<T>
    {
        List<T> ReadAll();

        void Add(T t);

        void Delete(int? id);

        T Find(int? id);

        void Update(T t);
    }
}
