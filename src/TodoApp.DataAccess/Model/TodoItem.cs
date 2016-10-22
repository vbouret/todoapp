using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.DataAccess.Model
{
    /// <summary>
    /// Class containing the TodoItem object, no need for specific Bson attributes, the mapping is automatic
    /// </summary>
    public class TodoItem
    {
        public string Id { get; set; } 
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; } //Not implemented yet
        public DateTime CompletionDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string User { get; set; } //Not implemented yet
    }
}
