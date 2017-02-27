using System.Windows;
using System.Windows.Controls;
using Remote_Notepad.ViewModel;
using System.Collections.ObjectModel;
using System;

namespace Remote_Notepad.Control
{
    /// <summary>
    /// Логика взаимодействия для ViewProfileControl.xaml
    /// </summary>
    public partial class ViewProfileControl : UserControl
    {
        #region ViewProfileViewModel
        public ViewProfileViewModel ViewProfileViewModel
        {
            get { return (ViewProfileViewModel)GetValue(ViewProfileViewModelProperty); }
            set { SetValue(ViewProfileViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ViewProfileViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewProfileViewModelProperty =
            DependencyProperty.Register("ViewProfileViewModel", typeof(ViewProfileViewModel), typeof(ViewProfileViewModel), new PropertyMetadata(null));

        #endregion


        public ViewProfileControl()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(OnLoad);
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            this.ViewProfileViewModel = new ViewProfileViewModel();
            this.DataContext = ViewProfileViewModel;
        }
    }
}
