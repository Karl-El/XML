using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace EDP
{
    public partial class s : System.Web.UI.Page
    {
        string q = "", rows = "5";

        SearchedEDP SearchedEDP = new SearchedEDP();
        DSManufacturer DSManufacturer = new DSManufacturer();
        ProdInfo ProdInfo = new ProdInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            q = Request.QueryString["q"];
            rdbtnlstDataSourceBrandsPageLoad();
            if (IsPostBack)
            {
                ViewAllInfo();
            }

        }

        protected void drpdwnlst_View_SelectedIndexChanged(object sender, EventArgs e)
        {
            rows = drpdwnlst_View.SelectedValue;
            rdbtnlstDataSourceBrands();
            ViewAllInfo();
        }

        public void rdbtnlstDataSourceBrands()
        {
            List<string> Brands;
            List<string> EDPs;
            EDPs = SearchedEDP.EDPSearching(q, rows);
            Brands = DSManufacturer.ListingEDPbyManufact(EDPs);
            if (IsPostBack)
            {
                rdbtnlst_Brand.Items.Clear();
                for (int i = 0; i < Brands.Count; i++)
                {
                    rdbtnlst_Brand.Items.Add(new ListItem(Brands[i]));
                }
            }
        }

        public void rdbtnlstDataSourceBrandsPageLoad()
        {
            List<string> Brands;
            List<string> EDPs;
            EDPs = SearchedEDP.EDPSearching(q, rows);
            Brands = DSManufacturer.ListingEDPbyManufact(EDPs);
            if (!IsPostBack)
            {
                rdbtnlst_Brand.Items.Clear();
                for (int i = 0; i < Brands.Count; i++)
                {
                    rdbtnlst_Brand.Items.Add(new ListItem(Brands[i]));
                }
            }
        }

        protected void lstvw_Prodinfo_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            //dtdpgr_ProdInfo.SetPageProperties(e.StartRowIndex, e.StartRowIndex, false);
            ViewAllInfo();
        }

        public void ViewAllInfo()
        {
            if (IsPostBack)
            {
                DataTable dt_ProdInfo = new DataTable();
                dt_ProdInfo.Columns.AddRange(new DataColumn[6]
                { new DataColumn("ProdName", typeof(string)),new DataColumn("ProdManufact", typeof(string)),new DataColumn("ProdDesc", typeof(string)),
            new DataColumn("ProdFinPrice", typeof(string)),new DataColumn("ProdAvailDesc", typeof(string)),new DataColumn("ProdImgURl", typeof(string)),
                });
                string name = "", manufact = "", desc = "", finalprice = "", availdesc = "", imageurl = "";
                List<string> EDPs;
                EDPs = SearchedEDP.EDPSearching(q, rows);
                for (int i = 0; i < EDPs.Count; i++)
                {
                    string URL = "http://afs-sl-pservice01.afservice.org:8080/productservice2/getProductInfo/pcmall?edplist=" + EDPs[i] + "&ignoreCatalog=true";
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
                    //ProdInfo.ShowDetails(EDPs[i], name, manufact, desc, finalprice, availdesc, imageurl);
                    dt_ProdInfo.Rows.Add(name, manufact, desc, "$ " + finalprice, availdesc, imageurl);
                }

                lstvw_Prodinfo.DataSource = dt_ProdInfo;
                lstvw_Prodinfo.DataBind();
            }
        }

    }
}