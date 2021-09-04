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
            InitializeComponent();
            for (int i = 0; i < 5; i++)
                CombDiff.Items.Add((Diff_ENUM)i);
            CombDiff.SelectedItem = Diff_ENUM.Easy;
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
                    using StreamWriter sr = File.AppendText(Json_Manager.Directory_POS + "ERRORS");
                    sr.Write($"ERROR POS: BtnImageFind Event (Tile_Create Form), Reason: {ex}");
                    return;
                }
                //Copies to local folder for use
                if(!ofd.FileName.StartsWith($"{Json_Manager.Directory_POS}\\Images\\"))
                    File.Copy(ofd.FileName, $"{Json_Manager.Directory_POS}\\Images\\{ofd.FileName.Split("\\")[^1]}");
                TbImage.Text = ofd.FileName.Split("\\")[^1];

            }
            else
                MessageBox.Show("Image Selection Cancelled");
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Tile tile = new()
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
