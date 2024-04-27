<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_home.aspx.cs" Inherits="ElectronicGadgets_Marketplace.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style>
        body
        {
            font-size:1.3rem;
            overflow-x:hidden;
        }
        .header
        {
            margin-top:-30px;
            width:100%;
            padding:10px;
            margin-left:-25px;
        }
        .swap-btn
        {
            
            background:lightgreen;
            font-weight:bold;
            width:75px;
            height:35px;
            border:none;
            box-shadow: 0 35px 22px rgba(0,0,0,0.16);
        }
        .swap-btn:hover
        {
            background:black;
            color:White;
            border:none;
            cursor:pointer;
            
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
            border:1px solid black;
            background-color:white;
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
        .dropdown_up_arrow,.dropdown_down_arrow
        {
            border:none;
            background-color:white;
        }
       .dropdown_up_arrow:hover,.dropdown_down_arrow:hover
        {
            cursor:pointer;    
        }
        .cat_data_list,#menu_btn,#close_menu,.dropdown_up_arrow
        {
            display:none;
        }        
        .cat_data_list
        {
            margin-left:-25px;
        }
        .prod_display
        {
            float:left;
            /**height:1400px;**/
        }
        
        #filter_div,.header
        {
            position:fixed;
            background-color:white;
        }
        #filter_div
        {
            margin-left:-10px;
            margin-top:80px;
            width:13%;
            padding:10px;
            background-color:#F5F5F5;
            min-height:100vh;
            height:100%;
        }
        #prod_div
        {
            margin-left:16%;
            margin-top:5%;
            padding:10px;
        }
         #seach_btn:hover
         {
            color:Black;
         }
         #DropDownList1,#btn_filter_show
         {
                 display:none;
         }
         .filter
         {
                width:100%;
                padding:15px;
                font-size:large;
                margin-top:25px;
         }
         .prod_list
         {
             display:block;
             padding-bottom:50px; 
             display:flex;
             flex-wrap:wrap;
             overflow:hidden;
         }
         .prod_list .card
         {
            flex:0 0 auto;
            width:300px;
            padding:20px;
            display:block;
            float:left;
            border:1px solid black;
            border-radius:25px;
            margin:20px;
         }
        .prod_list .card .img img
        {
            height:200px;
            width:250px;
        }
        .prod_list .card .content  
        {
            font-size:18px;
            padding:10px;
        }
        .prod_list .card .price
        {
            font-size:20px;
            float:left;
            padding-left:10px;
            display:block;
        }
        .prod_list .card .rating
        {
            font-size:18px;
            float:right;
            text-align:right; 
            width:150px;
        }
         .prod_list .card:hover
         {
             transform:scale(1.1);
             cursor:pointer;
             background-color:#F5F5F5;
         }
         #tbl_filter
         {
             font-size:18px;
         }
         #tbl_filter .select
         {
             margin-left:25px;
             background-color:#FFFFF0;  
             padding:3px;   
             font-size:15px;
             border-radius:5px;
             outline:none;
         }
         #txt_search:focus
         {
             outline:none;
         }
        @media (min-width:320px) and (max-width:1020px)  
        {
            body
            {
                margin:0 0;
                padding:0 0;
                font-size:1.3rem;
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
                 width:200px;
            }
            #prod_div
            {
                margin-left:210px;
            }
        }
    </style>
    <script type="text/javascript">
        var filter = "false";
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

        function filter_fun() {
           
            var width = window.innerWidth;
            if (width < 1080) {
            
                long_win:
                {

                    if (filter.match("false")) {
                        filter = "true";
                        document.getElementById('filter_div').style = "width:5%;";
                        document.getElementById('btn_filter_show').style = "display:inline";
                        document.getElementById('btn_filter_close').style = "display:none";

                        var filter_input = document.getElementsByClassName("filter");
                        for (var i = 0; i < filter_input.length; i++) {
                            filter_input[i].style.display = "none";
                        }
                        break long_win;
                    }
                    if (filter.match("true")) {
                        filter = "false";
                        document.getElementById('filter_div').style = "width:15%;";
                        document.getElementById('btn_filter_show').style = "display:none";
                        document.getElementById('btn_filter_close').style = "display:inline";

                        var filter_input = document.getElementsByClassName('filter');
                        for (var i = 0; i < filter_input.length; i++) {
                            filter_input[i].style = "width:100%;padding:15px;font-size:large;margin-top:25px;display:block";
                        }
                        break long_win;
                    }

                }
            }
            else {
                long_win:
                {
                    if (filter.match("false")) {
                        filter = "true";
                        document.getElementById('filter_div').style = "width:5%;";
                        document.getElementById('btn_filter_show').style = "display:inline";
                        document.getElementById('btn_filter_close').style = "display:none";

                        var filter_input = document.getElementsByClassName("filter");
                        for (var i = 0; i < filter_input.length; i++) {
                            filter_input[i].style.display = "none";
                        }
                        break long_win;
                    }
                    if (filter.match("true")) {
                        filter = "false";
                        document.getElementById('filter_div').style = "width:15%;";
                        document.getElementById('btn_filter_show').style = "display:none";
                        document.getElementById('btn_filter_close').style = "display:inline";

                        var filter_input = document.getElementsByClassName('filter');
                        for (var i = 0; i < filter_input.length; i++) {
                            filter_input[i].style = "width:100%;padding:15px;font-size:large;margin-top:25px;display:block";
                            }
                        break long_win;
                    }

                }
            }

        }



        function filter_show() {
            if (filter.match("false")) {
                filter = "true";
                filter = "false";
                document.getElementById('filter_div').style = "width:5%;";
                document.getElementsByClassName('prod_display')[1].style = "filter:blur(0px);pointer-events:auto;";
                document.getElementById('btn_filter_close').style = "display:none";
                document.getElementById('btn_filter_show').style = "display:inline";

                var filter_input = document.getElementsByClassName('filter');
                for (var i = 0; i < filter_input.length; i++) {
                    filter_input[i].style.display = "none";
                }

            }
        }
        function filter_close() {
            if (filter.match("true")) {
                document.getElementsByClassName('prod_display')[1].style = "filter:blur(4px);pointer-events:none;";
                document.getElementById('filter_div').style = "width:20%;";
                document.getElementById('btn_filter_close').style = "display:inline";
                document.getElementById('btn_filter_show').style = "display:none";

                var filter_input = document.getElementsByClassName("filter");
                for (var i = 0; i < filter_input.length; i++) {
                    filter_input[i].style.display = "block";
                }
            }
        }
    </script>
</head>
<body>
<form id="Form1" runat="server">

<table id="main" width="100%" style="border-spacing:10px;">
<tr>
    <td style="padding:10px;" valign="top">
        <div class="header" style="border-bottom:1px solid black;">
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
                    <asp:Button ID="seach_btn" ClientIDMode="Static"  type="button" 
                        CssClass="swap-btn" 
                        style="height:25px;background:white;box-shadow:none;border:1px solid black;" 
                        runat="server" Text="Search" 
                        onclick="filter_cat_chk_SelectedIndexChanged" /><br />
                    <%--<button id="seach_btn" type="button" class="swap-btn" style="height:25px;background:white;box-shadow:none;border:1px solid black;">Search</button><br />--%>
                </div>
                <div id="cat_div" runat="server">
                    <button id="close_menu" onclick="closeNav()" type="button" class="swap-btn" style="background:white;box-shadow:none;border:1px solid black;">Categories &larr;&larr;</button>
                    <asp:Label ID="check_str" Text="" runat="server"></asp:Label>
                    <asp:Repeater ID="cat_repeat" runat="server" 
                        onitemdatabound="cat_repeat_ItemDataBound" 
                        onitemcommand="cat_repeat_ItemCommand">
                    <ItemTemplate>
                        <div class='cat_data'>
                            <asp:LinkButton ID="lbt_cat" CssClass="cat_links" runat="server" CommandName="cat_click" CommandArgument='<%# Eval("p_cat_name") %>'><%# Eval("p_cat_name") %></asp:LinkButton>
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
                                        <asp:CheckBoxList ID="brand_check_list"  runat="server" AutoPostBack="True" onselectedindexchanged="brand_check_list_SelectedIndexChanged">
                                        </asp:CheckBoxList>
<%--                                    <asp:Repeater ID="brand_repeat" runat="server">
                                        <ItemTemplate>
                                               <a> <%# Eval("p_brand_name")%> </a>
                                               <br />
                                        </ItemTemplate>
                                    </asp:Repeater>--%>
                            </div>                   
                        </div>  
                    </ItemTemplate>
                    </asp:Repeater>
                </div>
            </td>
            <td width="15%"  align="center">
                <div id="login-btn">
                    <a href="login.aspx">
                        <asp:Button ID="login_btn" ClientIDMode="Static" CssClass="swap-btn" UseSubmitBehavior="false" runat="server" Text="LOGIN" />
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
    </td>
</tr>
<tr>
    <td valign="top">
       <div class="prod_display" id="filter_div">
            <button type="button" class="swap-btn" runat="server" id="btn_filter_show" onclick="filter_fun()">
                Filters <br/> &rarr;
            </button>
            <button type="button"  class="swap-btn" runat="server" id="btn_filter_close" onclick="filter_fun()">
                Filters <br/> &larr;
            </button>
<%--           <asp:ScriptManager ID="ScriptManager1" runat="server">
           </asp:ScriptManager>
           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
                <div id="Div1" runat="server">
                <table id="filter_cat_tbl" class="filter">
                    <tr>
                        <td>Category</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBoxList ID="filter_cat_chk" runat="server" AutoPostBack="true"
                                onselectedindexchanged="filter_cat_chk_SelectedIndexChanged" >
                            </asp:CheckBoxList>  
                        </td>
                    </tr>
                </table>

               <table id="filter_brand_tbl" class="filter">
                    <tr>
                        <td>Brand</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBoxList ID="filter_brand_chk" runat="server" AutoPostBack="true" 
                                onselectedindexchanged="filter_cat_chk_SelectedIndexChanged">
                            </asp:CheckBoxList>  
                        </td>
                    </tr>
                </table>
              </div>
              <%-- <table id="filter_price_tbl" class="filter">
                    <tr>
                        <td>Price</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButtonList ID="filter_price_rd" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="filter_cat_chk_SelectedIndexChanged">
                                <asp:ListItem Text="Low To High" Value="ASC"></asp:ListItem>
                                <asp:ListItem Text="High To Low" Value="DESC"></asp:ListItem>
                            </asp:RadioButtonList>
                            <%--<asp:CheckBoxList ID="filter_price_chk" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="filter_cat_chk_SelectedIndexChanged">
                                <asp:ListItem Text="Low To High" Value="ASC"></asp:ListItem>
                                <asp:ListItem Text="High To Low" Value="DESC"></asp:ListItem>
                            </asp:CheckBoxList>  
                        </td>
                    </tr>
                </table>--%>
           
      <%--      </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="filter_cat_chk" />
            </Triggers>
           </asp:UpdatePanel>--%>
            
       </div>
       <div class="prod_display" id="prod_div" runat="server" clientidmode="Static">
       
           <asp:Table ID="tbl_filter" runat="server" ClientIDMode="Static">
                <asp:TableRow>
                    <asp:TableCell>
                        Sort By :
                        <asp:DropDownList ID="drop_sort" runat="server" CssClass="select" ClientIDMode="Static" AutoPostBack="true" 
               onselectedindexchanged="drop_sort_SelectedIndexChanged">
                            <asp:ListItem Value="0" Selected="True">--Select Something--</asp:ListItem>
                            <asp:ListItem Value="1">Reviews</asp:ListItem>
                            <asp:ListItem Value="2">Price</asp:ListItem>
                        </asp:DropDownList>

                        <asp:DropDownList ID="drop_review" Visible="false" CssClass="select" runat="server" ClientIDMode="Static" 
               AutoPostBack="True" onselectedindexchanged="filter_cat_chk_SelectedIndexChanged">
                            <asp:ListItem Value="0" Selected="True">--Select Something--</asp:ListItem>
                            <asp:ListItem Value="Number">More Number of Reviews Provided</asp:ListItem>
                            <asp:ListItem Value="Stars">High Stars Reviews Provided</asp:ListItem>
                        </asp:DropDownList>

                        <asp:DropDownList ID="drop_price" Visible="false" CssClass="select" runat="server" ClientIDMode="Static" 
               AutoPostBack="True" onselectedindexchanged="filter_cat_chk_SelectedIndexChanged">
                            <asp:ListItem Value="0" Selected="True">--Select Something--</asp:ListItem>
                            <asp:ListItem Value="ASC">Low To High</asp:ListItem>
                            <asp:ListItem Value="DESC">High To Low</asp:ListItem>
                        </asp:DropDownList>

                    </asp:TableCell>
                </asp:TableRow>
           </asp:Table>
            <asp:Repeater ID="prod_cat" runat="server" 
                onitemdatabound="prod_cat_ItemDataBound">
            <ItemTemplate>
            
                <h2><%# Eval("p_cat_name") %></h2>
                <div class="prod_list" runat="server">
                    <asp:HiddenField ID="cat_name_hf" runat="server" Value='<%# Eval("p_cat_name") %>'  />
                     <asp:Repeater ID="prod_cat_data" runat="server">
                        <ItemTemplate>
                            <a href="order.aspx?p_id=<%# Eval("p_id") %>" style="color:Black;padding:0px;margin:0px;">
                            <div class="card">
                                <div class="img">
                                    <img src='<%#"img/prod_img/"+Eval("p_img") %>' />
                                </div>
                                <div class="content">
                                    <div class="productName">
                                        <%# Eval("p_name") %>
                                        <br />
                                        <span style="font-size:20px">(<%# Eval("p_sel_name")%>,<%# Eval("p_sel_state")%>)</span>
                                    </div>
                                </div>
                                <div class="price">
                                    &#8377; <%# Eval("p_price") %>
                                </div>
                                 <div class="rating">
                                        <%# (Convert.ToInt32(Eval("Stars")) == 0 ? "No Reviews" : Eval("Stars") + "&#9733;")%><%#(Convert.ToInt32(Eval("Review_Persons")) == 0 ? "" : "("+Eval("Review_Persons")+")")%>
                                </div>
                               
                            </div></a>
                        </ItemTemplate>
                     </asp:Repeater>
                </div>
            </ItemTemplate>
           </asp:Repeater>
       </div>
    </td>
</tr>
</table>
</form>
</body>
</html>