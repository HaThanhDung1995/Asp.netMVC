namespace Report.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MasterRole
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string MasterId { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleId { get; set; }

        public virtual Role Role { get; set; }

        public virtual Master Master { get; set; }
    }
}
