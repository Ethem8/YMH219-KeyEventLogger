using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KeyEventLogger.Logging
{
    /// <summary>Kayıtları yerel bir .txt dosyasına yazar.</summary>
    public static class LogFileWriter
    {
        /// <summary>
        /// Kayıtları dosyaya yazar. Hata olursa istisnayı yukarı fırlatır;
        /// hatayı kullanıcıya göstermek arayüzün görevidir.
        /// </summary>
        public static void Save(string path, IEnumerable<KeyEventRecord> records)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Dosya yolu boş olamaz.", "path");
            }

            using (var writer = new StreamWriter(path, false, new UTF8Encoding(true)))
            {
                writer.WriteLine("# YMH219 Key Event Logger kayıtları");
                writer.WriteLine("# Oluşturulma: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                writer.WriteLine("# Not: Yalnızca uygulama penceresi aktifken yakalanan olaylar.");
                writer.WriteLine();

                int count = 0;
                foreach (var record in records)
                {
                    writer.WriteLine(record.ToLogLine());
                    count++;
                }

                writer.WriteLine();
                writer.WriteLine("# Toplam kayıt: " + count);
            }
        }
    }
}
