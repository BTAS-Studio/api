using BTAS.API.Dto;
using BTAS.API.Extensions;
using BTAS.API.Models;
using BTAS.API.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTAS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenericController<T> : Controller where T : class
    {
        private readonly IRepository<T> _repository;
        protected GeneralResponse _response;

        public GenericController(IRepository<T> repository)
        {
            this._response = new GeneralResponse();
            _repository = repository;
        }

        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<object> GetAsync(bool includeChild = false)
        {
            try
            {
                if (includeChild)
                {
                    IEnumerable<T> entities = await _repository.GetAllAsyncWithChildren();
                    _response.result = entities;
                }
                else
                {
                    IEnumerable<T> entities = await _repository.GetAllAsync();
                    _response.result = entities;
                }
                
            }
            catch (Exception ex)
            {
                _response.success = false;
                _response.errorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("{id}")]
        public async Task<object> GetAsync(int id)
        {
            try
            {
                T entity = await _repository.GetByIdAsync(id);
                _response.result = entity;
            }
            catch (Exception ex)
            {
                _response.success = false;
                _response.errorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<object> PostAsync([FromBody] T entity)
        {
            try
            {
                T postedEntity = await _repository.CreateUpdateAsync(entity);

                _response.result = postedEntity;
            }
            catch (Exception ex)
            {
                _response.success = false;
                _response.errorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpPut]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<object> PutAsync([FromBody] T entity)
        {
            try
            {
                T updatedEntity = await _repository.CreateUpdateAsync(entity);

                _response.result = updatedEntity;
            }
            catch (Exception ex)
            {
                _response.success = false;
                _response.errorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        //[HttpDelete]
        //[ApiExplorerSettings(IgnoreApi = true)]
        //[Route("{id}")]
        //public async Task<bool> DeleteAsync(int id)
        //{
        //    try
        //    {
        //        bool result = await _repository.DeleteAsync(id);

        //        _response.result = result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //    return true;
        //}
    }
}
