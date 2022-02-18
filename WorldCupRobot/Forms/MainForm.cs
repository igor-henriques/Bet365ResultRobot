namespace MainRobotOrchester.Forms;

public partial class MainForm : Form
{
    private readonly System.Threading.Timer RobotsVerifier;

    public MainForm()
    {
        InitializeComponent();

        this.RobotsVerifier = new System.Threading.Timer(x => VerifyRobots(), null, 5000, 1000);
    }

    private void ChangeRobotStatusDescription(ToolStripStatusLabel statusElement, Color color, EStatusRobot status)
    {
        this.BeginInvoke((MethodInvoker)delegate
        {
            statusElement.ForeColor = color;
            statusElement.Text = status.ToString();
        });        
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
}