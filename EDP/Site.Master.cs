using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { txt_Search.Text = Request.QueryString["q"]; }
        }

        protected void lnbtn_Search_Click(object sender, EventArgs e)
        {
            string q = txt_Search.Text.Trim();
            Response.Redirect("s.aspx?q=" + q);
        }
    }
}