using AppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusikApp.ViewModels
{
    public class FriendsPageViewModel : BaseViewModels
    {
        public List<User> friends { get; set; }
        public FriendsPageViewModel() 
        {

        }

    }
}
