using ApoloHealth.Application.UseCases.EmployeeOperations.GetAll;
using ApoloHealth.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.ExamOperations.GetAll;

public sealed class GetAllEquipmentMapper : Profile
{
    public GetAllEquipmentMapper()
    {
        CreateMap<Equipment, GetAllEquipmentResponse>()
            .ForMember(dest => dest.Technicians, opt =>
             opt.MapFrom(src => src.Technicians.Select(x =>
             new EmployeeDTO()
             {
                 Id = x.Id,
                 Role = x.Role,
                 Wage = x.Wage,
                 Name = x.Name,
                 CPF = x.CPF,
                 BirthDate = x.BirthDate,
                 Email = x.Email,
                 Phone = x.Phone,
                 Gender = x.Gender,
                 Nationality = x.Nationality,
                 MaritalStatus = x.MaritalStatus,
                 Addresses = x.Addresses
             }
             )));
    }

}
