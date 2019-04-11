
using System;
using System.Text.RegularExpressions;
namespace EmployeeAspire
{

    /* This program contains function details about various functions present in Employee detail calss. It is accessed using
     * the DriverClass class.
     * Author: Purushottam
     * Date created: 24/7/2018
     * Date modified: 25/07/2018
     * */

    public class EmployeeDetails
    {
        public string EMPID; // These are access specifiers in class variables that cover encapsulation
        public string ENAME;
        public DateTime DOB;
        public DateTime DOJ;
        public string mobNo;
        public string emailId;



        public string getEmployeeID() // gets Employee ACE ID
        {
            Console.WriteLine("Enter Your Employee ID (ACEXXXX): ");
            EMPID = Console.ReadLine();
            // to validate id <9999
            if (Regex.IsMatch(EMPID, @"^ACE\d\d\d\d$") && EMPID.IndexOf("0000") == -1) // ACE followed by 4 digits but not ACE0000
                return EMPID;
            else
            {
                Console.WriteLine("Invalid Employee ID. Please Try again! ");
                getEmployeeID();
            }
            return EMPID;
        }




        public string getEmployeeName() //get Employee Name
        {
        Label1:
            Console.WriteLine("Enter Employee Name: ");
            ENAME = Console.ReadLine();


            if (Regex.IsMatch(ENAME, @"^[a-zA-Z_ ]*$") && (ENAME.IndexOf(" ") != 0) && (String.IsNullOrEmpty(ENAME) == false || String.IsNullOrWhiteSpace(ENAME) == false)) // to check if the name is valid. not number, not null, not special character cannot start with spaces, cannot be carriage return
            {
                return ENAME;
            }
            else
            {
                Console.WriteLine("Invalid Name. Try again !");
                getEmployeeName();
            }

            try
            {
                if (ENAME.Length <= 2)
                {
                    throw new LessThanThreeException("\n\nName cannot be less than 3 Characters");
                }
            }
            catch (LessThanThreeException e)
            {
                Console.WriteLine(e.ToString());
                goto Label1;
            }
            return ENAME;

        }




        public string getEmployeeDOB() //get employee DOB
        {
            Console.WriteLine("Enter Your Date of Birth (dd/MM/yyyy): ");

            try
            {
                DOB = DateTime.ParseExact(@Console.ReadLine(), @"d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                Console.WriteLine("\nInvalid date. Please Try again!");
                getEmployeeDOB();
            }

            DateTime localtime = DateTime.Now;
            if (localtime.Year - DOB.Year >= 18 && localtime.Year - DOB.Year <= 60)// to check if the dob is between 18-60
                return DOB.ToString("dd/MM/yyyy");

            else
            {
                Console.WriteLine("Invalid DOB. Please Try again !");
                getEmployeeDOB();
            }

            return DOB.ToString("dd/MM/yyyy");
        }




        public string getEmployeeDOJ() //get Employee DOJ
        {

            Console.WriteLine("Enter your Date of Joining (dd/MM/yyyy): ");
            try
            {
                DOJ = DateTime.ParseExact(@Console.ReadLine(), @"d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                Console.WriteLine("\nInvalid Date. Please Try again!");
                getEmployeeDOJ();
            }

            DateTime localtime = DateTime.Now;

            if (localtime.CompareTo(DOJ) < 0)  //should not be future date
            {
                Console.WriteLine("Invalid date of joining. Future Dates Not Allowed. Try again !");
                getEmployeeDOJ();
            }

            if (DOJ.Year - DOB.Year < 18 || DOJ.Year - DOB.Year > 60)  //DOJ and DOB must have 18-60 years gap
            {
                Console.WriteLine("DOJ - DOB cannot be less than 18 or more than 60");
                getEmployeeDOJ();
            }

            return DOJ.ToString("dd/MM/yyyy");
        }



        public string getEmployeeMobileNo() //Get Employee Mobile no. 
        {
            Console.WriteLine("Enter your 10 digit mobile number : ");
            mobNo = Console.ReadLine();
            if (mobNo.Length < 10 || String.IsNullOrEmpty(mobNo) == true || String.IsNullOrWhiteSpace(mobNo) == true)
            {
                Console.WriteLine("Invalid Mobile number. Try Again !");
                getEmployeeMobileNo();
            }
            if (Regex.IsMatch(mobNo, @"(\D+)"))
            {
                Console.WriteLine("The Mobile number contains alphabets. Please enter only numbers.");
                getEmployeeMobileNo();
            }

            if (Regex.IsMatch(mobNo, @"^0"))
            {
                Console.WriteLine("Invalid Mobile number. Try Again !");
                getEmployeeMobileNo();

            }

            return mobNo;
        }



        public string getEmployeeEmail() // Get Employee Email ID
        {
            Console.WriteLine("Enter your Email Id: ");
            emailId = Console.ReadLine();
            // to check if email id is valid
            if (Regex.IsMatch(emailId, @"(^[a-zA-Z]*\.[a-zA-Z]*)+@[A-Za-z]*\.[a-zA-Z]*$"))
                return emailId;
            else
            {
                Console.WriteLine("Please Enter a valid email id. ");
                getEmployeeEmail();
            }

            return emailId;
        }



        public virtual void getEmployeeSalary() // method overridding. This method will be overridden in permanent and contractual employee.
        {
            Console.WriteLine("This mesage will never be displayed as it will be overridden !");

        }

    }


}

//User defined Exception Class 

public class LessThanThreeException : Exception
{
    public LessThanThreeException(string message)
        : base(message)
    {
    }
}






