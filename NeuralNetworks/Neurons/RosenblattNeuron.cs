using System;
using System.Collections.Generic;

namespace Neurons
{
    // Logical and
    // x1   x2   AND
    // -1   -1   -1
    // -1    1   -1
    //  1   -1   -1
    //  1    1    1

    public class RosenblattNeuron
    {
        public double Weight1 { get; set; }
        public double Weight2 { get; set; }
        public double Threshold { get; set; }

        public double Rate { get; set; }


        public RosenblattNeuron(double rate)
        {
            Weight1 = new Random().NextDouble();
            Weight2 = new Random().NextDouble();
            Threshold = new Random().NextDouble();
            Rate = rate;
        }

        public double Activate(List<double> sample)
        {
            var weightedSum = Weight1 * sample[0] +
                              Weight2 * sample[1] +
                              Threshold;

            var y = ThresActivateFunction(weightedSum);
            return y;
        }

        public double ThresActivateFunction(double x)
        {
            return x < 0 ? -1 : 1;
        }

        public void Test(List<List<double>> samples)
        {
            foreach (var sample in samples)
            {
                var weightedSum = Weight1 * sample[0] +
                                  Weight2 * sample[1] +
                                  Threshold;
                var y = ThresActivateFunction(weightedSum);

                Console.WriteLine(string.Format("({0}, {1}): {2}", sample[0], sample[1], y));

            }
        }

        public int Train(List<List<double>> samples, List<double> targets)
        {
            var isFinish = false;

            var epochsCount = 0;

            while (!isFinish)
            {
                isFinish = true;
                for (var index = 0; index < samples.Count; index++)
                {
                    
                    var y = Activate(samples[index]);
                    // TODO fix with tolerance
                    if (y != targets[index])
                    {
                        isFinish = false;
                        Weight1 += Rate * samples[index][0] * targets[index];
                        Weight2 += Rate * samples[index][1] * targets[index];
                        Threshold += Rate * targets[index];
                    }
                }
                epochsCount++;
            }

            return epochsCount;
        }
    }
}
