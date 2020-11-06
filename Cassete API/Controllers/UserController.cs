using Cassete_API.Models;
using Cassete_API.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cassete_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //GET api/user
        [HttpGet]
        public List<UserModel> GetAll()
        {
            return _userService.GetAll();
        }

        //GET api/user/5
        [HttpGet("{id}")]
        public UserModel Get(int id)
        {
            return _userService.Get(id);
        }

        //GET api/user/search
        [Route("search")]
        [HttpGet]
        public UserModel Get(string subString)
        {
            return _userService.Search(subString);
        }

        //POST api/user
        [HttpPost]
        public void AddUser(UserModel user)
        {
            _userService.Add(user);
        }

        //PUT api/user/
        [HttpPut]
        public void UpdateUser(UserModel user)
        {
            _userService.Update(user);
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
            _userService.Delete(id);
        }
    }
}
