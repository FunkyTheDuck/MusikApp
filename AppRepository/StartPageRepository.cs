using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRepository
{
    public class StartPageRepository
    {
        public async Task<bool> LikeSongAsync(int userId, int songId)
        {
            return true;
        }
        public async Task<bool> SkipSongAsync(int userId, int songId)
        {
            return true;
        }
    }
}
