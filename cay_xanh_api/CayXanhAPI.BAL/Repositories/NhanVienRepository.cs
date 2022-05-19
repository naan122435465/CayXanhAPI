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
    public class NhanVienRepository : ConnectDatabase, INhanVienRepository
    {
        public async Task<Result<IEnumerable<QLCX_NhanVien>>> GetDanhSachNhanVien()
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                IEnumerable<QLCX_NhanVien> nhoms = await SqlMapper.QueryAsync<QLCX_NhanVien>(sqlConn, "SP_GETNHANVIEN", commandType: CommandType.StoredProcedure);
                return Result<IEnumerable<QLCX_NhanVien>>.Success(nhoms);
                // return await SqlMapper.QueryAsync<QLCX_NhomNhanVien>("sp_RoomGet", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<QLCX_NhanVien>>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }

        public async Task<Result<IEnumerable<QLCX_NhanVien>>> GetDanhSachNhanVienTheoNhom(int nhomId)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PNHOMID", nhomId);
                IEnumerable<QLCX_NhanVien> nhoms = await SqlMapper.QueryAsync<QLCX_NhanVien>(sqlConn, "SP_GETNHANVIEN_THEONHOM", parameters, commandType: CommandType.StoredProcedure);
                return Result<IEnumerable<QLCX_NhanVien>>.Success(nhoms);
                // return await SqlMapper.QueryAsync<QLCX_NhomNhanVien>("sp_RoomGet", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<QLCX_NhanVien>>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }

        public async Task<Result<QLCX_NhanVien>> GetNhanVien(int ID)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PID", ID);
                QLCX_NhanVien nhom = SqlMapper.QueryFirstOrDefault<QLCX_NhanVien>(sqlConn, "SP_GETNHANVIEN_DETAIL", parameters, commandType: CommandType.StoredProcedure);
                return Result<QLCX_NhanVien>.Success(nhom);
            }
            catch (Exception ex)
            {
                return Result<QLCX_NhanVien>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }

        public async Task<Result<QLCX_NhanVien>> InsertNhanVien(QLCX_NhanVien entity)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                string pw = Cryptographer.getHash(entity.MatKhau + entity.TenDangNhap);
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PMANHOM", null);
                parameters.Add("@PHOTEN", entity.HoTen);
                parameters.Add("@PDIACHI", entity.DiaChi);
                parameters.Add("@PDIENTHOAI", entity.DienThoai);
                parameters.Add("@PHOPTHU", entity.HopThu);
                parameters.Add("@PTENDANGNHAP", entity.TenDangNhap);
                parameters.Add("@PMATKHAU", pw);
                parameters.Add("@PQUYEN", entity.Quyen);
                parameters.Add("@PTRANGTHAI", entity.TrangThai);
                QLCX_NhanVien nhom = SqlMapper.QueryFirstOrDefault<QLCX_NhanVien>(sqlConn, "SP_INSERTNHANVIEN", parameters, commandType: CommandType.StoredProcedure);
                return Result<QLCX_NhanVien>.Success(nhom);
            }
            catch (Exception ex)
            {
                return Result<QLCX_NhanVien>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }

        public async Task<Result<int>> ThemNhanVienVaoNhom(int ID, string listNv)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PNHOMID", ID);
                parameters.Add("@PNVID", listNv);
                int nhom = await SqlMapper.ExecuteAsync(sqlConn, "SP_THEM_NHANVIEN_VAO_NHOM", parameters, commandType: CommandType.StoredProcedure);
                bool updateResult = nhom > 0;
                if (!updateResult)
                    return Result<int>.Failure("Thêm nhân viên vào nhóm không thành công");
                return Result<int>.Success(nhom);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }

        public async Task<Result<QLCX_NhanVien>> UpdateNhanVien(QLCX_NhanVien entity)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PID", entity.ID);
                parameters.Add("@PMANHOM", entity.MaNhom);
                parameters.Add("@PHOTEN", entity.HoTen);
                parameters.Add("@PDIACHI", entity.DiaChi);
                parameters.Add("@PDIENTHOAI", entity.DienThoai);
                parameters.Add("@PHOPTHU", entity.HopThu);
                parameters.Add("@PQUYEN", entity.Quyen);
                parameters.Add("@PTRANGTHAI", entity.TrangThai);
                QLCX_NhanVien nhom = SqlMapper.QueryFirstOrDefault<QLCX_NhanVien>(sqlConn, "SP_UPDATENHANVIEN", parameters, commandType: CommandType.StoredProcedure);
                return Result<QLCX_NhanVien>.Success(nhom);
            }
            catch (Exception ex)
            {
                return Result<QLCX_NhanVien>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }

        public async Task<Result<int>> UpdateNhom(int nvId, int nhomId = 0)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = ConnectDataBase();
                await sqlConn.OpenAsync();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PNVID", nvId);
                parameters.Add("@PNHOMID", nhomId);
                int nhom = await SqlMapper.ExecuteAsync(sqlConn, "SP_NHANVIEN_UPDATE_NHOM", parameters, commandType: CommandType.StoredProcedure);
                bool updateResult = nhom > 0;
                if (!updateResult) 
                    return Result<int>.Failure("Cập nhật nhóm cho nhân viên không thành công");
                return Result<int>.Success(nhom);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Process error: {ex.Message}");
            }
            finally
            {
                if (sqlConn != null)
                    sqlConn.Close();
            }
        }
    }
}
