using Remote_Notepad.Context;
using Remote_Notepad.Service.Client.Contract;
using Remote_Notepad.Service.Client.Stub;
using Remote_Notepad.Utility;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace Remote_Notepad.ViewModel
{
    public class DashboardViewModel : ViewModelBase
    {
        private IFrontServiceClient frontServiceClient;

        public DashboardViewModel()
        {
            frontServiceClient = ServiceManager.GetInstance().GetManager("FrontServiceClient") as IFrontServiceClient;
        }

        #region ViewMessages command
        private RelayCommand viewMessagesCommand;
        public ICommand ViewMessagesCommand
        {
            get
            {
                if (viewMessagesCommand == null)
                {
                    viewMessagesCommand = new RelayCommand(param => ViewMessages());
                }

                return viewMessagesCommand;
            }
        }

        private void ViewMessages()
        {
            ControlManager.GetInstance().Place("DashboardControl", "WorkspaceRegion", "ViewMessagesControl");
        }
        #endregion

        #region ViewProfile command
        private RelayCommand viewProfileCommand;
        public ICommand ViewProfileCommand
        {
            get
            {
                if (viewProfileCommand == null)
                {
                    viewProfileCommand = new RelayCommand(param => ViewProfile());
                }

                return viewProfileCommand;
            }
        }

        private void ViewProfile()
        {
            ControlManager.GetInstance().Place("DashboardControl", "WorkspaceRegion", "ViewProfileControl");
        }

        #endregion

        #region AddMessage command
        private RelayCommand addMessageCommand;
        public ICommand AddMessageCommand
        {
            get
            {
                if (addMessageCommand == null)
                {
                    addMessageCommand = new RelayCommand(param => AddMessage());
                }

                return addMessageCommand;
            }
        }

        private void AddMessage()
        {
            ControlManager.GetInstance().Place("DashboardControl", "WorkspaceRegion", "AddMessageControl");
        }
        #endregion

        #region Logout command
        private RelayCommand logoutCommand;
        public ICommand LogoutCommand
        {
            get
            {
                if (logoutCommand == null)
                {
                    logoutCommand = new RelayCommand(param => Logout());
                }

                return logoutCommand;
            }
        }

        private void Logout()
        {
            frontServiceClient.ConnectionClose();
            ControlManager.GetInstance().Place("MainWindow", "MainRegion", "LoginControl");
        }
        #endregion
    }
}
