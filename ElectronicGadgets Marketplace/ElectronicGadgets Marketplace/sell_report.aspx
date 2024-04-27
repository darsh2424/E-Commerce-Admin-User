<%@ Page Title="" Language="C#" MasterPageFile="~/sell_mst.Master" AutoEventWireup="true" CodeBehind="sell_report.aspx.cs" Inherits="ElectronicGadgets_Marketplace.sell_report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
#report_form table
{
    border-spacing:10px;
    font-size:1.1rem;
}
#prod_dgv
{
    text-align:center;
    margin-left:100px;
    width:80%;
}
select
{
             margin-left:25px;
             background-color:#FFFFF0;  
             padding:3px;   
             font-size:15px;
             border-radius:5px;
             outline:none;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="report_form" runat="server">
    <asp:Panel ID="select_panel" runat="server">
        <table style="margin-left:5%" id="main-tbl" width="85%">
            <tr>
                <td>
                    <table id="sort-tbl" width="85%">
                        <tr>
                            <td width="50%">
                                <div style="margin-left:100px">
                                    Select Category:
                                <asp:DropDownList AutoPostBack="true" ID="drop_cat" ClientIDMode="Static" runat="server" 
                                    onselectedindexchanged="drop_cat_SelectedIndexChanged">
                                </asp:DropDownList>
                                </div>
                                
                            </td>
                            <td>
                                <div style="margin-left:100px">
                                    Select Brand:
                                     <asp:DropDownList AutoPostBack="true" ID="drop_manu" ClientIDMode="Static" runat="server" 
                                    onselectedindexchanged="drop_manu_SelectedIndexChanged" >
                                        </asp:DropDownList>
                                </div>
                                
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table ID="prod-tbl" style="margin-left:30%">
                    <tr>
                    <td align="center">
                        Select Product Name:
                    </td>
                    <td>
                        <asp:DropDownList AutoPostBack="true" ID="drop_pname" Enabled=false 
                            ClientIDMode="Static" runat="server" 
                            onselectedindexchanged="drop_pname_SelectedIndexChanged" Width="150px">
                                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
                </td>
            </tr>
            
        </table>
    </asp:Panel>
<asp:GridView ID="prod_dgv" style="margin-left:5%" ClientIDMode="Static" 
        runat="server" BackColor="White" 
        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" GridLines="Horizontal" AllowSorting="True">
    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#F7F7F7" />
    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
    <SortedDescendingCellStyle BackColor="#E5E5E5" />
    <SortedDescendingHeaderStyle BackColor="#242121" />
   
</asp:GridView>
</form>
</asp:Content>
