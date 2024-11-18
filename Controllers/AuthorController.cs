using AuthorWebApiProject.DTOs;
using AuthorWebApiProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthorWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var authorDTO = _authorService.GetAuthors();
            return Ok(authorDTO);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var author = _authorService.GetById(id);
            return Ok(author);
        }

        [HttpPost]
        public IActionResult Add(AuthorDTO authorDTO)
        {
            var id = _authorService.AddAuthor(authorDTO);
            return Ok(id);
        }

        [HttpPut]
        public IActionResult Update(AuthorDTO updatedAuthorDTO)
        {
            var authorDTO = _authorService.UpdateAuthor(updatedAuthorDTO);
            return Ok(authorDTO);
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_authorService.DeleteAuthor(id))
            {
                return Ok(id);
            }
            return NotFound();
        }

        [HttpGet("author/{name}")]
        public IActionResult GetByName(string name)
        {
            var authorDTO = _authorService.GetByName(name);
            return Ok(authorDTO);
        }

        [HttpGet("authorBook/{id}")]
        public IActionResult GetBooks(int id)
        {
            var authorDto = _authorService.GetAuthorByBookID(id);
            return Ok(authorDto);
        }


    }
}
