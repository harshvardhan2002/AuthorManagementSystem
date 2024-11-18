using AuthorWebApiProject.DTOs;
using AuthorWebApiProject.Models;
using AuthorWebApiProject.Repsoitories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorWebApiProject.Services
{
    public class AuthorDetailsService : IAuthorDetailsService
    {
        private readonly IRepository<AuthorDetail> _authorDetailsRepository;

        private readonly IMapper _mapper;
        public AuthorDetailsService(IRepository<AuthorDetail> detailRepository, IMapper mapper)
        {
            _authorDetailsRepository = detailRepository;
            _mapper = mapper;
        }
        public int AddAuthorDetails(AuthorDetailsDTO detailDTO)
        {
            var detail = _mapper.Map<AuthorDetail>(detailDTO);
            _authorDetailsRepository.Add(detail);
            return detail.Id;
        }

        public bool DeleteAuthorDetails(int id)
        {
            var detail = _authorDetailsRepository.Get(id);
            if (detail != null)
            {
                _authorDetailsRepository.Delete(detail);
                return true;
            }
            return false;
        }

        public List<AuthorDetailsDTO> GetAuthorsDetails()
        {
            var details = _authorDetailsRepository.GetAll().Include(a=>a.Author).ToList();
            List<AuthorDetailsDTO> detailDTO = _mapper.Map<List<AuthorDetailsDTO>>(details);
            return detailDTO;
        }

        public AuthorDetailsDTO GetById(int id)
        {
            var details = _authorDetailsRepository.Get(id);
            AuthorDetailsDTO detailDTO = _mapper.Map<AuthorDetailsDTO>(details);
            return detailDTO;
        }

        public bool UpdateAuthorDetails(AuthorDetailsDTO detailDTO)
        {
            var detail = _mapper.Map<AuthorDetail>(detailDTO);
            var existingdetail = _authorDetailsRepository.GetAll().AsNoTracking().FirstOrDefault(a => a.Id == detail.Id);
            if (existingdetail != null)
            {
                _authorDetailsRepository.Update(detail);
                return true;
            }
            return false;
        }

        public AuthorDetailsDTO GetByAuthorId(int id)
        {
            var authorDetails = _authorDetailsRepository.GetAll().Include(a => a.Author).ToList();
            var author = authorDetails.Where(a => a.AuthorId == id).FirstOrDefault();
            AuthorDetailsDTO authorDetail = _mapper.Map<AuthorDetailsDTO>(author);
            return authorDetail;
        }

    }
}
