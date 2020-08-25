using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication11
{
    public partial class WebForm5 : System.Web.UI.Page
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

                ImageButton masterProfilePic = (ImageButton)Master.FindControl("ProfilePic");
                masterProfilePic.Visible = true;

                profilecoverpic = profilecoverpicHandler.ProfileCoverPic_Details((string)Session["user_id"]);
                if (profilecoverpic.ProfilePic == true)
                    masterProfilePic.ImageUrl = "~/ProfilePic/" + (string)Session["user_id"] + ".jpg";
                else
                    masterProfilePic.ImageUrl = "~/ProfilePic/default.png";

                HyperLink h1 = (HyperLink)Master.FindControl("TweetsLink");
                h1.Text = tweetHandler.Tweet_Count((string)(Session["user_id"])).ToString() + " Tweet(s)";
                HyperLink h2 = (HyperLink)Master.FindControl("FollowingLink");
                h2.Text = followingHandler.Find_Following_Count((string)(Session["user_id"])).ToString() + " Following(s)";
                HyperLink h3 = (HyperLink)Master.FindControl("FollowersLink");
                h3.Text = followingHandler.Find_Followers_Count((string)(Session["user_id"])).ToString() + " Follower(s)";

                person = personHandler.Person_Details((string)Session["user_id"]);
                Label l1 = (Label)Master.FindControl("FullName");
                l1.Text = person.FullName;
                Label l2 = (Label)Master.FindControl("UserName");
                l2.Text = "(@" + (string)Session["user_id"] + ")";

                List<Following> followingList = followingHandler.Find_Following_Names((string)Session["user_id"]);
                if (followingList != null)
                {
                    foreach (Following f in followingList)
                    {
                        string user_id = f.User_id;
                        string fullName = f.FullName;
                        bool profilepic = f.ProfilePic;
                        string user_idShow = f.User_idShow;
                        string profilepicurl = f.ProfilepicUrl;

                        FollowingDataList.DataSource = followingList;
                        FollowingDataList.DataBind();
                    }
                }
                else
                {
                    noFollowingLabel.Text = "You are not Following anybody.";
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
    }
}