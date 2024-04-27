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
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\tybca11\project\ElectronicGadgets Marketplace\ElectronicGadgets Marketplace\App_Data\elctrogadget.mdf;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30;User Instance=True");
        String cat_value = "";
        String brand_value = "";
        String price_value = "";
        String rate_value = "";
        String condition = "";
        int cnt_row = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["user_name"] != null)
            {

                cart_link.Text = Session["user_name"].ToString();
                cart_link.Style.Add("display", "block");
                login_btn.Style.Add("display", "none");
            }
            //else
            //{
            //    Response.Redirect("~/login.aspx");
            //}
            if (!(IsPostBack))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    disp_cat();
                    disp_fil(filter_cat_chk, "p_cat_name", "tbl_prod");
                    disp_fil(filter_brand_chk, "p_brand_name", "tbl_prod");
                }


                if (Request.QueryString["cat_name"] != null)
                {
                    String cat = Request.QueryString["cat_name"].ToString();
                    foreach (ListItem item in filter_cat_chk.Items)
                    {
                        item.Selected = false;

                    }
                    foreach (ListItem item in filter_cat_chk.Items)
                    {
                        if (item.Text == cat)
                        {
                            cat_value = cat;
                            item.Selected = true;
                        }
                    }

                    if (cat_value.Length > 0)
                    {
                        cat_value = "'" + cat_value + "'";
                        condition = "p_cat_name in(" + cat_value + ")";
                    }
                    prod_cat.DataSource = null;
                    prod_cat.DataBind();

                    DataTable cat_table = new DataTable("cat_table");
                    SqlCommand cmd = new SqlCommand();
                    if (condition.Length > 0)
                    {
                        //check_str.Text = "select p_cat_name,count(*) as total from tbl_prod where " + condition + " group by p_cat_name HAVING COUNT(*) > 0 ";
                        cmd = new SqlCommand("select p_cat_name,count(*) as total from tbl_prod where " + condition + " group by p_cat_name HAVING COUNT(*) > 0 ", con);
                    }
                    else
                    {
                        //check_str.Text="select p_cat_name,count(*) as total from tbl_prod group by p_cat_name HAVING COUNT(*) > 0 ";
                        cmd = new SqlCommand("select p_cat_name,count(*) as total from tbl_prod group by p_cat_name HAVING COUNT(*) > 0 ", con);
                    }


                    if (condition.Length > 0)
                    {
                        condition = " and " + condition;
                    }


                    // check_str.Text = condition;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(cat_table);
                    prod_cat.DataSource = cat_table;
                    prod_cat.DataBind();
                }
                else if (Request.QueryString["brand_name"] != null)
                {
                    String cat = Request.QueryString["brand_name"].ToString();
                    foreach (ListItem item in filter_brand_chk.Items)
                    {
                        item.Selected = false;

                    }
                    foreach (ListItem item in filter_brand_chk.Items)
                    {
                        if (item.Text == cat)
                        {
                            brand_value = cat;
                            item.Selected = true;
                        }
                    }

                    if (brand_value.Length > 0)
                    {
                        brand_value = "'" + brand_value + "'";
                        condition = "p_brand_name in(" + brand_value + ")";
                    }
                    prod_cat.DataSource = null;
                    prod_cat.DataBind();

                    DataTable cat_table = new DataTable("cat_table");
                    SqlCommand cmd = new SqlCommand();
                    if (condition.Length > 0)
                    {
                        //check_str.Text = "select p_cat_name,count(*) as total from tbl_prod where " + condition + " group by p_cat_name HAVING COUNT(*) > 0 ";
                        cmd = new SqlCommand("select p_cat_name,count(*) as total from tbl_prod where " + condition + " group by p_cat_name HAVING COUNT(*) > 0 ", con);
                    }
                    else
                    {
                        //check_str.Text="select p_cat_name,count(*) as total from tbl_prod group by p_cat_name HAVING COUNT(*) > 0 ";
                        cmd = new SqlCommand("select p_cat_name,count(*) as total from tbl_prod group by p_cat_name HAVING COUNT(*) > 0 ", con);
                    }


                    if (condition.Length > 0)
                    {
                        condition = " and " + condition;
                    }


                    // check_str.Text = condition;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(cat_table);
                    prod_cat.DataSource = cat_table;
                    prod_cat.DataBind();
                }

                else if (Request.QueryString["search"] != null)
                {
                    txt_search.Text = Request.QueryString["search"];
                    if (txt_search.Text.Trim().Length != 0)
                    {
                        if (condition.Length > 0)
                        {
                            condition += " and p_name like '%" + txt_search.Text + "%'";
                        }
                        else
                        {
                            condition += " p_name like '%" + txt_search.Text + "%'";
                        }
                        prod_cat.DataSource = null;
                        prod_cat.DataBind();

                        //check_str.Text = condition;
                        DataTable cat_table = new DataTable("cat_table");
                        SqlCommand cmd = new SqlCommand("select p_cat_name,count(*) as total from tbl_prod where " + condition + " group by p_cat_name HAVING COUNT(*) > 0 ", con);

                        if (condition.Length > 0)
                        {
                            condition = " and " + condition;
                        }
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(cat_table);
                        prod_cat.DataSource = cat_table;
                        prod_cat.DataBind();

                    }
            }
            
          }

            
        }
        public void disp_cat()
        {
            DataTable cat_table = new DataTable("cat_table");
            SqlCommand cmd = new SqlCommand("select top(4) p_cat_name,count(*) as total from tbl_prod group by p_cat_name  HAVING COUNT(*) > 0 ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(cat_table);
            cat_repeat.DataSource = cat_table;
            cat_repeat.DataBind();

            cat_table.Clear();
            cmd = new SqlCommand("select p_cat_name,count(*) as total from tbl_prod group by p_cat_name  HAVING COUNT(*) > 0 ", con);
            da = new SqlDataAdapter(cmd);
            da.Fill(cat_table);
            prod_cat.DataSource = cat_table;
            prod_cat.DataBind();
        }
        public void disp_fil(CheckBoxList chk, String col, String tbl, String ref_col = "", String ref_val = "")
        {
            SqlCommand cmd = new SqlCommand("", con);
            if (ref_col == "" && ref_val == "")
            {
                cmd = new SqlCommand("select " + col + ",count(*) as total from " + tbl + " group by " + col + " HAVING COUNT(*) > 0 ", con);
            }
            else
            {
                String str = "select " + col + ",count(*) as total from " + tbl + " where " + ref_col + " in (" + ref_val + ") group by " + col + " HAVING COUNT(*) > 0 ";
                cmd = new SqlCommand(str, con);

            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable filter_table = new DataTable("filter_table");
            da.Fill(filter_table);
            chk.DataSource = filter_table;
            chk.DataTextField = col;
            chk.DataValueField = col;
            chk.DataBind();

        }
        protected void prod_cat_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                
                DataTable prod_tbl = new DataTable("prod_tbl");
                DataColumn dtColumn;
                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(String);
                dtColumn.ColumnName = "p_id";
                dtColumn.ReadOnly = false;
                prod_tbl.Columns.Add(dtColumn);

                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(String);
                dtColumn.ColumnName = "p_img";
                dtColumn.ReadOnly = false;
                prod_tbl.Columns.Add(dtColumn);

                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(String);
                dtColumn.ColumnName = "p_name";
                dtColumn.ReadOnly = false;
                prod_tbl.Columns.Add(dtColumn);

                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(String);
                dtColumn.ColumnName = "p_sel_name";
                dtColumn.ReadOnly = false;
                prod_tbl.Columns.Add(dtColumn);

                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(String);
                dtColumn.ColumnName = "p_sel_city";
                dtColumn.ReadOnly = false;
                prod_tbl.Columns.Add(dtColumn);

                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(String);
                dtColumn.ColumnName = "p_cat_name";
                dtColumn.ReadOnly = false;
                prod_tbl.Columns.Add(dtColumn);

                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(float);
                dtColumn.ColumnName = "p_price";
                dtColumn.ReadOnly = false;
                prod_tbl.Columns.Add(dtColumn);

                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(String);
                dtColumn.ColumnName = "Stars";
                dtColumn.ReadOnly = false;
                prod_tbl.Columns.Add(dtColumn);

                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(String);
                dtColumn.ColumnName = "Review_Persons";
                dtColumn.ReadOnly = false;
                prod_tbl.Columns.Add(dtColumn);

                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(String);
                dtColumn.ColumnName = "p_sel_state";
                dtColumn.ReadOnly = false;
                prod_tbl.Columns.Add(dtColumn);

                var cat_name = (HiddenField)e.Item.FindControl("cat_name_hf");
                Repeater inner = (Repeater)e.Item.FindControl("prod_cat_data");
               
                SqlCommand data_cmd;
                if (condition.Length > 0)
                {
                    //check_str.Text = "select p_cat_name,count(*) as total from tbl_prod where " + condition + " group by p_cat_name HAVING COUNT(*) > 0 ";
                    data_cmd = new SqlCommand("select * from tbl_prod,tbl_sel where p_sel_id=sel_id and p_cat_name='" + cat_name.Value + "'" + condition + "", con);
                    //data_cmd = new SqlCommand("select top(1) * from tbl_prod,tbl_sel,tbl_rate where p_sel_id=sel_id and p_id=rate_p_id and p_cat_name='" + cat_name.Value + "' " + condition + "", con);
                }
                else
                {

                    //check_str.Text="select p_cat_name,count(*) as total from tbl_prod group by p_cat_name HAVING COUNT(*) > 0 ";
                    data_cmd = new SqlCommand("select top(3) p_id,p_img,p_name,p_cat_name,p_price,sel_name,sel_city,sel_state  from tbl_prod,tbl_sel where p_sel_id=sel_id and p_cat_name='" + cat_name.Value + "' group by p_id,p_img,p_name,p_cat_name,p_price,sel_id,sel_name,sel_city,sel_state", con);
                }
                //check_str.Text = condition;

                //if (cat_value == "" && brand_value != "")
                //{
                //    data_cmd = new SqlCommand("select * from tbl_prod,tbl_sel where p_sel_id=sel_id and p_cat_name='" + cat_name.Value + "' and p_brand_name in (" + brand_value + ")", con);

                //}
                //else if (cat_value != "" && brand_value == "")
                //{
                //    data_cmd = new SqlCommand("select * from tbl_prod,tbl_sel where p_sel_id=sel_id and p_cat_name='" + cat_name.Value + "'", con);

                //}
                //else if (cat_value != "" && brand_value != "")
                //{
                //    data_cmd = new SqlCommand("select * from tbl_prod,tbl_sel where p_sel_id=sel_id and p_cat_name='" + cat_name.Value + "' and p_brand_name in (" + brand_value + ")", con);
                //}
                //else
                //{
                //    data_cmd = new SqlCommand("select * from tbl_prod,tbl_sel where p_sel_id=sel_id and p_cat_name='" + cat_name.Value + "'", con);
                //}
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlDataReader drd = data_cmd.ExecuteReader();
                while (drd.Read())
                {
                    Double stars = 0;
                    Double cnt = 0;

                    data_cmd = new SqlCommand("select count(*) from tbl_rate where rate_p_id='" + drd.GetValue(0) + "'", con);
                    if (Convert.ToInt32(data_cmd.ExecuteScalar()) > 0)
                    {
                        SqlCommand cmd;
                        //if (rate_value == "")
                        //{
                            //check_str.Text = "select count(*),sum(rate_star)/count(*) from tbl_rate where rate_p_id='" + drd.GetValue(0) + "' group by rate_p_id";
                            cmd = new SqlCommand("select count(*) as Total_Reviews,sum(rate_star)/count(*) as Stars from tbl_rate where rate_p_id='" + drd.GetValue(0) + "' group by rate_p_id", con);
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

                    DataRow dtRow;
                    dtRow = prod_tbl.NewRow();
                    dtRow["p_id"] = drd["p_id"];
                    dtRow["p_img"] = drd["p_img"];
                    dtRow["p_name"] = drd["p_name"];
                    dtRow["p_cat_name"] = drd["p_cat_name"];
                    dtRow["p_price"] = drd["p_price"];
                    if (cnt > 0)
                    {
                        dtRow["Stars"] = stars ;
                        dtRow["Review_Persons"] = cnt ;
                    }
                    else
                    {
                        dtRow["Stars"] = 0;
                        dtRow["Review_Persons"] = 0;
                    }
                    dtRow["p_sel_name"] = drd["sel_name"];
                    dtRow["p_sel_city"] = drd["sel_city"];
                    dtRow["p_sel_state"] = drd["sel_state"];
                    prod_tbl.Rows.Add(dtRow);
                }
                //check_str.Text = rate_value;
                //if (rate_value.IndexOf("Stars").ToString() != "0")
                //{

                //    prod_tbl.DefaultView.Sort = "Stars DESC";
                //    prod_tbl = prod_tbl.DefaultView.ToTable();
                //}
                //else if (rate_value.IndexOf("Total_Reviews").ToString() != "0")
                //{
                //    prod_tbl.DefaultView.Sort = "Review_Persons DESC";
                //    prod_tbl = prod_tbl.DefaultView.ToTable();
                //}
                
                //prod_tbl.DefaultView.Sort = "p_rate";
                //if (price_value.Length > 0)
                //{
                //    prod_tbl.DefaultView.Sort = "p_price";
                //}
                if (drop_review.SelectedIndex == 2)
                {

                    prod_tbl.DefaultView.Sort = "Stars DESC";
                    prod_tbl = prod_tbl.DefaultView.ToTable();
                }
                else if (drop_review.SelectedIndex==1)
                {
                    prod_tbl.DefaultView.Sort = "Review_Persons DESC";
                    prod_tbl = prod_tbl.DefaultView.ToTable();
                }
                //prod_tbl = prod_tbl.DefaultView.ToTable();
                inner.DataSource = prod_tbl;
                inner.DataBind();
                con.Close();
            }
        }

        protected void cat_repeat_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                var cat_name = (HiddenField)e.Item.FindControl("cat_name_hide");
                CheckBoxList chk = (CheckBoxList)e.Item.FindControl("brand_check_list");
                //Repeater inner = (Repeater)e.Item.FindControl("brand_repeat");
                SqlCommand cmd = new SqlCommand("select p_brand_name,count(*) as total from tbl_prod where p_cat_name='" + cat_name.Value + "' group by p_brand_name  HAVING COUNT(*) > 0 ", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable filter_table = new DataTable("filter_table");
                da.Fill(filter_table);
                chk.DataSource = filter_table;
                chk.DataTextField = "p_brand_name";
                chk.DataValueField = "p_brand_name";
                chk.DataBind();
                //inner.DataSource = cmd.ExecuteReader();
                //inner.DataBind();
                con.Close();
            }
        }

        protected void filter_cat_chk_SelectedIndexChanged(object sender, EventArgs e)
        {


            condition = "";
            int cnt_cat = 0;
            int cnt_brand = 0;
            for (int i = 0; i < filter_cat_chk.Items.Count; i++)
            {
                if (filter_cat_chk.Items[i].Selected == true)
                {
                    cat_value += "'" + filter_cat_chk.Items[i].Text + "',";
                    cnt_cat++;
                }
            }
            if (cnt_cat > 0)
            {
                condition = "p_cat_name in (" + cat_value.Substring(0, cat_value.Length - 1) + ")";
            }
            else
            {
                condition = "";
            }


            for (int i = 0; i < filter_brand_chk.Items.Count; i++)
            {
                if (filter_brand_chk.Items[i].Selected == true)
                {
                    brand_value += "'" + filter_brand_chk.Items[i].Text + "',";
                }
            }
            if (brand_value.Length > 0)
            {
                if (condition.Length > 0)
                {
                    condition += " and p_brand_name in (" + brand_value.Substring(0, brand_value.Length - 1) + ")";
                }
                else
                {
                    condition += "p_brand_name in (" + brand_value.Substring(0, brand_value.Length - 1) + ")";
                }
                
            }
            else
            {
                condition += "";
            }

            if (drop_price.SelectedIndex > 0)
            {
                for (int i = 0; i < drop_price.Items.Count; i++)
                {
                    if (drop_price.Items[i].Selected == true)
                    {
                        price_value += drop_price.Items[i].Value;
                    }
                }
            }
            

            if (drop_review.SelectedIndex == 1)
            {
                rate_value = " order by Total_Reviews DESC";
            }
            else if (drop_review.SelectedIndex == 2)
            {
                rate_value = " order by Stars DESC";
            }
            else
            {
                rate_value = "";
            }


            if (txt_search.Text.Trim().Length != 0)
            {
                if (condition.Length > 0)
                {
                    condition += " and p_name like '%" + txt_search.Text + "%'";
                }
                else
                {
                    condition += " p_name like '%" + txt_search.Text + "%'";
                }
                
            }
            //check_str.Text = rate_value;

            if (cat_value.Length > 0 && brand_value.Length == 0)
            {

                brand_value = "";
                cat_value = cat_value.Substring(0, cat_value.Length - 1);
                disp_fil(filter_brand_chk, "p_brand_name", "tbl_prod", "p_cat_name", cat_value);
                //prod_cat.DataSource = null;
                //prod_cat.DataBind();

                //DataTable cat_table = new DataTable("cat_table");
                //SqlCommand cmd = new SqlCommand("select p_cat_name,count(*) as total from tbl_prod where p_cat_name in (" + cat_value + ") group by p_cat_name  HAVING COUNT(*) > 0 ", con);
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //da.Fill(cat_table);

                //prod_cat.DataSource = cat_table;
                //prod_cat.DataBind();

            }
            else if (cat_value.Length == 0 && brand_value.Length > 0)
            {

                cat_value = "";
                //cat_value = cat_value.Substring(0, cat_value.Length - 1);
                brand_value = brand_value.Substring(0, brand_value.Length - 1);

                disp_fil(filter_cat_chk, "p_cat_name", "tbl_prod", "p_brand_name", brand_value);
                //prod_cat.DataSource = null;
                //prod_cat.DataBind();

                //DataTable cat_table = new DataTable("cat_table");
                //SqlCommand cmd = new SqlCommand("select p_cat_name,count(*) as total from tbl_prod where p_brand_name in (" + brand_value + ") group by p_cat_name  HAVING COUNT(*) > 0 ", con);
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //da.Fill(cat_table);

                //prod_cat.DataSource = cat_table;
                //prod_cat.DataBind();
            }
            else if (cat_value.Length > 0 && brand_value.Length > 0)
            {

                cat_value = cat_value.Substring(0, cat_value.Length - 1);
                brand_value = brand_value.Substring(0, brand_value.Length - 1);

                //disp_fil(filter_brand_chk, "p_brand_name", "tbl_prod", "p_cat_name", value);
                //prod_cat.DataSource = null;
                //prod_cat.DataBind();

                //DataTable mix_table = new DataTable("mix_table");
                //SqlCommand cmd = new SqlCommand("select p_cat_name,count(*) as total from tbl_prod where p_cat_name in (" + cat_value + ") and p_brand_name in (" + brand_value + ") group by p_cat_name  HAVING COUNT(*) > 0 ", con);
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //da.Fill(mix_table);

                //prod_cat.DataSource = mix_table;
                //prod_cat.DataBind();


            }
            else
            {
                brand_value = "";
                cat_value = "";
                disp_fil(filter_brand_chk, "p_brand_name", "tbl_prod");
                disp_fil(filter_cat_chk, "p_cat_name", "tbl_prod");
                //prod_cat.DataSource = null;
                //prod_cat.DataBind();

                //DataTable cat_table = new DataTable("cat_table");
                //SqlCommand cmd = new SqlCommand("select p_cat_name,count(*) as total from tbl_prod group by p_cat_name HAVING COUNT(*) > 0 ", con);
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //da.Fill(cat_table);
                //prod_cat.DataSource = cat_table;
                //prod_cat.DataBind();
            }

            
            prod_cat.DataSource = null;
            prod_cat.DataBind();

            DataTable cat_table = new DataTable("cat_table");
            SqlCommand cmd=new SqlCommand();
            if (condition.Length > 0)
            {
                //check_str.Text = "select p_cat_name,count(*) as total from tbl_prod where " + condition + " group by p_cat_name HAVING COUNT(*) > 0 ";
                cmd = new SqlCommand("select p_cat_name,count(*) as total from tbl_prod where " + condition + " group by p_cat_name HAVING COUNT(*) > 0 ", con);
            }
            else
            {
                //check_str.Text="select p_cat_name,count(*) as total from tbl_prod group by p_cat_name HAVING COUNT(*) > 0 ";
                cmd = new SqlCommand("select p_cat_name,count(*) as total from tbl_prod group by p_cat_name HAVING COUNT(*) > 0 ", con);
            }

            if (price_value.Length > 0)
            {
                if (condition.Length > 0)
                {
                    condition = " and "+ condition +" order by p_price " + price_value + "";
                }
                else
                {
                    condition += " order by p_price " + price_value + "";
                }
               
                
            }
            else
            {
                if (condition.Length > 0)
                {
                    condition = " and " + condition;
                }
                
            }
          // check_str.Text = condition;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(cat_table);
            prod_cat.DataSource = cat_table;
            prod_cat.DataBind();
           //  Response.Write("<script>alert('select p_cat_name,count(*) as total from tbl_prod where p_cat_name in ("+cat_value+")')</script>");

        }

        protected void filter_price_chk_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void drop_sort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drop_sort.SelectedValue == "1")
            {
                drop_price.SelectedIndex = 0;
                drop_price.Visible = false;
                drop_review.Visible = true;
            }
            else if (drop_sort.SelectedValue == "2")
            {
                drop_review.SelectedIndex = 0;
                drop_price.Visible = true;
                drop_review.Visible = false;
            }
            else
            {
                drop_price.SelectedIndex = 0;
                drop_review.SelectedIndex = 0;
                drop_price.Visible = false;
                drop_review.Visible = false;
            }
        }

        protected void seach_btn_Click(object sender, EventArgs e)
        {
            
        }

        protected void cat_repeat_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "cat_click")
            {
                String cat = e.CommandArgument.ToString();
                foreach (ListItem item in filter_cat_chk.Items)
                {
                    item.Selected = false;
                    
                }
                foreach (ListItem item in filter_cat_chk.Items)
                {
                    if (item.Text == cat)
                    {
                        cat_value = cat;
                        item.Selected=true;
                    }
                }

                if (cat_value.Length > 0)
                {
                    condition = "p_cat_name in('"+cat_value+"')";
                }
                prod_cat.DataSource = null;
                prod_cat.DataBind();

                DataTable cat_table = new DataTable("cat_table");
                SqlCommand cmd = new SqlCommand();
                if (condition.Length > 0)
                {
                    //check_str.Text = "select p_cat_name,count(*) as total from tbl_prod where " + condition + " group by p_cat_name HAVING COUNT(*) > 0 ";
                    cmd = new SqlCommand("select p_cat_name,count(*) as total from tbl_prod where " + condition + " group by p_cat_name HAVING COUNT(*) > 0 ", con);
                }
                else
                {
                    //check_str.Text="select p_cat_name,count(*) as total from tbl_prod group by p_cat_name HAVING COUNT(*) > 0 ";
                    cmd = new SqlCommand("select p_cat_name,count(*) as total from tbl_prod group by p_cat_name HAVING COUNT(*) > 0 ", con);
                }

                
                    if (condition.Length > 0)
                    {
                        condition = " and " + condition;
                    }

                
                //check_str.Text = condition;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(cat_table);
                prod_cat.DataSource = cat_table;
                prod_cat.DataBind();
            }
        }

        protected void brand_check_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBoxList chk = (CheckBoxList)sender;
            String brand = "";
          
            foreach (ListItem item in chk.Items)
            {
                if (item.Selected)
                {
                    brand = item.Text;
                }
            }
            foreach (ListItem item in chk.Items)
            {
                item.Selected = false;
            }

            //filter
            foreach (ListItem item in filter_brand_chk.Items)
            {
                item.Selected = false;

            }
            foreach (ListItem item in filter_brand_chk.Items)
            {
                if (item.Text == brand)
                {
                    brand_value = brand;
                    item.Selected = true;
                }
            }
            //
            if (brand_value.Length > 0)
            {
                condition = "p_brand_name in('" + brand + "')";
            }
            prod_cat.DataSource = null;
            prod_cat.DataBind();

            DataTable cat_table = new DataTable("cat_table");
            SqlCommand cmd = new SqlCommand();
            if (condition.Length > 0)
            {
                //check_str.Text = "select p_cat_name,count(*) as total from tbl_prod where " + condition + " group by p_cat_name HAVING COUNT(*) > 0 ";
                cmd = new SqlCommand("select p_cat_name,count(*) as total from tbl_prod where " + condition + " group by p_cat_name HAVING COUNT(*) > 0 ", con);
            }
            else
            {
                //check_str.Text="select p_cat_name,count(*) as total from tbl_prod group by p_cat_name HAVING COUNT(*) > 0 ";
                cmd = new SqlCommand("select p_cat_name,count(*) as total from tbl_prod group by p_cat_name HAVING COUNT(*) > 0 ", con);
            }


            if (condition.Length > 0)
            {
                condition = " and " + condition;
            }


            //check_str.Text = condition;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(cat_table);
            prod_cat.DataSource = cat_table;
            prod_cat.DataBind();
        }



    }

}