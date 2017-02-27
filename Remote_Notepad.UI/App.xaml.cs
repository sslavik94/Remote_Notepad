using Remote_Notepad.Context;
using Remote_Notepad.Control;
using Remote_Notepad.Service.Client.Contract;
using Remote_Notepad.Service.Client.Stub;
using System;
using System.Windows;

namespace Remote_Notepad.UI
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void AppStartUp(object sender, StartupEventArgs args)
        {
            try
            {
                Bootstrapper.GetInstance();

                #region Main window definition
                this.MainWindow = ControlManager.GetInstance().GetControl("MainWindow") as MainWindow;
                this.MainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                this.MainWindow.Show();
                #endregion

                ControlManager.GetInstance().Place("MainWindow", "MainRegion", "LoginControl");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AppExit(object sender, ExitEventArgs args)
        {
            IFrontServiceClient frontServiceClient = ServiceManager.GetInstance().GetManager("FrontServiceClient") as IFrontServiceClient;
            frontServiceClient.ConnectionClose();
            this.Shutdown();
        }
    }
}
