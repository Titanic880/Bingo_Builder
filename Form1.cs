using System.Windows.Forms;
using System.Drawing;
using System;

namespace Bingo_Card_Generator
{
    public partial class Form1 : Form
    {
        private readonly Card card;

        public Form1()
        {
            InitializeComponent();
            Json_Manager.INIT();
            card = new();
#if !DEBUG
            if (!File.Exists(Json_Manager.Tile_File_Name))
            {
                DialogResult dr = MessageBox.Show("Prebuilt tiles are missing, Would you like to regenerate them?","Missing Data",MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                    Json_Manager.Generate_Default();
            }
#endif
            Load_Tiles();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            new Tile_Create().ShowDialog();
            Load_Tiles();
        }
        
        private void Load_Tiles() => LstAllTiles.DataSource = Json_Manager.GetTiles();

        private void BtnAddBingo_Click(object sender, EventArgs e)
        {
            if(!card.Card_Built && card.Tiles_Count == 24)
            {
                BtnAddBingo.Enabled = false;
                BtnBuild.Enabled = true;
            }

            if (card.Add_Tile((Tile)LstAllTiles.SelectedItem))
                MessageBox.Show("Error adding tile. (already have 25 or duplicate)");
        }

        private void BtnBuild_Click(object sender, EventArgs e)
        {
            BtnBuild.Enabled = false;
            BtnAddBingo.Enabled = true;

            if(!card.Card_Built && card.Tiles_Count == 25)
                card.Build_Card();
            else
                MessageBox.Show("ERROR: Please submit bug report");

            for(int i = 0; i < 5; i++)
                for (int x = 0; x < 5; x++)
                {
                    ((PictureBox)BingoGroup.Controls[i + x]).Image = new Bitmap(card.Set_Tiles[i][x].Image_Path);
                    ((PictureBox)BingoGroup.Controls[i + x]).Tag = card.Set_Tiles[i][x];
                }
            
        }

    }
}
