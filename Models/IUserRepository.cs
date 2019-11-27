using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebAPI.Models;

namespace MyWebAPI
{
    public interface IUserRepository
    {
        List<UserModel> GetUserList();
        UserModel GetByUserName(string UserName);
        void AddUser(UserModel entity);
        void UpdateUser(UserModel entity, int UserId);
        void DeleteUser(int UserId);

    }
}