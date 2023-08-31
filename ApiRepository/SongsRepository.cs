using ApiDBAccess;
using ApiDTOModels;
using ApiModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRepository
{
    public class SongsRepository : ISongsRepository
    {
        Database db = new();
        public async Task<List<Song>> GetSongs()
        {
            List<Song> songs = new();
            List<DtoSong> dtoSongs;

            try
            {
                dtoSongs = await db.Songs.ToListAsync();
            }
            catch (Exception)
            {

                return new List<Song>();
            }

            foreach (DtoSong song in dtoSongs)
            {
                Song UiSong = new Song
                {
                    Id = song.Id,
                    AlbumImage = song.AlbumImage,
                    ArtistId = song.ArtistId,
                    AudioExample = song.AudioExample,
                    Genre = song.Genre,
                    Name = song.Name,
                };
                songs.Add(UiSong);
            }
            return songs;
        }

        public async Task<Song> GetSongs(int id)
        {
            DtoSong dtoSong;
            dtoSong = await db.Songs.FirstOrDefaultAsync(x => x.Id == id);

            Song song = new Song
            {
                Id = dtoSong.Id,
                ArtistId = dtoSong.ArtistId,
                Name = dtoSong.Name,
                AlbumImage = dtoSong.AlbumImage,
                AudioExample = dtoSong.AudioExample,
                Genre = dtoSong.Genre,
            };

            return song;
        }

        public async Task<bool> Create(Song Song)
        {
            DtoSong dtoSong = new DtoSong
            {
                Id = Song.Id,
                ArtistId = Song.ArtistId,
                AlbumImage = Song.AlbumImage,
                AudioExample = Song.AudioExample,
                Genre = Song.Genre,
                Name = Song.Name,
            };
            await db.Songs.AddAsync(dtoSong);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Update(Song song)
        {
            DtoSong dtoSong = new DtoSong
            {
                Id = song.Id,
                ArtistId = song.ArtistId,
                AlbumImage = song.AlbumImage,
                AudioExample = song.AudioExample,
                Genre = song.Genre,
                Name = song.Name,
            };
            db.Songs.Update(dtoSong);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            DtoSong song = await db.Songs.FirstOrDefaultAsync(x => x.Id == id);

            db.Songs.Remove(song);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
