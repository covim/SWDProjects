using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Swd.PlayCollector.Repository
{
    public interface IGenericRepository<TEnity> where TEnity : class, new()   //TEntity muss eine Klasse sein und einen parameterlosen Konstruktor enthalten
    {
        DbSet<TEnity> DbSet { get; }

        
        //CRUD Methoden
        
        //Create
        void Add(TEnity t);
        Task AddAsync(TEnity t);

        //Read
        IQueryable<TEnity> GetAll();
        Task<IQueryable<TEnity>> GetAllAsync();

        //ReadById
        TEnity GetById(Object key);
        Task<TEnity> GetByIdAsync(Object key);

        //Update
        void Update(TEnity t, object key);
        Task UpdateAsync(TEnity t, object key);

        //Delete
        void Delete(object key);
        Task DeleteAsync(object key);









    }
}