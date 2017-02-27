using System;
using System.Windows;
using System.Net.Http;
using Microsoft.AspNet.SignalR.Client;
using Remote_Notepad.Domain;
using Remote_Notepad.Service.Client.Contract;
using System.Collections.ObjectModel;
using Remote_Notepad.Data;
using Remote_Notepad.Context;

namespace Remote_Notepad.Service.Client.Stub
{
    public class FrontServiceClient : IFrontServiceClient
    {
        UserInfo Member = new UserInfo();
        public IHubProxy HubProxy { get; set; }
        const string ServerURI = "http://192.168.1.104:8080";
        public HubConnection Connection { get; set; }

        public FrontServiceClient()
        {

        }


        public void ConnectionClose()
        {
            HubProxy.Invoke("UserDisconnected", Member.Login);
            Connection.Stop();
        }

        private async void ConnectAsync()
        {
            Connection = new HubConnection(ServerURI);
            HubProxy = Connection.CreateHubProxy("MyHub");
            Connection.Closed += Connection_Closed;
            HubProxy.On<UserInfo>("GetMember", (member) => Application.Current.Dispatcher.Invoke(() => Member = member));
            try
            {
                await Connection.Start();
            }
            catch (HttpRequestException)
            {
                return;
            }
        }

        void Connection_Closed()
        {
            var dispatcher = Application.Current.Dispatcher;
        }

        public bool SystemEnter(string login, string password)
        {
            if (login == "dev" && password == "dev")
            {
                //login = "test";
                ConnectAsync();
                System.Threading.Thread.Sleep(1000);   // Нужно изменить на ожидание отклика сервера!!!!!!
                HubProxy.Invoke("UserConnected", login);
                HubProxy.Invoke("Send", login);
                return true;
            }
            else return false;
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
            HubProxy.Invoke("MessageAdd", messageName, messageContent);
        }

        public void DeleteMessage(int index)
        {
            if (index != -1)
            {
                HubProxy.Invoke("MessageDelete", Member.MessageCollection[index].MessageName, Member.MessageCollection[index].MessageContent);
                Member.MessageCollection.RemoveAt(index);
                Member.Profile = Member.MessageCollection.Count;
            }
        }

        public void UpdateMessage(int index, MessageInfo oldMessage)
        {
            if (index != -1)
            {
                MessageInfo newMessage = new MessageInfo();
                newMessage.MessageName = "newName";
                newMessage.MessageContent = "newContent";
                HubProxy.Invoke("MessageUpdate", oldMessage.MessageName, oldMessage.MessageContent, newMessage.MessageName, newMessage.MessageContent);
                Member.MessageCollection.RemoveAt(index);
                Member.MessageCollection.Insert(index, newMessage);
            }
        }
    }
}
