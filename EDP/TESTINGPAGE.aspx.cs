using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP
{
    public partial class TESTINGPAGE : System.Web.UI.Page
    {
        SearchedEDP SearchedEDP = new SearchedEDP();
        DSManufacturer DSManufacturer = new DSManufacturer();

        string Q = "laptop", ROWS = "200";
        protected void Page_Load(object sender, EventArgs e)
        {
            string EDP = SearchedEDP.EDPinString(Q, ROWS);
            List<string> Brands = new List<string>();
            Brands = DSManufacturer.EDPListByManufact(EDP);
            string EDPString = string.Join("<br>", Brands);
            Response.Write(EDP +"<br>" + EDPString);
        }
    }
}