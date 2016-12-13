using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDP
{
    public class SearchedEDP
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
        }