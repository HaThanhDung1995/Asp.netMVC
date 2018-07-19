using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Model;

namespace Demo.Interface
{
    public interface IStudentService
    {
        //Khai báo method lên service
        List<StudentModel> ListStudent(); 


        //Tạo method create(Create, Edit, Delete đều dùng void)
        //Create sẽ mang dữ liệu mà ng dùng nhập vào, cụ thể là StudentModel, tí nữa trong controller mình sẽ truyền dữ liệu ngdung nhập từ Viewmodel sang model cho service xử lý
        void CreateStudent(StudentModel studentModel);

        //Get sudent theo Id
        StudentModel GetStudent(int id);

        //Update student
        void UpdateStudent(StudentModel studentModel);

        void DeleteStudent(int studentId);
    }
}
