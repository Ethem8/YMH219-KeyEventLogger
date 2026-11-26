namespace KeyEventLogger
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.topPanel = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlIndicator = new System.Windows.Forms.Panel();
            this.lblRecordingState = new System.Windows.Forms.Label();
            this.lblFocus = new System.Windows.Forms.Label();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.chkKeyDown = new System.Windows.Forms.CheckBox();
            this.chkKeyUp = new System.Windows.Forms.CheckBox();
            this.chkKeyPress = new System.Windows.Forms.CheckBox();
            this.grpStats = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblKeyDownCount = new System.Windows.Forms.Label();
            this.lblTopTitle = new System.Windows.Forms.Label();
            this.lstTopKeys = new System.Windows.Forms.ListBox();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.lblPlayground = new System.Windows.Forms.Label();
            this.txtPlayground = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.topPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.grpOptions.SuspendLayout();
            this.grpStats.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            //
            // topPanel
            //
            this.topPanel.Controls.Add(this.btnStart);
            this.topPanel.Controls.Add(this.btnStop);
            this.topPanel.Controls.Add(this.btnClear);
            this.topPanel.Controls.Add(this.btnSave);
            this.topPanel.Controls.Add(this.pnlIndicator);
            this.topPanel.Controls.Add(this.lblRecordingState);
            this.topPanel.Controls.Add(this.lblFocus);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Size = new System.Drawing.Size(860, 50);
            this.topPanel.Name = "topPanel";
            //
            // btnStart
            //
            this.btnStart.Location = new System.Drawing.Point(10, 10);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(90, 30);
            this.btnStart.TabStop = false;
            this.btnStart.Text = "▶ Başlat";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            //
            // btnStop
            //
            this.btnStop.Location = new System.Drawing.Point(106, 10);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(90, 30);
            this.btnStop.TabStop = false;
            this.btnStop.Text = "■ Durdur";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            //
            // btnClear
            //
            this.btnClear.Location = new System.Drawing.Point(202, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 30);
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Temizle";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // btnSave
            //
            this.btnSave.Location = new System.Drawing.Point(298, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 30);
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Kaydet (.txt)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // pnlIndicator
            //
            this.pnlIndicator.BackColor = System.Drawing.Color.Gray;
            this.pnlIndicator.Location = new System.Drawing.Point(430, 17);
            this.pnlIndicator.Name = "pnlIndicator";
            this.pnlIndicator.Size = new System.Drawing.Size(16, 16);
            //
            // lblRecordingState
            //
            this.lblRecordingState.AutoSize = true;
            this.lblRecordingState.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRecordingState.Location = new System.Drawing.Point(452, 15);
            this.lblRecordingState.Name = "lblRecordingState";
            this.lblRecordingState.Text = "KAYIT KAPALI";
            //
            // lblFocus
            //
            this.lblFocus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFocus.Location = new System.Drawing.Point(600, 17);
            this.lblFocus.Name = "lblFocus";
            this.lblFocus.Size = new System.Drawing.Size(250, 18);
            this.lblFocus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblFocus.Text = "Pencere odakta";
            //
            // lstLog
            //
            this.lstLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLog.Font = new System.Drawing.Font("Consolas", 10F);
            this.lstLog.HorizontalScrollbar = true;
            this.lstLog.IntegralHeight = false;
            this.lstLog.Name = "lstLog";
            //
            // rightPanel
            //
            this.rightPanel.Controls.Add(this.grpOptions);
            this.rightPanel.Controls.Add(this.grpStats);
            this.rightPanel.Controls.Add(this.grpFilter);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Location = new System.Drawing.Point(580, 50);
            this.rightPanel.Size = new System.Drawing.Size(280, 424);
            //
            // grpOptions
            //
            this.grpOptions.Controls.Add(this.chkKeyDown);
            this.grpOptions.Controls.Add(this.chkKeyUp);
            this.grpOptions.Controls.Add(this.chkKeyPress);
            this.grpOptions.Location = new System.Drawing.Point(8, 4);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(264, 75);
            this.grpOptions.Text = "Kaydedilecek olaylar";
            //
            // chkKeyDown
            //
            this.chkKeyDown.AutoSize = true;
            this.chkKeyDown.Checked = true;
            this.chkKeyDown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKeyDown.Location = new System.Drawing.Point(12, 22);
            this.chkKeyDown.Name = "chkKeyDown";
            this.chkKeyDown.TabStop = false;
            this.chkKeyDown.Text = "KeyDown";
            //
            // chkKeyUp
            //
            this.chkKeyUp.AutoSize = true;
            this.chkKeyUp.Location = new System.Drawing.Point(12, 46);
            this.chkKeyUp.Name = "chkKeyUp";
            this.chkKeyUp.TabStop = false;
            this.chkKeyUp.Text = "KeyUp";
            //
            // chkKeyPress
            //
            this.chkKeyPress.AutoSize = true;
            this.chkKeyPress.Location = new System.Drawing.Point(130, 22);
            this.chkKeyPress.Name = "chkKeyPress";
            this.chkKeyPress.TabStop = false;
            this.chkKeyPress.Text = "KeyPress (karakter)";
            //
            // grpStats
            //
            this.grpStats.Controls.Add(this.lblTotal);
            this.grpStats.Controls.Add(this.lblKeyDownCount);
            this.grpStats.Controls.Add(this.lblTopTitle);
            this.grpStats.Controls.Add(this.lstTopKeys);
            this.grpStats.Location = new System.Drawing.Point(8, 85);
            this.grpStats.Name = "grpStats";
            this.grpStats.Size = new System.Drawing.Size(264, 200);
            this.grpStats.Text = "İstatistik";
            //
            // lblTotal
            //
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(12, 22);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Text = "Toplam kayıt: 0";
            //
            // lblKeyDownCount
            //
            this.lblKeyDownCount.AutoSize = true;
            this.lblKeyDownCount.Location = new System.Drawing.Point(12, 44);
            this.lblKeyDownCount.Name = "lblKeyDownCount";
            this.lblKeyDownCount.Text = "Tuş basımı: 0";
            //
            // lblTopTitle
            //
            this.lblTopTitle.AutoSize = true;
            this.lblTopTitle.Location = new System.Drawing.Point(12, 68);
            this.lblTopTitle.Name = "lblTopTitle";
            this.lblTopTitle.Text = "En sık basılan 5 tuş:";
            //
            // lstTopKeys
            //
            this.lstTopKeys.IntegralHeight = false;
            this.lstTopKeys.Location = new System.Drawing.Point(12, 88);
            this.lstTopKeys.Name = "lstTopKeys";
            this.lstTopKeys.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstTopKeys.Size = new System.Drawing.Size(240, 100);
            this.lstTopKeys.TabStop = false;
            //
            // grpFilter
            //
            this.grpFilter.Controls.Add(this.lblFrom);
            this.grpFilter.Controls.Add(this.dtpFrom);
            this.grpFilter.Controls.Add(this.lblTo);
            this.grpFilter.Controls.Add(this.dtpTo);
            this.grpFilter.Controls.Add(this.btnFilter);
            this.grpFilter.Controls.Add(this.btnShowAll);
            this.grpFilter.Location = new System.Drawing.Point(8, 292);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(264, 135);
            this.grpFilter.Text = "Tarih/saat aralığına göre filtre";
            //
            // lblFrom
            //
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(12, 26);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Text = "Başlangıç:";
            //
            // dtpFrom
            //
            this.dtpFrom.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(82, 22);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(170, 23);
            this.dtpFrom.TabStop = false;
            //
            // lblTo
            //
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(12, 57);
            this.lblTo.Name = "lblTo";
            this.lblTo.Text = "Bitiş:";
            //
            // dtpTo
            //
            this.dtpTo.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(82, 53);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(170, 23);
            this.dtpTo.TabStop = false;
            //
            // btnFilter
            //
            this.btnFilter.Location = new System.Drawing.Point(12, 90);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(115, 30);
            this.btnFilter.TabStop = false;
            this.btnFilter.Text = "Filtrele";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            //
            // btnShowAll
            //
            this.btnShowAll.Location = new System.Drawing.Point(137, 90);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(115, 30);
            this.btnShowAll.TabStop = false;
            this.btnShowAll.Text = "Tümünü göster";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            //
            // bottomPanel
            //
            this.bottomPanel.Controls.Add(this.lblPlayground);
            this.bottomPanel.Controls.Add(this.txtPlayground);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 474);
            this.bottomPanel.Size = new System.Drawing.Size(860, 64);
            this.bottomPanel.Name = "bottomPanel";
            //
            // lblPlayground
            //
            this.lblPlayground.AutoSize = true;
            this.lblPlayground.Location = new System.Drawing.Point(10, 6);
            this.lblPlayground.Name = "lblPlayground";
            this.lblPlayground.Text = "Deneme alanı (isteğe bağlı, buraya yazdıklarınız da kaydedilir):";
            //
            // txtPlayground
            //
            this.txtPlayground.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlayground.Location = new System.Drawing.Point(10, 27);
            this.txtPlayground.Name = "txtPlayground";
            this.txtPlayground.Size = new System.Drawing.Size(840, 23);
            //
            // statusStrip
            //
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.lblStatus});
            this.statusStrip.Name = "statusStrip";
            //
            // lblStatus
            //
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "Kaydı başlatmak için Başlat'a basın. Olaylar yalnızca bu pencere aktifken yakalanır.";
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 560);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(820, 520);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YMH219 - Key Event Logger (eğitsel)";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.rightPanel.ResumeLayout(false);
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.grpStats.ResumeLayout(false);
            this.grpStats.PerformLayout();
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlIndicator;
        private System.Windows.Forms.Label lblRecordingState;
        private System.Windows.Forms.Label lblFocus;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.CheckBox chkKeyDown;
        private System.Windows.Forms.CheckBox chkKeyUp;
        private System.Windows.Forms.CheckBox chkKeyPress;
        private System.Windows.Forms.GroupBox grpStats;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblKeyDownCount;
        private System.Windows.Forms.Label lblTopTitle;
        private System.Windows.Forms.ListBox lstTopKeys;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Label lblPlayground;
        private System.Windows.Forms.TextBox txtPlayground;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}
