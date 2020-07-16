using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected readonly DataContext _context;
        protected readonly DbSet<T> _dbset;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }
        public T Create(T entity)
        {
            _dbset.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(T entity)
        {
            try
            {
                _dbset.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }


        }

        public bool Delete(short id)
        {
            var entity = _dbset.Find(id);
            return Delete(entity);

        }

        public IQueryable<T> GetQuery()
        {
            return _dbset;
        }

        public T Upadate(T entity)
        {
            try
            {
                _dbset.Update(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }


    }
}
