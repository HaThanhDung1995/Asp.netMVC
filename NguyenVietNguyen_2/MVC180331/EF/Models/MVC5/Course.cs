using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF1.Models.MVC5
{
    [Table("KhoaHoc")]
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("MaKH")]
        public int Id { get; set; }
        
        [StringLength(50)]
        [Required]
        [Column("TenKH")]
        public string Name { get; set; }
        
        [Column("HocPhi")]
        public double? Schoolfee { get; set; }
    }
}