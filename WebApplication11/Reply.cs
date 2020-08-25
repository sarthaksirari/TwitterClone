using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication11
{
    public class Reply
    {
        int reply_id;
        int tweet_id;
        string user_id;
        string message;
        DateTime created;

        public int Reply_id
        {
            get
            {
                return reply_id;
            }
            set
            {
                reply_id = value;
            }
        }

        public int Tweet_id
        {
            get
            {
                return tweet_id;
            }
            set
            {
                tweet_id = value;
            }
        }

        public string User_id
        {
            get
            {
                return user_id;
            }
            set
            {
                user_id = value;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }

        public DateTime Created
        {
            get
            {
                return created;
            }
            set
            {
                created = value;
            }
        }
    }
}