namespace CommonDatabase.Entities;

public partial record Odd
{
    public long Id { get; set; }
    public int IdMatchNext { get; set; }
    public int IdCompetition { get; set; }
    public DateTime Data { get; set; }
    public string TeamHome { get; set; } = null!;
    public string TeamAway { get; set; } = null!;
    public int IdTeamHome { get; set; }
    public int IdTeamAway { get; set; }
    public decimal PartidaVencedorCasa { get; set; }
    public decimal PartidaVencedorEmpate { get; set; }
    public decimal PartidaVencedorVisitante { get; set; }
    public decimal NumeroGols0 { get; set; }
    public decimal NumeroGols1 { get; set; }
    public decimal NumeroGols2 { get; set; }
    public decimal NumeroGols3 { get; set; }
    public decimal NumeroGols4 { get; set; }
    public decimal ResultadoCorretoCasa1x0 { get; set; }
    public decimal ResultadoCorretoCasa2x0 { get; set; }
    public decimal ResultadoCorretoCasa2x1 { get; set; }
    public decimal ResultadoCorretoCasa3x0 { get; set; }
    public decimal ResultadoCorretoCasa3x1 { get; set; }
    public decimal ResultadoCorretoCasa4x0 { get; set; }
    public decimal ResultadoCorretoEmpate0x0 { get; set; }
    public decimal ResultadoCorretoEmpate1x1 { get; set; }
    public decimal ResultadoCorretoEmpate2x2 { get; set; }
    public decimal ResultadoCorretoVisitante1x0 { get; set; }
    public decimal ResultadoCorretoVisitante2x0 { get; set; }
    public decimal ResultadoCorretoVisitante2x1 { get; set; }
    public decimal ResultadoCorretoVisitante3x0 { get; set; }
    public decimal ResultadoCorretoVisitante3x1 { get; set; }
    public decimal ResultadoCorretoVisitante4x0 { get; set; }
    public decimal ResultadoCorretoGrupoCasa1x02x02x1 { get; set; }
    public decimal ResultadoCorretoGrupoCasa3x03x14x0 { get; set; }
    public decimal ResultadoCorretoGrupoVisitante1x02x02x1 { get; set; }
    public decimal ResultadoCorretoGrupoVisitante3x03x14x0 { get; set; }
    public decimal ResultadoCorretoGrupoEmpateComGols { get; set; }
    public decimal ResultadoCorretoGrupoQualquerOutroResultado { get; set; }
    public decimal DuplaHipoteseCasaOuEmpate { get; set; }
    public decimal DuplaHipoteseEmpateOuVisitante { get; set; }
    public decimal DuplaHipoteseCasaOuVisitante { get; set; }
    public decimal TotalGolsMaisDe05 { get; set; }
    public decimal TotalGolsMaisDe15 { get; set; }
    public decimal TotalGolsMaisDe25 { get; set; }
    public decimal TotalGolsMaisDe35 { get; set; }
    public decimal TotalGolsMenosDe05 { get; set; }
    public decimal TotalGolsMenosDe15 { get; set; }
    public decimal TotalGolsMenosDe25 { get; set; }
    public decimal TotalGolsMenosDe35 { get; set; }
    public decimal HandicapResultadoCasaMenos20 { get; set; }
    public decimal HandicapResultadoCasaMenos10 { get; set; }
    public decimal HandicapResultadoCasaMais10 { get; set; }
    public decimal HandicapResultadoCasaMais20 { get; set; }
    public decimal HandicapResultadoEmpateMais20 { get; set; }
    public decimal HandicapResultadoEmpateMais10 { get; set; }
    public decimal HandicapResultadoEmpateMenos10 { get; set; }
    public decimal HandicapResultadoEmpateMenos20 { get; set; }
    public decimal HandicapResultadoVisitanteMais20 { get; set; }
    public decimal HandicapResultadoVisitanteMais10 { get; set; }
    public decimal HandicapResultadoVisitanteMenos10 { get; set; }
    public decimal HandicapResultadoVisitanteMenos20 { get; set; }
    public decimal ResultadoParaAmbosMarcaremCasaSim { get; set; }
    public decimal ResultadoParaAmbosMarcaremCasaNao { get; set; }
    public decimal ResultadoParaAmbosMarcaremVisitanteSim { get; set; }
    public decimal ResultadoParaAmbosMarcaremVisitanteNao { get; set; }
    public decimal ResultadoParaAmbosMarcaremEmpateSim { get; set; }
    public decimal ResultadoParaAmbosMarcaremEmpateNao { get; set; }
    public decimal ParaAmbosMarcaremSim { get; set; }
    public decimal ParaAmbosMarcaremNao { get; set; }
    public decimal ParaCasaMarcarSim { get; set; }
    public decimal ParaCasaMarcarNao { get; set; }
    public decimal ParaVisitanteMarcarSim { get; set; }
    public decimal ParaVisitanteMarcarNao { get; set; }
    public decimal TimeCasaGolsNaoMarcar { get; set; }
    public decimal TimeCasaGolsMarcarExatamente1 { get; set; }
    public decimal TimeCasaGolsMarcarExatamente2 { get; set; }
    public decimal TimeCasaGolsMarcarExatamente3 { get; set; }
    public decimal TimeCasaGolsMarcarExatamente4 { get; set; }
    public decimal TimeVisitanteGolsNaoMarcar { get; set; }
    public decimal TimeVisitanteGolsMarcarExatamente1 { get; set; }
    public decimal TimeVisitanteGolsMarcarExatamente2 { get; set; }
    public decimal TimeVisitanteGolsMarcarExatamente3 { get; set; }
    public decimal TimeVisitanteGolsMarcarExatamente4 { get; set; }
    public decimal MargemVitoriaCasa1 { get; set; }
    public decimal MargemVitoriaCasa2 { get; set; }
    public decimal MargemVitoriaCasa3Mais { get; set; }
    public decimal MargemVitoriaVisitante1 { get; set; }
    public decimal MargemVitoriaVisitante2 { get; set; }
    public decimal MargemVitoriaVisitante3Mais { get; set; }
    public decimal MargemVitoriaSemGols { get; set; }
    public decimal MargemVitoriaEmpateComGols { get; set; }
    public decimal TimeAmarcarPrimeiroCasa { get; set; }
    public decimal TimeAmarcarPrimeiroNenhum { get; set; }
    public decimal TimeAmarcarPrimeiroVisitante { get; set; }
    public decimal TimeAmarcarPorUltimoCasa { get; set; }
    public decimal TimeAmarcarPorUltimoNenhum { get; set; }
    public decimal TimeAmarcarPorUltimoVisitante { get; set; }
    public decimal IntervaloResultadoCasa { get; set; }
    public decimal IntervaloResultadoEmpate { get; set; }
    public decimal IntervaloResultadoVisitante { get; set; }
    public decimal IntervaloFinalJogoCasaCasa { get; set; }
    public decimal IntervaloFinalJogoCasaEmpate { get; set; }
    public decimal IntervaloFinalJogoCasaVisitante { get; set; }
    public decimal IntervaloFinalJogoEmpateCasa { get; set; }
    public decimal IntervaloFinalJogoEmpateEmpate { get; set; }
    public decimal IntervaloFinalJogoEmpateVisitante { get; set; }
    public decimal IntervaloFinalJogoVisitanteCasa { get; set; }
    public decimal IntervaloFinalJogoVisitanteEmpate { get; set; }
    public decimal IntervaloFinalJogoVisitanteVisitante { get; set; }
    public decimal IntervaloResultadoCorretoCasa1x0 { get; set; }
    public decimal IntervaloResultadoCorretoCasa2x0 { get; set; }
    public decimal IntervaloResultadoCorretoEmpate0x0 { get; set; }
    public decimal IntervaloResultadoCorretoEmpate1x1 { get; set; }
    public decimal IntervaloResultadoCorretoVisitante1x0 { get; set; }
    public decimal IntervaloResultadoCorretoVisitante2x0 { get; set; }
    public decimal IntervaloResultadoCorretoOutros { get; set; }
    public decimal ResultadoCorretoCasa3x2 { get; set; }
    public decimal ResultadoCorretoCasaQualquerOutro { get; set; }
    public decimal ResultadoCorretoEmpateQualquerOutro { get; set; }
    public decimal ResultadoCorretoVisitante3x2 { get; set; }
    public decimal ResultadoCorretoVisitanteQualquerOutro { get; set; }
    public decimal ResultadoCorretoGrupoCasa0x0 { get; set; }
    public decimal ResultadoCorretoGrupoCasa1x12x2 { get; set; }
    public decimal ResultadoCorretoGrupo3x34x4 { get; set; }
    public decimal ResultadoCorretoGrupoCasaQualquerOutro { get; set; }
    public decimal ResultadoCorretoGrupoVisitanteQualquerOutro { get; set; }
    public decimal NumeroGols5mais { get; set; }
    public decimal GoalscorerCasaCentroAvante { get; set; }
    public decimal GoalscorerCasaPontaEsquerda { get; set; }
    public decimal GoalscorerCasaMeiaAtacante { get; set; }
    public decimal GoalscorerCasaPontaDireita { get; set; }
    public decimal GoalscorerCasaQualquerOutroJogador { get; set; }
    public decimal GoalscorerVisitanteCentroAvante { get; set; }
    public decimal GoalscorerVisitantePontaEsquerda { get; set; }
    public decimal GoalscorerVisitanteMeiaAtacante { get; set; }
    public decimal GoalscorerVisitantePontaDireita { get; set; }
    public decimal GoalscorerVisitanteQualquerOutroJogador { get; set; }
    public decimal GoalscorerSemMarcadorDeGol { get; set; }
    public decimal TimeGolsCasa0 { get; set; }
    public decimal TimeGolsVisitante0 { get; set; }
    public decimal TimeGolsCasa1 { get; set; }
    public decimal TimeGolsVisitante1 { get; set; }
    public decimal TimeGolsCasa2 { get; set; }
    public decimal TimeGolsVisitante2 { get; set; }
    public decimal TimeGolsCasa3 { get; set; }
    public decimal TimeGolsVisitante3 { get; set; }
    public decimal TimeGolsCasa4 { get; set; }
    public decimal TimeGolsVisitante4 { get; set; }
    public decimal TimeGolsCasa5mais { get; set; }
    public decimal TimeGolsVisitante5mais { get; set; }
    public decimal ParaOtimeMarcarSimnaoCasaSim { get; set; }
    public decimal ParaOtimeMarcarSimnaoVisitanteSim { get; set; }
    public decimal ParaOtimeMarcarSimnaoAmbasMarcam { get; set; }
    public decimal ParaOtimeMarcarSimnaoCasaNao { get; set; }
    public decimal ParaOtimeMarcarSimnaoVisitanteNao { get; set; }

    public static implicit operator string(Odd odd)
    {
        StringBuilder sb = new();

        foreach (var prop in odd.GetType().GetProperties())
        {
            sb.AppendLine($"{prop.Name}:{prop.GetValue(odd)}");
        }

        return sb.ToString();
    }

    public override string ToString()
    {
        StringBuilder sb = new();

        foreach (var prop in this.GetType().GetProperties())
        {
            sb.AppendLine($"{prop.Name}:{prop.GetValue(this)}");
        }

        return sb.ToString();
    }
}