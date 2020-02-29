using System.Collections.Generic;
using Microsoft.Extensions.Logging;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRespository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRespository = studentRepository;
    }

    public List<StudentViewModel> GetAllStudents()
    {
        var studentViewModels = new List<StudentViewModel>();

        foreach(var student in _studentRespository.GetAllStudents())
        {
            studentViewModels.Add(new StudentViewModel {
                StudentId = student.StudentId,
                Email = student.Email,
                Special = BusinessRules.isSpecial(student)
            });
        }

        return studentViewModels;
    }

    public Student GetStudentById(long studentId)
    {
        return _studentRespository.GetStudentById(studentId);
    }

    public void AddStudent(Student student)
    {
        _studentRespository.AddStudent(student);
    }

    public void UpdateStudent(Student student)
    {
        _studentRespository.UpdateStudent(student);
    }

    public void DeleteStudent(long studentId)
    {
        _studentRespository.DeleteStudent(studentId);
    }
}