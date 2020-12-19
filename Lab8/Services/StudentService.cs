using Lab8.Models;

namespace Lab8.Services
{
    public class StudentService : MongoServiceBase<Student>
    {
        public StudentService()
            : base("Students")
        {

        }
    }
}
