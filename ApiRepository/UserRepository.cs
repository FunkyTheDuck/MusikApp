using ApiDBAccess;
using ApiDTOModels;
using ApiModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace ApiRepository
{
    public class UserRepository : IUserRepository
    {
        Database db;
        public UserRepository()
        {
            db = new Database();
        }
        public async Task<List<User>> GetUsers()
        {
            List<User> users = new();
            List<DtoUser> dtoUsers;
            try
            {
                dtoUsers = await db.Users.ToListAsync();
            }
            catch (Exception)
            {
                return new List<User>();
            }

            foreach (DtoUser dtoUser in dtoUsers)
            {
                User user = new User
                {
                    Id = dtoUser.Id,
                    ProfilPicture = dtoUser.ProfilPicture,
                    UserName = dtoUser.UserName,
                    Name = dtoUser.Name,
                    LastName = dtoUser.LastName,
                    Mail = dtoUser.Mail,
                    Password = dtoUser.Password,
                    IsArtist = dtoUser.IsArtist,
                    IsPremium = dtoUser.IsPremium,
                };
                users.Add(user);
            }
            return users;
        }
        public async Task<User> GetUsers(int id)
        {
            DtoUser dtoUser;
            dtoUser = await db.Users.FirstOrDefaultAsync(x => x.Id == id);
            User user = new User
            {
                Id = dtoUser.Id,
                ProfilPicture = dtoUser.ProfilPicture,
                UserName = dtoUser.UserName,
                Name = dtoUser.Name,
                LastName = dtoUser.LastName,
                Mail = dtoUser.Mail,
                Password = dtoUser.Password,
                IsArtist = dtoUser.IsArtist,
                IsPremium = dtoUser.IsPremium,
            };
            return user;
        }

        public async Task<User> GetUserAsync(string username, string password)
        {
            DtoUser dtoUser;
            dtoUser = await db.Users.FirstOrDefaultAsync(x => x.UserName == username && x.Password == password);
            User user = new User
            {
                Id = dtoUser.Id,
                ProfilPicture = dtoUser.ProfilPicture,
                UserName = dtoUser.UserName,
                Name = dtoUser.Name,
                LastName = dtoUser.LastName,
                Mail = dtoUser.Mail,
                Password = dtoUser.Password,
                IsArtist = dtoUser.IsArtist,
                IsPremium = dtoUser.IsPremium,
            };
            return user;
        }
        public async Task<bool> Create(User user)
        {
            DtoUser dtoUser = new DtoUser
            {
                Id = user.Id,
                ProfilPicture = user.ProfilPicture,
                UserName = user.UserName,
                Name = user.Name,
                LastName = user.LastName,
                Mail = user.Mail,
                Password = user.Password,
                IsArtist = user.IsArtist,
                IsPremium = user.IsPremium,
            };
            await db.Users.AddAsync(dtoUser);
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

        public async Task<bool> Update(User user)
        {
            DtoUser dtoUser = new DtoUser
            {
                Id = user.Id,
                ProfilPicture = user.ProfilPicture,
                UserName = user.UserName,
                Name = user.Name,
                LastName = user.LastName,
                Mail = user.Mail,
                Password = user.Password,
                IsArtist = user.IsArtist,
                IsPremium = user.IsPremium,
            };
            db.Users.Update(dtoUser);
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
            DtoUser user = await db.Users.FirstOrDefaultAsync(x => x.Id == id);
            db.Users.Remove(user);
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