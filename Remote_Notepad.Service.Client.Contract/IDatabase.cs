using Remote_Notepad.Domain;

namespace Remote_Notepad.Service.Client.Contract
{
    public interface IDatabase
    {
        UserInfo ReturnDataFromDatabase();
    }
}
