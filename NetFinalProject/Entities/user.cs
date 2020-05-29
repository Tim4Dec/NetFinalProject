namespace NetFinalProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("net.user")]
    public partial class user
    {
        public int id { get; set; }

        [StringLength(50)]
        public string nickname { get; set; }

        [StringLength(50)]
        public string pwd { get; set; }

        [StringLength(250)]
        public string avatar { get; set; }
    }
}
