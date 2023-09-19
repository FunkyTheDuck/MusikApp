﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDTOModels
{
    public class DtoWhiteList
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public DtoUser? User { get; set; }
        public string SongID { get; set; }
        public string SongArtistId { get; set; }
    }
}