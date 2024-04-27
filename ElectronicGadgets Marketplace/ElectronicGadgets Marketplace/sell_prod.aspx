<%@ Page Title="" Language="C#" MasterPageFile="~/sell_mst.Master" AutoEventWireup="true" CodeBehind="sell_prod.aspx.cs" Inherits="ElectronicGadgets_Marketplace.sell_prod" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    #home_main
    {
        left:0%;
        top:0%;
        width:100%;
        height:100%;  
        padding:12px;      
    }
    #home_nav_tr
    {
        height:10%;
    }
    .content_div
     {
         /**height:100px;
         border:1px solid black;**/
         margin:2%;
     }   
     #add_form_div
     {
         display:none;
     }
     #image-content,.frm-dtl
     {
         float:left;
     }
     .btn_image
     {
         width:400px;
         height:300px;
         margin-left:50px;
         position:relative;
         font-size:150px;
         border-radius:3px;
         background-color:#fff;
         overflow:hidden;
     }
     .btn_image input[type="file"]
     {
         left:0;
         padding:30px;
         cursor:pointer;
         position:absolute;
         transform:scale(5);
         opacity:0;
     }
     #img_alt_text
     {
         cursor:pointer;
     }
     #frm-tbl 
     {
         width:700px;
         /**border:1px solid black;**/
         padding:10px;
         font-size:20px;
         border-spacing: 30px;
     }
     #frm-tbl .frm-lbl
     {
         float:left;
         padding-right:10px;
         width:25%;
         text-align:right;
     }
     #frm-tbl .frm-input input[type="text"]
     {
         border:none;
         border-bottom:1px solid black;
         width:250px;
     }
     #frm-tbl .frm-input textarea
     {
         width:65%;
         height:100px;
     }
     #frm-tbl .frm-sel
     {
         font-size:15px;
         width:200px;
     }
     #list_prod_tbl
     {
         width:100%;
         font-size:20px;
         border-spacing:20px;
         text-align:center;
     }
     #list_prod_tbl #title_tr
     {
         font-weight:bolder;
         text-decoration:underline;
     }
    .swap-btn
    {
            background:White;
            width:150px;
            height:35px;
            margin-top:2%;
            border:none;
            margin:0px 25px 0px 25px;
            border-bottom:1px solid blue;
            box-shadow: 0 5px 10px rgba(0,0,0,0.25);
    }
    .swap-btn:hover
    {
            background:black;
            color:White;
            border:none;
            cursor:pointer;
    }
    .error_msg
    {
            font-size:15px;
            color:Red;
    } 
    .label
    {
        font-weight:bolder;
        text-decoration:underline;
        font-size:1.3rem;
        margin-left:80%;
        display:none;
        animation:changeColor 2s;
    }
    @keyframes changeColor
    {
        0%{filter:blur(4px);color:black;}
        90%{filter:blur(0px);color:black;}
        100%{display:none;}
    }
    #check_tbl
    {
        position:fixed;z-index:2;
        font-size:1.3rem;
        border-spacing:30px;
        margin-left:50%;
        margin-top:30%;
        box-shadow: 0 5px 10px rgba(0,0,0,0.25);
        background-color:White;
        display:none;
    }
    #update_prod_btn,#delete_prod_btn
    {
        display:none;
    }
