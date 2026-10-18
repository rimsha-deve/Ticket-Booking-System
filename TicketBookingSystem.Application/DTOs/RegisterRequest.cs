using System;
using System.Collections.Generic;
using System.Text;

namespace TicketBookingSystem.Application.DTOs
{
    public class RegisterRequest
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

}
