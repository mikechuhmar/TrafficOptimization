﻿using System;

namespace OptimizationSystem
{
    class Method
    {
        protected Function func;
        protected GenVectorFunction genVectorFunction;
        protected Random rand = new Random();
        protected Vector max;
        protected int amParams;
       
        //Конструктор
        public Method(int amParams, Function func, GenVectorFunction genVectorFunction, Vector max)
        {
            this.amParams = amParams;
            this.func = func;
            this.genVectorFunction = genVectorFunction;
            this.max = max;
        }
        
    }
}
