using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotter_group
{

     

    public class UserGlobal
    {

        private string user_name;
        private string user_password;

        public void set_username(string s)
        {
            this.user_name = s;
        }

        public string get_username
        {
            get
            {
                return user_name;
            }
        }


        public string get_user_password
        {
            get
            {
                return user_password;
            }
        }


        public void set_user_password(string s)
        {
            this.user_password = s;
        }




    }


       


    }
    




