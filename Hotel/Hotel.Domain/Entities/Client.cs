namespace Hotel.Domain.Entities;

/// <summary>
/// Клиент гостиницы
/// </summary>
public class Client
{
    /// <summary>
    /// Индентификатор клиента
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Номер паспорта клиента
    /// </summary>
    public string PassportNumber { get; set; } = string.Empty;

    /// <summary>
    /// Полное имя клиента
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Дата рождения клиента
    /// </summary>
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Гражданство клиента
    /// </summary>
    public string Citizenship { get; set; } = string.Empty;
}
