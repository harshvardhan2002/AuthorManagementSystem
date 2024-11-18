using AuthorWebApiProject.DTOs;
using AuthorWebApiProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthorWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorDetailesController : ControllerBase
    {
        private readonly IAuthorDetailsService _authorDetailsService;

        public AuthorDetailesController(IAuthorDetailsService authorDetailsService)
        {
            _authorDetailsService = authorDetailsService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var authorDetailsDTO = _authorDetailsService.GetAuthorsDetails();
            return Ok(authorDetailsDTO);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var authorDetailsDTO = _authorDetailsService.GetById(id);
            return Ok(authorDetailsDTO);
        }

        [HttpPost]
        public IActionResult Add(AuthorDetailsDTO authorDetailsDTO)
        {
            var id = _authorDetailsService.AddAuthorDetails(authorDetailsDTO);
            return Ok(id);
        }

        [HttpPut]
        public IActionResult Update(AuthorDetailsDTO authorDetailsDTO)
        {
            var authorDetails = _authorDetailsService.UpdateAuthorDetails(authorDetailsDTO);
            return Ok(authorDetails);
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_authorDetailsService.DeleteAuthorDetails(id))
                return Ok(id);
            return NotFound();
        }

        [HttpGet("author/{authorId}")]
        public IActionResult GetByAuthorID(int authorId)
        {
            var detailDTO = _authorDetailsService.GetByAuthorId(authorId);
            return Ok(detailDTO);
        }
    }
}
