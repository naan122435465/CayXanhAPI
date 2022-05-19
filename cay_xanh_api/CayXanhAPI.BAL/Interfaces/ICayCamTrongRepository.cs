using CayXanhAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayXanhAPI.BAL.Interfaces
{
   public interface ICayCamTrongRepository
    {
        Task<Result<IEnumerable<CayCamTrong>>> GetAll();
        Task<Result<CayCamTrong>> GetById(Guid id);
        Task<String> Delete(Guid id);
        Task<Result<CayCamTrong>> Add(CayCamTrong qlcx);
        Task<Result<CayCamTrong>> Update(CayCamTrong qlcx);
        Task<Result<IEnumerable<CayCamTrong>>> Search(string search);
    }
}
