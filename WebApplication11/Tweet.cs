using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication11
{
    public class Tweet
    {
        int tweet_id;
        string user_id;
        string fullName;
        string message;
        DateTime created;
        bool profilepic;
        string profilepicUrl;
        string user_idShow;

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

        public string FullName
        {
            get
            {
                return fullName;
            }
            set
            {
                fullName = value;
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

        public bool ProfilePic
        {
            get
            {
                return profilepic;
            }
            set
            {
                profilepic = value;
            }
        }

        public string ProfilepicUrl
        {
            get
            {
                return profilepicUrl;
            }
            set
            {
                profilepicUrl = value;
            }
        }

        public string User_idShow
        {
            get
            {
                return user_idShow;
            }
            set
            {
                user_idShow = value;
            }
        }
    }
}