using UserGraphicsDemo;


RestartManager restartManager = new RestartManager();
while (restartManager.ProgramiBaslat())
{
    try
    {
        // Kullanıcıdan veri al
        decimal baslangicFiyati = ExtensionMethods.FiyatGirisiKontrolEt("Başlangıç Noktası Tutar'ini Girin:");
        DateTime baslangicTarihi = ExtensionMethods.GirilenTarihiKontrolEt("Başlangıç Noktası Tarihini Girin (yyyy-MM-dd):");

        decimal bitisFiyati = ExtensionMethods.FiyatGirisiKontrolEt("Bitiş Noktası Tutar'ini Girin:");
        DateTime bitisTarihi = ExtensionMethods.GirilenTarihiKontrolEt("Bitiş Noktası Tarihini Girin (yyyy-MM-dd):");

        // baslangicNoktasi ve bitisNoktasi  nesnelerini oluştur
        Point baslangicNoktasi = new Point { Fiyat = baslangicFiyati, Zaman = baslangicTarihi };
        Point bitisNoktasi = new Point { Fiyat = bitisFiyati, Zaman = bitisTarihi };

        // info nesnesini oluştur
        if (!(new Line(baslangicNoktasi, bitisNoktasi) is ICalculate info))
        {
            throw new InvalidCastException("Line nesnesi ICalculate arayüzüne dönüştürülemedi.");
        }

        // Hesaplamaları gerçekleştir
        Console.WriteLine($"Fiyat Değişimi: {info.HesaplaFiyat():F2}");
        Console.WriteLine($"Zaman Farkı (gün): {info.HesaplaZaman():F0}");

        decimal ortalamaDegisim = info.HesaplaOrtalamaFiyatArtisi();
        Console.WriteLine($"Günlük Ortalama Fiyat Değişimi: {ortalamaDegisim:F2}");

        // Kullanıcıdan ara tarih al
        DateTime araTarih = ExtensionMethods.GirilenTarihiKontrolEt("Ara tarih girin (yyyy-MM-dd):");

        // Ara tarihteki fiyatı hesapla
        decimal araTarihtekiFiyat = ((Line)info).AraTarihtekiFiyatiHesapla(araTarih);
        Console.WriteLine($"Ara tarihteki fiyat: {araTarihtekiFiyat:F2}");

        // İki tarih arasında ortalama fiyatı hesapla
        DateTime araTarihBaslangic = ExtensionMethods.GirilenTarihiKontrolEt("Ara Başlangıç Tarihini Girin (yyyy-MM-dd):");
        DateTime araTarihBitis = ExtensionMethods.GirilenTarihiKontrolEt("Ara Bitiş Tarihini Girin (yyyy-MM-dd):");

        decimal ortalamaFiyat = ((Line)info).AraTarihtekiFiyatiHesapla(araTarihBaslangic,araTarihBitis);
        Console.WriteLine($"İki tarih arasındaki ortalama fiyat: {ortalamaFiyat:F2}");

        // Kullanıcıya devam edip etmeyeceğini sor
        Console.WriteLine("Program başarıyla tamamlandı. Devam etmek ister misiniz? (Evet/Hayır)");
        string cevap = Console.ReadLine()?.Trim().ToLower();

        if (string.IsNullOrWhiteSpace(cevap))
        {
            throw new NullReferenceException("Cevap boş olamaz. Lütfen 'Evet' veya 'Hayır' yazın.");
        }

        if (cevap?.ToLower() == "hayır" || cevap?.ToLower() == "h")
        {
            restartManager.ProgramiDurdur();
        }
        else if (cevap?.ToLower() == "evet" || cevap?.ToLower() == "e")
        {
            restartManager.BaslatilmaTrigger();
        }
        else
        {
            Console.WriteLine("Geçersiz cevap. Program sonlandırılıyor.");
            restartManager.ProgramiDurdur();
        }

    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
        restartManager.BaslatilmaTrigger();
    }
    catch (FormatException ex)
    {
        Console.WriteLine($"Geçersiz giriş formatı. Lütfen tekrar deneyin. Hata açıklaması {ex}");
        restartManager.BaslatilmaTrigger();
    }
    catch (OverflowException ex)
    {
        Console.WriteLine($"Aşırı büyük veya küçük değer hatası. Lütfen geçerli bir değer girin. Hata açıklaması: {ex}");
        restartManager.BaslatilmaTrigger();
    }
    catch (NullReferenceException ex)
    {
        Console.WriteLine($"Boş giriş hatası: {ex.Message}");
        restartManager.BaslatilmaTrigger();
    }
    catch (InvalidCastException ex)
    {
        Console.WriteLine($"Tür dönüşümü hatası: {ex.Message}");
        restartManager.BaslatilmaTrigger();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Bir hata oluştu: {ex.Message}");
    }
}

