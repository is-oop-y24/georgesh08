using System;
using Reports.DAL.Tools;

namespace Reports.DAL.Entities
{
    public class Task
    {
        public Task() { }
        
        public Task(string instance)
        {
            Instance = instance;
            CreationTime = DateTime.Now;
            LastChangeTime = DateTime.Now;
            TaskId = Guid.NewGuid();
            Status = TaskStatus.Open;
            IsChanged = false;
        }

        public string ResponsibleEmployee { get; set; }
        public string Instance { get; set; }
        public DateTime LastChangeTime { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsChanged { get; set; }
        public Guid TaskId { get; set; }
        public TaskStatus Status { get; set; }
    }
}