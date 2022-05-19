using CayXanhAPI.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CayXanhAPI.BAL.Interfaces
{
    public interface INhomNhanVienRepository
    {
        Task<IEnumerable<QLCX_NhomNhanVien>> GetAllNhomNhanVien();
        Task<QLCX_NhomNhanVien> Get(int ID);
        Task<string> Delete(int ID);
        Task<QLCX_NhomNhanVien> Insert(QLCX_NhomNhanVien nhom);
        Task<QLCX_NhomNhanVien> Edit(QLCX_NhomNhanVien nhom);
        Task<IEnumerable<NhanVienBasic>> GetAllNhanVien();

        Task<Result<IEnumerable<QLCX_NhomNhanVien>>> GetNhomNhanVien();
    }
}
