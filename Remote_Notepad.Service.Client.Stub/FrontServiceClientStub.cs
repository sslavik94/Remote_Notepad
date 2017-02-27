using Remote_Notepad.Data;
using Remote_Notepad.Domain;
using Remote_Notepad.Service.Client.Contract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remote_Notepad.Service.Client.Stub
{
    /// <summary>
    /// The front service client stub.
    /// </summary>
    public class FrontServiceClientStub// : IFrontServiceClient
    {
        private readonly IDatabase DatabaseStub;
        UserInfo Member = new UserInfo();

        public FrontServiceClientStub()
        {
            DatabaseStub = new DatabaseStub();
            UserInfo UserFromData = DatabaseStub.ReturnDataFromDatabase();   /////?!!!!!
            Member.Login = UserFromData.Login;                               /////!!!!!!
            Member.Password = UserFromData.Password;                         //////!!!!!
            Member.MessageCollection = UserFromData.MessageCollection;       //////?!!!!
            Member.Profile = UserFromData.Profile;       ///////!??!
        }

        public bool SystemEnter(string login, string password)
        {

            UserInfo UserFromData = DatabaseStub.ReturnDataFromDatabase();
            if (login == UserFromData.Login && password == UserFromData.Password)
            {
                Member.Login = UserFromData.Login;
                Member.Password = UserFromData.Password;
                Member.MessageCollection = UserFromData.MessageCollection;
                return true;
            }
            return false;
        }

        public ObservableCollection<MessageInfo> GetMessageList()
        {
            return Member.MessageCollection;
        }

        public UserInfo GetMember()
        {
            return Member;
        }

        public int GetProfile()
        {
            return Member.Profile;
        }

        public void AddMessage(string messageName, string messageContent)
        {
            MessageInfo newMessage = new MessageInfo();
            newMessage.MessageName = messageName;
            newMessage.MessageContent = messageContent;
            Member.MessageCollection.Add(newMessage);
            Member.Profile = Member.MessageCollection.Count;
        }

        public void DeleteMessage(int index)
        {
            if (index != -1)
            {
                Member.MessageCollection.RemoveAt(index);
                Member.Profile = Member.MessageCollection.Count;
            }
        }

        public void UpdateMessage(int index, MessageInfo message)
        {
            if (index != -1)
            {
                Member.MessageCollection.RemoveAt(index);
                Member.MessageCollection.Insert(index, message);
            }
        }
    }
}