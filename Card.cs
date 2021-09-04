using System.Security.Cryptography;

namespace Bingo_Card_Generator
{
    public class Card
    {
        /// <summary>
        /// Unset Tile Count
        /// </summary>
        public int? Tiles_Count { get; private set; } = null;
        private readonly Tile[] Unset_Tiles = null;
        private int unset_POS = 0;
        public Tile[][] Set_Tiles { get; private set; }
        public bool Card_Built { get; private set; } = false;

        public Card()
        {
            Unset_Tiles = new Tile[25];
        }

        public Card(Tile[] tiles)
        {
            Unset_Tiles = new Tile[25];
            Tiles_Count = tiles.Length;
        }

        public bool Add_Tile(Tile tile)
        {
            if (Unset_Tiles == null || tile == null || Unset_Tiles.Length == 25)
                return false;
            foreach (Tile a in Unset_Tiles)
                if (tile == a)
                    return false;
            Unset_Tiles[unset_POS] = tile;
            unset_POS++;
            return true;
        }
        public bool Add_Tiles(Tile[] tiles)
        {
            bool NoIssue = true;
            foreach (Tile a in tiles)
                if (!Add_Tile(a))
                    NoIssue = false;
            return NoIssue;
        }

        public bool Remove_Tile(Tile tile)
        {
            for (int i = 0; i < Unset_Tiles.Length; i++)
                if (Unset_Tiles[i] == tile)
                {
                    for (int x = i; x < Unset_Tiles.Length - i; x++)
                    {
                        Unset_Tiles[x] = Unset_Tiles[x + 1];
                    }
                    Tiles_Count--;
                    return true;
                }
            return false;
        }
        public bool Remove_Tile(string Name)
        {
            for(int i = 0; i < Unset_Tiles.Length; i++)
                if(Unset_Tiles[i].ToString() == Name)
                {
                    for(int x = i; x < Unset_Tiles.Length-i; x++)
                    {
                        Unset_Tiles[x] = Unset_Tiles[x + 1];
                    }
                    Tiles_Count--;
                    return true;
                }
            return false;
        }
        public bool Build_Card()
        {
            if (Card_Built || Unset_Tiles.Length != 25)
                return false;
            Set_Tiles = new Tile[5][];
            RNGCryptoServiceProvider provider = new();
            int n = Unset_Tiles.Length;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                Tile value = Unset_Tiles[k];
                Unset_Tiles[k] = Unset_Tiles[n];
                Unset_Tiles[n] = value;
            }
            for (int i = 0; i < 5; i++)
            {
                Set_Tiles[i] = new Tile[5];
                for (int x = 0; x < 5; x++)
                    Set_Tiles[i][x] = Unset_Tiles[(i * 5)+x];
            }

            Card_Built = true;
            return true;
        }
    }
}
