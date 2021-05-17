using System;
using System.Linq;
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
    public class UserGameController : ControllerBase
    {
        private readonly IUserGameRepository _repo;

        public UserGameController(){
            var service = SimpleInjectorContainer.GetInstance<IUserGameRepository>();
            _repo = (IUserGameRepository)service;
        }

        [HttpPost]
        public object Add(UserGame userGame){
            try {
                userGame.Id = Guid.NewGuid().ToString();
                userGame.CreationDate = DateTime.Now;

                _repo.Add(userGame);
                
                var controllerAction = new ControllerActionDescriptor();

                string actionName = controllerAction.ActionName;
                
                return CreatedAtAction(actionName, userGame);
            } catch(Exception error){
                throw error;
            }
        }

        [HttpDelete]
        public object Remove(UserGame userGame){
            try {
                _repo.Remove(userGame);                                               
                return NoContent();
            } catch(Exception error){
                throw error;
            }
        }
    }
}