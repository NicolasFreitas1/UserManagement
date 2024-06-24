namespace UserManagement.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public DateTime DateRegister { get; set; }
    public string Address { get; set; } = string.Empty;
    public string PhoneNumber {  get; set; } = string.Empty;
}
