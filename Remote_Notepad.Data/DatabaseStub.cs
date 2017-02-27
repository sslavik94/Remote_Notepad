using Remote_Notepad.Domain;
using Remote_Notepad.Service.Client.Contract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remote_Notepad.Data
{
    public class DatabaseStub : IDatabase
    {
        public UserInfo ReturnDataFromDatabase()
        {
            UserInfo Member = new UserInfo();
            Member.Login = "dev";
            Member.Password = "dev";
            Member.MessageCollection = new ObservableCollection<MessageInfo>();
            Member.Profile = new int();
            return Member;
        }
    }
}
