
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.WebApplication.Models
{
    //đây là viewmodel dùng để lấy dữ liệu ng dùng nhập vào đưa vào method post trong controller
    //ViewModel cũng giống như Model khi tạo thì để ý những tên biến của nó sẽ giống như db
    public class StudentViewModel
    {
        public int id { get; set; }

        public string name { get; set; }
    }
}