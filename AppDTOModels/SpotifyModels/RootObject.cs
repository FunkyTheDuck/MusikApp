﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDTOModels.SpotifyModels
{
    public class Rootobject
    {
        public Track[] tracks { get; set; }
        public Seed[] seeds { get; set; }
    }
}
