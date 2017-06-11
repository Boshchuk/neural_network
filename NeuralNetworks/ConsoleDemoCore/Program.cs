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

            TestRosenblattNeuron();
        }

        static void TestHebbNeuron()
        {
            var sample = new List<List<int>>
            {
                new List<int> {-1,-1 },
                new List<int> {-1, 1 },
                new List<int> { 1,-1 },
                new List<int> { 1, 1 },
            };

            var targets = new List<int> { -1, 1, 1, 1 };

            var neuron = new HebbNeuron();

            Console.WriteLine("test 1");
            neuron.Test(sample);

            neuron.Train(sample, targets);
            Console.WriteLine("test 2");
            neuron.Test(sample);
        }

        static void TestRosenblattNeuron()
        {
            var samples = new List<List<double>>
            {
                new List<double> {-1,-1 },
                new List<double> {-1, 1 },
                new List<double> { 1,-1 },
                new List<double> { 1, 1 },
            };

            var targets = new List<double>
            {
                -1, -1, -1, 1
            };

            var neuron = new RosenblattNeuron(0.1d);
            neuron.Test(samples);

            var epochsCount = neuron.Train(samples, targets);
            Console.WriteLine(string.Format("Epoch count = {0}",epochsCount));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("After learn");
            neuron.Test(samples);
        }
    }
}