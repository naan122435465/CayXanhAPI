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
    public class DanhMucDungChungChiTietRepository : ConnectDatabase, IDanhMucDungChungChiTietRepository
    {
        public async Task<Result<DanhMucDungChungChiTiet>>AddDanhMucChiTiet(DanhMucDungChungChiTiet dmct)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DanhMucCha", dmct.DanhMucCha);
                parameters.Add("@GiaTri", dmct.GiaTri);
                parameters.Add("@HienThi", dmct.HienThi);
                parameters.Add("@KichHoat", dmct.KichHoat);
                DanhMucDungChungChiTiet result =  sqlConn.QueryFirstOrDefault<DanhMucDungChungChiTiet>("sp_DanhMucDungChungChiTiet_ThemMoi", parameters, commandType: CommandType.StoredProcedure);
                return Result<DanhMucDungChungChiTiet>.Success(result);

            }
            catch (Exception ex)
            {
                return Result<DanhMucDungChungChiTiet>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }
        public async Task<string> DeleteDanhMucChiTiet(int id)
        {
             SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                sqlConn.Execute("sp_DanhMucDungChungChiTiet_Xoa", parameters, commandType: CommandType.StoredProcedure);
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
        public async Task<Result<IEnumerable<DanhMucDungChungChiTiet>>> GetAllDanhMucChiTiet()
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                IEnumerable<DanhMucDungChungChiTiet> result =  sqlConn.Query<DanhMucDungChungChiTiet>("sp_DanhMucDungChungChiTiet_All", commandType: CommandType.StoredProcedure);
                return Result<IEnumerable<DanhMucDungChungChiTiet>>.Success(result);

            }
            catch (Exception ex)
            {
                return Result<IEnumerable<DanhMucDungChungChiTiet>>.Failure($"Process error: {ex.Message}");
            }
        
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }
        public async Task<Result<DanhMucDungChungChiTiet>> GetDanhMucChiTiet(int id)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                DanhMucDungChungChiTiet result =  sqlConn.Query<DanhMucDungChungChiTiet>("sp_DanhMucDungChungChiTiet_GetById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return Result<DanhMucDungChungChiTiet>.Success(result);
            }
            catch (Exception ex)
            {
                return Result<DanhMucDungChungChiTiet>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }
        public async Task<Result<IEnumerable<DanhMucDungChungChiTiet>>> GetDanhMucChiTiet_TheoMucCha(int IDCha) 
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DanhMucCha", IDCha);
                IEnumerable< DanhMucDungChungChiTiet> result =  sqlConn.Query<DanhMucDungChungChiTiet>("sp_DanhMucDungChungChiTiet_TheoMucCha", parameters, commandType: CommandType.StoredProcedure);
                return Result<IEnumerable<DanhMucDungChungChiTiet>>.Success(result);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<DanhMucDungChungChiTiet>>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }
        public async  Task<Result<IEnumerable<DanhMucDungChungChiTiet>>> SearchDanhMucChiTiet(string search)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@search", search);
                IEnumerable<DanhMucDungChungChiTiet> result =  sqlConn.Query<DanhMucDungChungChiTiet>("sp_DanhMucDungChungChiTiet_TimKiem", parameters, commandType: CommandType.StoredProcedure);
                return Result<IEnumerable<DanhMucDungChungChiTiet>>.Success(result);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<DanhMucDungChungChiTiet>>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }

        public async Task<Result<DanhMucDungChungChiTiet>> UpdateDanhMucChiTiet(DanhMucDungChungChiTiet dmct)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", dmct.ID);
                parameters.Add("@DanhMucCha", dmct.DanhMucCha);
                parameters.Add("@GiaTri", dmct.GiaTri);
                parameters.Add("@HienThi", dmct.HienThi);
                parameters.Add("@KichHoat", dmct.KichHoat);
                DanhMucDungChungChiTiet result =  sqlConn.QueryFirstOrDefault<DanhMucDungChungChiTiet>("sp_DanhMucDungChungChiTiet_ChinhSua", parameters, commandType: CommandType.StoredProcedure);
                return Result<DanhMucDungChungChiTiet>.Success(result);
            }
            catch (Exception ex)
            {
                return Result<DanhMucDungChungChiTiet>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }
    }
}
