using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaCheTakSlozhno
{
    class CsCodeEvaler
    {
        public double EvalCode(string a)
        {
            return last = Convert.ToDouble(a);
        }

        public double last = 0;
        public const double pi = Math.PI;
        public const double e = Math.E;
        public double sin(double value) { return Math.Sin(value); }
        public double cos(double value) { return Math.Cos(value); }
        public double tan(double value) { return Math.Tan(value); }
    }
}
