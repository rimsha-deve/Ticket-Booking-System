using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using SysEx = System.Exception;

namespace TicketBookingSystem.Domain.Exceptions
{
    public class UnauthorizedException : SysEx
    {
        public UnauthorizedException(string message)
            : base(message)
        {
        }
    }
}
