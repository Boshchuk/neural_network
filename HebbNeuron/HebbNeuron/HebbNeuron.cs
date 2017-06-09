using System.Collections.Generic;
using System.Linq;

namespace HebbNeuron
{
    public class HebbNeuron
    {
        public int Weight1 { get; set; }

        public int Weight2 { get; set; }

        public int Threshold { get; set; }

        /// <summary>
        /// Demostrate work of Neoron
        /// </summary>
        /// <param name="samples">Sample data</param>
        public void Test(List<List<int>> samples)
        {
            int y = 0;
            for (var i = 0; i < samples.Count; i++)
            {
                var weightedSum = Weight1 * samples[i][0] +
                                  Weight2 * samples[i][1] +
                                  Threshold;
                if (weightedSum > 0)
                {
                    y = 1;
                }
                else
                {
                    y = -1;
                }
                var str = string.Format("({0}, {1}): {2}", samples[i][0], samples[i][1], y);
                System.Console.WriteLine(str);
            }
        }

        public void Train(List<List<int>> samples, IList<int> targets)
        {
            var length = samples.Count;
            for (var i = 0; i < length; i++)
            {
                Weight1 += samples[i][0] * targets[i];
                Weight1 += samples[i][1] * targets[i];
                Threshold += targets[i];
            }
        }
    }

  
}