using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CayXanhAPI.Domain;

namespace CayXanhAPI.BAL.Interfaces
{
    public interface INhanVienRepository
    {
        Task<Result<IEnumerable<QLCX_NhanVien>>> GetDanhSachNhanVien();
        Task<Result<IEnumerable<QLCX_NhanVien>>> GetDanhSachNhanVienTheoNhom(int nhomId);
        Task<Result<QLCX_NhanVien>> GetNhanVien(int ID);
        Task<Result<QLCX_NhanVien>> InsertNhanVien(QLCX_NhanVien entity);
        Task<Result<QLCX_NhanVien>> UpdateNhanVien(QLCX_NhanVien entity);

        Task<Result<int>> ThemNhanVienVaoNhom(int ID, string listNv);
        Task<Result<int>> UpdateNhom(int nvId, int nhomId = 0);
    }
}
