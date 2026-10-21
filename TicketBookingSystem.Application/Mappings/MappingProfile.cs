using System;
using System.Collections.Generic;
using System.Text;
using TicketBookingSystem.Application.DTOs.Login;
using TicketBookingSystem.Domain.Entities;

namespace TicketBookingSystem.Application.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {

            CreateMap<User, AuthResponse>();

        }
    }

}