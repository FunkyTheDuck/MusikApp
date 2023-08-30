using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDTOModels
{
    public class DtoFriend
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DtoUser User { get; set; }
        public int FriendId { get; set; }
        public DtoUser Friends { get; set; }
    }
}
