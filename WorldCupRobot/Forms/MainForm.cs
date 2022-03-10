namespace MainRobotOrchester.Forms;

public partial class MainForm : Form
{
    private readonly System.Threading.Timer RobotsVerifier;
    private readonly System.Threading.Timer LogsCleaner;
    private readonly EuroCupWorker euroCupWorker;
    private readonly PremiershipWorker premiershipWorker;
    private readonly SuperleagueWorker superleagueWorker;
    private readonly WorldCupWorker worldCupWorker;
    private bool IsFormReady = false;

    public static readonly List<string> eurocupLogs = new();
    public static readonly List<string> premiershipLogs = new();
    public static readonly List<string> superleagueLogs = new();
    public static readonly List<string> worldcupLogs = new();

    private readonly Settings settings;

    public MainForm(IHostedService euroCupWorker, Settings settings, IHostedService premiershipWorker, IHostedService superleagueWorker, IHostedService worldCupWorker)
    {
        InitializeComponent();

        this.RobotsVerifier = new System.Threading.Timer(x => VerifyRobots(), null, 0, 1000);
        this.LogsCleaner = new System.Threading.Timer(x => CleanLogs(), null, settings.TimeToResetLogsInHours * 3_600_000, settings.TimeToResetLogsInHours * 3_600_000);
        this.settings = settings;
        this.euroCupWorker = euroCupWorker as EuroCupWorker;
        this.premiershipWorker = premiershipWorker as PremiershipWorker;
        this.superleagueWorker = superleagueWorker as SuperleagueWorker;
        this.worldCupWorker = worldCupWorker as WorldCupWorker;
    }

    private void ChangeRobotStatusDescription(ToolStripStatusLabel statusElement, Color color, EStatusRobot status)
    {
        if (IsFormReady)
            this.BeginInvoke((MethodInvoker)delegate
            {
                try
                {
                    UpdateLog(rtbEurocupLog, eurocupLogs);
                    UpdateLog(rtbPremiershipLog, premiershipLogs);
                    UpdateLog(rtbSuperleagueLog, superleagueLogs);
                    UpdateLog(rtbWorldcupLog, worldcupLogs);

                    statusElement.ForeColor = color;
                    statusElement.Text = status.ToString();
                }
                catch (Exception) { }
            });
    }

    private void UpdateLog(RichTextBox rtbRobotLog, List<string> logs)
    {
        try
        {
            var logSource = logs?.ToArray();

            if (logSource?.Length * 2 > rtbRobotLog.Lines.Length)
            {
                rtbRobotLog.Lines = logSource;
                rtbRobotLog.SelectionStart = rtbRobotLog.Text.Length;
                rtbRobotLog.ScrollToCaret();
            }
        }
        catch (Exception) { }
    }

    private void VerifyRobots()
    {
        if (!EuroCupWorker.IsAlive)
        {
            ChangeRobotStatusDescription(eurocupStatus, Color.DarkRed, EStatusRobot.ERROR);
        }
        else
        {
            ChangeRobotStatusDescription(eurocupStatus, Color.LimeGreen, EStatusRobot.OK);
        }

        if (!PremiershipWorker.IsAlive)
        {
            ChangeRobotStatusDescription(premiershipStatus, Color.DarkRed, EStatusRobot.ERROR);
        }
        else
        {
            ChangeRobotStatusDescription(premiershipStatus, Color.LimeGreen, EStatusRobot.OK);
        }

        if (!SuperleagueWorker.IsAlive)
        {
            ChangeRobotStatusDescription(superleagueStatus, Color.DarkRed, EStatusRobot.ERROR);
        }
        else
        {
            ChangeRobotStatusDescription(superleagueStatus, Color.LimeGreen, EStatusRobot.OK);
        }

        if (!WorldCupWorker.IsAlive)
        {
            ChangeRobotStatusDescription(worldcupStatus, Color.DarkRed, EStatusRobot.ERROR);
        }
        else
        {
            ChangeRobotStatusDescription(worldcupStatus, Color.LimeGreen, EStatusRobot.OK);
        }
    }

    private void CleanLogs()
    {
        this.BeginInvoke((MethodInvoker)delegate
        {
            try
            {
                eurocupLogs.Clear(); rtbEurocupLog.Clear();
                premiershipLogs.Clear(); rtbPremiershipLog.Clear();
                superleagueLogs.Clear(); rtbSuperleagueLog.Clear();
                worldcupLogs.Clear(); rtbWorldcupLog.Clear();
            }
            catch (Exception) { }
        });
    }

    public static async Task ResetRobot<T>(T robot) where T : BackgroundService, IWorker
    {
        robot.StopDriver();

        await robot.StartAsync(CancellationToken.None);
    }

    private async void eurocupStatus_Click(object sender, EventArgs e)
    {
        await ResetRobot(euroCupWorker);
    }

    private async void premiershipStatus_Click(object sender, EventArgs e)
    {
        await ResetRobot(premiershipWorker);
    }

    private async void superleagueStatus_Click(object sender, EventArgs e)
    {
        await ResetRobot(superleagueWorker);
    }

    private async void worldcupStatus_Click(object sender, EventArgs e)
    {
        await ResetRobot(worldCupWorker);
    }

    private void MainForm_Shown(object sender, EventArgs e)
    {
        this.IsFormReady = true;
    }

