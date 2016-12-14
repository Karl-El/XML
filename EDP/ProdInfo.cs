using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace EDP
{
    public class ProdInfo
    {

        public void ShowDetails(string GetEDP, string NAME, string MANUFACT, string DESC, string FINALPRICE, string AVAILDESC, string IMAGEURL)
        {
            #region Working Code for Prod details
            //for (int i = 0; i < GetEDP.Count; i++)
            #region FORSTART
            //{
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
            }
            #endregion
            //}
            #endregion
        }
    }
}