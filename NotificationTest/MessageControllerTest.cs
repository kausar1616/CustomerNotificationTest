using CustomerNotification.API.Controllers;
using CustomerNotification.API.DTOs;
using CustomerNotificaton.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationTest
{
    [TestClass]
    public class MessageControllerTest
    {
        [TestMethod]
        public void Register()
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
                LastName = "ahm"
            };

            var response = controller.Post(newUserRegisteredDTO);
            var result = response as CreatedAtRouteResult;
            Assert.AreEqual(201, result.StatusCode);
        }
    }
}
