using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CayXanhAPI.Domain
{
    public class QLCX_NhomNhanVien
    {
        public int ID { get; set; }
        public string TenNhom { get; set; }
        public string MoTa { get; set; }
    }
}
