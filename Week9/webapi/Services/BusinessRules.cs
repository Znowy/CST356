public static class BusinessRules
{
    public static bool isSpecial(Student student) => 
        student.Email.Contains(specialString);

    public static string specialString = "@oit.edu";
}