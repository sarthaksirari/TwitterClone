<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication11.Home" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" runat="server" contentplaceholderid="NewTweetBox">
    <asp:TextBox ID="tweetTextBox" runat="server" TextMode="MultiLine" Height="82px" Width="100%" MaxLength="140"></asp:TextBox>
     <br />
    <br />
    <p class="spec">
        <asp:ImageButton ID="TweetButton" runat="server" class="fr" ImageUrl="~/images/tweet.jpg" OnClick="TweetButton_Click" />
        <asp:Label ID="tweetErrorMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
    </p>
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="PageBody">

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

    <asp:Label ID="noTweetLabel" runat="server" Font-Size="20px" class="fc"></asp:Label>
    <asp:DataList ID="TweetDataList" runat="server">
        <ItemTemplate>
            <div  style="border: 2px solid; width:100%;">
                <div class="Table" style="font-size:20px; text-decoration-color:#666666;">
                    <div class="Row" style=" height: 45px;">
                        <div class="Cell">
                            <asp:ImageButton class="profilepic" ID="FollowingProfilePic"  OnCommand="FollowingProfilePic_Command" CommandArgument='<%# Eval("user_id") %>' runat="server" Height="50px" Width="50px" ImageUrl='<%# Eval("profilepicurl") %>' />
                        </div>
                        <div class="Cell">
                            <asp:LinkButton ID="fullNameLink" runat="server" Text='<%# Eval("fullName") %>' OnCommand="fullNameLink_Command" CommandArgument='<%# Eval("user_id") %>' Font-Size="21px"></asp:LinkButton>
                            <asp:Label ID="user_idLabel" runat="server" Text='<%# Eval("user_idShow") %>' Font-Size="11"></asp:Label>
                            <br />
                            <asp:Label ID="messageLabel" runat="server" Text='<%# Eval("message") %>' Font-Size="13" />
                            <br />
                            <br />
                        </div>
                    </div>
                </div>
            </div>
            <br />
        </ItemTemplate>
    </asp:DataList>
</asp:Content>


