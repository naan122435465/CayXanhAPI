using CayXanhAPI.BAL.Interfaces;
using CayXanhAPI.Domain;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CayXanhAPI.BAL.Repositories
{
    public class NhomNhanVienRepository : ConnectDatabase, INhomNhanVienRepository

    {
        public async Task<QLCX_NhomNhanVien> Insert(QLCX_NhomNhanVien nhom)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenNhom", nhom.TenNhom);
                parameters.Add("@MoTa", nhom.MoTa);
                QLCX_NhomNhanVien data = sqlConn.QueryFirstOrDefault<QLCX_NhomNhanVien>("sp_InsertNhomNhanVien", parameters, commandType: CommandType.StoredProcedure);

                //QLCX_NhomNhanVien data = SqlMapper.QueryFirstOrDefault<QLCX_NhomNhanVien>(sqlConn, "sp_InsertNhomNhanVien", parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }

        public async Task<string>  Delete(int ID)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", ID);
                QLCX_NhomNhanVien nhom = SqlMapper.QueryFirstOrDefault<QLCX_NhomNhanVien>(sqlConn, "sp_DeleteNhomNhanVien", parameters, commandType: CommandType.StoredProcedure);
                return "Delete Succssec !";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }

        public async Task<QLCX_NhomNhanVien> Edit(QLCX_NhomNhanVien nhom)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", nhom.ID);
                parameters.Add("@TenNhom", nhom.TenNhom);
                parameters.Add("@MoTa", nhom.MoTa);

                QLCX_NhomNhanVien data = await SqlMapper.QueryFirstAsync<QLCX_NhomNhanVien>(sqlConn, "sp_EditNhomNhanVien", parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }

        public async Task<QLCX_NhomNhanVien> Get(int ID)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", ID);
                QLCX_NhomNhanVien nhom = SqlMapper.QueryFirstOrDefault<QLCX_NhomNhanVien>(sqlConn, "sp_GetNhomNhanVienByID", parameters, commandType: CommandType.StoredProcedure);
                return nhom;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }

        public async Task<IEnumerable<QLCX_NhomNhanVien>> GetAllNhomNhanVien()
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                IEnumerable<QLCX_NhomNhanVien> nhoms = await SqlMapper.QueryAsync<QLCX_NhomNhanVien>(sqlConn, "sp_GetAllNhomNhanVien", commandType: CommandType.StoredProcedure);
                return nhoms;
                // return await SqlMapper.QueryAsync<QLCX_NhomNhanVien>("sp_RoomGet", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }

        public async Task<IEnumerable<NhanVienBasic>> GetAllNhanVien()
        {

            SqlConnection sqlConn = null;
            try
            {
                string sql = @"sp_GetAllNhanVienTest";
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                IEnumerable<NhanVienBasic> nhoms = await SqlMapper.QueryAsync<NhanVienBasic>(sqlConn, sql, commandType: CommandType.StoredProcedure);
                return nhoms;
                // return await SqlMapper.QueryAsync<QLCX_NhomNhanVien>("sp_RoomGet", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }

        public async Task<Result<IEnumerable<QLCX_NhomNhanVien>>> GetNhomNhanVien()
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                IEnumerable<QLCX_NhomNhanVien> nhoms = await SqlMapper.QueryAsync<QLCX_NhomNhanVien>(sqlConn, "sp_GetAllNhomNhanVien", commandType: CommandType.StoredProcedure);
                return Result<IEnumerable<QLCX_NhomNhanVien>>.Success(nhoms);
                // return await SqlMapper.QueryAsync<QLCX_NhomNhanVien>("sp_RoomGet", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<QLCX_NhomNhanVien>>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }
    }
}