    private async void btnSaveConfigurations_Click(object sender, EventArgs e)
    {
        settings.UserDefinedRandomTime = int.Parse(string.IsNullOrEmpty(tbRandomTime.Text) ? "10" : tbRandomTime.Text);
        settings.TimeToResetLogsInHours = int.Parse(string.IsNullOrEmpty(tbLogsCleaningInterval.Text) ? "24" : tbLogsCleaningInterval.Text);
        settings.SecondsPausedEachIteration = int.Parse(string.IsNullOrEmpty(tbIterationInterval.Text) ? "30" : tbIterationInterval.Text);
        settings.IsDescritiveOperationsEnabled = cbOperacaoDescritiva.Checked;

        if (settings.UserDefinedRandomTime <= 0 | settings.TimeToResetLogsInHours <= 0 | settings.SecondsPausedEachIteration <= 0)
        {
            MessageBox.Show("Apenas valores positivos são válidos", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var jsonSettings = JsonConvert.SerializeObject(new
        {
            ConnectionString = Settings.ConnectionString,
            UserDefinedRandomTime = settings.UserDefinedRandomTime,
            TimeToResetLogsInHours = settings.TimeToResetLogsInHours,
            WorldCupIdCompetition = settings.WorldCupIdCompetition,
            EuroCupIdCompetition = settings.EuroCupIdCompetition,
            SuperleagueIdCompetition = settings.SuperleagueIdCompetition,
            PremiershipIdCompetition = settings.PremiershipIdCompetition,
            SecondsPausedEachIteration = settings.SecondsPausedEachIteration,
            IsDescritiveOperationsEnabled = settings.IsDescritiveOperationsEnabled,
        });

        await File.WriteAllTextAsync(Path.Combine(Environment.CurrentDirectory, "Configurations/Settings.json"), jsonSettings);

        MessageBox.Show("Configurações salvas", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnLimpar_Click(object sender, EventArgs e)
    {
        Action func = logsTabControl.SelectedTab.Text switch
        {
            "Eurocup" => () => { eurocupLogs.Clear(); rtbEurocupLog.Clear(); }
            ,
            "Premiership" => () => { premiershipLogs.Clear(); rtbPremiershipLog.Clear(); }
            ,
            "Superleague" => () => { superleagueLogs.Clear(); rtbSuperleagueLog.Clear(); }
            ,
            "Worldcup" => () => { worldcupLogs.Clear(); rtbWorldcupLog.Clear(); }
            ,
            _ => () => { }
        };

        func.Invoke();
    }

    private async void btnExport_Click(object sender, EventArgs e)
    {
        List<string> logs = logsTabControl.SelectedTab.Text switch
        {
            "Eurocup" => eurocupLogs,
            "Premiership" => premiershipLogs,
            "Superleague" => superleagueLogs,
            "Worldcup" => worldcupLogs,
            _ => new()
        };

        await File.WriteAllLinesAsync(Path.Combine(Environment.CurrentDirectory, $"{logsTabControl.SelectedTab.Text}Logs.txt"), logs);

        MessageBox.Show("Logs salvas na pasta raíz do projeto", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void logsTabControl_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (logsTabControl.SelectedIndex == 4)
        {
            btnExport.Enabled = false;
            btnLimpar.Enabled = false;
        }
        else
        {
            btnExport.Enabled = true;
            btnLimpar.Enabled = true;
        }
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        tbLogsCleaningInterval.Text = settings.TimeToResetLogsInHours.ToString();
        tbRandomTime.Text = settings.UserDefinedRandomTime.ToString();
        tbIterationInterval.Text = settings.SecondsPausedEachIteration.ToString();
        cbOperacaoDescritiva.Checked = settings.IsDescritiveOperationsEnabled;
    }

    private void tbLogsCleaningInterval_KeyPress(object sender, KeyPressEventArgs e)
    {
        var ch = e.KeyChar;

        if (ch.Equals('\b'))
            return;

        if ((!ch.Equals((char)System.Windows.Forms.Keys.Back)) && (!char.IsDigit(ch) | !int.TryParse(tbLogsCleaningInterval.Text.Trim() + ch, out _)))
        {
            e.Handled = true;
        }

        if (tbLogsCleaningInterval.Text.Length > 5)
        {
            e.Handled = true;
        }
    }

    private void tbIterationInterval_KeyPress(object sender, KeyPressEventArgs e)
    {
        var ch = e.KeyChar;

        if (ch.Equals('\b'))
            return;

        if ((!ch.Equals((char)System.Windows.Forms.Keys.Back)) && (!char.IsDigit(ch) | !int.TryParse(tbIterationInterval.Text.Trim() + ch, out _)))
        {
            e.Handled = true;
        }

        if (tbIterationInterval.Text.Length > 5)
        {
            e.Handled = true;
        }
    }

    private void tbRandomTime_KeyPress(object sender, KeyPressEventArgs e)
    {
        var ch = e.KeyChar;

        if (ch.Equals('\b'))
            return;

        if ((!ch.Equals((char)System.Windows.Forms.Keys.Back)) && (!char.IsDigit(ch) | !int.TryParse(tbRandomTime.Text.Trim() + ch, out _)))
        {
            e.Handled = true;
        }

        if (tbRandomTime.Text.Length > 5)
        {
            e.Handled = true;
        }
    }
}