using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WebService
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Filme GetFilme(int value);
        [OperationContract]
        List<Filme> ListFilmes();
        [OperationContract]
        int AddFilme(int key, Filme filme);
        [OperationContract]
        bool DelFilme(int id);
        [OperationContract]
        bool UptFilme(int id, Filme filme);
        [OperationContract]
        Plataforma GetPlataforma(int value);
        [OperationContract]
        List<Plataforma> ListPlataforma();
        [OperationContract]
        bool AddPlataforma(int key, Plataforma plataforma);
        [OperationContract]
        bool DelPlataforma(int id);
        [OperationContract]
        bool UptPlataforma(int id, Plataforma plataforma);
    }
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
