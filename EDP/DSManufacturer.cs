using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace EDP
{
    public class DSManufacturer
    {
        public List<string> ListingEDPbyManufact(List<string> AllEDP)
        {
            List<string> EDP = new List<string>();
            for (int i = 0; i < AllEDP.Count; i++)
            {
                string URL = "http://afs-sl-pservice01.afservice.org:8080/productservice2/getProductInfo/pcmall?edplist=" + AllEDP[i] + "&ignoreCatalog=true";
                XmlTextReader reader = new XmlTextReader(URL);
                reader.WhitespaceHandling = WhitespaceHandling.Significant;

                while (reader.Read())
                {
                    if (reader.Name == "manufacturer")
                    {
                        string elementstring = reader.ReadElementString("manufacturer");
                        EDP.Add(elementstring);
                    }
                }
            }
            EDP = EDP.Distinct().ToList();
            EDP = EDP.OrderBy(i => i).ToList();
            return (EDP);
        }

        public List<string> EDPListByManufact(string AllEDP)
        {
            List<string> EDP = new List<string>();
            //for (int i = 0; i < AllEDP.Count; i++)
            //{
            string URL = "http://afs-sl-pservice01.afservice.org:8080/productservice2/getProductInfo/pcmall?edplist=" + AllEDP + "&ignoreCatalog=true";
            XmlTextReader reader = new XmlTextReader(URL);
            reader.WhitespaceHandling = WhitespaceHandling.Significant;

            while (reader.Read())
            {

                reader.ReadToFollowing("manufacturer");
                if (reader.Name == "manufacturer")
                {
                    string elementstring = reader.ReadElementString("manufacturer");
                    EDP.Add(elementstring);
                }
            }
            //}
            EDP = EDP.Distinct().ToList();
            EDP = EDP.OrderBy(i => i).ToList();
            return (EDP);
        }
    }
}