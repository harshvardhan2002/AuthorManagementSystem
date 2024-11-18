using AuthorWebApiProject.DTOs;
using AuthorWebApiProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthorWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var bookDTO = _bookService.GetBooks();
            return Ok(bookDTO);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var bookDTO = _bookService.GetById(id);
            return Ok(bookDTO);
        }

        [HttpPost]
        public IActionResult Add(BookDTO bookDTO)
        {
            var id = _bookService.AddBook(bookDTO);
            return Ok(id);
        }

        [HttpPut]
        public IActionResult Update(BookDTO updatedBookDTO)
        {
            var bookDTO = _bookService.UpdateBook(updatedBookDTO);
            return Ok(bookDTO);
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_bookService.DeleteBook(id))
            {
                return Ok(id);
            }
            return NotFound();
        }

        [HttpGet("book/{authorId}")]
        public IActionResult GetByAuthorID(int authorId)
        {
            var bookDTO = _bookService.GetBookByAuthorID(authorId);
            return Ok(bookDTO);
        }
    }
}
