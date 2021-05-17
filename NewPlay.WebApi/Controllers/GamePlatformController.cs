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
    public class GamePlatformController : ControllerBase
    {
        private readonly IGamePlatformRepository _repo;

        public GamePlatformController(){
            var service = SimpleInjectorContainer.GetInstance<IGamePlatformRepository>();
            _repo = (IGamePlatformRepository)service;
        }

        [HttpGet]
        public IEnumerable<GamePlatform> GetAll(){
            return _repo.GetAll();
        }

        [HttpPost]
        public object Add(GamePlatform gamePlatform){
            try {
                gamePlatform.CreationDate = DateTime.Now;

                _repo.Add(gamePlatform);
                
                var controllerAction = new ControllerActionDescriptor();

                string actionName = controllerAction.ActionName;
                
                return CreatedAtAction(actionName, gamePlatform);
            } catch(Exception error){
                throw error;
            }
        }

        [HttpDelete]
        public object Remove(GamePlatform gamePlatform){
            try {
                _repo.Remove(gamePlatform);                                               
                return NoContent();
            } catch(Exception error){
                throw error;
            }
        }
    }
}