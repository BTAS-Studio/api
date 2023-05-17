using BTAS.API.Dto;
using BTAS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace BTAS.API.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsyncWithChildren();
        //Task<IEnumerable<T>> GetAllAsyncWithChildren(searchFilter filter = null);
        //Task<IEnumerable<T>> GetAllAsyncWithChildren(searchFilter<T> filter = null);
        Task<T> GetByIdAsync(int id);
        Task<T> CreateUpdateAsync(T entity);
        //Task<T> DeleteAsync(int id);
        //Task<IQueryable<T>> FindAll();
    }
}
