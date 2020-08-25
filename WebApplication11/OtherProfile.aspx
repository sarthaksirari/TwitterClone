<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="OtherProfile.aspx.cs" Inherits="WebApplication11.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CoverPic" runat="server">
    <div>
        <asp:Image class="coverpic" ID="CoverPicButton" runat="server" Height="236px" Width="100%" />
    </div>
    <div class="div_profilepic">
        <asp:Image class="profilepic" ID="ProfilePicButton" runat="server" Height="175px" Width="175px" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NewTweetBox" runat="server">
    <asp:ImageButton ID="FollowUnfollowButton" runat="server" style="height:130px; width:130px; margin-left:200px; border:7px solid; border-radius:30px; border-color:#d1cfcf" OnClick="FollowUnfollowButton_Click" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageBody" runat="server">

    <meta charset="utf-8" />
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>

    <script>
        $(function () {
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
    <br />
    
    <asp:Label ID="noTweetLabel" runat="server" Font-Size="20px" class="fc"></asp:Label>
    <asp:DataList ID="TweetDataList" runat="server">
        <ItemTemplate>
            <div  style="border: 2px solid; width:580px;">
                <div class="Table" style="font-size:20px; text-decoration-color:#666666;">
                    <div class="Row" style=" height: 45px;">
                        <div class="Cell">
                            <asp:ImageButton class="profilepic" ID="FollowingProfilePic" OnCommand="FollowingProfilePic_Command" CommandArgument='<%# Eval("user_id") %>' runat="server" Height="50px" Width="50px" ImageUrl='<%# Eval("profilepicurl") %>' />
                        </div>
                        <div class="Cell">
                            <asp:LinkButton ID="fullNameLink" OnCommand="fullNameLink_Command" CommandArgument='<%# Eval("user_id") %>' runat="server" Text='<%# Eval("fullName") %>' Font-Size="21px"></asp:LinkButton>
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