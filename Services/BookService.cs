using AuthorWebApiProject.DTOs;
using AuthorWebApiProject.Models;
using AuthorWebApiProject.Repsoitories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorWebApiProject.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IMapper _mapper;
        public BookService(IRepository<Book> bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public int AddBook(BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            _bookRepository.Add(book);
            return book.Id;
        }

        public bool DeleteBook(int id)
        {
            var book = _bookRepository.Get(id); GetById(id);
            if (book != null)
            {
                _bookRepository.Delete(book);
                return true;
            }
            return false;
        }

        public List<BookDTO> GetBooks()
        {
            var books = _bookRepository.GetAll().Include(b=>b.Author).ToList();
            List<BookDTO> bookDTOs = _mapper.Map<List<BookDTO>>(books);
            return bookDTOs;

        }

        public BookDTO GetById(int id)
        {
            var book = _bookRepository.Get(id);
            BookDTO bookDTO = _mapper.Map<BookDTO>(book);
            return bookDTO;
        }

        public bool UpdateBook(BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            var existingBook = _bookRepository.GetAll().AsNoTracking().FirstOrDefault(a => a.Id == book.Id);
            if (existingBook != null)
            {
                _bookRepository.Update(book);
                return true;
            }
            return false;
        }
        public List<BookDTO> GetBookByAuthorID(int id)
        {
            var books = _bookRepository.GetAll().Include(b => b.Author).ToList().Where(a=>a.AuthorId==id);
            List<BookDTO> bookDTO = _mapper.Map<List<BookDTO>>(books);

            return bookDTO;
        }
    }
}
