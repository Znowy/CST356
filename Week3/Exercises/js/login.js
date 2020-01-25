function validate()
{
    document.getElementById("usernameError").style.visibility = "hidden";
    document.getElementById("passwordError").style.visibility = "hidden";

    if (document.getElementById("usernameId").value == "")
    {
        document.getElementById("usernameError").style.visibility = "visible";
    }

    if (document.getElementById("passwordId").value == "")
    {
        document.getElementById("passwordError").style.visibility = "visible";
    }
}