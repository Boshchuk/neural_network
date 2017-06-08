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
        public void Test(IEnumerable<int> samples)
        {
            var sampleA = samples.ToArray();
            int y = 0;
            for (int i = 0; i < sampleA.Length; i++)
            {
                var weightedSum = Weight1 * sampleA[0] +
                                  Weight2 * sampleA[1] +
                                  Threshold;
                if (weightedSum > 0)
                {
                    y = 1;
                }
                else
                {
                    y = -1;
                }
            }
            System.Console.WriteLine(string.Format("({0}, {1}): {2}", sampleA[0], sampleA[1]), y);
        }
    }
}