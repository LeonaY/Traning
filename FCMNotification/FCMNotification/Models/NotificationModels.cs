using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCMNotification.Models
{
    public class NotificationModels
    {
        public string Authorization { get; set; }
        public string SendTitle { get; set; }

        public string SendMsg { get; set; }
        public string RegistrationToken { get; set; }

        public string Topics { get; set; }
        public string SendResponse { get; set; }

        public bool IsByToken { get; set; }

        public string application { get; set; }

        public bool IsSandBox { get; set; }
    }
}