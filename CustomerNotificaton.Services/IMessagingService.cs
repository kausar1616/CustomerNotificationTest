using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerNotificaton.Services
{
    public interface IMessagingService
    {
        Task<List<string>> GetMessageFormats();
        Task<List<string>> GetMessageTypes();
        Task SendMessageAsync(string customerId, string messageBody);
    }
}