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
        string q = "", rows = "5", EDPinString = "";
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
                rdbtnlstDataSourceBrands();
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
            EDPinString = SearchedEDP.EDPinString(q, rows);
            Brands = DSManufacturer.EDPListByManufact(EDPinString);
            rdbtnlst_Brand.Items.Clear();
            for (int i = 0; i < Brands.Count; i++)
            {
                rdbtnlst_Brand.Items.Add(new ListItem(Brands[i]));
            }
        }

        protected void lstvw_Prodinfo_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            //dtdpgr_ProdInfo.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            //ViewAllInfo();
        }

        protected void lstvw_Prodinfo_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Label lbl_StockDesc;
            LinkButton lnkbtn_AddToCart;
            
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                System.Data.DataRowView rowView = e.Item.DataItem as System.Data.DataRowView;
                lbl_StockDesc = (Label)e.Item.FindControl("lbl_StockDesc");
                lnkbtn_AddToCart = (LinkButton)e.Item.FindControl("lnkbtn_AddToCart");

                if (lbl_StockDesc.Text == "In stock. Usually ships next business day.")
                {
                    lbl_StockDesc.ForeColor = ColorTranslator.FromHtml("#009900");
                }
                if (lbl_StockDesc.Text == "Sold Out")
                {
                    lbl_StockDesc.ForeColor = Color.Red;
                }
                if (lbl_StockDesc.Text == "Temporarily out of stock. Order today and we'll deliver when available.")
                {
                    lbl_StockDesc.ForeColor = Color.OrangeRed;
                }
            }
        }

        public void ViewAllInfo()
        {
            EDPinString = SearchedEDP.EDPinString(q, rows);
            DataTable dt_Info = new DataTable();
            dt_Info = ProdInfo.ShowInfo(EDPinString);
            lstvw_Prodinfo.DataSource = dt_Info;
            lstvw_Prodinfo.DataBind();
        }
    }
}