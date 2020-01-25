var students = '{"students": [{"studentId": 12345, "email": "jake.student@oit.edu"}, {"studentId": 23456, "email": "david.student@oit.edu"}, {"studentId": 34567, "email": "brad.student@oit.edu"}, {"studentId": 45678, "email": "andrew.student@oit.edu"}, {"studentId": 56789, "email": "nick.student@oit.edu"}]}';

function getParse()
{
    return JSON.parse(students);
}

function getStudents()
{
    var data = getParse();
    displayStudents(data.students);
}

function displayStudents(students)
{
    var tableData = "";
    for (i=0; i < students.length; i++)
    {
        tableData += "<tr><td>" + students[i].studentId + "</td><td>" + students[i].email + "</td>";
        document.getElementById("studentList").innerHTML = tableData;
    }
}