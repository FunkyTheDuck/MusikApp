using ApiDTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDBAccess
{
    public class Server : IServer
    {
        public List<DtoArtist> Artists { get; set; } = new List<DtoArtist>();
        public List<DtoArtistPayment> ArtistPayments { get; set; } = new List<DtoArtistPayment>();
        public List<DtoBlackList> Blacklists { get; set; } = new List<DtoBlackList>();
        public List<DtoPremium> Premiums { get; set; } = new List<DtoPremium>();
        public List<DtoSettings> Settings { get; set; } = new List<DtoSettings>();
        public List<DtoSong> Songs { get; set; } = new List<DtoSong>();
        public List<DtoUser> Users { get; set; } = new List<DtoUser>();
        public List<DtoWhiteList> Whitelists { get; set; } = new List<DtoWhiteList>();

        public Server() 
        { 
        
        }

        public async Task<List<DtoArtist>> GetArtists()
        {
            return Artists;
        }

        public async Task<DtoArtist> GetArtist(int id)
        {
            return Artists.FirstOrDefault(x => x.id == id);
        }

        public async Task<bool> Create(DtoArtist artist)
        {
            if (artist != null)
            {
                Artists.Add(artist);
                return true;
            }
            return false;
        }

        public async Task<bool> Update(DtoArtist artist)
        {
            DtoArtist a = new DtoArtist();
            try
            {
                a = Artists[Artists.IndexOf(Artists.FirstOrDefault(x => x.id == artist.id))];
            }
            catch
            {
                return false;
            }
            if (a != null)
            {
                Artists[Artists.IndexOf(a)] = artist;
                return true;
            }
            return false;
        }

        public async Task<List<DtoArtistPayment>> GetArtistPayments()
        {
            return ArtistPayments;
        }

        public async Task<DtoArtistPayment> GetArtistPayments(int id)
        {
            return ArtistPayments.FirstOrDefault(x => x.id == id);
        }

        public async Task<bool> Create(DtoArtistPayment artistPayments)
        {
            if (artistPayments != null)
            {
                ArtistPayments.Add(artistPayments);
                return true;
            }
            return false;
        }

        public async Task<bool> Update(DtoArtistPayment artistPayments)
        {
            DtoArtistPayment a = new DtoArtistPayment();
            try
            {
                a = ArtistPayments[ArtistPayments.IndexOf(ArtistPayments.FirstOrDefault(x => x.id == artistPayments.id))];
            }
            catch
            {
                return false;
            }
            if (a != null)
            {
                ArtistPayments[ArtistPayments.IndexOf(a)] = artistPayments;
                return true;
            }
            return false;
        }

        public async Task<List<DtoBlackList>> GetBlacklists()
        {
            return Blacklists;
        }

        public async Task<DtoBlackList> GetBlacklists(int id)
        {
            return Blacklists.FirstOrDefault(x => x.id == id);
        }

        public async Task<bool> Create(DtoBlackList blacklist)
        {
            if (blacklist != null)
            {
                Blacklists.Add(blacklist);
                return true;
            }
            return false;
        }

        public async Task<bool> Update(DtoBlackList blacklist)
        {
            DtoBlackList b = new DtoBlackList();
            try
            {
                b = Blacklists[Blacklists.IndexOf(Blacklists.FirstOrDefault(x => x.id == blacklist.id))];
            }
            catch
            {
                return false;
            }
            if (b != null)
            {
                Blacklists[Blacklists.IndexOf(b)] = blacklist;
                return true;
            }
            return false;
        }

        public async Task<List<DtoPremium>> GetPremiums()
        {
            return Premiums;
        }

        public async Task<DtoPremium> GetPremiums(int id)
        {
            return Premiums.FirstOrDefault(x => x.id == id);
        }

        public async Task<bool> Create(DtoPremium premium)
        {
            if (premium != null)
            {
                Premiums.Add(premium);
                return true;
            }
            return false;
        }

        public async Task<bool> Update(DtoPremium premium)
        {
            DtoPremium p = new DtoPremium();
            try
            {
                p = Premiums[Premiums.IndexOf(Premiums.FirstOrDefault(x => x.id == premium.id))];
            }
            catch
            {
                return false;
            }
            if (p != null)
            {
                Premiums[Premiums.IndexOf(p)] = premium;
                return true;
            }
            return false;
        }

        public async Task<List<DtoSettings>> GetSettings()
        {
            return Settings;
        }

        public async Task<DtoSettings> GetSettings(int id)
        {
            return Settings.FirstOrDefault(x => x.id == id);
        }

        public async Task<bool> Create(DtoSettings settings)
        {
            if (settings != null)
            {
                Settings.Add(settings);
                return true;
            }
            return false;
        }

        public async Task<bool> Update(DtoSettings settings)
        {
            DtoSettings s = new DtoSettings();
            try
            {
                s = Settings[Settings.IndexOf(Settings.FirstOrDefault(x => x.id == settings.id))];
            }
            catch
            {
                return false;
            }
            if (s != null)
            {
                Settings[Settings.IndexOf(s)] = settings;
                return true;
            }
            return false;
        }

        public async Task<List<DtoSong>> GetSongs()
        {
            return Songs;
        }

        public async Task<DtoSong> GetSongs(int id)
        {
            return Songs.FirstOrDefault(x => x.id == id);
        }

        public async Task<bool> Create(DtoSong songs)
        {
            if (songs != null)
            {
                Songs.Add(songs);
                return true;
            }
            return false;
        }

        public async Task<bool> Update(DtoSong songs)
        {
            DtoSong s = new DtoSong();
            try
            {
                s = Songs[Songs.IndexOf(Songs.FirstOrDefault(x => x.id == songs.id))];
            }
            catch
            {
                return false;
            }
            if (s != null)
            {
                Songs[Songs.IndexOf(s)] = songs;
                return true;
            }
            return false;
        }

        public async Task<List<DtoUser>> GetUsers()
        {
            return Users;
        }

        public async Task<DtoUser> GetUsers(int id)
        {
            return Users.FirstOrDefault(x => x.id == id);
        }

        public async Task<bool> Create(DtoUser user)
        {
            if (user != null)
            {
                Users.Add(user);
                return true;
            }
            return false;
        }

        public async Task<bool> Update(DtoUser user)
        {
            DtoUser u = new DtoUser();
            try
            {
                u = Users[Users.IndexOf(Users.FirstOrDefault(x => x.id == user.id))];
            }
            catch
            {
                return false;
            }
            if (u != null)
            {
                Users[Users.IndexOf(u)] = user;
                return true;
            }
            return false;
        }

        public async Task<List<DtoWhiteList>> GetWhitelists()
        {
            return Whitelists;
        }

        public async Task<DtoWhiteList> GetWhitelists(int id)
        {
            return Whitelists.FirstOrDefault(x => x.id == id);
        }

        public async Task<bool> Create(DtoWhiteList whitelist)
        {
            if (whitelist != null)
            {
                Whitelists.Add(whitelist);
                return true;
            }
            return false;
        }

        public async Task<bool> Update(DtoWhiteList whitelist)
        {
            DtoWhiteList w = new DtoWhiteList();
            try
            {
                w = Whitelists[Whitelists.IndexOf(Whitelists.FirstOrDefault(x => x.id == whitelist.id))];
            }
            catch
            {
                return false;
            }
            if (w != null)
            {
                Whitelists[Whitelists.IndexOf(w)] = whitelist;
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
