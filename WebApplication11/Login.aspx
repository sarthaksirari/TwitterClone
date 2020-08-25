<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication11.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="login.css" rel="stylesheet" />
    <title></title>
    <style type="text/css">
        .login-error {
            align-content: center;
        }
        .k {
            
             margin-top:50px;
          margin-left:0px;
             height:100%;
             width:100%;
            -webkit-animation: myfirst 25s infinite;
            background-repeat:no-repeat;
            animation:reverse;
        }
        @-webkit-keyframes myfirst{
  0%   {background-image: url(backimage/Chrysanthemum.jpg); background-repeat:no-repeat}
    25%  {background-image: url(backimage/Desert.jpg);background-repeat:no-repeat}
    50%   {background-image: url(backimage/Hydrangeas.jpg);background-repeat:no-repeat}
    75%  {background-image: url(backimage/Jellyfish.jpg);background-repeat:no-repeat}
    100%   {background-image: url(backimage/Lighthouse.jpg);background-repeat:no-repeat}

        }

    </style>
</head>
<body class="k">
    <div id="wrapper">

	<form id="form1" class="login-form" runat="server">
	
		<div class="header">
		<h1>Welcome to Twitter</h1>
		<span>Fill out the form below to login to your account.</span>
		</div>
	
		<div class="content">
            <asp:TextBox ID="username" runat="server" class="input username" placeholder="Username *"></asp:TextBox>
		<div class="user-icon"></div>
            <p style="color:red"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="username" ErrorMessage="Please Enter Your UserName" Font-Size="15px"></asp:RequiredFieldValidator></p>
            <asp:TextBox ID="password" runat="server" class="input password" placeholder="Password *"></asp:TextBox>
		<div class="pass-icon"></div>		
		    <p style="color:red"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="password" ErrorMessage="Please Enter Your Password"></asp:RequiredFieldValidator></p>
		</div>

		<div class="footer">
            <asp:Button class="button" ID="Login" runat="server" Text="Login" OnClick="Login_Click" />
            <asp:Button class="register" ID="Register" runat="server" Text="Register" OnClick="Register_Click" ValidationGroup="Register" />
		</div>
	
	</form>

    </div>
    <div class="gradient"></div>

</body>
</html>
