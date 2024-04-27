using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services; 
using System.Data;
using System.Data.SqlClient;
namespace ElectronicGadgets_Marketplace
{
    public partial class register : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\tybca11\project\ElectronicGadgets Marketplace\ElectronicGadgets Marketplace\App_Data\elctrogadget.mdf;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30;User Instance=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            seller_panel.Visible = false;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            user_panel.Visible = true;
            seller_panel.Visible = false;
            ScriptManager.RegisterClientScriptBlock(this, typeof(string), "uniqueKey","load_user();", true);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            user_panel.Visible = false;
            seller_panel.Visible = true;
            ScriptManager.RegisterClientScriptBlock(this, typeof(string), "uniqueKey","load_sel();", true);

        }

        protected void user_sub_btn_Click(object sender, EventArgs e)
        {
            String user_id;
            String txt_name = txt_user_name.Value;
            String txt_email = txt_user_email.Value;
            String txt_con = txt_user_con.Value;
            String txt_pass = txt_user_pass.Value;
            String txt_add1 = txt_user_add1.Value;
            String txt_add2 = txt_user_add2.Value;
            String txt_city = txt_user_city.Value;
            String txt_pin = txt_user_pin.Value;
            String txt_state = txt_user_state.Value;

            if (txt_name != "" && txt_email != "" && txt_con != "" && txt_pass != "" && txt_add1 != "" && txt_add2 != "" && txt_city != "" && txt_pin != "" && txt_state != "")
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("select * from tbl_user where u_name='" + txt_name + "'", con);
                SqlDataReader drd = cmd.ExecuteReader();
                if (drd.HasRows)
                {
                    username_err.Text = "*Name Already Exist!";
                }
                else
                {
                    drd.Close();
                    username_err.Text = "";
                    SqlCommand cmd_count = new SqlCommand("select count(*) from tbl_user", con);
                    if (Convert.ToInt32(cmd_count.ExecuteScalar()) > 0)
                    {
                        SqlCommand cmd_id = new SqlCommand("select max(u_id) from tbl_user", con);
                        user_id = (Convert.ToInt64(cmd_id.ExecuteScalar()) + 1).ToString();
                    }
                    else
                    {
                        user_id = "1";
                    }
                    SqlCommand data_cmd = new SqlCommand("insert into tbl_user values('" + user_id + "','" + txt_name + "','" + txt_email + "','" + txt_con + "','" + txt_pass + "','" + txt_add1 + "','" + txt_add2 + "','" + txt_city + "','" + txt_pin + "','" + txt_state + "');", con);
                    data_cmd.ExecuteNonQuery();
                    Session["user_name"] = txt_name;
                    Response.Redirect("~/user_home.aspx");
                }


                con.Close();
            }
            else
            {
                Response.Write("<script>alert('Fill All Details!');</script>");
            }
        }

        protected void sel_sub_btn_Click(object sender, EventArgs e)
        {
            String sel_id;
            String txt_name = txt_sel_name.Value;
            String txt_email = txt_sel_email.Value;
            String txt_con = txt_sel_con.Value;
            String txt_pass = txt_sel_pass.Value;
            String txt_add1 = txt_sel_add1.Value;
            String shop_img = txt_sel_pic.PostedFile.FileName.ToString();
            String txt_city = txt_sel_city.Value;
            String txt_pin = txt_sel_pin.Value;
            String txt_state = txt_sel_state.Value;

            
            if (txt_name != "" && txt_email != "" && txt_con != "" && txt_pass != "" && txt_add1 != "" && shop_img != "" && txt_city != "" && txt_pin != "" && txt_state != "")
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from tbl_sel where sel_name='" + txt_name + "'", con);
                    SqlDataReader drd = cmd.ExecuteReader();
                    if (drd.HasRows)
                    {
                        selname_err.Text = "*Name Already Exist!";
                        seller_panel.Visible = true;
                        user_panel.Visible = false;
                        ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "load_sel();",true);
                    }
                    else
                    {
                        
                        drd.Close();
                        selname_err.Text = "";
                        SqlCommand cmd_count = new SqlCommand("select count(*) from tbl_sel", con);
                        if (Convert.ToInt32(cmd_count.ExecuteScalar())>0)
                        {
                            SqlCommand cmd_id = new SqlCommand("select max(sel_id) from tbl_sel", con);
                            sel_id = (Convert.ToInt64(cmd_id.ExecuteScalar()) + 1).ToString();
                        }
                        else
                        {
                            sel_id = "1";
                        }
                        String folderpath = Server.MapPath("~/img/shop_img/");
                        String file_Ext = shop_img.Substring(shop_img.IndexOf("."));
                        String filename = txt_name + file_Ext;
                        txt_sel_pic.SaveAs(folderpath + filename);
                        SqlCommand data_cmd = new SqlCommand("insert into tbl_sel values('" + sel_id + "','" + txt_name + "','" + txt_con + "','" + txt_email + "','" + txt_pass + "','" + txt_add1 + "','" + txt_city + "','" + txt_pin + "','" + txt_state + "','" + filename + "');", con);
                        data_cmd.ExecuteNonQuery();
                        Session["sel_id"] = sel_id;
                        Session["sel_name"] = txt_name;
                        Response.Redirect("~/sell_home.aspx");
                    }
                }
                catch (Exception except)
                {
                    Response.Write("<script>alert('Error!');</script>");
                    seller_panel.Visible = true;
                    user_panel.Visible = false;
                    ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "load_sel();", true);
                }

                con.Close();
            }
            else
            {
                Response.Write("<script>alert('Fill All Details!');</script>");
                seller_panel.Visible = true;
                user_panel.Visible = false;
                ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "load_sel();", true);
            }
        }
    }



}
