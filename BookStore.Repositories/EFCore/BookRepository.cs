using BookStore.Entities.Models;
using BookStore.Entities.RequestFeatures;
using BookStore.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories.EFCore
{
    public sealed class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneBook(Book book) => Create(book);

        public void DeleteOneBook(Book book) => Delete(book);

        public async Task<Book> GetOneBookByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(b => b.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<PagedList<Book>> GetAllBooksAsync(BookParameters bookParameters, bool trackChanges)
        {
            var books = await FindAll(trackChanges)
                .FilterBooks(bookParameters.MinPrice, bookParameters.MaxPrice)
                .OrderBy(x => x.Id)
                .ToListAsync();

            return PagedList<Book>.ToPagedList(books, bookParameters.PageNumber, bookParameters.PageSize);
        }

        public void UpdateOneBook(Book book) => Update(book);
    }
}
