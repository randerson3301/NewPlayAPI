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
    public class GameController : ControllerBase
    {
        private readonly IGameRepository _repo;

        public GameController(){
            var service = SimpleInjectorContainer.GetInstance<IGameRepository>();
            _repo = (IGameRepository)service;
        }

        [HttpGet]
        public IEnumerable<Game> GetAll(){
            return _repo.GetAll();
        }
                                           
        [HttpGet]
        [Route("filterBy")]
        public object GetByFilter(string id=null, string userId=null, DateTime? startDate=null, 
        DateTime? finishDate=null, bool? active = null){
            object response = null;

            if(userId != null)
                response = _repo.GetGamesByUserId(userId);
            else
                response = _repo.FilterBy(id, startDate, finishDate, active);
                        
            return response;
        }
        
        [HttpPost]
        public object Add(Game game){
            try {
                game.Id = Guid.NewGuid().ToString();
                game.CreationDate = DateTime.Now;

                _repo.Add(game);
                
                var controllerAction = new ControllerActionDescriptor();

                string actionName = controllerAction.ActionName;
                
                return CreatedAtAction(actionName, game);
            } catch(Exception error){
                throw error;
            }
        }

        [HttpPut]
        public void Update(Game game, bool? isDisabling=null){
            try {
                //disable game           
                if(isDisabling == true){
                    game.DisableDate = DateTime.Now;
                    //tirar o id mocado e implementar autenticação
                    game.DisableUserId = "120a78f5-8f10-46d2-9a2d-765ea9991c9b";
                }

                _repo.Update(game);
                               
            } catch (Exception error){
                throw error;
            }            
        }
    }
}