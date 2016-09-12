using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCMNotification.Models
{
    public class BannerViewModel
    {
    }
    public class ProductPeriodViewModel : ProductBoxViewModel
    {
        /// <summary>
        /// 時間區間
        /// </summary>
        public PeriodModel period { get; set; }

        public string tel { get; set; }
    }
    public class PeriodModel
    {
        /// <summary>
        /// 起始時間
        /// </summary>
        public string start { get; set; }
        /// <summary>
        /// 過期時間
        /// </summary>
        public string expired { get; set; }
    }
}