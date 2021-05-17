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
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepository _repo;

        public PlatformController(){
            var service = SimpleInjectorContainer.GetInstance<IPlatformRepository>();
            _repo = (IPlatformRepository)service;
        }

        [HttpGet]
        public IEnumerable<Platform> GetAll(){
            return _repo.GetAll();
        }
        
        [HttpGet]
        [Route("filterBy")]
        public object GetByFilter(int? id=null, DateTime? startDate=null, 
        DateTime? finishDate=null, bool? active = null){
            object response = null;

            response = _repo.FilterBy(id, startDate, finishDate, active);
                        
            return response;
        }

        [HttpPost]
        public object Add(Platform platform){
            try {
                platform.CreationDate = DateTime.Now;

                _repo.Add(platform);
                
                var controllerAction = new ControllerActionDescriptor();

                string actionName = controllerAction.ActionName;
                
                return CreatedAtAction(actionName, platform);
            } catch(Exception error){
                throw error;
            }
        }

        [HttpPut]
        public void Update(Platform platform, bool? isDisabling=null){
            try {
                //disable platform           
                if(isDisabling == true){
                    platform.DisableDate = DateTime.Now;
                    //tirar o id mocado e implementar autenticação
                    platform.DisableUserId = "120a78f5-8f10-46d2-9a2d-765ea9991c9b";
                }

                _repo.Update(platform);
                               
            } catch (Exception error){
                throw error;
            }            
        }
    }
}