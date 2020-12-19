using Lab8.Models;
using Lab8.Services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            // init data
            //InitData();

            var studentService = new StudentService();
            var groupService = new GroupService();
            var employeeService = new EmployeeService();
            var courseService = new CourseService();

            // print collection (each document)
            Console.WriteLine("Print all documents");
            studentService.Get().ForEach(Print);
            groupService.Get().ForEach(Print);
            employeeService.Get().ForEach(Print);
            courseService.Get().ForEach(Print);

            // performs key-value query with at least 2 conditions
            Console.WriteLine("Filter");
            var filter = Builders<Employee>.Filter.Or(
                Builders<Employee>.Filter.Eq(s => s.Name, "Svitlana"),
                Builders<Employee>.Filter.Eq(s => s.Name, "Volodymyr"),
                Builders<Employee>.Filter.And(
                    Builders<Employee>.Filter.Eq(s => s.Position, "Lecturer"),
                    Builders<Employee>.Filter.Gt(s => s.Salary, 300)
                    ));
            var filterResult = employeeService.items.Find(filter).ToList();
            filterResult.ForEach(Print);

            // performs aggregation with at least 4 stages (lookup and group stages are obligatory)
            Console.WriteLine("Aggregation");
            var resultAgg = studentService.items.Aggregate()
                .Match(student => student.JoinDate > DateTime.Now.AddDays(-100))
                .Limit(3)
                .Lookup("Groups", "GroupId", "_id", "Group")
                //.Group(stundent => stundent.GroupId, value => new { group = value.Key, TotalStudents = value.Count() })
                //.Sort(new BsonDocument { { "TotalStudents", 1 } })
                .ToList();
            //resultAgg.ForEach(Print);
            resultAgg.Select(v => BsonSerializer.Deserialize<object>(v)).ToList().ForEach(Print);

            Console.ReadKey();
        }

        public static void Print(object obj)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            Console.WriteLine(JsonSerializer.Serialize(obj, options));
        }

        private static void InitData()
        {
            var studentService = new StudentService();
            studentService.Create(new Student { Id = "student_1", Name = "Kevin", Phone = "12345678", GroupId = "Group_1", JoinDate = DateTime.Now, MarkList = new List<MarkModel> { new MarkModel { CourseId = "Course_1", Mark = 95 }, new MarkModel { CourseId = "Course_2", Mark = 80 } } });
            studentService.Create(new Student { Id = "student_2", Name = "Mark", Phone = "12345678", GroupId = "Group_1", JoinDate = DateTime.Now, MarkList = new List<MarkModel> { new MarkModel { CourseId = "Course_2", Mark = 60 }, new MarkModel { CourseId = "Course_4", Mark = 60 } } });
            studentService.Create(new Student { Id = "student_3", Name = "Steve", Phone = "12345678", GroupId = "Group_2", JoinDate = DateTime.Now, MarkList = new List<MarkModel> { new MarkModel { CourseId = "Course_3", Mark = 75 } } });
            studentService.Create(new Student { Id = "student_4", Name = "Alex", Phone = "12345678", GroupId = "Group_2", JoinDate = DateTime.Now, MarkList = new List<MarkModel> { new MarkModel { CourseId = "Course_4", Mark = 90 } } });

            var groupService = new GroupService();
            groupService.Create(new Group { Id = "Group_1", Name = "TI-01mp", Students = new List<string> { "student_1", "student_2" } });
            groupService.Create(new Group { Id = "Group_2", Name = "TI-02mn", Students = new List<string> { "student_3", "student_4" } });

            var employeeService = new EmployeeService();
            employeeService.Create(new Employee { Id = "Employee_1", Name = "Oleg Telenyk", Phone = "31231", Position = "Dean", Salary = 1000m });
            employeeService.Create(new Employee { Id = "Employee_2", Name = "Svitlana", Phone = "31231", Position = "Professor", Salary = 700m });
            employeeService.Create(new Employee { Id = "Employee_3", Name = "Volodymyr", Phone = "31231", Position = "Assistant", Salary = 300m });
            employeeService.Create(new Employee { Id = "Employee_4", Name = "Mykola", Phone = "31231", Position = "Lecturer", Salary = 600m });

            var courseService = new CourseService();
            courseService.Create(new Course { Id = "Course_1", Name = "Biology", Credits = 4.5f, TeacherId = "Employee_1", StartDate = DateTime.Now, EndDate = new DateTime(2020, 12, 31), Groups = new List<string> { "Group_1" } });
            courseService.Create(new Course { Id = "Course_2", Name = "Math", Credits = 3f, TeacherId = "Employee_2", StartDate = DateTime.Now, EndDate = new DateTime(2020, 12, 31), Groups = new List<string> { "Group_1", "Group_2" } });
            courseService.Create(new Course { Id = "Course_3", Name = "Computer Science", Credits = 5f, TeacherId = "Employee_3", StartDate = DateTime.Now, EndDate = new DateTime(2020, 12, 31), Groups = new List<string> { } });
            courseService.Create(new Course { Id = "Course_4", Name = "Logic", Credits = 1f, TeacherId = "Employee_4", StartDate = DateTime.Now, EndDate = new DateTime(2020, 12, 31), Groups = new List<string> { "Group_1", "Group_2" } });

        }
    }
}
