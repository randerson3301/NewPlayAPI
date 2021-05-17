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
    public class UserGenreController: ControllerBase
    {
        private readonly IUserGenreRepository _repo;

        public UserGenreController(){
            var service = SimpleInjectorContainer.GetInstance<IUserGenreRepository>();
            _repo = (IUserGenreRepository)service;
        }

        [HttpGet]
        public IEnumerable<UserGenre> GetAll(){
            return _repo.GetAll();
        }

        [HttpPost]
        public object Add(UserGenre userGenre){
            try {
                userGenre.Id = Guid.NewGuid().ToString();
                userGenre.CreationDate = DateTime.Now;

                _repo.Add(userGenre);
                
                var controllerAction = new ControllerActionDescriptor();

                string actionName = controllerAction.ActionName;
                
                return CreatedAtAction(actionName, userGenre);
            } catch(Exception error){
                throw error;
            }
        }

        [HttpDelete]
        public object Remove(UserGenre userGenre){
            try {
                _repo.Remove(userGenre);                                               
                return NoContent();
            } catch(Exception error){
                throw error;
            }
        }
    }
}