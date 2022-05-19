using CayXanhAPI.BAL.Interfaces;
using CayXanhAPI.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CayXanhAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucDungChungController : BaseApiController
    {
        private IDanhMucDungChungRepository repository;
        public DanhMucDungChungController(IDanhMucDungChungRepository _repository)
        {
            repository = _repository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return HandleResult(await repository.GetAllDanhMucDungChung());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return HandleResult(await repository.GetDanhMucDungChung(id)); 
        }
        [HttpPost]
        public async Task<IActionResult> Post(DanhMucDungChung dmdc)
        {
            return HandleResult(await repository.AddDanhMucDungChung(dmdc));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, DanhMucDungChung dmdc)
        {
            dmdc.ID = id;
            return HandleResult(await repository.UpdateDanhMucDungChung(dmdc));
        }
        [HttpDelete]
        public async Task<string> Delete(int id)
        {
            return await repository.DeleteDanhMucDungChung(id);
        }
        [HttpGet("search")]
        public async Task<IActionResult> Search(string search)
        {
            return HandleResult(await repository.SearchDanhMucDungChung(search));

        }

    }
}
