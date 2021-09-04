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
        public string Image_Path
        {
            get { return image_path; }
            set => image_path = Environment.CurrentDirectory + "\\Images\\" + value;
        }
        private string image_path;

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

        public Tile() { }

        public override string ToString()
        {
            return Name;
        }
    }
}
