using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EyesManager
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger.SetRecord(true);
            Logger.SetPath(Application.StartupPath);

            MainController mainController = new MainController();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DefineSeting.SetServerPath(mainController.LocalIniManager.GetKeyValue("Setting", "serverPath"));

            if (mainController.WorkManager.ConnectTest())
                mainController.WorkManager.StepList = mainController.StepManager.GetAllStep();

            MainForm loginFrom = new MainForm(mainController);

            if (loginFrom.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm(mainController));
            }
        }
    }
}
