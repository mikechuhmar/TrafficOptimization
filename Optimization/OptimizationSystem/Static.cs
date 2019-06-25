using System.Collections.Generic;
using System.Linq;

namespace OptimizationSystem
{
    public static class Static
    {
        //Веса слагаемых
        public static int alpha = 5, beta = 3, gamma = 3, delta = 2, epsilon = 1;
        //Количество TB
        public static int TB_Count
        {
            get
            {                
                return Form2.TPe.Count(x => x.Text.Contains("TB"));
            }
        }
        //Количество LB
        public static int LB_Count
        {
            get
            {
                return Form2.TPe.Count(x => x.Text.Contains("LB"));
            }
        }
        //Данные, полученные во время имитационного моделирования
        public static List<Data> dataList;
        //Данные, полученные во время предыдущего имитационного моделирования
        public static List<Data> prev_dataList = null;
    }
}
