using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace EDP
{
    public class SearchedEDP
    {
        public List<string> EDPSearching(string q, string rows)
        {
            List<string> EDP = new List<string>();
            EDP.Clear();
            string URL = "http://afs-sl-schmgr03.afservice.org:8080/searchManager/search/afs-sl-schmstr.afservice.org:8080/solr4/Products/select?q=" + q + "&fl=EDP&store=pcmall&rows=" + rows + "&start=0";
            XmlTextReader reader = new XmlTextReader(URL);
            while (reader.ReadToFollowing("result"))
            {
                while (reader.ReadToFollowing("int"))
                {
                    if (reader.GetAttribute("name") == "EDP")
                    {
                        string xmltext_EDP = reader.ReadElementString("int");
                        EDP.Add(xmltext_EDP);
                    }
                }
            }
            return (EDP);
        }

        public string EDPinString(string q, int rows, int start)
        {
            string[] StringedEDP = new string[] { };
            List<string> EDP = new List<string>();
            EDP.Clear();
            string URL = "http://afs-sl-schmgr03.afservice.org:8080/searchManager/search/afs-sl-schmstr.afservice.org:8080/solr4/Products/select?q=" + q + "&fl=EDP&store=pcmall&rows=" + rows + "&start="+start;
            XmlTextReader reader = new XmlTextReader(URL);
            while (reader.ReadToFollowing("result"))
            {
                while (reader.ReadToFollowing("int"))
                {
                    if (reader.GetAttribute("name") == "EDP")
                    {
                        string xmltext_EDP = reader.ReadElementString("int");
                        EDP.Add(xmltext_EDP);
                    }

                }
            }
            StringedEDP = EDP.ToArray();
            string EDPString = string.Join(",", StringedEDP);
            return (EDPString);
        }

        public string EDPinStringForMan(string q, int rows)
        {
            string[] StringedEDP = new string[] { };
            List<string> EDP = new List<string>();
            EDP.Clear();
            string URL = "http://afs-sl-schmgr03.afservice.org:8080/searchManager/search/afs-sl-schmstr.afservice.org:8080/solr4/Products/select?q=" + q + "&fl=EDP&store=pcmall&rows=" + rows + "&start=0";
            XmlTextReader reader = new XmlTextReader(URL);
            while (reader.ReadToFollowing("result"))
            {
                while (reader.ReadToFollowing("int"))
                {
                    if (reader.GetAttribute("name") == "EDP")
                    {
                        string xmltext_EDP = reader.ReadElementString("int");
                        EDP.Add(xmltext_EDP);
                    }

                }
            }
            StringedEDP = EDP.ToArray();
            string EDPString = string.Join(",", StringedEDP);
            return (EDPString);
        }
    }
}
//http://afs-sl-schmgr03.afservice.org:8080/searchManager/search/afs-sl-schmstr.afservice.org:8080/solr4/Products/select?q=" + Findproduct + "&fl=EDP&store=pcmall&rows=" + ProductLimitView + "&start=" + StartRead + "&facet=true&facet.field=Manufacturer&facet.field=InStock&facet.limit=" + BrandLimit
