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

        public static Tile GetTile(string Name)
        {
            throw new NotImplementedException();
        }

        public static Tile[] GetTiles()
        {
            if (!File.Exists(Tile_File_Name))
            {
                File.Create(Tile_File_Name).Close();
                return null;
            }
            using StreamReader sr = new(Tile_File_Name);
            string data = sr.ReadToEnd();
            int count = data.Split("},{").Length;
            int count2 = data.Split(',').Length;
            Tile[] tiles;
            if (count + 1 == count2)
            {
                List<Tile> Ret = new();
                foreach (string til in data.Split(','))
                    Ret.Add(JsonConvert.DeserializeObject<Tile>(data));
                tiles = Ret.ToArray();
            }
            else
            {
                tiles = new Tile[1];
                tiles[0] = JsonConvert.DeserializeObject<Tile>(data);
            }

            return tiles;
        }

        public static bool AddTile(Tile til)
        {
            if (til == null)
                return false;
            try
            {
                string output = JsonConvert.SerializeObject(til);
                if (File.Exists(Tile_File_Name) && File.ReadAllText(Tile_File_Name) == null)
                    output = output.Insert(0, ",");
                using StreamWriter sw = new(Tile_File_Name, true);
                sw.Write(output);
            }
            catch { return false; }

            return true;
        }

        public static bool Save_Card(Card card)
        {
            throw new NotImplementedException();
        }
        public static void Generate_Default()
        {
            throw new NotImplementedException();
        }
    }
}
