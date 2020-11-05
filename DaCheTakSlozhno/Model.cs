using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaCheTakSlozhno
{

    class Model
    {
        MathEvaluator math = new MathEvaluator();
        public string Xmin
        {
            get;
            set;
        }
        public string Xmax
        {
            get;
            set;
        }
        public string userFormula
        {
            get;
            set;
        }
        public string A
        {
            get;
            set;
        }
        public string B
        {
            get;
            set;
        }
        public string C
        {
            get;
            set;
        }
        public double PointY(int a)
        {
            double result = math.Evaluate(userFormula,a,Convert.ToInt32(A), Convert.ToInt32(B), Convert.ToInt32(C));
            return result;
        }

    }
}
