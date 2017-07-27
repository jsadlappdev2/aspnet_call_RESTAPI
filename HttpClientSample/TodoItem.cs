using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientSample.Models
{
    class TodoItem
    {
        public int id { get; set; }
        public string Description { get; set; }
        public string DueDate { get; set; }
        public bool isDone { get; set; }

        public static implicit operator TodoItem(List<TodoItem> v)
        {
            throw new NotImplementedException();
        }
    }
}
