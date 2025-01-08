using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserGraphicsDemo
{
    public class Point : ICalculate
    {
        private decimal _fiyat;
        public virtual decimal Fiyat
        {
            get => _fiyat;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fiyat sıfır ve sıfırdan küçük olamaz. Lütfen tutarı güncelleyiniz.");
                }
                _fiyat = value;
            }
        }
        public virtual DateTime Zaman { get; set; }

        public virtual decimal HesaplaFiyat()
        {
            return 0;
        }
        public virtual double HesaplaZaman()
        {
            return 0;
        }
        public virtual decimal HesaplaOrtalamaFiyatArtisi()
        {
            return 0;
        }
    }
}
