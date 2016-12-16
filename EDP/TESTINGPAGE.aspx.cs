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
        string Q = "laptop", ROWS = "5";
        protected void Page_Load(object sender, EventArgs e)
        {
            string EDP = SearchedEDP.EDPinString(Q, ROWS);
            Response.Write(EDP);
        }
    }
}