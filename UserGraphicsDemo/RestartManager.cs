using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserGraphicsDemo
{
    public class RestartManager
    {
        private bool yenidenBaslat;
        public RestartManager()
        {
            yenidenBaslat = true;
        }
        public bool ProgramiBaslat()
        {
            return yenidenBaslat;
        }
        public void ProgramiDurdur()
        {
            yenidenBaslat = false;
        }
        public void BaslatilmaTrigger()
        {
            yenidenBaslat = true;
        }
    }
}
