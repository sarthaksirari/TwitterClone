using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication11
{
    public partial class Home : System.Web.UI.Page
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

                List<Tweet> tweetList = tweetHandler.Tweet_List_Following((string)Session["user_id"]);
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

        protected void TweetButton_Click(object sender, ImageClickEventArgs e)
        {

            if (tweetTextBox.Text.Length > 140)
                tweetErrorMessage.Text = "Please Enter a Tweet with maximum 140 characters.";
            else if (tweetTextBox.Text.Length == 0)
                tweetErrorMessage.Text = "Please Enter a Tweet with atleast one character.";
            else
            {
                tweet.User_id = (string)Session["user_id"];
                tweet.Message = tweetTextBox.Text;
                tweet.Created = DateTime.Now;
                if(tweetHandler.Tweet_Add(tweet)==true)
                    Response.Write("<script language=javascript>alert('Your Tweet has been posted.');</script>");
                else
                    Response.Write("<script language=javascript>alert('Error posting your Tweet! Please try again.');</script>");
            }
        }

        protected void fullNameLink_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("OtherProfile.aspx?user_id=" + e.CommandArgument.ToString());
        }

        protected void FollowingProfilePic_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("OtherProfile.aspx?user_id=" + e.CommandArgument.ToString());
        }
    }
}