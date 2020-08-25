<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WebApplication11.Profile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NewTweetBox" runat="server">
    <asp:Label ID="tweetErrorMessage" runat="server" Font-Bold="True" Font-Size="15px" ForeColor="Red"></asp:Label>
    <br />
    <asp:ImageButton ID="DeleteTweetsButton" CssClass="profilepic" runat="server" ImageUrl="~/images/delete-tweets.jpg" Height="100px" Width="100px" style="margin-left:150px" OnClick="DeleteTweetsButton_Click" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">

    <meta charset="utf-8" />
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>

    <script>
        $(document).ready(function () {
            $(".accordion").accordion({ collapsible: true, defaultOpen: false, active: false });

            $("#CoverPic_FileUploaderCP").hide();
            $("#CoverPic_FileUploaderDP").hide();
            $("#CoverPic_SaveChangesButton").hide();

            $("#CoverPic_CoverPicButton").click(function () {
                $("#CoverPic_FileUploaderCP").click();
            });

            $("#CoverPic_ProfilePicButton").click(function () {
                $("#CoverPic_FileUploaderDP").click();
            });
        });
    </script>

    <script>
        function showpreview(input, type) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    if (type == "DP") {
                        $("#CoverPic_ProfilePicButton").attr('src', e.target.result);
                        $("#CoverPic_SaveChangesButton").show();
                    }
                    else if (type == "CP") {
                        $("#CoverPic_CoverPicButton").attr('src', e.target.result);
                        $("#CoverPic_SaveChangesButton").show();
                    }
                }
                reader.readAsDataURL(input.files[0]);
            }
        }
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
    <asp:DataList ID="TweetDataList" runat="server" OnItemCommand="TweetDataList_ItemCommand">
        <ItemTemplate>
            <div  style="border: 2px solid; width:580px;">
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
                        </div>
                    </div>
                </div>
                <br />
                <div>
                    <div class="accordion">
                        <h3>Edit Tweet</h3>
                        <div>
                            <div>
                                <asp:TextBox ID="tweetTextBox" runat="server" Text='<%# Eval("message") %>' TextMode="MultiLine" Height="75px" Width="500px" ></asp:TextBox>
                                <br />
                                <br />
                            </div>
                            <div class="spec">
                                <asp:ImageButton ID="SaveTweetChangesButton" OnCommand="SaveTweetChangesButton_Command" CommandArgument='<%# Eval("tweet_id") %>' runat="server" class="fr" ImageUrl="~/images/save-changes.jpg" />
                            </div>
                        </div>
                    </div>
                </div>
                <br />
            </div>
            <br />
        </ItemTemplate>
    </asp:DataList>

</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="CoverPic">
    <div style="cursor:pointer;">
        <asp:Image CssClass="coverpic" id="CoverPicButton" runat="server" Height="236px" Width="100%" />
    </div>
    <div class="div_profilepic" style="cursor:pointer;">
        <asp:Image CssClass="profilepic" ID="ProfilePicButton" runat="server" Height="175px" Width="175px" />
        <asp:ImageButton CssClass="roundbutton" ID="SaveChangesButton" runat="server" style="margin-left: 430px" ImageUrl="~/images/save-changes.jpg" OnClick="SaveChangesButton_Click" />
    </div>
    <asp:FileUpload ID="FileUploaderDP" onchange="showpreview(this, 'DP')" runat="server" />
    <asp:FileUpload ID="FileUploaderCP" onchange="showpreview(this, 'CP')" runat="server" />
</asp:Content>
