using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper;
using MyWebAPI.Models;

namespace MyWebAPI
{
    public class UserRepository : IUserRepository
    {
        string _SqlCon = "Data Source=(local);Initial Catalog=UserDb;Integrated Security=True";
        public List<UserModel> GetUserList()
        {
            string sql = "SELECT UserId,UserName,UserType,City FROM UserDtls";
            using (var connection = new SqlConnection(_SqlCon))
            {
               return connection.Query<UserModel>(sql).ToList();
            }
        }
        public UserModel GetByUserName(string UserName)
        {
            string sql = "SELECT UserId,UserName,UserType,City FROM UserDtls WHERE UserName='" + UserName + "'";
            using (var connection = new SqlConnection(_SqlCon))
            {
               return connection.Query<UserModel>(sql).SingleOrDefault();
            }
        }
        public void AddUser(UserModel entity)
        {
            string sql = "INSERT INTO UserDtls (UserName,UserType,City) Values (@UserName,@UserType,@City)";
            using (var connection = new SqlConnection(_SqlCon))
            {
               connection.Execute(sql, new {UserName = entity.UserName, UserType = entity.UserType, City = entity.City});
            }
        }
        public void UpdateUser(UserModel entity, int UserId)
        {
            string sql = "UPDATE UserDtls SET UserName = @UserName, UserType=@UserType, City=@City WHERE UserId = @UserId";
            using (var connection = new SqlConnection(_SqlCon))
            {
               connection.Execute(sql, new {UserName = entity.UserName, UserType = entity.UserType, City = entity.City, UserId=UserId});
            }
        }
        public void DeleteUser(int UserId)
        {
            string sql = "DELETE FROM UserDtls WHERE UserId = @UserId";
            using (var connection = new SqlConnection(_SqlCon))
            {
               connection.Execute(sql, new {UserId=UserId});
            }
        }
    }
}