using BookStore.Entities.DataTransferObjects;
using BookStore.Entities.Exceptions;
using BookStore.Entities.Models;
using BookStore.Services.Contracts;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Presentation.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BookController(IServiceManager manager)
        {
            _manager = manager;
        }




        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _manager.BookService.GetAllBooks(false);
            return Ok(books);
        }



        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            var book = _manager.BookService.GetOneBookById(id, false);

            return Ok(book);
        }



        [HttpPost]
        public IActionResult CreateOneBook([FromBody] BookDtoForInsertion bookDto)
        {
            if (bookDto is null) 
                return BadRequest(); // StatusCode 400

            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);   // StatusCode 422

            var book = _manager.BookService.CreateOneBook(bookDto);

            return StatusCode(201, book);
        }




        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] BookDtoForUpdate bookDto)
        {
            if (bookDto is null) 
                return BadRequest();

            if(!ModelState.IsValid) 
                return UnprocessableEntity(ModelState);  //StatusCode 422

            _manager.BookService.UpdateOneBook(id, bookDto, false);
            return NoContent();  //StatusCode 204
        }




        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
            _manager.BookService.DeleteOneBook(id, false);
            return NoContent();
        }




        [HttpPatch("(id:int)")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<BookDtoForUpdate> bookPatch)
        {
            if(bookPatch is null) 
                return BadRequest();

            var result = _manager.BookService.GetOneBookForPatch(id, false);

            bookPatch.ApplyTo(result.bookDtoForUpdate, ModelState);

            TryValidateModel(result.bookDtoForUpdate);

            if (!ModelState.IsValid) 
                return UnprocessableEntity(ModelState);

            _manager.BookService.SaveChangesForPatch(result.bookDtoForUpdate, result.book);
       
            return NoContent();
        }
    }
}
