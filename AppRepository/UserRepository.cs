using AppDBAccess;
using AppDTOModels;
using AppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRepository
{
    public class UserRepository
    {
        DBContext db;
        public UserRepository()
        {
            db = new();
        }
        public async Task<User> GetUserAsync(string username, string password)
        {
            DtoUser dtoUser;
            try
            {
                dtoUser = await db.GetUserAsync(username, password);
            }
            catch (Exception)
            {
                return null;
            }
            if (dtoUser != null)
            {
                User user = new User
                {
                    Id = dtoUser.Id,
                    Name = dtoUser.Name,
                    LastName = dtoUser.LastName,
                    UserName = dtoUser.UserName,
                    Password = dtoUser.Password,
                    Mail = dtoUser.Mail,
                    IsPremium = dtoUser.IsPremium,
                    IsArtist = dtoUser.IsArtist,
                    ProfilPicture = dtoUser.ProfilPicture,
                };
                return user;
            }
            return null;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            DtoUser dtouser = new DtoUser();
            if (user != null) 
            {
                dtouser.Name = user.Name;
                dtouser.LastName = user.LastName;
                dtouser.UserName = user.UserName;
                dtouser.Password = user.Password;
                dtouser.Mail = user.Mail;
                dtouser.IsPremium = user.IsPremium;
                dtouser.IsArtist = user.IsArtist;
            }
            try
            {
                return await db.CreateUser(dtouser);
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
