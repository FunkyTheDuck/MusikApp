using AppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MusikApp.ViewModels
{
    public class FriendsPageViewModel : BaseViewModels
    {
        public List<User> Friends { get; set; }
        public FriendsPageViewModel()
        {
            Friends = new List<User>();
            User user = new User()
            {
                Id = 1,
                ProfilPicture = "profilbillede.jpg",
                Name = "Justin",
                LastName = "Bieber",
                UserName = "JustinB",
                Password = "Bruger123",
                Mail = "justinbieber@hotmail.com",
                IsPremium = true,
                IsArtist = true,
                LastOnline = DateTime.Now
            };
            User user1 = new User()
            {
                Id = 2,
                ProfilPicture = "profilbillede.jpg",
                Name = "Justin",
                LastName = "Bieber",
                UserName = "JustinB",
                Password = "Bruger123",
                Mail = "justinbieber@hotmail.com",
                IsPremium = true,
                IsArtist = true,
                LastOnline = DateTime.Now
            };
            User user2 = new User()
            {
                Id = 3,
                ProfilPicture = "profilbillede.jpg",
                Name = "Justin",
                LastName = "Bieber",
                UserName = "JustinB",
                Password = "Bruger123",
                Mail = "justinbieber@hotmail.com",
                IsPremium = true,
                IsArtist = true,
                LastOnline = DateTime.Now
            };
            Friends.Add(user);
            Friends.Add(user1);
            Friends.Add(user2);
            OnPropChanged(nameof(Friends));
        }

    }
}
