using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication11
{
    public class TweetHandler
    {
        TweetDBAccess tweetDb = null;

        public TweetHandler()
	    {
	    	tweetDb = new TweetDBAccess();
	    }

        public List<Tweet> Tweet_List(string user_id)
        {
            return tweetDb.Tweet_List(user_id);
        }

        public List<Tweet> Tweet_List_Following(string user_id)
        {
            return tweetDb.Tweet_List_Following(user_id);
        }

        public bool Tweet_Delete(int tweet_id)
        {
            return tweetDb.Tweet_Delete(tweet_id);
        }

        public bool Tweet_Delete_Person(string user_id)
        {
            return tweetDb.Tweet_Delete_Person(user_id);
        }

        public int Tweet_Count(string user_id)
        {
            return tweetDb.Tweet_Count(user_id);
        }

        public bool Tweet_Update(Tweet tweet)
        {
            return tweetDb.Tweet_Update(tweet);
        }

        public bool Tweet_Add(Tweet tweet)
        {
            return tweetDb.Tweet_Add(tweet);
        }
    }
}