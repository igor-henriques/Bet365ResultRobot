using System.Globalization;

namespace MainRobotOrchester.Builders;

public class OddBuilder<T> where T : BackgroundService, IWorker
{
    private readonly NumberFormatInfo decimalFormat = new NumberFormatInfo { NumberDecimalSeparator = "." };
    private readonly IWebRepository webRepository;
    private readonly Settings settings;
    private readonly ElementsXPath elementsXPath;
    private readonly ElementsCSS elementsCSS;
    private ILogger<T> logger;

    public OddBuilder(IWebRepository webRepository, Settings settings, ElementsXPath elementsXPath, ElementsCSS elementsCSS, ILogger<T> logger)
    {
        this.logger = logger;
        this.webRepository = webRepository;
        this.settings = settings;
        this.elementsXPath = elementsXPath;
        this.elementsCSS = elementsCSS;
    }

    public async Task<Odd> BuildOddAsync()
    {
        Odd odd = new()
        {
            IdCompetition = settings.EuroCupIdCompetition,
            Data = DateTime.UtcNow,
            TeamHome = await webRepository.GetElementContent(By.XPath(elementsXPath.NomeTimeCasa)),
            TeamAway = await webRepository.GetElementContent(By.XPath(elementsXPath.NomeTimeVisitante)),
        };

        odd = await ScrapSectionsAsync(odd);

        return odd;
    }

    private async Task<Odd> ScrapSectionsAsync(Odd odd)
    {
        try
        {
            var sections = await webRepository.GetElements(By.ClassName(elementsCSS.InformationSections));

            while (!IsSectionsAvailable(sections))
            {
                sections = await webRepository.GetElements(By.ClassName(elementsCSS.InformationSections));
            }

            foreach (var section in sections)
            {
                var task = section?.Text?.ToUpper() switch
                {
                    "FULLTIME RESULT" => ScrapFullTimeResultSection(odd),
                    "DOUBLE CHANCE" => ScrapDoubleChanceSection(odd),
                    "RESULTADO CORRETO" => ScrapResultadoCorretoSection(odd),
                    "RESULTADO CORRETO - GRUPO" => ScrapResultadoCorretoGrupoSection(odd),
                    "INTERVALO/FINAL DO JOGO" => ScrapIntervaloFinalJogoSection(odd),
                    "GOLS MAIS/MENOS" => ScrapGolsMaisMenosSection(odd),
                    "TOTAL DE GOLS EXATOS" => ScrapTotalGolsExatosSection(odd),
                    "FIRST GOALSCORER" => ScrapFirstGoalScorerSection(odd),
                    "RESULTADO/PARA AMBOS OS TIMES MARCAREM" => ScrapResultadosAmbosTimesMarcaremSection(odd),
                    "HANDICAP - RESULTADO" => ScrapHandicapResultadoSection(odd),
                    "MARGEM DE VITÓRIA" => ScrapMargemVitoriaSection(odd),
                    "TIME - GOLS" => ScrapTimeGolsSection(odd),
                    "PARA O TIME MARCAR - SIM/NÃO" => ScrapParaTimeMarcarSection(odd),
                    "PRIMEIRO TIME A MARCAR" => ScrapPrimeiroTimeMarcarSection(odd),
                    "HALF TIME RESULT" => ScrapHalfTimeResultSection(odd),
                    "RESULTADO CORRETO - INTERVALO" => ScrapResultadoCorretoIntervaloSection(odd),
                    _ => Task.FromResult(odd)
                };

                odd = await task;
            }

            return odd;
        }
        catch (Exception)
        {
            odd = await ScrapSectionsAsync(odd);
        }

        return odd;
    }

    private bool IsSectionsAvailable(IReadOnlyCollection<IWebElement> sections)
    {
        return sections.Count() >= 16;
    }

    private async Task<Odd> ScrapFullTimeResultSection(Odd odd)
    {
        if (settings.IsDescritiveOperationsEnabled)
            logger.UILogInformation($"PROCESSANDO ODD - FULLTIME RESULT");

        odd.PartidaVencedorCasa = decimal.Parse(await webRepository.GetElementContent(By.XPath(elementsXPath.PartidaVencedorCasa)), decimalFormat);
        odd.PartidaVencedorEmpate = decimal.Parse(await webRepository.GetElementContent(By.XPath(elementsXPath.PartidaVencedorEmpate)), decimalFormat);
        odd.PartidaVencedorVisitante = decimal.Parse(await webRepository.GetElementContent(By.XPath(elementsXPath.PartidaVencedorVisitante)), decimalFormat);

        return await ValueTask.FromResult(odd);
    }

