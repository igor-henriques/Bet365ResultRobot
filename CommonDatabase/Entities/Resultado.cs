namespace CommonDatabase.Entities;

public record Resultado : BaseEntity
{
    public EventType TipoEvento { get; set; }
    public DateTime Horario { get; set; }

    [StringLength(50)]
    public string NomeTimeCasa { get; set; }
    public short PontuacaoTimeCasa { get; set; }

    [StringLength(50)]
    public string NomeTimeVisitante { get; set; }
    public short PontuacaoTimeVisitante { get; set; }
    public short TotalGols { get; set; }
}