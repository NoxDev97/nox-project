using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AOR_Extended_WPF.Handlers
{
    public class ItemsInfo
    {
        public Dictionary<int, string> ItemInfo { get; private set; }

        public ItemsInfo()
        {
            ItemInfo = new Dictionary<int, string>();
        }

        public void AddItem(int id, string name, int val)
        {
            if (val == 0)
            {
                ItemInfo[id] = name;
            }
            else
            {
                int code = id - 1;
                char[] itemNameBuilder = name.ToCharArray();
                int counter = 0;

                for (int j = 0; j <= 4; j++)
                {
                    if (j == 0)
                    {
                        counter++;
                        name = new string(itemNameBuilder);
                        ItemInfo[code + counter] = name;
                    }
                    else
                    {
                        counter++;
                        name = new string(itemNameBuilder) + "@" + j;
                        ItemInfo[code + counter] = name;
                    }
                }
            }
        }

        public async Task InitItems()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("/scripts/Handlers/items.txt");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"HTTP error! status: {response.StatusCode}");
                }

                string data = await response.Content.ReadAsStringAsync();
                string[] lines = data.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string line in lines)
                {
                    var match = System.Text.RegularExpressions.Regex.Match(line, @"^(\d+):\s+([^\s]+)\s+");

                    if (match.Success)
                    {
                        int id = int.Parse(match.Groups[1].Value);
                        string name = match.Groups[2].Value;
                        AddItem(id, name, 0);
                    }
                }
            }
        }
    }
}
