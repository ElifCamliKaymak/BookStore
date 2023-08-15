using BookStore.Entities.DataTransferObjects;
using BookStore.Entities.Models;
using BookStore.Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Contracts
{
    public interface IBookService
    {
        Task<(IEnumerable<BookDto> bookDto, MetaData metaData)> GetAllBooksAsync(BookParameters bookParameters, bool trackChanges);
        Task<BookDto> GetOneBookByIdAsync(int id, bool trackChanges);
        Task<BookDto> CreateOneBookAsync(BookDtoForInsertion book);
        Task UpdateOneBookAsync(int id, BookDtoForUpdate bookDto, bool trackChanges);
        Task DeleteOneBookAsync(int id, bool trackChanges);
        Task<(BookDtoForUpdate bookDtoForUpdate, Book book)> GetOneBookForPatchAsync(int id, bool trackChanges);
        Task SaveChangesForPatchAsync(BookDtoForUpdate bookDtoForUpdate, Book book);
    }
}
