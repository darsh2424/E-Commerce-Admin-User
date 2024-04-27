using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace ElectronicGadgets_Marketplace
{
    public partial class order : System.Web.UI.Page
    {
        String load_pid;
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\tybca11\project\ElectronicGadgets Marketplace\ElectronicGadgets Marketplace\App_Data\elctrogadget.mdf;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30;User Instance=True");
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_name"] != null)
            {
                cart_link.Text = Session["user_name"].ToString();
                cart_link.Style.Add("display", "block");
                login_btn.Style.Add("display", "none");

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                String user_id = "";
                String p_id = Request.Params["p_id"];
                SqlCommand cmd = new SqlCommand("select u_id from tbl_user where u_name='" + Session["user_name"] + "'", con);
                user_id = cmd.ExecuteScalar().ToString();

                SqlCommand cart_check = new SqlCommand("select count(*) from tbl_cart where cart_p_id='"+p_id+"' and cart_user_id='"+user_id+"'",con);
                if (Convert.ToInt32(cart_check.ExecuteScalar()) > 0)
                {
                    add_btn.Text = "Alrady In Cart";
                    add_btn.Enabled = false;
                }

                SqlCommand sel = new SqlCommand("select count(*) from tbl_rate where rate_u_id='" + user_id + "' and rate_p_id='" + p_id + "'", con);
                    if (Convert.ToInt32(sel.ExecuteScalar()) > 0)
                    {
                        add_panel.Visible=false;
                    }
                    else
                    {
                        add_panel.Visible=true;
                    }

                con.Close();
            }

            if (Request.Params["p_id"] == null)
            {
                //Response.Redirect("~/order.aspx?p_id=1");
                Response.Redirect("~/user_home.aspx");
            }
            else
            {
                disp_cat();
                load_pid = Request.Params["p_id"];
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from tbl_prod where p_id='"+load_pid+"'",con);
                SqlDataReader drd = cmd.ExecuteReader();
                while (drd.Read())
                {
                    txt_pname.Value = drd.GetValue(2).ToString();
                    txt_pdec.Text = drd.GetValue(3).ToString();
                    txt_cat.Value = drd.GetValue(4).ToString();
                    txt_brand.Value = drd.GetValue(5).ToString();
                    txt_price.Value = drd.GetValue(6).ToString();
                    txt_quan.Value = drd.GetValue(7).ToString();
                    Image1.ImageUrl = "img/prod_img/"+drd.GetValue(8).ToString();

                    SqlCommand sel_cmd = new SqlCommand("select * from tbl_sel where sel_id='" + drd.GetValue(1).ToString() + "'", con);
                    SqlDataReader sel_drd = sel_cmd.ExecuteReader();
                    while (sel_drd.Read())
                    {
                        txt_sel_name.Value = sel_drd.GetValue(1).ToString();
                        txt_sel_con.Text = sel_drd.GetValue(2).ToString();
                        txt_sel_address.Text = sel_drd.GetValue(5).ToString() + Environment.NewLine + sel_drd.GetValue(6).ToString() + "," + sel_drd.GetValue(7).ToString();
                        txt_sel_state.Value = sel_drd.GetValue(8).ToString();
                    }
                }

                Double cnt = 0;
                Double stars = 0;
                SqlCommand data_cmd = new SqlCommand("select count(*) from tbl_rate where rate_p_id='" + load_pid + "'", con);
                if (Convert.ToInt32(data_cmd.ExecuteScalar()) > 0)
                {

                    //SqlCommand cmd;
                    //if (rate_value == "")
                    //{
                    //check_str.Text = "select count(*),sum(rate_star)/count(*) from tbl_rate where rate_p_id='" + drd.GetValue(0) + "' group by rate_p_id";
                    cmd = new SqlCommand("select count(*) as Total_Reviews,sum(rate_star)/count(*) as Stars from tbl_rate where rate_p_id='" + load_pid + "' group by rate_p_id", con);
                    //}
                    //else
                    //{
                    //    //check_str.Text = "select count(*),sum(rate_star)/count(*) from tbl_rate where rate_p_id='" + drd.GetValue(0) + "' group by rate_p_id " + rate_value + "";
                    //    cmd = new SqlCommand("select count(*) as Total_Reviews,sum(rate_star)/count(*) as Stars from tbl_rate where rate_p_id='" + drd.GetValue(0) + "' group by rate_p_id " + rate_value + "", con);

                    //}
                    SqlDataReader rate_drd = cmd.ExecuteReader();
                    while (rate_drd.Read())
                    {
                        cnt = Convert.ToDouble(rate_drd.GetValue(0));
                        stars = Convert.ToDouble(rate_drd.GetValue(1));
                        //cnt++;
                        //stars += Convert.ToDouble(rate_drd.GetValue(0));
                    }
                    //stars = stars / cnt;
                }
                if (cnt > 0)
                {
                    lbl_total.Text = stars + "&#x2605;(" + cnt + ")";
                }
                else
                {
                    lbl_total.Text = "No Reviews";
                }
                
            }
        }
        protected void cat_repeat_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                var cat_name = (HiddenField)e.Item.FindControl("cat_name_hide");
                //CheckBoxList chk = (CheckBoxList)e.Item.FindControl("brand_check_list");
                Repeater inner = (Repeater)e.Item.FindControl("brand_repeat");
                SqlCommand cmd = new SqlCommand("select p_brand_name,count(*) as total from tbl_prod where p_cat_name='" + cat_name.Value + "' group by p_brand_name  HAVING COUNT(*) > 0 ", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable filter_table = new DataTable("filter_table");
                da.Fill(filter_table);
                //chk.DataSource = filter_table;
                //chk.DataTextField = "p_brand_name";
                //chk.DataValueField = "p_brand_name";
                //chk.DataBind();
                inner.DataSource = cmd.ExecuteReader();
                inner.DataBind();
                con.Close();
            }
        }
        public void disp_cat()
        {
            DataTable cat_table = new DataTable("cat_table");
            SqlCommand cmd = new SqlCommand("select p_cat_name,count(*) as total from tbl_prod group by p_cat_name  HAVING COUNT(*) > 0 ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(cat_table);
            cat_repeat.DataSource = cat_table;
            cat_repeat.DataBind();
        }

        protected void add_btn_Click(object sender, EventArgs e)
        {
            if(Session["user_name"]==null)
            {
                Response.Redirect("~/login.aspx");
            }
            else
            {
                String cart_id = "";
                String user_id = "";
                String p_id = Request.Params["p_id"];
                String sel_id = "";
                SqlCommand cmd = new SqlCommand("select u_id from tbl_user where u_name='" + Session["user_name"] + "'", con);
                user_id = cmd.ExecuteScalar().ToString();
                cmd = new SqlCommand("select p_sel_id from tbl_prod where p_id='" + p_id + "'", con);
                sel_id = cmd.ExecuteScalar().ToString();

                SqlCommand match_cmd = new SqlCommand("select count(*) from tbl_cart where cart_p_id='"+Request.Params["p_id"].ToString()+"' and cart_user_id='"+user_id+"' and cart_p_sel_id='"+sel_id+"'", con);
                if (Convert.ToInt32(match_cmd.ExecuteScalar()) == 0)
                {
                    if (Convert.ToInt32(txt_quan.Value) < Convert.ToInt32(txt_ask_quan.Text))
                    {
                        lbl_err.Text = "Check Quantity";
                    }
                    else
                    {

                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        SqlCommand cmd_count = new SqlCommand("select count(*) from tbl_cart", con);
                        if (Convert.ToInt32(cmd_count.ExecuteScalar()) > 0)
                        {
                            SqlCommand cmd_id = new SqlCommand("select max(cart_id) from tbl_cart", con);
                            cart_id = (Convert.ToInt64(cmd_id.ExecuteScalar()) + 1).ToString();
                        }
                        else
                        {
                            cart_id = "1";
                        }
                        cmd = new SqlCommand("insert into tbl_cart values('" + cart_id + "','" + user_id + "','" + p_id + "','"+sel_id+"','" + txt_ask_quan.Text + "')", con);
                        cmd.ExecuteNonQuery();
                        Response.Redirect(Request.RawUrl);
                        con.Close();
                        lbl_err.Text = "";
                    }
                }
                else
                {
                    lbl_err.Text = "*Already In Cart!";
                }
                
            }
            
        }

        protected void seach_btn_Click(object sender, EventArgs e)
        {
            if (txt_search.Text.Trim() != "")
            {
                Response.Redirect("user_home.aspx?search=" + txt_search.Text);
            }
            
        }

        protected void add_rate_btn_Click(object sender, EventArgs e)
        {

            if (Session["user_name"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            else
            {
                String rate_id = "";
                String user_id = "";
                String p_id = Request.Params["p_id"];
                SqlCommand cmd = new SqlCommand("select u_id from tbl_user where u_name='" + Session["user_name"] + "'", con);
                user_id = cmd.ExecuteScalar().ToString();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd_count = new SqlCommand("select count(*) from tbl_rate", con);
                if (Convert.ToInt32(cmd_count.ExecuteScalar()) > 0)
                {
                    SqlCommand cmd_id = new SqlCommand("select max(rate_id) from tbl_rate", con);
                    rate_id = (Convert.ToInt64(cmd_id.ExecuteScalar()) + 1).ToString();
                }
                else
                {
                    rate_id = "1";
                }
                SqlCommand sel = new SqlCommand("select count(*) from tbl_rate where rate_u_id='" + user_id + "' and rate_p_id='" + p_id + "'", con);
               if (Convert.ToInt32(sel.ExecuteScalar()) > 0)
               {

               }
               else
               {
                   cmd = new SqlCommand("insert into tbl_rate values('" + rate_id + "','" + user_id + "','" + p_id + "','" +rate_txt.Value + "')", con);
                   cmd.ExecuteNonQuery();
               }
               Response.Redirect(Request.RawUrl);
                con.Close();
                lbl_err.Text = "";
            }
        }

       

    }
}