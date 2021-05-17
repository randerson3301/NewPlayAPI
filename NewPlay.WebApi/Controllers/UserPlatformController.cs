using System;
using System.Collections.Generic;
using NewPlay.Domain.Models;
using NewPlay.Domain.Interfaces;
using NewPlay.Infrastructure.IoC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace NewPlay.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserPlatformController : ControllerBase
    {
        private readonly IUserPlatformRepository _repo;

        public UserPlatformController(){
            var service = SimpleInjectorContainer.GetInstance<IUserPlatformRepository>();
            _repo = (IUserPlatformRepository)service;
        }

        [HttpGet]
        public IEnumerable<UserPlatform> GetAll(){
            return _repo.GetAll();
        }

        [HttpPost]
        public object Add(UserPlatform userPlatform){
            try {
                userPlatform.Id = Guid.NewGuid().ToString();
                userPlatform.CreationDate = DateTime.Now;

                _repo.Add(userPlatform);
                
                var controllerAction = new ControllerActionDescriptor();

                string actionName = controllerAction.ActionName;
                
                return CreatedAtAction(actionName, userPlatform);
            } catch(Exception error){
                throw error;
            }
        }

        [HttpDelete]
        public object Remove(UserPlatform userPlatform){
            try {
                _repo.Remove(userPlatform);                                               
                return NoContent();
            } catch(Exception error){
                throw error;
            }
        }
    }
}