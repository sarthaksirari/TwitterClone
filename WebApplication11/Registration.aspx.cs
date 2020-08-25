using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication11
{
    public partial class Registration : System.Web.UI.Page
    {
        Person person = new Person();
        ProfileCoverPic profilecoverpic = new ProfileCoverPic();

        PersonHandler personHandler = new PersonHandler();
        ProfileCoverPicHandler profilecoverpicHandler = new ProfileCoverPicHandler();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            if (termsCheckbox.Checked == true)
            {
                int c = 0;
                checkboxErrorLabel.Text = "";

                List<Person> personList = personHandler.Person_List();
                foreach (Person p in personList)
                {
                    if (user_idTextBox.Text == p.User_id)
                    {
                        Response.Write("<script language=javascript>alert('This UserName has already been taken. Please enter some other UserName.');</script>");
                        c = 1;
                    }
                }

                if (c == 0)
                {
                    person.User_id = user_idTextBox.Text;

                    person.Password = PersonDBAccess.EncryptPassWord(passwordTextBox.Text);
                    person.FullName = user_idTextBox.Text;
                    person.Email = emailTextBox.Text;
                    person.Joined = DateTime.Now;
                    person.Active = true;

                    personHandler.Person_Add(person);
                    profilecoverpicHandler.ProfileCoverPic_Add(user_idTextBox.Text);

                    Session["user_id"] = (string)person.User_id;
                    Response.Redirect("Home.aspx");
                }
            }
            else
                checkboxErrorLabel.Text = "Please Select the Terms & Conditions";
        }
    }
}