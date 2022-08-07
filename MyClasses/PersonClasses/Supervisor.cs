using System.Collections.Generic;

namespace MyClasses.PersonClasses
{
    public class Supervisor : Person
    {
        public List<Employee> Employees { get; set; }
    }
}
