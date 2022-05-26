using System.Collections.Generic;
using System.ServiceModel;
using WCF.ViewModels;

namespace WCF.Interfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmployees" in both code and config file together.
    [ServiceContract]
    public interface IUser
    {
        [OperationContract]
        List<UserVM> All();

        [OperationContract]
        UserVM Show(int id);

        [OperationContract]
        bool Insert(UserVM item);

        [OperationContract]
        bool Update(int id, UserVM item);

        [OperationContract]
        bool Delete(int id);
    }
}
