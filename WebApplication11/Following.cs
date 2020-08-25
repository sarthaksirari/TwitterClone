using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication11
{
    public class Following
    {
        string user_id;
        string following_id;
        string fullName;
        bool profilepic;
        string profilepicUrl;
        string user_idShow;

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

        public string Following_id
        {
            get
            {
                return following_id;
            }
            set
            {
                following_id = value;
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