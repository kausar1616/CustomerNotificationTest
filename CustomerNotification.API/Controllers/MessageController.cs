using CustomerNotification.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using CustomerNotificaton.Services;
using CustomerNotification.API.Helpers;

namespace CustomerNotification.API.Controllers
{
    [ApiController]
    [Route("api/message")]    
    public class MessageController : ControllerBase
    {        
        private readonly ILogger<MessageController> _logger;
        private readonly IMessagingService _messagingService;

        public MessageController(IMessagingService messagingService, ILogger<MessageController> logger)
        {   
            _logger = logger;
            _messagingService = messagingService;

        }
                
        [HttpGet("getMessageTypes")]
        public ActionResult<List<string>> Get()
        {
            var types = _messagingService.GetMessageTypes().Result;
                        
            _logger.LogInformation(Resource.TotalCountMessageTypes, types.Count);
            return types;
        }
        
        [HttpGet]
        [Route("getMessageFormat")]
        public ActionResult<List<string>> GetMessageFormat()
        {
            var formatTypes = _messagingService.GetMessageFormats().Result;

            _logger.LogInformation(Resource.TotalCountMessageFormat, formatTypes.Count);
            return formatTypes;
        }

        [HttpPost()]
        [Route("register")]
        public ActionResult Post([FromBody] MessageDTO newUserRegisteredDTO)
        {
            if (newUserRegisteredDTO.MessageFormat == null)
            {
                return BadRequest(Resource.MessageFormatNotNull);
            }

            var messageBody =  ApiHelper.ProcessObjectToString(newUserRegisteredDTO, MessageType.NewUserRegistered);
            var customerId = newUserRegisteredDTO.CustomerId.ToString();

            _messagingService.SendMessageAsync(customerId, messageBody);

            _logger.LogInformation(Resource.RegisterUserInfo, newUserRegisteredDTO.CustomerId);
            return NoContent();
        }

        [HttpPost()]
        [Route("userAccessBlocked")]
        public ActionResult UserAccessBlocked([FromBody] MessageDTO messageDTO)
        {
            if (messageDTO.CustomerId == null)
            {
                return BadRequest(Resource.CustomerIdNotNull);
            }

            if (messageDTO.MessageFormat == null)
            {
                return BadRequest(Resource.MessageFormatNotNull);
            }

            var messageBody = ApiHelper.ProcessObjectToString(messageDTO, MessageType.UserAccessBlocked);
            var customerId = messageDTO.CustomerId.ToString();

            _messagingService.SendMessageAsync(customerId, messageBody);

            _logger.LogInformation(Resource.UserAccessBlockedInfo, messageDTO.CustomerId);
            return NoContent();
        }

        [HttpPost()]
        [Route("userDeleted")]
        public ActionResult UserDeleted([FromBody] MessageDTO messageDTO)
        {
            if (messageDTO.CustomerId == null)
            {
                return BadRequest(Resource.CustomerIdNotNull);
            }

            if (messageDTO.MessageFormat == null)
            {
                return BadRequest(Resource.MessageFormatNotNull);
            }

            var messageBody = ApiHelper.ProcessObjectToString(messageDTO, MessageType.UserDeleted);
            var customerId = messageDTO.CustomerId.ToString();

            _messagingService.SendMessageAsync(customerId, messageBody);

            _logger.LogInformation(Resource.UserDeletedInfo, messageDTO.CustomerId);
            return NoContent();
        }


    }

}
