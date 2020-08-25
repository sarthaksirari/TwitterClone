<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WebApplication11.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="registration.css" rel="stylesheet" />
    <link href="registration_normalize.css" rel="stylesheet" />
    <title></title>
</head>
<body>
  <div class="container">
    <section class="register">
      <h1>Join Twitter</h1>
      <form id="form1" runat="server">
      <div class="reg_section personal_info">
      <h3>Your Personal Information</h3>
       <asp:TextBox ID="nameTextBox" runat="server" placeholder="Your Full Name *" MaxLength="30"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Your Full Name" ControlToValidate="nameTextBox" Font-Bold="True" Font-Overline="False" Font-Size="12px" Font-Strikeout="False" Font-Underline="False" ForeColor="#CC0000"></asp:RequiredFieldValidator>
       <asp:TextBox ID="emailTextBox" runat="server" placeholder="Your E-mail Address *" MaxLength="50" AutoCompleteType="Email"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Your E-mail Address" ControlToValidate="emailTextBox" Font-Bold="True" Font-Size="12px" ForeColor="#CC0000"></asp:RequiredFieldValidator>
      </div>
      <div class="reg_section password">
      <h3>Your Twitter Information</h3>
      <asp:TextBox ID="user_idTextBox" runat="server" placeholder="Your Desired Username *" MaxLength="25"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter Your Username" ControlToValidate="user_idTextBox" Font-Bold="True" Font-Size="12px" ForeColor="#CC0000"></asp:RequiredFieldValidator>
      <asp:TextBox ID="passwordTextBox" runat="server" placeholder="Your Password *" MaxLength="50"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Enter Your Password" ControlToValidate="passwordTextBox" Font-Bold="True" Font-Size="12px" ForeColor="#CC0000"></asp:RequiredFieldValidator>
      </div>
      
      <p class="terms">
        <label>
            <asp:CheckBox ID="termsCheckbox" runat="server" />
            I accept  <a href="Login.aspx">Twitter</a> Terms & Condition <br />
            <asp:Label ID="checkboxErrorLabel" runat="server" Font-Bold="True" Font-Size="12px" ForeColor="#CC0000"></asp:Label>
        </label></p>
          <br />
          <br />
          <br />
      <p class="submit">
          <asp:Button ID="RegisterButton" runat="server" Text="Sign Up" OnClick="RegisterButton_Click"/>
      </p>
      </form>
    </section>
  </div>
</body>
</html>
