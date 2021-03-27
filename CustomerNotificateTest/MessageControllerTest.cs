using CustomerNotification.API.Controllers;
using CustomerNotification.API.DTOs;
using CustomerNotificaton.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomerNotificateTest
{
    [TestClass]
    public class MessageControllerTest
    {
        [TestMethod]
        public void RegisterSuccess()
        {
            var messagingService = new MessagingService();
            var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();
            var factory = serviceProvider.GetService<ILoggerFactory>();

            var logger = factory.CreateLogger<MessageController>();

            var controller = new MessageController(messagingService, logger);


            var newUserRegisteredDTO = new MessageDTO()
            {
                Email = "kas@gmail.com",
                FirstName = "kas",
                LastName = "ahm",
                MessageFormat = "JSON"
            };

            var response = controller.Post(newUserRegisteredDTO);
            var result = response as StatusCodeResult;
            Assert.AreEqual(204, result.StatusCode);
        }

        [TestMethod]
        public void GetSuccess()
        {
            var messagingService = new MessagingService();
            var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();
            var factory = serviceProvider.GetService<ILoggerFactory>();

            var logger = factory.CreateLogger<MessageController>();

            var controller = new MessageController(messagingService, logger);
                                  
            var response = controller.Get();
            var messageTypes = response.Value;
            Assert.AreEqual(3, messageTypes.Count);
        }
    }
}
