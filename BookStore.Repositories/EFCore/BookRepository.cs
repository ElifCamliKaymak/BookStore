using BookStore.Entities.Models;
using BookStore.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repositories.EFCore
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneBook(Book book) => Create(book);

        public void DeleteOneBook(Book book) => Delete(book);

        public Book GetOneBookById(int id, bool trackChanges) =>
            FindByCondition(b => b.Id.Equals(id), trackChanges)
            .SingleOrDefault();

        public IQueryable<Book> GetAllBooks(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(x=>x.Id);

        public void UpdateOneBook(Book book) => Update(book);
    }
}
