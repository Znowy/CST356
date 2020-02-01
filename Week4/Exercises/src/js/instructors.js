var instructors = '{"instructors": [{"first": "Phong", "middle": "A", "last": "Nguyen"}, {"first": "Sherry", "middle": "B", "last": "Yang"}, {"first": "Gerald", "middle": "C", "last": "Aden"}, {"first": "Heath", "middle": "D", "last": "Higgins"}, {"first": "Lucas", "middle": "E", "last": "Cordova"}]}';

function getInstructorParse()
{
    return JSON.parse(instructors);
}

function getInstructors()
{
    var data = getInstructorParse();
    console.log(data.instructors);
    displayInstructors(data.instructors);
}

function displayInstructors(instructors)
{
    var tableData = "";
    for (i=0; i < instructors.length; i++)
    {
        tableData += "<tr><td>" + instructors[i].first + "</td><td>" + instructors[i].middle + "</td><td>" + instructors[i].last + "</td>";
        document.getElementById("instructorList").innerHTML = tableData;
    }
}