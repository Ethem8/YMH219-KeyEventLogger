using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyEventLogger.Logging
{
    /// <summary>
    /// Bellekteki olay kayıtlarını tutar. Kayıt açma/kapama, temizleme,
    /// filtreleme ve istatistik işlemleri burada yapılır.
    /// </summary>
    public class KeyEventLog
    {
        private readonly List<KeyEventRecord> _records = new List<KeyEventRecord>();

        public bool IsRecording { get; private set; }

        public int Count
        {
            get { return _records.Count; }
        }

        public IReadOnlyList<KeyEventRecord> Records
        {
            get { return _records; }
        }

        /// <summary>Yeni kayıt eklendiğinde tetiklenir.</summary>
        public event EventHandler<KeyEventRecord> RecordAdded;

        /// <summary>Kayıt durumu (başladı/durdu) değiştiğinde tetiklenir.</summary>
        public event EventHandler RecordingChanged;

        /// <summary>Kayıtlar temizlendiğinde tetiklenir.</summary>
        public event EventHandler Cleared;

        public void Start()
        {
            if (IsRecording) return;
            IsRecording = true;
            Raise(RecordingChanged);
        }

        public void Stop()
        {
            if (!IsRecording) return;
            IsRecording = false;
            Raise(RecordingChanged);
        }

        /// <summary>Kayıt açıksa olayı listeye ekler. Kayıt kapalıysa hiçbir şey yapmaz.</summary>
        public bool Add(KeyEventRecord record)
        {
            if (!IsRecording || record == null)
            {
                return false;
            }
            _records.Add(record);
            var handler = RecordAdded;
            if (handler != null) handler(this, record);
            return true;
        }

        public void Clear()
        {
            _records.Clear();
            Raise(Cleared);
        }

        /// <summary>Verilen zaman aralığındaki (uçlar dahil) kayıtları döndürür.</summary>
        public List<KeyEventRecord> Filter(DateTime from, DateTime to)
        {
            if (from > to)
            {
                var tmp = from;
                from = to;
                to = tmp;
            }
            return _records.Where(r => r.Timestamp >= from && r.Timestamp <= to).ToList();
        }

        /// <summary>Sadece KeyDown olaylarını sayarak en sık basılan tuşları döndürür.</summary>
        public List<KeyValuePair<string, int>> TopKeys(int count)
        {
            return _records
                .Where(r => r.Kind == KeyEventKind.KeyDown)
                .GroupBy(r => r.BaseKey)
                .Select(g => new KeyValuePair<string, int>(g.Key, g.Count()))
                .OrderByDescending(p => p.Value)
                .ThenBy(p => p.Key)
                .Take(count)
                .ToList();
        }

        /// <summary>Toplam tuş basımı (KeyDown) sayısı.</summary>
        public int KeyDownCount
        {
            get { return _records.Count(r => r.Kind == KeyEventKind.KeyDown); }
        }

        private void Raise(EventHandler handler)
        {
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}
