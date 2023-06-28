using System.Collections;
using System.Diagnostics;
using Lab3.CheckPoint.Interfaces;
using Lab3.CheckPoint.Vehicles;
using Lab3.Sample.Vehicles;

namespace Lab3.Sample
{
    internal class Program
    {
        private const float MinWaitTime = 50;
        private const float MaxWaitTime = 100;


        public static void Main(string[] args)
        {
            ITheftDetectionSystem theftDetectionSystem = new SampleTheftDetectionSystem();
            RandomVehicleGenerator vehicleGenerator = new RandomVehicleGenerator();
            IOutStream outStream = new OutStream();
            CheckPoint.CheckPoint checkPoint = new CheckPoint.CheckPoint(theftDetectionSystem, outStream);
            IEnumerator simulation = Simulation(vehicleGenerator, checkPoint);
            while (!Console.KeyAvailable)
            {
                simulation.MoveNext();
            }

            Console.WriteLine(checkPoint.Statistics);
        }

        private static IEnumerator Simulation(RandomVehicleGenerator vehicleGenerator, CheckPoint.CheckPoint checkPoint)
        {
            while (true)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                float waitTime = new Random().NextSingle() * (MaxWaitTime - MinWaitTime) + MinWaitTime;
                while (waitTime > stopwatch.ElapsedMilliseconds)
                {
                    yield return null;
                }

                AVehicle vehicle = vehicleGenerator.NextVehicle();
                Console.WriteLine(vehicle);
                checkPoint.RegisterVehicle(vehicle);
            }
        }
    }
}