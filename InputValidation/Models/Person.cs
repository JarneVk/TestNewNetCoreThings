namespace InputValidation.Models;

public class Person
{
    public string Name { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }

    public Adress Adress { get; set; } = new();
}