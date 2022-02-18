namespace CommonDatabase.Entities;

public partial record OddType
{
    public int Id { get; set; }
    public string Tipo { get; set; } = null!;
    public string Nome { get; set; } = null!;
}
