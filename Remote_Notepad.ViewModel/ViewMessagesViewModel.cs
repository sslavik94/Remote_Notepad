using Remote_Notepad.Context;
using Remote_Notepad.Domain;
using Remote_Notepad.Service.Client.Contract;
using Remote_Notepad.Utility;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace Remote_Notepad.ViewModel
{
    public class ViewMessagesViewModel : ViewModelBase
    {
        private IFrontServiceClient frontServiceClient;

        #region Messages
        public ObservableCollection<MessageInfo> Messages
        {
            get { return (ObservableCollection<MessageInfo>)GetValue(MessagesProperty); }
            set { SetValue(MessagesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Messages.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessagesProperty =
            DependencyProperty.Register("Messages", typeof(ObservableCollection<MessageInfo>), typeof(ViewMessagesViewModel), new PropertyMetadata(null));


        #endregion

        #region SelectedIndex
        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedIndexProperty =
            DependencyProperty.Register("SelectedIndex", typeof(int), typeof(ViewMessagesViewModel), new PropertyMetadata(-1));


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

        #region DeleteMessage command
        private RelayCommand deleteMessageCommand;
        public ICommand DeleteMessageCommand
        {
            get
            {
                if (deleteMessageCommand == null)
                {
                    deleteMessageCommand = new RelayCommand(param => DeleteMessage());
                }

                return deleteMessageCommand;
            }
        }

        private void DeleteMessage()
        {
                frontServiceClient.DeleteMessage(SelectedIndex);
        }
        #endregion

        #region UpdateMessage command
        private RelayCommand updateMessageCommand;
        public ICommand UpdateMessageCommand
        {
            get
            {
                if (updateMessageCommand == null)
                {
                    updateMessageCommand = new RelayCommand(param => UpdateMessage());
                }

                return updateMessageCommand;
            }
        }

        private void UpdateMessage()
        {
            //ControlManager.GetInstance().Place("DashboardControl", "WorkspaceRegion", "AddMessageControl");
            var message = new MessageInfo();
            ObservableCollection<MessageInfo> messages = frontServiceClient.GetMessageList();
            message = messages[SelectedIndex];
            frontServiceClient.UpdateMessage(SelectedIndex, message);
        }
        #endregion

        public ViewMessagesViewModel()
        {
            frontServiceClient = ServiceManager.GetInstance().GetManager("FrontServiceClient") as IFrontServiceClient;
            Messages = frontServiceClient.GetMessageList();
        }
    }
}
