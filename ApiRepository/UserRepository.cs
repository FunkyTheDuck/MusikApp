using ApiDBAccess;
using ApiDTOModels;
using System;

namespace ApiRepository
{
    public class UserRepository : IUserRepository
    {
        IServer server { get; set; }
        public UserRepository()
        {
            server = new Server();
        }
       
        public async Task<bool> Create(DtoUser user)
        {
            return await server.Create(user);
        }
        
        public async Task<List<DtoUser>> GetUsers()
        {
            return await server.GetUsers();
        }

        public async Task<DtoUser> GetUsers(int id)
        {
            return await server.GetUsers(id);
        }

        public async Task<bool> Update(DtoUser user)
        {
            return await server.Update(user);
        }
        public async Task<bool> Delete(int id)
        {
            return await server.Delete(id);
        }
    }
}