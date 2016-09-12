using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCMNotification.Models
{
    public class ADModels
    {
    }

    public class Rootobject
    {
        public Adgroup adGroup { get; set; }
        public string ResultCode { get; set; }
        public string ResultMessage { get; set; }
    }

    public class Adgroup
    {
        public Adsite[] AdSites { get; set; }
    }

    public class Adsite
    {
        public string SiteID { get; set; }
        public string Title { get; set; }
        public string TitleEN { get; set; }
        public int EnumType { get; set; }
        public int EnumGroup { get; set; }
        public int AdType { get; set; }
        public Adpacket[] AdPackets { get; set; }
    }

    public class Adpacket
    {
        public string PacketID { get; set; }
        public string SiteID { get; set; }
        public string Title { get; set; }
        public string TitleEN { get; set; }
        public int ShowSeq { get; set; }
        public DateTime OfflineDate { get; set; }
        public int ShowCount { get; set; }
        public Adunit[] AdUnits { get; set; }
    }

    public class Adunit
    {
        public string UnitID { get; set; }
        public string PacketID { get; set; }
        public string UnitKey { get; set; }
        public string Title { get; set; }
        public string BannerTitle { get; set; }
        public string Describe { get; set; }
        public string ImgPath { get; set; }
        public string MoviePath { get; set; }
        public string PageLink { get; set; }
        public string GoodID { get; set; }
        public int ShowSeq { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime SaleDate { get; set; }
        public int AdType { get; set; }
        public int Price { get; set; }
        public string SaleType { get; set; }
        public int PromoPrice { get; set; }
        public string OrderNum { get; set; }
        public string TagID { get; set; }
        public int ADUnitStatus { get; set; }
        public string GroupID { get; set; }
        public int UnitSeq { get; set; }
    }

}