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
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input) && DateTime.TryParseExact(input,"yyyy-MM-dd",null, System.Globalization.DateTimeStyles.None, out DateTime validDate))
            {
                return validDate;
            }
            Console.WriteLine("Geçersiz tarih formatı. Lütfen geçerli bir tarih girin:");
        }
    }
    public static decimal FiyatGirisiKontrolEt(this string mesaj)
    {
        while (true)
        {
            Console.WriteLine(mesaj);
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input) && decimal.TryParse(input, out decimal fiyat) && fiyat > 0)
            {
                return fiyat;
            }
            Console.WriteLine("Hatalı giriş! Fiyat sıfırdan büyük olmalıdır. Lütfen tekrar deneyin.");
        }
    }
}
