using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IGenericRepository<T>
    {
        T Create(T entity);
        T Upadate(T entity);
        bool Delete(T entity);
        bool Delete(short id);
        IQueryable<T> GetQuery();


    }
}
