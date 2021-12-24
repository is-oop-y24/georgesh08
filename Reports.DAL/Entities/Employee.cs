using System;
using System.Collections.Generic;
using Reports.DAL.Tools;
using Reports.DAL.Tools.Exceptions;

namespace Reports.DAL.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Guid MasterId { get; set; }
        public string Name { get; set; }
        
        public Employee() { }

        public Employee(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new EmployeeException("Invalid name.");
            }
            Name = name;
            Id = Guid.NewGuid();
            MasterId = Guid.Empty;
        }
    }
}