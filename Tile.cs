using System.Drawing;
using System;
using System.Collections;

namespace Bingo_Card_Generator
{
    [Serializable()]
    public class Tile
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public Diff_ENUM Difficulty { get; set; } = Diff_ENUM.NULL;
        public bool Completed { get; set; } = false;
        public Image BitImage
        {
            get
            {
                if (Image_Path != null)
                    if (Image_Path.Trim() != "")
                        if (Image_Path.Substring(Image_Path.Length - 3, 3) == "jpg"
                         || Image_Path.Substring(Image_Path.Length - 3, 3) == "png")
                            return new Bitmap(Image_Path);
                return null;
            }
        }
        public string Image_Path { get; set; } = null;
        public bool NullCheck()
        {
            if (Name == null
            || Desc == null
            || Difficulty == Diff_ENUM.NULL
            || BitImage == null
            || Image_Path == null)
                return false;
            else
                return true;
        }

        public Tile() { }

        public override string ToString()
        {
            return Name;
        }
    }
}
