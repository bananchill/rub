using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_OrlovME
{
    public class Employee
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int EmpId { get; }



        public PaymentClassification Classification { get; set; }
        public PaymentSchedule Schedule { get; set; }
        public PaymentMethod Method { get; set; }
        public Affiliation Affiliation { get; set; }



        public Employee(int empid, string name, string address)
        {
            this.Name = name;
            this.Address = address;
            this.EmpId = empid;
        }


        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Сотрудник: ").Append(EmpId).Append("     ");
            builder.Append(Name).Append("     ");
            builder.Append(Address).Append("     ");
            builder.Append("Классификация платежа: ").Append(Classification).Append("  ");
            builder.Append(Schedule);
            builder.Append(" через: ").Append(Method);
            builder.Append("принадлежит к ").Append(Affiliation);
            return builder.ToString();
        }
    }
}
