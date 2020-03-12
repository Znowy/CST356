using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using FakeItEasy;
using FluentAssertions;

public class StudentServiceTests
{
    private StudentService _studentService; // System Under Test (SUT)
    private IStudentRepository _studentRepository; // Mock
    private const string specialString = "@oit.edu";

    [SetUp]
    public void Setup()
    {
        _studentRepository = A.Fake<IStudentRepository>();

        _studentService = new StudentService(_studentRepository);
    }

    [Test]
    public void ShouldNotReturnSpecialStudents()
    {
        // Arrange (Given)
        A.CallTo(() => _studentRepository.GetAllStudents()).Returns(
            new List<Student> {
                new Student {
                    Email = "john.smith@gmail.com"
                },
                new Student {
                    Email = "jane.doe@gmail.com"
                }
            }
        );

        // Act (When)
        var studentViewModels = _studentService.GetAllStudents();

        // Assert (NUnit Assertions) (Then)
        Assert.That(studentViewModels.Any(sdto => sdto.Special), Is.EqualTo(false));

        // Assert (FluentAssertions) (Then)
        studentViewModels.Any(sdto => sdto.Special).Should().BeFalse();
    }

    [Test]
    public void ShouldReturnSpecialStudents()
    {
        // Arrange
        var expectedStudentName = "john.smith" + specialString;

        A.CallTo(() => _studentRepository.GetAllStudents()).Returns(
            new List<Student> {
                new Student {
                    Email = expectedStudentName
                },
                new Student {
                    Email = "jane.doe@gmail.com"
                }
            }
        );

        // Act
        var studentViewModels = _studentService.GetAllStudents();

        // Assert (FluentAssertions)
        studentViewModels.Count(sdto => sdto.Special).Should().Be(1);
        studentViewModels.Single(sdto => sdto.Special).Email.Should().Be(expectedStudentName);
    }
}