using System;
using System.Runtime.Serialization;

namespace WCF.ViewModels
{
    [DataContract]
    public class UserVM
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }


        [DataMember]
        public DateTime Birthday { get; set; }


        [DataMember]
        public Int16 Gender { get; set; }
    }
}