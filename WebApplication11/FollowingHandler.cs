using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication11
{
    public class FollowingHandler
    {
        FollowingDBAccess followingDb = null;

        public FollowingHandler()
	    {
            followingDb = new FollowingDBAccess();
	    }

        public bool Following_Add(Following following)
        {
            return followingDb.Following_Add(following);
        }

        public bool Following_Delete(Following following)
        {
            return followingDb.Following_Delete(following);
        }

        public bool Following_Follower_Delete(string user_id)
        {
            return followingDb.Following_Follower_Delete(user_id);
        }

        public List<Following> Find_Following_Names(string user_id)
        {
            return followingDb.Find_Following_Names(user_id);
        }

        public List<Following> Find_Followers_Names(string following_id)
        {
            return followingDb.Find_Followers_Names(following_id);
        }

        public int Find_Following_Count(string user_id)
        {
            return followingDb.Find_Following_Count(user_id);
        }

        public int Find_Followers_Count(string following_id)
        {
            return followingDb.Find_Followers_Count(following_id);
        }
    }
}