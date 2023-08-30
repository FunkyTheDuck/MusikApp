﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDTOModels
{
    public class DtoUser
    {
        public int Id { get; set; }
        public string? ProfilPicture { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }
        [Required, MaxLength(255)]
        public string UserName { get; set; }
        [Required, MaxLength(50)]
        public string Mail { get; set; }
        public bool IsPremium { get; set; }
        public bool IsArtist { get; set; }
        public DtoWhiteList WhiteList { get; set; }
        public DtoBlackList BlackList { get; set; }
        public DtoSettings Settings { get; set; }
        public DtoPremium Premium { get; set; }
        public DtoArtist Artist { get; set; }
        public List<DtoFriend> Friends { get; set; }
    }
}