
// Data Transfer Object class, used to bypass navigation properties validation during API calls
public class StudentDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public StudentDTO() { }

    public StudentDTO(Student student)
    {
        Id = student.Id;
        FirstName = student.FirstName;
        LastName = student.LastName;
    }
}