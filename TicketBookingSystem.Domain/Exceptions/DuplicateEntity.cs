using System;
using System.Collections.Generic;
using System.Text;
using SysEx = System.Exception;


namespace TicketBookingSystem.Domain.Exceptions
{
    public class DuplicateEntity : SysEx
    {
        public DuplicateEntity(string message)
            : base(message)
        {
        }
    
    }
}
