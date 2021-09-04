using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.IO;
using System;

namespace Bingo_Card_Generator
{
    public static class Json_Manager
    {
        public const string Tile_File_Name = "TILE_JSON_DATA.json";
        public const string Card_File_Name = "CARD_JSON_DATA.json";
        public static readonly string Directory_POS = $"C:\\Users\\{Environment.UserName}\\Bingo_Generator";

        /// <summary>
        /// Checks all files/Folders related to the project
        /// </summary>
        public static void INIT()
        {
            if (!File.Exists(Directory_POS + Tile_File_Name))
                File.Create(Directory_POS + Tile_File_Name).Close();
            if(!File.Exists(Directory_POS + Card_File_Name))
                File.Create(Directory_POS + Card_File_Name).Close();
            if (!Directory.Exists(Directory_POS + "/Images"))
                Directory.CreateDirectory(Directory_POS + "/Images");
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
            if (File.ReadAllText(Directory_POS + Tile_File_Name) == null || File.ReadAllText(Directory_POS + Tile_File_Name).Trim() == "")
                return null;

            using StreamReader sr = File.OpenText(Directory_POS + Tile_File_Name);
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
                if (File.ReadAllText(Directory_POS + Tile_File_Name).Trim() != "")
                    tiles = GetTiles().ToList();
                else
                    tiles = new List<Tile>();
                if (!tiles.Contains(til))
                {
                    tiles.Add(til);
                    using StreamWriter sw = new(Directory_POS + Tile_File_Name);
                    sw.Write(JsonConvert.SerializeObject(tiles, Formatting.Indented));
                }
            }
            catch (Exception _ex)
            {
                using StreamWriter sr = File.AppendText(Directory_POS + "ERRORS");
                sr.Write($"ERROR POS: AddTile Method, Reason: {_ex}");
                return false;
            }

            return true;
        }

        public static bool Save_Card(Card card)
        { //REBUILD BEFORE USE
            throw new NotImplementedException();
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
