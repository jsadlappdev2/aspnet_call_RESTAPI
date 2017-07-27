using System;
using System.Collections.Generic;

namespace HttpClientSample.Models
{
    [DataContract]
    public class TodoItem
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string DueDate { get; set; }
        [DataMember]
        public bool isDone { get; set; }

        public static implicit operator TodoItem(List<TodoItem> v)
        {
            throw new NotImplementedException();
        }
    }

    internal class DataContractAttribute : Attribute
    {
    }

    internal class DataMemberAttribute : Attribute
    {
    }
}
