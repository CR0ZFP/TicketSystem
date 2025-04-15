using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Data;
using TicketSystem.Entitites.Dto.Problem;
using TicketSystem.Entitites.Entities;
using TicketSystem.Logic.Dto;

namespace TicketSystem.Logic
{
    public class ProblemLogic
    {
        public Repository<Problem> repository;
        public Mapper Mapper;
        public ProblemLogic(Repository<Problem> repository, DtoProvider provider)
        {
            this.repository = repository;
            this.Mapper = provider.Mapper;
        }

        public IEnumerable<ProblemViewDto> Read ()
        {
            return repository.GetAll()
                .Include(x => x.User)
                .Select(x => Mapper.Map<ProblemViewDto>(x))
                .ToList();
        }

        public void Create(ProblemCreateDto problem, string userId)
        {
            var entity = Mapper.Map<Problem>(problem);
            entity.Date = DateTime.Now;
            entity.UserId = userId;
            repository.Create(entity);
        }
    }
}
