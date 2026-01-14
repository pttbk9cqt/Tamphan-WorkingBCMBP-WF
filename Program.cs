using System;
using System.Windows.Forms;

namespace Tamphan_WorkingBCMBP_WF
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Input1506());
        }
    }
}
