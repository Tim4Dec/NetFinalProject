using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NetFinalProject.Models
{
    [Table("net.comment")]
    public partial class Comment
    {
        public int id { get; set; }

        public int owner { get; set; }

        public int speech { get; set; }

        public int floor { get; set; }

        [StringLength(500)]
        public string content { get; set; }

        public DateTime? time { get; set; }


    }
}