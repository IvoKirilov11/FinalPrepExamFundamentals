using System;
using System.Linq;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> carsDistance = new Dictionary<string, int>();
            Dictionary<string, int> carsFuel = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] car = Console.ReadLine()
                    .Split("|");

                string nameCar = car[0];
                int milage = int.Parse(car[1]);
                int fuel = int.Parse(car[2]);

                carsDistance[nameCar] = milage;
                carsFuel[nameCar] = fuel;
            }
            string input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] tolkens = input.Split(" : ");
                string command = tolkens[0];

                if (command == "Drive")
                {
                    int amortizationMileage = 100000;
                    string car = tolkens[1];
                    int distance = int.Parse(tolkens[2]);
                    int fuelCommand = int.Parse(tolkens[3]);

                    if (fuelCommand > carsFuel[car])
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        carsDistance[car] += distance;
                        carsFuel[car] -= fuelCommand;
                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuelCommand} liters of fuel consumed.");
                    }
                    if (carsDistance[car] >= amortizationMileage)
                    {
                        Console.WriteLine($"Time to sell the {car}!");
                        carsDistance.Remove(car);
                        carsFuel.Remove(car);

                    }

                }
                if (command == "Refuel")
                {
                    int maxRefillLevel = 75;
                    int fuelCommand = int.Parse(tolkens[2]);
                    int actualNeededFuelAmount = maxRefillLevel - carsFuel[tolkens[1]];

                    carsFuel[tolkens[1]] += fuelCommand;
                    if (carsFuel[tolkens[1]] > maxRefillLevel)
                    {
                        Console.WriteLine($"{tolkens[1]} refueled with {actualNeededFuelAmount} liters");

                        carsFuel[tolkens[1]] = maxRefillLevel;
                    }
                    else
                    {
                        Console.WriteLine($"{tolkens[1]} refueled with {fuelCommand} liters");
                    }
                }
                if (command == "Revert")
                {
                    int minimumMileageLevel = 10000;
                    string car = tolkens[1];
                    int revert = int.Parse(tolkens[2]);

                    carsDistance[tolkens[1]] -= revert;

                    if (carsDistance[tolkens[1]] >= minimumMileageLevel)
                    {
                        Console.WriteLine($"{tolkens[1]} mileage decreased by {revert} kilometers");
                    }
                    else
                    {
                        carsDistance[tolkens[1]] = minimumMileageLevel;
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join($"{Environment.NewLine}", carsDistance
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Select(x => $"{x.Key} -> Mileage: {x.Value} kms, Fuel in the tank: {carsFuel[x.Key]} lt.")));
        }
    }
}