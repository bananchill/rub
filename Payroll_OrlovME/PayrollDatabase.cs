using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_OrlovME
{
   public class PayrollDatabase
    {
        private static Hashtable employees = new Hashtable();

        public static void AddEmployee(Employee employee)
        {
            employees[employee.EmpId] = employee;
        }

        public static Employee GetEmployee(int id)
        {
            return (Employee)employees[id];
        }
    }
}
