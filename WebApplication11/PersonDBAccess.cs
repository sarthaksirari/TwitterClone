using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebApplication11
{
    public class PersonDBAccess
    {
        public bool Person_Add(Person person)
        {
            SqlParameter[] parameters = new SqlParameter[]
		{                
			new SqlParameter("@user_id", person.User_id),
			new SqlParameter("@Password", person.Password),
			new SqlParameter("@FullName", person.FullName),
			new SqlParameter("@Email", person.Email),
			new SqlParameter("@Joined", person.Joined),
			new SqlParameter("@Active", person.Active)
		};
            return SqlDBHelper.ExecuteNonQuery("Person_Add", CommandType.StoredProcedure, parameters);
        }

        public bool Person_Update(Person person)
        {
            SqlParameter[] parameters = new SqlParameter[]
		{
            new SqlParameter("@user_id", person.User_id),
			new SqlParameter("@FullName", person.FullName),
			new SqlParameter("@Email", person.Email),
		};
            return SqlDBHelper.ExecuteNonQuery("Person_Update", CommandType.StoredProcedure, parameters);
        }

        public bool Person_Password_Update(Person person)
        {
            SqlParameter[] parameters = new SqlParameter[]
		{
            new SqlParameter("@user_id", person.User_id),
			new SqlParameter("@Password", person.Password)
		};
            return SqlDBHelper.ExecuteNonQuery("Person_Password_Update", CommandType.StoredProcedure, parameters);
        }

        public bool Person_Delete(string user_id)
        {
            SqlParameter[] parameters = new SqlParameter[]
		{
			new SqlParameter("@user_id", user_id)
		};
            return SqlDBHelper.ExecuteNonQuery("Person_Delete", CommandType.StoredProcedure, parameters);
        }

        public Person Person_Details(string user_id)
        {
            Person person = null;

            SqlParameter[] parameters = new SqlParameter[]
		{
			new SqlParameter("@user_id", user_id)
		};
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("Person_Details", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];

                    person = new Person();

                    person.FullName = row["fullName"].ToString();
                    person.Password = ObjectToByteArray(row["password"]);
                    person.Email = row["email"].ToString();
                    person.Joined = (DateTime)row["joined"];
                }
            }
            return person;
        }

        public Person Login(string user_id)
        {
            Person person = null;

            SqlParameter[] parameters = new SqlParameter[]
		{
			new SqlParameter("@user_id", user_id)
		};
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("Login", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];

                    person = new Person();

                    person.User_id = row["user_id"].ToString();
                    person.Password = ObjectToByteArray(row["password"]);

                }
            }
            return person;
        }

        public List<Person> Person_List()
        {
            List<Person> personList = null;

            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("Person_List", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    personList = new List<Person>();

                    foreach (DataRow row in table.Rows)
                    {
                        Person person = new Person();

                        person.User_id = row["user_id"].ToString();
                        person.FullName = row["fullName"].ToString();
                        person.ProfilePic = (bool)row["profilepic"];
                        if (person.ProfilePic == true)
                            person.ProfilepicUrl = "~/ProfilePic/" + person.User_id + ".jpg";
                        else
                            person.ProfilepicUrl = "~/ProfilePic/default.png";
                        person.User_idShow = "(@" + person.User_id + ")";

                        personList.Add(person);
                    }
                }
            }
            return personList;
        }

        public List<Person> Search_User(string user)
        {
            List<Person> personList = null;

            SqlParameter[] parameters = new SqlParameter[]
		{
			new SqlParameter("@user", user)
		};
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("Search_User", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    personList = new List<Person>();

                    foreach (DataRow row in table.Rows)
                    {
                        Person person = new Person();

                        person.User_id = row["user_id"].ToString();

                        personList.Add(person);
                    }
                }
            }
            return personList;
        }

        public List<Person> Search_Results(string user)
        {
            List<Person> personList = null;

            SqlParameter[] parameters = new SqlParameter[]
		{
			new SqlParameter("@user", user)
		};
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("Search_Results", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    personList = new List<Person>();

                    foreach (DataRow row in table.Rows)
                    {
                        Person person = new Person();

                        person.User_id = row["user_id"].ToString();
                        person.FullName = row["fullName"].ToString();
                        person.ProfilePic = (bool)row["profilepic"];
                        if (person.ProfilePic == true)
                            person.ProfilepicUrl = "~/ProfilePic/" + person.User_id + ".jpg";
                        else
                            person.ProfilepicUrl = "~/ProfilePic/default.png";
                        person.User_idShow = "(@" + person.User_id + ")";

                        personList.Add(person);
                    }
                }
            }
            return personList;
        }

        public static byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public static byte[] EncryptPassWord(string password)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] returnByteArray;
            UTF8Encoding encoder = new UTF8Encoding();
            returnByteArray = md5Hasher.ComputeHash(encoder.GetBytes(password));
            return returnByteArray;
        }

        public static bool IsCorrectPassWord(string userID, string password)
        {
            string strConnString = "Data Source=(localdb)\\v11.0; Initial Catalog=TwitterClone; Integrated Security=True";
            SqlConnection objConn = new SqlConnection(strConnString);
            string strSQL = "SELECT COUNT(*) FROM Person WHERE  user_id = @Username AND password = @Password;";
            SqlCommand objCmd = new SqlCommand(strSQL, objConn);

            //Create the parameters
            SqlParameter paramUsername;
            paramUsername = new SqlParameter("@Username", SqlDbType.VarChar, 25);
            paramUsername.Value = userID;
            objCmd.Parameters.Add(paramUsername);

            //Hash the password
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] hashedDataBytes;
            UTF8Encoding encoder = new UTF8Encoding();
            hashedDataBytes = md5Hasher.ComputeHash(encoder.GetBytes(password));

            //Execute the parameterized query
            SqlParameter paramPwd;
            paramPwd = new SqlParameter("@Password", SqlDbType.Binary, 16);
            paramPwd.Value = hashedDataBytes;
            objCmd.Parameters.Add(paramPwd);

            //The results of the count will be held here
            int iResults;
            try
            {
                objConn.Open();
                //We use execute scalar, since we only need one cell
                iResults = Convert.ToInt32(objCmd.ExecuteScalar().ToString());
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                objConn.Close();
            }

            if (iResults == 1)
                return true;
            else
                return false;
        }
    }
}