using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System;

namespace Bingo_Card_Generator
{
    public partial class Tile_Create : Form
    {        
        public Tile_Create()
        {
            Init();
            CombDiff.SelectedItem = Diff_ENUM.Easy;
        }
        private void Init()
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
                CombDiff.Items.Add((Diff_ENUM)i);
        }
        public Tile_Create(Tile tomod)
        {
            Init();
            TbName.Text = tomod.Name;
            RtbDesc.Text = tomod.Desc;
            TbImage.Text = tomod.Image_Path;
            CombDiff.SelectedItem = tomod.Difficulty;
        }

        private void BtnImageFind_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new();
            ofd.InitialDirectory = "C:/";
            ofd.FileName = "Image Find";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {   
                    //Tests File Type
                    string Test = ofd.FileName.Split('.')[^1].ToLower();
                    if (Test == "png" || Test == "jpg")
                    {
                        Image img = new Bitmap(ofd.FileName);
                        if (img == null)
                            throw new Exception("Image is not an Image!");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    using StreamWriter sr = File.AppendText(Json_Manager.ERROR_FILE);
                    sr.Write($"ERROR POS: BtnImageFind Event (Tile_Create Form), Reason: {ex}");
                    return;
                }
                //Copies to local folder for use
                TbImage.Text = ofd.FileName;
            }
            else MessageBox.Show("Image Selection Cancelled");
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Tile tile = new(File.ReadAllBytes(image_file))
            {
                Name = TbName.Text,
                Desc = RtbDesc.Text,
                Difficulty = (Diff_ENUM)CombDiff.SelectedItem,
                Image_Path = TbImage.Text
            };
            if (tile.NullCheck())
            {
                if (Json_Manager.AddTile(tile))
                {
                    MessageBox.Show("Added to the list!");
                    Close();
                }
                else MessageBox.Show("Item Failed to be added to the list");
                
            }
            else MessageBox.Show("Tile not completed! (Missing/NULL Field)");
        }
    }
}
