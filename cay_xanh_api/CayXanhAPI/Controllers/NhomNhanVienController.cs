using CayXanhAPI.BAL.Interfaces;
using CayXanhAPI.BAL.Repositories;
using CayXanhAPI.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CayXanhAPI.Controllers
{
    public class NhomNhanVienController : BaseApiController
    {
        private readonly INhomNhanVienRepository repository;
        public NhomNhanVienController(INhomNhanVienRepository _repository)
        {
            //repository = new NhomNhanVienRepository();
            repository = _repository;
        }
    
        [HttpGet]
        [Route("/Api/NhomNhanVien")]
        // GET: api/<NhomNhanVienController>
        [HttpGet]
        public async Task<IEnumerable<QLCX_NhomNhanVien>> Gets()
        {
           var data = await repository.GetAllNhomNhanVien();
            return data;
        }

        //// GET api/<NhomNhanVienController>/5
        //[HttpGet("{id}")]
        //[Route("/Api/NhomNhanVien/{id}")]
        //public async Task<QLCX_NhomNhanVien> Get(int ID)
        //{
        //    var data = await repository.Get(ID);
        //    return data;
        //}
        // GET api/<NhomNhanVienController>/5
        [HttpGet("{id}")]
        public async Task< QLCX_NhomNhanVien> Get(int id)
        {
            var data = await repository.Get(id);
               return  data;
        }


       // POST api/<NhomNhanVienController>
        [HttpPost]
        [Route("/Api/NhomNhanVien")]
        public async Task<QLCX_NhomNhanVien> Post([FromBody] QLCX_NhomNhanVien nhom)
        {
            await repository.Insert(nhom);
            var lst = await repository.GetAllNhomNhanVien();
            var re = lst.OrderByDescending(i => i.ID).FirstOrDefault();
            return re;
        }
        [HttpPut]
        public async Task<QLCX_NhomNhanVien> Edit([FromBody] QLCX_NhomNhanVien nhom)
        {
            return await repository.Edit(nhom);
            //return await repository.Get(nhom.ID);
        }
        // DELETE api/<NhomNhanVienController>/5
        [HttpDelete("{id}")]
        //[Route("/Api/NhomNhanVien/{id}")]
        public async Task<string> Delete(int id)
        {
           return await repository.Delete(id);
            
        }

        [HttpGet]
        [Route("gettiep/{id}/{name}")]
        public string dkmdkm(string id, string name)
        {
            return $"{id}: {name}";
        }

        [HttpGet]
        [Route("getchovui")]
        public async Task<IActionResult> getget()
        {
            string EmployeeID = "";
            var emp = VerifyUserFromToken(Request);
            if (emp != null)
                EmployeeID = emp;
            else
                return Unauthorized();

            var lstResult = await repository.GetAllNhanVien();
            return Ok(new JsonResult(lstResult));
        }

        [HttpGet]
        [Route("getchovuitiep")]
        public async Task<IActionResult> getchovui()
        {
            return HandleResult(await repository.GetNhomNhanVien());
        }
    }
}
