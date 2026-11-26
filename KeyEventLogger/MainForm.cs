using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using KeyEventLogger.Logging;

namespace KeyEventLogger
{
    /// <summary>
    /// Eğitsel tuş olayı kaydedici. Olaylar yalnızca bu form aktifken, formun kendi
    /// olay mekanizması (KeyPreview, ProcessCmdKey) ile yakalanır. Global hook,
    /// arka planda çalışma veya ağ üzerinden gönderme yoktur.
    /// </summary>
    public partial class MainForm : Form
    {
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int TopKeyCount = 5;

        private readonly KeyEventLog _log = new KeyEventLog();

        // Filtre uygulanmışken liste sadece filtre sonucunu gösterir.
        private bool _filterActive;

        public MainForm()
        {
            InitializeComponent();

            _log.RecordAdded += Log_RecordAdded;
            _log.RecordingChanged += Log_RecordingChanged;
            _log.Cleared += Log_Cleared;

            dtpFrom.Value = DateTime.Now.AddMinutes(-10);
            dtpTo.Value = DateTime.Now.AddHours(1);

            UpdateRecordingIndicator();
            UpdateStatistics();
        }

        // ---------- Klavye olaylarının yakalanması ----------

        /// <summary>
        /// KeyDown olayını form düzeyinde yakalar. Normal KeyDown olayı ok tuşları,
        /// Tab gibi "dialog" tuşlarında butonlar odaktayken tetiklenmediği için
        /// ProcessCmdKey kullanılır. Tuş işlenmeye normal şekilde devam eder.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((msg.Msg == WM_KEYDOWN || msg.Msg == WM_SYSKEYDOWN) && chkKeyDown.Checked)
            {
                _log.Add(KeyEventRecord.FromKeyEvent(KeyEventKind.KeyDown, new KeyEventArgs(keyData)));
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (chkKeyUp.Checked)
            {
                _log.Add(KeyEventRecord.FromKeyEvent(KeyEventKind.KeyUp, e));
            }
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (chkKeyPress.Checked)
            {
                _log.Add(KeyEventRecord.FromKeyPress(e));
            }
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            lblFocus.Text = "Pencere odakta, olaylar yakalanabilir";
            lblFocus.ForeColor = Color.DarkGreen;
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            // Pencere odağı kaybedince hiçbir tuş yakalanmaz. Bunu kullanıcıya açıkça gösteriyoruz.
            lblFocus.Text = "Pencere odakta değil, olay yakalanmıyor";
            lblFocus.ForeColor = Color.DimGray;
        }

        // ---------- Butonlar ----------

        private void btnStart_Click(object sender, EventArgs e)
        {
            _log.Start();
            txtPlayground.Focus();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _log.Stop();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _log.Clear();
            txtPlayground.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_log.Count == 0)
            {
                MessageBox.Show(this, "Kaydedilecek olay yok.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var dialog = new SaveFileDialog())
            {
                dialog.Title = "Kayıtları kaydet";
                dialog.Filter = "Metin dosyası (*.txt)|*.txt";
                dialog.FileName = "tus-kayitlari-" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".txt";

                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    // Filtre açıksa sadece ekranda görünen kayıtlar kaydedilir.
                    IEnumerable<KeyEventRecord> records = _filterActive ? GetFilteredRecords() : (IEnumerable<KeyEventRecord>)_log.Records;
                    LogFileWriter.Save(dialog.FileName, records);
                    lblStatus.Text = "Kaydedildi: " + dialog.FileName;
                }
                catch (IOException ex)
                {
                    ShowError("Dosya yazılamadı: " + ex.Message);
                }
                catch (UnauthorizedAccessException ex)
                {
                    ShowError("Bu konuma yazma izniniz yok: " + ex.Message);
                }
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            var filtered = GetFilteredRecords();
            _filterActive = true;
            lstLog.BeginUpdate();
            lstLog.Items.Clear();
            foreach (var record in filtered)
            {
                lstLog.Items.Add(record.ToLogLine());
            }
            lstLog.EndUpdate();
            lblStatus.Text = string.Format("Filtre: {0:HH:mm:ss} - {1:HH:mm:ss} arası {2} kayıt gösteriliyor.",
                dtpFrom.Value, dtpTo.Value, filtered.Count);
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            _filterActive = false;
            ReloadList();
            lblStatus.Text = "Tüm kayıtlar gösteriliyor.";
        }

        // ---------- Kayıt modelinden gelen olaylar ----------

        private void Log_RecordAdded(object sender, KeyEventRecord record)
        {
            if (!_filterActive)
            {
                lstLog.Items.Add(record.ToLogLine());
                lstLog.TopIndex = Math.Max(0, lstLog.Items.Count - 1);
            }
            UpdateStatistics();
        }

        private void Log_RecordingChanged(object sender, EventArgs e)
        {
            UpdateRecordingIndicator();
            lblStatus.Text = _log.IsRecording
                ? "Kayıt başladı. Bu pencere aktifken basılan tuşlar listeleniyor."
                : "Kayıt durduruldu.";
        }

        private void Log_Cleared(object sender, EventArgs e)
        {
            _filterActive = false;
            lstLog.Items.Clear();
            UpdateStatistics();
            lblStatus.Text = "Kayıtlar temizlendi.";
        }

        // ---------- Yardımcılar ----------

        private List<KeyEventRecord> GetFilteredRecords()
        {
            // Bitiş saniyesinin tamamı dahil olsun.
            DateTime to = dtpTo.Value.AddMilliseconds(999);
            return _log.Filter(dtpFrom.Value, to);
        }

        private void ReloadList()
        {
            lstLog.BeginUpdate();
            lstLog.Items.Clear();
            foreach (var record in _log.Records)
            {
                lstLog.Items.Add(record.ToLogLine());
            }
            lstLog.EndUpdate();
            if (lstLog.Items.Count > 0)
            {
                lstLog.TopIndex = lstLog.Items.Count - 1;
            }
        }

        private void UpdateRecordingIndicator()
        {
            bool on = _log.IsRecording;
            pnlIndicator.BackColor = on ? Color.Red : Color.Gray;
            lblRecordingState.Text = on ? "KAYIT AÇIK" : "KAYIT KAPALI";
            lblRecordingState.ForeColor = on ? Color.Red : Color.DimGray;
            btnStart.Enabled = !on;
            btnStop.Enabled = on;
        }

        private void UpdateStatistics()
        {
            lblTotal.Text = "Toplam kayıt: " + _log.Count;
            lblKeyDownCount.Text = "Tuş basımı (KeyDown): " + _log.KeyDownCount;

            lstTopKeys.BeginUpdate();
            lstTopKeys.Items.Clear();
            int rank = 1;
            foreach (var pair in _log.TopKeys(TopKeyCount))
            {
                lstTopKeys.Items.Add(string.Format("{0}. {1}  ({2} kez)", rank++, pair.Key, pair.Value));
            }
            lstTopKeys.EndUpdate();
        }

        private void ShowError(string message)
        {
            MessageBox.Show(this, message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
