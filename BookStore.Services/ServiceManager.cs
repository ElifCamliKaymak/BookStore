using AutoMapper;
using BookStore.Repositories.Contracts;
using BookStore.Services.Contracts;

namespace BookStore.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookService> _bookService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerService logger, IMapper mapper)
        {
            _bookService = new Lazy<IBookService>(() => new BookManager(repositoryManager, logger, mapper));
        }
        public IBookService BookService => _bookService.Value;
    }
}
