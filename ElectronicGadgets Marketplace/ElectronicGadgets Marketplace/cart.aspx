<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="ElectronicGadgets_Marketplace.cart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <style type="text/css">
    #main
    {
        width:100%;
        border-spacing:10px;
    }
    .header
     {
        border-bottom:1px solid black;
        background-color:white;
        height:75px;
     }
    .header ul
    {
       list-style:none;
    }
    .header ul a
    {
        color:Black;
        text-decoration:none;
        padding:10px;
    }
    .header li
    {
        float:left;
        margin-left:25px;                                                                                                                                                                                                                                                                                       
    }
    .swap-btn
    {  
        border-radius:25px;
        background:white;
        font-weight:bold;
        width:125px;
        height:35px;
    }
    .swap-btn:hover
    {
        background:black;
        color:White;
        border:none;
        cursor:pointer; 
    }
    .logout
    {
        
        border-radius:25px;
        padding:10px;
        background:white;
        font-weight:bold;
        width:auto;
        height:auto;
    }
    .logout:hover
    {
        cursor:pointer; 
    }
    .tbl_cart
    {
        border-spacing:10px;
    }
    .tbl_cart td
    {
        padding:15px; 
    }
    .tbl_cart #header_row td 
    {
        font-weight:bold;
        border-bottom:1px solid black;
        text-align:center;
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
    @keyframes changeColor
    {
        0%{filter:blur(4px);color:black;}
        90%{filter:blur(0px);color:black;}
        100%{display:none;}
    }
    
 </style>
</head>
<body>
<form id="form1" runat="server">
<table id="main">
<tr>
    <td>
        <div class="header">
            <ul>
                <li>
                    <asp:Button ID="cart_btn" CssClass="swap-btn" UseSubmitBehavior="false" 
                        CausesValidation="false"  runat="server" Text="My Cart" 
                        onclick="cart_btn_Click" />
                </li>
                <li>
                    <asp:Button ID="user_dtl_btn" CssClass="swap-btn" UseSubmitBehavior="false" 
                        CausesValidation="false"  runat="server" Text="My Details" 
                        onclick="user_dtl_btn_Click" />
                </li>
                <li style="margin-left:80%;margin-top:-25px;"><a href="user_home.aspx"><asp:Button ID="home_btn" UseSubmitBehavior="false" CausesValidation="false" CssClass="swap-btn" runat="server" Text="Back To Home" /></a></li>
                <li style="margin-left:90%;margin-top:-40px;">
                  
                        <button class="logout">
                            <a style="color:Black;text-decoration:none;padding:0px" href="logout.aspx"><img src="img/proj_img/logout.png" width="25px" height="25px" />LOGOUT</a>
                        </button>
                        
                   
                </li>
                
            </ul>    
        </div>     
    </td>
</tr>
<tr>
    <td>
    
        <asp:Table ID="tbl_filter" runat="server" ClientIDMode="Static">
                <asp:TableRow>
                    <asp:TableCell>
                        Display:
                        <asp:DropDownList ID="drop_sort" runat="server" CssClass="select" 
            ClientIDMode="Static" AutoPostBack="true" 
            onselectedindexchanged="drop_sort_SelectedIndexChanged">
                            <asp:ListItem Value="0" Selected="True">--Select Something--</asp:ListItem>
                            <asp:ListItem Value="1">Cart </asp:ListItem>
                            <asp:ListItem Value="2">Requested Orders</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
           </asp:Table>
            <asp:Label ID="lbl_success" CssClass="label" runat="server" Text=""></asp:Label>
        <asp:Panel ID="cart_panel" ClientIDMode="Static" runat="server">
        <h2>My Cart</h2>
                   
         <asp:Panel ID="cart_tbl_panel" runat="server">
         <table class="tbl_cart">
         <asp:Repeater ID="cart_repeat" runat="server" 
                onitemdatabound="cart_repeat_ItemDataBound" 
                 onitemcommand="cart_repeat_ItemCommand">
                        <HeaderTemplate>
                            <tr id="header_row">
                                <td>Product<br />Name</td>
                                <td>Product<br />Category</td>
                                <td>Product<br />Brand</td>
                                <td>Seller<br />Name</td>
                                <td>Seller<br />Contact</td>
                                <td>Seller<br />Email</td>
                                <td>Seller<br />Address</td>
                                <td>Available<br />Quantity</td>
                                <td>Your<br />Ask</td>
                                <td></td>
                            </tr>
                        </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("p_name") %></td>
                                    <td><%# Eval("p_cat_name") %></td>
                                    <td><%# Eval("p_brand_name") %></td>
                                    <td><%# Eval("sel_name") %></td>
                                    <td><%# Eval("sel_contact") %></td>
                                    <td><%# Eval("sel_email") %></td>
                                    <td><%# Eval("sel_address") %></td>
                                    <td><asp:Label ID="lbl_quan" runat="server" Text='<%# Eval("p_quan") %>'></asp:Label></td>
                                    <td><%# Eval("cart_quan") %></td>
                                    <td>
                                            <asp:Button ID="pur_btn" runat="server" style="width:75px;" CssClass="swap-btn" CommandName="purchase" CommandArgument='<%# Eval("cart_id") %>' Text="Purchase" />
                                            
                                            <asp:Button ID="remove_btn" runat="server" style="width:75px;" CssClass="swap-btn" CommandName="del" CommandArgument='<%# Eval("cart_id") %>' Text="Remove" />
                                            <asp:Label ID="lbl_err" runat="server" Text="Out Of Stock"></asp:Label>   

                                            <a href='order.aspx?p_id=<%# Eval("p_id") %>''><asp:Button ID="prod_btn" UseSubmitBehavior="false" runat="server" style="width:120px" CssClass="swap-btn" Text="Product Details" /></a>
                                            
                                    </td>
                                </tr>
                            
                            </ItemTemplate>
                    </asp:Repeater>
            </table>
             </asp:Panel>  
             -- End Of List --
            </asp:Panel>
        <asp:Panel ID="req_panel" ClientIDMode="Static" Visible="false" runat="server">
            <h2>Requested Orders</h2>
            <asp:Panel ID="req_tbl_panel" runat="server">
            <table class="tbl_cart">
                <asp:Repeater ID="req_repeat" runat="server" 
                    onitemcommand="req_repeat_ItemCommand">
                        <HeaderTemplate>
                            <tr id="header_row">
                                <td>Product<br />Name</td>
                                <td>Product<br />Category</td>
                                <td>Product<br />Brand</td>
                                <td>Seller<br />Name</td>
                                <td>Seller<br />Contact</td>
                                <td>Seller<br />Email</td>
                                <td>Seller<br />Address</td>
                                <td>Quantity</td>
                                <td>Price</td>
                                <td>Order<br />Requested<br />Date</td>
                                <td></td>
                            </tr>
                        </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("p_name") %></td>
                                    <td><%# Eval("p_cat_name") %></td>
                                    <td><%# Eval("p_brand_name") %></td>
                                    <td><%# Eval("sel_name") %></td>
                                    <td><%# Eval("sel_contact") %></td>
                                    <td><%# Eval("sel_email") %></td>
                                    <td><%# Eval("sel_address") %></td>
                                    <td><%# Eval("o_quan") %></td>
                                    <td><%# Eval("o_price") %></td>
                                    <td><%# Eval("o_date") %></td>
                                    <td>
                                        <asp:Button ID="can_btn" runat="server" style="width:auto" CssClass="swap-btn" CommandName="cancel" CommandArgument='<%# Eval("o_id") %>' Text="Cancel Order Request" />

                                    </td>
                                    <td>
                                            
                                            <a href='order.aspx?p_id=<%# Eval("p_id") %>''><asp:Button ID="prod_btn" UseSubmitBehavior="false" runat="server" style="width:120px" CssClass="swap-btn" Text="Product Details" /></a>
                                            
                                    </td>
                                </tr>
                            
                            </ItemTemplate>
                    </asp:Repeater>
            </table>
            </asp:Panel>
            
            -- End Of List --
        </asp:Panel>
        <asp:Panel ID="dtl_panel" ClientIDMode="Static" Visible="false" runat="server">
            <h2>Purchase Hitory</h2>
            <asp:Panel ID="pur_tbl_panel" runat="server">
            <table class="tbl_cart">
                <asp:Repeater ID="pur_repeat" runat="server">
                        <HeaderTemplate>
                            <tr id="header_row">
                                <td>Product<br />Name</td>
                                <td>Product<br />Category</td>
                                <td>Product<br />Brand</td>
                                <td>Seller<br />Name</td>
                                <td>Seller<br />Contact</td>
                                <td>Seller<br />Email</td>
                                <td>Seller<br />Address</td>
                                <td>Quantity</td>
                                <td>Price</td>
                                <td>Order<br />Requested<br />Date</td>
                                <td></td>
                            </tr>
                        </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("p_name") %></td>
                                    <td><%# Eval("p_cat_name") %></td>
                                    <td><%# Eval("p_brand_name") %></td>
                                    <td><%# Eval("sel_name") %></td>
                                    <td><%# Eval("sel_contact") %></td>
                                    <td><%# Eval("sel_email") %></td>
                                    <td><%# Eval("sel_address") %></td>
                                    <td><%# Eval("o_quan") %></td>
                                    <td><%# Eval("o_price") %></td>
                                    <td><%# Eval("o_date") %></td>
                                    <td><%# Eval("o_sub_date") %></td>
                                    <td>
                                            
                                            <a href='order.aspx?p_id=<%# Eval("p_id") %>''><asp:Button ID="prod_btn" UseSubmitBehavior="false" runat="server" style="width:120px" CssClass="swap-btn" Text="Product Details" /></a>
                                            
                                    </td>
                                </tr>
                            
                            </ItemTemplate>
                    </asp:Repeater>
            </table>
            </asp:Panel>
            -- End Of List --            
        </asp:Panel>
    </td>
</tr>
</table>
</form>
</body>
</html>
