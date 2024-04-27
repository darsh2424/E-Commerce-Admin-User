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
    public partial class sell_home : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\tybca11\project\ElectronicGadgets Marketplace\ElectronicGadgets Marketplace\App_Data\elctrogadget.mdf;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30;User Instance=True");
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sel_name"] != null)
            {
                //profile_btn.Value = Session["user_name"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }

            if (!IsPostBack)
            {
                order_panel.Visible = true;
                order_panel.Enabled = true;
                stock_panel.Enabled = false;
                stock_panel.Visible = false;
                sub.Visible = false;
                sub.Enabled = false;
                disp_req();
                
            }
            
            
        }

        public void disp_prod()
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
            dtColumn.ColumnName = "p_img";
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
            dtColumn.ColumnName = "p_quan";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "p_price";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "p_id";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);


            SqlCommand user_id_cmd = new SqlCommand("select sel_id from tbl_sel where sel_name='" + Session["sel_name"] + "'", con);
            String user_id = user_id_cmd.ExecuteScalar().ToString();

            SqlCommand cmd = new SqlCommand("select p_img,p_name,p_cat_name,p_brand_name,p_quan,p_price,p_id from tbl_prod where p_sel_id='" + user_id + "' order by p_quan", con);
            SqlDataReader drd = cmd.ExecuteReader();
            while (drd.Read())
            {
                cnt++;
                DataRow dtRow;
                dtRow = cart_tbl.NewRow();
                dtRow["p_img"] = drd.GetValue(0).ToString();
                dtRow["p_name"] = drd.GetValue(1).ToString();
                dtRow["p_cat_name"] = drd.GetValue(2).ToString();
                dtRow["p_brand_name"] = drd.GetValue(3).ToString();
                dtRow["p_quan"] = drd.GetValue(4).ToString();
                dtRow["p_price"] = drd.GetValue(5).ToString();
                dtRow["p_id"] = drd.GetValue(6).ToString();
                cart_tbl.Rows.Add(dtRow);
            }

            if (cnt > 0)
            {
                stock_repeat.DataSource = cart_tbl;
                stock_repeat.DataBind();
            }
            con.Close();
        }
        public void disp_sub()
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
            dtColumn.ColumnName = "user_name";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "user_contact";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "user_email";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "user_address";
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
            dtColumn.ColumnName = "user_id";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);


            SqlCommand user_id_cmd = new SqlCommand("select sel_id from tbl_sel where sel_name='" + Session["sel_name"] + "'", con);
            String user_id = user_id_cmd.ExecuteScalar().ToString();

            SqlCommand cmd = new SqlCommand("select p_name,p_cat_name,p_brand_name,u_name,u_contact,u_email,u_add1,u_add2,u_city,u_state,o_quan,o_p_id,o_sel_id,o_id,o_price,o_date,o_sub_date,u_pin from tbl_prod,tbl_sel,tbl_order,tbl_user where tbl_prod.p_id=tbl_order.o_p_id and tbl_order.o_sel_id=tbl_sel.sel_id and tbl_order.o_user_id=tbl_user.u_id and o_sel_id='" + user_id + "' and o_status='1'", con);
            SqlDataReader drd = cmd.ExecuteReader();
            while (drd.Read())
            {
                cnt++;
                DataRow dtRow;
                dtRow = cart_tbl.NewRow();
                dtRow["o_id"] = drd.GetValue(13).ToString();
                dtRow["p_name"] = drd.GetValue(0).ToString();
                dtRow["p_cat_name"] = drd.GetValue(1).ToString();
                dtRow["p_brand_name"] = drd.GetValue(2).ToString();
                dtRow["user_name"] = drd.GetValue(3).ToString();
                dtRow["user_contact"] = drd.GetValue(4).ToString();
                dtRow["user_email"] = drd.GetValue(5).ToString();
                dtRow["user_address"] = drd.GetValue(6).ToString() + "<br>" + drd.GetValue(7).ToString() + "<br>" + drd.GetValue(8).ToString() + "<br>-" + drd.GetValue(17).ToString() + "<br>" + drd.GetValue(9).ToString();
                dtRow["o_quan"] = drd.GetValue(10).ToString();
                dtRow["p_id"] = drd.GetValue(11).ToString();
                dtRow["user_id"] = drd.GetValue(12).ToString();
                dtRow["o_price"] = drd.GetValue(14).ToString();
                dtRow["o_date"] = drd.GetDateTime(15).ToString("yyyy-MM-dd");
                dtRow["o_sub_date"] = drd.GetDateTime(15).ToString("yyyy-MM-dd");


                cart_tbl.Rows.Add(dtRow);
            }

            if (cnt > 0)
            {
                sub_repeat.DataSource = cart_tbl;
                sub_repeat.DataBind();
            }
            else
            {
                //req_tbl_panel.Visible = false;
            }
            con.Close();
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
            dtColumn.ColumnName = "user_name";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "user_contact";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "user_email";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "user_address";
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
            dtColumn.ColumnName = "user_id";
            dtColumn.ReadOnly = false;
            cart_tbl.Columns.Add(dtColumn);


            SqlCommand user_id_cmd = new SqlCommand("select sel_id from tbl_sel where sel_name='" + Session["sel_name"] + "'", con);
            String user_id = user_id_cmd.ExecuteScalar().ToString();

            SqlCommand cmd = new SqlCommand("select p_name,p_cat_name,p_brand_name,u_name,u_contact,u_email,u_add1,u_add2,u_city,u_state,o_quan,o_p_id,o_sel_id,o_id,o_price,o_date,o_status,u_pin from tbl_prod,tbl_sel,tbl_order,tbl_user where tbl_prod.p_id=tbl_order.o_p_id and tbl_order.o_sel_id=tbl_sel.sel_id and tbl_order.o_user_id=tbl_user.u_id and o_sel_id='" + user_id + "' and o_status='0'", con);
            SqlDataReader drd = cmd.ExecuteReader();
            while (drd.Read())
            {
                cnt++;
                DataRow dtRow;
                dtRow = cart_tbl.NewRow();
                dtRow["o_id"] = drd.GetValue(13).ToString();
                dtRow["p_name"] = drd.GetValue(0).ToString();
                dtRow["p_cat_name"] = drd.GetValue(1).ToString();
                dtRow["p_brand_name"] = drd.GetValue(2).ToString();
                dtRow["user_name"] = drd.GetValue(3).ToString();
                dtRow["user_contact"] = drd.GetValue(4).ToString();
                dtRow["user_email"] = drd.GetValue(5).ToString();
                dtRow["user_address"] = drd.GetValue(6).ToString() + "<br>" + drd.GetValue(7).ToString() + "<br>" + drd.GetValue(8).ToString() + "<br>-" + drd.GetValue(17).ToString() + "<br>" + drd.GetValue(9).ToString();
                dtRow["o_quan"] = drd.GetValue(10).ToString();
                dtRow["p_id"] = drd.GetValue(11).ToString();
                dtRow["user_id"] = drd.GetValue(12).ToString();
                dtRow["o_price"] = drd.GetValue(14).ToString();
                dtRow["o_date"] = drd.GetDateTime(15).ToString("yyyy-MM-dd");
                if (drd.GetValue(16).ToString() == "0")
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
                //req_tbl_panel.Visible = false;
            }
            con.Close();
        }
        protected void order_disp_Click(object sender, EventArgs e)
        {
            disp_req();
            order_panel.Enabled = true;
            order_panel.Visible = true;

            stock_panel.Enabled = false;
            stock_panel.Visible = false;

        }

        protected void stock_disp_Click(object sender, EventArgs e)
        {
            disp_prod();
            stock_panel.Enabled = true;
            stock_panel.Visible = true;

            order_panel.Enabled = false;
            order_panel.Visible = false;
        }

        protected void req_repeat_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "cancel")
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                String o_id = e.CommandArgument.ToString();
                SqlCommand del_cmd = new SqlCommand("delete from tbl_order where o_id='" + o_id + "'", con);
                del_cmd.ExecuteNonQuery();
                con.Close();
                lbl_success.Text = "Order Cancelled!";
                lbl_success.Style.Add("display", "block");
                Response.Write("<script>setTimeout(function(){document.getElementsByClassName('label')[0].style.display='none';},3000);</script>");
                Response.Redirect(Request.RawUrl);
            }
            if (e.CommandName == "submit")
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                String o_id = e.CommandArgument.ToString();
                String o_date = DateTime.Now.ToString("yyyy-MM-dd");
                SqlCommand del_cmd = new SqlCommand("update tbl_order set o_sub_date='" + o_date + "',o_status='1' where o_id='" + o_id + "'", con);
                del_cmd.ExecuteNonQuery();

                SqlCommand sel_p_cmd = new SqlCommand("select o_p_id from tbl_order where o_id='" + o_id + "'", con);
                String p_id = sel_p_cmd.ExecuteScalar().ToString();

                SqlCommand sel_o_cmd = new SqlCommand("select o_quan from tbl_order where o_id='" + o_id + "'", con);
                String order_quan = sel_o_cmd.ExecuteScalar().ToString();
                SqlCommand sel_cmd = new SqlCommand("select p_quan from tbl_prod where p_id='" + p_id + "'", con);
                String curr_quan=sel_cmd.ExecuteScalar().ToString();

                String final_quan = Convert.ToString(Convert.ToInt32(curr_quan) - Convert.ToInt32(order_quan));

                SqlCommand upd_cmd = new SqlCommand("update tbl_prod set p_quan='"+final_quan+"' where p_id='" + p_id + "'", con);
                upd_cmd.ExecuteNonQuery();
                con.Close();
                lbl_success.Text = "Order Submitted!";
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
                    req.Visible = true;
                    req.Enabled = true;
                    sub.Visible = false;
                    sub.Enabled = false;
                    disp_req();
                }
                else if (drop_sort.SelectedIndex == 2)
                {
                    req.Visible = false;
                    req.Enabled = false;
                    sub.Visible = true;
                    sub.Enabled = true;
                    disp_sub();
                }
            }
        }
    }
}