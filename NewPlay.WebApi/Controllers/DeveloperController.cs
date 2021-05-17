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
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperRepository _repo;

        public DeveloperController(){
            var service = SimpleInjectorContainer.GetInstance<IDeveloperRepository>();
            _repo = (IDeveloperRepository)service;
        }

        [HttpGet]
        public IEnumerable<Developer> GetAll(){
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
        public object Add(Developer developer){
            try {
                developer.CreationDate = DateTime.Now;

                _repo.Add(developer);
                
                var controllerAction = new ControllerActionDescriptor();

                string actionName = controllerAction.ActionName;
                
                return CreatedAtAction(actionName, developer);
            } catch(Exception error){
                throw error;
            }
        }

        [HttpPut]
        public void Update(Developer developer, bool? isDisabling=null){
            try {
                //disable developer           
                if(isDisabling == true){
                    developer.DisableDate = DateTime.Now;
                    //tirar o id mocado e implementar autenticação
                    developer.DisableUserId = "120a78f5-8f10-46d2-9a2d-765ea9991c9b";
                }

                _repo.Update(developer);
                               
            } catch (Exception error){
                throw error;
            }            
        }
    }
}