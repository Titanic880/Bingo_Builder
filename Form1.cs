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
#if !DEBUG
            BtnAddBingo.Enabled = false;
            BtnBuild.Enabled = false;
            LstBingoTiles.Enabled = false;
            BingoGroup.Enabled = false;
#endif
            Json_Manager.INIT();
            card = new();

            Load_Tiles();
            Tile[] ar = Json_Manager.GetTiles();
            if (ar is null) return;
            pb01.Tag = ar[0];
            pb01.BackColor = Color.Black;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            new Tile_Create().ShowDialog();
            Load_Tiles();
        }
        private void BtnModify_Click(object sender, EventArgs e)
        {
            new Tile_Create((Tile)LstAllTiles.SelectedItem).ShowDialog();
            Load_Tiles();
        }

        private void Load_Tiles() => LstAllTiles.DataSource = Json_Manager.GetTiles();

        private void BtnAddBingo_Click(object sender, EventArgs e)
        {
            pb01.Image = ((Tile)LstAllTiles.SelectedItem).ByteArrayToImage();
            /*
            if(!card.Card_Built && card.Tiles_Count == 24)
            {
                BtnAddBingo.Enabled = false;
                BtnBuild.Enabled = true;
            }
            if (card.Add_Tile((Tile)LstAllTiles.SelectedItem))
                MessageBox.Show("Error adding tile. (already have 25 or duplicate)");*/
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

        private void BtnFolder_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start("Explorer.exe", Json_Manager.Directory_POS);

        ToolTip tip;
        private void PicReset(object sender, EventArgs e) => tip = null;
        private void PicHover(object sender, EventArgs e)
        {
            if (sender is not PictureBox) return;
            //if (card == null || !card.Card_Built) return;     //Removed for testing of hover
            Tile tile = (Tile)((PictureBox)sender).Tag;
            if (tile != null && tip == null)
            {
                tip = new();
                tip.SetToolTip((PictureBox)sender, tile.Desc);
            }
        }
        

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Width = 816;
            this.Height = 618;
        }
    }
}
