using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication11
{
    public class ReplyDBAccess
    {
        public bool Reply_Add(Reply reply)
        {
            SqlParameter[] parameters = new SqlParameter[]
		{
			new SqlParameter("@tweet_id", reply.User_id),
			new SqlParameter("@user_id", reply.Message),
			new SqlParameter("@message", reply.Created),
            new SqlParameter("@created", reply.Created)
		};
            return SqlDBHelper.ExecuteNonQuery("Reply_Add", CommandType.StoredProcedure, parameters);
        }

        public bool Reply_Delete(string reply_id)
        {
            SqlParameter[] parameters = new SqlParameter[]
		{
			new SqlParameter("@tweet_id", reply_id)
		};
            return SqlDBHelper.ExecuteNonQuery("Reply_Delete", CommandType.StoredProcedure, parameters);
        }

        public List<Tweet> Reply_List(string reply_id)
        {
            List<Tweet> tweetListFollowing = null;

            SqlParameter[] parameters = new SqlParameter[]
		{
			new SqlParameter("@user_id", reply_id)
		};
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("Reply_List", CommandType.StoredProcedure, parameters))
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
                            tweet.ProfilepicUrl = "~/ProfilePic/" + reply_id + ".jpg";
                        else
                            tweet.ProfilepicUrl = "~/ProfilePic/default.png";
                        tweet.User_idShow = "(@" + tweet.User_id + ")";

                        tweetListFollowing.Add(tweet);
                    }
                }
            }
            return tweetListFollowing;
        }
    }
}