using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EmployeeAspire
{

    /* This class contains various collection functions like Dictionary and sortedList of various employees
     * The funtion extract values from list of objects in EmployeeDetails Class and store them in various collections.
     * Author: Purushottam
     * Date created: 23/7/2018
     * Date modified: 23/07/2018
     * */
    class EmployeeCollection
    {
        public static Dictionary<int, string> AspirePermanentEmployees = new Dictionary<int, string>();
        public static Dictionary<int, string> AspireContractEmployees = new Dictionary<int, string>();
        public static SortedList<double, string> sortedSalaryPermanent = new SortedList<double, string>();
        public static SortedList<double, string> sortedSalaryContract = new SortedList<double, string>();
        public static void CheckUniquePermanentEmployees()
        { // Function to check employee ACE ID are different and store them in a dictionary
            int uniqueInt = 0;
            string PEName = string.Empty;
            foreach (var e1 in DriverClass.permanentEmployeeList)
            {
                uniqueInt = Int32.Parse(Regex.Match(e1.EMPID, @"\d+").Value);
                PEName = e1.ENAME;
                if (AspirePermanentEmployees.ContainsKey(uniqueInt) == false)
                {
                    AspirePermanentEmployees.Add(uniqueInt, PEName);
                }
                else
                {
                    Console.WriteLine("Two Employees have same ACE-ID. Integrity Compromised!");
                    Console.WriteLine($"ACE-ID: {e1.EMPID} Name: {e1.ENAME}");
                }
            }
            if (AspirePermanentEmployees.Count != 0)
            {

                Console.WriteLine("\nACE-ID\t\tPermanent Employee");


                foreach (KeyValuePair<int, string> item in AspirePermanentEmployees)
                {
                    Console.WriteLine($"{item.Key}\t\t{item.Value}");
                }
            }

        }



        public static void CheckUniqueContractEmployees() // Function to check employee ACE ID are different and store them in a dictionary
        {
            int uniqueInt = 0;
            string CEName = string.Empty;
            foreach (var e1 in DriverClass.contractEmployeeList)
            {
                uniqueInt = Int32.Parse(Regex.Match(e1.EMPID, @"\d+").Value);
                CEName = e1.ENAME;
                if (AspireContractEmployees.ContainsKey(uniqueInt) == false)
                {
                    AspireContractEmployees.Add(uniqueInt, CEName);
                }
                else
                {
                    Console.WriteLine("Two Employees have same ACE-ID. Integrity Compromised!");
                    Console.WriteLine($"ACE-ID: {e1.EMPID} Name: {e1.ENAME}");
                }
            }
            if (AspireContractEmployees.Count != 0)
            {

                Console.WriteLine("\nACE-ID\t\tContract Employee");

                foreach (KeyValuePair<int, string> item in AspireContractEmployees)
                {
                    Console.WriteLine($"{item.Key}\t\t{item.Value}");
                }
            }


        }

        public static void CheckUniqueContractSalary()// Function to check employee Salary are different and store them in a SortedList
        {
            double uniqueSalary = 0;
            string CEName = string.Empty;
            foreach (var e1 in DriverClass.contractEmployeeList)
            {
                uniqueSalary = e1.gSalary;
                CEName = e1.ENAME;
                if (sortedSalaryContract.ContainsKey(uniqueSalary) == false)
                {
                    sortedSalaryContract.Add(uniqueSalary, CEName);
                }
                else
                {
                    Console.WriteLine("Two Employees have same Salary. Integrity Compromised!");
                    Console.WriteLine($"Salary: {e1.gSalary} Name: {e1.ENAME}");
                }
            }

            if (sortedSalaryContract.Count != 0)
            {

                Console.WriteLine("\nSalary\t\tContract Employee");


                foreach (KeyValuePair<double, string> item in sortedSalaryContract)
                {
                    Console.WriteLine($"{item.Key}\t\t{item.Value}");
                }
            }


        }


        public static void CheckUniquePermanentSalary()// Function to check employee Salary are different and store them in a SortedList
        {
            double uniqueSalary = 0;
            string PEName = string.Empty;
            foreach (var e1 in DriverClass.permanentEmployeeList)
            {
                uniqueSalary = e1.gSalary;
                PEName = e1.ENAME;
                if (sortedSalaryPermanent.ContainsKey(uniqueSalary) == false)
                {
                    sortedSalaryPermanent.Add(uniqueSalary, PEName);
                }
                else
                {
                    Console.WriteLine("Two Employees have same Salary. Integrity Compromised!");
                    Console.WriteLine($"Salary: {e1.gSalary} Name: {e1.ENAME}");
                }
            }
            if (sortedSalaryPermanent.Count != 0)
            {

                Console.WriteLine("\nSalary\t\tPermanent Employee");


                foreach (KeyValuePair<double, string> item in sortedSalaryPermanent)
                {
                    Console.WriteLine($"{item.Key}\t\t{item.Value}");
                }
            }


        }

    }
}




