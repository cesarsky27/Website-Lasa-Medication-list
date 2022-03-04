<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Pages_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LOGIN</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />

    <link rel="stylesheet" href="~/Content/Custom.css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

    <!-- Bootstrap 3.3.6 -->
    <link rel="stylesheet" href="~/Content/bootstrap.css" />
    <link rel="stylesheet" href="~/Content/Site.css" />
    <link rel="stylesheet" href="~/Content/dist/css/AdminLTE.min.css" />

    <!-- Font Awesome -->
    <link rel="stylesheet" href="~/Content/font-awesome/css/font-awesome.css" />
    <link rel="stylesheet" href="~/Content/font-awesome/css/style.css" />

    <!-- Toast -->
    <link rel="stylesheet" href="~/Content/plugins/toast/toastr.css" />
    <style>
            body.body1 {
            /*background-image: url('~/Assets/img/Bg1.png');*/
            background-image: url("<%= Page.ResolveClientUrl("~/Assets/img/bg-image2.svg") %>") !important;
            height: 100%;
            background-size: cover;

            background-repeat: no-repeat;
            /*background-position: center;
            background-size: cover;*/

            }

            #formBox {
            top: 207px;
            left: 444px;
            width: 392px;
            height: 299px;
            background: #FFFFFF 0% 0% no-repeat padding-box;
            box-shadow: 0px 8px 16px #00000026;
            border-radius: 8px;
            opacity: 1;
            margin: auto;
            margin-top: 207.21px;

            }

            
            #text {
                font-size: 30px;
                color: #1A2268;
                font-weight: bold;
                font-family: 'Helvetica Neue LT Std';
                margin-top: 25px;
                    
            }

            #containerText {
                /*position: absolute;*/
                margin-top: 30px;
                padding-top: 10px;
                /*margin-left: 148.5px;*/
            }

            #username {
                top: 286px;
                left: 468px;
                width: 344px;
                height: 40px;
                background: #FFFFFF 0% 0% no-repeat padding-box;
                border: 1px solid #2a3593;
                border-radius: 4px;
                opacity: 1;
                /*margin-left: 55px;*/
            }
            #username1 {
                top: 286px;
                left: 468px;
                width: 344px;
                height: 40px;
                background: #FFFFFF 0% 0% no-repeat padding-box;
                border: 1px solid #2a3593;
                border-radius: 4px;
                opacity: 1;
                /*margin-left: 55px;*/
                /*margin-top: 20px;*/
            }
            #forgotPass {
                font-size: 12px;
                font-family: 'Helvetica Neue LT Std';
                font-weight: bold;
                color: #4D9B35;
                /*padding-left: 200px;*/
                /*padding-top: 10px;*/
                padding-bottom: 10px;
                padding-right: 30px;
            }

            .button1{
               top: 434px;
                left: 468px;
                width: 342px;
                height: 40px;
                background: #2A3593 0% 0% no-repeat padding-box;
                border-radius: 30px;
                opacity: 1;
                max-width: 540px;
                color: white;
                border: 0px solid #2A3593;
                font-family: 'Helvetica Neue LT Std';
                font-size: 13px;
                
            }

            .button1:hover {
                background-color: blue;
                color: white;
                cursor: pointer;
            }

            #button2 {
                padding-left: 35px;
                /*border: 1px solid #2a3593;*/
                padding-bottom: 20px;
            }

            #button3 {
                padding-left: 35px;
                /*border: 1px solid #2a3593;*/
                padding-bottom: 20px;
            }

            .imgSrc {
                width: 25px;
                height: 25px;
            }

            .borderColor {
                border: 1px solid blue;
                border-radius: 4px;
            }
    </style>
</head>
<body class="body1">
    <form id="formLogin" runat="server">
        <div id="formBox" align="center">
            <div id="containerText">
                <h1 id="text" align="center">LOGIN</h1>
            </div>
           <%-- <div id="input">
                <asp:TextBox id="username" runat="server" placeholder="Username"></asp:TextBox>
            </div>--%>
            <div>

            <div class="input-group">
            <div class="input-group-prepend" id="button2">
              <span class="input-group-text">
                  <img src="<%= Page.ResolveClientUrl("~/Assets/img/atom-icon.png") %>" class="imgSrc" alt="Alternate Text" />
              </span>
            </div>
                <asp:TextBox ID="username" runat="server" placeholder="Username" required="required" oninvalid="this.setCustomValidity('Username cannot be empty.')" oninput="this.setCustomValidity('')" ></asp:TextBox>
          </div>
            <%--<input type="text" class="form-control" placeholder="Username">--%> 
           <div class="input-group">
            <div class="input-group-prepend" id="button3">
              <span class="input-group-text">
                  <img src="<%= Page.ResolveClientUrl("~/Assets/img/atom-lock.png") %>" class="imgSrc" alt="Alternate Text" />
              </span>
            </div>
                <asp:TextBox style="width: 1000px; height: 39px" ID="password" CssClass="borderColor" TextMode="Password" runat="server" placeholder="Password" required="required" oninvalid="this.setCustomValidity('Password salah!!!')" oninput="this.setCustomValidity('')"></asp:TextBox>
            <div class="input-group d-flex justify-content-end " id="forgotPass" >
					<a href="#modalForgotPass" data-toggle="modal" style="text-align: left; color: #4D9B35; font: normal normal normal 12px/17px Helvetica;">Forgot Password?</a>
				</div>
          </div>
            </div>
            <%--<div id="input">
                <asp:TextBox id="username1" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>               
            </div>--%>
            <asp:Button Text="LOGIN" OnClick ="btnSignIn_Click" CssClass="button1" runat="server" />
            <%--<button type="button" id="button1" class="btn btn-primary button1">LOGIN</button>--%>
           <%--login form--%>   

        </div>
    </form>
</body>
</html>
                
