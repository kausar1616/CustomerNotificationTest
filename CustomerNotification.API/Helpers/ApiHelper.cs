using CustomerNotification.API.DTOs;
using CustomerNotificaton.Services.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace CustomerNotification.API.Helpers
{
    public static class ApiHelper
    {
        public static string ProcessObjectToString(MessageDTO messageDTO, MessageType messageType)
        {
            string messageString;
            if (messageType == MessageType.NewUserRegistered)
            {
                var message = new RegisterUser
                {
                    MessageType = MessageType.NewUserRegistered.ToString(),
                    Email = messageDTO.Email,
                    FirstName = messageDTO.FirstName,
                    LastName = messageDTO.LastName
                };
                message.Data.CustomerId = messageDTO.CustomerId;

                messageString = messageDTO.MessageFormat == "JSON" ? JsonSerializer.Serialize(message) : ProcessObjectToXMLString(message);
            }
            else 
            {
                var message = new Message();
                message.Data.CustomerId = messageDTO.CustomerId;
                if (messageType == MessageType.UserAccessBlocked)
                {
                    message.MessageType = MessageType.UserAccessBlocked.ToString();
                }
                else if(messageType == MessageType.UserDeleted)
                {
                    message.MessageType = MessageType.UserDeleted.ToString();
                }

                messageString = messageDTO.MessageFormat == "JSON" ? JsonSerializer.Serialize(message) : ProcessObjectToXMLString(message);
            }           

            return messageString;            
        }

        public static string ProcessObjectToXMLString(object message)
        {            
            System.Xml.Serialization.XmlSerializer serializer;
            if (message.GetType() == typeof(RegisterUser))
            {
                 serializer = new System.Xml.Serialization.XmlSerializer(typeof(RegisterUser));
            }
            else
            {
                serializer = new System.Xml.Serialization.XmlSerializer(typeof(Message));
            }
                        
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UnicodeEncoding(false, false); // no BOM in a .NET string
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            using (StringWriter textWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    serializer.Serialize(xmlWriter, message);
                }
                return textWriter.ToString();
            }

        }
    }
}
