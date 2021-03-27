using CustomerNotification.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerNotificaton.Services
{
    public class MessagingService : IMessagingService
    {
        public async Task<List<string>> GetMessageTypes()
        {            
            await Task.Delay(1000);
            var types = Helper.GetMessageTypes();            
            return types;
        }
        public async Task<List<string>> GetMessageFormats()
        {
            await Task.Delay(1000);
            var formatTypes = new List<string>() { "JSON", "XML", "CSV" };
            return formatTypes;
        }

        public async Task SendMessageAsync(string customerId, string messageBody)
        {
            //this is a mock method and candidates don't need to chage this
            await Task.Delay(1000);
            Console.WriteLine($"sending customer id: {customerId}, the following message {messageBody}");
        }
      
    }

}