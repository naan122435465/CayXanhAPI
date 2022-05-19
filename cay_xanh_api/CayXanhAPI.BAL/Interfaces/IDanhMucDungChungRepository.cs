using CayXanhAPI.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CayXanhAPI.BAL.Interfaces
{
    public interface IDanhMucDungChungRepository
    {
        Task<Result<IEnumerable<DanhMucDungChung>>> GetAllDanhMucDungChung();
        Task<Result<DanhMucDungChung>> GetDanhMucDungChung(int id);
        Task<String> DeleteDanhMucDungChung(int id);
        Task<Result<DanhMucDungChung>> AddDanhMucDungChung(DanhMucDungChung dmdc);
        Task<Result<DanhMucDungChung>> UpdateDanhMucDungChung(DanhMucDungChung dmdc);
        Task<Result<IEnumerable<DanhMucDungChung>>> SearchDanhMucDungChung(string dmdc);
    }
}
