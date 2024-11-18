using AuthorWebApiProject.DTOs;
using AuthorWebApiProject.Exceptions;
using AuthorWebApiProject.Models;
using AuthorWebApiProject.Repsoitories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorWebApiProject.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _authorRepository;
        private readonly IMapper _mapper;
        public AuthorService(IRepository<Author> authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public int AddAuthor(AuthorDTO authorDTO)
        {
            var author = _mapper.Map<Author>(authorDTO);
            _authorRepository.Add(author);
            return author.Id;
        }

        public bool DeleteAuthor(int id)
        {
            var author = _authorRepository.Get(id);
            if (author != null)
            {
                _authorRepository.Delete(author);
                return true;
            }
            return false;
        }

        public List<AuthorDTO> GetAuthors()
        {
            var authors = _authorRepository.GetAll().Include(a => a.Books).Include(a => a.AuthorDetail).ToList();
            List<AuthorDTO> authorDTOs = _mapper.Map<List<AuthorDTO>>(authors);
            return authorDTOs;

        }

        public AuthorDTO GetById(int id)
        {
            var author = _authorRepository.GetAll().Include(a => a.Books).FirstOrDefault(a => a.Id == id);
            if (author == null)
            {
                throw new AuthorNotFoundException("Author Id is not found.");
            }
            AuthorDTO authorDTO = _mapper.Map<AuthorDTO>(author);
            return authorDTO;
        }

        public bool UpdateAuthor(AuthorDTO authorDTO)
        {
            var author = _mapper.Map<Author>(authorDTO);
            var existingAuthor = _authorRepository.GetAll().AsNoTracking().FirstOrDefault(a => a.Id == author.Id);
            if (existingAuthor != null)
            {
                _authorRepository.Update(author);
                return true;
            }
            return false;
        }
        public AuthorDTO GetByName(string name)
        {
            var author = _authorRepository.GetAll().Where(a => a.Name == name).FirstOrDefault();
            AuthorDTO authorDTO = _mapper.Map<AuthorDTO>(author);
            return authorDTO;
        }

        public AuthorDTO GetAuthorByBookID(int id)
        {
            var authors = _authorRepository.GetAll().Include(a => a.Books).ToList();
            var author = authors.FirstOrDefault(a => a.Id == id);
            AuthorDTO authorDTO = _mapper.Map<AuthorDTO>(author);
            return authorDTO;
        }

    }
}
