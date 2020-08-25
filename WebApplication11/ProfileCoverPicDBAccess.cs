using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication11
{
    public class ProfileCoverPicDBAccess
    {
        public bool ProfileCoverPic_Add(string user_id)
        {
            SqlParameter[] parameters = new SqlParameter[]
		{                
			new SqlParameter("@user_id", user_id)
		};
            return SqlDBHelper.ExecuteNonQuery("ProfileCoverPic_Add", CommandType.StoredProcedure, parameters);
        }

        public bool ProfilePic_Update(string user_id)
        {
            SqlParameter[] parameters = new SqlParameter[]
		{                
			new SqlParameter("@user_id", user_id)
		};
            return SqlDBHelper.ExecuteNonQuery("ProfilePic_Update", CommandType.StoredProcedure, parameters);
        }

        public bool CoverPic_Update(string user_id)
        {
            SqlParameter[] parameters = new SqlParameter[]
		{                
			new SqlParameter("@user_id", user_id)
		};
            return SqlDBHelper.ExecuteNonQuery("CoverPic_Update", CommandType.StoredProcedure, parameters);
        }

        public bool ProfilePic_Delete(string user_id)
        {
            SqlParameter[] parameters = new SqlParameter[]
		{                
			new SqlParameter("@user_id", user_id)
		};
            return SqlDBHelper.ExecuteNonQuery("ProfilePic_Delete", CommandType.StoredProcedure, parameters);
        }

        public bool CoverPic_Delete(string user_id)
        {
            SqlParameter[] parameters = new SqlParameter[]
		{                
			new SqlParameter("@user_id", user_id)
		};
            return SqlDBHelper.ExecuteNonQuery("CoverPic_Delete", CommandType.StoredProcedure, parameters);
        }

        public bool ProfileCoverPic_Delete(string user_id)
        {
            SqlParameter[] parameters = new SqlParameter[]
		{                
			new SqlParameter("@user_id", user_id)
		};
            return SqlDBHelper.ExecuteNonQuery("ProfileCoverPic_Delete", CommandType.StoredProcedure, parameters);
        }

        public ProfileCoverPic ProfileCoverPic_Details(string user_id)
        {
            ProfileCoverPic profilecoverpic = null;

            SqlParameter[] parameters = new SqlParameter[]
		{
			new SqlParameter("@user_id", user_id)
		};
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("ProfileCoverPic_Details", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];

                    profilecoverpic = new ProfileCoverPic();

                    profilecoverpic.ProfilePic = (bool)row["profilepic"];
                    profilecoverpic.CoverPic = (bool)row["coverpic"];
                }
            }
            return profilecoverpic;
        }
    }
}