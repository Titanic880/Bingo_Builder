using System.IO;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Bingo_Card_Generator
{
    [Serializable()]
    public class Tile
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public Diff_ENUM Difficulty { get; set; } = Diff_ENUM.NULL;
        public bool Completed { get; set; } = false;
        public string Image_Path
        {
            get { return image_path; }
            set => image_path = value;
        }
        private string image_path;

        public byte[] Img_bytes { get; set; }
        public bool NullCheck()
        {
            if (Name == null
            || Desc == null
            || Difficulty == Diff_ENUM.NULL
            || Image_Path == null)
                return false;
            else
                return true;
        }

        public Tile()
        {
            if(Image_Path != null)
                ImageToByteArray(new Bitmap(Image_Path));
        }
        public Tile(byte[] image)
        {
            Img_bytes = image;
        }
        public Tile(Image image)
        {
            Img_bytes = ImageToByteArray(image);
        }

        private byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new();
            if (Image_Path.EndsWith("png"))
                imageIn.Save(ms, ImageFormat.Png);
            else if (Image_Path.EndsWith("jpg"))
                imageIn.Save(ms, ImageFormat.Jpeg);
            else
                ms = null;
            return ms.ToArray();
        }

        public Image ByteArrayToImage()
        {
            if(Img_bytes == null)
            {
                Img_bytes = ImageToByteArray(new Bitmap(Json_Manager.Images_Folder_Name+Image_Path));
                if (Img_bytes == null)
                    return null;
                else
                    Json_Manager.Replace_Tile(this);

            }
            MemoryStream ms = new(Img_bytes);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
