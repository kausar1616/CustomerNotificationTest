using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerNotification.API.Helpers
{
    public enum MessageType
    {
        [Description("In rushqq")]
        NewUserRegistered,
        [Description("In rushqqqqq")]
        UserDeleted,
        [Description("In rushqasdfqq")]
        UserAccessBlocked
    }

    public static class Helper
    {
        public static List<string> GetMessageTypes()
        {
            return Enum.GetNames(typeof(MessageType)).ToList();
        }
    }
}
