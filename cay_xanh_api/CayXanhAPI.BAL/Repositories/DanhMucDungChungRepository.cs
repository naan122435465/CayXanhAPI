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

namespace CayXanhAPI.BAL.Repositories { 
    public class DanhMucDungChungRepository : ConnectDatabase, IDanhMucDungChungRepository
{
    public async Task<Result<DanhMucDungChung>> AddDanhMucDungChung(DanhMucDungChung dmdc)
    {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@KichHoat", dmdc.KichHoat);
                parameters.Add("@MoTa", dmdc.MoTa);
                parameters.Add("@TenDanhMuc", dmdc.TenDanhMuc);
                DanhMucDungChung result = sqlConn.QueryFirstOrDefault<DanhMucDungChung>("sp_DanhMucDungChung_ThemMoi", parameters, commandType: CommandType.StoredProcedure);
                return Result<DanhMucDungChung>.Success(result);
            }
            catch (Exception ex)
            {
                return Result<DanhMucDungChung>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }
    public async Task<string> DeleteDanhMucDungChung(int id)
    {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                sqlConn.Execute("sp_DanhMucDungChung_Xoa", parameters, commandType: CommandType.StoredProcedure);
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

    public async Task<Result<IEnumerable<DanhMucDungChung>>> GetAllDanhMucDungChung()
    {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                IEnumerable<DanhMucDungChung> result = sqlConn.Query<DanhMucDungChung>("sp_DanhMucDungChung_All", commandType: CommandType.StoredProcedure);
                return Result<IEnumerable<DanhMucDungChung>>.Success(result);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable< DanhMucDungChung >>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }

    public async Task<Result<DanhMucDungChung>> GetDanhMucDungChung(int id)
    {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                DanhMucDungChung result = sqlConn.Query<DanhMucDungChung>("sp_DanhMucDungChung_GetById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return Result<DanhMucDungChung>.Success(result);
            }
            catch (Exception ex)
            {
                return Result<DanhMucDungChung>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }

    public async Task<Result<IEnumerable<DanhMucDungChung>>> SearchDanhMucDungChung(string search)
    {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@search", search);
                IEnumerable<DanhMucDungChung> result =  sqlConn.Query<DanhMucDungChung>("sp_DanhMucDungChung_TimKiem", parameters, commandType: CommandType.StoredProcedure);
                return Result<IEnumerable<DanhMucDungChung>>.Success(result);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<DanhMucDungChung>>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }

    public async Task<Result<DanhMucDungChung>> UpdateDanhMucDungChung(DanhMucDungChung dmdc)
    {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", dmdc.ID);
                parameters.Add("@KichHoat", dmdc.KichHoat);
                parameters.Add("@MoTa", dmdc.MoTa);
                parameters.Add("@TenDanhMuc", dmdc.TenDanhMuc);
                DanhMucDungChung result =  sqlConn.QueryFirstOrDefault<DanhMucDungChung>("sp_DanhMucDungChung_ChinhSua", parameters, commandType: CommandType.StoredProcedure);
                return Result<DanhMucDungChung>.Success(result);
            }
            catch (Exception ex)
            {
                return Result<DanhMucDungChung>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }
}
}
