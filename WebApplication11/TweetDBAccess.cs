using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication11
{
    public class TweetDBAccess
    {
        public bool Tweet_Add(Tweet tweet)
        {
            SqlParameter[] parameters = new SqlParameter[]
		{
			new SqlParameter("@User_id", tweet.User_id),
			new SqlParameter("@Message", tweet.Message),
			new SqlParameter("@Created", tweet.Created)
		};
            return SqlDBHelper.ExecuteNonQuery("Tweet_Add", CommandType.StoredProcedure, parameters);
        }

        public bool Tweet_Update(Tweet tweet)
        {
            SqlParameter[] parameters = new SqlParameter[]
		{
            new SqlParameter("@tweet_id", tweet.Tweet_id),
            new SqlParameter("@Message", tweet.Message)
		};
            return SqlDBHelper.ExecuteNonQuery("Tweet_Update", CommandType.StoredProcedure, parameters);
        }

        public int Tweet_Count(string user_id)
        {
            int count = 0;

            SqlParameter[] parameters = new SqlParameter[]
		{
			new SqlParameter("@user_id", user_id)
		};
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("Tweet_Count", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count == 1)
                {
                    count = Convert.ToInt32(table.Rows[0][0]);
                }
            }
            return count;
        }

        public bool Tweet_Delete(int tweet_id)
        {
            SqlParameter[] parameters = new SqlParameter[]
		{
			new SqlParameter("@tweet_id", tweet_id)
		};
            return SqlDBHelper.ExecuteNonQuery("Tweet_Delete", CommandType.StoredProcedure, parameters);
        }

        public bool Tweet_Delete_Person(string user_id)
        {
            SqlParameter[] parameters = new SqlParameter[]
		{
			new SqlParameter("@user_id", user_id)
		};
            return SqlDBHelper.ExecuteNonQuery("Tweet_Delete_Person", CommandType.StoredProcedure, parameters);
        }

        public List<Tweet> Tweet_List_Following(string user_id)
        {
            List<Tweet> tweetListFollowing = null;

            SqlParameter[] parameters = new SqlParameter[]
		{
			new SqlParameter("@user_id", user_id)
		};
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("Tweet_List_Following", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    tweetListFollowing = new List<Tweet>();

                    foreach (DataRow row in table.Rows)
                    {
                        Tweet tweet = new Tweet();

                        tweet.Tweet_id = Convert.ToInt32(row["tweet_id"]);
                        tweet.User_id = row["user_id"].ToString();
                        tweet.FullName = row["fullName"].ToString();
                        tweet.Message = row["message"].ToString();
                        tweet.ProfilePic = (bool)row["profilepic"];
                        if (tweet.ProfilePic == true)
                            tweet.ProfilepicUrl = "~/ProfilePic/" + tweet.User_id + ".jpg";
                        else
                            tweet.ProfilepicUrl = "~/ProfilePic/default.png";
                        tweet.User_idShow = "(@" + tweet.User_id + ")";

                        tweetListFollowing.Add(tweet);
                    }
                }
            }
            return tweetListFollowing;
        }

        public List<Tweet> Tweet_List(string user_id)
        {
            List<Tweet> tweetList = null;

            SqlParameter[] parameters = new SqlParameter[]
		{
			new SqlParameter("@user_id", user_id)
		};
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("Tweet_List", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    tweetList = new List<Tweet>();

                    foreach (DataRow row in table.Rows)
                    {
                        Tweet tweet = new Tweet();

                        tweet.Tweet_id = Convert.ToInt32(row["tweet_id"]);
                        tweet.User_id = row["user_id"].ToString();
                        tweet.FullName = row["fullName"].ToString();
                        tweet.Message = row["message"].ToString();
                        tweet.ProfilePic = (bool)row["profilepic"];
                        if (tweet.ProfilePic == true)
                            tweet.ProfilepicUrl = "~/ProfilePic/" + tweet.User_id + ".jpg";
                        else
                            tweet.ProfilepicUrl = "~/ProfilePic/default.png";
                        tweet.User_idShow = "(@" + tweet.User_id + ")";

                        tweetList.Add(tweet);
                    }
                }
            }
            return tweetList;
        }
    }
}