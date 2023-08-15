using System.Collections;
using System.Diagnostics;
using Lab7.CheckPoint.Interfaces;
using Lab7.CheckPoint.Vehicles;
using Lab7.Sample.Vehicles;

namespace Lab7.Sample
{
    internal class Program
    {
        private const float MinWaitTime = 50;
        private const float MaxWaitTime = 100;


        public static void Main(string[] args)
        {
            ITheftDetectionSystem theftDetectionSystem = new SampleTheftDetectionSystem();
            RandomVehicleGenerator vehicleGenerator = new RandomVehicleGenerator();
            
            CheckPoint.CheckPoint checkPoint = new CheckPoint.CheckPoint(theftDetectionSystem);
            
            TrafficFlowTerminalRandom trafficFlowTerminalRandom = new TrafficFlowTerminalRandom(checkPoint);
            TrafficFlowTerminalSpeeding trafficFlowTerminalSpeeding = new TrafficFlowTerminalSpeeding(checkPoint);
            TrafficFlowTerminalStolen trafficFlowTerminalStolen = new TrafficFlowTerminalStolen(checkPoint);
                
            IEnumerator simulation = Simulation(vehicleGenerator, checkPoint);
            while (!Console.KeyAvailable)
            {
                simulation.MoveNext();
            }
            
            trafficFlowTerminalRandom.Dispose();
            trafficFlowTerminalSpeeding.Dispose();
            trafficFlowTerminalStolen.Dispose();

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
                checkPoint.RegisterVehicle(vehicle);
            }
        }
    }
}