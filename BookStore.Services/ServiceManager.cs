﻿using AutoMapper;
using BookStore.Entities.DataTransferObjects;
using BookStore.Repositories.Contracts;
using BookStore.Services.Contracts;

namespace BookStore.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookService> _bookService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerService logger, IMapper mapper, IDataShaper<BookDto> shaper)
        {
            _bookService = new Lazy<IBookService>(() => new BookManager(repositoryManager, logger, mapper, shaper));
        }
        public IBookService BookService => _bookService.Value;
    }
}
