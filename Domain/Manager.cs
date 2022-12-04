namespace Domain;

public class Manager : Employee
{
    public List<Employee> Subordinates { get; set; } = new();
}