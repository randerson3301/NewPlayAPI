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
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRepository _repo;

        public PublisherController(){
            var service = SimpleInjectorContainer.GetInstance<IPublisherRepository>();
            _repo = (IPublisherRepository)service;
        }

        [HttpGet]
        public IEnumerable<Publisher> GetAll(){
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
        public object Add(Publisher publisher){
            try {
                publisher.CreationDate = DateTime.Now;

                _repo.Add(publisher);
                
                var controllerAction = new ControllerActionDescriptor();

                string actionName = controllerAction.ActionName;
                
                return CreatedAtAction(actionName, publisher);
            } catch(Exception error){
                throw error;
            }
        }

        [HttpPut]
        public void Update(Publisher publisher, bool? isDisabling=null){
            try {
                //disable publisher           
                if(isDisabling == true){
                    publisher.DisableDate = DateTime.Now;
                    //tirar o id mocado e implementar autenticação
                    publisher.DisableUserId = "120a78f5-8f10-46d2-9a2d-765ea9991c9b";
                }

                _repo.Update(publisher);
                               
            } catch (Exception error){
                throw error;
            }            
        }
    }
}