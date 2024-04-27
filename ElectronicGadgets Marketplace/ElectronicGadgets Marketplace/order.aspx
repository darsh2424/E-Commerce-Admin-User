<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="ElectronicGadgets_Marketplace.order" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <style type="text/css">
            body
            {
                overflow-x:hidden;
                font-size:1.3rem;
            }
     .header
     {
        width:100%;
        border-bottom:1px solid black;
        padding:10px;
     }
        #cart_link
        {
            display:none;
            text-decoration:none;
            color:Black;
            font-size:15px;
            padding:10px;
            background-color:lightgreen;
            width:75px;
        }
        #cart_link:hover
        {
            background-color:white;
            border:1px solid black;
        }
        #cat_div
        {
            margin-top:25px;
        }
        #cat_div .cat_data
        {
            /**border:1px solid black;**/
            width:200px;
            float:left;
        }
        #cat_div .cat_data a
        {
            text-decoration:none;
            color:Black;
        } 
        .cat_data_list,#menu_btn,#close_menu,.dropdown_up_arrow
        {
            display:none;
        }        
        .cat_data_list
        {
            margin-left:-25px;
        }
   
        .dropdown_up_arrow,.dropdown_down_arrow
        {
            border:none;
            background-color:white;
        }
        .dropdown_up_arrow:hover,.dropdown_down_arrow:hover
        {
            cursor:pointer;    
        }
        
    #home_main
    {
        left:0%;
        top:0%;
        width:100%;
        height:100%;  
        padding:12px;      
    }
     .frm-tbl 
     {
         width:700px;
         /**border:1px solid black;**/
         font-size:20px;
         border-spacing: 25px;
     }
     .frm-tbl .frm-lbl
     {
         float:left;
         width:40%;
         text-align:right;
         font-weight:bold;
     }
     .frm-tbl .frm-input input[type="text"]
     {
         border:none;
         font-size:large;
         margin-left:10px; 
     }
     .frm-tbl .frm-input input[type="number"]
     {
         margin-left:10px; 
         width:50px;
     }
      .frm-tbl .frm-input input[type="text"]:focus,textarea:focus
     {
        outline:none;
     }
     .frm-tbl .frm-input input[type="text"]:hover,.frm-lbl:hover,textarea:hover
     {
        cursor:default;
     }
     .frm-tbl .frm-input textarea
     {
         border:none;
         font-size:large;
         margin-left:10px;
         color:Black;
         width:50%;
         height:auto;
         resize:none;
     }
    .swap-btn
    {
            background:White;
            width:70px;
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
    
    #seach_btn:hover
    {
         color:Black;
     }
     #txt_search:focus
         {
             outline:none;
         }
         
     #star-div
     {  
         text-align:center;
         margin-top:50px;
         margin-left:40%;
         border-radius:20px;
         padding-left:10px;
     }
     .star-cb-group button
     {
         cursor:pointer;
         border:none;
         background-color:White;
         width:50px;
         height:50px;
         font-size:35px;
     } 
     .rate-div-lbl
     {
        font-size:25px;
     }
   @media (min-width:320px) and (max-width:1020px)  
        {
            body
            {
                margin:0 0;
                padding:0 0;
                font-size:1.5rem;
            }
            #menu
            {
                z-index:1;
            }
            #logo
            {
                display:none;
            }
             #menu_btn
            {
                display:block;
            }
            #close_menu
            {
                display:block;margin-left:70%;margin-top:30px;
            }
            #cat_div
            {
                display:none;
                border:1px solid black;
                width:30%;
                position:absolute;
                background-color:white;
                margin-left:-50%;
                margin-top:-50px;
                z-index:3;
                height:100%;
            }
            .cat_data
            {
                display:block;
                width:500px;
                text-align:left;
                padding-top:5px;
            }
            .cat_data_list
            {
                color:green;
                text-align:left;
                padding-top:5px;
                margin-left:40px;
            }
            #filter_div
            {
                float:right;
            }
        }
            .style1
            {
                height: 33px;
            }
        </style>
<script type="text/javascript">
    function showList(clicked_id) {
        var btn_inputs1 = document.getElementsByClassName("dropdown_up_arrow");
        for (var i = 0; i < btn_inputs1.length; i++) {
            btn_inputs1[i].style.display = "none";
        }
        var btn_inputs2 = document.getElementsByClassName("dropdown_down_arrow");
        for (var i = 0; i < btn_inputs2.length; i++) {
            btn_inputs2[i].style.display = "inline";
        }

        var list_id = clicked_id.toString();
        var list_show = list_id.substring(0, list_id.indexOf("_darrow")) + "_list";
        var inputs1 = document.getElementsByClassName("cat_data_list");
        for (var i = 0; i < inputs1.length; i++) {
            inputs1[i].style.display = "none";
        }

        var inputs2 = document.getElementsByClassName(list_show);
        for (var i = 0; i < inputs2.length; i++) {

            inputs2[i].style.display = "block";
        }
        document.getElementById(clicked_id).style.display = "none";
        var btn_id = list_id.substring(0, list_id.indexOf("_darrow")) + "_uarrow";
        document.getElementById(btn_id).style.display = "inline";
    }
    function InviList(clicked_id) {
        var inputs1 = document.getElementsByClassName("cat_data_list");
        for (var i = 0; i < inputs1.length; i++) {
            inputs1[i].style.display = "none";
        }
        document.getElementById(clicked_id).style.display = "none";
        var btn_id = clicked_id.substring(0, clicked_id.indexOf("_uarrow")) + "_darrow";
        document.getElementById(btn_id).style.display = "inline";
    }

    function NavList() {
        document.getElementsByClassName('prod_display')[1].style = "filter:blur(4px);pointer-events:none;";
        document.getElementById('cat_div').style = "display:inline;pointer-events:auto;";

    }
    function closeNav() {
        document.getElementById('cat_div').style = "display:none;";
        document.getElementsByClassName('prod_display')[1].style = "filter:blur(0px);pointer-events:none;";
    }

    function fill(id) {
        //alert(id);
        var button_id = id;
        var rate_id = button_id.substring(7);
        document.getElementById("rate_txt").value = rate_id;
        //alert(rate_id);
        var inputs1 = document.getElementsByClassName("rating");
        for (var i = 0; i < rate_id; i++) {
            //            inputs1[i].style.display = "inline";
            var btn_rate = "rating-" + String(Number(i.toString()) + 1);
            document.getElementById(btn_rate).innerHTML = "&#x2605;";
        }
        for (var i = rate_id; i < 5; i++) {
            //            inputs1[i].style.display = "inline";
            var btn_rate = "rating-" + String(Number(i.toString()) + 1);
            document.getElementById(btn_rate).innerHTML = "&#x2606;";
        }
    }
</script>
</head>
<body>
<form id="form1" runat="server">
    <div class="header">
        <table width="100%">
            <td align="center">
                <!-- logo -->
                <a href="user_home.aspx"><img id="logo" src="img/proj_img/back_man.png" width="120px" height="100px"/></a>
                <button id="menu_btn" type="button" class="swap-btn" style="box-shadow:none;border:1px solid black;" onclick="NavList()">Categories &rarr;&rarr;</button>
            </td>
            <td width="70%" align="center">
                <div id="search_div" style="padding:10px;border:1px solid black;width:500px;border-radius:20px;">
                    <asp:TextBox ID="txt_search" ClientIDMode="Static" placeholder="Search.." 
                        style="font-size: 17px;border: none;float:left;width:70%;background:white" runat="server"></asp:TextBox>
                    <asp:Button ID="seach_btn" ClientIDMode="Static" CausesValidation="false" type="button" 
                        CssClass="swap-btn" 
                        style="height:25px;background:white;box-shadow:none;border:1px solid black;" 
                        runat="server" Text="Search" onclick="seach_btn_Click" /><br />
                    <%--<button id="seach_btn" type="button" class="swap-btn" style="height:25px;background:white;box-shadow:none;border:1px solid black;">Search</button><br />--%>
                </div>
                <div id="cat_div" runat="server">
                    <button id="close_menu" onclick="closeNav()" type="button" class="swap-btn" style="background:white;box-shadow:none;border:1px solid black;">Categories &larr;&larr;</button>
                    <asp:Label ID="check_str" Text="" runat="server"></asp:Label>
                    <asp:Repeater ID="cat_repeat" runat="server" 
                        onitemdatabound="cat_repeat_ItemDataBound">
                    <ItemTemplate>
                        <div class='cat_data'>
                            <asp:LinkButton ID="lbt_cat" CssClass="cat_links" runat="server" CausesValidation="false" PostBackUrl='<%# "user_home.aspx?cat_name="+Eval("p_cat_name") %>'><%# Eval("p_cat_name") %></asp:LinkButton>
                            <%--<a class='cat_links' href='<%# Eval("p_cat_name") %>' style='padding:10px;'>
                                <%# Eval("p_cat_name") %>
                            </a>--%>
                            <button type="button" id="<%# Eval("p_cat_name") %>_darrow" class="dropdown_down_arrow" onclick="showList(this.id)">
                                <img src="img/proj_img/down_arr.jpg" width="15" height="15" />
                            </button>
                            <button type="button" id="<%# Eval("p_cat_name") %>_uarrow" class="dropdown_up_arrow" onclick="InviList(this.id)">
                                <img src="img/proj_img/up_arr.jpg" width="15" height="15" />
                            </button>
                           <%--<input type="button" id="<%# Eval("p_cat_name") %>_darrow" class="dropdown_down_arrow" onclick="showList(this.id)" value="&darr;" />--%>
                           <%--<input type="button" id="<%# Eval("p_cat_name") %>_uarrow" class="dropdown_up_arrow" onclick="InviList(this.id)" value="&uarr;"/>--%>
                            <div class="cat_data_list <%# Eval("p_cat_name") %>_list">
                                <asp:HiddenField ID="cat_name_hide" Value='<%# Eval("p_cat_name") %>' runat="server" />
                                        
                                        <%--<asp:CheckBoxList ID="brand_check_list"  runat="server" AutoPostBack="True">
                                        </asp:CheckBoxList>--%>
                                    <asp:Repeater ID="brand_repeat" runat="server">
                                        <ItemTemplate>
                                                <asp:LinkButton ID="lbt_brand" CssClass="cat_links" runat="server" CausesValidation="false" PostBackUrl='<%# "user_home.aspx?brand_name="+Eval("p_brand_name") %>'><%# Eval("p_brand_name") %></asp:LinkButton>
                            
                                               <%--<a> <%# Eval("p_brand_name")%> </a>--%>
                                               <br />
                                        </ItemTemplate>
                                    </asp:Repeater>
                            </div>                   
                        </div>  
                    </ItemTemplate>
                    </asp:Repeater>
                </div>
            </td>
            <td width="15%"  align="center">
                <div id="login-btn">
                    <a href="login.aspx">
                        <asp:Button ID="login_btn" ClientIDMode="Static" CssClass="swap-btn" UseSubmitBehavior="false" CausesValidation="false" runat="server" Text="LOGIN" />
                        <%--<input type="button" class="swap-btn" value="LOGIN"/>--%>
                    </a>
                </div>
                <div id="user-profile">
                    <asp:HyperLink ID="cart_link" ClientIDMode="Static" runat="server" NavigateUrl="cart.aspx" Text="My Profile"></asp:HyperLink>
            <%--        <input type="button" class="swap-btn" value="My Profile" runat="server" id="profile_btn"/>--%>
                </div>
            </td>
        </table>
    </div>
    <table id="home_main" style="margin-top:10px;">
        <tr>
            <td width="40%" align="right" valign="top">
                <div id="img_preview" runat="server" clientidmode="Static">
                    <asp:Image ID="Image1" runat="server" style='width:250px;height:250px;margin-right:100px;margin-top:100px;' />
                </div>
            </td>
            <td>
                        <table class="frm-tbl">
                            <tr>
                                <td>
                                    <div class="frm-lbl">Product Name/Title:</div>
                                    <div class="frm-input">
                                        <input type="text" id="txt_pname" runat="server" readonly="readonly" /><br /> 
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="frm-lbl">Description:</div>
                                    <div class="frm-input">
                                        <asp:TextBox ID="txt_pdec" runat="server" TextMode="MultiLine" readonly="True"></asp:TextBox>
                                         <br />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="frm-lbl"> Category:</div>
                                    <div class="frm-input">
                                       <input type="text" id="txt_cat" runat="server" readonly="readonly" /><br />                                  
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="frm-lbl"> Brand /Manufacturer:</div>
                                    <div class="frm-input">
                                         <input type="text" id="txt_brand" runat="server" readonly="readonly" /><br />                                   
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="frm-lbl">Available Quantity:</div>
                                    <div class="frm-input">
                                        <input type="text" id="txt_quan" runat="server" readonly="readonly" /><br />                                
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="frm-lbl">Your Quantity:</div>
                                    <div class="frm-input">
                                        <asp:TextBox ID="txt_ask_quan" TextMode="Number" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_ask_quan" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <%--<input type="text" id="Text1" runat="server" readonly="readonly" />--%>
                                        <br />                                
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="frm-lbl">Price:</div>
                                    <div class="frm-input">
                                        <input type="text" id="txt_price" runat="server" readonly="readonly" /><br />                                        
                                    </div>
                                </td>
                            </tr>
                 </table>
                 
       </table>
    <table class="frm-tbl" style="margin-left:40%;">
                               <tr>
                                <td>
                                    <div class="frm-lbl">Seller Name:</div>
                                    <div class="frm-input">
                                        <input type="text" id="txt_sel_name" runat="server" readonly="readonly" /><br /> 
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="frm-lbl">Seller Contact:</div>
                                    <div class="frm-input">
                                        <asp:TextBox ID="txt_sel_con" runat="server"></asp:TextBox>
                                         <br />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="frm-lbl"> Seller Adderss:</div>
                                    <div class="frm-input">
                                        <asp:TextBox id="txt_sel_address" runat="server" readonly="True" runat="server" TextMode="MultiLine"></asp:TextBox>                                
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="frm-lbl">Seller State:</div>
                                    <div class="frm-input">
                                        <input type="text" id="txt_sel_state" runat="server" readonly="readonly" /><br />                                
                                    </div>
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="right">
                                    <asp:Button ID="add_btn" runat="server" class="swap-btn" Text="Add To Cart" 
                                        style="width:250px;" onclick="add_btn_Click" /><br />
                                     <div class="frm-lbl"><asp:Label ID="lbl_err" runat="server" ForeColor="Red" Text=""></asp:Label></div>
                                        
                                </td>
                            </tr>
            </table>
       
       <div id="star-div">
            <table id="star-tbl">
                <tr>
                    <td align="right" class="style1">
                        <div class="previous-rate" style="margin-right:30px;">
                            <span class="rate-div-lbl">Current Rating :</span>
                            <asp:Label ID="lbl_total" runat="server" Text=""></asp:Label>  
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                      <asp:Panel ID="add_panel" runat="server">
                        <span class="rate-div-lbl">Rate Now:</span>
                        <span class="star-cb-group">
                            <button type="button" id="rating-1" class="rating" onclick="fill(this.id);">&#x2606;</button>
                            <button type="button" id="rating-2" class="rating" onclick="fill(this.id);">&#x2606;</button>
                            <button type="button" id="rating-3" class="rating" onclick="fill(this.id);">&#x2606;</button>
                            <button type="button" id="rating-4" class="rating" onclick="fill(this.id);">&#x2606;</button>
                            <button type="button" id="rating-5" class="rating" onclick="fill(this.id);">&#x2606;</button>
                        </span>
                        <span class="rate-div-lbl" style="visibility:hidden" id="lbl-rate">
                            <input type="text" id="rate_txt" style="width:15px" runat="server" />
                        </span>
                        <asp:Button ID="add_rate_btn" runat="server" CssClass="swap-btn" 
                            style="width:auto;padding:10px;" Text="Add Rating" CausesValidation="False" 
                            onclick="add_rate_btn_Click" />

                      </asp:Panel>
                        
                    </td>
                </tr>
            </table>
       </div> 
                        
</form>
</body>
</html>
