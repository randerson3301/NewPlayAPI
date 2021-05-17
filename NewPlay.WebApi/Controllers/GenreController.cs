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
    public class GenreController: ControllerBase
    {
        private readonly IGenreRepository _repo;

        public GenreController(){
            var service = SimpleInjectorContainer.GetInstance<IGenreRepository>();
            _repo = (IGenreRepository)service;
        }

        [HttpGet]
        public IEnumerable<Genre> GetAll(){
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
        public object Add(Genre genre){
            try {
                genre.CreationDate = DateTime.Now;

                _repo.Add(genre);
                
                var controllerAction = new ControllerActionDescriptor();

                string actionName = controllerAction.ActionName;
                
                return CreatedAtAction(actionName, genre);
            } catch(Exception error){
                throw error;
            }
        }

        [HttpPut]
        public void Update(Genre genre, bool? isDisabling=null){
            try {
                //disable genre           
                if(isDisabling == true){
                    genre.DisableDate = DateTime.Now;
                    //tirar o id mocado e implementar autenticação
                    genre.DisableUserId = "120a78f5-8f10-46d2-9a2d-765ea9991c9b";
                }

                _repo.Update(genre);
                               
            } catch (Exception error){
                throw error;
            }            
        }
    }
}