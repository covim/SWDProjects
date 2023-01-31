using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.PlayCollector.Repository
{
    public class GenericRepository<TEnity, TModel> : IGenericRepository<TEnity>
        where TEnity : class, new()
        where TModel : DbContext, new()
    {
        //Member

        private DbContext _dbContext;
        private DbSet<TEnity> _dbSet;


        //Properties
        public DbSet<TEnity> DbSet
        {
            get { return _dbSet; }
        }

        //Coonstrucor

        public GenericRepository()
        {
            Init(new TModel());
        }

        public GenericRepository(DbContext context)
        {
            Init(context);
        }

        public void Init(DbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<TEnity>();
        }


        public void Add(TEnity t)
        {
            _dbSet.Add(t);
            _dbContext.SaveChanges();
        }

        public async Task AddAsync(TEnity t)
        {
            await _dbSet.AddAsync(t);
            await _dbContext.SaveChangesAsync();

        }

        public void Delete(object key)
        {
            TEnity existing = _dbSet.Find(key);
            if (existing != null)
            {
                _dbSet.Remove(existing);
                _dbContext.SaveChanges();
            }
        }

        public async Task DeleteAsync(object key)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEnity> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<IQueryable<TEnity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }


        public TEnity GetById(object key)
        {
            return _dbSet.Find(key);
        }

        public Task<TEnity> GetByIdAsync(object key)
        {
            throw new NotImplementedException();
        }

        public void Update(TEnity t, object key)
        {
            TEnity existing = _dbSet.Find(key);
            if (existing != null)
            {
                _dbContext.Entry(existing).CurrentValues.SetValues(t);
                _dbContext.SaveChanges();
                _dbContext.Entry(existing).Reload();
            }

        }

        public async Task UpdateAsync(TEnity t, object key)
        {
            throw new NotImplementedException();
        }


    }
}
