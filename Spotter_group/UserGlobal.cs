using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotter_group
{



    /*
    <User ID = "0" >
    < FirstName > Jason </ FirstName >
    < LastName > Merrill </ LastName >
    < BirthDate > 08 / 16 / 1983 </ BirthDate >
    < Username > jasonlmerrill </ Username >
    < StartDate > 08 / 16 / 1983 </ StartDate >
    < Gender > Male </ Gender >
    < CurrentWeight > 155 </ CurrentWeight >
    < CurrentHeight > 5'8"</CurrentHeight>
    <Password>password</Password>
    <Workout>Cardio</Workout>
    <Admin>No</Admin>

    */

    public class UserGlobal
    {

        private string user_Id;
        private string user_Password;
        private string user_Name;
        private string first_Name;
        private string last_Name;
        private string birth_Date;
        private string user_Gender;
        private string current_Weight;
        private string current_Height;
        private string workout;
        private string admin;
        private string user_images;

        
        

        public void set_user_id(string s)
        {
            this.user_Id = s;
        }

        public string get_username
        {
            get
            {
                return user_Id;
            }
        }


        public string get_user_password
        {
            get
            {
                return user_Password;
            }
        }


        public void set_user_password(string s)
        {
            this.user_Password = s;
        }


        public string get_user_Name
        {
            get
            {
                return user_Name;
            }
        }


        public void set_user_Name(string s)
        {
            this.user_Name = s;
        }

        public string get_First_Name
        {
            get
            {
                return first_Name;
            }
        }


        public void set_First_Name(string s)
        {
            this.first_Name = s;
        }

        public string get_Last_Name
        {
            get
            {
                return last_Name;
            }
        }


        public void set_Last_Name(string s)
        {
            this.last_Name = s;
        }

        public string get_Birth_Date
        {
            get
            {
                return birth_Date;
            }
        }


        public void set_Birth_Date(string s)
        {
            this.birth_Date = s;
        }

        public string get_Gender
        {
            get
            {
                return user_Gender;
            }
        }


        public void set_Gender(string s)
        {
            this.user_Gender = s;
        }

        public string get_Current_Weight
        {
            get
            {
                return this.current_Weight;
            }
        }


        public void set_Current_Weight(string s)
        {
            this.current_Weight = s;
        }


        public string get_Current_Height
        {
            get
            {
                return this.current_Height;
            }
        }


        public void set_Current_Height(string s)
        {
            this.current_Height = s;
        }

        public string get_Workout
        {
            get
            {
                return this.workout;
            }
        }


        public void set_Workout(string s)
        {
            this.workout = s;
        }

        public string get_Admin
        {
            get
            {
                return this.admin;
            }
        }


        public void set_Admin(string s)
        {
            this.admin = s;
        }

        public void set_User_Image(string s)
        {
            this.user_images = s;
        }

        public string get_User_Images
        {
            get
            {
                return this.user_images;
            }

        }


    }//end class

}//end name space
    




