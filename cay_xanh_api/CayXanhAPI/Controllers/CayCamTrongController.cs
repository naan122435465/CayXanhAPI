using CayXanhAPI.BAL.Interfaces;
using CayXanhAPI.BAL.Repositories;
using CayXanhAPI.Controllers;
using CayXanhAPI.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CayXanhApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CayCamTrongController :  BaseApiController
    {
        private ICayCamTrongRepository repository;
        public CayCamTrongController(ICayCamTrongRepository _repository)
        {
           repository = _repository ;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return HandleResult(await repository.GetAll()); ;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return HandleResult(await repository.GetById(id)); ;
        }
        [HttpPost]
        public async Task<IActionResult> Post(CayCamTrong qlcx)
        {
            return HandleResult(await repository.Add(qlcx));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, CayCamTrong qlcx)
        {
            qlcx.ID = id;
            return HandleResult(await repository.Update(qlcx));
        }
        [HttpDelete]
        public async Task<string> Delete(Guid id)
        {
            return  await repository.Delete(id);
        }
        [HttpGet("search")]
        public async Task<IActionResult> Search(string search)
        {
            return HandleResult(await repository.Search(search));
            
        }
    }
}

