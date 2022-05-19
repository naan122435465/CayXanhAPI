using CayXanhAPI.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CayXanhAPI.BAL.Interfaces
{
   public interface IDanhMucDungChungChiTietRepository
    {
        Task<Result<IEnumerable<DanhMucDungChungChiTiet>>> GetAllDanhMucChiTiet();
        Task<Result<DanhMucDungChungChiTiet>> GetDanhMucChiTiet(int id);
        Task<Result<IEnumerable<DanhMucDungChungChiTiet>>> GetDanhMucChiTiet_TheoMucCha(int IDCha);
        Task<String> DeleteDanhMucChiTiet(int id);
        Task<Result<DanhMucDungChungChiTiet>> AddDanhMucChiTiet(DanhMucDungChungChiTiet dmct);
        Task<Result<DanhMucDungChungChiTiet>> UpdateDanhMucChiTiet(DanhMucDungChungChiTiet dmct);
        Task<Result<IEnumerable<DanhMucDungChungChiTiet>>> SearchDanhMucChiTiet(string search);
       
    }
}
