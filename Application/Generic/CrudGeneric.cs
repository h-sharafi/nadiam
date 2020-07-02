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
    public class CrudGeneric<T> : ICrudGeneric<T> where T : class
    {

        protected readonly DataContext _context;
        protected readonly DbSet<T> _dbset;

        public CrudGeneric(DataContext context)
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

        public IQueryable<T> GetList()
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

        public async Task<string> SaveFile(IFormFile file)
        {
            if (file == null) return null;
            var folderName = Path.Combine("wwwroot", "FileUplaod");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            var FileGuidName = Guid.NewGuid().ToString();
            var FileName = FileGuidName + Path.GetExtension(file.FileName);
            string fullPath = Path.Combine(pathToSave, FileName);

            await using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return FileName;

        }
    }
}
