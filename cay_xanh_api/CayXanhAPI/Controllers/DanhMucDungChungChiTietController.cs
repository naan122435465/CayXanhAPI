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
    public class DanhMucDungChungChiTietController : BaseApiController
    {
        private readonly IDanhMucDungChungChiTietRepository repository;
        public DanhMucDungChungChiTietController(IDanhMucDungChungChiTietRepository _repository)
        {
            repository = _repository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return HandleResult(await repository.GetAllDanhMucChiTiet());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return HandleResult(await repository.GetDanhMucChiTiet(id));
        }
        [HttpGet("idCha")]
        public async Task<IActionResult> GetTheoIdCha(int idcha)
        {
            return HandleResult(await repository.GetDanhMucChiTiet_TheoMucCha(idcha));
        }
        [HttpPost]
        public async Task<IActionResult> Post(DanhMucDungChungChiTiet dmct)
        {
            return HandleResult(await repository.AddDanhMucChiTiet(dmct));
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, DanhMucDungChungChiTiet dmct)
        {
            dmct.ID = id;
            return HandleResult(await repository.UpdateDanhMucChiTiet(dmct));
        }
        [HttpDelete]
        public async Task<string> Delete(int id)
        {
            return await repository.DeleteDanhMucChiTiet(id);
        }
        [HttpGet("Search")]
        public async Task<IActionResult> Search(string search)
        {
            return HandleResult(await repository.SearchDanhMucChiTiet(search));
        }

    }
}
