using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            ViewAllInfo();
        }



        protected void drpdwnlst_View_SelectedIndexChanged(object sender, EventArgs e)
        {
            rows = drpdwnlst_View.SelectedValue;
            rdbtnlstDataSourceBrands();
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

        public class InfoPerProd
        {
            public string ProdName { get; set; }
            public string ProdManufact { get; set; }
            public string ProdDesc { get; set; }
            public string ProdFinPrice { get; set; }
            public string ProdAvailDesc { get; set; }
            public string ProdImgURl { get; set; }
        }
        //private void BindItemsInCart(List<InfoPerProd> ListOfSelectedProducts)
        //{
        //    // The the LIST as the DataSource
        //    this.rptrProdInfo.DataSource = ListOfSelectedProducts;

        //    // Then bind the repeater
        //    // The public properties become the columns of your repeater
        //    this.rptrProdInfo.DataBind();
        //}
        public void ViewAllInfo()
        {
            List<InfoPerProd> DataItems = new List<InfoPerProd>();
            var CD = new InfoPerProd();
            
            string name = "", manufact = "", desc = "", finalprice = "", availdesc = "", imageurl = "";
            List<string> EDPs;
            EDPs = SearchedEDP.EDPSearching(q, rows);
            for (int i = 0; i < EDPs.Count; i++)
            {
                ProdInfo.ShowDetails(EDPs[i], name, manufact, desc, finalprice, availdesc, imageurl);
                CD.ProdName = name;
                CD.ProdManufact = manufact;
                CD.ProdDesc = desc;
                CD.ProdFinPrice = finalprice;
                CD.ProdAvailDesc = availdesc;
                CD.ProdImgURl = imageurl;
                DataItems.Add(CD);
                //Response.Write(name + manufact + desc + finalprice + availdesc + imageurl);
            }

            rptrProdInfo.DataSource = DataItems;
            rptrProdInfo.DataBind();
            //Information = Detailed.ShowDetails(EDPs);
            //plchldr_Prod.Controls.Add(new LiteralControl(Information));
        }
    }
}