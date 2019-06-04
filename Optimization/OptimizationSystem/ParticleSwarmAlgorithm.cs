using System;
using System.Collections.Generic;
using System.Linq;

namespace OptimizationSystem
{
    class SwarmParticlesAlgorithm: Method
    {
        int amParticles;
        int amSteps;
        double a1, a2;
        Vector groupBest;
        List<Vector> particlesBest;
        List<Vector> points;
        List<Vector> speeds;
        //Конструктор
        public SwarmParticlesAlgorithm(int amParticles, int amParams, int amSteps, double a1, double a2, Function func, GenVectorFunction genVectorFunction, Vector max) : base(amParams, func, genVectorFunction, max)
        {
            this.amParticles = amParticles;
            this.amSteps = amSteps;
            this.a1 = a1;
            this.a2 = a2;
        }        
        //Создание стартовых положений и стартовых скоростей
        void CreateStartPoints()
        {
            particlesBest = new List<Vector>(amParticles);
            points = new List<Vector>(amParticles);
            speeds = new List<Vector>(amParticles);
            Random rnd = new Random();
            for (int i = 0; i < amParticles; i++)
            {
                Vector point = new Vector(genVectorFunction(rand));
                points.Add(point);
                speeds.Add(new Vector(amParams));
                
                particlesBest.Add(point);
                
            }
            var query = points.OrderBy(x => func(x));
            groupBest = new Vector(query.First());
        }
        //Новые положения и новые скорости
        void ChangeNewPoints()
        {
            Random rnd = new Random();
            for (int i = 0; i < amParticles; i++)
            {                
                for (int j = 0; j < amParams; j++)
                    speeds[i][j] = speeds[i][j] + (int)(a1 * rnd.Next(0, 10) * (particlesBest[i][j] - points[i][j]))/10 + (int)(a2 * rnd.Next(0, 10) * (groupBest[j] - points[i][j]))/10;
                for (int j = 0; j < amParams; j++)
                    points[i][j] = Math.Abs(points[i][j] + speeds[i][j]);                
                if (func(points[i]) < func(particlesBest[i]))
                    particlesBest[i] = new Vector(points[i]);
            }
            groupBest = new Vector(particlesBest.OrderBy(x => func(x)).First());           

        }
        //Результат
        public Vector result()
        {
            int i;
            CreateStartPoints();            
            for (i = 0; i < amSteps; i++)
            {
                Vector prevGroupBest = new Vector(groupBest);
                ChangeNewPoints();                
            }
            Vector resultAlgorith = groupBest;
            return resultAlgorith;
        }
    }
}
