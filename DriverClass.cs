using System;
using System.Collections.Generic;

namespace EmployeeAspire
{
    /*This project is about employee data entry. It takes Employee Id, Name, DOB, DOJ, Email and mobile number as input
     * Author Name: Purushottam
     * Date Started: 24/07/2018
     * Date Modified: 25/07/2018
     * */
    class DriverClass  // This is the class that contains Main Method
    {
        public static List<permanentSalary> permanentEmployeeList = new List<permanentSalary>();//List of Object for Permanent Employee
        public static List<contractSalary> contractEmployeeList = new List<contractSalary>();//List of Object for Temporary Employee

        public static void Main() // This is the main method.
        {
            int EmployeeType = 0;
            int choice = 0;


        One:
            Console.WriteLine("\nEnter 1 for Permanent Employee\nEnter any other digit for Contract Employee ");
            try
            {
                EmployeeType = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {

                Console.WriteLine("\n\nInvalid Input. Try Again!");
                Main();
            }

            if (EmployeeType == 1)
            {

                permanentSalary employeeAspire = new permanentSalary();// creating a new object to access members of EmployeeDetails Class.
                Console.WriteLine(employeeAspire.getEmployeeID());
                Console.WriteLine(employeeAspire.getEmployeeName());
                Console.WriteLine(employeeAspire.getEmployeeDOB());
                Console.WriteLine(employeeAspire.getEmployeeDOJ());
                Console.WriteLine(employeeAspire.getEmployeeMobileNo());
                Console.WriteLine(employeeAspire.getEmployeeEmail());
                employeeAspire.getEmployeeSalary();
                permanentEmployeeList.Add(employeeAspire);
            }
            else
            {

                contractSalary employeeAspire = new contractSalary();// creating a new object to access members of EmployeeDetails Class. 
                Console.WriteLine(employeeAspire.getEmployeeID());
                Console.WriteLine(employeeAspire.getEmployeeName());
                Console.WriteLine(employeeAspire.getEmployeeDOB());
                Console.WriteLine(employeeAspire.getEmployeeDOJ());
                Console.WriteLine(employeeAspire.getEmployeeMobileNo());
                Console.WriteLine(employeeAspire.getEmployeeEmail());
                employeeAspire.getEmployeeSalary();
                contractEmployeeList.Add(employeeAspire);
            }


        Two:
            Console.WriteLine("\n\nDo you want to continue ?\n\nOption (1)  Press 1 to exit and view stored data.\n\nOption (2)  Press any other number to continue entering Employee Details");

            try
            {
                choice = Convert.ToInt32(Console.ReadLine());

            }
            catch (FormatException)
            {

                Console.WriteLine("\nInvalid Input. Try Again!");
                goto Two;
            }

            if (choice != 1)
                goto One;

            else
            {
                {
                    if (permanentEmployeeList.Count != 0)
                        Console.WriteLine("\nPermanent Employees details:\n");
                    foreach (var PE in permanentEmployeeList)
                        Console.WriteLine($"EMPID: {PE.EMPID}\tName: {PE.ENAME}\tGross-Salary: {PE.gSalary}");
                }
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine("---------------------------------------------------------------");
                {
                    if (contractEmployeeList.Count != 0)
                        Console.WriteLine("\nContract Employees details:\n");
                    foreach (var CE in contractEmployeeList)
                        Console.WriteLine($"EMPID: {CE.EMPID}\tName: {CE.ENAME}\tGross-Salary: {CE.gSalary}");
                }

                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine("---------------------------------------------------------------");
            }

            Console.WriteLine("\n\nDictionary Implementation: ");
            EmployeeCollection.CheckUniquePermanentEmployees();
            EmployeeCollection.CheckUniqueContractEmployees();

            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------------");

            Console.WriteLine("\n\nSorted List Implemetation");
            EmployeeCollection.CheckUniquePermanentSalary();
            EmployeeCollection.CheckUniqueContractSalary();

            Console.Read();

        }
    }
}
