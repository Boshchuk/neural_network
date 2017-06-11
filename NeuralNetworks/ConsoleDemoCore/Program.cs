using System;
using System.Collections.Generic;
using Neurons;

namespace ConsoleDemoCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello NN World!");

            var sample = new List<List<int>>
            {
                new List<int> {-1,-1 },
                new List<int> {-1, 1 },
                new List<int> { 1,-1 },
                new List<int> { 1, 1 },
            };

            var targets = new List<int>
            {
                -1,
                1,
                1,
                1
            };

            var neuron = new HebbNeuron();

            Console.WriteLine("test 1");
            neuron.Test(sample);

            neuron.Train(sample, targets);
            Console.WriteLine("test 2");
            neuron.Test(sample);
        }
    }
}