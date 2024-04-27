using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
namespace ElectronicGadgets_Marketplace
{
    public partial class sell_prod : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\tybca11\project\ElectronicGadgets Marketplace\ElectronicGadgets Marketplace\App_Data\elctrogadget.mdf;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30;User Instance=True");
        String pid, pname, pdes, pcat, pmanu, pprice, pquan, seller_id, prod_file;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sel_id"] != null)
            {
                HiddenField1.Value = Session["sel_id"].ToString();
            }
            if (!(IsPostBack))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    disp_cat();
                    disp_manu();
                }
                add_prod_btn.Style.Add("display", "inline");
                update_prod_btn.Style.Add("display", "none");
                delete_prod_btn.Style.Add("display", "none");

                if (Request.Params["p_id"] != null)
                {
                    add_form_div.Style.Add("display", "block");
                    list_prod_div.Style.Add("display", "none");
                    add_prod_btn.Style.Add("display", "none");
                    update_prod_btn.Style.Add("display", "inline");
                    delete_prod_btn.Style.Add("display", "inline");

                    SqlCommand sel = new SqlCommand("select * from tbl_prod where p_id='" + Request.Params["p_id"] + "'", con);
                    SqlDataReader rdr = sel.ExecuteReader();
                    while (rdr.Read())
                    {
                        txt_pname.Value = rdr.GetString(2);
                        txt_pdec.Text = rdr.GetString(3);
                        for (int i = 0; i < drop_cat.Items.Count; i++)
                        {
                            if (drop_cat.Items[i].Value == rdr.GetString(4))
                            {
                                drop_cat.Items[0].Selected = false;
                                drop_cat.Items[i].Selected = true;
                                break;
                            }
                        }
                        for (int i = 0; i < drop_manu.Items.Count; i++)
                        {
                            if (drop_manu.Items[i].Value == rdr.GetString(5))
                            {
                                drop_manu.Items[0].Selected = false;
                                drop_manu.Items[i].Selected = true;
                                break;
                            }
                        }
                        txt_price.Value = rdr.GetValue(6).ToString();
                        txt_quan.Value = rdr.GetValue(7).ToString();
                        RequiredFieldValidator20.Enabled = false;
                        RegularExpressionValidator18.Enabled = false;
                        img_preview.InnerHtml = "<img id='product_image' src='img/prod_img/" + rdr.GetString(8) + "' style='width:250px;height:250px;'/>";
                        img_alt_text.InnerHtml = "";
                        prod_img_err.Text = "*Click Photo To Change";
                    }

                }

            }
            
        }

        public void disp_cat(string val = "")
        {
            SqlCommand cmd;
            if (val == "")
            {
                cmd = new SqlCommand("select cat_name from tbl_cat", con);
            }
            else
            {
                cmd = new SqlCommand("select distinct(manu_cat_name) as cat_name from tbl_manu where manu_name='" + val + "'", con);
            }
            DataTable cat_table = new DataTable("cat_table");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(cat_table);
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
                cmd = new SqlCommand("select distinct(manu_name) from tbl_manu", con);
            }
            else
            {
                cmd = new SqlCommand("select distinct(manu_name) from tbl_manu where manu_cat_name='" + val + "'", con);
            }

            DataTable manu_table = new DataTable("manu_table");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(manu_table);
            drop_manu.DataSource = manu_table;
            drop_manu.DataTextField = "manu_name";
            drop_manu.DataValueField = "manu_name";
            drop_manu.DataBind();
            ListItem it = new ListItem("--Select Option --", "0");
            drop_manu.Items.Insert(0, it);
        }

        protected void add_prod_btn_Click(object sender, EventArgs e)
        {
            con.Open();
            int cnt = 0;
            if (drop_cat.SelectedIndex == 0)
            {
                sel_cat_err.Text = "*Select Any Category";
                cnt++;
            }
            if (drop_manu.SelectedIndex == 0)
            {
                sel_manu_err.Text = "*Select Any Brand";
                cnt++;
            }
            if (cnt == 0)
            {

                sel_cat_err.Text = "";
                sel_manu_err.Text = "";
                prod_img_err.Text = "";
                prod_img_err.Text = "";
                seller_id = "";
                if (Session["sel_name"] != null)
                {
                    seller_id = Session["sel_id"].ToString();
                }
                else
                {
                    seller_id = "1";
                }
                pid = "";
                pname = txt_pname.Value;
                pdes = txt_pdec.Text;
                pcat = drop_cat.SelectedValue;
                pmanu = drop_manu.SelectedValue;
                pquan = txt_quan.Value;
                pprice = txt_price.Value;
                prod_file = prod_img.PostedFile.FileName.ToString();

                SqlCommand cmd = new SqlCommand("select count(*) from tbl_prod where p_sel_id='"+seller_id+"' and p_cat_name='" + pcat + "' and p_brand_name='" + pmanu + "' and p_name like '%" + pname + "%'", con);
                match_lbl.Text = cmd.ExecuteScalar().ToString();

                if (Convert.ToInt32(match_lbl.Text) > 0)
                {
                    check_tbl.Style.Add("display", "block");
                    home_main.Style.Add("pointer-events", "none");
                    home_main.Style.Add("background-color", "#7d7d7d");
                    home_main.Style.Add("filter", "blur(4px)");
                }
                else
                {
                    SqlCommand cmd_count = new SqlCommand("select count(*) from tbl_prod", con);
                    if (Convert.ToInt32(cmd_count.ExecuteScalar()) > 0)
                    {
                        SqlCommand cmd_id = new SqlCommand("select max(p_id) from tbl_prod", con);
                        pid = (Convert.ToInt64(cmd_id.ExecuteScalar()) + 1).ToString();
                    }
                    else
                    {
                        pid = "1";
                    }
                    String folderpath = Server.MapPath("~/img/prod_img/");
                    String file_Ext = prod_file.Substring(prod_file.IndexOf("."));
                    String filename = pid + "_image" + file_Ext;
                    prod_img.SaveAs(folderpath + filename);
                    SqlCommand data_cmd = new SqlCommand("insert into tbl_prod values('" + pid + "','" + seller_id + "','" + pname + "','" + pdes + "','" + pcat + "','" + pmanu + "','" + pprice + "','" + pquan + "','" + filename + "');", con);
                    data_cmd.ExecuteNonQuery();
                    lbl_success.Text = "Product Inserted Successfully!";
                    lbl_success.Style.Add("display", "block");
                    Response.Write("<script>setTimeout(function(){document.getElementsByClassName('label')[0].style.display='none';},3000);</script>");
                    con.Close();
                    txt_pname.Value = "";
                    txt_pdec.Text = "";
                    drop_cat.SelectedIndex = 0;
                    drop_manu.SelectedIndex = 0;
                    txt_quan.Value = "";
                    txt_price.Value = "";
                }
            }

            con.Close();
        }

        protected void drop_cat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drop_cat.SelectedIndex > 0 && drop_manu.SelectedIndex == 0)
            {
                disp_manu(drop_cat.SelectedValue);
            }
        }

        protected void drop_manu_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (drop_manu.SelectedIndex > 0 && drop_cat.SelectedIndex == 0)
            {
                disp_cat(drop_manu.SelectedValue);
            }
        }

        protected void btn_conti_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd_count = new SqlCommand("select count(*) from tbl_prod", con);
            if (Convert.ToInt32(cmd_count.ExecuteScalar()) > 0)
            {
                SqlCommand cmd_id = new SqlCommand("select max(p_id) from tbl_prod", con);
                pid = (Convert.ToInt64(cmd_id.ExecuteScalar()) + 1).ToString();
            }
            else
            {
                pid = "1";
            }
            String folderpath = Server.MapPath("~/img/prod_img/");
            String file_Ext = prod_file.Substring(prod_file.IndexOf("."));
            String filename = pid + "_image" + file_Ext;
            prod_img.SaveAs(folderpath + filename);
            SqlCommand data_cmd = new SqlCommand("insert into tbl_prod values('" + pid + "','" + seller_id + "','" + pcat + "','" + filename + "','" + pname + "','" + pmanu + "','" + pdes + "','" + pprice + "','" + pquan + "');", con);
            data_cmd.ExecuteNonQuery();
            lbl_success.Text = "Product Inserted Successfully!";
            lbl_success.Style.Add("display", "block");
            Response.Write("<script>setTimeout(function(){document.getElementsByClassName('label')[0].style.display='none';},3000);</script>");



            pid = "";
            txt_pname.Value = "";
            txt_pdec.Text = "";
            drop_cat.SelectedIndex = 0;
            drop_manu.SelectedIndex = 0;
            txt_quan.Value = "";
            txt_price.Value = "";
            con.Close();
            check_tbl.Style.Add("display", "none");
            home_main.Style.Add("pointer-events", "auto");
            home_main.Style.Add("background-color", "white");
            home_main.Style.Add("filter", "blur(px)");
        }
        protected void btn_stop_Click(object sender, EventArgs e)
        {
            check_tbl.Style.Add("display", "none");
            home_main.Style.Add("pointer-events", "auto");
            home_main.Style.Add("background-color", "white");
            home_main.Style.Add("filter", "blur(px)");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            add_form_div.Style.Add("display", "block");
            list_prod_div.Style.Add("display", "none");
            add_prod_btn.Style.Add("display", "none");
            update_prod_btn.Style.Add("display", "inline");
            delete_prod_btn.Style.Add("display", "inline");

            txt_pname.Value = GridView1.SelectedRow.Cells[3].Text;
            txt_pdec.Text = GridView1.SelectedRow.Cells[6].Text;
            for (int i = 0; i < drop_cat.Items.Count; i++)
            {
                if (drop_cat.Items[i].Value == GridView1.SelectedRow.Cells[2].Text)
                {
                    drop_cat.Items[0].Selected = false;
                    drop_cat.Items[i].Selected = true;
                    break;
                }
            }
            for (int i = 0; i < drop_manu.Items.Count; i++)
            {
                if (drop_manu.Items[i].Value == GridView1.SelectedRow.Cells[5].Text)
                {
                    drop_manu.Items[0].Selected = false;
                    drop_manu.Items[i].Selected = true;
                    break;
                }
            }
            txt_price.Value = GridView1.SelectedRow.Cells[7].Text;
            txt_quan.Value = GridView1.SelectedRow.Cells[8].Text;
            RequiredFieldValidator20.Enabled = false;
            RegularExpressionValidator18.Enabled = false;
            img_preview.InnerHtml = "<img id='product_image' src='" + ((Image)GridView1.SelectedRow.Cells[4].Controls[1]).ImageUrl + "' style='width:250px;height:250px;'/>";
            img_alt_text.InnerHtml = "";
            prod_img_err.Text = "*Click Photo To Change";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            txt_pname.Value = "";
            txt_pdec.Text = "";
            for (int i = 0; i < drop_cat.Items.Count; i++)
            {
                if (drop_cat.Items[i].Selected == true)
                {
                    drop_cat.Items[i].Selected = false;
                    break;
                }
            }
            drop_cat.Items[0].Selected = true;
            for (int i = 0; i < drop_manu.Items.Count; i++)
            {
                if (drop_manu.Items[i].Selected == true)
                {
                    drop_manu.Items[i].Selected = false;
                    break;
                }
            }
            drop_manu.Items[0].Selected = true;
            txt_price.Value = "";
            txt_quan.Value = "";
            img_preview.InnerHtml = "";
            img_alt_text.InnerHtml = "&#43;";
            prod_img_err.Text = "";
            add_prod_btn.Style.Add("display", "inline");
            update_prod_btn.Style.Add("display", "none");
            delete_prod_btn.Style.Add("display", "none");
            add_form_div.Style.Add("display", "block");
            list_prod_div.Style.Add("display", "none");
            lbl_success.Text = "";
            lbl_success.Style.Add("display", "none");
            RequiredFieldValidator20.Enabled = true;
            RegularExpressionValidator18.Enabled = true;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            GridView1.DataBind();
            prod_img_err.Text = "";
            lbl_success.Text = "";
            lbl_success.Style.Add("display", "none");
            add_form_div.Style.Add("display", "none");
            list_prod_div.Style.Add("display", "block");
            RequiredFieldValidator20.Enabled = true;
            RegularExpressionValidator18.Enabled = true;
        }
        protected void update_prod_btn_Click(object sender, EventArgs e)
        {
            con.Open();
            pid = GridView1.SelectedRow.Cells[1].Text;
            String folderpath = Server.MapPath("~/img/prod_img/");
            int cnt = 0;
            if (drop_cat.SelectedIndex == 0)
            {
                sel_cat_err.Text = "*Select Any Category";
                cnt++;
            }
            if (drop_manu.SelectedIndex == 0)
            {
                sel_manu_err.Text = "*Select Any Brand";
                cnt++;
            }
            if (cnt == 0)
            {

                sel_cat_err.Text = "";
                sel_manu_err.Text = "";
                prod_img_err.Text = "";
                prod_img_err.Text = "";
                String grid_rul = (((Image)GridView1.SelectedRow.Cells[4].Controls[1]).ImageUrl).ToString();
                String filename = grid_rul.Substring(13);
                pname = txt_pname.Value;
                pdes = txt_pdec.Text;
                pcat = drop_cat.SelectedValue;
                pmanu = drop_manu.SelectedValue;
                pquan = txt_quan.Value;
                pprice = txt_price.Value;
                if (prod_img.HasFile)
                {
                    String db_fname = ((Image)GridView1.SelectedRow.Cells[4].Controls[1]).ImageUrl;
                    if (File.Exists(db_fname))
                    {
                        File.Delete(db_fname);
                    }

                    prod_file = prod_img.PostedFile.FileName.ToString();
                    String file_Ext = prod_file.Substring(prod_file.IndexOf("."));
                    filename = pid + "_image" + file_Ext;
                    prod_img.SaveAs(folderpath + filename);
                }
                SqlCommand data_cmd = new SqlCommand("update tbl_prod set p_cat_name='" + pcat + "', p_img='" + filename + "',p_name='" + pname + "',p_brand_name='" + pmanu + "',p_desc='" + pdes + "',p_price='" + pprice + "',p_quan='" + pquan + "' where p_id='" + pid + "'", con);
                data_cmd.ExecuteNonQuery();
                lbl_success.Text = "Product Updated Successfully!";
                lbl_success.Style.Add("display", "block");
                Response.Write("<script>setTimeout(function(){document.getElementsByClassName('label')[0].style.display='none';},3000);</script>");

                txt_pname.Value = "";
                txt_pdec.Text = "";
                drop_cat.SelectedIndex = 0;
                drop_manu.SelectedIndex = 0;
                txt_quan.Value = "";
                txt_price.Value = "";
                img_preview.InnerHtml = "";
                img_alt_text.InnerHtml = "&#43;";
                prod_img_err.Text = "";
                update_prod_btn.Style.Add("display", "none");
                delete_prod_btn.Style.Add("display", "none");
                add_form_div.Style.Add("display", "block");
                RequiredFieldValidator20.Enabled = true;
                RegularExpressionValidator18.Enabled = true;
            }
            con.Close();
        }

        protected void delete_prod_btn_Click(object sender, EventArgs e)
        {
            con.Open();
            pid = GridView1.SelectedRow.Cells[1].Text;
            String db_fname = ((Image)GridView1.SelectedRow.Cells[4].Controls[1]).ImageUrl;
            if (File.Exists(db_fname))
            {
                File.Delete(db_fname);
            }
            SqlCommand data_cmd = new SqlCommand("select count(*) from tbl_rate where rate_p_id='" + pid + "'", con);
            if (Convert.ToInt32(data_cmd.ExecuteScalar()) > 0)
            {
                data_cmd = new SqlCommand("delete from tbl_rate where p_id='" + pid + "'", con);
            }
            data_cmd = new SqlCommand("delete from tbl_prod where p_id='" + pid + "'", con);
            data_cmd.ExecuteNonQuery();
            lbl_success.Text = "Product Deleted Successfully!";
            lbl_success.Style.Add("display", "block");
            Response.Write("<script>setTimeout(function(){document.getElementsByClassName('label')[0].style.display='none';},3000);</script>");
            con.Close();
            sel_cat_err.Text = "";
            sel_manu_err.Text = "";
            prod_img_err.Text = "";
            prod_img_err.Text = "";
            txt_pname.Value = "";
            txt_pdec.Text = "";
            drop_cat.SelectedIndex = 0;
            drop_manu.SelectedIndex = 0;
            txt_quan.Value = "";
            txt_price.Value = "";
            img_preview.InnerHtml = "";
            img_alt_text.InnerHtml = "&#43;";
            prod_img_err.Text = "";
            update_prod_btn.Style.Add("display", "none");
            delete_prod_btn.Style.Add("display", "none");
            add_form_div.Style.Add("display", "block");
            RequiredFieldValidator20.Enabled = true;
            RegularExpressionValidator18.Enabled = true;
        }



    }
}