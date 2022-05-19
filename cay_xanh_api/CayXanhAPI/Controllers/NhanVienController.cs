using Microsoft.AspNetCore.Mvc;
using CayXanhAPI.BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CayXanhAPI.Domain;
using CayXanhAPI.RequestEntities;

namespace CayXanhAPI.Controllers
{
    public class NhanVienController : BaseApiController
    {
        private readonly INhanVienRepository _repository;

        public NhanVienController(INhanVienRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("getdanhsachnhanvien")]
        public async Task<IActionResult> getdanhsach()
        {
            return HandleResult(await _repository.GetDanhSachNhanVien());
        }
        [HttpGet]
        [Route("getdsnhanvientheonhom")]
        public async Task<IActionResult> getdanhsachtheonhom(int nhomId)
        {
            return HandleResult(await _repository.GetDanhSachNhanVienTheoNhom(nhomId));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetThongTinNhanVien(int id)
        {
            return HandleResult(await _repository.GetNhanVien(id));
        }

        [HttpPost]
        [Route("insertnhanvien")]
        public async Task<IActionResult> Insert([FromBody] QLCX_NhanVien nhanvien)
        {
            return HandleResult(await _repository.InsertNhanVien(nhanvien));
        }

        [HttpPost]
        [Route("themnhanvienvaonhom")]
        public async Task<IActionResult> ThemNhanVienVaoNhom([FromBody] ThemNhanVienVaoNhomRequest _request)
        {
            return HandleResult(await _repository.ThemNhanVienVaoNhom(_request.NhomId, _request.nvIds));
        }

        [HttpPut]
        [Route("updatenhanvien")]
        public async Task<IActionResult> Update([FromBody] QLCX_NhanVien nhanvien)
        {
            return HandleResult(await _repository.UpdateNhanVien(nhanvien));
        }

        [HttpPut]
        [Route("updatenhom")]
        public async Task<IActionResult> UpdateNhom([FromBody] QLCX_NhanVien nhanvien)
        {
            return HandleResult(await _repository.UpdateNhom(nhanvien.ID, nhanvien.MaNhom));
        }
    }
}
