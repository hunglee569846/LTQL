using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace websiteBANHANG.Models
{
    [Table("Accounts")]
    public class Account
    {
        [Key]
        [Required(ErrorMessage ="Ten dang nhap khong dung")]
        public string Username { get; set; }

        [Required(ErrorMessage ="sai mat khau")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}