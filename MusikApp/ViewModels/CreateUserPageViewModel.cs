using AppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusikApp.ViewModels
{
    public class CreateUserPageViewModel
    {
        public string Name {get; set ;}
        public string LastName {get; set;}
        public string UserName {get; set;}
        public string Mail {get; set;}
        public string Password {get; set;}

        public void CreateUser()
        {
            User user = new User
            {
                Name = Name,
                LastName = LastName,
                UserName = UserName,
                Mail = Mail,
                Password = Password,
            };
            //api kald til at lave brugeren
        }

    }
}
