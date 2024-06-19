using System;
using System.Collections.Generic;
using System.Linq;
using AOR_Extended_WPF.Utils;

namespace AOR_Extended_WPF.Handlers
{
    public class HarvestablesHandler
    {
        private readonly Settings settings;
        public List<Harvestable> HarvestableList { get; set; }

        public HarvestablesHandler(Settings settings)
        {
            this.settings = settings;
            HarvestableList = new List<Harvestable>();
        }

        public void AddHarvestable(int id, int type, int tier, double posX, double posY, int charges, int size)
        {
            switch (GetStringType(type))
            {
                case "Fiber":
                    if (!settings.HarvestingStaticFiber[$"e{charges}"][tier - 1])
                        return;
                    break;
                case "Hide":
                    if (!settings.HarvestingStaticHide[$"e{charges}"][tier - 1])
                        return;
                    break;
                case "Log":
                    if (!settings.HarvestingStaticWood[$"e{charges}"][tier - 1])
                        return;
                    break;
                case "Ore":
                    if (!settings.HarvestingStaticOre[$"e{charges}"][tier - 1])
                        return;
                    break;
                case "Rock":
                    if (!settings.HarvestingStaticRock[$"e{charges}"][tier - 1])
                        return;
                    break;
                default:
                    return;
            }

            var harvestable = HarvestableList.FirstOrDefault(item => item.Id == id);

            if (harvestable == null)
            {
                var h = new Harvestable(id, GetStringType(type), tier, posX, posY, charges, size);
                HarvestableList.Add(h);
            }
            else
            {
                harvestable.SetCharges(charges);
            }
        }

        public void UpdateHarvestable(int id, int type, int tier, double posX, double posY, int charges, int size)
        {
            switch (GetStringType(type))
            {
                case "Fiber":
                    if (!settings.HarvestingStaticFiber[$"e{charges}"][tier - 1])
                        return;
                    break;
                case "Hide":
                    if (!settings.HarvestingStaticHide[$"e{charges}"][tier - 1])
                        return;
                    break;
                case "Log":
                    if (!settings.HarvestingStaticWood[$"e{charges}"][tier - 1])
                        return;
                    break;
                case "Ore":
                    if (!settings.HarvestingStaticOre[$"e{charges}"][tier - 1])
                        return;
                    break;
                case "Rock":
                    if (!settings.HarvestingStaticRock[$"e{charges}"][tier - 1])
                        return;
                    break;
                default:
                    return;
            }

            var harvestable = HarvestableList.FirstOrDefault(item => item.Id == id);

            if (harvestable == null)
            {
                AddHarvestable(id, type, tier, posX, posY, charges, size);
            }
            else
            {
                harvestable.Charges = charges;
                harvestable.Size = size;
            }
        }

        public void HarvestFinished(object[] parameters)
        {
            int id = (int)parameters[3];
            int count = (int)parameters[5];
            UpdateHarvestable(id, count);
        }

        public void HarvestUpdateEvent(object[] parameters)
        {
            int id = (int)parameters[0];

            if (parameters[1] == null)
            {
                RemoveHarvestable(id);
                return;
            }

            var harvestable = HarvestableList.FirstOrDefault(item => item.Id == id);

            if (harvestable != null)
            {
                harvestable.Size = (int)parameters[1];
            }
        }

        public void NewHarvestableObject(int id, object[] parameters)
        {
            int type = (int)parameters[5];
            int tier = (int)parameters[7];
            double[] location = (double[])parameters[8];

            int enchant = parameters[11] == null ? 0 : (int)parameters[11];
            int size = parameters[10] == null ? 0 : (int)parameters[10];

            UpdateHarvestable(id, type, tier, location[0], location[1], enchant, size);
        }

        public void NewSimpleHarvestableObject(object[] parameters)
        {
            int[] a0 = (int[])parameters[0];

            if (a0.Length == 0) return;

            int[] a1 = (int[])parameters[1];
            int[] a2 = (int[])parameters[2];
            double[] a3 = (double[])parameters[3];
            int[] a4 = (int[])parameters[4];

            for (int i = 0; i < a0.Length; i++)
            {
                int id = a0[i];
                int type = a1[i];
                int tier = a2[i];
                double posX = a3[i * 2];
                double posY = a3[i * 2 + 1];
                int count = a4[i];

                AddHarvestable(id, type, tier, posX, posY, 0, count);
            }
        }

        public void RemoveNotInRange(double lpX, double lpY)
        {
            HarvestableList = HarvestableList
                .Where(x => CalculateDistance(lpX, lpY, x.PosX, x.PosY) <= 80)
                .Where(item => item.Size != 0)
                .ToList();
        }

        public double CalculateDistance(double lpX, double lpY, double posX, double posY)
        {
            double deltaX = lpX - posX;
            double deltaY = lpY - posY;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        public void RemoveHarvestable(int id)
        {
            HarvestableList = HarvestableList.Where(x => x.Id != id).ToList();
        }

        public List<Harvestable> GetHarvestableList()
        {
            return new List<Harvestable>(HarvestableList);
        }

        public void UpdateHarvestable(int harvestableId, int count)
        {
            var harvestable = HarvestableList.FirstOrDefault(h => h.Id == harvestableId);

            if (harvestable != null)
            {
                harvestable.Size -= count;
            }
        }

        public string GetStringType(int typeNumber)
        {
            if (typeNumber >= 0 && typeNumber <= 5)
            {
                return "Log";
            }
            else if (typeNumber >= 6 && typeNumber <= 10)
            {
                return "Rock";
            }
            else if (typeNumber >= 11 && typeNumber <= 14)
            {
                return "Fiber";
            }
            else if (typeNumber >= 15 && typeNumber <= 22)
            {
                return "Hide";
            }
            else if (typeNumber >= 23 && typeNumber <= 27)
            {
                return "Ore";
            }
            else
            {
                return "";
            }
        }
    }
}
