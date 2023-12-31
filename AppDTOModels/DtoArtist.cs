﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDTOModels
{
    public class DtoArtist
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DtoUser User { get; set; }
        public List<string>? HighlightSong { get; set; }
        public DtoArtistPayment ArtistPayment { get; set; }
    }
}
