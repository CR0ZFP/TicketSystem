using AutoMapper;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Entitites.Dto.Problem;
using TicketSystem.Entitites.Entities;

namespace TicketSystem.Logic.Dto
{
    public class DtoProvider
    {
        public Mapper Mapper { get; }

        public DtoProvider()
        {
            this.Mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Problem, ProblemViewDto>().ForMember(
                dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));
                cfg.CreateMap<ProblemCreateDto, Problem>();

            }));
        }
    }
}
