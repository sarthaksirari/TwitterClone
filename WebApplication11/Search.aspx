<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="WebApplication11.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NewTweetBox" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">

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

    <asp:Label ID="noUserFoundLabel" Font-Size="20px" runat="server"></asp:Label>
    <asp:DataList ID="SearchResults" runat="server">
        <ItemTemplate>
            <div style="border: 2px solid;">
                <div class="Table" style="font-size:20px; text-decoration-color:#666666;">
                    <div class="Row" style=" height: 45px;">
                        <div class="Cell">
                            <asp:ImageButton class="profilepic" ID="FollowerProfilePic" OnCommand="FollowerProfilePic_Command" CommandArgument='<%# Eval("user_id") %>' runat="server" Height="50px" Width="50px" ImageUrl='<%# Eval("profilepicurl") %>' />
                        </div>
                        <div class="Cell">
                            <asp:LinkButton ID="fullNameLink" OnCommand="fullNameLink_Command" CommandArgument='<%# Eval("user_id") %>' runat="server" Text='<%# Eval("fullName") %>' NavigateUrl="Profile.aspx" Font-Size="25px"></asp:LinkButton>
                            <asp:Label ID="user_idLabel" runat="server" Text='<%# Eval("user_idShow") %>' Font-Size="13"></asp:Label>
                        </div>
                        <br />
                        <br />
                    </div>
                </div>
            </div>
            <br />
        </ItemTemplate>
    </asp:DataList>
</asp:Content>