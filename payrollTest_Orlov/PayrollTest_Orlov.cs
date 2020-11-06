using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payroll_OrlovME;

namespace payrollTest_Orlov
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
           
                int empId = 1;
                Employee e = new Employee(empId, "Арсений", "амонович");
                Assert.AreEqual("Арсений", e.Name);
                Assert.AreEqual("амонович", e.Address);
                Assert.AreEqual(empId, e.EmpId);
            }

        [TestMethod]
        public void MyTestMethod()
        {
            int empId = 1;
            Employee e = new Employee(empId, "Арсений", "амонович");
            e.ToString();
        }

        [TestMethod]
        public void TestAddSalariedEmployee()
        {
            int empId = 1;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Арсений", "амонович", 9999.99);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Арсений", e.Name);

            PaymentClassification paymentClassification = e.Classification;
            Assert.IsTrue(paymentClassification is SalariedClassification);

            SalariedClassification salariedClassification = (SalariedClassification)paymentClassification;
            Assert.AreEqual(9999.99, salariedClassification.Salary, .001);

            PaymentSchedule paymentSchedule = e.Schedule;
            Assert.IsTrue(paymentSchedule is MonthlySchedule);

            PaymentMethod paymentMethod = e.Method;
            Assert.IsTrue(paymentMethod is HoldMethod);
        }

        [TestMethod]
        public void TestAddHourlyEmployee()
        {
            int empId = 1;
            AddHourlyEmployee h = new AddHourlyEmployee(empId, "Арсений", "амонович", 999.99);
            h.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Арсений", e.Name);
            PaymentClassification paymentClassification = e.Classification;
            Assert.IsTrue(paymentClassification is HourlyClassification);

            HourlyClassification hourlyClassification = (HourlyClassification)paymentClassification;
            Assert.AreEqual(999.99, hourlyClassification.HourlyRate, .001);

            PaymentSchedule paymentSchedule = e.Schedule;
            Assert.IsTrue(paymentSchedule is WeeklySchedule);

            PaymentMethod paymentMethod = e.Method;
            Assert.IsTrue(paymentMethod is HoldMethod);
        }

        [TestMethod]
        public void TestAddCommissionedEmployee()
        {
            int empId = 1;
            AddCommissionedEmployee c = new AddCommissionedEmployee(empId, "Арсений", "амонович", 9999.99, 10.00);
            c.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Арсений", e.Name);
            PaymentClassification paymentClassification = e.Classification;
            Assert.IsTrue(paymentClassification is CommissionedClassification);

            CommissionedClassification commissionedClassification = (CommissionedClassification)paymentClassification;

            Assert.AreEqual(9999.99, commissionedClassification.Salary, .001);
            Assert.AreEqual(10.00, commissionedClassification.CommissionRate, .001);

            PaymentSchedule paymentSchedule = e.Schedule;
            Assert.IsTrue(paymentSchedule is BiweeklySchedule);

            PaymentMethod paymentMethod = e.Method;
            Assert.IsTrue(paymentMethod is HoldMethod);
        
    }
    }
}
