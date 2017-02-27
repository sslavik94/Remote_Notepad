using System.Windows;
using System.Windows.Controls;
using Remote_Notepad.ViewModel;
using System.Collections.ObjectModel;

namespace Remote_Notepad.Control
{
    /// <summary>
    /// Логика взаимодействия для LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        #region LoginViewModel
        public LoginViewModel LoginViewModel
        {
            get { return (LoginViewModel)GetValue(LoginViewModelProperty); }
            set { SetValue(LoginViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoginViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoginViewModelProperty =
            DependencyProperty.Register("LoginViewModel", typeof(LoginViewModel), typeof(LoginViewModel), new PropertyMetadata(null));

        #endregion


        public LoginControl()
        {
            InitializeComponent();
            this.LoginViewModel = new LoginViewModel();
            this.DataContext = LoginViewModel;
        }
    }
}
