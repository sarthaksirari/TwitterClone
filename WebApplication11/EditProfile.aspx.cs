using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication11
{
    public partial class WebForm12 : System.Web.UI.Page
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

                person = personHandler.Person_Details((string)Session["user_id"]);
                FullNameLabel.Text = person.FullName;
                UserNameLabel.Text = (string)Session["user_id"];
                EmailLabel.Text = person.Email;
                JoinedLabel.Text = person.Joined.ToString();

                FullNameTextBox.Text = FullNameLabel.Text;
                EmailTextBox.Text = EmailLabel.Text;
            }
        }

        protected void SavePasswordChangesButton_Click(object sender, ImageClickEventArgs e)
        {
            person = personHandler.Person_Details((string)Session["user_id"]);
            
            if (PersonDBAccess.IsCorrectPassWord((string)Session["user_id"], OldPasswordTextBox.Text) == true)
            {
                byte[] encryptedPassword = PersonDBAccess.EncryptPassWord(NewPasswordTextBox.Text);
                person.Password = encryptedPassword;
                person.User_id = (string)Session["user_id"];

                if (personHandler.Person_Password_Update(person) == true)
                {
                    Response.Write("<script language=javascript>alert('Your Password has been changed.');</script>");
                    OldPasswordTextBox.Text = null;
                    NewPasswordTextBox.Text = null;
                }
                else
                    Response.Write("<script language=javascript>alert('Error Changing Your Password!');</script>");
            }
            else
                Response.Write("<script language=javascript>alert('Current password is incorrect.');</script>");
        }

        protected void YesButton_Click(object sender, ImageClickEventArgs e)
        {
            tweetHandler.Tweet_Delete_Person((string)Session["user_id"]);
            followingHandler.Following_Follower_Delete((string)Session["user_id"]);
            profilecoverpicHandler.ProfileCoverPic_Delete((string)Session["user_id"]);
            personHandler.Person_Delete((string)Session["user_id"]);
            Response.Write("<script language=javascript>alert('Your account is deleted.');</script>");
            Response.Redirect("Login.aspx");
        }

        protected void NoButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("EditProfile.aspx");
        }

        protected void SaveProfileChangesButton_Click(object sender, ImageClickEventArgs e)
        {
            if (FullNameLabel.Text != FullNameTextBox.Text || EmailLabel.Text != EmailTextBox.Text)
            {
                person.FullName = FullNameTextBox.Text;
                person.Email = EmailTextBox.Text;
                person.User_id = (string)Session["user_id"];

                if (personHandler.Person_Update(person) == true)
                {
                    person = personHandler.Person_Details((string)Session["user_id"]);
                    FullNameLabel.Text = person.FullName;
                    EmailLabel.Text = person.Email;
                }
                else
                    Response.Write("<script language=javascript>alert('Error Changing Your Details!');</script>");
            }
        }
    }
}