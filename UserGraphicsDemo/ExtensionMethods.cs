using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserGraphicsDemo;

public static class ExtensionMethods
{
    public static DateTime GirilenTarihiKontrolEt(this string mesaj)
    {
        while (true)
        {
            Console.WriteLine(mesaj);
            if (DateTime.TryParse(Console.ReadLine(), out DateTime validDecimal))
            {
                return validDecimal;
            }
            Console.WriteLine("Geçersiz sayı formatı. Lütfen geçerli bir tarih girin:");
        }
    }
    public static decimal FiyatGirisiKontrolEt(this string mesaj)
    {
        while (true)
        {
            Console.WriteLine(mesaj);
            if (decimal.TryParse(Console.ReadLine(), out decimal fiyat) && fiyat > 0)
            {
                return fiyat;
            }
            Console.WriteLine("Hatalı giriş! Fiyat sıfırdan büyük olmalıdır. Lütfen tekrar deneyin.");
        }
    }
}
