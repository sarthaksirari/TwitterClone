using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication11
{
    public class FollowingDBAccess
    {
        public bool Following_Add(Following following)
        {
            SqlParameter[] parameters = new SqlParameter[]
		{
			new SqlParameter("@User_id", following.User_id),
			new SqlParameter("@Following_id", following.Following_id)
		};
            return SqlDBHelper.ExecuteNonQuery("Following_Add", CommandType.StoredProcedure, parameters);
        }

        public bool Following_Delete(Following following)
        {
            SqlParameter[] parameters = new SqlParameter[]
		{
			new SqlParameter("@User_id", following.User_id),
			new SqlParameter("@Following_id", following.Following_id)
		};
            return SqlDBHelper.ExecuteNonQuery("Following_Delete", CommandType.StoredProcedure, parameters);
        }

        public bool Following_Follower_Delete(string user_id)
        {
            SqlParameter[] parameters = new SqlParameter[]
		{
			new SqlParameter("@User_id", user_id)
		};
            return SqlDBHelper.ExecuteNonQuery("Following_Follower_Delete", CommandType.StoredProcedure, parameters);
        }

        public List<Following> Find_Following_Names(string user_id)
        {
            List<Following> followingList = null;

            SqlParameter[] parameters = new SqlParameter[]
		{
			new SqlParameter("@User_id", user_id)
		};
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("Find_Following_Names", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    followingList = new List<Following>();

                    foreach (DataRow row in table.Rows)
                    {
                        Following following = new Following();

                        following.User_id = row["user_id"].ToString();
                        following.FullName = row["fullName"].ToString();
                        following.ProfilePic = (bool)row["profilepic"];
                        if (following.ProfilePic == true)
                            following.ProfilepicUrl = "~/ProfilePic/" + following.User_id + ".jpg";
                        else
                            following.ProfilepicUrl = "~/ProfilePic/default.png";
                        following.User_idShow = "(@" + following.User_id + ")";

                        followingList.Add(following);
                    }
                }
            }
            return followingList;
        }

        public List<Following> Find_Followers_Names(string following_id)
        {
            List<Following> followersList = null;

            SqlParameter[] parameters = new SqlParameter[]
		{
			new SqlParameter("@Following_id", following_id)
		};
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("Find_Followers_Names", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    followersList = new List<Following>();

                    foreach (DataRow row in table.Rows)
                    {
                        Following following = new Following();

                        following.User_id = row["user_id"].ToString();
                        following.FullName = row["fullName"].ToString();
                        following.ProfilePic = (bool)row["profilepic"];
                        if (following.ProfilePic == true)
                            following.ProfilepicUrl = "~/ProfilePic/" + following.User_id + ".jpg";
                        else
                            following.ProfilepicUrl = "~/ProfilePic/default.png";
                        following.User_idShow = "(@" + following.User_id + ")";

                        followersList.Add(following);
                    }
                }
            }
            return followersList;
        }

        public int Find_Following_Count(string user_id)
        {
            int count = 0;

            SqlParameter[] parameters = new SqlParameter[]
		{
			new SqlParameter("@User_id", user_id)
		};
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("Find_Following_Count", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count == 1)
                {
                    count = Convert.ToInt32(table.Rows[0][0]);
                }
            }
            return count;
        }

        public int Find_Followers_Count(string following_id)
        {
            int count = 0;

            SqlParameter[] parameters = new SqlParameter[]
		{
			new SqlParameter("@Following_id", following_id)
		};
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("Find_Followers_Count", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count == 1)
                {
                    count = Convert.ToInt32(table.Rows[0][0]);
                }
            }
            return count;
        }
    }
}