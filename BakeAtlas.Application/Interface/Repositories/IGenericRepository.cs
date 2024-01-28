using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeAtlas.Application.Interface.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
        void DeleteAllAsync(List<T> entities);
        void DeleteAsync(T entity);
        List<T> GetAllAsync();
        T GetByIdAsync(string id);
        Task SaveChangesAsync();
        void UpdateAsync(T entity);

    }
}
