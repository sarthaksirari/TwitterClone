using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication11
{
    public class Person
    {
        string user_id;
        byte[] password;
        string fullName;
        string email;
        DateTime joined;
        bool active;
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

        public byte[] Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
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

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public DateTime Joined
        {
            get
            {
                return joined;
            }
            set
            {
                joined = value;
            }
        }

        public bool Active
        {
            get
            {
                return active;
            }
            set
            {
                active = value;
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