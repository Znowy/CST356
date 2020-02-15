using System.Collections.Generic;

namespace Database
{
    public static class InMemory
    {
        public static List<Student> Students = new List<Student>
        {
            new Student
            {
                Id = 1,
                studentId = 1234,
                email = "jake.student@oit.edu"
            },
            new Student
            {
                Id = 2,
                studentId = 2345,
                email = "david.student@oit.edu"
            }
        };

        public static List<Instructor> Instructors = new List<Instructor>
        {
            new Instructor
            {
                Id = 1,
                first = "Phong",
                middle = "A",
                last = "Nguyen"
            },
            new Instructor
            {
                Id = 2,
                first = "Sherry",
                middle = "B",
                last = "Yang"
            }
        };
    }
}