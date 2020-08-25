using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication11
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Person person = new Person();
        PersonHandler empHandler = new PersonHandler();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            person = empHandler.Login(username.Text);

            if (person == null)
            {
                Response.Write("<script language=javascript>alert('Incorrect UserName or Password. Please try again or Register as a new user.');</script>");
            }
            else if (person.User_id == username.Text && PersonDBAccess.IsCorrectPassWord(username.Text, password.Text)==true)
            {
                Session["user_id"] = (string)person.User_id;
                Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Write("<script language=javascript>alert('Incorrect UserName or Password. Please try again or Register as a new user.');</script>");
            }
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }
    }
}