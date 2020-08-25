using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication11
{
    public class PersonHandler
    {
	    PersonDBAccess personDb = null;

	    public PersonHandler()
	    {
	    	personDb = new PersonDBAccess();
	    }

	    public List<Person> Person_List()
	    {
            return personDb.Person_List();
	    }

        public bool Person_Add(Person person)
        {
            return personDb.Person_Add(person);
        }

        public bool Person_Update(Person person)
    	{
            return personDb.Person_Update(person);
    	}

        public bool Person_Password_Update(Person person)
        {
            return personDb.Person_Password_Update(person);
        }

        public Person Person_Details(string user_id)
    	{
            return personDb.Person_Details(user_id);
    	}

        public bool Person_Delete(string user_id)
    	{
            return personDb.Person_Delete(user_id);
    	}

        public Person Login(string user)
    	{
            return personDb.Login(user);
    	}

        public List<Person> Search_User(string user)
        {
            return personDb.Search_User(user);
        }

        public List<Person> Search_Results(string user)
        {
            return personDb.Search_Results(user);
        }
    }
}