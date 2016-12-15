using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
        List<string> EDPs;

        SearchedEDP SearchedEDP = new SearchedEDP();
        DSManufacturer DSManufacturer = new DSManufacturer();
        ProdInfo ProdInfo = new ProdInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            q = Request.QueryString["q"];
            if (!IsPostBack)
            {
                ViewAllInfo();
            }
            rdbtnlstDataSourceBrandsPageLoad();
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

        protected void lstvw_Prodinfo_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Label lbl_StockDes;
            LinkButton lnkbtn_AddToCart;
            //if (e.Item.ItemType == ListViewItemType.DataItem)
            //{
            //    lbl_StockDes = (Label)e.Item.FindControl("lbl_StockDes");
            //    lnkbtn_AddToCart = (LinkButton)e.Item.FindControl("lnkbtn_AddToCart");

            //    if (lbl_StockDes.Text == "Temporarily out of stock. Order today and we'll deliver when available")
            //    {
            //        lbl_StockDes.ForeColor = Color.Red;
            //        lnkbtn_AddToCart.Text = "Pre-Order Now";
            //    }

            //}
        }

        public void ViewAllInfo()
        {
            if (IsPostBack)
            {
                EDPs = SearchedEDP.EDPSearching(q, rows);
                DataTable dt_Info = new DataTable();
                dt_Info = ProdInfo.ShowDetails(EDPs);
                lstvw_Prodinfo.DataSource =dt_Info;
                lstvw_Prodinfo.DataBind();
            }
        }
        

    }
}