using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication11
{
    public partial class WebForm7 : System.Web.UI.Page
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

                string user_id = Request.QueryString["user_id"];

                if((string)Session["user_id"]==user_id)
                    Response.Redirect("Profile.aspx");

                profilecoverpic = profilecoverpicHandler.ProfileCoverPic_Details(user_id);
                if (profilecoverpic.ProfilePic == true && profilecoverpic.CoverPic == true)
                {
                    ProfilePicButton.ImageUrl = "~/ProfilePic/" + user_id + ".jpg";
                    CoverPicButton.ImageUrl = "~/CoverPic/" + user_id + ".jpg";
                }
                else if (profilecoverpic.ProfilePic == true)
                    ProfilePicButton.ImageUrl = "~/ProfilePic/" + user_id + ".jpg";
                else if (profilecoverpic.CoverPic == true)
                    CoverPicButton.ImageUrl = "~/CoverPic/" + user_id + ".jpg";
                else
                {
                    ProfilePicButton.ImageUrl = "~/ProfilePic/default.png";
                    CoverPicButton.ImageUrl = "~/CoverPic/default.png";
                }

                FollowUnfollowButton.ImageUrl = "~/images/follow-me.jpg";
                List<Following> followingList = followingHandler.Find_Following_Names((string)Session["user_id"]);
                if(followingList != null)
                {
                    foreach (Following f in followingList)
                    {
                        if(f.User_id==user_id)
                        {
                            FollowUnfollowButton.ImageUrl = "~/images/unfollow-me.jpg";
                        }
                    }
                }

                HyperLink h1 = (HyperLink)Master.FindControl("TweetsLink");
                h1.Text = tweetHandler.Tweet_Count(user_id).ToString() + " Tweet(s)";
                h1.NavigateUrl = "OtherProfile.aspx?user_id=" + user_id;
                HyperLink h2 = (HyperLink)Master.FindControl("FollowingLink");
                h2.Text = followingHandler.Find_Following_Count(user_id).ToString() + " Following(s)";
                h2.NavigateUrl = "OtherFollowing.aspx?user_id=" + user_id;
                HyperLink h3 = (HyperLink)Master.FindControl("FollowersLink");
                h3.Text = followingHandler.Find_Followers_Count(user_id).ToString() + " Follower(s)";
                h3.NavigateUrl = "OtherFollower.aspx?user_id=" + user_id;

                person = personHandler.Person_Details(user_id);
                FullNameLabel.Text = person.FullName;
                UserNameLabel.Text = user_id;
                EmailLabel.Text = person.Email;
                JoinedLabel.Text = person.Joined.ToString();

                List<Tweet> tweetList = tweetHandler.Tweet_List(user_id);
                if (tweetList != null)
                {
                    foreach (Tweet t in tweetList)
                    {
                        int tweet_id = t.Tweet_id;
                        string user_idDL = t.User_id;
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

        protected void FollowingProfilePic_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("OtherProfile.aspx?user_id=" + e.CommandArgument.ToString());
        }

        protected void fullNameLink_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("OtherProfile.aspx?user_id=" + e.CommandArgument.ToString());
        }

        protected void FollowUnfollowButton_Click(object sender, ImageClickEventArgs e)
        {
            string user_id = Request.QueryString["user_id"];

            List<Following> followingList = followingHandler.Find_Following_Names((string)Session["user_id"]);
            if (followingList != null)
            {
                foreach (Following f in followingList)
                {
                    if (f.User_id == user_id)
                    {
                        FollowUnfollowButton.ImageUrl = "~/images/follow-me.jpg";
                        following.User_id = (string)Session["user_id"];
                        following.Following_id = user_id;
                        if(followingHandler.Following_Delete(following)==true)
                            Response.Redirect("OtherProfile.aspx?user_id=" + user_id);
                    }
                    else
                    {
                        FollowUnfollowButton.ImageUrl = "~/images/unfollow-me.jpg";
                        following.User_id = (string)Session["user_id"];
                        following.Following_id = user_id;
                        if(followingHandler.Following_Add(following)==true)
                            Response.Redirect("OtherProfile.aspx?user_id=" + user_id);
                    }
                }
            }
            else
            {
                FollowUnfollowButton.ImageUrl = "~/images/unfollow-me.jpg";
                following.User_id = (string)Session["user_id"];
                following.Following_id = user_id;
                if (followingHandler.Following_Add(following) == true)
                    Response.Redirect("OtherProfile.aspx?user_id=" + user_id);
            }
        }
    }
}