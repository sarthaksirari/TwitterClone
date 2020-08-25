using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication11
{
    public partial class WebForm10 : System.Web.UI.Page
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
                }
                else if (profilecoverpic.CoverPic == true)
                {   CoverPicButton.ImageUrl = "~/CoverPic/" + (string)Session["user_id"] + ".jpg";
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
                    noTweetLabel.Text = "No tweets to delete.";
                }
            }
        }

        protected void DeleteTweet_Command(object sender, CommandEventArgs e)
        {
            int tweet_id= Convert.ToInt32(e.CommandArgument);

            tweetHandler.Tweet_Delete(tweet_id);
            Server.TransferRequest(Request.Url.AbsolutePath, false);
        }

        protected void CancelDeleteTweetsButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }
    }
}