using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication11
{
    public partial class WebForm9 : System.Web.UI.Page
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

                string user_idQuery = Request.QueryString["user_id"];

                ImageButton masterProfilePic = (ImageButton)Master.FindControl("ProfilePic");
                masterProfilePic.Visible = true;

                profilecoverpic = profilecoverpicHandler.ProfileCoverPic_Details(user_idQuery);
                if (profilecoverpic.ProfilePic == true)
                    masterProfilePic.ImageUrl = "~/ProfilePic/" + user_idQuery + ".jpg";
                else
                    masterProfilePic.ImageUrl = "~/ProfilePic/default.png";

                HyperLink h1 = (HyperLink)Master.FindControl("TweetsLink");
                h1.Text = tweetHandler.Tweet_Count(user_idQuery).ToString() + " Tweet(s)";
                h1.NavigateUrl = "OtherProfile.aspx?user_id=" + user_idQuery;
                HyperLink h2 = (HyperLink)Master.FindControl("FollowingLink");
                h2.Text = followingHandler.Find_Following_Count(user_idQuery).ToString() + " Following(s)";
                h2.NavigateUrl = "OtherFollowing.aspx?user_id=" + user_idQuery;
                HyperLink h3 = (HyperLink)Master.FindControl("FollowersLink");
                h3.Text = followingHandler.Find_Followers_Count(user_idQuery).ToString() + " Follower(s)";
                h3.NavigateUrl = "OtherFollower.aspx?user_id=" + user_idQuery;

                person = personHandler.Person_Details(user_idQuery);
                Label l1 = (Label)Master.FindControl("FullName");
                l1.Text = person.FullName;
                Label l2 = (Label)Master.FindControl("UserName");
                l2.Text = "(@" + user_idQuery + ")";

                List<Following> followerList = followingHandler.Find_Followers_Names(user_idQuery);
                if (followerList != null)
                {
                    foreach (Following f in followerList)
                    {
                        string user_id = f.User_id;
                        string fullName = f.FullName;
                        bool profilepic = f.ProfilePic;
                        string user_idShow = f.User_idShow;
                        string profilepicurl = f.ProfilepicUrl;

                        FollowerDataList.DataSource = followerList;
                        FollowerDataList.DataBind();
                    }
                }
                else
                {
                    noFollowerLabel.Text = "You have no Follower.";
                }
            }
        }

        protected void fullNameLink_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("OtherProfile.aspx?user_id=" + e.CommandArgument.ToString());
        }

        protected void FollowerProfilePic_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("OtherProfile.aspx?user_id=" + e.CommandArgument.ToString());
        }
    }
}