using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication11
{
    public partial class Profile : System.Web.UI.Page
    {
        Person person = new Person();
        Tweet tweet = new Tweet();
        Following following = new Following();
        ProfileCoverPic profilecoverpic = new ProfileCoverPic();

        PersonHandler personHandler = new PersonHandler();
        TweetHandler tweetHandler = new TweetHandler();
        FollowingHandler followingHandler = new FollowingHandler();
        ProfileCoverPicHandler profilecoverpicHandler = new ProfileCoverPicHandler();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["user_id"] == "")
                    Response.Redirect("Login.aspx");

                Master.FindControl("ProfilePic").Visible = false;

                profilecoverpic = profilecoverpicHandler.ProfileCoverPic_Details((string)Session["user_id"]);
                if (profilecoverpic.ProfilePic == true && profilecoverpic.CoverPic == true)
                {
                    ProfilePicButton.ImageUrl = "~/ProfilePic/" + (string)Session["user_id"] + ".jpg";
                    CoverPicButton.ImageUrl = "~/CoverPic/" + (string)Session["user_id"] + ".jpg";
                }
                else if (profilecoverpic.ProfilePic == true)
                {
                    ProfilePicButton.ImageUrl = "~/ProfilePic/" + (string)Session["user_id"] + ".jpg";
                    CoverPicButton.ImageUrl = "~/CoverPic/default.png";
                }
                else if (profilecoverpic.CoverPic == true)
                {
                    ProfilePicButton.ImageUrl = "~/ProfilePic/default.png";
                    CoverPicButton.ImageUrl = "~/CoverPic/" + (string)Session["user_id"] + ".jpg";
                }
                else
                {
                    ProfilePicButton.ImageUrl = "~/ProfilePic/default.png";
                    CoverPicButton.ImageUrl = "~/CoverPic/default.png";
                }

                HyperLink h1 = (HyperLink)Master.FindControl("TweetsLink");
                h1.Text = tweetHandler.Tweet_Count((string)(Session["user_id"])).ToString() + " Tweet(s)";
                HyperLink h2 = (HyperLink)Master.FindControl("FollowingLink");
                h2.Text = followingHandler.Find_Following_Count((string)(Session["user_id"])).ToString() + " Following(s)";
                HyperLink h3 = (HyperLink)Master.FindControl("FollowersLink");
                h3.Text = followingHandler.Find_Followers_Count((string)(Session["user_id"])).ToString() + " Follower(s)";

                person = personHandler.Person_Details((string)Session["user_id"]);
                FullNameLabel.Text = person.FullName;
                UserNameLabel.Text = (string)Session["user_id"];
                EmailLabel.Text = person.Email;
                JoinedLabel.Text = person.Joined.ToString();


                List<Tweet> tweetList = tweetHandler.Tweet_List((string)Session["user_id"]);
                if (tweetList != null)
                {
                    foreach (Tweet t in tweetList)
                    {
                        int tweet_id = t.Tweet_id;
                        string user_id = t.User_id;
                        string fullName = t.FullName;
                        string message = t.Message;
                        bool profilepic = t.ProfilePic;
                        string user_idShow = t.User_idShow;
                        string profilepicurl = t.ProfilepicUrl;

                        TweetDataList.DataSource = tweetList;
                        TweetDataList.DataBind();
                    }
                }
                else
                {
                    noTweetLabel.Text = "No tweets to show.";
                }
                
            }
        }

        protected void TweetDataList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TweetDataList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            TextBox t1 = e.Item.FindControl("tweetTextBox") as TextBox;

            if (t1.Text.Length > 140)
                Response.Write("<script language=javascript>alert('Please Enter a Tweet with maximum 140 characters.');</script>");
            else if (t1.Text.Length == 0)
                Response.Write("<script language=javascript>alert('Please Enter a Tweet with minimum one character.');</script>");
            else
            {
                tweet.Message = t1.Text;
                tweetHandler.Tweet_Update(tweet);
                Server.TransferRequest(Request.Url.AbsolutePath, false);
            }
        }

        protected void SaveTweetChangesButton_Command(object sender, CommandEventArgs e)
        {
            tweet.Tweet_id = Convert.ToInt32(e.CommandArgument);
        }

        protected void DeleteTweetsButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DeleteTweets.aspx");
        }

        protected void SaveChangesButton_Click(object sender, ImageClickEventArgs e)
        {
            if(FileUploaderCP.FileName!="" && FileUploaderDP.FileName!="")
            {
                FileUploaderCP.SaveAs(Server.MapPath("~/CoverPic/" + (string)Session["user_id"] + ".jpg"));
                profilecoverpicHandler.CoverPic_Update((string)Session["user_id"]);

                FileUploaderDP.SaveAs(Server.MapPath("~/ProfilePic/" + (string)Session["user_id"] + ".jpg"));
                profilecoverpicHandler.ProfilePic_Update((string)Session["user_id"]);

                Response.Redirect("Profile.aspx");
            }
            else if (FileUploaderCP.FileName != "")
            {
                FileUploaderCP.SaveAs(Server.MapPath("~/CoverPic/" + (string)Session["user_id"] + ".jpg"));
                profilecoverpicHandler.CoverPic_Update((string)Session["user_id"]);

                Response.Redirect("Profile.aspx");
            }
            else if (FileUploaderDP.FileName != "")
            {
                FileUploaderDP.SaveAs(Server.MapPath("~/ProfilePic/" + (string)Session["user_id"] + ".jpg"));
                profilecoverpicHandler.ProfilePic_Update((string)Session["user_id"]);

                Response.Redirect("Profile.aspx");
            }
        }
    }
}