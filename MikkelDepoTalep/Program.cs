using System;
using System.Windows.Forms;

namespace MikkelDepoTalep
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LogInForm mF = new LogInForm();
            Application.Run(mF);
            if (mF.successLogin)
                Application.Run(new mainForm(mF.name, mF.userName));
        }
    }
}
