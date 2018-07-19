namespace Report.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ActionRole
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleId { get; set; }

        public int WebActionId { get; set; }

        public virtual WebAction WebAction { get; set; }

        public virtual Role Role { get; set; }
    }
}
