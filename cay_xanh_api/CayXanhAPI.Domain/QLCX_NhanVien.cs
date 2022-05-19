using System;
using System.Collections.Generic;
using System.Text;

namespace CayXanhAPI.Domain
{
    public class QLCX_NhanVien
    {
        public int ID { get; set; }
        public int MaNhom { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string HopThu { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public int Quyen { get; set; }
        public string TrangThai { get; set; }
    }

    public class NhanVienBasic
    {
        public int ID { get; set; }
        public string HoTen { get; set; }
        public string TenDangNhap { get; set; }
        public string TenNhom { get; set; }
    }
}
