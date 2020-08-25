using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication11
{
    public class ProfileCoverPic
    {
        string user_id;
        bool profilepic;
        bool coverpic;

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

        public bool CoverPic
        {
            get
            {
                return coverpic;
            }
            set
            {
                coverpic = value;
            }
        }
    }
}