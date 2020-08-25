using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication11
{
    public class ProfileCoverPicHandler
    {
        ProfileCoverPicDBAccess profilecoverpicDb = null;

        public ProfileCoverPicHandler()
        {
            profilecoverpicDb = new ProfileCoverPicDBAccess();
        }

        public bool ProfileCoverPic_Add(string user_id)
        {
            return profilecoverpicDb.ProfileCoverPic_Add(user_id);
        }

        public bool ProfilePic_Update(string user_id)
        {
            return profilecoverpicDb.ProfilePic_Update(user_id);
        }


        public bool CoverPic_Update(string user_id)
        {
            return profilecoverpicDb.CoverPic_Update(user_id);
        }

        public bool ProfilePic_Delete(string user_id)
        {
            return profilecoverpicDb.ProfilePic_Delete(user_id);
        }

        public bool CoverPic_Delete(string user_id)
        {
            return profilecoverpicDb.CoverPic_Delete(user_id);
        }

        public bool ProfileCoverPic_Delete(string user_id)
        {
            return profilecoverpicDb.ProfileCoverPic_Delete(user_id);
        }

        public ProfileCoverPic ProfileCoverPic_Details(string user_id)
        {
            return profilecoverpicDb.ProfileCoverPic_Details(user_id);
        }
    }
}