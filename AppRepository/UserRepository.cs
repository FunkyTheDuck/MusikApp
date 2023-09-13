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

    }
}
