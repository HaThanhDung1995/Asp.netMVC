using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Model
{
    public class StudentModel
    {
        public int id { get; set; }

        [DisplayName("Tên học sinh")]
        public string name { get; set; }
    }
}
