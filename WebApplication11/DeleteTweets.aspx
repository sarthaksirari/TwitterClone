<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DeleteTweets.aspx.cs" Inherits="WebApplication11.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CoverPic" runat="server">
    
    <div>
        <asp:ImageButton class="coverpic" id="CoverPicButton"  runat="server" Height="236px" Width="100%" />
    </div>
    <div class="div_profilepic">
        <asp:ImageButton class="profilepic" ID="ProfilePicButton" runat="server" Height="175px" Width="175px" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NewTweetBox" runat="server">
    <asp:ImageButton CssClass="roundbutton" style="margin-left:150px" ID="CancelDeleteTweetsButton" runat="server" ImageUrl="~/images/cancel.jpg" Height="36px" Width="100px" OnClick="CancelDeleteTweetsButton_Click" />
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

    <asp:Label ID="noTweetLabel" runat="server" Font-Size="20px" class="fc"></asp:Label>
    <asp:DataList ID="TweetDataList" runat="server">
        <ItemTemplate>
            <div  style="border: 2px solid; width:100%;">
                <div class="Table" style="font-size:20px; text-decoration-color:#666666;">
                    <div class="Row" style=" height: 45px;">
                        <div class="Cell">
                            <asp:ImageButton class="profilepic" ID="FollowingProfilePic" runat="server" Height="50px" Width="50px" ImageUrl='<%# Eval("profilepicurl") %>' />
                        </div>
                        <div class="Cell">
                            <asp:HyperLink ID="fullNameLink" runat="server" Text='<%# Eval("fullName") %>' NavigateUrl="Profile.aspx" Font-Size="21px"></asp:HyperLink>
                            <asp:Label ID="user_idLabel" runat="server" Text='<%# Eval("user_idShow") %>' Font-Size="11"></asp:Label>
                            <br />
                            <asp:Label ID="messageLabel" runat="server" Text='<%# Eval("message") %>' Font-Size="13" />
                            <br />
                            <br />
                            <asp:ImageButton ID="DeleteTweet" OnCommand="DeleteTweet_Command" CommandArgument='<%# Eval("tweet_id") %>' CssClass="fr" runat="server" ImageUrl="~/images/delete.jpg" />
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