</style>
<script type="text/javascript">
    var img_bool = "false";
    function getImgData(event) {
        var choosefile = document.getElementById('prod_img');
        var imgPreview = document.getElementById('img_preview');

        if (choosefile.files[0]) {
            var imgFiles = event.target.files;
            if (imgFiles.length > 0) {
                var imgSrc = URL.createObjectURL(imgFiles[0]);
                imgPreview.innerHTML = "<img id='product_image' src='" + imgSrc + "' style='width:250px;height:250px;'/>";
                document.getElementById('img_alt_text').style = "color:white;font-size:25px;position:absolute;margin-left:40%;margin-top:-5%;background-color:black;border:1px solid black;border-radius:50%;";
                document.getElementById('img_alt_text').innerHTML = "&#8722";
                img_bool = "true";
            }
        }

    }
    function reset_pic() {
        if (img_bool == "true") {
            var imgPreview = document.getElementById('img_preview');
            imgPreview.innerHTML = "";
            document.getElementById('img_alt_text').style = "";
            document.getElementById('img_alt_text').innerHTML = "&#43;";
            img_bool = "false";
        }
    }

    function show_list_prod() {
        document.getElementById('add_form_div').style = "display:none;";
        document.getElementById('list_prod_div').style = "display:block;";
    }
    function show_add_prod() {
        document.getElementById('add_form_div').style = "display:block;";
        document.getElementById('list_prod_div').style = "display:none;";
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lbl_success" runat="server" Text="" CssClass="label"></asp:Label>

<form id="Form1" runat="server" enctype="multipart/form-data">
<asp:HiddenField ID="HiddenField1" runat="server" />
<table id="check_tbl" clientidmode="Static" runat="server">
    <tr>
        <td>
            <label id="warn_label" runat="server">There are <asp:Label ID="match_lbl" runat="server" Text=""></asp:Label> Matches, Do You Want To Insert ? </label>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Button ID="btn_conti" CssClass="swap-btn" runat="server" Text="YES" 
                onclick="btn_conti_Click" style="width:150px" CausesValidation="False" />
            <asp:Button ID="btn_stop" CssClass="swap-btn" runat="server" Text="NO" 
                onclick="btn_stop_Click" style="width:150px" CausesValidation="False" />
        </td>
    </tr>
</table>

    <table id="home_main" runat="server" clientidmode="Static">
        <tr id="home_nav_tr">
            <td>
                <asp:Button ID="Button1" runat="server" CausesValidation="false" 
                    class="swap-btn home_nav_btn" Text="Add New Products" ClientIDMode="Static" 
                    onclientclick="show_add_prod();" onclick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" CausesValidation="false" 
                    class="swap-btn home_nav_btn" Text="Listed Products" ClientIDMode="Static" 
                    onclientclick="show_list_prod();" onclick="Button2_Click" />
           </td>
        </tr>
        <tr>
            <td id="content_td" valign="top">
                <div id="add_form_div" class="content_div" runat="server" clientidmode="Static">
                    <div class="frm-dtl" id="image_content">
                        <button id="pimg_btn" type="button" class="btn_image">
                                <span id="img_alt_text" runat="server" clientidmode="Static" onclick="reset_pic();">&#43;</span>
                                <div id="img_preview" runat="server" clientidmode="Static"></div>
                                <asp:FileUpload ID="prod_img" runat="server" clientidmode="Static" onchange="getImgData(event);" />
                        </button><br />
                        <div style="margin-left:25%">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" 
                                        ControlToValidate="prod_img" ErrorMessage="*Field can not be Empty" 
                                        Display="Dynamic" CssClass="error_msg  sel_error"></asp:RequiredFieldValidator>
                                    <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator18" 
                                         ControlToValidate="prod_img" runat="server" 
                                         ErrorMessage="*Upload JPG/JPEG/PNG files Only" 
                                         ValidationExpression="([a-zA-Z0-9\s_\\.\-\(\):])+(.jpg|.jpeg|.png)$" Display="Dynamic" 
                                        CssClass="error_msg  sel_error"></asp:RegularExpressionValidator>
                        <asp:Label ID="prod_img_err" runat="server" Text="" CssClass="error_msg" style="margin-left:25%"></asp:Label>
                        </div>
                    </div>
                    <div class="frm-dtl">
                        <table id="frm-tbl">
                            <tr>
                                <td>
                                    <div class="frm-lbl">Product Name/Title:</div>
                                    <div class="frm-input">
                                        <input type="text" id="txt_pname" runat="server" /><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="txt_pname" ErrorMessage="*Field can not be Empty" 
                                        Display="Dynamic" CssClass="error_msg"></asp:RequiredFieldValidator>
                                    <br />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                         ControlToValidate="txt_pname" runat="server" 
                                         ErrorMessage="*Length Must Be 8 to 50  <br> <span style='margin-left:25%'>Use Only Alphabets-Numbers-Some Symbols</span>" 
                                         ValidationExpression="^[a-zA-Z0-9\s_\\.\-\(\):\|]{8,40}" Display="Dynamic" 
                                        CssClass="error_msg"></asp:RegularExpressionValidator>                                
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="frm-lbl">Description:</div>
                                    <div class="frm-input">
                                        <asp:TextBox ID="txt_pdec" runat="server" TextMode="MultiLine"></asp:TextBox>
                                         <br />
                                    <div style="margin-left:25%">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="txt_pdec" ErrorMessage="*Field can not be Empty" 
                                        Display="Dynamic" CssClass="error_msg"></asp:RequiredFieldValidator>
                                    <br />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                                         ControlToValidate="txt_pdec" runat="server" 
                                         ErrorMessage="*Length Must Be 8 to 200  <br> Use Only Alphabets-Numbers-Some Symbols" 
                                         ValidationExpression="^[A-Za-z0-9'\.\-\s\,\|]{8,200}" Display="Dynamic" 
                                        CssClass="error_msg"></asp:RegularExpressionValidator>   
                                    </div>                                 
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="frm-lbl">Select Category:</div>
                                    <div class="frm-input">
                                        <asp:DropDownList id="drop_cat" runat="server" class="frm-sel" AutoPostBack="true" 
                                            onselectedindexchanged="drop_cat_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:Label ID="sel_cat_err" runat="server" Text="" CssClass="error_msg"></asp:Label>                                   
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="frm-lbl">Select Brand /Manufacturer:</div>
                                    <div class="frm-input">
                                        <asp:DropDownList id="drop_manu" runat="server" class="frm-sel" 
                                            AutoPostBack="True" onselectedindexchanged="drop_manu_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:Label ID="sel_manu_err" runat="server" Text="" CssClass="error_msg"></asp:Label>                                    
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="frm-lbl">Quantity:</div>
                                    <div class="frm-input">
                                        <input type="text" id="txt_quan" runat="server" /><br />
                                    
                                    <div style="margin-left:25%">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ControlToValidate="txt_quan" ErrorMessage="*Field can not be Empty" 
                                        Display="Dynamic" CssClass="error_msg"></asp:RequiredFieldValidator>
                                    <br />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" 
                                         ControlToValidate="txt_quan" runat="server" 
                                         ErrorMessage="*Max 9 At a Time" 
                                         ValidationExpression="^[1-9]{1}" Display="Dynamic" 
                                        CssClass="error_msg"></asp:RegularExpressionValidator> 
                                        <asp:Label ID="txt_quan_err" runat="server" Text="" CssClass="error_msg"></asp:Label>       
                                     </div>                                               
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="frm-lbl">Price:</div>
                                    <div class="frm-input">
                                        <input type="text" id="txt_price" runat="server" /><br />
                                        
                                    <div style="margin-left:25%">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                        ControlToValidate="txt_price" ErrorMessage="*Field can not be Empty" 
                                        Display="Dynamic" CssClass="error_msg"></asp:RequiredFieldValidator>
                                    <br />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" 
                                         ControlToValidate="txt_price" runat="server" 
                                         ErrorMessage="*Use Only Digits and only one dot" 
                                         ValidationExpression="[(?<=^| )\d]+[(\.\d+)?(?=$| )]{3}" Display="Dynamic" 
                                        CssClass="error_msg"></asp:RegularExpressionValidator> 
                                        <asp:Label ID="txt_price_err" runat="server" Text="" CssClass="error_msg"></asp:Label>   
                                     </div>                                                  
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                   <asp:Button ID="update_prod_btn" runat="server" class="swap-btn" Text="Update Product" OnClick="update_prod_btn_Click" />
                                   <asp:Button ID="delete_prod_btn" runat="server" class="swap-btn" 
                                        Text="Delete Product" onclick="delete_prod_btn_Click" />
                                   <asp:Button ID="add_prod_btn" runat="server" class="swap-btn" Text="Add Product" onclick="add_prod_btn_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div id="list_prod_div" class="content_div" runat="server" clientidmode="Static">
                    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" 
                        AutoGenerateColumns="False" DataKeyNames="p_id" AllowPaging="True" 
                        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
                        CellPadding="4" ForeColor="Black" PageSize="5" CellSpacing="2" 
                        HorizontalAlign="Center" 
                        onselectedindexchanged="GridView1_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" >
                            <ItemStyle BackColor="#FFFF99" />
                            </asp:CommandField>
                            <asp:BoundField DataField="p_id" HeaderText="Product ID" ReadOnly="True" 
                                SortExpression="p_id" />
                            <asp:BoundField DataField="p_cat_name" HeaderText="Category Name" 
                                SortExpression="p_cat_name" />
                            <asp:BoundField DataField="p_name" HeaderText="Product Name/Title" 
                                SortExpression="p_name" />
                            <asp:TemplateField HeaderText="Image" SortExpression="p_img">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("p_img") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Image ID="Image1" Width="300" Height="300" runat="server" ImageUrl='<%#"img/prod_img/"+ Eval("p_img") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="p_brand_name" HeaderText="Brand" 
                                SortExpression="p_brand_name" />
                            <asp:BoundField DataField="p_desc" HeaderText="Description" 
                                SortExpression="p_desc" />
                            <asp:BoundField DataField="p_price" HeaderText="Price" 
                                SortExpression="p_price" />
                            <asp:BoundField DataField="p_quan" HeaderText="Quantity" 
                                SortExpression="p_quan" />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" />
                        <SelectedRowStyle BackColor="#CCFFFF" Font-Bold="True" ForeColor="Black" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="Gray" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        SelectCommand="SELECT * FROM [tbl_prod] WHERE ([p_sel_id] = @p_sel_id)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="HiddenField1" Name="p_sel_id" 
                                PropertyName="Value" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </td>
        </tr>
    </table>
</form>
</asp:Content>



