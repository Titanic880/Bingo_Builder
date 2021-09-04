using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo_Card_Generator
{
    public static class Json_Manager
    {
        public const string Tile_File_Name = "TILE_JSON_DATA.json";
        public const string Card_File_Name = "CARD_JSON_DATA.json";
        public static bool Data_Made_Session = false;

        public static void INIT()
        {
            if (!File.Exists(Tile_File_Name))
            {
                File.Create(Tile_File_Name).Close();
                Data_Made_Session = true;
            }
        }
        public static Tile GetTile(string Name)
        {
            Tile[] tiles = GetTiles();
            foreach (Tile a in tiles)
                if (a.ToString() == Name)
                    return a;

            return null;
        }

        public static Tile[] GetTiles()
        {
            if (File.ReadAllText(Tile_File_Name) == null || File.ReadAllText(Tile_File_Name).Trim() == "")
                return null;

            using StreamReader sr = File.OpenText(Tile_File_Name);
            JsonSerializer serializer = new();
            return (Tile[])serializer.Deserialize(sr, typeof(Tile[]));
        }

        public static bool AddTile(Tile til)
        {
            if (til == null)
                return false;
            try
            {
                List<Tile> tiles;
                if (File.ReadAllText(Tile_File_Name).Trim() != "")
                    tiles = GetTiles().ToList();
                else
                    tiles = new List<Tile>();
                if (!tiles.Contains(til))
                {
                    tiles.Add(til);
                    using StreamWriter sw = new(Tile_File_Name);
                    sw.Write(JsonConvert.SerializeObject(tiles, Formatting.Indented));
                }
            }
            catch (Exception ex)
            { 
                return false;
            }

            return true;
        }

        public static bool Save_Card(Card card)
        {
            try
            {
                string[] files = Directory.GetFiles(Environment.CurrentDirectory);
                int count = 0;
                foreach (string a in files)
                    if (a.StartsWith("Card_"))
                        count++;
                using StreamWriter sw = new($"Card_{count}");
                sw.Write(JsonConvert.SerializeObject(card, Formatting.Indented));
            }
            catch //(Exception ex)
            {
                return false;
            }
            return true;
        }
        public static void Generate_Default()
        {
            string[] tiles =
            {
                @"{ 'Name': 'Test_0','Desc': 'This is a test :D','Difficulty': 0,'Completed': false,'Image_Path': 'C:\\Users\\Mitch\\Desktop\\Bingo Card Generator\\bin\\Debug\\net5.0-windows\\Images\\BabySharkTurtle.jpg'}",
                @"  {'Name': 'Test_1','Desc': 'This is a 2nd test :D','Difficulty': 1,'Completed': false,'Image_Path': 'C:\\Users\\Mitch\\Desktop\\Bingo Card Generator\\bin\\Debug\\net5.0-windows\\Images\\BabySharkTurtle.jpg'}"
            };

            Tile[] ile = new Tile[tiles.Length];
            for (int i = 0; i < tiles.Length; i++)
                ile[i] = JsonConvert.DeserializeObject<Tile>(tiles[i]);
            foreach (Tile a in ile)
                AddTile(a);
        }
    }
}
