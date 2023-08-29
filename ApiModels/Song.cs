﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModels
{
    public class Song
    {
        public int id { get; set; }
        public int artistId { get; set; }
        public Artist artist { get; set; }
        [MaxLength(100)]
        public string name { get; set; }
        [MaxLength(255)]
        public string albumImage { get; set; }
        public byte[] audioExample { get; set; }
        [MaxLength(100)]
        public List<string> genre { get; set; }
        public WhiteList whiteList { get; set; }
        public BlackList blackList { get; set; }
    }
}
