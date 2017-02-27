using Remote_Notepad.Context;
using Remote_Notepad.Service.Client.Contract;
using Remote_Notepad.Utility;
using System;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Remote_Notepad.Domain;

namespace Remote_Notepad.ViewModel
{
    public class AddMessageViewModel : ViewModelBase
    {
        private IFrontServiceClient frontServiceClient;

        private DispatcherTimer timer;

        #region MessageNameText
        public string MessageNameText
        {
            get { return (string)GetValue(MessageNameTextProperty); }
            set { SetValue(MessageNameTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MessageNameText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageNameTextProperty =
            DependencyProperty.Register("MessageNameText", typeof(string), typeof(AddMessageViewModel), new PropertyMetadata(""));

        #endregion

        #region MessageContentText
        public string MessageContentText
        {
            get { return (string)GetValue(MessageContentTextProperty); }
            set { SetValue(MessageContentTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MessageContentText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageContentTextProperty =
            DependencyProperty.Register("MessageContentText", typeof(string), typeof(AddMessageViewModel), new PropertyMetadata(""));

        #endregion

        #region ErrorText
        public string ErrorText
        {
            get { return (string)GetValue(ErrorTextProperty); }
            set { SetValue(ErrorTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorTextProperty =
            DependencyProperty.Register("ErrorText", typeof(string), typeof(AddMessageViewModel), new PropertyMetadata(""));
        #endregion

        #region SaveMessage command
        private RelayCommand saveMessageCommand;
        public ICommand SaveMessageCommand
        {
            get
            {
                if (saveMessageCommand == null)
                {
                    saveMessageCommand = new RelayCommand(param => SaveMessage());
                }

                return saveMessageCommand;
            }
        }

        private void SaveMessage()
        {
            try
            {
                if (ValidateMessage(MessageNameText, MessageContentText) == true)
                {
                    frontServiceClient.AddMessage(MessageNameText, MessageContentText);
                    MessageNameText =  "";
                    MessageContentText = "";
                    ControlManager.GetInstance().Place("DashboardControl", "WorkspaceRegion", "ViewMessagesControl");
                }
                else
                {
                    ErrorText = "Invalid data!";
                    timer = new DispatcherTimer();
                    timer.Tick += new EventHandler(timer_Tick);
                    timer.Interval = new TimeSpan(0, 0, 5);
                    timer.Start();       
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            ErrorText = "";
            timer.IsEnabled = false;
        }
        private bool ValidateMessage(string messageNameText, string messageContentText)
        {
            int errorCounter = 0;
            for (int i = 0; i < frontServiceClient.GetMessageList().Count; i++)
            {
                if (messageNameText.Length == 0 || messageContentText.Length == 0 || messageNameText == frontServiceClient.GetMessageList()[i].MessageName)
                    errorCounter++;
            }
            if (errorCounter == 0)
                return true;
            else return false;
        }

        #endregion

        #region Cancel command
        private RelayCommand cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                if (cancelCommand == null)
                {
                    cancelCommand = new RelayCommand(param => Cancel());
                }

                return cancelCommand;
            }
        }

        private void Cancel()
        {
            ControlManager.GetInstance().Place("DashboardControl", "WorkspaceRegion", "ViewProfileControl");
            MessageNameText = "";
            MessageContentText = "";
        }
        #endregion

        public AddMessageViewModel()
        {
            frontServiceClient = ServiceManager.GetInstance().GetManager("FrontServiceClient") as IFrontServiceClient;
        }
    }
}
