using BookStore.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repositories.EFCore
{
    //abstract sayesinde base repository sınıfı new lenemeyecek sadece kalıtım alan sınıflar bu metotları kullanabilecek.
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        //base repositoryden kalıtım alan sınıfların bu context e erişebilmesi için private değil protected kullanıldı.
        protected readonly RepositoryContext _context;
        public BaseRepository(RepositoryContext context)
        {
            _context = context;
        }

        public async Task Create(T entity) => await _context.Set<T>().AddAsync(entity);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges)
            => 
            !trackChanges ? 
            _context.Set<T>().AsNoTracking() : 
            _context.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
            => 
            !trackChanges ? 
            _context.Set<T>().Where(expression).AsNoTracking() : 
            _context.Set<T>().Where(expression);

        public void Update(T entity) => _context.Set<T>().Update(entity);
    }
}
