using System;
namespace EmployeeAspire
{
    /* This program contains function details about Contract Employee Salary. It is heirarchical inhertience
    * the Employee class.
    * Author: Purushottam
    * Date created: 24/7/2018
    * Date modified: 25/07/2018
    * */
    class contractSalary : EmployeeDetails
    {
        private int Salary;
        public double gSalary;
        double da, pf, hra;
        public contractSalary()
        {
            Salary = 0;
            da = pf = gSalary = hra = 0;

        }

        public contractSalary(int income) // Constructor OverLoading
        {
            Console.WriteLine("As Contract Employee your basic Salary is : {0}", income);

            Salary = income;
            hra = 20 * Salary / 100;
            da = 10 * Salary / 100;
            pf = 15 * Salary / 100;
            gSalary = Salary + hra + da + pf;

        }

        public override void getEmployeeSalary() // this method will override getEmployeeSalary in Employee class
        {
            int bSalary;
            Console.WriteLine("Enter your basic Salary in Rupees: ");
            bSalary = Convert.ToInt32(Console.ReadLine());
            if (Salary == 0)
            {
                hra = 20 * bSalary / 100;
                da = 10 * bSalary / 100;
                pf = 15 * bSalary / 100;
                gSalary = bSalary + hra + da + pf;
            }

        }



    }
}
