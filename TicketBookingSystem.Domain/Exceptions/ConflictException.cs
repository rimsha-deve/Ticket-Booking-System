using System;
using System.Collections.Generic;
using System.Text;
using SysEx = System.Exception;

namespace TicketBookingSystem.Domain.Exception
{
    public class ConflictException : SysEx
    {
        public ConflictException(string message)
       : base(message)
        {
        }
    }
}
