<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="ElectronicGadgets_Marketplace.register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
     body
        {
            background-color:#f4fcf8;
            overflow:hidden;
            font-size:1.2rem; 
        } 
     input[type="text"],input[type="password"]
     {
         border:none;
         border-bottom:1px solid black;
     }
     #navbar
        {
            width:100%;
            margin-left:7%;
            margin-top:7%;
            padding-bottom:10px;
        }
     #swap-frm
        {
            width:80%;
            margin-left:7%;
            padding:10px;
            background:#ffffff;
           /** border:1px solid black;  animation:changeColor 2s;**/
            box-shadow: 0 45px 65px rgba(0,0,0,0.50), 0 35px 22px rgba(0,0,0,0.16);
            
        }
      .swap-btn
        {
            background:White;
            font-weight:bold;
            width:100px;
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
     .swap-win
        {
            /**border:1px solid black;**/
            padding-top:10px;
            display:none;
        }
      
        
      @keyframes changeColor
        {
                from{filter:blur(4px);color:black;}
                to{filter:blur(0px);color:#6a5a54;}
        } 
        
        
        .frm-dtl1
        {
            width:55%;
            float:left;
            display:inline;
            text-align:right;
        }
        .frm-dtl2
        {
           width:40%; 
           display:inline;
           float:right;
           text-align:right;
        }
        .frm-lbl
        {
            width:50%;
            padding-right:10px;
        }
        .frm-input
        {
            width:50%;
        }
        .frm-lbl,.frm-input
        {
            display:inline;
        }
        
        #user-reg-tbl .first-td, #sel-reg-tbl .first-td
        {
            width:80%;
            
        }
        #swap-frm .swap-btn
        {
               margin-left:70%;margin-top:2%;width:200px;box-shadow:none;border:1px solid black;
        }
        .error_msg
        {
            font-size:15px;
            color:Red;
        } 
         @media (min-width:320px) and (max-width:1280px)  
         {
             body
             {
                 font-size:1.2rem;
                 overflow:scroll;
             }
             .frm-dtl1
             {
                 display:block;
                 float:none;
                 text-align:right;
                 width:100%;
             }
             .frm-dtl2
             {
                 display:block;
                 float:none;
                 text-align:right;
                 width:100%;
             }
             #main
             {
                 margin-top:15%;
             }
             #user-reg-tbl #first-td, #sel-reg-tbl #first-td
            {
                width:70%;
            }
            #swap-frm .swap-btn
            {
               margin-left:60%;
            }
            
         }
    </style>
    <script type="text/javascript">
        var click_btn = "user";
        function load_sel() {
            click_btn = "seller";
            setTimeout(change_win,500);
        }
        function load_user() {
            click_btn = "user";
            setTimeout(change_win,500);        
        }
        function change_win() {
        document.getElementById('swap-frm').style.animation = "changeColor 1s";
       
        if (click_btn == "user") {
            document.getElementById('user-reg-tbl').style.display="block";
            document.getElementById('sel-reg-tbl').style.display = "none";
        }
        else if (click_btn == "seller") {
            document.getElementById('sel-reg-tbl').style.display = "block";
            document.getElementById('user-reg-tbl').style.display = "none";
        }


    }
    function change_text() {
        document.getElementById('username_err').value = "";
    }
    </script>
</head>
<body onload="change_win();">
<form id="main" runat="server">
    <table id="navbar">
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="User" class="swap-btn" onclick="Button1_Click" CausesValidation="false" UseSubmitBehavior="False" />
                <asp:Button ID="Button2" runat="server" Text="Seller" class="swap-btn" onclick="Button2_Click"  CausesValidation="false" UseSubmitBehavior="False" />
           </td>
        </tr>
    </table>


    <div id="swap-frm">
        
        <asp:Panel ID="user_panel" runat="server">
        <table id="user-reg-tbl" class="swap-win">
        <tr valign="top">
            <td class="first-td">
                
                <form id="user_form" method="post">
                <table  width="100%">
                    <tr>
                        <td>
                            <div class="frm-dtl1">
                                <div class="frm-lbl">Enter Your Username:</div>
                                <div class="frm-input">
                                    <input type="text" name="txt_user_name" id="txt_user_name" class="user-frm-text" placeholder="ex. electro_11" runat="server" onmouseout="change_text();" /><br />
                                    <asp:Label ID="username_err" runat="server"  Text="" CssClass="error_msg user_error"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="txt_user_name" ErrorMessage="*Field can not be Empty" 
                                        Display="Dynamic" CssClass="error_msg user_error"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                         ControlToValidate="txt_user_name" runat="server" 
                                         ErrorMessage="*Length Must Be 5 to 15  <br> Use Only Alphabets-Numbers-Underscore" 
                                         ValidationExpression="^[A-Za-z][A-Za-z0-9_]{5,15}" Display="Dynamic" 
                                        CssClass="error_msg user_error"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="frm-dtl1">
                                <div class="frm-lbl">Enter Your Email:</div>
                                <div class="frm-input">
                                     <input type="text" name="txt_user_email" id="txt_user_email" class="user-frm-text" placeholder="ex. abc@gmail.com" runat="server" /><br />
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="txt_user_email" ErrorMessage="*Field can not be Empty" 
                                        Display="Dynamic" CssClass="error_msg user_error"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                                         ControlToValidate="txt_user_email" runat="server" 
                                         ErrorMessage="*Invalid Email address" 
                                         ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" 
                                        CssClass="error_msg  user_error"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="frm-dtl2">
                                <div class="frm-lbl">Enter Your Contact:</div>
                                <div class="frm-input">
                                     <input type="text" name="txt_user_con" id="txt_user_con" class="user-frm-text" placeholder="Must Be 10 Digits Only!" runat="server" /><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ControlToValidate="txt_user_con" ErrorMessage="*Field can not be Empty" 
                                        Display="Dynamic" CssClass="error_msg  user_error"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" 
                                         ControlToValidate="txt_user_con" runat="server" 
                                         ErrorMessage="*Invalid Contact No" 
                                         ValidationExpression="^[0-9]{10}" Display="Dynamic" 
                                        CssClass="error_msg  user_error"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="frm-dtl1">
                                <div class="frm-lbl">Enter Your Password:</div>
                                <div class="frm-input">
                                     <input type="password" name="txt_user_pass" id="txt_user_pass" class="user-frm-text" runat="server"/><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                        ControlToValidate="txt_user_pass" ErrorMessage="*Field can not be Empty" 
                                        Display="Dynamic" CssClass="error_msg  user_error"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" 
                                         ControlToValidate="txt_user_pass" runat="server" 
                                         ErrorMessage="*Minimum five characters<br>At least one letter, one number <br> and one special character" 
                                         ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&amp;])[A-Za-z\d@$!%*#?&amp;]{5,}$" Display="Dynamic" 
                                        CssClass="error_msg  user_error"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="frm-dtl2">
                                <div class="frm-lbl">Enter Password Again:</div>
                                <div class="frm-input">
                                     <input type="password" name="txt_user_conf" id="txt_user_conf" class="user-frm-text" runat="server"/><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                        ControlToValidate="txt_user_conf" ErrorMessage="*Field can not be Empty" 
                                        Display="Dynamic" CssClass="error_msg  user_error"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:CompareValidator ID="CompareValidator1" runat="server"  
                                         ErrorMessage="*Must be Same" Display="Dynamic" CssClass="error_msg  user_error" 
                                         ControlToCompare="txt_user_pass" ControlToValidate="txt_user_conf"></asp:CompareValidator>
                                    
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="frm-dtl1">
                                <div class="frm-lbl">Enter Address Line1:</div>
                                <div class="frm-input">
                                     <input type="text" name="txt_user_add1" id="txt_user_add1" class="user-frm-text" placeholder="ex. house no./flat no. and society/apartments" runat="server"/><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                        ControlToValidate="txt_user_add1" ErrorMessage="*Field can not be Empty" 
                                        Display="Dynamic" CssClass="error_msg  user_error"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" 
                                         ControlToValidate="txt_user_add1" runat="server" 
                                         ErrorMessage="*Minimuum 5 characters<br>Use Alphabets-Digits-Space etc." 
                                         ValidationExpression="^[A-Za-z0-9'\.\-\s\,]{5,}" Display="Dynamic" 
                                        CssClass="error_msg  user_error"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="frm-dtl2">
                                <div class="frm-lbl">Enter Address Line2:</div>
                                <div class="frm-input">
                                     <input type="text" name="txt_user_add2" id="txt_user_add2" class="user-frm-text" placeholder="ex. landmark" runat="server"/><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                        ControlToValidate="txt_user_add2" ErrorMessage="*Field can not be Empty" 
                                        Display="Dynamic" CssClass="error_msg  user_error"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" 
                                         ControlToValidate="txt_user_add2" runat="server" 
                                         ErrorMessage="*Minimuum 5 characters<br>Use Alphabets-Digits-Space etc." 
                                         ValidationExpression="^[A-Za-z0-9'\.\-\s\,]{5,}" Display="Dynamic" 
                                        CssClass="error_msg  user_error"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="frm-dtl1">
                                <div class="frm-lbl">Enter City:</div>
                                <div class="frm-input">
                                     <input type="text" name="txt_user_city" id="txt_user_city" class="user-frm-text" placeholder="ex. Anand" runat="server"/><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                        ControlToValidate="txt_user_city" ErrorMessage="*Field can not be Empty" 
                                        Display="Dynamic" CssClass="error_msg  user_error"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" 
                                         ControlToValidate="txt_user_city" runat="server" 
                                         ErrorMessage="*Length Must Be 3 to 15  - Use Only Alphabets" 
                                         ValidationExpression="^[A-Za-z]{3,15}" Display="Dynamic" 
                                        CssClass="error_msg  user_error"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="frm-dtl2">
                                <div class="frm-lbl">Enter Pincode:</div>
                                <div class="frm-input">
                                     <input type="text" name="txt_user_pin" id="txt_user_pin" class="user-frm-text" placeholder=" 6 digit zipcode/postalcode" runat="server"/><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                        ControlToValidate="txt_user_pin" ErrorMessage="*Field can not be Empty" 
                                        Display="Dynamic" CssClass="error_msg  user_error"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" 
                                         ControlToValidate="txt_user_pin" runat="server" 
                                         ErrorMessage="*Invalid PinCode" 
                                         ValidationExpression="\d{6}" Display="Dynamic" 
                                        CssClass="error_msg  user_error"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="frm-dtl1">
                                <div class="frm-lbl">Enter State:</div>
                                <div class="frm-input">
                                     <input type="text" name="txt_user_state" id="txt_user_state" class="user-frm-text" placeholder="ex. Gujarat" runat="server"/><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                        ControlToValidate="txt_user_state" ErrorMessage="*Field can not be Empty" 
                                        Display="Dynamic" CssClass="error_msg  user_error"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" 
                                         ControlToValidate="txt_user_state" runat="server" 
                                         ErrorMessage="*Length Must Be 3 to 15  - Use Only Alphabets" 
                                         ValidationExpression="^[A-Za-z]{3,15}" Display="Dynamic" 
                                        CssClass="error_msg  user_error"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button id="user_sub_btn" runat="server" class="swap-btn" Text="Submit" onclick="user_sub_btn_Click"/>
                        </td>
                    </tr>
                    </table>
                    </form>
                
            </td>
            
            <td valign="bottom">
                <img src="img/proj_img/back_kid.png" width="110%"/>
            </td>
        </tr>
        </table>
        </asp:Panel>
        <asp:Panel ID="seller_panel" runat="server">
        <table id="sel-reg-tbl" class="swap-win">
        <tr>
            <td class="first-td">
            
            <form id="sel_from" method="post" enctype="multipart/form-data">
                <table  width="100%">
                    <tr>
                        <td>
                            <div class="frm-dtl1">
                                <div class="frm-lbl">Enter Your Username:</div>
                                <div class="frm-input">
                                    <input type="text" name="txt_sel_name" id="txt_sel_name" class="sel-frm-text" placeholder="ex. electro_11" runat="server" /><br />
                                    <asp:Label ID="selname_err" runat="server"  Text="" CssClass="error_msg sell_error"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                        ControlToValidate="txt_sel_name" ErrorMessage="*Field can not be Empty" 
                                        Display="Dynamic" CssClass="error_msg  sel_error"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" 
                                         ControlToValidate="txt_sel_name" runat="server" 
                                         ErrorMessage="*Length Must Be 5 to 25 <br> Use Only Alphabets-Numbers-Underscore" 
                                         ValidationExpression="^[A-Za-z][A-Za-z0-9_]{5,25}" Display="Dynamic" 
                                        CssClass="error_msg  sel_error"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="frm-dtl1">
                                <div class="frm-lbl">Enter Your Email:</div>
                                <div class="frm-input">
                                     <input type="text" name="txt_sel_email" id="txt_sel_email" class="sel-frm-text" placeholder="ex. abc@gmail.com" runat="server" /><br />
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                        ControlToValidate="txt_sel_email" ErrorMessage="*Field can not be Empty" 
                                        Display="Dynamic" CssClass="error_msg  sel_error"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator11" 
                                         ControlToValidate="txt_sel_email" runat="server" 
                                         ErrorMessage="*Invalid Email address" 
                                         ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" 
                                        CssClass="error_msg  sel_error"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="frm-dtl2">
                                <div class="frm-lbl">Enter Your Contact:</div>
                                <div class="frm-input">
                                     <input type="text" name="txt_sel_con" id="txt_sel_con" class="sel-frm-text" placeholder="Must Be 10 Digits Only!" runat="server" /><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                        ControlToValidate="txt_sel_con" ErrorMessage="*Field can not be Empty" 
                                        Display="Dynamic" CssClass="error_msg  sel_error"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator12" 
                                         ControlToValidate="txt_sel_con" runat="server" 
                                         ErrorMessage="*Invalid Contact No" 
                                         ValidationExpression="^[0-9]{10}" Display="Dynamic" 
                                        CssClass="error_msg  sel_error"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="frm-dtl1">
                                <div class="frm-lbl">Enter Your Password:</div>
                                <div class="frm-input">
                                     <input type="password" name="txt_sel_pass" id="txt_sel_pass" class="sel-frm-text" runat="server"/><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                                        ControlToValidate="txt_sel_pass" ErrorMessage="*Field can not be Empty" 
                                        Display="Dynamic" CssClass="error_msg  sel_error"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator13" 
                                         ControlToValidate="txt_sel_pass" runat="server" 
                                         ErrorMessage="*Minimum five characters<br>At least one letter, one number <br> and one special character" 
                                         ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&amp;])[A-Za-z\d@$!%*#?&amp;]{5,}$" Display="Dynamic" 
                                        CssClass="error_msg  sel_error"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="frm-dtl2">
                                <div class="frm-lbl">Enter Password Again:</div>
                                <div class="frm-input">
                                     <input type="password" name="txt_sel_conf" id="txt_sel_conf" class="sel-frm-text" runat="server"/><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                                        ControlToValidate="txt_sel_conf" ErrorMessage="*Field can not be Empty" 
                                        Display="Dynamic" CssClass="error_msg  sel_error"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:CompareValidator ID="CompareValidator2" runat="server"  
                                         ErrorMessage="*Must be Same" Display="Dynamic" CssClass="error_msg  sel_error" 
                                         ControlToCompare="txt_sel_pass" ControlToValidate="txt_sel_conf"></asp:CompareValidator>
                                    
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="frm-dtl1">
                                <div class="frm-lbl">Enter Address:</div>
                                <div class="frm-input">
                                     <input type="text" name="txt_sel_add1" id="txt_sel_add1" class="sel-frm-text" placeholder="ex. house no./flat no. and society/apartments" runat="server"/><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                                        ControlToValidate="txt_sel_add1" ErrorMessage="*Field can not be Empty" 
                                        Display="Dynamic" CssClass="error_msg  sel_error"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator14" 
                                         ControlToValidate="txt_sel_add1" runat="server" 
                                         ErrorMessage="*Minimuum 5 characters<br>Use Alphabets-Digits-Space etc." 
                                         ValidationExpression="^[A-Za-z0-9'\.\-\s\,]{5,}" Display="Dynamic" 
                                        CssClass="error_msg  sel_error"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="frm-dtl2">
                                <div class="frm-lbl">Upload Shop Img: </div>
                                <div class="frm-input">
                                    <asp:FileUpload name="txt_sel_pic" id="txt_sel_pic" style="width:45%;" runat="server" /><br />
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" 
                                        ControlToValidate="txt_sel_pic" ErrorMessage="*Field can not be Empty" 
                                        Display="Dynamic" CssClass="error_msg  sel_error"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator18" 
                                         ControlToValidate="txt_sel_pic" runat="server" 
                                         ErrorMessage="*Upload JPG/JPEG/PNG files Only" 
                                         ValidationExpression="([a-zA-Z0-9\s_\\.\-\(\):])+(.jpg|.jpeg|.png)$" Display="Dynamic" 
                                        CssClass="error_msg  sel_error"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="frm-dtl1">
                                <div class="frm-lbl">Enter City:</div>
                                <div class="frm-input">
                                     <input type="text" name="txt_sel_city" id="txt_sel_city" class="sel-frm-text" placeholder="ex. Anand" runat="server"/><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
                                        ControlToValidate="txt_sel_city" ErrorMessage="*Field can not be Empty" 
                                        Display="Dynamic" CssClass="error_msg  sel_error"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator15" 
                                         ControlToValidate="txt_sel_city" runat="server" 
                                         ErrorMessage="*Length Must Be 3 to 15  - Use Only Alphabets" 
                                         ValidationExpression="^[A-Za-z]{3,15}" Display="Dynamic" 
                                        CssClass="error_msg  sel_error"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="frm-dtl2">
                                <div class="frm-lbl">Enter Pincode:</div>
                                <div class="frm-input">
                                     <input type="text" name="txt_sel_pin" id="txt_sel_pin" class="sel-frm-text" placeholder=" 6 digit zipcode/postalcode" runat="server"/><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" 
                                        ControlToValidate="txt_sel_pin" ErrorMessage="*Field can not be Empty" 
                                        Display="Dynamic" CssClass="error_msg  sel_error"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator16" 
                                         ControlToValidate="txt_sel_pin" runat="server" 
                                         ErrorMessage="*Invalid PinCode" 
                                         ValidationExpression="\d{6}" Display="Dynamic" 
                                        CssClass="error_msg  sel_error"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="frm-dtl1">
                                <div class="frm-lbl">Enter State:</div>
                                <div class="frm-input">
                                     <input type="text" name="txt_sel_state" id="txt_sel_state" class="sel-frm-text" placeholder="ex. Gujarat" runat="server"/><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" 
                                        ControlToValidate="txt_sel_state" ErrorMessage="*Field can not be Empty" 
                                        Display="Dynamic" CssClass="error_msg  sel_error"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator17" 
                                         ControlToValidate="txt_sel_state" runat="server" 
                                         ErrorMessage="*Length Must Be 3 to 15  - Use Only Alphabets" 
                                         ValidationExpression="^[A-Za-z]{3,15}" Display="Dynamic" 
                                        CssClass="error_msg  sel_error"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="sel_sub_btn" runat="server" class="swap-btn"  Text="Submit" OnClick="sel_sub_btn_Click" />
                        </td>
                    </tr>
                    </table>
             </form>
             
            </td>
            <td valign="bottom">
                <img src="img/proj_img/back_man.png" width="100%"/>
            </td>
        </tr>

        </table>
        </asp:Panel>
    </div>
     
                     

    <table style="font-size:15px;margin-top:25px;margin-left:7%;width:80%;">
        <tr>
            <td align="right" style="height:50px;padding-top:5px;"><a href="login.aspx" style="text-decoration:none;font-weight:bolder;">Already Registered? </a> | <a href="user_home.aspx" style="text-decoration:none;font-weight:bolder;">Back To Home </a></td>
        </tr>
    </table>
</form>
</body>
</html>
