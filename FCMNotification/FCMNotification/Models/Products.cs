using FCMNotification.Validate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FCMNotification.Models
{
    public class Products
    {
        //[CustomRequireAttribute(20, "Bar", "Baz", ErrorMessage = "The combined minimum length of the Foo, Bar and Baz properties should be longer than 20")]
        public string Foo { get; set; }

        [Required(ErrorMessage = "發送日期必填")]
        public string Bar { get; set; }
        [CustomEmailValidator]
        public string Baz { get; set; }

        [Required(ErrorMessage = "Name is Requirde")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is Requirde")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
    }
}