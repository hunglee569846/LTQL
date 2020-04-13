using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace websiteBANHANG.Models
{
    [Table("Article")]
    public partial class Article
    {
        [StringLength(10)]
        public string ArticleID { get; set; }

        [StringLength(50)]
        public string Author { get; set; }
        [AllowHtml]
        [Column(TypeName = "ntext")]
        public string ArticleContent { get; set; }
    }
}