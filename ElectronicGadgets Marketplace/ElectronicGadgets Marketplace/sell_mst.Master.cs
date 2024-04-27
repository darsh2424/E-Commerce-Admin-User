using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectronicGadgets_Marketplace
{
    public partial class sell_mst : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sel_name"] != null)
            {
                //profile_btn.Value = Session["user_name"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
                //Session["sel_id"] = "1";
                //Session["sel_name"] = "gada_elctronics";
            }
        }
    }
}