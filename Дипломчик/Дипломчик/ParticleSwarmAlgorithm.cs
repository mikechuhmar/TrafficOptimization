using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дипломчик
{
    public class SwarmParticlesAlgorithm
    {
        int amParticles;
        int amCoords;
        int amSteps;
        double a1, a2;
        Function func;
        Vector groupBest;
        List<Vector> particlesBest;
        List<Vector> points;
        List<Vector> speeds;
        public SwarmParticlesAlgorithm(int amParticles, int amCoords, int amSteps, double a1, double a2, Function func)
        {
            this.amParticles = amParticles;
            this.amCoords = amCoords;
            this.amSteps = amSteps;
            this.a1 = a1;
            this.a2 = a2;
            this.func = func;
        }
        void CreateStartPoints()
        {
            particlesBest = new List<Vector>(amParticles);
            points = new List<Vector>(amParticles);
            speeds = new List<Vector>(amParticles);
            Random rnd = new Random();
            for (int i = 0; i < amParticles; i++)
            {
                points.Add(new Vector());
                speeds.Add(new Vector());
                particlesBest.Add(new Vector());
                for (int j = 0; j < amCoords; j++)
                {
                    double value = rnd.Next(-100, 100);
                    points[i].Add(value);
                    speeds[i].Add(value);
                    particlesBest[i].Add(value);
                }
            }
            var query = points.OrderBy(x => func(x));
            groupBest = new Vector(query.First());

        }
        void ChangeNewPoints()
        {
            Random rnd = new Random();
            for (int i = 0; i < amParticles; i++)
            {
                for (int j = 0; j < amCoords; j++)
                {
                    speeds[i][j] = speeds[i][j] + a1 * rnd.NextDouble() * (particlesBest[i][j] - points[i][j]) + a2 * rnd.NextDouble() * (groupBest[j] - points[i][j]);
                }
                points[i] = points[i] + speeds[i];
                if (func(points[i]) < func(particlesBest[i]))
                    particlesBest[i] = new Vector(points[i]);
            }
            groupBest = new Vector(particlesBest.OrderBy(x => func(x)).First());
        }
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
