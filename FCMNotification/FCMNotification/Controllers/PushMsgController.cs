using FCMNotification.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace FCMNotification.Controllers
{
    public class PushMsgController : Controller
    {
        PushMsgModels pushMsgModels = new PushMsgModels();
        // GET: PushMsg
        public ActionResult Index()
        {

            pushMsgModels = LoadJson();
            SelectList list = new SelectList(pushMsgModels.AppPlatForm, "App", "App");
            SelectList Styles = new SelectList(pushMsgModels.Styles, "style", "showName");
            SelectList Types = new SelectList(pushMsgModels.Types, "type", "showTite");


            ViewBag.AppPlatFormList = list;
            ViewBag.Styles = Styles;
            ViewBag.Types = Types;
            
            var cookie = HttpContext.Request.Cookies["Pushdll"] ?? new HttpCookie("Pushdll");
            cookie.HttpOnly = true;
            var json = JsonConvert.SerializeObject(pushMsgModels);
            cookie.Value = HttpContext.Server.UrlEncode(json);
            HttpContext.Response.Cookies.Add(cookie);


            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            XmlDocument xDoc = new XmlDocument();
            xDoc.AppendChild(xDoc.CreateElement("Data"));
            string goodlist = string.Empty;
            XmlElement element = null;
            XmlElement Content = null;
            XmlElement Good = null;
            XmlElement Repeater = xDoc.CreateElement("Repeater");
            DataTable Tem = new DataTable();
            XmlNode DiscountNode;
            XmlNode CPRCNode;
            DataTable t1 = new DataTable();
            DataTable t2 = new DataTable();
            t1.Columns.Add("zipurl");
            t1.Columns.Add("clickurl");
            t1.Columns.Add("bannerurl");
            t1.Columns.Add("name");
            t1.Rows.Add("NULL", "NULL", "http://localhost/FugoETMallB2CR2/E68Images/Mobile/SPBanner/2014101318410_87ffb9c7-0072-4227-9093-57c0dbc6b448.jpg", "新活動123");

            t2.Columns.Add("good_id1");
            t2.Columns.Add("good_sub1");
            t2.Columns.Add("good_prc1");
            t2.Columns.Add("good_id2");
            t2.Columns.Add("good_sub2");
            t2.Columns.Add("good_prc2");
            t2.Columns.Add("type");
            t2.Columns.Add("PRC1");
            t2.Columns.Add("GOOD_NM1");
            t2.Columns.Add("PRC2");
            t2.Columns.Add("GOOD_NM2");
            t2.Rows.Add("1130690", "TEST", "NULL", "1130690", "TEST", "NULL", "A", 1000, "LIGHT & amp; DARK菁竹良炭平口褲組", 1000, "LIGHT & amp; DARK菁竹良炭平口褲組");
            t2.Rows.Add("1130690", "TEST", "NULL", "1130690", "TEST", "NULL", "B", 1000, "LIGHT & amp; DARK菁竹良炭平口褲組", 1000, "LIGHT & amp; DARK菁竹良炭平口褲組");
            t2.Rows.Add("1130690", "TEST", "NULL", "1130690", "TEST", "NULL", "A", 1000, "LIGHT & amp; DARK菁竹良炭平口褲組", 1000, "LIGHT & amp; DARK菁竹良炭平口褲組");
            t2.Rows.Add("1130693", "可愛小碎花圖案讓你安心睡到天亮不外漏", "NULL","","", "NULL", "B", 649, "【莫妮塔】可愛小碎花防水不外漏貼身彈性低腰生理褲 &#40;568&#41;", 499, "【海鮮市集】手工製作竹筴魚一夜干 3份..");

            ds.Tables.Add(t1);
            ds.Tables.Add(t2);
            
            element = xDoc.CreateElement("Name");
            element.InnerText = ds.Tables[0].Rows[0]["name"].ToString();
            xDoc.DocumentElement.AppendChild(element);
            element = xDoc.CreateElement("bannerurl");
            element.InnerText = ds.Tables[0].Rows[0]["bannerurl"].ToString();
            xDoc.DocumentElement.AppendChild(element);
            element = xDoc.CreateElement("clickurl");
            element.InnerText = ds.Tables[0].Rows[0]["clickurl"].ToString();
            xDoc.DocumentElement.AppendChild(element);
            element = xDoc.CreateElement("zipurl");
            element.InnerText = ds.Tables[0].Rows[0]["zipurl"].ToString();
            xDoc.DocumentElement.AppendChild(element);
            foreach (DataRow dr in ds.Tables[1].Rows)
            {


                if (dr["type"].ToString() == "A")   //兩支商品
                {
                    Content = xDoc.CreateElement("Content");
                    element = xDoc.CreateElement("type");
                    element.InnerText = dr["type"].ToString();
                    Content.AppendChild(element);
                    element = xDoc.CreateElement("GOOD_ID");
                    element.InnerText = dr["good_id1"].ToString();
                    if (goodlist == "")
                    {
                        goodlist = goodlist + dr["good_id1"].ToString();
                    }
                    else
                    {
                        if (goodlist.IndexOf(dr["good_id1"].ToString()) < 0)
                            goodlist = goodlist + "," + dr["good_id1"].ToString();
                    }
                    Content.AppendChild(element);

                    element = xDoc.CreateElement("GOOD_NM");
                    element.InnerText = dr["GOOD_NM1"].ToString();
                    Content.AppendChild(element);

                    element = xDoc.CreateElement("PRC");
                    element.InnerText = dr["PRC1"].ToString();
                    Content.AppendChild(element);

                    element = xDoc.CreateElement("GOOD_SUB");
                    if (dr["good_sub1"].ToString() == "")
                    {
                        element.InnerText = "Empty";
                    }
                    else
                    {
                        element.InnerText = dr["good_sub1"].ToString();
                    }
                    Content.AppendChild(element);

                    element = xDoc.CreateElement("GOOD_PRC");
                    if (dr["good_prc1"].ToString() == "")
                    {
                        element.InnerText = "";
                    }
                    else
                    {
                        element.InnerText = dr["good_prc1"].ToString();
                    }
                    Content.AppendChild(element);

                    Repeater.AppendChild(Content);


                    Content = xDoc.CreateElement("Content");
                    element = xDoc.CreateElement("type");
                    element.InnerText = dr["type"].ToString();
                    Content.AppendChild(element);
                    element = xDoc.CreateElement("GOOD_ID");
                    element.InnerText = dr["good_id2"].ToString();
                    if (goodlist == "")
                    {
                        goodlist = goodlist + dr["good_id2"].ToString();
                    }
                    else
                    {
                        if (goodlist.IndexOf(dr["good_id2"].ToString()) < 0)
                            goodlist = goodlist + "," + dr["good_id2"].ToString();
                    }
                    Content.AppendChild(element);

                    element = xDoc.CreateElement("GOOD_NM");
                    element.InnerText = dr["GOOD_NM2"].ToString();
                    Content.AppendChild(element);
                    element = xDoc.CreateElement("PRC");
                    element.InnerText = dr["PRC2"].ToString();
                    Content.AppendChild(element);

                    element = xDoc.CreateElement("GOOD_SUB");
                    if (dr["good_sub2"].ToString() == "")
                    {
                        element.InnerText = "Empty";
                    }
                    else
                    {
                        element.InnerText = dr["good_sub2"].ToString();
                    }
                    Content.AppendChild(element);

                    element = xDoc.CreateElement("GOOD_PRC");
                    if (dr["good_prc2"].ToString() == "")
                    {
                        element.InnerText = "";
                    }
                    else
                    {
                        element.InnerText = dr["good_prc2"].ToString();
                    }
                    Content.AppendChild(element);

                    Repeater.AppendChild(Content);
                }
                else    //單支商品 dr["type"].ToString() == "B"
                {
                    Content = xDoc.CreateElement("Content");
                    element = xDoc.CreateElement("type");
                    element.InnerText = dr["type"].ToString();
                    Content.AppendChild(element);
                    element = xDoc.CreateElement("GOOD_ID");
                    element.InnerText = dr["good_id1"].ToString();
                    if (goodlist == "")
                    {
                        goodlist = goodlist + dr["good_id1"].ToString();
                    }
                    else
                    {
                        if (goodlist.IndexOf(dr["good_id1"].ToString()) < 0)
                            goodlist = goodlist + "," + dr["good_id1"].ToString();
                    }
                    Content.AppendChild(element);

                    element = xDoc.CreateElement("GOOD_NM");
                    element.InnerText = dr["GOOD_NM1"].ToString();
                    Content.AppendChild(element);

                    element = xDoc.CreateElement("PRC");
                    element.InnerText = dr["PRC1"].ToString();
                    Content.AppendChild(element);


                    element = xDoc.CreateElement("GOOD_SUB");
                    if (dr["good_sub1"].ToString() == "")
                    {
                        element.InnerText = "Empty";
                    }
                    else
                    {
                        element.InnerText = dr["good_sub1"].ToString();
                    }
                    Content.AppendChild(element);

                    element = xDoc.CreateElement("GOOD_PRC");
                    if (dr["good_prc1"].ToString() == "")
                    {
                        element.InnerText = "";
                    }
                    else
                    {
                        element.InnerText = dr["good_prc1"].ToString();
                    }
                    Content.AppendChild(element);

                    Repeater.AppendChild(Content);
                }


            }
            xDoc.DocumentElement.AppendChild(Repeater);

            Tem.Columns.Add("GOOD_ID");
            Tem.Columns.Add("DISCOUNT_VALUE");
            Tem.Columns.Add("CPRC");

            Tem.Rows.Add("1130690", "", "2400");

            XmlNodeList nodes = xDoc.DocumentElement.SelectNodes("/Data/Repeater/Content");
            foreach (XmlNode GoodNode in nodes)
            {
                DiscountNode = xDoc.CreateElement("DisValue");
                CPRCNode = xDoc.CreateElement("CPRC");
                if (Tem.Select("GOOD_ID=" + GoodNode.SelectSingleNode("GOOD_ID").InnerText).Length > 0)
                {
                    DiscountNode.InnerXml = Tem.Select("GOOD_ID=" + GoodNode.SelectSingleNode("GOOD_ID").InnerText)[0]["DISCOUNT_VALUE"].ToString();
                    CPRCNode.InnerXml = Tem.Select("GOOD_ID=" + GoodNode.SelectSingleNode("GOOD_ID").InnerText)[0]["CPRC"].ToString();
                }
                else
                {
                    DiscountNode.InnerXml = "";
                    CPRCNode.InnerXml = "";
                }
                GoodNode.AppendChild(DiscountNode);
                GoodNode.AppendChild(CPRCNode);

            }

            return View(pushMsgModels);
        }


        public PushMsgModels LoadJson()
        {
            PushMsgModels items = new PushMsgModels();
            using (StreamReader r = new StreamReader(@"D:\VSTraning\FCMNotification\FCMNotification\PushMsg.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<PushMsgModels>(json);
            }
            return items;
        }

        public ActionResult ImgTraning()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImgTraning(HttpPostedFileBase files, FormCollection input)
        {
            var file = Request.Files;
            return View();
        }

        public ActionResult UploadImg(HttpPostedFileBase files, FormCollection input, string id)
        {
            Response.StatusCode = 200;
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteImg()
        {
            Response.StatusCode = 200;
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
