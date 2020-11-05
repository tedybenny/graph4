using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaCheTakSlozhno
{
    public class MathEvaluator
    {
        public double Evaluate(String input,int x,int a,int b, int c)
        {
            if(x < 0)
            {
                input = input.Replace("-x", Convert.ToString(x));
            }
            input = input.Replace("x", Convert.ToString(x));
            if (a < 0)
            {
                input = input.Replace("-a", Convert.ToString(a));
            }
            input = input.Replace("a", Convert.ToString(a));
            if (b < 0)
            {
                input = input.Replace("-b", Convert.ToString(b));
            }
            input = input.Replace("b", Convert.ToString(b));
            if (c < 0)
            {
                input = input.Replace("-c", Convert.ToString(c));
            }
            input = input.Replace("c", Convert.ToString(c));

            Expression e = new Expression(input);
            return e.calculate();
        }
    }
}
