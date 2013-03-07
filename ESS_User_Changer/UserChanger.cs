using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;   

namespace ESS_User_Changer
{
    class UserChanger
    {
        static void Main(string[] args)
        {
            string AbraHRMS_Live = "AbraHRMS_TRN"; //Change this to your AbraHRMS_Live Database
            string AbraEmployeeSelfService = "AbraESS_TRN"; // Change this to your ESS Database
            Console.Out.NewLine = ""; // Tells NewLine to insert a carriage return
            string path = @"C:\UserChanger.sql"; // Change this to where you want your file


            if (File.Exists(path)) // Checks to see if File exists
            {
                File.Delete(path); // Deletes file if it exists
            } // Otherwise, we continue as normal

            using (FileStream fs = File.Create(path)); //Creates the File
            
            //Have user enter old data
            Console.WriteLine("Enter the old Employee Number: ");
            string old_emp_no = Console.ReadLine();
            Console.WriteLine("Enter the old Employee First Name: ");
            string old_fname = Console.ReadLine();
            Console.WriteLine("Enter the old Employee Last Name: ");
            string old_lname = Console.ReadLine();
            Console.WriteLine("Enter the old Employee Company Code: ");
            string old_co_code = Console.ReadLine();
            
            
            //Have User enter new data
            Console.WriteLine("Enter the new Employee Number: ");
            string new_emp_no = Console.ReadLine();
            Console.WriteLine("Enter the new Employee First Name: ");
            string new_fname = Console.ReadLine();
            Console.WriteLine("Enter the new Employee Last Name: ");
            string new_lname = Console.ReadLine();
            Console.WriteLine("Enter the new Employee Company Code: ");
            string new_co_code = Console.ReadLine();
            
            
            StringBuilder builderOutput = new StringBuilder(); // starts string builer

            // below we use string builder to build our file
            
            // Sets script to use the AbraHRMS_Live 
            builderOutput.Append("USE ");
            builderOutput.Append(AbraHRMS_Live);
            builderOutput.Append(";");
            builderOutput.AppendLine();
            builderOutput.AppendLine();
            // updates dbo.hemerg
            builderOutput.Append("UPDATE dbo.hemerg");
            builderOutput.AppendLine();
            builderOutput.Append("SET ");
            builderOutput.Append("e_empno = '");
            builderOutput.Append(new_emp_no);
            builderOutput.Append("'");
            builderOutput.Append("WHERE ");
            builderOutput.AppendLine();
            builderOutput.Append("e_empno = '");
            builderOutput.Append(old_emp_no);
            builderOutput.Append("'");
            builderOutput.AppendLine();
            builderOutput.Append("GO");
            builderOutput.AppendLine();
            builderOutput.AppendLine();
            // updates dbo.hdepben
            builderOutput.Append("UPDATE dbo.hdepben");
            builderOutput.AppendLine();
            builderOutput.Append("SET d_empno = '");
            builderOutput.Append(new_emp_no);
            builderOutput.Append("'");
            builderOutput.AppendLine();
            builderOutput.Append("WHERE 	d_empno = '");
            builderOutput.Append(old_emp_no);
            builderOutput.Append("'");
            builderOutput.AppendLine();
            builderOutput.Append("GO");
            builderOutput.AppendLine();
            builderOutput.AppendLine();
            // updates dbo.hbene
            builderOutput.Append("UPDATE dbo.hbene");
            builderOutput.AppendLine();
            builderOutput.Append("SET b_empno = '");
            builderOutput.Append(new_emp_no);
            builderOutput.Append("'");
            builderOutput.AppendLine();
            builderOutput.Append("WHERE 	b_empno = '");
            builderOutput.Append(old_emp_no);
            builderOutput.Append("'");
            builderOutput.AppendLine();
            builderOutput.Append("GO");
            builderOutput.AppendLine();
            builderOutput.AppendLine();
            // updates dbo.bpscmas
            builderOutput.Append("UPDATE dbo.bpspcmas");
            builderOutput.AppendLine();
            builderOutput.Append("SET lastname = '");
            builderOutput.Append(new_lname);
            builderOutput.Append("', firstname = '");
            builderOutput.Append(new_fname);
            builderOutput.Append("', middlename = 'Middle'");
            builderOutput.AppendLine();
            builderOutput.Append("WHERE 	empno = '");
            builderOutput.Append(old_emp_no);
            builderOutput.Append("'");
            builderOutput.AppendLine();
            builderOutput.Append("GO");
            builderOutput.AppendLine();
            builderOutput.AppendLine();
            // updates dbo.hdepend
            builderOutput.Append("UPDATE dbo.hdepend");
            builderOutput.AppendLine();
            builderOutput.Append("SET d_fname = 'Child', d_lname='");
            builderOutput.Append(new_lname);
            builderOutput.Append("', d_ssno = '000-00-0000', d_address1 = '123 Old President St.', d_birth = ''");
            builderOutput.AppendLine();
            builderOutput.Append("WHERE 	d_empno = '");
            builderOutput.Append(old_emp_no);
            builderOutput.Append("'");
            builderOutput.AppendLine();
            builderOutput.Append("GO");
            builderOutput.AppendLine();
            builderOutput.AppendLine();
            // updates dbo.hrpersnl
            builderOutput.Append("UPDATE dbo.hrpersnl");
            builderOutput.AppendLine();
            builderOutput.Append("SET p_empemail = '");
            builderOutput.Append(new_fname);
            builderOutput.Append(new_lname);
            builderOutput.Append("@domain.com', p_secemail = '', p_fname = '");
            builderOutput.Append(new_fname);
            builderOutput.Append("', p_lname = '");
            builderOutput.Append(new_lname);
            builderOutput.Append("', p_nickname = '");
            builderOutput.Append(new_fname);
            builderOutput.Append("', p_mi = 'M', p_fcity = 'Lexington', p_hcity = 'Lexington', p_hzip = '68850', p_hstreet1 = '123 Old President St', p_birth = '', p_hphone = '', p_jobtitle = '', p_jobgroup = '', p_notes = '', p_supemail = '', p_supervis = '', p_superno = '', p_empno = '");
            builderOutput.Append(new_emp_no);
            builderOutput.Append("', p_ssn = '0123456789'");
            builderOutput.AppendLine();
            builderOutput.Append("WHERE 	p_empno = '");
            builderOutput.Append(old_emp_no);
            builderOutput.Append("'");
            builderOutput.AppendLine();
            builderOutput.Append("GO");
            builderOutput.AppendLine();
            builderOutput.AppendLine();
            // updates dbo.bpspcmas
            builderOutput.Append("UPDATE dbo.bpspcmas");
            builderOutput.AppendLine();
            builderOutput.Append("SET empno = '");
            builderOutput.Append(new_emp_no);
            builderOutput.Append("'");
            builderOutput.AppendLine();
            builderOutput.Append("WHERE 	empno = '");
            builderOutput.Append(old_emp_no);
            builderOutput.Append("'");
            builderOutput.AppendLine();
            builderOutput.Append("GO");
            builderOutput.AppendLine();
            builderOutput.AppendLine();
            // Sets script to use the AbraEmployeeSelfService 
            builderOutput.Append("USE ");
            builderOutput.Append(AbraEmployeeSelfService);
            builderOutput.Append(";");
            builderOutput.AppendLine();
            // Updates dbo.tNOTIFICATIONS (Notification Message)
            builderOutput.Append("UPDATE dbo.tNOTIFICATIONS");
            builderOutput.AppendLine();
            builderOutput.Append("SET NotificationMessage = 'Notification Message Here'");
            builderOutput.AppendLine();
            builderOutput.Append("WHERE NotificationActedOnUserIDNo != NULL");
            builderOutput.AppendLine();
            builderOutput.Append("GO");
            builderOutput.AppendLine();
            builderOutput.AppendLine();
            // Updates dbo.tNOTIFICATIONS (NotificationReminderEmployeeKey)
            builderOutput.Append("UPDATE dbo.tNOTIFICATIONS");
            builderOutput.AppendLine();
            builderOutput.Append("SET NotificationReminderEmployeeKey = '");
            builderOutput.Append(new_emp_no);
            builderOutput.Append("     ");
            builderOutput.Append(new_co_code);
            builderOutput.Append("'");
            builderOutput.AppendLine();
            builderOutput.Append("WHERE NotificationReminderEmployeeKey = '");
            builderOutput.Append(old_emp_no);
            builderOutput.Append("     ");
            builderOutput.Append(old_co_code);
            builderOutput.Append("'");
            builderOutput.AppendLine();
            builderOutput.Append("GO");
            builderOutput.AppendLine();
            builderOutput.AppendLine();
            // Updates dbo.tUSERS (UserAbraSuiteLogicalPrimaryKey)
            builderOutput.Append("UPDATE dbo.tUSERS");
            builderOutput.AppendLine();
            builderOutput.Append("SET UserAbraSuiteLogicalPrimaryKey = '");
            builderOutput.Append(new_emp_no);
            builderOutput.Append("     ");
            builderOutput.Append(new_co_code);
            builderOutput.Append("'");
            builderOutput.AppendLine();
            builderOutput.Append("WHERE UserAbraSuiteLogicalPrimaryKey = '");
            builderOutput.Append(old_emp_no);
            builderOutput.Append("     ");
            builderOutput.Append(old_co_code);
            builderOutput.Append("'");
            builderOutput.AppendLine();
            builderOutput.Append("GO");
            builderOutput.AppendLine();
            builderOutput.AppendLine();
            string output = builderOutput.ToString(); // Convert String builder to string
            System.IO.File.AppendAllText(path, output); // Sends string to file
        }
    }

}
