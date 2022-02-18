﻿namespace CommonDatabase.Entities;

public partial record MatchOddGreen
{
    public long Id { get; set; }
    public long IdMatch { get; set; }
    public long IdCompetition { get; set; }
    public bool? PartidaVencedorCasa { get; set; }
    public bool? PartidaVencedorEmpate { get; set; }
    public bool? PartidaVencedorVisitante { get; set; }
    public bool? NumeroGols0 { get; set; }
    public bool? NumeroGols1 { get; set; }
    public bool? NumeroGols2 { get; set; }
    public bool? NumeroGols3 { get; set; }
    public bool? NumeroGols4 { get; set; }
    public bool? ResultadoCorretoCasa1x0 { get; set; }
    public bool? ResultadoCorretoCasa2x0 { get; set; }
    public bool? ResultadoCorretoCasa2x1 { get; set; }
    public bool? ResultadoCorretoCasa3x0 { get; set; }
    public bool? ResultadoCorretoCasa3x1 { get; set; }
    public bool? ResultadoCorretoCasa4x0 { get; set; }
    public bool? ResultadoCorretoEmpate0x0 { get; set; }
    public bool? ResultadoCorretoEmpate1x1 { get; set; }
    public bool? ResultadoCorretoEmpate2x2 { get; set; }
    public bool? ResultadoCorretoVisitante1x0 { get; set; }
    public bool? ResultadoCorretoVisitante2x0 { get; set; }
    public bool? ResultadoCorretoVisitante2x1 { get; set; }
    public bool? ResultadoCorretoVisitante3x0 { get; set; }
    public bool? ResultadoCorretoVisitante3x1 { get; set; }
    public bool? ResultadoCorretoVisitante4x0 { get; set; }
    public bool? ResultadoCorretoGrupoCasa1x02x02x1 { get; set; }
    public bool? ResultadoCorretoGrupoCasa3x03x14x0 { get; set; }
    public bool? ResultadoCorretoGrupoVisitante1x02x02x1 { get; set; }
    public bool? ResultadoCorretoGrupoVisitante3x03x14x0 { get; set; }
    public bool? ResultadoCorretoGrupoEmpateComGols { get; set; }
    public bool? ResultadoCorretoGrupoQualquerOutroResultado { get; set; }
    public bool? DuplaHipoteseCasaOuEmpate { get; set; }
    public bool? DuplaHipoteseEmpateOuVisitante { get; set; }
    public bool? DuplaHipoteseCasaOuVisitante { get; set; }
    public bool? TotalGolsMaisDe05 { get; set; }
    public bool? TotalGolsMaisDe15 { get; set; }
    public bool? TotalGolsMaisDe25 { get; set; }
    public bool? TotalGolsMaisDe35 { get; set; }
    public bool? TotalGolsMenosDe05 { get; set; }
    public bool? TotalGolsMenosDe15 { get; set; }
    public bool? TotalGolsMenosDe25 { get; set; }
    public bool? TotalGolsMenosDe35 { get; set; }
    public bool? HandicapResultadoCasaMenos20 { get; set; }
    public bool? HandicapResultadoCasaMenos10 { get; set; }
    public bool? HandicapResultadoCasaMais10 { get; set; }
    public bool? HandicapResultadoCasaMais20 { get; set; }
    public bool? HandicapResultadoEmpateMais20 { get; set; }
    public bool? HandicapResultadoEmpateMais10 { get; set; }
    public bool? HandicapResultadoEmpateMenos10 { get; set; }
    public bool? HandicapResultadoEmpateMenos20 { get; set; }
    public bool? HandicapResultadoVisitanteMais20 { get; set; }
    public bool? HandicapResultadoVisitanteMais10 { get; set; }
    public bool? HandicapResultadoVisitanteMenos10 { get; set; }
    public bool? HandicapResultadoVisitanteMenos20 { get; set; }
    public bool? ResultadoParaAmbosMarcaremCasaSim { get; set; }
    public bool? ResultadoParaAmbosMarcaremCasaNao { get; set; }
    public bool? ResultadoParaAmbosMarcaremVisitanteSim { get; set; }
    public bool? ResultadoParaAmbosMarcaremVisitanteNao { get; set; }
    public bool? ResultadoParaAmbosMarcaremEmpateSim { get; set; }
    public bool? ResultadoParaAmbosMarcaremEmpateNao { get; set; }
    public bool? ParaAmbosMarcaremSim { get; set; }
    public bool? ParaAmbosMarcaremNao { get; set; }
    public bool? ParaCasaMarcarSim { get; set; }
    public bool? ParaCasaMarcarNao { get; set; }
    public bool? ParaVisitanteMarcarSim { get; set; }
    public bool? ParaVisitanteMarcarNao { get; set; }
    public bool? TimeCasaGolsNaoMarcar { get; set; }
    public bool? TimeCasaGolsMarcarExatamente1 { get; set; }
    public bool? TimeCasaGolsMarcarExatamente2 { get; set; }
    public bool? TimeCasaGolsMarcarExatamente3 { get; set; }
    public bool? TimeCasaGolsMarcarExatamente4 { get; set; }
    public bool? TimeVisitanteGolsNaoMarcar { get; set; }
    public bool? TimeVisitanteGolsMarcarExatamente1 { get; set; }
    public bool? TimeVisitanteGolsMarcarExatamente2 { get; set; }
    public bool? TimeVisitanteGolsMarcarExatamente3 { get; set; }
    public bool? TimeVisitanteGolsMarcarExatamente4 { get; set; }
    public bool? MargemVitoriaCasa1 { get; set; }
    public bool? MargemVitoriaCasa2 { get; set; }
    public bool? MargemVitoriaCasa3Mais { get; set; }
    public bool? MargemVitoriaVisitante1 { get; set; }
    public bool? MargemVitoriaVisitante2 { get; set; }
    public bool? MargemVitoriaVisitante3Mais { get; set; }
    public bool? MargemVitoriaSemGols { get; set; }
    public bool? MargemVitoriaEmpateComGols { get; set; }
    public bool? TimeAmarcarPrimeiroCasa { get; set; }
    public bool? TimeAmarcarPrimeiroNenhum { get; set; }
    public bool? TimeAmarcarPrimeiroVisitante { get; set; }
    public bool? TimeAmarcarPorUltimoCasa { get; set; }
    public bool? TimeAmarcarPorUltimoNenhum { get; set; }
    public bool? TimeAmarcarPorUltimoVisitante { get; set; }
    public bool? IntervaloResultadoCasa { get; set; }
    public bool? IntervaloResultadoEmpate { get; set; }
    public bool? IntervaloResultadoVisitante { get; set; }
    public bool? IntervaloFinalJogoCasaCasa { get; set; }
    public bool? IntervaloFinalJogoCasaEmpate { get; set; }
    public bool? IntervaloFinalJogoCasaVisitante { get; set; }
    public bool? IntervaloFinalJogoEmpateCasa { get; set; }
    public bool? IntervaloFinalJogoEmpateEmpate { get; set; }
    public bool? IntervaloFinalJogoEmpateVisitante { get; set; }
    public bool? IntervaloFinalJogoVisitanteCasa { get; set; }
    public bool? IntervaloFinalJogoVisitanteEmpate { get; set; }
    public bool? IntervaloFinalJogoVisitanteVisitante { get; set; }
    public bool? IntervaloResultadoCorretoCasa1x0 { get; set; }
    public bool? IntervaloResultadoCorretoCasa2x0 { get; set; }
    public bool? IntervaloResultadoCorretoEmpate0x0 { get; set; }
    public bool? IntervaloResultadoCorretoEmpate1x1 { get; set; }
    public bool? IntervaloResultadoCorretoVisitante1x0 { get; set; }
    public bool? IntervaloResultadoCorretoVisitante2x0 { get; set; }
    public bool? IntervaloResultadoCorretoOutros { get; set; }
    public bool? ResultadoCorretoCasa3x2 { get; set; }
    public bool? ResultadoCorretoCasaQualquerOutro { get; set; }
    public bool? ResultadoCorretoEmpateQualquerOutro { get; set; }
    public bool? ResultadoCorretoVisitante3x2 { get; set; }
    public bool? ResultadoCorretoVisitanteQualquerOutro { get; set; }
    public bool? ResultadoCorretoGrupoCasa0x0 { get; set; }
    public bool? ResultadoCorretoGrupoCasa1x12x2 { get; set; }
    public bool? ResultadoCorretoGrupo3x34x4 { get; set; }
    public bool? ResultadoCorretoGrupoCasaQualquerOutro { get; set; }
    public bool? ResultadoCorretoGrupoVisitanteQualquerOutro { get; set; }
    public bool? NumeroGols5mais { get; set; }
    public bool? GoalscorerCasaCentroAvante { get; set; }
    public bool? GoalscorerCasaPontaEsquerda { get; set; }
    public bool? GoalscorerCasaMeiaAtacante { get; set; }
    public bool? GoalscorerCasaPontaDireita { get; set; }
    public bool? GoalscorerCasaQualquerOutroJogador { get; set; }
    public bool? GoalscorerVisitanteCentroAvante { get; set; }
    public bool? GoalscorerVisitantePontaEsquerda { get; set; }
    public bool? GoalscorerVisitanteMeiaAtacante { get; set; }
    public bool? GoalscorerVisitantePontaDireita { get; set; }
    public bool? GoalscorerVisitanteQualquerOutroJogador { get; set; }
    public bool? GoalscorerSemMarcadorDeGol { get; set; }
    public bool? TimeGolsCasa0 { get; set; }
    public bool? TimeGolsVisitante0 { get; set; }
    public bool? TimeGolsCasa1 { get; set; }
    public bool? TimeGolsVisitante1 { get; set; }
    public bool? TimeGolsCasa2 { get; set; }
    public bool? TimeGolsVisitante2 { get; set; }
    public bool? TimeGolsCasa3 { get; set; }
    public bool? TimeGolsVisitante3 { get; set; }
    public bool? TimeGolsCasa4 { get; set; }
    public bool? TimeGolsVisitante4 { get; set; }
    public bool? TimeGolsCasa5mais { get; set; }
    public bool? TimeGolsVisitante5mais { get; set; }
    public bool? ParaOtimeMarcarSimnaoCasaSim { get; set; }
    public bool? ParaOtimeMarcarSimnaoVisitanteSim { get; set; }
    public bool? ParaOtimeMarcarSimnaoAmbasMarcam { get; set; }
    public bool? ParaOtimeMarcarSimnaoCasaNao { get; set; }
    public bool? ParaOtimeMarcarSimnaoVisitanteNao { get; set; }
}