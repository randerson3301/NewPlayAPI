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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;

        public UserController(){
            var service = SimpleInjectorContainer.GetInstance<IUserRepository>();
            _repo = (IUserRepository)service;
        }

        [HttpGet]
        public IEnumerable<User> GetAll(){
            return _repo.GetAll();
        }
        
        [HttpGet]
        [Route("filterBy")]
        public object GetByFilter(string id=null, DateTime? startDate=null, 
        DateTime? finishDate=null, bool? active = null, string role=null){
            object response = null;

            response = _repo.FilterBy(id, startDate, finishDate, active, role);
                        
            return response;
        }

        [HttpGet]
        [Route("profile")]
        public object GetByValue(string id){
            object response = null;

            response = _repo.GetAssociatedGamesPlatformAndGenres(id);
                        
            return response;
        }


        [HttpPost]
        public object Add(User user){
            try {
                user.Id = Guid.NewGuid().ToString();
                user.CreationDate = DateTime.Now;

                _repo.Add(user);
                
                var controllerAction = new ControllerActionDescriptor();

                string actionName = controllerAction.ActionName;
                
                return CreatedAtAction(actionName, user);
            } catch(Exception error){
                throw error;
            }
        }

        [HttpPut]
        public void Update(User user, bool? isDisabling=null){
            try {
                //disable user           
                if(isDisabling == true){
                    user.DisableDate = DateTime.Now;
                    //tirar o id mocado e implementar autenticação
                    user.DisableUserId = "120a78f5-8f10-46d2-9a2d-765ea9991c9b";
                }

                _repo.Update(user);
                               
            } catch (Exception error){
                throw error;
            }            
        }
    }
}