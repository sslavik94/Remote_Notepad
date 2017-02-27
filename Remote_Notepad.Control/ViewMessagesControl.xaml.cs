using System.Windows;
using System.Windows.Controls;
using Remote_Notepad.ViewModel;
using System.Collections.ObjectModel;

namespace Remote_Notepad.Control
{
    /// <summary>
    /// Логика взаимодействия для ViewMesssagesControl.xaml
    /// </summary>
    public partial class ViewMessagesControl : UserControl
    {
        #region ViewMessagesViewModel
        public ViewMessagesViewModel ViewMessagesViewModel
        {
            get { return (ViewMessagesViewModel)GetValue(ViewMessagesViewModelProperty); }
            set { SetValue(ViewMessagesViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ViewMessagesViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewMessagesViewModelProperty =
            DependencyProperty.Register("ViewMessagesViewModel", typeof(ViewMessagesViewModel), typeof(ViewMessagesViewModel), new PropertyMetadata(null));

        #endregion


        public ViewMessagesControl()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(OnLoad);
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            this.ViewMessagesViewModel = new ViewMessagesViewModel();
            this.DataContext = ViewMessagesViewModel;
        }
    }
}
