using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc4WorkGps.Models
{
    [Table("Employees")]
    public class UserModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("用户名")]
        [Required]
        public string Name { get; set; }

        [DisplayName("手机号")]
        [Required]
        public string MobilePhone { get; set; }

        [DisplayName("IMSI")]
        [Required]
        public string IMSI { get; set; }

        [DisplayName("IMEI")]
        public string IMEI { get; set; }

        [DisplayName("备注")]
        public string Remark { get; set; }
    }
}