using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        string q = "", EDPinString = "", NumFound = "", currentUrl = HttpContext.Current.Request.Url.AbsoluteUri;
        static int MinPage = 0, MaxPage = 0, NumPage = 0, rows = 5, start = 0;

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
                drpdwnlst_View.SelectedValue = Request.QueryString["rpp"];
                MinPage = rows * NumPage;
                MaxPage = rows + MinPage;
                MinPage = MinPage + 1;
                lbl_MaxPage.Text = MaxPage.ToString();
                lbl_MinPage.Text = MinPage.ToString();
            }
        }

        protected void lnkbtn_Nxt_Click(object sender, EventArgs e)
        {
            string[] separateURL = currentUrl.Split('?');
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(separateURL[1]);
            rows = Convert.ToInt32(drpdwnlst_View.SelectedValue); NumPage = NumPage + 1; start = NumPage * rows;
            MinPage = rows * NumPage; MaxPage = rows + MinPage; lbl_MaxPage.Text = MaxPage.ToString(); lbl_MinPage.Text = MinPage.ToString();
            queryString["q"] = q; queryString["rpp"] = rows.ToString(); queryString["page"] = NumPage.ToString();
            currentUrl = separateURL[0] + "?" + queryString.ToString(); Response.Redirect(currentUrl);
        }

        protected void lnkbtn_Prev_Click(object sender, EventArgs e)
        {
            string[] separateURL = currentUrl.Split('?');
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(separateURL[1]);
            rows = Convert.ToInt32(drpdwnlst_View.SelectedValue); NumPage = NumPage - 1; start = NumPage * rows;
            MinPage = rows * NumPage; MaxPage = rows + MinPage; lbl_MaxPage.Text = MaxPage.ToString(); lbl_MinPage.Text = MinPage.ToString();
            queryString["q"] = q; queryString["rpp"] = rows.ToString(); queryString["page"] = NumPage.ToString();
            currentUrl = separateURL[0] + "?" + queryString.ToString(); Response.Redirect(currentUrl);
        }

        protected void drpdwnlst_View_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] separateURL = currentUrl.Split('?');
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(separateURL[1]);
            rows = Convert.ToInt32(drpdwnlst_View.SelectedValue);
            NumPage = 0; queryString["q"] = q; queryString["rpp"] = rows.ToString(); queryString.Remove("page");
            rdbtnlstDataSourceBrands(); currentUrl = separateURL[0] + "?" + queryString.ToString();
            Response.Redirect(currentUrl);
        }

        public void rdbtnlstDataSourceBrands()
        {
            List<string> Brands;
            EDPinString = SearchedEDP.EDPinStringForMan(q, rows);
            Brands = DSManufacturer.EDPListByManufact(EDPinString);
            rdbtnlst_Brand.Items.Clear();
            for (int i = 0; i < Brands.Count; i++)
            {
                rdbtnlst_Brand.Items.Add(new ListItem(Brands[i]));
            }
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
                { lbl_StockDesc.ForeColor = ColorTranslator.FromHtml("#009900"); }
                if (lbl_StockDesc.Text == "Sold Out")
                { lbl_StockDesc.ForeColor = Color.Red; }
                if (lbl_StockDesc.Text == "Temporarily out of stock. Order today and we'll deliver when available.")
                { lbl_StockDesc.ForeColor = Color.Orange; }
            }
        }

        public void ViewAllInfo()
        {
            EDPinString = SearchedEDP.EDPinString(q, rows, start);
            DataTable dt_Info = new DataTable();
            dt_Info = ProdInfo.ShowInfo(EDPinString);
            lstvw_Prodinfo.DataSource = dt_Info;
            lstvw_Prodinfo.DataBind();
        }
    }
}