using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCMNotification.Models
{

    public class ProductBoxViewModel
    {
        /// <summary>
        /// 商品代碼 GoodID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 商品名稱
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 商品圖
        /// </summary>
        public string imageUrl { get; set; }
        /// <summary>
        /// 頁面連結
        /// </summary>
        public string pageLink { get; set; }
        /// <summary>
        /// 購買連結
        /// </summary>
        public string purchaseLink { get; set; }
        /// <summary>
        /// 市價
        /// </summary>
        public string marketingPrice { get; set; }
        /// <summary>
        /// 優惠價
        /// </summary>
        public string finalPrice { get; set; }
        /// <summary>
        /// 是否18禁
        /// </summary>
        public bool isAgeRating { get; set; }
        /// <summary>
        /// 排序數字
        /// </summary>
        public int sort { get; set; }
        /// <summary>
        /// 廣告編號
        /// </summary>
        public string advertisementId { get; set; }
    }
}