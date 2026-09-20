namespace Hotel.Domain.Entities;

public class Client
{
    public int Id { get; set; }

    public string PassportNumber { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public DateTime BirthDate { get; set; }

    public string Citizenship { get; set; } = string.Empty;
}
