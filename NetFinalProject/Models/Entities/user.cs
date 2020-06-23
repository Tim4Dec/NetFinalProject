namespace NetFinalProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("net.user")]
    public partial class User
    {
        public int id { get; set; }

        public int sex { get; set; }

        [StringLength(50)]
        public string nickname { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        [StringLength(50)]
        public string pwd { get; set; }

        [StringLength(250)]
        public string avatar { get; set; }

        public DateTime? birthday { get; set; }

        [StringLength(20)]
        public string email { get; set; }

        [StringLength(20)]
        public string phone { get; set; }
    }
}
