using Remote_Notepad.Context;
using Remote_Notepad.Domain;
using Remote_Notepad.Service.Client.Contract;
using Remote_Notepad.Service.Client.Stub;
using Remote_Notepad.Utility;
using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace Remote_Notepad.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public IFrontServiceClient frontServiceClient;

        #region Login command
        private RelayCommand loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new RelayCommand(param => Login());
                }

                return loginCommand;
            }
        }
        #endregion 

        #region Login and Password property registration
        public string LoginName
        {
            get { return (string)GetValue(LoginNameProperty); }
            set { SetValue(LoginNameProperty, value); }
        }

        public static readonly DependencyProperty LoginNameProperty =
        DependencyProperty.Register("LoginName", typeof(string), typeof(LoginViewModel), new PropertyMetadata(""));


        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(LoginViewModel), new PropertyMetadata(""));


        #endregion


        public LoginViewModel()
        {
            //for stub
            //frontServiceClient = new FrontServiceClientStub();

            //for real
            frontServiceClient = ServiceManager.GetInstance().GetManager("FrontServiceClient") as IFrontServiceClient;
        }

        private void Login()
        {
            try
            {
                if (frontServiceClient.SystemEnter(LoginName, Password) == true)
                {
                    LoginName = null;
                    Password = null;
                    ControlManager.GetInstance().Place("MainWindow", "MainRegion", "DashboardControl");
                }
                else
                {
                    ControlManager.GetInstance().Place("LoginControl", "ErrorRegion", "ErrorControl");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
