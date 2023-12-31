using BakeAtlas.Application.Interface.Repositories;
using BakeAtlas.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeAtlas.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BakeAtlasDbContext _dbContext;

        public GenericRepository(BakeAtlasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async void AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public void DeleteAllAsync(List<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        public void DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public List<T> GetAllAsync()
        {
           return _dbContext.Set<T>().ToList();
        }

        public T GetByIdAsync(string id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void SaveChangesAsync()
        {
            _dbContext.SaveChangesAsync();
        }

        public void UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
    }

}
