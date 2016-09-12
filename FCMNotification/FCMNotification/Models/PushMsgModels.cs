using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCMNotification.Models
{

    public class PushMsgModels
    {
        public List<Appplatform> AppPlatForm { get; set; }
        public List<Style> Styles { get; set; }
        public List<Type> Types { get; set; }
    }

    public class Appplatform
    {
        public string App { get; set; }
        public List<int> Styles { get; set; }
        public List<int> Types { get; set; }
    }

    public class Style
    {
        public int style { get; set; }
        public string showName { get; set; }
        public bool title { get; set; }
        public bool content { get; set; }
        public bool banner { get; set; }
    }

    public class Type
    {
        public int type { get; set; }
        public string showTite { get; set; }
    }


}