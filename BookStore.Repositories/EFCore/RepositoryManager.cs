using BookStore.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IBookRepository> _bookRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;

            //eager loading herşeyin bir anda yüklenmesi
            //lazy loading ise tembel yükleme. o refenransa ne zaman ihtiyaç olursa o zaman çağırılır böylece performans artışı sağlar.
            _bookRepository=new Lazy<IBookRepository>(()=>new BookRepository(_context));
        }

        public IBookRepository Book => _bookRepository.Value;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
