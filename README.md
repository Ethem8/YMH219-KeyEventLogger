# YMH219 - Key Event Logger (Eğitsel)

Windows Forms'ta klavye olaylarının (`KeyDown`, `KeyUp`, `KeyPress`) nasıl yakalandığını ve işlendiğini gösteren eğitsel bir uygulama. Basılan tuşlar zaman bilgisiyle listelenir. İstenirse yerel bir `.txt` dosyasına kaydedilebilir.

> YMH 219 Nesne Tabanlı Programlama dersi, Ek Uygulama Ödevi 2

## Kapsam ve güvenlik sınırı

Bu uygulama **gerçek bir sistem keylogger'ı değildir.**

- Olaylar **yalnızca uygulamanın kendi penceresi odaktayken** formun olay mekanizmasıyla (`KeyPreview`, `ProcessCmdKey`) yakalanır.
- Global keyboard hook, Win32 `SetWindowsHookEx`, arka planda veya gizli çalışma, başlangıçta otomatik açılma **yoktur.**
- Başka uygulamalardan veri toplanmaz. Kayıtlar ağ üzerinden gönderilmez, sadece kullanıcı isterse yerel dosyaya yazılır.
- Pencere odağı kaybettiğinde arayüz bunu açıkça gösterir ("Pencere odakta değil, olay yakalanmıyor").

## Kullanılan teknolojiler

- C# / .NET 8 (`net8.0-windows`)
- Windows Forms (`ListBox`, `DateTimePicker`, `SaveFileDialog`, `StatusStrip`)
- `System.IO.StreamWriter` ile dosya yazma, LINQ ile istatistik ve filtre
- Harici NuGet paketi yok

## Kurulum ve çalıştırma

1. `git clone https://github.com/Ethem8/YMH219-KeyEventLogger.git`
2. `YMH219-KeyEventLogger.sln` dosyasını Visual Studio 2022 ile açın.
3. **F5** ile çalıştırın.

Komut satırından: `dotnet run --project KeyEventLogger`

## Özellikler

- Pencere aktifken basılan tuşun adı ve milisaniye hassasiyetinde zamanı `ListBox` üzerinde gösterilir (ör. `[2026-11-26 17:45:03.512] KeyDown  Ctrl + C`).
- **Başlat / Durdur** butonlarıyla kayıt kontrol edilir. Kırmızı/gri gösterge ve "KAYIT AÇIK / KAPALI" yazısı durumu belirtir.
- **Temizle** ekrandaki ve bellekteki kayıtları siler.
- **Kaydet (.txt)** kayıtları seçilen bir metin dosyasına UTF-8 olarak yazar. Dosya hataları kullanıcıya mesajla bildirilir.
- Hangi olayların (`KeyDown`, `KeyUp`, `KeyPress`) kaydedileceği seçilebilir.
- *(İsteğe bağlı)* Toplam kayıt, toplam tuş basımı ve **en sık basılan 5 tuş** istatistiği gösterilir.
- *(İsteğe bağlı)* Kayıtlar **tarih/saat aralığına göre filtrelenebilir.** Filtre açıkken "Kaydet" sadece filtrelenmiş kayıtları yazar.

## Sınıf yapısı

| Sınıf | Görevi |
|---|---|
| `Logging/KeyEventRecord` | Tek bir olay kaydı (zaman, tür, tuş adı) ve satır formatı |
| `Logging/KeyEventKind` | `KeyDown`, `KeyUp`, `KeyPress` |
| `Logging/KeyNameFormatter` | `Keys` değerlerini okunabilir adlara çevirir (`D5` → `5`, `Return` → `Enter`) |
| `Logging/KeyEventLog` | Kayıt listesi, başlat/durdur, temizle, filtre, istatistik ve olaylar (`RecordAdded`, `RecordingChanged`, `Cleared`) |
| `Logging/LogFileWriter` | Kayıtları `StreamWriter` ile `.txt` dosyasına yazar |
| `MainForm` | Klavye olaylarını yakalar, arayüzü günceller |

`KeyDown` için `ProcessCmdKey` kullanıldı, çünkü normal `KeyDown` olayı bir buton odaktayken ok tuşları ve Tab gibi tuşlarda tetiklenmez. `KeyUp` ve `KeyPress` için formun `KeyPreview = true` özelliği kullanıldı.

## Ekran görüntüleri

| Kayıt sırasında | Filtre ve istatistik |
|---|---|
| ![Kayıt](screenshots/kayit.png) | ![İstatistik](screenshots/istatistik.png) |

## Bilinen sınırlamalar / geliştirme notları

- Kayıtlar bellekte tutulur. Uygulama kapanınca, kaydedilmemiş olaylar kaybolur.
- Windows'un kendine ayırdığı bazı tuş kombinasyonları (ör. `Alt+Tab`, `Win`) pencereye ulaşmadığı için listelenmez. Bu, kapsam gereği beklenen bir durumdur.

## Öğrenci

**İbrahim Ethem Erkan** · 240541010
