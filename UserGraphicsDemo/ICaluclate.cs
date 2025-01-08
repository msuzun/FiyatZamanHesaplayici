using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserGraphicsDemo
{
    public interface ICalculate
    {
        decimal Fiyat { get; set; }
        DateTime Zaman { get; set; }
        decimal HesaplaFiyat();
        double HesaplaZaman();
        decimal HesaplaOrtalamaFiyatArtisi();
        
    }
}
