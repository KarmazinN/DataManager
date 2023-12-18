using DataManager.BOL.Entity;
using DataManager.BOL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.BOL.Common
{
    public class EmployeeSearch
    {
        public string FistName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<EmployeeViewModel>? employees { get; set;}
    }
}
