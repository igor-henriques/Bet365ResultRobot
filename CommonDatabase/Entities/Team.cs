namespace CommonDatabase.Entities;

public partial record Team
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string? Image { get; set; }
}