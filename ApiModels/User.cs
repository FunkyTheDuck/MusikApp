﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModels
{
    public class User
    {
        public int id { get; set; }
        public string? profilPicture { get; set; }
        [MaxLength(100)]
        public string name { get; set; }
        [MaxLength(100)]
        public string lastName { get; set; }
        [MaxLength(255)]
        public string userName { get; set; }
        [MaxLength(50)]
        public string mail { get; set; }
        public bool isPremium { get; set; }
        public bool isArtist { get; set; }
        public WhiteList whiteList { get; set; }
        public BlackList blackList { get; set; }
        public Settings settings { get; set; }
        public Premium premium { get; set; }
        public Artist artist { get; set; }
    }
}
