using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.BOL.ViewModel
{
    public class EmployeeViewModel
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EntryDay { get; set; }
        public decimal Salary { get; set; }

        public string Departament { get; set; }
        public string Position { get; set; }   
        public string Company { get; set; }
    }
}
