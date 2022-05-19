using System;
using System.Collections.Generic;
using System.Text;

namespace CayXanhAPI.Domain
{
    public class DanhMucDungChungChiTiet
    {
        public int ID { get; set; }
        public int DanhMucCha { get; set; }
        public int GiaTri { get; set; }
        public string HienThi { get; set; }
        public char KichHoat { get; set; }
    }
}
