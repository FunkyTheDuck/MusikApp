using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModels
{
    public class User
    {
        public int Id { get; set; }
        public string? ProfilPicture { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(255)]
        public string UserName { get; set; }
        [MaxLength(50)]
        public string Mail { get; set; }
        [MaxLength(255)]
        public string Password { get; set; }
        public bool IsPremium { get; set; }
        public bool IsArtist { get; set; }
        public WhiteList? WhiteList { get; set; }
        public BlackList? BlackList { get; set; }
        public Settings? Settings { get; set; }
        public Premium? Premium { get; set; }
        public Artist? Artist { get; set; }
        public List<Friend>? Friends { get; set; } 
    }
}
