namespace StudentsServices.Dtos;

public class UpdateStudentDto
{
    public required string firstName { get; set; }
    public required string lastName { get; set; }
    public required string email { get; set; }
    public string? phone { get; set; }
    public int fees { get; set; }
}