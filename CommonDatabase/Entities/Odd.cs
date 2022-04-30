namespace CommonDatabase.Entities;

/// <summary>
/// Por questões de performance, foi optado por definir todas
/// as propriedades em uma só entidade para evitar joins no banco
/// 
/// Desenvolvedor: Igor Henriques
/// Data: 27/04/2022
/// </summary>
public record Odd : BaseEntity
{    
    public EventType TipoEvento { get; set; }
    public DateTime DataInicio { get; set; }
    [StringLength(50)]
    public string NomeCompeticao { get; set; }

    // Probabilidades ---------------
    [StringLength(50)]
    public string NomeTimeCasa { get; set; }
    public decimal ProbabilidadeVitoriaTimeCasa { get; set; }
    [StringLength(50)]
    public string NomeTimeVisitante { get; set; }
    public decimal ProbabilidadeVitoriaTimeVisitante { get; set; }
    public decimal ProbabilidadeEmpate { get; set; }

    // Mais/Menos de 2.5 Gols ---------------
    public decimal MaisDe2_5Gols { get; set; }
    public decimal MenosDe2_5Gols { get; set; }

    // Pontuação Correta ---------------
    public decimal PontuacaoCorretaTimeCasa_1_0 { get; set; }
    public decimal PontuacaoCorretaTimeCasa_2_0 { get; set; }
    public decimal PontuacaoCorretaTimeCasa_2_1 { get; set; }
    public decimal PontuacaoCorretaTimeVisitante_1_0 { get; set; }
    public decimal PontuacaoCorretaTimeVisitante_2_0 { get; set; }
    public decimal PontuacaoCorretaTimeVisitante_2_1 { get; set; }
    public decimal PontuacaoCorretaEmpate_1_0 { get; set; }
    public decimal PontuacaoCorretaEmpate_2_0 { get; set; }
    public decimal PontuacaoCorretaEmpate_2_1 { get; set; }

    // Dupla ---------------
    public decimal VisitadoOuEmpate { get; set; }
    public decimal VisitadoOuVisitante { get; set; }
    public decimal EmpateOuVisitante { get; set; }

    // Número total de gols ---------------
    public decimal Total0Gols { get; set; }
    public decimal Total1Gols { get; set; }
    public decimal Total2Gols { get; set; }
    public decimal Total3Gols { get; set; }
    public decimal Total4Gols { get; set; }
}