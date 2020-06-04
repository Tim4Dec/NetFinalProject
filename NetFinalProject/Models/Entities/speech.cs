using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace NetFinalProject.Models
{
    [Table("net.speech")]
    public partial class Speech
    {
        public int id { get; set; }

        public int owner { get; set; }

        [StringLength(250)]
        public string title { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string content { get; set; }

        public DateTime? time { get; set; }
    }
}