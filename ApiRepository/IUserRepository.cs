using ApiDTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRepository
{
    public interface IUserRepository
    {
        Task<List<DtoUser>> GetUsers();
        Task<DtoUser> GetUsers(int id);
        Task<bool> Create(DtoUser user);
        Task<bool> Update(DtoUser user);
        Task<bool> Delete(int id);
    }
}
