using JWTASPNetCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace JWTASPNetCore.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly List<UserDTO> users = new List<UserDTO>();
        public UserRepository()
        {
            users.Add(new UserDTO { UserName = "nvmanh", Password = "12345678", Role = "manager" });
        }
        public UserDTO GetUser(UserModel userModel)
        {
            return users.Where(x => x.UserName.ToLower() == userModel.UserName.ToLower()
                && x.Password == userModel.Password).FirstOrDefault();
        }
    }
}
