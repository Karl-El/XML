using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Data;

namespace EDP
{
    public class ProdInfo
    {
        public static DataTable ShowDetails(List<string> getEDP)
        {
            DataTable dt_ProdInfo = new DataTable();
            dt_ProdInfo.Columns.AddRange(new DataColumn[6]
            { new DataColumn("ProdName", typeof(string)),new DataColumn("ProdManufact", typeof(string)),new DataColumn("ProdDesc", typeof(string)),
            new DataColumn("ProdFinPrice", typeof(string)),new DataColumn("ProdAvailDesc", typeof(string)),new DataColumn("ProdImgURl", typeof(string)),
            });
            string name = "", manufact = "", desc = "", finalprice = "", availdesc = "", imageurl = "";
            for (int i = 0; i < getEDP.Count; i++)
            {
                string URL = "http://afs-sl-pservice01.afservice.org:8080/productservice2/getProductInfo/pcmall?edplist=" + getEDP[i] + "&ignoreCatalog=true";
                XmlTextReader reader = new XmlTextReader(URL);
                reader.WhitespaceHandling = WhitespaceHandling.Significant;
                while (reader.Read())
                {

                    if (reader.Name == "name")
                    {
                        name = reader.ReadElementString("name");
                    }
                    if (reader.Name == "manufacturer")
                    {
                        manufact = reader.ReadElementString("manufacturer");
                    }
                    if (reader.Name == "description")
                    {
                        desc = reader.ReadElementString("description");
                    }
                    if (reader.Name == "finalPrice")
                    {
                        finalprice = reader.ReadElementString("finalPrice");
                    }
                    if (reader.Name == "availabilityDescription")
                    {
                        availdesc = reader.ReadElementString("availabilityDescription");
                    }
                    if (reader.Name == "xlg")
                    {
                        imageurl = reader.ReadElementString("xlg");
                    }
                }
                dt_ProdInfo.Rows.Add(name, manufact, desc, "$ " + finalprice, availdesc, imageurl);
            }

            return dt_ProdInfo;
        }

        public static DataTable ShowInfo(string getEDP)
        {
            DataTable dt_ProdInfo = new DataTable();
            dt_ProdInfo.Columns.AddRange(new DataColumn[6]
            { new DataColumn("ProdName", typeof(string)),new DataColumn("ProdManufact", typeof(string)),new DataColumn("ProdDesc", typeof(string)),
            new DataColumn("ProdFinPrice", typeof(string)),new DataColumn("ProdAvailDesc", typeof(string)),new DataColumn("ProdImgURl", typeof(string)),
            });
            string name = "", manufact = "", desc = "", finalprice = "", availdesc = "", imageurl = "";
            string URL = "http://afs-sl-pservice01.afservice.org:8080/productservice2/getProductInfo/pcmall?edplist=" + getEDP + "&ignoreCatalog=true";
            XmlTextReader reader = new XmlTextReader(URL);
            reader.WhitespaceHandling = WhitespaceHandling.Significant;
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "item")
                {
                    if (reader.Name == "name")
                    {
                        name = reader.ReadElementString("name");
                    }
                    if (reader.Name == "manufacturer")
                    {
                        manufact = reader.ReadElementString("manufacturer");
                    }
                    if (reader.Name == "description")
                    {
                        desc = reader.ReadElementString("description");
                    }
                    if (reader.Name == "finalPrice")
                    {
                        finalprice = reader.ReadElementString("finalPrice");
                    }
                    if (reader.Name == "availabilityDescription")
                    {
                        availdesc = reader.ReadElementString("availabilityDescription");
                    }
                    if (reader.Name == "xlg")
                    {
                        imageurl = reader.ReadElementString("xlg");
                    }
                    dt_ProdInfo.Rows.Add(name, manufact, desc, "$ " + finalprice, availdesc, imageurl);
                }
            }
            return dt_ProdInfo;
        }

        /*public void ShowDetails(string GetEDP, string NAME, string MANUFACT, string DESC, string FINALPRICE, string AVAILDESC, string IMAGEURL)
        {
            #region Working Code for Prod details
            string URL = "http://afs-sl-pservice01.afservice.org:8080/productservice2/getProductInfo/pcmall?edplist=" + GetEDP + "&ignoreCatalog=true";
            XmlTextReader reader = new XmlTextReader(URL);
            reader.WhitespaceHandling = WhitespaceHandling.Significant;
            while (reader.Read())
            {

                if (reader.Name == "name")
                {
                    NAME = reader.ReadElementString("name");
                }
                if (reader.Name == "manufacturer")
                {
                    MANUFACT = reader.ReadElementString("manufacturer");
                }
                if (reader.Name == "description")
                {
                    DESC = reader.ReadElementString("description");
                }
                if (reader.Name == "finalPrice")
                {
                    FINALPRICE = reader.ReadElementString("finalPrice");
                }
                if (reader.Name == "availabilityDescription")
                {
                    AVAILDESC = reader.ReadElementString("availabilityDescription");
                }
                if (reader.Name == "xlg")
                {
                    IMAGEURL = reader.ReadElementString("xlg");

                }
            }*/
    }
}