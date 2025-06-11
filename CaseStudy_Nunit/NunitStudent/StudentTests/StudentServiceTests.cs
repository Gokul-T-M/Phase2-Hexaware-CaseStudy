using NUnit.Framework;
using Moq;
using StudentDAL.Domain;
using StudentDAL.Repository;
using StudentDAL.BusinessLogic;
using System.Collections.Generic;

namespace StudentTests
{

    public class StudentServiceTests
    {
        private Mock<IStudentRepository> _mockRepo;
        private StudentService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IStudentRepository>();
            _service = new StudentService(_mockRepo.Object);
        }

        [Test]
        public void AddStudent_Should_Call_Repository_Add()
        {
            var student = new Student { RollNo = 1, Name = "John", Email = "john@gmail.com" };

            _service.AddStudent(student);

            _mockRepo.Verify(r => r.Add(student), Times.Once);
        }

        [Test]
        public void GetAllStudents_Should_Return_Students()
        {
            var students = new List<Student>
            {
                new Student { RollNo = 1, Name = "John", Email = "john@gmail.com" }
            };
            _mockRepo.Setup(r => r.GetAll()).Returns(students);

            var result = _service.GetAllStudents();

            Assert.AreEqual(1, result.Count);
        }
    }
}
