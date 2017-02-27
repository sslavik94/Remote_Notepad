using System.Windows.Controls;
using Remote_Notepad.ViewModel;
using System.Windows;
using System.Collections.ObjectModel;

namespace Remote_Notepad.Control
{
    /// <summary>
    /// Логика взаимодействия для AddMessageControl.xaml
    /// </summary>
    public partial class AddMessageControl : UserControl
    {
        #region AddMessageViewModel
        public AddMessageViewModel AddMessageViewModel
        {
            get { return (AddMessageViewModel)GetValue(AddMessageViewModelProperty); }
            set { SetValue(AddMessageViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddMessageViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddMessageViewModelProperty =
            DependencyProperty.Register("AddMessageViewModel", typeof(AddMessageViewModel), typeof(AddMessageViewModel), new PropertyMetadata(null));


        #endregion

        public AddMessageControl()
        {
            InitializeComponent();
            this.AddMessageViewModel = new AddMessageViewModel();
            this.DataContext = AddMessageViewModel;
        }
    }
}
