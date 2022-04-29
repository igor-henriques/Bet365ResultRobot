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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainRobotStatusStrip = new System.Windows.Forms.StatusStrip();
            this.clubesStatusDescription = new System.Windows.Forms.ToolStripStatusLabel();
            this.clubesStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.worldcupStatusDescription = new System.Windows.Forms.ToolStripStatusLabel();
            this.worldcupStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.resultadosClubesDescription = new System.Windows.Forms.ToolStripStatusLabel();
            this.resultadosStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.logsTabControl = new System.Windows.Forms.TabControl();
            this.clubesTab = new System.Windows.Forms.TabPage();
            this.rtbClubesLog = new System.Windows.Forms.RichTextBox();
            this.worldcupTab = new System.Windows.Forms.TabPage();
            this.rtbWorldcupLog = new System.Windows.Forms.RichTextBox();
            this.resultadosTab = new System.Windows.Forms.TabPage();
            this.rtbResultadosLog = new System.Windows.Forms.RichTextBox();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.cbOperacaoDescritiva = new System.Windows.Forms.CheckBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbIterationInterval = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLogsCleaningInterval = new System.Windows.Forms.TextBox();
            this.btnSaveConfigurations = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRandomTime = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.mainRobotStatusStrip.SuspendLayout();
            this.logsTabControl.SuspendLayout();
            this.clubesTab.SuspendLayout();
            this.worldcupTab.SuspendLayout();
            this.resultadosTab.SuspendLayout();
            this.settingsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainRobotStatusStrip
            // 
            this.mainRobotStatusStrip.BackColor = System.Drawing.Color.White;
            this.mainRobotStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clubesStatusDescription,
            this.clubesStatus,
            this.worldcupStatusDescription,
            this.worldcupStatus,
            this.resultadosClubesDescription,
            this.resultadosStatus});
            this.mainRobotStatusStrip.Location = new System.Drawing.Point(0, 428);
            this.mainRobotStatusStrip.Name = "mainRobotStatusStrip";
            this.mainRobotStatusStrip.Size = new System.Drawing.Size(654, 22);
            this.mainRobotStatusStrip.TabIndex = 2;
            this.mainRobotStatusStrip.Text = "mainRobotStatusStrip";
            // 
            // clubesStatusDescription
            // 
            this.clubesStatusDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.clubesStatusDescription.Name = "clubesStatusDescription";
            this.clubesStatusDescription.Size = new System.Drawing.Size(80, 17);
            this.clubesStatusDescription.Text = "Clubes Robot";
            // 
            // clubesStatus
            // 
            this.clubesStatus.ForeColor = System.Drawing.Color.Orange;
            this.clubesStatus.Name = "clubesStatus";
            this.clubesStatus.Size = new System.Drawing.Size(57, 17);
            this.clubesStatus.Text = "PENDING";
            this.clubesStatus.ToolTipText = "Clique para reiniciar o robô, caso necessário";
            this.clubesStatus.Click += new System.EventHandler(this.clubesStatus_Click);
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
            this.worldcupStatus.ToolTipText = "Clique para reiniciar o robô, caso necessário";
            this.worldcupStatus.Click += new System.EventHandler(this.worldcupStatus_Click);
            // 
            // resultadosClubesDescription
            // 
            this.resultadosClubesDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.resultadosClubesDescription.Name = "resultadosClubesDescription";
            this.resultadosClubesDescription.Size = new System.Drawing.Size(104, 17);
            this.resultadosClubesDescription.Text = "Resultados Robot";
            // 
            // resultadosStatus
            // 
            this.resultadosStatus.ForeColor = System.Drawing.Color.Orange;
            this.resultadosStatus.Name = "resultadosStatus";
            this.resultadosStatus.Size = new System.Drawing.Size(57, 17);
            this.resultadosStatus.Text = "PENDING";
            // 
            // logsTabControl
            // 
            this.logsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logsTabControl.Controls.Add(this.clubesTab);
            this.logsTabControl.Controls.Add(this.worldcupTab);
            this.logsTabControl.Controls.Add(this.resultadosTab);
            this.logsTabControl.Controls.Add(this.settingsTab);
            this.logsTabControl.Location = new System.Drawing.Point(0, 0);
            this.logsTabControl.Name = "logsTabControl";
            this.logsTabControl.SelectedIndex = 0;
            this.logsTabControl.Size = new System.Drawing.Size(654, 353);
            this.logsTabControl.TabIndex = 4;
            this.logsTabControl.SelectedIndexChanged += new System.EventHandler(this.logsTabControl_SelectedIndexChanged);
            // 
            // clubesTab
            // 
            this.clubesTab.Controls.Add(this.rtbClubesLog);
            this.clubesTab.Location = new System.Drawing.Point(4, 24);
            this.clubesTab.Name = "clubesTab";
            this.clubesTab.Padding = new System.Windows.Forms.Padding(3);
            this.clubesTab.Size = new System.Drawing.Size(646, 325);
            this.clubesTab.TabIndex = 0;
            this.clubesTab.Text = "Clubes";
            this.clubesTab.UseVisualStyleBackColor = true;
            // 
            // rtbClubesLog
            // 
            this.rtbClubesLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbClubesLog.Location = new System.Drawing.Point(3, 3);
            this.rtbClubesLog.Name = "rtbClubesLog";
            this.rtbClubesLog.Size = new System.Drawing.Size(640, 319);
            this.rtbClubesLog.TabIndex = 7;
            this.rtbClubesLog.Text = "";
            // 
            // worldcupTab
            // 
            this.worldcupTab.Controls.Add(this.rtbWorldcupLog);
            this.worldcupTab.Location = new System.Drawing.Point(4, 24);
            this.worldcupTab.Name = "worldcupTab";
            this.worldcupTab.Padding = new System.Windows.Forms.Padding(3);
            this.worldcupTab.Size = new System.Drawing.Size(646, 325);
            this.worldcupTab.TabIndex = 3;
            this.worldcupTab.Text = "Worldcup";
            this.worldcupTab.UseVisualStyleBackColor = true;
            // 
            // rtbWorldcupLog
            // 
            this.rtbWorldcupLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbWorldcupLog.Location = new System.Drawing.Point(3, 3);
            this.rtbWorldcupLog.Name = "rtbWorldcupLog";
            this.rtbWorldcupLog.Size = new System.Drawing.Size(640, 319);
            this.rtbWorldcupLog.TabIndex = 5;
            this.rtbWorldcupLog.Text = "";
            // 
            // resultadosTab
            // 
            this.resultadosTab.Controls.Add(this.rtbResultadosLog);
            this.resultadosTab.Location = new System.Drawing.Point(4, 24);
            this.resultadosTab.Name = "resultadosTab";
            this.resultadosTab.Size = new System.Drawing.Size(646, 325);
            this.resultadosTab.TabIndex = 5;
            this.resultadosTab.Text = "Resultados";
            this.resultadosTab.UseVisualStyleBackColor = true;
            // 
            // rtbResultadosLog
            // 
            this.rtbResultadosLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbResultadosLog.Location = new System.Drawing.Point(0, 0);
            this.rtbResultadosLog.Name = "rtbResultadosLog";
            this.rtbResultadosLog.Size = new System.Drawing.Size(646, 325);
            this.rtbResultadosLog.TabIndex = 8;
            this.rtbResultadosLog.Text = "";
            // 
            // settingsTab
            // 
            this.settingsTab.Controls.Add(this.cbOperacaoDescritiva);
            this.settingsTab.Controls.Add(this.pictureBox3);
            this.settingsTab.Controls.Add(this.label3);
            this.settingsTab.Controls.Add(this.tbIterationInterval);
            this.settingsTab.Controls.Add(this.pictureBox2);
            this.settingsTab.Controls.Add(this.label2);
            this.settingsTab.Controls.Add(this.tbLogsCleaningInterval);
            this.settingsTab.Controls.Add(this.btnSaveConfigurations);
            this.settingsTab.Controls.Add(this.pictureBox1);
            this.settingsTab.Controls.Add(this.label1);
            this.settingsTab.Controls.Add(this.tbRandomTime);
            this.settingsTab.Location = new System.Drawing.Point(4, 24);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.settingsTab.Size = new System.Drawing.Size(646, 325);
            this.settingsTab.TabIndex = 4;
            this.settingsTab.Text = "Configurações";
            this.settingsTab.UseVisualStyleBackColor = true;
            // 
            // cbOperacaoDescritiva
            // 
            this.cbOperacaoDescritiva.AutoSize = true;
            this.cbOperacaoDescritiva.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbOperacaoDescritiva.Location = new System.Drawing.Point(423, 10);
            this.cbOperacaoDescritiva.Name = "cbOperacaoDescritiva";
            this.cbOperacaoDescritiva.Size = new System.Drawing.Size(215, 23);
            this.cbOperacaoDescritiva.TabIndex = 19;
            this.cbOperacaoDescritiva.Text = "Ativar descrição de operações";
            this.toolTip.SetToolTip(this.cbOperacaoDescritiva, "Ativa descrição de cada estágio de extração do odd");
            this.cbOperacaoDescritiva.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Black;
            this.pictureBox3.Location = new System.Drawing.Point(299, 97);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(57, 1);
            this.pictureBox3.TabIndex = 18;
            this.pictureBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(10, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 21);
            this.label3.TabIndex = 17;
            this.label3.Text = "Intervalo entre cada iteração (seg)";
            this.toolTip.SetToolTip(this.label3, "Configuração do intervalo para limpar as logs");
            // 
            // tbIterationInterval
            // 
            this.tbIterationInterval.BackColor = System.Drawing.SystemColors.Control;
            this.tbIterationInterval.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbIterationInterval.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbIterationInterval.Location = new System.Drawing.Point(299, 79);
            this.tbIterationInterval.Name = "tbIterationInterval";
            this.tbIterationInterval.Size = new System.Drawing.Size(57, 18);
            this.tbIterationInterval.TabIndex = 16;
            this.tbIterationInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.tbIterationInterval, "Configuração do intervalo para limpar as logs");
            this.tbIterationInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbIterationInterval_KeyPress);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Location = new System.Drawing.Point(299, 64);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(57, 1);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(10, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 21);
            this.label2.TabIndex = 14;
            this.label2.Text = "Intervalo para limpar logs (hrs)";
            this.toolTip.SetToolTip(this.label2, "Configuração do intervalo para limpar as logs");
            // 
            // tbLogsCleaningInterval
            // 
            this.tbLogsCleaningInterval.BackColor = System.Drawing.SystemColors.Control;
            this.tbLogsCleaningInterval.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLogsCleaningInterval.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbLogsCleaningInterval.Location = new System.Drawing.Point(299, 46);
            this.tbLogsCleaningInterval.Name = "tbLogsCleaningInterval";
            this.tbLogsCleaningInterval.Size = new System.Drawing.Size(57, 18);
            this.tbLogsCleaningInterval.TabIndex = 13;
            this.tbLogsCleaningInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.tbLogsCleaningInterval, "Configuração do intervalo para limpar as logs");
            this.tbLogsCleaningInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLogsCleaningInterval_KeyPress);
            // 
            // btnSaveConfigurations
            // 
            this.btnSaveConfigurations.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSaveConfigurations.Location = new System.Drawing.Point(3, 283);
            this.btnSaveConfigurations.Name = "btnSaveConfigurations";
            this.btnSaveConfigurations.Size = new System.Drawing.Size(640, 39);
            this.btnSaveConfigurations.TabIndex = 12;
            this.btnSaveConfigurations.Text = "Salvar";
            this.btnSaveConfigurations.UseVisualStyleBackColor = true;
            this.btnSaveConfigurations.Click += new System.EventHandler(this.btnSaveConfigurations_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(299, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 1);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "Intervalo para obter resultados (seg)";
            this.toolTip.SetToolTip(this.label1, "Configuração do tempo em segundos necessário antes de extrair resultados");
            // 
            // tbRandomTime
            // 
            this.tbRandomTime.BackColor = System.Drawing.SystemColors.Control;
            this.tbRandomTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbRandomTime.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbRandomTime.Location = new System.Drawing.Point(299, 12);
            this.tbRandomTime.Name = "tbRandomTime";
            this.tbRandomTime.Size = new System.Drawing.Size(57, 18);
            this.tbRandomTime.TabIndex = 9;
            this.tbRandomTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.tbRandomTime, "Configuração do tempo em segundos necessário antes de extrair resultados");
            this.tbRandomTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRandomTime_KeyPress);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLimpar.Location = new System.Drawing.Point(0, 395);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(654, 33);
            this.btnLimpar.TabIndex = 16;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExport.Location = new System.Drawing.Point(0, 350);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(654, 45);
            this.btnExport.TabIndex = 17;
            this.btnExport.Text = "Exportar";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(654, 450);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.logsTabControl);
            this.Controls.Add(this.mainRobotStatusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(670, 489);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bet365 - Robot Orchester";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.mainRobotStatusStrip.ResumeLayout(false);
            this.mainRobotStatusStrip.PerformLayout();
            this.logsTabControl.ResumeLayout(false);
            this.clubesTab.ResumeLayout(false);
            this.worldcupTab.ResumeLayout(false);
            this.resultadosTab.ResumeLayout(false);
            this.settingsTab.ResumeLayout(false);
            this.settingsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private StatusStrip mainRobotStatusStrip;
    private ToolStripStatusLabel clubesStatusDescription;
    private ToolStripStatusLabel clubesStatus;
    private ToolStripStatusLabel worldcupStatusDescription;
    private ToolStripStatusLabel worldcupStatus;
    private TabControl logsTabControl;
    private TabPage worldcupTab;
    private RichTextBox rtbWorldcupLog;
    private ToolTip toolTip;
    private TabPage settingsTab;
    private Button btnSaveConfigurations;
    private PictureBox pictureBox1;
    private Label label1;
    private TextBox tbRandomTime;
    private TabPage clubesTab;
    private RichTextBox rtbClubesLog;
    private Button btnLimpar;
    private Button btnExport;
    private PictureBox pictureBox2;
    private Label label2;
    private TextBox tbLogsCleaningInterval;
    private PictureBox pictureBox3;
    private Label label3;
    private TextBox tbIterationInterval;
    private CheckBox cbOperacaoDescritiva;
    private TabPage resultadosTab;
    private RichTextBox rtbResultadosLog;
    private ToolStripStatusLabel resultadosClubesDescription;
    private ToolStripStatusLabel resultadosStatus;
}