using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerNotificaton.Services.Model
{
    public class Data
    {
        public Guid? CustomerId { get; set; }      
    }

    public class Message
    {
        public Message()
        {
            Data = new Data();
        }
        public string MessageType { get; set; }
        public Data Data { get; set; }
    }

    public class RegisterUser : Message
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
