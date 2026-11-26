using System;
using System.Windows.Forms;

namespace KeyEventLogger.Logging
{
    /// <summary>
    /// Tek bir klavye olayının kaydı: ne zaman, hangi olay, hangi tuş.
    /// </summary>
    public class KeyEventRecord
    {
        public DateTime Timestamp { get; private set; }
        public KeyEventKind Kind { get; private set; }

        /// <summary>Tuşun okunabilir adı (ör. "A", "Enter", "Ctrl + C").</summary>
        public string KeyName { get; private set; }

        /// <summary>İstatistik için değiştirici tuşlar olmadan tuşun kendisi (ör. "C").</summary>
        public string BaseKey { get; private set; }

        public KeyEventRecord(DateTime timestamp, KeyEventKind kind, string keyName, string baseKey)
        {
            Timestamp = timestamp;
            Kind = kind;
            KeyName = keyName;
            BaseKey = baseKey;
        }

        /// <summary>KeyDown / KeyUp olayından kayıt oluşturur.</summary>
        public static KeyEventRecord FromKeyEvent(KeyEventKind kind, KeyEventArgs e)
        {
            string baseKey = KeyNameFormatter.Format(e.KeyCode);
            string name = baseKey;

            // Değiştirici tuşun kendisine basıldıysa ("Shift") başına tekrar eklenmez.
            if (!KeyNameFormatter.IsModifierKey(e.KeyCode))
            {
                string prefix = "";
                if (e.Control) prefix += "Ctrl + ";
                if (e.Alt) prefix += "Alt + ";
                if (e.Shift) prefix += "Shift + ";
                name = prefix + baseKey;
            }

            return new KeyEventRecord(DateTime.Now, kind, name, baseKey);
        }

        /// <summary>KeyPress olayından (üretilen karakter) kayıt oluşturur.</summary>
        public static KeyEventRecord FromKeyPress(KeyPressEventArgs e)
        {
            string name = KeyNameFormatter.FormatChar(e.KeyChar);
            return new KeyEventRecord(DateTime.Now, KeyEventKind.KeyPress, name, name);
        }

        /// <summary>Dosya ve ekran için tek satırlık kayıt formatı.</summary>
        public string ToLogLine()
        {
            return string.Format("[{0:yyyy-MM-dd HH:mm:ss.fff}] {1,-8} {2}", Timestamp, Kind, KeyName);
        }

        public override string ToString()
        {
            return ToLogLine();
        }
    }
}
