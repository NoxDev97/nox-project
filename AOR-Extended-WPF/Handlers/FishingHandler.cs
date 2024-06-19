using System;
using System.Collections.Generic;
using System.Linq;
using AOR_Extended_WPF.Utils;

namespace AOR_Extended_WPF.Handlers
{
    public class FishingHandler
    {
        public Settings Settings { get; set; }
        public List<Fish> Fishes { get; set; }

        public FishingHandler(Settings settings)
        {
            Settings = settings;
            Fishes = new List<Fish>();
        }

        public void NewFishEvent(object[] parameters)
        {
            if (!Settings.ShowFish) return;

            int id = (int)parameters[0];
            string type = parameters[4]?.ToString();
            double[] coor = (double[])parameters[1];
            int sizeSpawned = (int)parameters[2];
            int sizeLeftToSpawn = (int)parameters[3];

            if (string.IsNullOrEmpty(type)) return;
            if (coor == null) return;

            double posX = coor[0];
            double posY = coor[1];

            UpsertFish(id, posX, posY, type, sizeSpawned, sizeLeftToSpawn);
        }

        public void UpsertFish(int id, double posX, double posY, string type, int sizeSpawned, int sizeLeftToSpawn)
        {
            Fish fish = new Fish(id, posX, posY, type, sizeSpawned, sizeLeftToSpawn);

            int index = Fishes.FindIndex(f => f.Id == fish.Id);
            if (index != -1)
            {
                Fishes[index] = fish;
                return;
            }

            Fishes.Add(fish);
        }

        public void FishingEnd(object[] parameters)
        {
            if (!Settings.ShowFish) return;

            Console.WriteLine("Fishing END:");
            Console.WriteLine(parameters);
            Console.WriteLine();

            int id = (int)parameters[0];

            if (!Fishes.Any(fish => fish.Id == id)) return;

            RemoveFish(id);
        }

        public void RemoveFish(int id)
        {
            Fishes = Fishes.Where(fish => fish.Id != id).ToList();
        }
    }
}

