<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="OtherFollowing.aspx.cs" Inherits="WebApplication11.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CoverPic" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NewTweetBox" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageBody" runat="server">
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

    <asp:Label ID="noFollowingLabel" Font-Size="20px" runat="server"></asp:Label>
    <asp:DataList ID="FollowingDataList" runat="server">
        <ItemTemplate>
            <div  style="border: 2px solid;">
                <div class="Table" style="font-size:20px; text-decoration-color:#666666;">
                    <div class="Row" style=" height: 45px;">
                        <div class="Cell">
                            <asp:ImageButton class="profilepic" ID="FollowingProfilePic" OnCommand="FollowingProfilePic_Command" CommandArgument='<%# Eval("user_id") %>' runat="server" Height="50px" Width="50px" ImageUrl='<%# Eval("profilepicurl") %>' />
                        </div>
                        <div class="Cell">
                            <asp:LinkButton ID="fullNameLink" OnCommand="fullNameLink_Command" CommandArgument='<%# Eval("user_id") %>' Text='<%# Eval("fullName") %>' Font-Size="25px" runat="server"></asp:LinkButton>
                            <asp:Label ID="user_idLabel" runat="server" Text='<%# Eval("user_idShow") %>' Font-Size="13"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
