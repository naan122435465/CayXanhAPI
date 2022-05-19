using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CayXanhAPI.Domain
{
    public class CayCamTrong
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string TenCay { get; set; }
        public string TenKhoaHoc { get; set; }
        public string HoThucVat { get; set; }
        public string MoTa { get; set; }

        public Char CamTrong { get; set; }
    }
}
