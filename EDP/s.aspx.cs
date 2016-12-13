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
        protected void Page_Load(object sender, EventArgs e)
        {
            q = Request.QueryString["q"];
            rdbtnlstDataSourceBrandsPageLoad();
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
    }
}