namespace CommonDatabase.Data;

public partial class Bet365RobotContext : DbContext
{
    public Bet365RobotContext()
    {
    }

    public Bet365RobotContext(DbContextOptions<Bet365RobotContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Competition> Competitions { get; set; } = null!;
    public virtual DbSet<Match> Matches { get; set; } = null!;
    public virtual DbSet<MatchNext> MatchNexts { get; set; } = null!;
    public virtual DbSet<MatchOddGreen> MatchOddGreens { get; set; } = null!;
    public virtual DbSet<MatchStatistic> MatchStatistics { get; set; } = null!;
    public virtual DbSet<MatchUniqueId> MatchUniqueIds { get; set; } = null!;
    public virtual DbSet<Odd> Odds { get; set; } = null!;
    public virtual DbSet<OddType> OddTypes { get; set; } = null!;
    public virtual DbSet<Ranking> Rankings { get; set; } = null!;
    public virtual DbSet<RankingMarket> RankingMarkets { get; set; } = null!;
    public virtual DbSet<Statistic> Statistics { get; set; } = null!;
    public virtual DbSet<StatisticChartDatum> StatisticChartData { get; set; } = null!;
    public virtual DbSet<StatisticMaxima> StatisticMaximas { get; set; } = null!;
    public virtual DbSet<Team> Teams { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(Settings.ConnectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Competition>(entity =>
        {
            entity.ToTable("Competition");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.DataUpdateMaximas)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Descricao).HasMaxLength(300);

            entity.Property(e => e.DescricaoAlternativa).HasMaxLength(300);

            entity.Property(e => e.Img)
                .HasMaxLength(100)
                .HasDefaultValueSql("('..')");

            entity.Property(e => e.LastUpdate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.NextUpdate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Match>(entity =>
        {
            entity.ToTable("Match");

            entity.HasIndex(e => new { e.IdCompetition, e.Date, e.IdTeamHome, e.IdTeamAway }, "NonClusteredIndex-20211206-192522");

            entity.HasIndex(e => new { e.Title, e.Date }, "UniqueMatch")
                .IsUnique();

            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.Property(e => e.FinalTimeResult).HasMaxLength(6);

            entity.Property(e => e.HalfTimeResult).HasMaxLength(6);

            entity.Property(e => e.PositionFirstGoalscorer).HasMaxLength(100);

            entity.Property(e => e.Title).HasMaxLength(256);

            entity.Property(e => e.UserDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<MatchNext>(entity =>
        {
            entity.ToTable("MatchNext");

            entity.Property(e => e.DataInicioJogo).HasColumnType("datetime");

            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.Property(e => e.OddBttsN)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("Odd_Btts_N");

            entity.Property(e => e.OddBttsS)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("Odd_Btts_S");

            entity.Property(e => e.OddCasa)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("Odd_Casa");

            entity.Property(e => e.OddCasaMarcaN)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("Odd_CasaMarca_N");

            entity.Property(e => e.OddCasaMarcaS)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("Odd_CasaMarca_S");

            entity.Property(e => e.OddEmpate)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("Odd_Empate");

            entity.Property(e => e.OddFora)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("Odd_Fora");

            entity.Property(e => e.OddForaMarcaN)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("Odd_ForaMarca_N");

            entity.Property(e => e.OddForaMarcaS)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("Odd_ForaMarca_S");

            entity.Property(e => e.OddGols0)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("Odd_Gols0");

            entity.Property(e => e.OddGols1)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("Odd_Gols1");

            entity.Property(e => e.OddGols2)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("Odd_Gols2");

            entity.Property(e => e.OddGols3)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("Odd_Gols3");

            entity.Property(e => e.OddGols4)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("Odd_Gols4");

            entity.Property(e => e.OddOver05)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("Odd_Over05");

            entity.Property(e => e.OddOver15)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("Odd_Over15");

            entity.Property(e => e.OddOver25)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("Odd_Over25");

            entity.Property(e => e.OddOver35)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("Odd_Over35");

            entity.Property(e => e.OddUnder05)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("Odd_Under05");

            entity.Property(e => e.OddUnder15)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("Odd_Under15");

            entity.Property(e => e.OddUnder25)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("Odd_Under25");

            entity.Property(e => e.OddUnder35)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("Odd_Under35");

            entity.Property(e => e.Tempo).HasMaxLength(10);

            entity.Property(e => e.TimeCasa).HasMaxLength(256);

            entity.Property(e => e.TimeVisitante).HasMaxLength(256);

            entity.Property(e => e.UserDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<MatchOddGreen>(entity =>
        {
            entity.ToTable("MatchOddGreen");

            entity.Property(e => e.DuplaHipoteseCasaOuEmpate).HasColumnName("DuplaHipotese_CasaOuEmpate");

            entity.Property(e => e.DuplaHipoteseCasaOuVisitante).HasColumnName("DuplaHipotese_CasaOuVisitante");

            entity.Property(e => e.DuplaHipoteseEmpateOuVisitante).HasColumnName("DuplaHipotese_EmpateOuVisitante");

            entity.Property(e => e.GoalscorerCasaCentroAvante).HasColumnName("GOALSCORER_Casa_CentroAvante");

            entity.Property(e => e.GoalscorerCasaMeiaAtacante).HasColumnName("GOALSCORER_Casa_MeiaAtacante");

            entity.Property(e => e.GoalscorerCasaPontaDireita).HasColumnName("GOALSCORER_Casa_PontaDireita");

            entity.Property(e => e.GoalscorerCasaPontaEsquerda).HasColumnName("GOALSCORER_Casa_PontaEsquerda");

            entity.Property(e => e.GoalscorerCasaQualquerOutroJogador).HasColumnName("GOALSCORER_Casa_QualquerOutroJogador");

            entity.Property(e => e.GoalscorerSemMarcadorDeGol).HasColumnName("GOALSCORER_SemMarcadorDeGol");

            entity.Property(e => e.GoalscorerVisitanteCentroAvante).HasColumnName("GOALSCORER_Visitante_CentroAvante");

            entity.Property(e => e.GoalscorerVisitanteMeiaAtacante).HasColumnName("GOALSCORER_Visitante_MeiaAtacante");

            entity.Property(e => e.GoalscorerVisitantePontaDireita).HasColumnName("GOALSCORER_Visitante_PontaDireita");

            entity.Property(e => e.GoalscorerVisitantePontaEsquerda).HasColumnName("GOALSCORER_Visitante_PontaEsquerda");

            entity.Property(e => e.GoalscorerVisitanteQualquerOutroJogador).HasColumnName("GOALSCORER_Visitante_QualquerOutroJogador");

            entity.Property(e => e.HandicapResultadoCasaMais10).HasColumnName("HandicapResultado_Casa_Mais10");

            entity.Property(e => e.HandicapResultadoCasaMais20).HasColumnName("HandicapResultado_Casa_Mais20");

            entity.Property(e => e.HandicapResultadoCasaMenos10).HasColumnName("HandicapResultado_Casa_Menos10");

            entity.Property(e => e.HandicapResultadoCasaMenos20).HasColumnName("HandicapResultado_Casa_Menos20");

            entity.Property(e => e.HandicapResultadoEmpateMais10).HasColumnName("HandicapResultado_Empate_Mais10");

            entity.Property(e => e.HandicapResultadoEmpateMais20).HasColumnName("HandicapResultado_Empate_Mais20");

            entity.Property(e => e.HandicapResultadoEmpateMenos10).HasColumnName("HandicapResultado_Empate_Menos10");

            entity.Property(e => e.HandicapResultadoEmpateMenos20).HasColumnName("HandicapResultado_Empate_Menos20");

            entity.Property(e => e.HandicapResultadoVisitanteMais10).HasColumnName("HandicapResultado_Visitante_Mais10");

            entity.Property(e => e.HandicapResultadoVisitanteMais20).HasColumnName("HandicapResultado_Visitante_Mais20");

            entity.Property(e => e.HandicapResultadoVisitanteMenos10).HasColumnName("HandicapResultado_Visitante_Menos10");

            entity.Property(e => e.HandicapResultadoVisitanteMenos20).HasColumnName("HandicapResultado_Visitante_Menos20");

            entity.Property(e => e.IntervaloFinalJogoCasaCasa).HasColumnName("IntervaloFinalJogo_CasaCasa");

            entity.Property(e => e.IntervaloFinalJogoCasaEmpate).HasColumnName("IntervaloFinalJogo_CasaEmpate");

            entity.Property(e => e.IntervaloFinalJogoCasaVisitante).HasColumnName("IntervaloFinalJogo_CasaVisitante");

            entity.Property(e => e.IntervaloFinalJogoEmpateCasa).HasColumnName("IntervaloFinalJogo_EmpateCasa");

            entity.Property(e => e.IntervaloFinalJogoEmpateEmpate).HasColumnName("IntervaloFinalJogo_EmpateEmpate");

            entity.Property(e => e.IntervaloFinalJogoEmpateVisitante).HasColumnName("IntervaloFinalJogo_EmpateVisitante");

            entity.Property(e => e.IntervaloFinalJogoVisitanteCasa).HasColumnName("IntervaloFinalJogo_VisitanteCasa");

            entity.Property(e => e.IntervaloFinalJogoVisitanteEmpate).HasColumnName("IntervaloFinalJogo_VisitanteEmpate");

            entity.Property(e => e.IntervaloFinalJogoVisitanteVisitante).HasColumnName("IntervaloFinalJogo_VisitanteVisitante");

            entity.Property(e => e.IntervaloResultadoCasa).HasColumnName("IntervaloResultado_Casa");

            entity.Property(e => e.IntervaloResultadoCorretoCasa1x0).HasColumnName("IntervaloResultadoCorreto_Casa_1x0");

            entity.Property(e => e.IntervaloResultadoCorretoCasa2x0).HasColumnName("IntervaloResultadoCorreto_Casa_2x0");

            entity.Property(e => e.IntervaloResultadoCorretoEmpate0x0).HasColumnName("IntervaloResultadoCorreto_Empate_0x0");

            entity.Property(e => e.IntervaloResultadoCorretoEmpate1x1).HasColumnName("IntervaloResultadoCorreto_Empate_1x1");

            entity.Property(e => e.IntervaloResultadoCorretoOutros).HasColumnName("IntervaloResultadoCorreto_Outros");

            entity.Property(e => e.IntervaloResultadoCorretoVisitante1x0).HasColumnName("IntervaloResultadoCorreto_Visitante_1x0");

            entity.Property(e => e.IntervaloResultadoCorretoVisitante2x0).HasColumnName("IntervaloResultadoCorreto_Visitante_2x0");

            entity.Property(e => e.IntervaloResultadoEmpate).HasColumnName("IntervaloResultado_Empate");

            entity.Property(e => e.IntervaloResultadoVisitante).HasColumnName("IntervaloResultado_Visitante");

            entity.Property(e => e.MargemVitoriaCasa1).HasColumnName("MargemVitoria_Casa1");

            entity.Property(e => e.MargemVitoriaCasa2).HasColumnName("MargemVitoria_Casa2");

            entity.Property(e => e.MargemVitoriaCasa3Mais).HasColumnName("MargemVitoria_Casa3Mais");

            entity.Property(e => e.MargemVitoriaEmpateComGols).HasColumnName("MargemVitoria_EmpateComGols");

            entity.Property(e => e.MargemVitoriaSemGols).HasColumnName("MargemVitoria_SemGols");

            entity.Property(e => e.MargemVitoriaVisitante1).HasColumnName("MargemVitoria_Visitante1");

            entity.Property(e => e.MargemVitoriaVisitante2).HasColumnName("MargemVitoria_Visitante2");

            entity.Property(e => e.MargemVitoriaVisitante3Mais).HasColumnName("MargemVitoria_Visitante3Mais");

            entity.Property(e => e.NumeroGols0).HasColumnName("NumeroGols_0");

            entity.Property(e => e.NumeroGols1).HasColumnName("NumeroGols_1");

            entity.Property(e => e.NumeroGols2).HasColumnName("NumeroGols_2");

            entity.Property(e => e.NumeroGols3).HasColumnName("NumeroGols_3");

            entity.Property(e => e.NumeroGols4).HasColumnName("NumeroGols_4");

            entity.Property(e => e.NumeroGols5mais).HasColumnName("NumeroGols_5Mais");

            entity.Property(e => e.ParaAmbosMarcaremNao).HasColumnName("ParaAmbosMarcarem_Nao");

            entity.Property(e => e.ParaAmbosMarcaremSim).HasColumnName("ParaAmbosMarcarem_Sim");

            entity.Property(e => e.ParaCasaMarcarNao).HasColumnName("ParaCasaMarcar_Nao");

            entity.Property(e => e.ParaCasaMarcarSim).HasColumnName("ParaCasaMarcar_Sim");

            entity.Property(e => e.ParaOtimeMarcarSimnaoAmbasMarcam).HasColumnName("ParaOTimeMarcarSIMNAO_AmbasMarcam");

            entity.Property(e => e.ParaOtimeMarcarSimnaoCasaNao).HasColumnName("ParaOTimeMarcarSIMNAO_CasaNao");

            entity.Property(e => e.ParaOtimeMarcarSimnaoCasaSim).HasColumnName("ParaOTimeMarcarSIMNAO_CasaSim");

            entity.Property(e => e.ParaOtimeMarcarSimnaoVisitanteNao).HasColumnName("ParaOTimeMarcarSIMNAO_VisitanteNao");

            entity.Property(e => e.ParaOtimeMarcarSimnaoVisitanteSim).HasColumnName("ParaOTimeMarcarSIMNAO_VisitanteSim");

            entity.Property(e => e.ParaVisitanteMarcarNao).HasColumnName("ParaVisitanteMarcar_Nao");

            entity.Property(e => e.ParaVisitanteMarcarSim).HasColumnName("ParaVisitanteMarcar_Sim");

            entity.Property(e => e.PartidaVencedorCasa).HasColumnName("PartidaVencedor_Casa");

            entity.Property(e => e.PartidaVencedorEmpate).HasColumnName("PartidaVencedor_Empate");

            entity.Property(e => e.PartidaVencedorVisitante).HasColumnName("PartidaVencedor_Visitante");

            entity.Property(e => e.ResultadoCorretoCasa1x0).HasColumnName("ResultadoCorreto_Casa_1x0");

            entity.Property(e => e.ResultadoCorretoCasa2x0).HasColumnName("ResultadoCorreto_Casa_2x0");

            entity.Property(e => e.ResultadoCorretoCasa2x1).HasColumnName("ResultadoCorreto_Casa_2x1");

            entity.Property(e => e.ResultadoCorretoCasa3x0).HasColumnName("ResultadoCorreto_Casa_3x0");

            entity.Property(e => e.ResultadoCorretoCasa3x1).HasColumnName("ResultadoCorreto_Casa_3x1");

            entity.Property(e => e.ResultadoCorretoCasa3x2).HasColumnName("ResultadoCorreto_Casa_3x2");

            entity.Property(e => e.ResultadoCorretoCasa4x0).HasColumnName("ResultadoCorreto_Casa_4x0");

            entity.Property(e => e.ResultadoCorretoCasaQualquerOutro).HasColumnName("ResultadoCorreto_Casa_QualquerOutro");

            entity.Property(e => e.ResultadoCorretoEmpate0x0).HasColumnName("ResultadoCorreto_Empate_0x0");

            entity.Property(e => e.ResultadoCorretoEmpate1x1).HasColumnName("ResultadoCorreto_Empate_1x1");

            entity.Property(e => e.ResultadoCorretoEmpate2x2).HasColumnName("ResultadoCorreto_Empate_2x2");

            entity.Property(e => e.ResultadoCorretoEmpateQualquerOutro).HasColumnName("ResultadoCorreto_Empate_QualquerOutro");

            entity.Property(e => e.ResultadoCorretoGrupo3x34x4).HasColumnName("ResultadoCorretoGrupo_3x3_4x4");

            entity.Property(e => e.ResultadoCorretoGrupoCasa0x0).HasColumnName("ResultadoCorretoGrupo_Casa_0x0");

            entity.Property(e => e.ResultadoCorretoGrupoCasa1x02x02x1).HasColumnName("ResultadoCorretoGrupo_Casa_1x0_2x0_2x1");

            entity.Property(e => e.ResultadoCorretoGrupoCasa1x12x2).HasColumnName("ResultadoCorretoGrupo_Casa_1x1_2x2");

            entity.Property(e => e.ResultadoCorretoGrupoCasa3x03x14x0).HasColumnName("ResultadoCorretoGrupo_Casa_3x0_3x1_4x0");

            entity.Property(e => e.ResultadoCorretoGrupoCasaQualquerOutro).HasColumnName("ResultadoCorretoGrupo_Casa_QualquerOutro");

            entity.Property(e => e.ResultadoCorretoGrupoEmpateComGols).HasColumnName("ResultadoCorretoGrupo_EmpateComGols");

            entity.Property(e => e.ResultadoCorretoGrupoQualquerOutroResultado).HasColumnName("ResultadoCorretoGrupo_QualquerOutroResultado");

            entity.Property(e => e.ResultadoCorretoGrupoVisitante1x02x02x1).HasColumnName("ResultadoCorretoGrupo_Visitante_1x0_2x0_2x1");

            entity.Property(e => e.ResultadoCorretoGrupoVisitante3x03x14x0).HasColumnName("ResultadoCorretoGrupo_Visitante_3x0_3x1_4x0");

            entity.Property(e => e.ResultadoCorretoGrupoVisitanteQualquerOutro).HasColumnName("ResultadoCorretoGrupo_Visitante_QualquerOutro");

            entity.Property(e => e.ResultadoCorretoVisitante1x0).HasColumnName("ResultadoCorreto_Visitante_1x0");

            entity.Property(e => e.ResultadoCorretoVisitante2x0).HasColumnName("ResultadoCorreto_Visitante_2x0");

            entity.Property(e => e.ResultadoCorretoVisitante2x1).HasColumnName("ResultadoCorreto_Visitante_2x1");

            entity.Property(e => e.ResultadoCorretoVisitante3x0).HasColumnName("ResultadoCorreto_Visitante_3x0");

            entity.Property(e => e.ResultadoCorretoVisitante3x1).HasColumnName("ResultadoCorreto_Visitante_3x1");

            entity.Property(e => e.ResultadoCorretoVisitante3x2).HasColumnName("ResultadoCorreto_Visitante_3x2");

            entity.Property(e => e.ResultadoCorretoVisitante4x0).HasColumnName("ResultadoCorreto_Visitante_4x0");

            entity.Property(e => e.ResultadoCorretoVisitanteQualquerOutro).HasColumnName("ResultadoCorreto_Visitante_QualquerOutro");

            entity.Property(e => e.ResultadoParaAmbosMarcaremCasaNao).HasColumnName("ResultadoParaAmbosMarcarem_CasaNao");

            entity.Property(e => e.ResultadoParaAmbosMarcaremCasaSim).HasColumnName("ResultadoParaAmbosMarcarem_CasaSim");

            entity.Property(e => e.ResultadoParaAmbosMarcaremEmpateNao).HasColumnName("ResultadoParaAmbosMarcarem_EmpateNao");

            entity.Property(e => e.ResultadoParaAmbosMarcaremEmpateSim).HasColumnName("ResultadoParaAmbosMarcarem_EmpateSim");

            entity.Property(e => e.ResultadoParaAmbosMarcaremVisitanteNao).HasColumnName("ResultadoParaAmbosMarcarem_VisitanteNao");

            entity.Property(e => e.ResultadoParaAmbosMarcaremVisitanteSim).HasColumnName("ResultadoParaAmbosMarcarem_VisitanteSim");

            entity.Property(e => e.TimeAmarcarPorUltimoCasa).HasColumnName("TimeAMarcarPorUltimo_Casa");

            entity.Property(e => e.TimeAmarcarPorUltimoNenhum).HasColumnName("TimeAMarcarPorUltimo_Nenhum");

            entity.Property(e => e.TimeAmarcarPorUltimoVisitante).HasColumnName("TimeAMarcarPorUltimo_Visitante");

            entity.Property(e => e.TimeAmarcarPrimeiroCasa).HasColumnName("TimeAMarcarPrimeiro_Casa");

            entity.Property(e => e.TimeAmarcarPrimeiroNenhum).HasColumnName("TimeAMarcarPrimeiro_Nenhum");

            entity.Property(e => e.TimeAmarcarPrimeiroVisitante).HasColumnName("TimeAMarcarPrimeiro_Visitante");

            entity.Property(e => e.TimeCasaGolsMarcarExatamente1).HasColumnName("TimeCasaGols_MarcarExatamente1");

            entity.Property(e => e.TimeCasaGolsMarcarExatamente2).HasColumnName("TimeCasaGols_MarcarExatamente2");

            entity.Property(e => e.TimeCasaGolsMarcarExatamente3).HasColumnName("TimeCasaGols_MarcarExatamente3");

            entity.Property(e => e.TimeCasaGolsMarcarExatamente4).HasColumnName("TimeCasaGols_MarcarExatamente4");

            entity.Property(e => e.TimeCasaGolsNaoMarcar).HasColumnName("TimeCasaGols_NaoMarcar");

            entity.Property(e => e.TimeGolsCasa0).HasColumnName("TimeGols_Casa0");

            entity.Property(e => e.TimeGolsCasa1).HasColumnName("TimeGols_Casa1");

            entity.Property(e => e.TimeGolsCasa2).HasColumnName("TimeGols_Casa2");

            entity.Property(e => e.TimeGolsCasa3).HasColumnName("TimeGols_Casa3");

            entity.Property(e => e.TimeGolsCasa4).HasColumnName("TimeGols_Casa4");

            entity.Property(e => e.TimeGolsCasa5mais).HasColumnName("TimeGols_Casa5mais");

            entity.Property(e => e.TimeGolsVisitante0).HasColumnName("TimeGols_Visitante0");

            entity.Property(e => e.TimeGolsVisitante1).HasColumnName("TimeGols_Visitante1");

            entity.Property(e => e.TimeGolsVisitante2).HasColumnName("TimeGols_Visitante2");

            entity.Property(e => e.TimeGolsVisitante3).HasColumnName("TimeGols_Visitante3");

            entity.Property(e => e.TimeGolsVisitante4).HasColumnName("TimeGols_Visitante4");

            entity.Property(e => e.TimeGolsVisitante5mais).HasColumnName("TimeGols_Visitante5mais");

            entity.Property(e => e.TimeVisitanteGolsMarcarExatamente1).HasColumnName("TimeVisitanteGols_MarcarExatamente1");

            entity.Property(e => e.TimeVisitanteGolsMarcarExatamente2).HasColumnName("TimeVisitanteGols_MarcarExatamente2");

            entity.Property(e => e.TimeVisitanteGolsMarcarExatamente3).HasColumnName("TimeVisitanteGols_MarcarExatamente3");

            entity.Property(e => e.TimeVisitanteGolsMarcarExatamente4).HasColumnName("TimeVisitanteGols_MarcarExatamente4");

            entity.Property(e => e.TimeVisitanteGolsNaoMarcar).HasColumnName("TimeVisitanteGols_NaoMarcar");

            entity.Property(e => e.TotalGolsMaisDe05).HasColumnName("TotalGols_MaisDe_05");

            entity.Property(e => e.TotalGolsMaisDe15).HasColumnName("TotalGols_MaisDe_15");

            entity.Property(e => e.TotalGolsMaisDe25).HasColumnName("TotalGols_MaisDe_25");

            entity.Property(e => e.TotalGolsMaisDe35).HasColumnName("TotalGols_MaisDe_35");

            entity.Property(e => e.TotalGolsMenosDe05).HasColumnName("TotalGols_MenosDe_05");

            entity.Property(e => e.TotalGolsMenosDe15).HasColumnName("TotalGols_MenosDe_15");

            entity.Property(e => e.TotalGolsMenosDe25).HasColumnName("TotalGols_MenosDe_25");

            entity.Property(e => e.TotalGolsMenosDe35).HasColumnName("TotalGols_MenosDe_35");
        });

        modelBuilder.Entity<MatchStatistic>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<MatchUniqueId>(entity =>
        {
            entity.ToTable("MatchUniqueId");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Odd>(entity =>
        {
            entity.ToTable("Odd");

            entity.Property(e => e.Data).HasColumnType("datetime");

            entity.Property(e => e.DuplaHipoteseCasaOuEmpate)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DuplaHipotese_CasaOuEmpate");

            entity.Property(e => e.DuplaHipoteseCasaOuVisitante)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DuplaHipotese_CasaOuVisitante");

            entity.Property(e => e.DuplaHipoteseEmpateOuVisitante)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DuplaHipotese_EmpateOuVisitante");

            entity.Property(e => e.GoalscorerCasaCentroAvante)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("GOALSCORER_Casa_CentroAvante");

            entity.Property(e => e.GoalscorerCasaMeiaAtacante)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("GOALSCORER_Casa_MeiaAtacante");

            entity.Property(e => e.GoalscorerCasaPontaDireita)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("GOALSCORER_Casa_PontaDireita");

            entity.Property(e => e.GoalscorerCasaPontaEsquerda)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("GOALSCORER_Casa_PontaEsquerda");

            entity.Property(e => e.GoalscorerCasaQualquerOutroJogador)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("GOALSCORER_Casa_QualquerOutroJogador");

            entity.Property(e => e.GoalscorerSemMarcadorDeGol)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("GOALSCORER_SemMarcadorDeGol");

            entity.Property(e => e.GoalscorerVisitanteCentroAvante)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("GOALSCORER_Visitante_CentroAvante");

            entity.Property(e => e.GoalscorerVisitanteMeiaAtacante)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("GOALSCORER_Visitante_MeiaAtacante");

            entity.Property(e => e.GoalscorerVisitantePontaDireita)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("GOALSCORER_Visitante_PontaDireita");

            entity.Property(e => e.GoalscorerVisitantePontaEsquerda)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("GOALSCORER_Visitante_PontaEsquerda");

            entity.Property(e => e.GoalscorerVisitanteQualquerOutroJogador)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("GOALSCORER_Visitante_QualquerOutroJogador");

            entity.Property(e => e.HandicapResultadoCasaMais10)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("HandicapResultado_Casa_Mais10");

            entity.Property(e => e.HandicapResultadoCasaMais20)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("HandicapResultado_Casa_Mais20");

            entity.Property(e => e.HandicapResultadoCasaMenos10)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("HandicapResultado_Casa_Menos10");

            entity.Property(e => e.HandicapResultadoCasaMenos20)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("HandicapResultado_Casa_Menos20");

            entity.Property(e => e.HandicapResultadoEmpateMais10)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("HandicapResultado_Empate_Mais10");

            entity.Property(e => e.HandicapResultadoEmpateMais20)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("HandicapResultado_Empate_Mais20");

            entity.Property(e => e.HandicapResultadoEmpateMenos10)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("HandicapResultado_Empate_Menos10");

            entity.Property(e => e.HandicapResultadoEmpateMenos20)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("HandicapResultado_Empate_Menos20");

            entity.Property(e => e.HandicapResultadoVisitanteMais10)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("HandicapResultado_Visitante_Mais10");

            entity.Property(e => e.HandicapResultadoVisitanteMais20)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("HandicapResultado_Visitante_Mais20");

            entity.Property(e => e.HandicapResultadoVisitanteMenos10)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("HandicapResultado_Visitante_Menos10");

            entity.Property(e => e.HandicapResultadoVisitanteMenos20)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("HandicapResultado_Visitante_Menos20");

            entity.Property(e => e.IntervaloFinalJogoCasaCasa)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IntervaloFinalJogo_CasaCasa");

            entity.Property(e => e.IntervaloFinalJogoCasaEmpate)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IntervaloFinalJogo_CasaEmpate");

            entity.Property(e => e.IntervaloFinalJogoCasaVisitante)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IntervaloFinalJogo_CasaVisitante");

            entity.Property(e => e.IntervaloFinalJogoEmpateCasa)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IntervaloFinalJogo_EmpateCasa");

            entity.Property(e => e.IntervaloFinalJogoEmpateEmpate)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IntervaloFinalJogo_EmpateEmpate");

            entity.Property(e => e.IntervaloFinalJogoEmpateVisitante)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IntervaloFinalJogo_EmpateVisitante");

            entity.Property(e => e.IntervaloFinalJogoVisitanteCasa)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IntervaloFinalJogo_VisitanteCasa");

            entity.Property(e => e.IntervaloFinalJogoVisitanteEmpate)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IntervaloFinalJogo_VisitanteEmpate");

            entity.Property(e => e.IntervaloFinalJogoVisitanteVisitante)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IntervaloFinalJogo_VisitanteVisitante");

            entity.Property(e => e.IntervaloResultadoCasa)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IntervaloResultado_Casa");

            entity.Property(e => e.IntervaloResultadoCorretoCasa1x0)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IntervaloResultadoCorreto_Casa_1x0");

            entity.Property(e => e.IntervaloResultadoCorretoCasa2x0)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IntervaloResultadoCorreto_Casa_2x0");

            entity.Property(e => e.IntervaloResultadoCorretoEmpate0x0)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IntervaloResultadoCorreto_Empate_0x0");

            entity.Property(e => e.IntervaloResultadoCorretoEmpate1x1)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IntervaloResultadoCorreto_Empate_1x1");

            entity.Property(e => e.IntervaloResultadoCorretoOutros)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IntervaloResultadoCorreto_Outros");

            entity.Property(e => e.IntervaloResultadoCorretoVisitante1x0)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IntervaloResultadoCorreto_Visitante_1x0");

            entity.Property(e => e.IntervaloResultadoCorretoVisitante2x0)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IntervaloResultadoCorreto_Visitante_2x0");

            entity.Property(e => e.IntervaloResultadoEmpate)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IntervaloResultado_Empate");

            entity.Property(e => e.IntervaloResultadoVisitante)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IntervaloResultado_Visitante");

            entity.Property(e => e.MargemVitoriaCasa1)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MargemVitoria_Casa1");

            entity.Property(e => e.MargemVitoriaCasa2)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MargemVitoria_Casa2");

            entity.Property(e => e.MargemVitoriaCasa3Mais)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MargemVitoria_Casa3Mais");

            entity.Property(e => e.MargemVitoriaEmpateComGols)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MargemVitoria_EmpateComGols");

            entity.Property(e => e.MargemVitoriaSemGols)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MargemVitoria_SemGols");

            entity.Property(e => e.MargemVitoriaVisitante1)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MargemVitoria_Visitante1");

            entity.Property(e => e.MargemVitoriaVisitante2)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MargemVitoria_Visitante2");

            entity.Property(e => e.MargemVitoriaVisitante3Mais)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MargemVitoria_Visitante3Mais");

            entity.Property(e => e.NumeroGols0)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NumeroGols_0");

            entity.Property(e => e.NumeroGols1)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NumeroGols_1");

            entity.Property(e => e.NumeroGols2)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NumeroGols_2");

            entity.Property(e => e.NumeroGols3)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NumeroGols_3");

            entity.Property(e => e.NumeroGols4)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NumeroGols_4");

            entity.Property(e => e.NumeroGols5mais)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NumeroGols_5Mais");

            entity.Property(e => e.ParaAmbosMarcaremNao)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ParaAmbosMarcarem_Nao");

            entity.Property(e => e.ParaAmbosMarcaremSim)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ParaAmbosMarcarem_Sim");

            entity.Property(e => e.ParaCasaMarcarNao)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ParaCasaMarcar_Nao");

            entity.Property(e => e.ParaCasaMarcarSim)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ParaCasaMarcar_Sim");

            entity.Property(e => e.ParaOtimeMarcarSimnaoAmbasMarcam)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ParaOTimeMarcarSIMNAO_AmbasMarcam");

            entity.Property(e => e.ParaOtimeMarcarSimnaoCasaNao)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ParaOTimeMarcarSIMNAO_CasaNao");

            entity.Property(e => e.ParaOtimeMarcarSimnaoCasaSim)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ParaOTimeMarcarSIMNAO_CasaSim");

            entity.Property(e => e.ParaOtimeMarcarSimnaoVisitanteNao)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ParaOTimeMarcarSIMNAO_VisitanteNao");

            entity.Property(e => e.ParaOtimeMarcarSimnaoVisitanteSim)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ParaOTimeMarcarSIMNAO_VisitanteSim");

            entity.Property(e => e.ParaVisitanteMarcarNao)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ParaVisitanteMarcar_Nao");

            entity.Property(e => e.ParaVisitanteMarcarSim)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ParaVisitanteMarcar_Sim");

            entity.Property(e => e.PartidaVencedorCasa)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PartidaVencedor_Casa");

            entity.Property(e => e.PartidaVencedorEmpate)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PartidaVencedor_Empate");

            entity.Property(e => e.PartidaVencedorVisitante)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PartidaVencedor_Visitante");

            entity.Property(e => e.ResultadoCorretoCasa1x0)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorreto_Casa_1x0");

            entity.Property(e => e.ResultadoCorretoCasa2x0)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorreto_Casa_2x0");

            entity.Property(e => e.ResultadoCorretoCasa2x1)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorreto_Casa_2x1");

            entity.Property(e => e.ResultadoCorretoCasa3x0)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorreto_Casa_3x0");

            entity.Property(e => e.ResultadoCorretoCasa3x1)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorreto_Casa_3x1");

            entity.Property(e => e.ResultadoCorretoCasa3x2)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorreto_Casa_3x2");

            entity.Property(e => e.ResultadoCorretoCasa4x0)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorreto_Casa_4x0");

            entity.Property(e => e.ResultadoCorretoCasaQualquerOutro)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorreto_Casa_QualquerOutro");

            entity.Property(e => e.ResultadoCorretoEmpate0x0)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorreto_Empate_0x0");

            entity.Property(e => e.ResultadoCorretoEmpate1x1)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorreto_Empate_1x1");

            entity.Property(e => e.ResultadoCorretoEmpate2x2)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorreto_Empate_2x2");

            entity.Property(e => e.ResultadoCorretoEmpateQualquerOutro)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorreto_Empate_QualquerOutro");

            entity.Property(e => e.ResultadoCorretoGrupo3x34x4)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorretoGrupo_3x3_4x4");

            entity.Property(e => e.ResultadoCorretoGrupoCasa0x0)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorretoGrupo_Casa_0x0");

            entity.Property(e => e.ResultadoCorretoGrupoCasa1x02x02x1)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorretoGrupo_Casa_1x0_2x0_2x1");

            entity.Property(e => e.ResultadoCorretoGrupoCasa1x12x2)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorretoGrupo_Casa_1x1_2x2");

            entity.Property(e => e.ResultadoCorretoGrupoCasa3x03x14x0)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorretoGrupo_Casa_3x0_3x1_4x0");

            entity.Property(e => e.ResultadoCorretoGrupoCasaQualquerOutro)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorretoGrupo_Casa_QualquerOutro");

            entity.Property(e => e.ResultadoCorretoGrupoEmpateComGols)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorretoGrupo_EmpateComGols");

            entity.Property(e => e.ResultadoCorretoGrupoQualquerOutroResultado)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorretoGrupo_QualquerOutroResultado");

            entity.Property(e => e.ResultadoCorretoGrupoVisitante1x02x02x1)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorretoGrupo_Visitante_1x0_2x0_2x1");

            entity.Property(e => e.ResultadoCorretoGrupoVisitante3x03x14x0)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorretoGrupo_Visitante_3x0_3x1_4x0");

            entity.Property(e => e.ResultadoCorretoGrupoVisitanteQualquerOutro)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorretoGrupo_Visitante_QualquerOutro");

            entity.Property(e => e.ResultadoCorretoVisitante1x0)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorreto_Visitante_1x0");

            entity.Property(e => e.ResultadoCorretoVisitante2x0)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorreto_Visitante_2x0");

            entity.Property(e => e.ResultadoCorretoVisitante2x1)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorreto_Visitante_2x1");

            entity.Property(e => e.ResultadoCorretoVisitante3x0)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorreto_Visitante_3x0");

            entity.Property(e => e.ResultadoCorretoVisitante3x1)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorreto_Visitante_3x1");

            entity.Property(e => e.ResultadoCorretoVisitante3x2)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorreto_Visitante_3x2");

            entity.Property(e => e.ResultadoCorretoVisitante4x0)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorreto_Visitante_4x0");

            entity.Property(e => e.ResultadoCorretoVisitanteQualquerOutro)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoCorreto_Visitante_QualquerOutro");

            entity.Property(e => e.ResultadoParaAmbosMarcaremCasaNao)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoParaAmbosMarcarem_CasaNao");

            entity.Property(e => e.ResultadoParaAmbosMarcaremCasaSim)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoParaAmbosMarcarem_CasaSim");

            entity.Property(e => e.ResultadoParaAmbosMarcaremEmpateNao)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoParaAmbosMarcarem_EmpateNao");

            entity.Property(e => e.ResultadoParaAmbosMarcaremEmpateSim)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoParaAmbosMarcarem_EmpateSim");

            entity.Property(e => e.ResultadoParaAmbosMarcaremVisitanteNao)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoParaAmbosMarcarem_VisitanteNao");

            entity.Property(e => e.ResultadoParaAmbosMarcaremVisitanteSim)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ResultadoParaAmbosMarcarem_VisitanteSim");

            entity.Property(e => e.TeamAway).HasMaxLength(250);

            entity.Property(e => e.TeamHome).HasMaxLength(250);

            entity.Property(e => e.TimeAmarcarPorUltimoCasa)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeAMarcarPorUltimo_Casa");

            entity.Property(e => e.TimeAmarcarPorUltimoNenhum)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeAMarcarPorUltimo_Nenhum");

            entity.Property(e => e.TimeAmarcarPorUltimoVisitante)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeAMarcarPorUltimo_Visitante");

            entity.Property(e => e.TimeAmarcarPrimeiroCasa)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeAMarcarPrimeiro_Casa");

            entity.Property(e => e.TimeAmarcarPrimeiroNenhum)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeAMarcarPrimeiro_Nenhum");

            entity.Property(e => e.TimeAmarcarPrimeiroVisitante)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeAMarcarPrimeiro_Visitante");

            entity.Property(e => e.TimeCasaGolsMarcarExatamente1)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeCasaGols_MarcarExatamente1");

            entity.Property(e => e.TimeCasaGolsMarcarExatamente2)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeCasaGols_MarcarExatamente2");

            entity.Property(e => e.TimeCasaGolsMarcarExatamente3)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeCasaGols_MarcarExatamente3");

            entity.Property(e => e.TimeCasaGolsMarcarExatamente4)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeCasaGols_MarcarExatamente4");

            entity.Property(e => e.TimeCasaGolsNaoMarcar)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeCasaGols_NaoMarcar");

            entity.Property(e => e.TimeGolsCasa0)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeGols_Casa0");

            entity.Property(e => e.TimeGolsCasa1)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeGols_Casa1");

            entity.Property(e => e.TimeGolsCasa2)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeGols_Casa2");

            entity.Property(e => e.TimeGolsCasa3)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeGols_Casa3");

            entity.Property(e => e.TimeGolsCasa4)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeGols_Casa4");

            entity.Property(e => e.TimeGolsCasa5mais)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeGols_Casa5mais");

            entity.Property(e => e.TimeGolsVisitante0)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeGols_Visitante0");

            entity.Property(e => e.TimeGolsVisitante1)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeGols_Visitante1");

            entity.Property(e => e.TimeGolsVisitante2)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeGols_Visitante2");

            entity.Property(e => e.TimeGolsVisitante3)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeGols_Visitante3");

            entity.Property(e => e.TimeGolsVisitante4)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeGols_Visitante4");

            entity.Property(e => e.TimeGolsVisitante5mais)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeGols_Visitante5mais");

            entity.Property(e => e.TimeVisitanteGolsMarcarExatamente1)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeVisitanteGols_MarcarExatamente1");

            entity.Property(e => e.TimeVisitanteGolsMarcarExatamente2)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeVisitanteGols_MarcarExatamente2");

            entity.Property(e => e.TimeVisitanteGolsMarcarExatamente3)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeVisitanteGols_MarcarExatamente3");

            entity.Property(e => e.TimeVisitanteGolsMarcarExatamente4)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeVisitanteGols_MarcarExatamente4");

            entity.Property(e => e.TimeVisitanteGolsNaoMarcar)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TimeVisitanteGols_NaoMarcar");

            entity.Property(e => e.TotalGolsMaisDe05)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TotalGols_MaisDe_05");

            entity.Property(e => e.TotalGolsMaisDe15)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TotalGols_MaisDe_15");

            entity.Property(e => e.TotalGolsMaisDe25)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TotalGols_MaisDe_25");

            entity.Property(e => e.TotalGolsMaisDe35)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TotalGols_MaisDe_35");

            entity.Property(e => e.TotalGolsMenosDe05)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TotalGols_MenosDe_05");

            entity.Property(e => e.TotalGolsMenosDe15)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TotalGols_MenosDe_15");

            entity.Property(e => e.TotalGolsMenosDe25)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TotalGols_MenosDe_25");

            entity.Property(e => e.TotalGolsMenosDe35)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TotalGols_MenosDe_35");
        });

        modelBuilder.Entity<OddType>(entity =>
        {
            entity.ToTable("OddType");

            entity.Property(e => e.Nome).HasMaxLength(150);

            entity.Property(e => e.Tipo).HasMaxLength(100);
        });

        modelBuilder.Entity<Ranking>(entity =>
        {
            entity.ToTable("Ranking");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.Property(e => e.DateUpdate).HasColumnType("datetime");

            entity.Property(e => e.Market).HasMaxLength(100);

            entity.Property(e => e.MarketPercents).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.Team).HasMaxLength(256);
        });

        modelBuilder.Entity<RankingMarket>(entity =>
        {
            entity.ToTable("RankingMarket");

            entity.Property(e => e.Market).HasMaxLength(150);
        });

        modelBuilder.Entity<Statistic>(entity =>
        {
            entity.ToTable("Statistic");

            entity.HasIndex(e => e.Categoria, "StatisticMaxima_Categoria");

            entity.Property(e => e.Categoria).HasMaxLength(250);

            entity.Property(e => e.Descricao).HasMaxLength(250);

            entity.Property(e => e.IdTelegramGroups).HasMaxLength(1000);

            entity.Property(e => e.IdTelegramGroupsTodosCampeonatos).HasMaxLength(1000);

            entity.Property(e => e.Nome).HasMaxLength(250);

            entity.Property(e => e.Template).HasMaxLength(4000);
        });

        modelBuilder.Entity<StatisticChartDatum>(entity =>
        {
            entity.Property(e => e.AmbasMarcam).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.DataUpdate).HasColumnType("datetime");

            entity.Property(e => e.Over15).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.Over25).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.Under25).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<StatisticMaxima>(entity =>
        {
            entity.ToTable("StatisticMaxima");

            entity.Property(e => e.DataEnvio).HasColumnType("datetime");

            entity.Property(e => e.DataUpdate).HasColumnType("datetime");

            entity.Property(e => e.Porcentagem).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.ValorEnvio).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.IdCompetitionNavigation)
                .WithMany(p => p.StatisticMaximas)
                .HasForeignKey(d => d.IdCompetition)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StatisticMaxima_Competition");

            entity.HasOne(d => d.IdStatisticNavigation)
                .WithMany(p => p.StatisticMaximas)
                .HasForeignKey(d => d.IdStatistic)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StatisticMaxima_Statistic");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.ToTable("Team");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.Image).HasMaxLength(50);

            entity.Property(e => e.Nome).HasMaxLength(256);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}