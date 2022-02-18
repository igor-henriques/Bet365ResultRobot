namespace MainRobotOrchester.Forms;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainRobotStatusStrip = new System.Windows.Forms.StatusStrip();
            this.eurocupStatusDescription = new System.Windows.Forms.ToolStripStatusLabel();
            this.eurocupStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.premiershipStatusDescription = new System.Windows.Forms.ToolStripStatusLabel();
            this.premiershipStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.superleagueStatusDescription = new System.Windows.Forms.ToolStripStatusLabel();
            this.superleagueStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.worldcupStatusDescription = new System.Windows.Forms.ToolStripStatusLabel();
            this.worldcupStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.rtbRobotsLog = new System.Windows.Forms.RichTextBox();
            this.mainRobotStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainRobotStatusStrip
            // 
            this.mainRobotStatusStrip.BackColor = System.Drawing.Color.White;
            this.mainRobotStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eurocupStatusDescription,
            this.eurocupStatus,
            this.premiershipStatusDescription,
            this.premiershipStatus,
            this.superleagueStatusDescription,
            this.superleagueStatus,
            this.worldcupStatusDescription,
            this.worldcupStatus});
            this.mainRobotStatusStrip.Location = new System.Drawing.Point(0, 428);
            this.mainRobotStatusStrip.Name = "mainRobotStatusStrip";
            this.mainRobotStatusStrip.Size = new System.Drawing.Size(654, 22);
            this.mainRobotStatusStrip.TabIndex = 2;
            this.mainRobotStatusStrip.Text = "mainRobotStatusStrip";
            // 
            // eurocupStatusDescription
            // 
            this.eurocupStatusDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.eurocupStatusDescription.Name = "eurocupStatusDescription";
            this.eurocupStatusDescription.Size = new System.Drawing.Size(89, 17);
            this.eurocupStatusDescription.Text = "Eurocup Robot";
            // 
            // eurocupStatus
            // 
            this.eurocupStatus.ForeColor = System.Drawing.Color.Orange;
            this.eurocupStatus.Name = "eurocupStatus";
            this.eurocupStatus.Size = new System.Drawing.Size(57, 17);
            this.eurocupStatus.Text = "PENDING";
            // 
            // premiershipStatusDescription
            // 
            this.premiershipStatusDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.premiershipStatusDescription.Name = "premiershipStatusDescription";
            this.premiershipStatusDescription.Size = new System.Drawing.Size(111, 17);
            this.premiershipStatusDescription.Text = "Premiership Robot";
            // 
            // premiershipStatus
            // 
            this.premiershipStatus.ForeColor = System.Drawing.Color.Orange;
            this.premiershipStatus.Name = "premiershipStatus";
            this.premiershipStatus.Size = new System.Drawing.Size(57, 17);
            this.premiershipStatus.Text = "PENDING";
            // 
            // superleagueStatusDescription
            // 
            this.superleagueStatusDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.superleagueStatusDescription.Name = "superleagueStatusDescription";
            this.superleagueStatusDescription.Size = new System.Drawing.Size(114, 17);
            this.superleagueStatusDescription.Text = "Superleague Robot";
            // 
            // superleagueStatus
            // 
            this.superleagueStatus.ForeColor = System.Drawing.Color.Orange;
            this.superleagueStatus.Name = "superleagueStatus";
            this.superleagueStatus.Size = new System.Drawing.Size(57, 17);
            this.superleagueStatus.Text = "PENDING";
            // 
            // worldcupStatusDescription
            // 
            this.worldcupStatusDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.worldcupStatusDescription.Name = "worldcupStatusDescription";
            this.worldcupStatusDescription.Size = new System.Drawing.Size(98, 17);
            this.worldcupStatusDescription.Text = "Worldcup Robot";
            // 
            // worldcupStatus
            // 
            this.worldcupStatus.ForeColor = System.Drawing.Color.Orange;
            this.worldcupStatus.Name = "worldcupStatus";
            this.worldcupStatus.Size = new System.Drawing.Size(57, 17);
            this.worldcupStatus.Text = "PENDING";
            // 
            // rtbRobotsLog
            // 
            this.rtbRobotsLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbRobotsLog.Location = new System.Drawing.Point(0, 67);
            this.rtbRobotsLog.Name = "rtbRobotsLog";
            this.rtbRobotsLog.Size = new System.Drawing.Size(654, 361);
            this.rtbRobotsLog.TabIndex = 3;
            this.rtbRobotsLog.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(654, 450);
            this.Controls.Add(this.rtbRobotsLog);
            this.Controls.Add(this.mainRobotStatusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(670, 489);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bet365 - Robot Orchester";
            this.mainRobotStatusStrip.ResumeLayout(false);
            this.mainRobotStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private StatusStrip mainRobotStatusStrip;
    private ToolStripStatusLabel eurocupStatusDescription;
    private ToolStripStatusLabel eurocupStatus;
    private ToolStripStatusLabel premiershipStatusDescription;
    private ToolStripStatusLabel premiershipStatus;
    private ToolStripStatusLabel superleagueStatusDescription;
    private ToolStripStatusLabel superleagueStatus;
    private ToolStripStatusLabel worldcupStatusDescription;
    private ToolStripStatusLabel worldcupStatus;
    private RichTextBox rtbRobotsLog;
}