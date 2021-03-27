using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerNotification.API.DTOs
{
    public class BaseDTO
    {
        public Guid? CustomerId { get; set; }       
        public string? MessageFormat { get; set; }
    }
    public class MessageDTO : BaseDTO
    {
        public MessageDTO()
        {
            CustomerId = Guid.NewGuid();
        }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
