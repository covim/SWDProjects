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
            TEnity existing = await _dbSet.FindAsync(key);
            if (existing != null)
            {
                _dbSet.Remove(existing);
                await _dbContext.SaveChangesAsync();
            }
        }
        
        public IQueryable<TEnity> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<IQueryable<TEnity>> GetAllAsync()
        {
            return _dbSet.AsQueryable();
        }


        public TEnity GetById(object key)
        {
            return _dbSet.Find(key);
        }

        public async Task<TEnity> GetByIdAsync(object key)
        {
            return await _dbSet.FindAsync(key);
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
            TEnity existing = await _dbSet.FindAsync(key);
            if (existing != null)
            {
                _dbContext.Entry(existing).CurrentValues.SetValues(t);
                await _dbContext.SaveChangesAsync();
                await _dbContext.Entry(existing).ReloadAsync();
            }
        }


    }
}
