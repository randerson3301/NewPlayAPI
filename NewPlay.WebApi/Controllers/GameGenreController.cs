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
    public class GameGenreController : ControllerBase
    {
        private readonly IGameGenreRepository _repo;

        public GameGenreController(){
            var service = SimpleInjectorContainer.GetInstance<IGameGenreRepository>();
            _repo = (IGameGenreRepository)service;
        }

        [HttpGet]
        public IEnumerable<GameGenre> GetAll(){
            return _repo.GetAll();
        }

        [HttpPost]
        public object Add(GameGenre gameGenre){
            try {
                gameGenre.CreationDate = DateTime.Now;

                _repo.Add(gameGenre);
                
                var controllerAction = new ControllerActionDescriptor();

                string actionName = controllerAction.ActionName;
                
                return CreatedAtAction(actionName, gameGenre);
            } catch(Exception error){
                throw error;
            }
        }

        [HttpDelete]
        public object Remove(GameGenre gameGenre){
            try {
                _repo.Remove(gameGenre);                                               
                return NoContent();
            } catch(Exception error){
                throw error;
            }
        }
    }
}