    private async Task<Odd> ScrapDoubleChanceSection(Odd odd)
    {
        if (settings.IsDescritiveOperationsEnabled)
            logger.UILogInformation($"PROCESSANDO ODD - DOUBLE CHANCE");

        odd.DuplaHipoteseCasaOuEmpate = decimal.Parse(await webRepository.GetElementContent(By.XPath(elementsXPath.DuplaHipoteseCasaOuEmpate)), decimalFormat); ;
        odd.DuplaHipoteseCasaOuVisitante = decimal.Parse(await webRepository.GetElementContent(By.XPath(elementsXPath.DuplaHipoteseCasaOuVisitante)), decimalFormat); ;
        odd.DuplaHipoteseEmpateOuVisitante = decimal.Parse(await webRepository.GetElementContent(By.XPath(elementsXPath.DuplaHipoteseEmpateOuVisitante)), decimalFormat); ;

        return await ValueTask.FromResult(odd);
    }
    private async Task<Odd> ScrapResultadoCorretoSection(Odd odd)
    {
        if (settings.IsDescritiveOperationsEnabled)
            logger.UILogInformation($"PROCESSANDO ODD - RESULTADO CORRETO");

        var elements = await webRepository.GetElements(By.ClassName(elementsCSS.ResultadosCorretos));

        var listElements = elements.ToList();

        odd.ResultadoCorretoCasa1x0 = decimal.Parse(listElements[0].Text, decimalFormat);
        odd.ResultadoCorretoCasa2x0 = decimal.Parse(listElements[1].Text, decimalFormat);
        odd.ResultadoCorretoCasa2x1 = decimal.Parse(listElements[2].Text, decimalFormat);
        odd.ResultadoCorretoCasa3x0 = decimal.Parse(listElements[3].Text, decimalFormat);
        odd.ResultadoCorretoCasa3x1 = decimal.Parse(listElements[4].Text, decimalFormat);
        odd.ResultadoCorretoCasa3x2 = decimal.Parse(listElements[5].Text, decimalFormat);
        odd.ResultadoCorretoCasa4x0 = decimal.Parse(listElements[6].Text, decimalFormat);
        odd.ResultadoCorretoCasaQualquerOutro = decimal.Parse(listElements[7].Text, decimalFormat);
        odd.ResultadoCorretoEmpate0x0 = decimal.Parse(listElements[8].Text, decimalFormat);
        odd.ResultadoCorretoEmpate1x1 = decimal.Parse(listElements[9].Text, decimalFormat);
        odd.ResultadoCorretoEmpate2x2 = decimal.Parse(listElements[10].Text, decimalFormat);
        odd.ResultadoCorretoEmpateQualquerOutro = decimal.Parse(listElements[11].Text, decimalFormat);
        odd.ResultadoCorretoVisitante1x0 = decimal.Parse(listElements[12].Text, decimalFormat);
        odd.ResultadoCorretoVisitante2x0 = decimal.Parse(listElements[13].Text, decimalFormat);
        odd.ResultadoCorretoVisitante2x1 = decimal.Parse(listElements[14].Text, decimalFormat);
        odd.ResultadoCorretoVisitante3x0 = decimal.Parse(listElements[15].Text, decimalFormat);
        odd.ResultadoCorretoVisitante3x1 = decimal.Parse(listElements[16].Text, decimalFormat);
        odd.ResultadoCorretoVisitante3x2 = decimal.Parse(listElements[17].Text, decimalFormat);
        odd.ResultadoCorretoVisitante4x0 = decimal.Parse(listElements[18].Text, decimalFormat);
        odd.ResultadoCorretoVisitanteQualquerOutro = decimal.Parse(listElements[19].Text, decimalFormat);

        return await ValueTask.FromResult(odd);
    }
    private async Task<Odd> ScrapResultadoCorretoGrupoSection(Odd odd)
    {
        if (settings.IsDescritiveOperationsEnabled)
            logger.UILogInformation($"PROCESSANDO ODD - RESULTADO CORRETO - GRUPO");

        var elements = await webRepository.GetElements(By.ClassName(elementsCSS.ResultadosCorretos));

        var listElements = elements.ToList();

        odd.ResultadoCorretoGrupoCasa1x02x02x1 = decimal.Parse(listElements[20].Text, decimalFormat);
        odd.ResultadoCorretoGrupoCasa3x03x14x0 = decimal.Parse(listElements[21].Text, decimalFormat);
        odd.ResultadoCorretoGrupoCasa0x0 = decimal.Parse(listElements[22].Text, decimalFormat);
        odd.ResultadoCorretoGrupoCasa1x12x2 = decimal.Parse(listElements[23].Text, decimalFormat);
        odd.ResultadoCorretoGrupoVisitante1x02x02x1 = decimal.Parse(listElements[24].Text, decimalFormat);
        odd.ResultadoCorretoGrupoVisitante3x03x14x0 = decimal.Parse(listElements[25].Text, decimalFormat);
        odd.ResultadoCorretoGrupo3x34x4 = decimal.Parse(listElements[26].Text, decimalFormat);
        odd.ResultadoCorretoGrupoCasaQualquerOutro = decimal.Parse(listElements[27].Text, decimalFormat);
        odd.ResultadoCorretoGrupoVisitanteQualquerOutro = decimal.Parse(listElements[28].Text, decimalFormat);

        return await ValueTask.FromResult(odd);
    }

