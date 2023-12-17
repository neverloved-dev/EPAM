﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ORM_Classes.Services
{
    public interface IGenericService<T> where T : class
    {
        public List<T> GetAll();
        public T GetSingle(int value);
        public T Update(T entity);
        public void Delete(int id);
    }
}