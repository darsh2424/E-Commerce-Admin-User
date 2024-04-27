<%@ Page Title="" Language="C#" MasterPageFile="~/sell_mst.Master" AutoEventWireup="true" CodeBehind="sell_home.aspx.cs" Inherits="ElectronicGadgets_Marketplace.sell_home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
   
    #home_nav_tr
    {
        height:10%;
    }
    #content_div
     {
         border:1px solid black;
         margin:2%;
     }   
    .swap-btn
        {
            background:White;
            
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
    .tbl_cart
    {
        margin-top:25px;
        border-spacing:10px;
        
    }
    
    .tbl_cart td 
    {
        width:300px;
        padding:5px;
    }
 
    .tbl_cart #header_row td 
    {
        border-bottom:1px solid black;
        font-weight:bolder;
        text-align:center;
    }
    .label
    {
        font-weight:bolder;
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
    <table id="home_main" style="margin-top:50px;">
        <tr id="home_nav_tr">
            <td>
                <asp:Button ID="order_disp" CausesValidation="false" 
                    CssClass="swap-btn home_nav_btn" runat="server" Text="Orders" 
                    onclick="order_disp_Click" />
                <asp:Button ID="stock_disp" CausesValidation="false" 
                    CssClass="swap-btn home_nav_btn" runat="server" Text="Stock" 
                    onclick="stock_disp_Click" />
            </td>
        </tr>
        <tr>
            <td id="content_td" valign="top">

         <asp:Label ID="lbl_success" CssClass="label" runat="server" Text=""></asp:Label>
          <asp:Panel ID="order_panel" runat="server">
            <asp:Table ID="tbl_filter" runat="server" style="margin-top:20px" ClientIDMode="Static">
                <asp:TableRow>
                    <asp:TableCell>
                        Display:
                        <asp:DropDownList ID="drop_sort" runat="server" CssClass="select" 
            ClientIDMode="Static" AutoPostBack="true" 
            onselectedindexchanged="drop_sort_SelectedIndexChanged">
                            <asp:ListItem Value="0" Selected="True">--Select Something--</asp:ListItem>
                            <asp:ListItem Value="1">Requested Orders </asp:ListItem>
                            <asp:ListItem Value="2">Submitted Orders </asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
           </asp:Table>    
             <asp:Panel ID="req" runat="server">
             
             <table class="tbl_cart">
                <asp:Repeater ID="req_repeat" runat="server" onitemcommand="req_repeat_ItemCommand">
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
                                <td></td>
                            </tr>
                        </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("p_name") %></td>
                                    <td><%# Eval("p_cat_name") %></td>
                                    <td><%# Eval("p_brand_name") %></td>
                                    <td><%# Eval("user_name") %></td>
                                    <td><%# Eval("user_contact") %></td>
                                    <td><%# Eval("user_email") %></td>
                                    <td><%# Eval("user_address") %></td>
                                    <td><%# Eval("o_quan") %></td>
                                    <td><%# Eval("o_price") %></td>
                                    <td><%# Eval("o_date") %></td>
                                    <td>
                                        <asp:Button ID="can_btn" runat="server" style="width:auto" CssClass="swap-btn" CommandName="cancel" CommandArgument='<%# Eval("o_id") %>' Text="Cancel Order Request" />        
                                        <br /><br /> 
                                        <asp:Button ID="Button1" runat="server" style="width:auto" CssClass="swap-btn" CommandName="submit" CommandArgument='<%# Eval("o_id") %>' Text="Order Submitted" />
                                                                     
                                    </td>
                                    <td>
                                         <a href='sell_prod.aspx?p_id=<%# Eval("p_id") %>''><asp:Button ID="prod_btn" UseSubmitBehavior="false" runat="server" style="width:120px" CssClass="swap-btn" Text="Product Details" /></a>
                                    </td>
                                </tr>
                            
                            </ItemTemplate>
                    </asp:Repeater>
            </table>
           </asp:Panel>
             <asp:Panel ID="sub" runat="server">
             <table class="tbl_cart">
                <asp:Repeater ID="sub_repeat" runat="server">
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
                                <td>Order <br /> Submitted <br /> Date</td>
                                <td></td>
                            </tr>
                        </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("p_name") %></td>
                                    <td><%# Eval("p_cat_name") %></td>
                                    <td><%# Eval("p_brand_name") %></td>
                                    <td><%# Eval("user_name") %></td>
                                    <td><%# Eval("user_contact") %></td>
                                    <td><%# Eval("user_email") %></td>
                                    <td><%# Eval("user_address") %></td>
                                    <td><%# Eval("o_quan") %></td>
                                    <td><%# Eval("o_price") %></td>
                                    <td><%# Eval("o_date") %></td>
                                    <td>
                                        <%# Eval("o_sub_date") %>                           
                                    </td>
                                    <td>
                                         <a href='sell_prod.aspx?p_id=<%# Eval("p_id") %>''><asp:Button ID="prod_btn" UseSubmitBehavior="false" runat="server" style="width:120px" CssClass="swap-btn" Text="Product Details" /></a>
                                    </td>
                                </tr>
                            
                            </ItemTemplate>
                    </asp:Repeater>
            </table>
           </asp:Panel>   

                </asp:Panel>
                <asp:Panel ID="stock_panel" style="margin-left:10px" runat="server">
                    <table class="tbl_cart">
                <asp:Repeater ID="stock_repeat" runat="server">
                        <HeaderTemplate>
                            <tr id="header_row">
                                <td>Product<br />Image</td>
                                <td>Product<br />Name</td>
                                <td>Product<br />Category</td>
                                <td>Product<br />Brand</td>
                                <td>Quantity</td>
                                <td>Price</td>
                            </tr>
                        </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <img src='img/prod_img/<%# Eval("p_img") %>' height="100" width="100" />
                                    </td>
                                    <td><%# Eval("p_name") %></td>
                                    <td><%# Eval("p_cat_name") %></td>
                                    <td><%# Eval("p_brand_name") %></td>
                                    <td><%# Eval("p_quan") %></td>
                                    <td><%# Eval("p_price") %></td>
                                    <td>
                                         <a href='sell_prod.aspx?p_id=<%# Eval("p_id") %>''><asp:Button ID="prod_btn" UseSubmitBehavior="false" runat="server" style="width:120px" CssClass="swap-btn" Text="Product Details" /></a>
                                    </td>
                                </tr>
                            
                            </ItemTemplate>
                    </asp:Repeater>
            </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</form>
</asp:Content>
