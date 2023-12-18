using DataManager.BOL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.BOL.ViewModel
{
    public class CreateEmployeeViewModel
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

        public int Departament_Id { get; set; }
        public int Position_Id { get; set; }
        public int Company_Id { get; set; }
        public List<Company> companies { get; set; }
        public List<Position> positions { get; set; }
        public List<Departament> departments { get; set; }
    }
}
