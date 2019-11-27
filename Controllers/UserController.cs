using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var userlist = this._userRepository.GetUserList();
            return Ok(userlist);
        }

        [HttpGet]
        [Route("{UserName}")]
        public IActionResult GetByUserName(string UserName)
        {
            var userlist = this._userRepository.GetByUserName(UserName);
            return Ok(userlist);
        }

        [HttpPost]
        public IActionResult AddUser(UserModel entity)
        {
            _userRepository.AddUser(entity);
            return Ok(entity);
        }

        [HttpPut]
        [Route("{UserId}")]
        public IActionResult UpdateUser(UserModel entity, int UserId)
        {
            _userRepository.UpdateUser(entity, UserId);
            return Ok(entity);
        }

        [HttpDelete]
        [Route("{UserId}")]
        public IActionResult DeleteUser(int UserId)
        {
            _userRepository.DeleteUser(UserId);
            return Ok();
        }
    }
}