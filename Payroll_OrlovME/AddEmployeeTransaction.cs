using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_OrlovME
{
    public abstract class AddEmployeeTransaction : Transaction
    {
        private readonly int empid;
        private readonly string name;
        private readonly string address;

        public AddEmployeeTransaction(int empid, string name, string address)
        {
            this.empid = empid;
            this.name = name;
            this.address = address;
        }
        protected abstract PaymentClassification MakeClassification();
        protected abstract PaymentSchedule MakeSchedule();

        public void Execute()
        {
            Employee e = new Employee(empid, name, address);
            PaymentClassification paymentClassification = MakeClassification();
            PaymentSchedule paymentSchedule = MakeSchedule();
            PaymentMethod paymentMethod = new HoldMethod();

            e.Classification = paymentClassification;
            e.Schedule = paymentSchedule;
            e.Method = paymentMethod;

            PayrollDatabase.AddEmployee(e);
        }
        public override string ToString()
        {
            return String.Format("{0} id:{1} name:{2} address:{3}", GetType().Name, empid, name, address);
        }
    }
}
