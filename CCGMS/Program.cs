using System;
using System.Windows.Forms;

namespace CCGMS
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize and run Form1 directly
            Form1 form1 = new Form1();
            Application.Run(form1);
        }
    }
}
