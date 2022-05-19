using CayXanhAPI.BAL.Interfaces;
using CayXanhAPI.Domain;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayXanhAPI.BAL.Repositories
{
    public class CayCamTrongRepository : ConnectDatabase, ICayCamTrongRepository
    {
        public async Task<Result<CayCamTrong>> Add(CayCamTrong qlcx)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenCay", qlcx.TenCay);
                parameters.Add("@TenKhoaHoc", qlcx.TenKhoaHoc);
                parameters.Add("@HoThucVat", qlcx.HoThucVat);
                parameters.Add("@MoTa", qlcx.MoTa);
                parameters.Add("@CamTrong", qlcx.CamTrong);
                CayCamTrong result =  sqlConn.QueryFirstOrDefault<CayCamTrong>("sp_CayCamTrong_ThemMoi", parameters, commandType: CommandType.StoredProcedure);
                return Result<CayCamTrong>.Success(result);
             }
            catch (Exception ex)
            {
                return Result<CayCamTrong>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }
        public async Task<string> Delete(Guid Id)
        {
            SqlConnection sqlConn = null;
            try
             {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                sqlConn.Execute("sp_CayCamtrong_Xoa", parameters, commandType: CommandType.StoredProcedure);
                return "Delete Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
             }
             finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
             }
        }
        public async Task<Result<IEnumerable<CayCamTrong>>> GetAll()
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();

                IEnumerable<CayCamTrong> result = (IEnumerable<CayCamTrong>)sqlConn.Query<IEnumerable<CayCamTrong>>("sp_CayCamTrong_All", commandType: CommandType.StoredProcedure);
                return Result<IEnumerable<CayCamTrong>>.Success(result);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<CayCamTrong>>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }
        public async Task<Result<CayCamTrong>> GetById(Guid Id)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                CayCamTrong result =  sqlConn.Query<CayCamTrong>("sp_CayCamTrong_GetById",parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return Result<CayCamTrong>.Success(result);
            }
            catch (Exception ex)
            {
                return Result<CayCamTrong>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }
        public async Task<Result<CayCamTrong>> Update(CayCamTrong qlcx)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", qlcx.ID);
                parameters.Add("@TenCay", qlcx.TenCay);
                parameters.Add("@TenKhoaHoc", qlcx.TenKhoaHoc);
                parameters.Add("@HoThucVat", qlcx.HoThucVat);
                parameters.Add("@MoTa", qlcx.MoTa);
                parameters.Add("@CamTrong", qlcx.CamTrong);
                CayCamTrong result = sqlConn.QueryFirstOrDefault<CayCamTrong>("sp_CayCamTrong_ChinhSua", parameters, commandType: CommandType.StoredProcedure);
                return Result<CayCamTrong>.Success(result);
            }
            catch (Exception ex)
            {
                return Result<CayCamTrong>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }
        public async Task<Result<IEnumerable<CayCamTrong>>> Search(string search)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@search", search);
                IEnumerable<CayCamTrong> result = (IEnumerable<CayCamTrong>)sqlConn.Query<IEnumerable<CayCamTrong>>("sp_CayCamtrong_TimKiem", parameters, commandType: CommandType.StoredProcedure);
                return Result<IEnumerable<CayCamTrong>>.Success(result);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<CayCamTrong>>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }
    }
}
