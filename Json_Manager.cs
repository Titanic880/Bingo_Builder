using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.IO;
using System;
using System.Windows.Forms;

namespace Bingo_Card_Generator
{
    public static class Json_Manager
    {
        public static readonly string Directory_POS = $"C:\\Users\\{Environment.UserName}\\Bingo_Generator\\";
        public static readonly string Tile_File_Name = Directory_POS + "TILE_JSON_DATA.json";
        public static readonly string Card_File_Name = Directory_POS + "CARD_JSON_DATA.json";
        public static readonly string Images_Folder_Name = Directory_POS + "Images\\";
        public static readonly string ERROR_FILE = Directory_POS + "Error";
        /// <summary>
        /// Checks all files/Folders related to the project
        /// </summary>
        public static void INIT()
        {
            if (!File.Exists(Tile_File_Name))
                File.Create(Tile_File_Name).Close();
            if(!File.Exists(Card_File_Name))
                File.Create(Card_File_Name).Close();
            if (!Directory.Exists(Images_Folder_Name))
                Directory.CreateDirectory(Images_Folder_Name);
            if (File.ReadAllText(Tile_File_Name) == "")
            {
                DialogResult dr = MessageBox.Show("Prebuilt tiles are missing, Would you like to regenerate them?", "Missing Data", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                    Generate_Default();
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
            catch (Exception _ex)
            {
                using StreamWriter sr = File.AppendText(ERROR_FILE);
                sr.Write($"ERROR POS: AddTile Method, Reason: {_ex}");
                return false;
            }

            return true;
        }
        
        public static bool Replace_Tile(Tile tile)
        {
            try
            {

                Tile[] ar = GetTiles();
                for (int i = 0; i < ar.Length; i++)
                    if (ar[i].Name == tile.Name && ar[i].Desc == tile.Desc && ar[i].Difficulty == tile.Difficulty)
                        ar[i] = tile;

                using StreamWriter sw = new(Tile_File_Name);
                sw.Write(JsonConvert.SerializeObject(ar, Formatting.Indented));
            }
            catch (Exception ex)
            {
                StreamWriter sw = File.AppendText(ERROR_FILE);
                sw.WriteLine($"ERROR ON REPLACE TILE (NAME: {tile.Name}): "+ex.Message);
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
                @"{'Name': 'Test_0','Desc': 'This is a test :D','Difficulty': 0,'Completed': false,'Image_Path': '9psumxhi6nm41.jpg'}",
                @"{'Name': 'Test_1','Desc': 'This is a 2nd test :D','Difficulty': 1,'Completed': false,'Image_Path': 'BabySharkTurtle.jpg'}"
            };

            Tile[] ile = new Tile[tiles.Length];
            for (int i = 0; i < tiles.Length; i++)
                ile[i] = JsonConvert.DeserializeObject<Tile>(tiles[i]);
            foreach (Tile a in ile)
                if (!AddTile(a))
                {
                    StreamWriter sr = File.AppendText(ERROR_FILE);
                    sr.WriteLine($"Issue Adding Default Tile: {DateTime.UtcNow}");
                    sr.Dispose();
                }
        }
    }
}
