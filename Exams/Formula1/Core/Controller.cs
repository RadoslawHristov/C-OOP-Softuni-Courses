using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository=new PilotRepository();
        private RaceRepository raceRepository=new RaceRepository();
        private FormulaOneCarRepository formulaOneCarRepo=new FormulaOneCarRepository();

        public string CreatePilot(string fullName)
        {
            var pilot = pilotRepository.FindByName(fullName);
            if (pilot != null)
            {
                throw new InvalidOperationException($"Pilot {fullName} is already created.");
            }

            Pilot pilots = new Pilot(fullName);
            pilotRepository.Add(pilots);
            return $"Pilot {fullName} is created.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            var formula = formulaOneCarRepo.FindByName(model);
            if (formula != null)
            {
                throw new InvalidOperationException($"Formula one car {model} is already created.");
            }
            else if (type != "Ferrari" && type != "Williams")
            {
                throw new InvalidOperationException($"Formula one car type {type} is not valid.");
            }

            IFormulaOneCar car = null;
            if (type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }

            formulaOneCarRepo.Add(car);
            return $"Car {type}, model {model} is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            var race = raceRepository.FindByName(raceName);
            if (race != null)
            {
                throw new InvalidOperationException($"Race {raceName} is already created.");
            }

            Race races = new Race(raceName, numberOfLaps);
            raceRepository.Add(races);
            return $"Race {raceName} is created.";
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            var pilot = pilotRepository.FindByName(pilotName);
            if (pilot == null)
            {
                throw new InvalidOperationException($"Pilot {pilotName} does not exist or has a car.");
            }
            var car = formulaOneCarRepo.FindByName(carModel);
            if (car == null)
            {
                throw new NullReferenceException($"Car {carModel} does not exist.");
            }
            pilot.AddCar(car);
            formulaOneCarRepo.Remove(car);
            return $"Pilot {pilotName} will drive a {car.GetType().Name} {carModel} car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var race = raceRepository.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }
            var pilot = pilotRepository.FindByName(pilotFullName);
            if (pilot == null || pilot.CanRace == false || race.Pilots.Contains(pilot))
            {
                throw new InvalidOperationException($"Can not add pilot {pilotFullName} to the race.");
            }
            race.AddPilot(pilot);
            return $"Pilot {pilotFullName} is added to the {raceName} race.";
        }
         
        public string StartRace(string raceName)
        {
            var race = raceRepository.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than three participants.");
            }

            if (race.TookPlace == true)
            {
                throw new InvalidOperationException($"Can not execute race {raceName}.");
            }

            List<IPilot> racers = new List<IPilot>();
            foreach (var pilot in race.Pilots)
            {
                pilot.Car.RaceScoreCalculator(race.NumberOfLaps); //throw exception object not references
                racers.Add(pilot);
            }

            race.TookPlace = true;
            racers[0].WinRace();
            racers = racers.OrderByDescending(x => x.NumberOfWins).ToList();
            return $"Pilot {racers[0].FullName} wins the {raceName} race." +
            $"Pilot {racers[1].FullName} is second in the {raceName} race." +
            $"Pilot {racers[2].FullName} is third in the {raceName} race.";
        }


        public string RaceReport()
        {
            StringBuilder sv = new StringBuilder();
            var allrace = raceRepository.Models.Where(x => x.TookPlace == true).ToList();
            foreach (var races in allrace)
            {
                sv.AppendLine($"The {races.RaceName} race has:");
                sv.AppendLine(races.RaceInfo());//may be small problem
            }

            return sv.ToString().Trim();
        }

        public string PilotReport()
        {
            StringBuilder sv = new StringBuilder();

            foreach (var pilot in pilotRepository.Models.OrderByDescending(x=>x.NumberOfWins))
            {
                sv.AppendLine(pilot.ToString());
            }

            return sv.ToString().Trim();
        }
    }
}