    private async Task<Odd> ScrapIntervaloFinalJogoSection(Odd odd)
    {
        if (settings.IsDescritiveOperationsEnabled)
            logger.UILogInformation($"PROCESSANDO ODD - INTERVALO/FINAL DO JOGO");

        var elements = await webRepository.GetElements(By.ClassName(elementsCSS.IntervaloFinalJogoANDFirstGoalScorer));

        var listElements = elements.ToList();

        odd.IntervaloFinalJogoCasaCasa = decimal.Parse(listElements[3].Text, decimalFormat);
        odd.IntervaloFinalJogoCasaEmpate = decimal.Parse(listElements[4].Text, decimalFormat);
        odd.IntervaloFinalJogoCasaVisitante = decimal.Parse(listElements[5].Text, decimalFormat);
        odd.IntervaloFinalJogoEmpateCasa = decimal.Parse(listElements[6].Text, decimalFormat);
        odd.IntervaloFinalJogoEmpateEmpate = decimal.Parse(listElements[7].Text, decimalFormat);
        odd.IntervaloFinalJogoEmpateVisitante = decimal.Parse(listElements[8].Text, decimalFormat);
        odd.IntervaloFinalJogoVisitanteCasa = decimal.Parse(listElements[9].Text, decimalFormat);
        odd.IntervaloFinalJogoVisitanteEmpate = decimal.Parse(listElements[10].Text, decimalFormat);
        odd.IntervaloFinalJogoVisitanteVisitante = decimal.Parse(listElements[11].Text, decimalFormat);

        return await ValueTask.FromResult(odd);
    }
    private async Task<Odd> ScrapGolsMaisMenosSection(Odd odd)
    {
        if (settings.IsDescritiveOperationsEnabled)
            logger.UILogInformation($"PROCESSANDO ODD - GOLS MAIS/MENOS");

        var elements = await webRepository.GetElements(By.ClassName(elementsCSS.GolsMaisMenos_ResultadosAmbosTimesMarcarem_MargemVitoria_TimeGols_ParaTimeMarcar_PrimeiroTimeMarcar));

        var listElements = elements.ToList();

        odd.TotalGolsMaisDe05 = decimal.Parse(listElements[0].Text, decimalFormat);
        odd.TotalGolsMaisDe15 = decimal.Parse(listElements[1].Text, decimalFormat);
        odd.TotalGolsMaisDe25 = decimal.Parse(listElements[2].Text, decimalFormat);
        odd.TotalGolsMaisDe35 = decimal.Parse(listElements[3].Text, decimalFormat);
        odd.TotalGolsMenosDe05 = decimal.Parse(listElements[4].Text, decimalFormat);
        odd.TotalGolsMenosDe15 = decimal.Parse(listElements[5].Text, decimalFormat);
        odd.TotalGolsMenosDe25 = decimal.Parse(listElements[6].Text, decimalFormat);
        odd.TotalGolsMenosDe35 = decimal.Parse(listElements[7].Text, decimalFormat);

        return await ValueTask.FromResult(odd);
    }
    private async Task<Odd> ScrapTotalGolsExatosSection(Odd odd)
    {
        if (settings.IsDescritiveOperationsEnabled)
            logger.UILogInformation($"PROCESSANDO ODD - TOTAL DE GOLS EXATOS");

        var elements = await webRepository.GetElements(By.ClassName(elementsCSS.GolsExatosANDHalfTimeResult));

        var listElements = elements.ToList();

        odd.NumeroGols0 = decimal.Parse(listElements[0].Text, decimalFormat);
        odd.NumeroGols1 = decimal.Parse(listElements[1].Text, decimalFormat);
        odd.NumeroGols2 = decimal.Parse(listElements[2].Text, decimalFormat);
        odd.NumeroGols3 = decimal.Parse(listElements[3].Text, decimalFormat);
        odd.NumeroGols4 = decimal.Parse(listElements[4].Text, decimalFormat);
        odd.NumeroGols5mais = 0;

        return await ValueTask.FromResult(odd);
    }
    private async Task<Odd> ScrapFirstGoalScorerSection(Odd odd)
    {
        if (settings.IsDescritiveOperationsEnabled)
            logger.UILogInformation($"PROCESSANDO ODD - FIRST Goalscorer");

        var elements = await webRepository.GetElements(By.ClassName(elementsCSS.IntervaloFinalJogoANDFirstGoalScorer));

        var listElements = elements.ToList();

        odd.GoalscorerCasaCentroAvante = decimal.Parse(listElements[12].Text, decimalFormat);
        odd.GoalscorerCasaPontaEsquerda = decimal.Parse(listElements[13].Text, decimalFormat);
        odd.GoalscorerCasaMeiaAtacante = decimal.Parse(listElements[14].Text, decimalFormat);
        odd.GoalscorerCasaPontaDireita = decimal.Parse(listElements[15].Text, decimalFormat);
        odd.GoalscorerCasaQualquerOutroJogador = decimal.Parse(listElements[16].Text, decimalFormat);
        odd.GoalscorerVisitanteCentroAvante = decimal.Parse(listElements[17].Text, decimalFormat);
        odd.GoalscorerVisitantePontaEsquerda = decimal.Parse(listElements[18].Text, decimalFormat);
        odd.GoalscorerVisitanteMeiaAtacante = decimal.Parse(listElements[19].Text, decimalFormat);
        odd.GoalscorerVisitantePontaDireita = decimal.Parse(listElements[20].Text, decimalFormat);
        odd.GoalscorerVisitanteQualquerOutroJogador = decimal.Parse(listElements[21].Text, decimalFormat);
        odd.GoalscorerSemMarcadorDeGol = decimal.Parse(listElements[22].Text, decimalFormat);

        return await ValueTask.FromResult(odd);
    }
    private async Task<Odd> ScrapResultadosAmbosTimesMarcaremSection(Odd odd)
    {
        if (settings.IsDescritiveOperationsEnabled)
            logger.UILogInformation($"PROCESSANDO ODD - RESULTADO/PARA AMBOS OS TIMES MARCAREM");

        var elements = await webRepository.GetElements(By.ClassName(elementsCSS.GolsMaisMenos_ResultadosAmbosTimesMarcarem_MargemVitoria_TimeGols_ParaTimeMarcar_PrimeiroTimeMarcar));

        var listElements = elements.ToList();

        odd.ResultadoParaAmbosMarcaremCasaSim = decimal.Parse(listElements[8].Text, decimalFormat);
        odd.ResultadoParaAmbosMarcaremVisitanteSim = decimal.Parse(listElements[9].Text, decimalFormat);
        odd.ResultadoParaAmbosMarcaremEmpateSim = decimal.Parse(listElements[10].Text, decimalFormat);
        odd.ResultadoParaAmbosMarcaremCasaNao = decimal.Parse(listElements[11].Text, decimalFormat);
        odd.ResultadoParaAmbosMarcaremVisitanteNao = decimal.Parse(listElements[12].Text, decimalFormat);
        odd.ResultadoParaAmbosMarcaremEmpateNao = decimal.Parse(listElements[13].Text, decimalFormat);

        return await ValueTask.FromResult(odd);
    }
    private async Task<Odd> ScrapHandicapResultadoSection(Odd odd)
    {
        if (settings.IsDescritiveOperationsEnabled)
            logger.UILogInformation($"PROCESSANDO ODD - HANDICAP - RESULTADO");

        var elements = await webRepository.GetElements(By.ClassName(elementsCSS.ResultadosCorretos));

        var listElements = elements.ToList();

        odd.HandicapResultadoCasaMenos20 = decimal.Parse(listElements[31].Text, decimalFormat);
        odd.HandicapResultadoCasaMenos10 = decimal.Parse(listElements[32].Text, decimalFormat);
        odd.HandicapResultadoCasaMais10 = decimal.Parse(listElements[33].Text, decimalFormat);
        odd.HandicapResultadoCasaMais20 = decimal.Parse(listElements[34].Text, decimalFormat);
        odd.HandicapResultadoEmpateMais20 = decimal.Parse(listElements[35].Text, decimalFormat);
        odd.HandicapResultadoEmpateMais10 = decimal.Parse(listElements[36].Text, decimalFormat);
        odd.HandicapResultadoEmpateMenos10 = decimal.Parse(listElements[37].Text, decimalFormat);
        odd.HandicapResultadoEmpateMenos20 = decimal.Parse(listElements[38].Text, decimalFormat);
        odd.HandicapResultadoVisitanteMais20 = decimal.Parse(listElements[39].Text, decimalFormat);
        odd.HandicapResultadoVisitanteMais10 = decimal.Parse(listElements[40].Text, decimalFormat);
        odd.HandicapResultadoVisitanteMenos10 = decimal.Parse(listElements[41].Text, decimalFormat);
        odd.HandicapResultadoVisitanteMenos20 = decimal.Parse(listElements[42].Text, decimalFormat);

        return await ValueTask.FromResult(odd);
    }
    private async Task<Odd> ScrapMargemVitoriaSection(Odd odd)
    {
        if (settings.IsDescritiveOperationsEnabled)
            logger.UILogInformation($"PROCESSANDO ODD - MARGEM DE VITÓRIA");

        var elements = await webRepository.GetElements(By.ClassName(elementsCSS.GolsMaisMenos_ResultadosAmbosTimesMarcarem_MargemVitoria_TimeGols_ParaTimeMarcar_PrimeiroTimeMarcar));

        var listElements = elements.ToList();

        odd.MargemVitoriaCasa1 = decimal.Parse(listElements[14].Text, decimalFormat);
        odd.MargemVitoriaCasa2 = decimal.Parse(listElements[15].Text, decimalFormat);
        odd.MargemVitoriaCasa3Mais = decimal.Parse(listElements[16].Text, decimalFormat);
        odd.MargemVitoriaVisitante1 = decimal.Parse(listElements[17].Text, decimalFormat);
        odd.MargemVitoriaVisitante2 = decimal.Parse(listElements[18].Text, decimalFormat);
        odd.MargemVitoriaVisitante3Mais = decimal.Parse(listElements[19].Text, decimalFormat);
        odd.MargemVitoriaSemGols = decimal.Parse(listElements[20].Text, decimalFormat);
        odd.MargemVitoriaEmpateComGols = decimal.Parse(listElements[21].Text, decimalFormat);

        return await ValueTask.FromResult(odd);
    }
    private async Task<Odd> ScrapTimeGolsSection(Odd odd)
    {
        if (settings.IsDescritiveOperationsEnabled)
            logger.UILogInformation($"PROCESSANDO ODD - TIME GOLS");

        var elements = await webRepository.GetElements(By.ClassName(elementsCSS.GolsMaisMenos_ResultadosAmbosTimesMarcarem_MargemVitoria_TimeGols_ParaTimeMarcar_PrimeiroTimeMarcar));

        var listElements = elements.ToList();

        odd.TimeGolsCasa0 = decimal.Parse(listElements[22].Text, decimalFormat);
        odd.TimeGolsVisitante0 = decimal.Parse(listElements[23].Text, decimalFormat);
        odd.TimeGolsCasa1 = decimal.Parse(listElements[24].Text, decimalFormat);
        odd.TimeGolsVisitante1 = decimal.Parse(listElements[25].Text, decimalFormat);
        odd.TimeGolsCasa2 = decimal.Parse(listElements[26].Text, decimalFormat);
        odd.TimeGolsVisitante2 = decimal.Parse(listElements[27].Text, decimalFormat);
        odd.TimeGolsCasa3 = decimal.Parse(listElements[28].Text, decimalFormat);
        odd.TimeGolsVisitante3 = decimal.Parse(listElements[29].Text, decimalFormat);
        odd.TimeGolsCasa4 = decimal.Parse(listElements[30].Text, decimalFormat);
        odd.TimeGolsVisitante4 = decimal.Parse(listElements[31].Text, decimalFormat);
        odd.TimeGolsCasa5mais = decimal.Parse(listElements[32].Text, decimalFormat);
        odd.TimeGolsVisitante5mais = decimal.Parse(listElements[33].Text, decimalFormat);

        return await ValueTask.FromResult(odd);
    }
    private async Task<Odd> ScrapParaTimeMarcarSection(Odd odd)
    {
        if (settings.IsDescritiveOperationsEnabled)
            logger.UILogInformation($"PROCESSANDO ODD - PARA O TIME MARCAR");

        var elements = await webRepository.GetElements(By.ClassName(elementsCSS.GolsMaisMenos_ResultadosAmbosTimesMarcarem_MargemVitoria_TimeGols_ParaTimeMarcar_PrimeiroTimeMarcar));

        var listElements = elements.ToList();

        odd.ParaOtimeMarcarSimnaoCasaSim = decimal.Parse(listElements[34].Text, decimalFormat);
        odd.ParaOtimeMarcarSimnaoVisitanteSim = decimal.Parse(listElements[35].Text, decimalFormat);
        odd.ParaOtimeMarcarSimnaoAmbasMarcam = decimal.Parse(listElements[36].Text, decimalFormat);
        odd.ParaOtimeMarcarSimnaoCasaNao = decimal.Parse(listElements[37].Text, decimalFormat);
        odd.ParaOtimeMarcarSimnaoVisitanteNao = decimal.Parse(listElements[38].Text, decimalFormat);

        return await ValueTask.FromResult(odd);
    }
    private async Task<Odd> ScrapPrimeiroTimeMarcarSection(Odd odd)
    {
        if (settings.IsDescritiveOperationsEnabled)
            logger.UILogInformation($"PROCESSANDO ODD - PRIMEIRO TIME A MARCAR");

        var elements = await webRepository.GetElements(By.ClassName(elementsCSS.GolsMaisMenos_ResultadosAmbosTimesMarcarem_MargemVitoria_TimeGols_ParaTimeMarcar_PrimeiroTimeMarcar));

        var listElements = elements.ToList();

        odd.TimeAmarcarPrimeiroCasa = decimal.Parse(listElements[39].Text, decimalFormat);
        odd.TimeAmarcarPrimeiroVisitante = decimal.Parse(listElements[40].Text, decimalFormat);
        odd.TimeAmarcarPrimeiroNenhum = decimal.Parse(listElements[41].Text, decimalFormat);
        odd.TimeAmarcarPorUltimoCasa = decimal.Parse(listElements[42].Text, decimalFormat);
        odd.TimeAmarcarPorUltimoVisitante = decimal.Parse(listElements[43].Text, decimalFormat);
        odd.TimeAmarcarPorUltimoNenhum = decimal.Parse(listElements[44].Text, decimalFormat);

        return await ValueTask.FromResult(odd);
    }
    private async Task<Odd> ScrapHalfTimeResultSection(Odd odd)
    {
        if (settings.IsDescritiveOperationsEnabled)
            logger.UILogInformation($"PROCESSANDO ODD - HALFTIMERESULT");

        var elements = await webRepository.GetElements(By.ClassName(elementsCSS.GolsExatosANDHalfTimeResult));

        var listElements = elements.ToList();

        odd.IntervaloResultadoCasa = decimal.Parse(listElements[5].Text, decimalFormat);
        odd.IntervaloResultadoEmpate = decimal.Parse(listElements[6].Text, decimalFormat);
        odd.IntervaloResultadoVisitante = decimal.Parse(listElements[7].Text, decimalFormat);

        return await ValueTask.FromResult(odd);
    }
    private async Task<Odd> ScrapResultadoCorretoIntervaloSection(Odd odd)
    {
        if (settings.IsDescritiveOperationsEnabled)
            logger.UILogInformation($"PROCESSANDO ODD - RESULTADO CORRETO INTERVALO");

        var elements = await webRepository.GetElements(By.ClassName(elementsCSS.ResultadosCorretos));

        var listElements = elements.ToList();

        odd.IntervaloResultadoCorretoCasa1x0 = decimal.Parse(listElements[43].Text, decimalFormat);
        odd.IntervaloResultadoCorretoCasa2x0 = decimal.Parse(listElements[44].Text, decimalFormat);
        odd.IntervaloResultadoCorretoEmpate0x0 = decimal.Parse(listElements[45].Text, decimalFormat);
        odd.IntervaloResultadoCorretoEmpate1x1 = decimal.Parse(listElements[46].Text, decimalFormat);
        odd.IntervaloResultadoCorretoVisitante1x0 = decimal.Parse(listElements[47].Text, decimalFormat);
        odd.IntervaloResultadoCorretoVisitante2x0 = decimal.Parse(listElements[48].Text, decimalFormat);
        odd.IntervaloResultadoCorretoOutros = decimal.Parse(listElements[49].Text, decimalFormat);

        return await ValueTask.FromResult(odd);
    }
}