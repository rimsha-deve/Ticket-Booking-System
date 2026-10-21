using System;
using System.Collections.Generic;
using System.Text;
using SysEx = System.Exception;

namespace TicketBookingSystem.Domain.Exception
{
    public class BadRequestException : SysEx
    {
        public BadRequestException(string message)
       : base(message)
        {
        }
    }
}
