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
    public partial class sell_report : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\tybca11\project\ElectronicGadgets Marketplace\ElectronicGadgets Marketplace\App_Data\elctrogadget.mdf;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30;User Instance=True");
        String condition="";
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
                fetchtbl();
                disp_cat();
                disp_manu();
            }
            
        }
        public void disp_cat(string val = "")
        {
            SqlCommand cmd;
            if (val == "")
            {
                cmd = new SqlCommand("select distinct(p_cat_name) as cat_name from tbl_prod", con);
            }
            else
            {
                cmd = new SqlCommand("select distinct(p_cat_name) as cat_name from tbl_prod where p_brand_name='" + val + "'", con);
            }
            DataTable cat_table = new DataTable("cat_table");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(cat_table);
            drop_cat.DataSource = null;
            drop_cat.DataBind();
            drop_cat.DataSource = cat_table;
            drop_cat.DataTextField = "cat_name";
            drop_cat.DataValueField = "cat_name";

            drop_cat.DataBind();
            ListItem it = new ListItem("--Select Option --", "0");
            drop_cat.Items.Insert(0, it);
        }

        public void disp_manu(string val = "")
        {
            SqlCommand cmd;
            if (val == "")
            {
                cmd = new SqlCommand("select distinct(p_brand_name) from tbl_prod", con);
            }
            else
            {
                cmd = new SqlCommand("select distinct(p_brand_name) from tbl_prod where p_cat_name='" + val + "'", con);
            }

            DataTable manu_table = new DataTable("manu_table");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(manu_table);

            drop_manu.DataSource=null;
            drop_manu.DataBind();
            drop_manu.DataSource = manu_table;
            drop_manu.DataTextField = "p_brand_name";
            drop_manu.DataValueField = "p_brand_name";
            drop_manu.DataBind();
            ListItem it = new ListItem("--Select Option --", "0");
            drop_manu.Items.Insert(0, it);
        }

        public void disp_prod(String cat,String brand)
        {
            SqlCommand cmd= new SqlCommand("select p_id,p_name from tbl_prod where p_cat_name='" + cat + "' and p_brand_name='" + brand + "'", con);
            DataTable manu_table = new DataTable("manu_table");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(manu_table);
            drop_pname.DataSource = manu_table;
            drop_pname.DataTextField = "p_name";
            drop_pname.DataValueField = "p_name";
            drop_pname.DataBind();
            ListItem it = new ListItem("--Select Option --", "0");
            drop_pname.Items.Insert(0, it);
            drop_pname.Enabled = true;
        }
        protected void drop_cat_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (drop_cat.SelectedIndex > 0 && drop_manu.SelectedIndex == 0)
            {

                disp_manu(drop_cat.SelectedValue);
                prod_dgv.DataSource = null;
                prod_dgv.DataBind();
                fetchtbl(drop_cat.SelectedValue.ToString());
            }
            else if (drop_cat.SelectedIndex > 0 && drop_manu.SelectedIndex > 0)
            {
                disp_prod(drop_cat.SelectedValue.ToString(), drop_manu.SelectedValue.ToString());
                prod_dgv.DataSource = null;
                prod_dgv.DataBind();
                fetchtbl(drop_cat.SelectedValue.ToString(),drop_manu.SelectedValue.ToString());
            }
            else
            {
                prod_dgv.DataSource = null;
                prod_dgv.DataBind();
                fetchtbl();
                disp_manu();
                disp_cat();
            }
        }

        protected void drop_manu_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (drop_manu.SelectedIndex > 0 && drop_cat.SelectedIndex == 0)
            {
                prod_dgv.DataSource = null;
                prod_dgv.DataBind();
                fetchtbl(null,drop_manu.SelectedValue.ToString());
                disp_cat(drop_manu.SelectedValue);
            }
            else if (drop_cat.SelectedIndex > 0 && drop_manu.SelectedIndex > 0)
            {
                disp_prod(drop_cat.SelectedValue.ToString(), drop_manu.SelectedValue.ToString());
                prod_dgv.DataSource = null;
                prod_dgv.DataBind();
                fetchtbl(drop_cat.SelectedValue.ToString(), drop_manu.SelectedValue.ToString());
            }
            else
            {
                prod_dgv.DataSource = null;
                prod_dgv.DataBind();
                fetchtbl();
                disp_manu();
                disp_cat();
            }
        }
        public void fetchtbl(String cat = null, String brand = null, String pname = null)
        {
            String condition = "";
            int cnt = 0;
            if (cat != null)
            {
                condition = " and tbl_prod.p_cat_name='"+cat+"'";
                cnt++;
            }
            if (brand != null)
            {
                condition = " and tbl_prod.p_brand_name='" + brand + "'";
                cnt++;
            }
            if (pname != null)
            {
                condition = " and tbl_prod.p_name='" + pname + "'";
                cnt++;
            }

            String query = "select p_name as Prodct_Name,p_cat_name as Category,p_brand_name as Brand,sum(o_quan) as Total_Sales,count(*) as Total_Orders from tbl_prod,tbl_order where tbl_prod.p_id=tbl_order.o_p_id and o_sel_id='"+Session["sel_id"].ToString()+"'" + condition + " group by p_name,p_cat_name,p_brand_name";
            SqlCommand sel=new SqlCommand(query,con);
            SqlDataAdapter da = new SqlDataAdapter(sel);
            DataTable table = new DataTable("table");
            da.Fill(table);
            prod_dgv.DataSource = table;
            prod_dgv.DataBind();
        }

        protected void drop_pname_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            if (drop_pname.SelectedIndex > 0)
            {
                SqlCommand cmd = new SqlCommand("select p_id from tbl_prod where p_name = '" + drop_pname.Text.ToString() + "'", con);
                String p_id = cmd.ExecuteScalar().ToString();
                String query = "select o_sub_date as Order_Date,u_name as Customer_Name,u_email as Email,u_city as City,u_state as State,o_quan as Order_Quantity from tbl_order,tbl_prod,tbl_user where o_user_id=u_id and o_p_id=p_id and p_id='" + p_id + "'";
                SqlCommand sel = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(sel);
                DataTable table = new DataTable("table");
                da.Fill(table);
                con.Close();
                prod_dgv.DataSource = table;
                prod_dgv.DataBind();
            }
            else
            {
                prod_dgv.DataSource = null;
                prod_dgv.DataBind();
                fetchtbl(drop_cat.SelectedValue.ToString(), drop_manu.SelectedValue.ToString());
            }
        }
    }
}