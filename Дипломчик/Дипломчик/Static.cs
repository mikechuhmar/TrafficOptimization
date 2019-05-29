using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дипломчик
{
    public static class Static
    {
        public static double alpha = 5, beta = 3, gamma = 3, delta = 2, epsilon = 1;
        public static int TB_Count
        {
            get
            {
                return Form2.TPe.Count(x => x.Text.Contains("TB"));
            }
        }
        public static int LB_Count
        {
            get
            {
                return Form2.TPe.Count(x => x.Text.Contains("LB"));
            }
        }
        public static List<Data> dataList;
        public static Data currentData;
        public static List<Data> prev_dataList = null;
    }
}
