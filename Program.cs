using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bingo_Card_Generator
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public enum Diff_ENUM
    {
        NULL = -2,
        Debug = -1,
        Easy = 0,
        Medium = 1,
        Hard = 2,
        Elite = 3,
        Master = 4
    }
}
