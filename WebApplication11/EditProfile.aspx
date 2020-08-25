<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="WebApplication11.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CoverPic" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NewTweetBox" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageBody" runat="server">

    <meta charset="utf-8" />
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>

    <script>
        $(document).ready(function () {
            $(".accordion").accordion({ collapsible: true, defaultOpen: false, active: false });
        });
    </script>

    <style type="text/css">
        .Table {
            display: table;
        }
        .Row {
            display: table-row;
        }
        .Cell {
            display: table-cell;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>

    <div class="Table" style="font-size:20px; text-decoration-color:#666666;">
        <div class="Row" style=" height: 45px;">
            <div class="Cell">
                Name:
            </div>
            <div class="Cell">
                <asp:label id="FullNameLabel" runat="server" font-size="19px" font-strikeout="false" forecolor="#666666"></asp:label>
            </div>
        </div>
        <div class="Row" style=" height: 45px;">
            <div class="Cell">
                UserName:
            </div>
            <div class="Cell">
                <asp:label id="UserNameLabel" runat="server" font-size="19px" font-strikeout="false" forecolor="#666666"></asp:label>
            </div>
        </div>
        <div class="Row" style=" height: 45px;">
            <div class="Cell">
                Email ID:
            </div>
            <div class="Cell">
                <asp:label id="EmailLabel" runat="server" font-size="19px" font-strikeout="false" forecolor="#666666"></asp:label>
            </div>
        </div>
        <div class="Row" style=" height: 45px;">
            <div class="Cell">
                Joined On:
            </div>
            <div class="Cell">
                <asp:label id="JoinedLabel" runat="server" font-size="19px" font-strikeout="false" forecolor="#666666"></asp:label>
            </div>
        </div>
    </div>

    <div class="accordion">
        <h3>Edit Profile Details</h3>
        <div>
            <div class="Table" style="font-size:20px; text-decoration-color:#666666;">
                <div class="Row" style=" height: 45px;">
                    <div class="Cell">
                        Name:
                    </div>
                    <div class="Cell">
                        <asp:TextBox ID="FullNameTextBox" runat="server" Font-Size="20px " Font-Strikeout="False" ForeColor="#666666" MaxLength="30"></asp:TextBox>
                    </div>
                </div>
                <div class="Row" style=" height: 45px;">
                    <div class="Cell">
                        Email ID:
                    </div>
                    <div class="Cell">
                        <asp:TextBox ID="EmailTextBox" runat="server" Font-Size="20px" Font-Strikeout="False" ForeColor="#666666" MaxLength="50" AutoCompleteType="Email"></asp:TextBox>
                    </div>
                </div>
                <div class="Row" style=" height: 45px;">
                    <div class="Cell">
                        &nbsp;
                    </div>
                    <div class="Cell">
                        <asp:ImageButton ID="SaveProfileChangesButton" runat="server" ImageUrl="~/images/save-changes.jpg" OnClick="SaveProfileChangesButton_Click" />
                    </div>
                </div>
            </div>
        </div>

        <h3>Change Password&nbsp; <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="NewPasswordTextBox" ControlToValidate="OldPasswordTextBox" Display="Dynamic" ErrorMessage="(New Password cannot be same as Old Password)" Font-Size="15px" ForeColor="Red" Operator="NotEqual"></asp:CompareValidator>&nbsp;</h3>
        <div>
            <div class="Table" style="font-size:20px; text-decoration-color:#666666;">
                <div class="Row" style=" height: 45px;">
                    <div class="Cell">
                        Current Password:
                    </div>
                    <div class="Cell">
                        <asp:TextBox ID="OldPasswordTextBox" runat="server" Font-Size="20px " Font-Strikeout="False" ForeColor="#666666" MaxLength="50"></asp:TextBox>
                    </div>
                </div>
                <div class="Row" style=" height: 45px;">
                    <div class="Cell">
                        New Password:
                    </div>
                    <div class="Cell">
                        <asp:TextBox ID="NewPasswordTextBox" runat="server" Font-Size="20px" Font-Strikeout="False" ForeColor="#666666" MaxLength="50"></asp:TextBox>
                    </div>
                </div>
                <div class="Row" style=" height: 45px;">
                    <div class="Cell">
                        &nbsp;
                    </div>
                    <div class="Cell">
                        <asp:ImageButton ID="SavePasswordChangesButton" runat="server" ImageUrl="~/images/save-changes.jpg" OnClick="SavePasswordChangesButton_Click" />
                    </div>
                </div>
            </div>
        </div>

        <h3>Delete Account</h3>
        <div style="font-size:20px; text-decoration-color:#666666;">
            Are you sure you want to delete your Twitter Account?
            <div style="margin-left:150px">
                <asp:ImageButton CssClass="profilepic" ID="YesButton" runat="server" Height="40px" Width="40px" ImageUrl="~/images/yes.jpg" OnClick="YesButton_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton CssClass="profilepic" ID="NoButton" runat="server" Height="40px" Width="40px" ImageUrl="~/images/no.jpg" OnClick="NoButton_Click" />
            </div>
        </div>
    </div>
</asp:Content>
