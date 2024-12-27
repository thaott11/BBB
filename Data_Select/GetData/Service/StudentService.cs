using GetData.Models;

namespace GetData.Service
{
    public interface IStudentService
    {
        public Task<List<Student>> Getdata();
    }
    public class StudentService : IStudentService
    {
        public Task<List<Student>> Getdata()
        {
            string Parameter = "Student";

            string para = new { }
        }
    }
}
