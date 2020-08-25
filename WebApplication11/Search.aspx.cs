using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication11
{
    public partial class WebForm3 : System.Web.UI.Page
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

                string user = Request.QueryString["user"];

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

                List<Person> personList = personHandler.Search_Results(user);
                if (personList != null)
                {
                    foreach (Person p in personList)
                    {
                        string user_id = p.User_id;
                        string fullName = p.FullName;
                        bool profilepic = p.ProfilePic;
                        string user_idShow = p.User_idShow;
                        string profilepicurl = p.ProfilepicUrl;

                        SearchResults.DataSource = personList;
                        SearchResults.DataBind();
                    }
                }
                else
                {
                    noUserFoundLabel.Text = "No such User found.";
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