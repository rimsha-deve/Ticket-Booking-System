using System;
using SysEx = System.Exception;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace TicketBookingSystem.Domain.Exceptions
{
    public class NotFoundException : SysEx
    {
        public NotFoundException(string message)
            : base(message)
        {
        }
    }
}
