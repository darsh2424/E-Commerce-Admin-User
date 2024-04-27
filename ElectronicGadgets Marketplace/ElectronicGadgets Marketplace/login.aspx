<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ElectronicGadgets_Marketplace.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        /** #C2D8D3 #EBF6F7  **/
        body
        {   
            padding:0px;
            margin:0px;
            font-size:1.3rem;
            /** #f4fcf8 background-repeat:no-repeat;
            background-position:center; **/
        }
        input[type="text"],input[type="password"]
        {
            border:none;
            border-bottom:1px solid black;
            width:250px;
        }

        #master-tbl .first
        {
            width:10%;
            height:700px;
        }
        #main-div
        {
            width:80%;
            margin-top:10%;
            margin-left:10%;
            /** #ffffff  border:1px solid black;    animation:changeColor 2s;**/
            box-shadow: 0 45px 65px rgba(0,0,0,0.50);
            
        }
        .swap-btn
        {
            background:White;
            font-weight:bold;
            width:150px;
            height:35px;
            margin-left:10%;
            margin-top:2%;
        }
        .swap-btn:hover
        {
            background:black;
            color:White;
            border:none;
            cursor:pointer;
            
        }
        #ven_tbl,#user_tbl
        {
            width:70%;
            border-spacing:10px;
            display:none;
        }
        #ven_tbl
        {
            margin-left:10%;
        }
        
        .main-tbl 
        {
            width:50%;
            height:380px;
            float:left;
        }
        
        .error_msg
        {
            font-size:15px;
            color:Red;
        } 
        @keyframes changeColor
        {
                from{filter:blur(4px);color:#6a5a54;}
                to {filter:blur(0px);color:black;}
        } 
        input[type="text"]:focus,input[type="password"]:focus
         {
             outline:none;
         }
        @media (min-width:320px) and (max-width:1250px)  
        {
            #main-div
            {
                width:60%;
                height:50%;
                margin-left:2%;
                margin-top:5%;
                box-shadow:none;
            }
            #man-back
            {
               width:150px;
               height:120px;
            }
            .main-tbl
            {
            width:720px;
            height:300px;
            margin:10px;
            background:#ffffff;
            border:1px solid black;    /**animation:changeColor 2s;**/
            box-shadow: 0 45px 65px rgba(0,0,0,0.50);
            }
            
            #master-tbl
            {
                margin-top:25%;
            }

        }
    </style>
    <script type="text/javascript">

    function load_sel() {
        document.getElementById('ven_div').style.animation = "changeColor 1s";
        setTimeout(check_ven, 1000);
    }
    function load_user() {
        
        document.getElementById('user_div').style.animation = "changeColor 1s";
        setTimeout(check_user, 1000);
    }
    function check_ven() {
        document.getElementById('ven_tbl').style = "display:block";
        document.getElementById('ven_div').style = "display:none";
        document.getElementById('user_div').style = "display:inline";
        document.getElementById('user_tbl').style = "display:none";
        
    }
    function check_user() {
        document.getElementById('user_tbl').style = "display:block";
        document.getElementById('user_div').style = "display:none";
        document.getElementById('ven_div').style = "display:inline";
        document.getElementById('ven_tbl').style = "display:none";
        
    }
    </script>
</head>
<body>
<form runat="server">
<table id="master-tbl" width="100%">
<tr>
<td class="first" style="background:url('img/proj_img/back_left.png') no-repeat;"></td>
<td>
 <table id="main-div">
 <tr>
 <td> 
    <table class="main-tbl">
        <tr>
            <td>
               <div id="ven_div" runat="server">
                    <table id="ven-div-tbl">
                        <tr>
                            <td>
                                  <table>
                                    <tr valign="middle">
                                        <td><img id="man-back" src="img/proj_img/back_man.png" width="200px" height="200px" /></td>
                                        <td><span style="font-weight:bolder;font-family:Arial Black;">Login As Seller?</span><br />
                                            <input type="button" class="swap-btn" runat="server" id="ven_visi_btn" value="Click Here!" causesvalidation="false" onclick="load_sel();" />
                                        </td>
                                    </tr>
                                  </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <table id="ven_tbl" runat="server">
                    <tr>
                        <td><h3>Seller Login</h3></td>
                    </tr>
                    <tr>
                        <td>Username:</td>
                    </tr>
                    <tr>
                        <td><input type="text" id="txt_sel_name" name="txt_sel_name" runat="server"  />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>Password:</td>
                    </tr>
                    <tr align="right">
                        <td><input id="txt_sel_pass" type="password" name="txt_sel_pass" runat="server"  />
                            <br />
                            <asp:Label ID="lbl_sel_err" runat="server" Text="" CssClass="error_msg"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="sel_sub" runat="server" name="sel_sub" class="swap-btn" style="width:100px;" Text="LOGIN" UseSubmitBehavior="false" OnClick="sel_sub_Click" />

                            </td>
                    </tr>
                </table>               
            </td>
       </tr>
   </table>
    <table class="main-tbl" style="margin-top:10px;">
   <tr>
            <td>
               
               <div id="user_div" runat="server">
                    <table id="user-div-tbl">
                        <tr>
                            <td>
                                  <table>
                                    <tr valign="middle">
                                        <td width="50%" align="right"><span style="font-weight:bolder;font-family:Arial Black;">Login As User? </span><br />
                                               <input type="button" class="swap-btn" runat="server" id="user_visi_btn" value="Click Here!" causesvalidation="false" onclick="load_user();" />
                                        </td>
                                        <td><img id="kid-back" src="img/proj_img/back_kid.png" width="100%"/></td>
                                    </tr>
                                  </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <table id="user_tbl" runat="server">
                    <tr>
                        <td><h3>User Login</h3></td>
                    </tr>
                    <tr>
                        <td>Username:</td>
                    </tr>
                    <tr>
                        <td><input type="text" id="txt_user_name" name="txt_user_name" runat="server"  />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>Password:</td>
                    </tr>
                    <tr align="right">
                        <td><input id="txt_user_pass" type="password" name="txt_user_pass" runat="server"  />
                            <br />
                            <asp:Label ID="lbl_user_err" runat="server" Text="" CssClass="error_msg"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="user_sub" runat="server" name="user_sub" class="swap-btn" style="width:100px;" Text="LOGIN" UseSubmitBehavior="false" OnClick="user_sub_Click" />

                            </td>
                    </tr>
                </table>    
                    
            </td>
        </tr>
        </table>
</td>
</tr>
 <tr>
     <td colspan="2" align="center" style="height:50px;padding-top:25px;"><a href="register.aspx" style="text-decoration:none;font-weight:bolder;">New User? </a></td>
</tr>
<tr>
    <td colspan="2" align="center"><a href="user_home.aspx" style="text-decoration:none;font-weight:bolder;">Back To Home </a></td>
</tr>
</table></td>
<td class="first" style="background:url('img/proj_img/back_right.png') no-repeat right;"></td>
</tr>
</table>
                        
 </form>
 </body>
</html>
