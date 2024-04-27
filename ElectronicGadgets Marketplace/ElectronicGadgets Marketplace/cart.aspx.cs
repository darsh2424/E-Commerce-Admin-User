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
    public partial class cart : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\tybca11\project\ElectronicGadgets Marketplace\ElectronicGadgets Marketplace\App_Data\elctrogadget.mdf;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30;User Instance=True");
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                if (Session["user_name"] == null)
                {
                    Session["user_name"] = "darsh_11";
                    //Response.Redirect("login.aspx");
                }

                dtl_panel.Visible = false;
                dtl_panel.Enabled = false;

                disp_cart();
            }
        }
        public void disp_req()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int cnt = 0;
            DataTable cart_tbl = new DataTable("cart_tbl");
            DataColumn dtColumn;

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "o_id";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "p_name";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "p_cat_name";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "p_brand_name";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "sel_name";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "sel_contact";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "sel_email";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "sel_address";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "o_quan";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "o_price";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "o_date";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "o_status";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "p_id";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);


            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "sel_id";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            SqlCommand user_id_cmd = new SqlCommand("select u_id from tbl_user where u_name='" + Session["user_name"] + "'", con);
            String user_id = user_id_cmd.ExecuteScalar().ToString();

            SqlCommand cmd = new SqlCommand("select p_name,p_cat_name,p_brand_name,sel_name,sel_contact,sel_email,sel_address,sel_city,sel_state,o_quan,o_p_id,o_sel_id,o_id,o_price,o_date,o_status from tbl_prod,tbl_sel,tbl_order,tbl_user where tbl_prod.p_id=tbl_order.o_p_id and tbl_order.o_sel_id=tbl_sel.sel_id and tbl_order.o_user_id=tbl_user.u_id and o_user_id='" + user_id + "' and o_status='0'", con);
            SqlDataReader drd = cmd.ExecuteReader();
            while (drd.Read())
            {
                cnt++;
                DataRow dtRow;
                dtRow = cart_tbl.NewRow();
                dtRow["o_id"] = drd.GetValue(12).ToString();
                dtRow["p_name"] = drd.GetValue(0).ToString();
                dtRow["p_cat_name"] = drd.GetValue(1).ToString();
                dtRow["p_brand_name"] = drd.GetValue(2).ToString();
                dtRow["sel_name"] = drd.GetValue(3).ToString();
                dtRow["sel_contact"] = drd.GetValue(4).ToString();
                dtRow["sel_email"] = drd.GetValue(5).ToString();
                dtRow["sel_address"] = drd.GetValue(6).ToString() + "<br>" + drd.GetValue(7).ToString() + "<br>" + drd.GetValue(8).ToString();
                dtRow["o_quan"] = drd.GetValue(9).ToString();
                dtRow["p_id"] = drd.GetValue(10).ToString();
                dtRow["sel_id"] = drd.GetValue(11).ToString();
                dtRow["o_price"] = drd.GetValue(13).ToString();
                dtRow["o_date"] = drd.GetDateTime(14).ToString("yyyy-MM-dd");
                if (drd.GetValue(15).ToString() == "0")
                {
                    dtRow["o_status"] = "Requested!";
                }


                cart_tbl.Rows.Add(dtRow);
            }

            if (cnt > 0)
            {
                req_repeat.DataSource = cart_tbl;
                req_repeat.DataBind();
            }
            else
            {
                req_tbl_panel.Visible = false;
            }
            con.Close();
                
        }
        public void disp_cart()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int cnt = 0;
            DataTable cart_tbl = new DataTable("cart_tbl");
            DataColumn dtColumn;

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "cart_id";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "p_name";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "p_cat_name";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "p_brand_name";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "sel_name";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "sel_contact";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "sel_email";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "sel_address";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "p_quan";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "cart_quan";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "p_id";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);


            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "sel_id";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            SqlCommand user_id_cmd = new SqlCommand("select u_id from tbl_user where u_name='"+Session["user_name"]+"'",con);
            String user_id = user_id_cmd.ExecuteScalar().ToString();

            SqlCommand cmd = new SqlCommand("select p_name,p_cat_name,p_brand_name,sel_name,sel_contact,sel_email,sel_address,sel_city,sel_state,p_quan,cart_quan,cart_p_id,cart_p_sel_id,cart_id from tbl_prod,tbl_sel,tbl_cart,tbl_user where tbl_prod.p_id=tbl_cart.cart_p_id and tbl_cart.cart_p_sel_id=tbl_sel.sel_id and tbl_cart.cart_user_id=tbl_user.u_id and cart_user_id='" + user_id + "'", con);
            SqlDataReader drd = cmd.ExecuteReader();
            while (drd.Read())
            {
                cnt++;
                DataRow dtRow;
                dtRow = cart_tbl.NewRow();
                dtRow["cart_id"] = drd.GetValue(13).ToString();
                dtRow["p_name"] = drd.GetValue(0).ToString();
                dtRow["p_cat_name"] = drd.GetValue(1).ToString();
                dtRow["p_brand_name"] = drd.GetValue(2).ToString();
                dtRow["sel_name"] = drd.GetValue(3).ToString();
                dtRow["sel_contact"] = drd.GetValue(4).ToString();
                dtRow["sel_email"] = drd.GetValue(5).ToString();
                dtRow["sel_address"] = drd.GetValue(6).ToString() + "<br>" + drd.GetValue(7).ToString() + "<br>" + drd.GetValue(8).ToString();
                dtRow["p_quan"] = drd.GetValue(9).ToString();
                dtRow["cart_quan"] = drd.GetValue(10).ToString();
                dtRow["p_id"]=drd.GetValue(11).ToString();
                dtRow["sel_id"] = drd.GetValue(12).ToString();

                cart_tbl.Rows.Add(dtRow);
            }

            if (cnt > 0)
            {
                cart_repeat.DataSource = cart_tbl;
                cart_repeat.DataBind();
            }
            else
            {
                cart_tbl_panel.Visible = false;
            }
            con.Close();
        }
        public void disp_pur()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int cnt = 0;
            DataTable cart_tbl = new DataTable("cart_tbl");
            DataColumn dtColumn;

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "o_id";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "p_name";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "p_cat_name";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "p_brand_name";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "sel_name";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "sel_contact";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "sel_email";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "sel_address";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "o_quan";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "o_price";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "o_date";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "o_sub_date";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "p_id";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);


            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "sel_id";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            SqlCommand user_id_cmd = new SqlCommand("select u_id from tbl_user where u_name='" + Session["user_name"] + "'", con);
            String user_id = user_id_cmd.ExecuteScalar().ToString();

            SqlCommand cmd = new SqlCommand("select p_name,p_cat_name,p_brand_name,sel_name,sel_contact,sel_email,sel_address,sel_city,sel_state,o_quan,o_p_id,o_sel_id,o_id,o_price,o_date,o_sub_date from tbl_prod,tbl_sel,tbl_order,tbl_user where tbl_prod.p_id=tbl_order.o_p_id and tbl_order.o_sel_id=tbl_sel.sel_id and tbl_order.o_user_id=tbl_user.u_id and o_user_id='" + user_id + "' and o_status='1' and o_sub_date!=null", con);
            SqlDataReader drd = cmd.ExecuteReader();
            while (drd.Read())
            {
                cnt++;
                DataRow dtRow;
                dtRow = cart_tbl.NewRow();
                dtRow["o_id"] = drd.GetValue(12).ToString();
                dtRow["p_name"] = drd.GetValue(0).ToString();
                dtRow["p_cat_name"] = drd.GetValue(1).ToString();
                dtRow["p_brand_name"] = drd.GetValue(2).ToString();
                dtRow["sel_name"] = drd.GetValue(3).ToString();
                dtRow["sel_contact"] = drd.GetValue(4).ToString();
                dtRow["sel_email"] = drd.GetValue(5).ToString();
                dtRow["sel_address"] = drd.GetValue(6).ToString() + "<br>" + drd.GetValue(7).ToString() + "<br>" + drd.GetValue(8).ToString();
                dtRow["o_quan"] = drd.GetValue(9).ToString();
                dtRow["p_id"] = drd.GetValue(10).ToString();
                dtRow["sel_id"] = drd.GetValue(11).ToString();
                dtRow["o_price"] = drd.GetValue(13).ToString();
                dtRow["o_date"] = drd.GetDateTime(14).ToString("yyyy-MM-dd");
                dtRow["o_sub_date"] = drd.GetDateTime(15).ToString("yyyy-MM-dd");


                cart_tbl.Rows.Add(dtRow);
            }

            if (cnt > 0)
            {
                pur_repeat.DataSource = cart_tbl;
                pur_repeat.DataBind();
            }
            else
            {
                pur_tbl_panel.Visible = false;
            }
            con.Close();

        }
        protected void cart_btn_Click(object sender, EventArgs e)
        {
            cart_panel.Enabled = true;
            cart_panel.Visible = true;

            req_panel.Visible = false;

            dtl_panel.Visible = false;
            dtl_panel.Enabled = false;
        }

        protected void user_dtl_btn_Click(object sender, EventArgs e)
        {
            cart_panel.Enabled = false;
            cart_panel.Visible = false;

            req_panel.Visible = false;

            dtl_panel.Visible = true;
            dtl_panel.Enabled = true;

            disp_pur();
        }

        protected void cart_repeat_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                var quan = (Label)e.Item.FindControl("lbl_quan");
                var lbl = (Label)e.Item.FindControl("lbl_err");
                var btn = (Button)e.Item.FindControl("pur_btn");

                if (Convert.ToInt32(quan.Text) > 0)
                {
                    lbl.Visible = false;
                }
                else
                {
                    btn.Enabled = false;
                    btn.Visible = false;
                }
            }
        }

        protected void cart_repeat_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "purchase")
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                String cart_id = e.CommandArgument.ToString();
                SqlCommand user_id_cmd = new SqlCommand("select u_id from tbl_user where u_name='" + Session["user_name"] + "'", con);
                String user_id = user_id_cmd.ExecuteScalar().ToString();
                String p_id = "";
                String sel_id = "";
                String p_quan = "";
                String p_price = "";
                String o_date = DateTime.Now.ToString("yyyy-MM-dd");
                String o_status = "0";
                SqlCommand cmd = new SqlCommand("select cart_p_id,cart_p_sel_id,cart_quan,p_price from tbl_prod,tbl_sel,tbl_cart,tbl_user where tbl_prod.p_id=tbl_cart.cart_p_id and tbl_cart.cart_p_sel_id=tbl_sel.sel_id and tbl_cart.cart_user_id=tbl_user.u_id and cart_user_id='" + user_id + "'", con);
                SqlDataReader drd = cmd.ExecuteReader();
                
                while (drd.Read())
                {
                    p_id = drd.GetValue(0).ToString();
                    sel_id = drd.GetValue(1).ToString();
                    p_quan = drd.GetValue(2).ToString();
                    p_price = drd.GetValue(3).ToString();
                }
                //home_btn.Text = p_id + sel_id + p_quan + p_price+o_date;
                //String pid = args.Substring(0, args.IndexOf(","));
                //String sel_id = args.Substring(args.IndexOf(",")+1);

                String o_id="";
                    SqlCommand cmd_count = new SqlCommand("select count(*) from tbl_order", con);
                    if (Convert.ToInt32(cmd_count.ExecuteScalar()) > 0)
                    {
                        SqlCommand cmd_id = new SqlCommand("select max(o_id) from tbl_order", con);
                        o_id = (Convert.ToInt64(cmd_id.ExecuteScalar()) + 1).ToString();
                    }
                    else
                    {
                        o_id = "1";
                    }

                    try
                    {
                        SqlCommand insert_cmd = new SqlCommand("insert into tbl_order values('" + o_id + "','" + p_id + "','" + sel_id + "','" + user_id + "','" + p_quan + "','" + p_price + "','2024-03-21',null,'" + o_status + "')", con);
                        insert_cmd.ExecuteNonQuery();

                        SqlCommand del_cmd = new SqlCommand("delete from tbl_cart where cart_id='" + cart_id + "'", con);
                        del_cmd.ExecuteNonQuery();

                        lbl_success.Text = "Order Submitted!";
                        lbl_success.Style.Add("display", "block");
                        Response.Write("<script>setTimeout(function(){document.getElementsByClassName('label')[0].style.display='none';},3000);</script>");
                        disp_cart();
                    }
                    catch (Exception ex)
                    {
                        lbl_success.Text = "Error!";
                        lbl_success.Style.Add("display", "block");
                        Response.Write("<script>setTimeout(function(){document.getElementsByClassName('label')[0].style.display='none';},3000);</script>");
                        
                    }
                

               //SqlCommand upd_cmd = new SqlCommand(,con);

                con.Close();
            }
            if (e.CommandName == "del")
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                String cart_id = e.CommandArgument.ToString();
                SqlCommand del_cmd = new SqlCommand("delete from tbl_cart where cart_id='" + cart_id + "'", con);
                del_cmd.ExecuteNonQuery();

                lbl_success.Text = "Product Removed!";
                lbl_success.Style.Add("display", "block");
                Response.Write("<script>setTimeout(function(){document.getElementsByClassName('label')[0].style.display='none';},3000);</script>");
                Response.Redirect(Request.RawUrl);

            }
        }

        protected void drop_sort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drop_sort.SelectedIndex > 0)
            {
                if (drop_sort.SelectedIndex == 1)
                {
                    cart_panel.Visible = true;
                    req_panel.Visible = false;
                    dtl_panel.Visible=false;

                    disp_cart();
                }
                else if (drop_sort.SelectedIndex == 2)
                {
                    cart_panel.Visible = false;
                    req_panel.Visible = true;
                    dtl_panel.Visible = false;

                    disp_req();
                }
            }
        }

        protected void req_repeat_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "cancel")
            {
                String o_id = e.CommandArgument.ToString();
                try
                {

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand del_cmd = new SqlCommand("delete from tbl_order where o_id='" + o_id + "'", con);
                    del_cmd.ExecuteNonQuery();
                    con.Close();
                    lbl_success.Text = "Order Request Cancelled!";
                    lbl_success.Style.Add("display", "block");
                    Response.Write("<script>setTimeout(function(){document.getElementsByClassName('label')[0].style.display='none';},3000);</script>");
                    Response.Redirect(Request.RawUrl);
                }
                catch (Exception ex)
                {
                    lbl_success.Text = "Error!";
                    lbl_success.Style.Add("display", "block");
                    Response.Write("<script>setTimeout(function(){document.getElementsByClassName('label')[0].style.display='none';},3000);</script>");

                }
            }
        }

    }
}