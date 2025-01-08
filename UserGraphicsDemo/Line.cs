using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UserGraphicsDemo;

public class Line : Point
{
    public Point _baslangicNoktasi{ get; set; }
    public Point _bitisNoktasi { get; set; }
    public Line(Point baslangicNoktasi, Point bitisNoktasi)
    {
        if (baslangicNoktasi == null)
            throw new ArgumentNullException(nameof(baslangicNoktasi), "Başlangıç noktası null olamaz.");
        if (bitisNoktasi == null)
            throw new ArgumentNullException(nameof(bitisNoktasi), "Bitiş noktası null olamaz.");
        if (bitisNoktasi.Zaman < baslangicNoktasi.Zaman)
            throw new ArgumentException("Bitiş zamanı, başlangıç zamanından küçük olamaz. Lütfen tarihleri kontrol edin.");
        _baslangicNoktasi = baslangicNoktasi;
        _bitisNoktasi = bitisNoktasi;
    }
    public override decimal HesaplaFiyat() => _bitisNoktasi.Fiyat - _baslangicNoktasi.Fiyat;

    public override double HesaplaZaman() => (_bitisNoktasi.Zaman - _baslangicNoktasi.Zaman).TotalDays;

    // Günlük ortalama fiyat değişimini hesaplayan metod
    public override decimal HesaplaOrtalamaFiyatArtisi()
    {
        double zamanFarki = HesaplaZaman();

        if (zamanFarki == 0)
        {
            throw new InvalidOperationException("Zaman farkı sıfır olamaz.");
        }

        decimal fiyatDegisimi = HesaplaFiyat();
        return fiyatDegisimi / (decimal)zamanFarki;
    }
    // Ara tarihteki fiyatı hesaplayan metod
    public decimal AraTarihtekiFiyatiHesapla(DateTime araTarih)
    {
        if (araTarih < _baslangicNoktasi.Zaman)
        {
            Console.WriteLine("Ara tarih başlangıç tarihinden önce. Hesaplama başlangıç tarihine göre yapılacak.");
            araTarih = _baslangicNoktasi.Zaman;
        }
        else if (araTarih > _bitisNoktasi.Zaman)
        {
            Console.WriteLine("Ara tarih bitiş tarihinden sonra. Hesaplama bitiş tarihine göre yapılacak.");
            araTarih = _bitisNoktasi.Zaman;
        }

        decimal toplamGun = (decimal)HesaplaZaman();
        decimal baslangictanSonrakiGun = (decimal)(araTarih - _baslangicNoktasi.Zaman).TotalDays;

        decimal toplamFiyatDegisimi = (decimal)HesaplaFiyat();
        decimal araTarihtekiFiyatDegisimi = (baslangictanSonrakiGun / toplamGun) * toplamFiyatDegisimi;

        return _baslangicNoktasi.Fiyat + araTarihtekiFiyatDegisimi;
    }
    // İki tarih arasındaki ortalama fiyatı hesaplayan overload metod
    public decimal AraTarihtekiFiyatiHesapla(DateTime araTarihBaslangic, DateTime araTarihBitis)
    {
        // Tarih doğrulamaları
        if (araTarihBaslangic > araTarihBitis)
        {
            throw new ArgumentException("Başlangıç ara tarihi, bitiş ara tarihinden büyük olamaz.");
        }

        if (araTarihBaslangic < _baslangicNoktasi.Zaman)
        {
            Console.WriteLine("Başlangıç ara tarihi, başlangıç tarihinden önce. Başlangıç tarihine göre hesaplanacak.");
            araTarihBaslangic = _baslangicNoktasi.Zaman;
        }

        if (araTarihBitis > _bitisNoktasi.Zaman)
        {
            Console.WriteLine("Bitiş ara tarihi, bitiş tarihinden sonra. Bitiş tarihine göre hesaplanacak.");
            araTarihBitis = _bitisNoktasi.Zaman;
        }

        // Gün farkı hesaplama
        double toplamGun = (double)HesaplaZaman();
        double baslangictanSonrakiGunBaslangic = (double)(araTarihBaslangic - _baslangicNoktasi.Zaman).TotalDays;
        double baslangictanSonrakiGunBitis = (double)(araTarihBitis - _baslangicNoktasi.Zaman).TotalDays;

        // İlgili tarih aralığındaki fiyat değişimlerini hesapla
        decimal toplamFiyatDegisimi = (decimal)HesaplaFiyat();
        decimal baslangictakiFiyat = _baslangicNoktasi.Fiyat + (decimal)(baslangictanSonrakiGunBaslangic / toplamGun) * toplamFiyatDegisimi;
        decimal bitistekiFiyat = _baslangicNoktasi.Fiyat + (decimal)(baslangictanSonrakiGunBitis / toplamGun) * toplamFiyatDegisimi;

        // Ortalama fiyat hesaplama
        return (baslangictakiFiyat + bitistekiFiyat) / 2;
    }
}
