using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication11
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        //[System.Web.Script.Services.ScriptMethod()]
        //[System.Web.Services.WebMethod]
        //public static List<string> GetUserid(string prefixText)
        //{
        //    DataTable dt = new DataTable();
        //    string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        //    SqlConnection con = new SqlConnection(constr);
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("select userid from person where user_id like @User_id+'%'", con);
        //    cmd.Parameters.AddWithValue("@User_id", prefixText);
        //    SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //    adp.Fill(dt);
        //    List<string> UserNames = new List<string>();
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        UserNames.Add(dt.Rows[i][0].ToString());
        //    }
        //    return UserNames;
        //}

        //private void SetDefaultButton(TextBox txt, ImageButton defaultButton)
        //{
        //    txt.Attributes.Add("onkeydown", "funfordefautenterkey1(" + defaultButton.ClientID + ",event)");
        //}

        //protected void SearchButton_Click(object sender, EventArgs e)
        //{
        //    Session["visitorid"] = search.Text;
        //    Response.Redirect("OtherProfile.aspx?user_id=" + search.Text);
        //}



        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Search.aspx?user=" + search.Text.ToString());
        }

        protected void ProfilePic_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["user_id"] = "";
            Response.Redirect("Login.aspx");
        }
    }
}