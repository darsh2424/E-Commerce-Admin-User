using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ElectronicGadgets_Marketplace
{
    public partial class login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\tybca11\project\ElectronicGadgets Marketplace\ElectronicGadgets Marketplace\App_Data\elctrogadget.mdf;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30;User Instance=True"); 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sel_sub_Click(object sender, EventArgs e)
        {
            String username = txt_sel_name.Value;
            String pass = txt_sel_pass.Value;
            if (username == "" && pass == "")
            {
               lbl_sel_err.Text = "*Fill All Details!";
            }
            else
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("select count(*) from tbl_sel where sel_name='" + username + "' and sel_pass='" + pass + "'", con);
                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                {
                    cmd = new SqlCommand("select sel_id from tbl_sel where sel_name='" + username + "' and sel_pass='" + pass + "'", con);
                    Session["sel_id"] = cmd.ExecuteScalar().ToString();
                    Session["sel_name"] = username;
                    Response.Redirect("~/sell_home.aspx");
                }
                else
                {
                    lbl_sel_err.Text = "*Invalid Username or Password!";
                }
                con.Close();
              }
            ven_tbl.Style.Add("display","inline");
            ven_div.Style.Add("display", "none");
            user_div.Style.Add("display", "inline");
            user_tbl.Style.Add("display", "none");
        }
        protected void user_sub_Click(object sender, EventArgs e)
        {
            String username = txt_user_name.Value;
            String pass = txt_user_pass.Value;

            if (username == "" && pass == "")
            {
                lbl_user_err.Text = "*Fill All Details!";
            }
            else
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("select count(*) from tbl_user where u_name='" + username + "' and u_pass='" + pass + "'", con);
                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                {
                    Session["user_name"] = username;
                    Response.Redirect("~/user_home.aspx");
                }
                else
                {
                    lbl_user_err.Text = "*Invalid Username or Password!";
                }
                con.Close();
            }
            ven_tbl.Style.Add("display", "none");
            ven_div.Style.Add("display", "inline");
            user_div.Style.Add("display", "none");
            user_tbl.Style.Add("display", "inline");

        }
    }
}