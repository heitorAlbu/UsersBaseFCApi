using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersBaseFC.Application.CQRS.Users.Commands.Register;
using UsersBaseFC.Application.CQRS.Users.Commands.Remove;
using UsersBaseFC.Application.CQRS.Users.Commands.Update;
using UsersBaseFC.Application.DTOs;
using UsersBaseFC.Domain.Entities;

namespace UsersBaseFC.Application.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<RegisterUserCommand, User>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.Name, opt => opt.MapFrom(p => p.Name))
                .ForMember(p => p.Password, opt => opt.MapFrom(p => p.Password))
                .ForMember(p => p.Email, opt => opt.MapFrom(p => p.Email))
                .ForMember(p => p.Fone, opt => opt.MapFrom(p => p.Fone))
                .ForMember(p => p.CPF, opt => opt.MapFrom(p => p.CPF))
                .ForMember(p => p.BirthDate, opt => opt.MapFrom(p => p.BirthDate))
                .ForMember(p => p.InclusionDate, opt => opt.MapFrom(p => DateTime.Now))
                //.ForMember(p => p.ChangeDate, opt => opt.MapFrom(p => p.ChangeDate))
                .ForMember(p => p.MotherName, opt => opt.MapFrom(p => p.MotherName))
                .ForMember(p => p.isActive, opt => opt.MapFrom(p => p.isActive));

            CreateMap<User, UserDTO>()
                .ForMember(p => p.Id, opt => opt.MapFrom(p => p.Id.ToString()))
                .ForMember(p => p.Name, opt => opt.MapFrom(p => p.Name))
                .ForMember(p => p.Email, opt => opt.MapFrom(p => p.Email))
                .ForMember(p => p.Fone, opt => opt.MapFrom(p => p.Fone))
                .ForMember(p => p.CPF, opt => opt.MapFrom(p => p.CPF))
                .ForMember(p => p.BirthDate, opt => opt.MapFrom(p => p.BirthDate.ToString()))
                .ForMember(p => p.InclusionDate, opt => opt.MapFrom(p => p.InclusionDate.ToString()))
                .ForMember(p => p.ChangeDate, opt => opt.MapFrom(p => p.ChangeDate.ToString()))
                .ForMember(p => p.MotherName, opt => opt.MapFrom(p => p.MotherName))
                .ForMember(p => p.isActive, opt => opt.MapFrom(p => p.isActive));
               

            CreateMap<UpdateUserCommand, User>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.Name, opt => opt.MapFrom(p => p.Name))
                .ForMember(p => p.Password, opt => opt.MapFrom(p => p.Password))
                .ForMember(p => p.Email, opt => opt.MapFrom(p => p.Email))
                .ForMember(p => p.Fone, opt => opt.MapFrom(p => p.Fone))
                .ForMember(p => p.CPF, opt => opt.MapFrom(p => p.CPF))
                .ForMember(p => p.BirthDate, opt => opt.MapFrom(p => p.BirthDate))
                //.ForMember(p => p.InclusionDate, opt => opt.MapFrom(p => p.InclusionDate))
                .ForMember(p => p.ChangeDate, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(p => p.MotherName, opt => opt.MapFrom(p => p.MotherName))
                .ForMember(p => p.isActive, opt => opt.MapFrom(p => p.isActive));

        }
    }
}
