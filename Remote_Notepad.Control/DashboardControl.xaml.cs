using System.Windows;
using System.Windows.Controls;
using Remote_Notepad.ViewModel;
using System.Collections.ObjectModel;
namespace Remote_Notepad.Control
{
    /// <summary>
    /// Логика взаимодействия для DashboardControl.xaml
    /// </summary>
    public partial class DashboardControl : UserControl
    {
        #region DashboardViewModel
        public DashboardViewModel DashboardViewModel
        {
            get { return (DashboardViewModel)GetValue(DashboardViewModelProperty); }
            set { SetValue(DashboardViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DashboardViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DashboardViewModelProperty =
            DependencyProperty.Register("DashboardViewModel", typeof(DashboardViewModel), typeof(DashboardViewModel), new PropertyMetadata(null));

        #endregion


        public DashboardControl()
        {
            InitializeComponent();
            this.DashboardViewModel = new DashboardViewModel();
            this.DataContext = DashboardViewModel;
        }
    }
}
