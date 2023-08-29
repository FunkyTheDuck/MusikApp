using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModels
{
    public class Settings
    {
        public int id { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
        public string changeGenre { get; set; }
        public int howNewTheMusicIs { get; set; }
        public int howManyNotifications { get; set; }
    }
}
