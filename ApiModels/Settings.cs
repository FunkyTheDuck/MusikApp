using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModels
{
    public class Settings
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        [MaxLength(255)]
        public string ChangeGenre { get; set; }
        public int HowNewTheMusicIs { get; set; }
        public int HowManyNotifications { get; set; }
    }
}
