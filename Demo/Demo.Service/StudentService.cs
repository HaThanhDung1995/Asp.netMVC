using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Demo.Entity;
using Demo.Interface;
using Demo.Model;

namespace Demo.Service
{
    public class StudentService : BaseService, IStudentService
    {
        //contructor class entity
        private readonly DbSet<student> _dbStudents;

        public StudentService(DemoContext dbContext) : base(dbContext)
        {
            _dbStudents = Db.Set<student>();
        }


        //Method Create khai báo trong interface
        public List<StudentModel> ListStudent()
        {
            //ProjectTo<StudentModel>() mapping entity vs Model
            var liststudent = _dbStudents.AsNoTracking().ProjectTo<StudentModel>().ToList(); 
            

            return liststudent;
        }

        public void CreateStudent(StudentModel studentModel)
        {
            //mapping entity student vs StudentModel để add giữ liệu vào db
            var student = Mapper.Map<student>(studentModel);

            //Add giữ liệu vào db
            _dbStudents.Add(student);


            //Lưu giữ liệu

            Db.SaveChanges();
        }

        public StudentModel GetStudent(int id)
        {
            //tìm student theo id, để binding dữ liệu sang view
            var student = _dbStudents.FirstOrDefault(a => a.id == id);

            //nếu id khác null thì maping student vs studentmodel, ngược lại return về null
            return student != null ? Mapper.Map<StudentModel>(student) : null;
        }

        public void UpdateStudent(StudentModel studentModel)
        {
            //tìm student để update
            var student = _dbStudents.Find(studentModel.id);

            //student khác null 
            if (student != null)
            {
                student.name = studentModel.name;
                Db.SaveChanges();
            }
        }

        public void DeleteStudent(int studentId)
        {
            var student = _dbStudents.Find(studentId);
            if (student != null)
            {
                _dbStudents.Remove(student);
                Db.SaveChanges();
            }
        }
    }
}
