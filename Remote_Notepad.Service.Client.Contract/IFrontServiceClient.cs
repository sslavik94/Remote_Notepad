using System.Collections.Generic;
using Remote_Notepad.Domain;
using System.Collections.ObjectModel;

namespace Remote_Notepad.Service.Client.Contract
{
    public interface IFrontServiceClient
    {
        bool SystemEnter(string login, string password);
        void AddMessage(string messageName, string messageContent);
        ObservableCollection<MessageInfo> GetMessageList();
        UserInfo GetMember();
        int GetProfile();
        void DeleteMessage(int index);
        void UpdateMessage(int index, MessageInfo message);
        void ConnectionClose();
    }
}
