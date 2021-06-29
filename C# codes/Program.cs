using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    /*
     Some concepts that are left in program
     1) Size of data types: 
        integer: its size is (4 bytes)
        long: its size is (8 bytes)
        float: its size is (4 bytes)
        char: its size is (2 bytes)
        boolean: its size is (1 bit)
        string: its size is 2byte per input
     2) if we put something inside () then it will be calculated seperately
     3) if on one side of + operator is string operand then whole expression will be converted to string
     4) math and string methods.
     5) Two types of type casting:
        Implicit type casting: char to int to long to float to double
        Explicit type casting: two ways of doing explicit type casting a) put in brackets the target data type before the data
                                                                       b) Use the convert class like Convert.ToInt32 if you are not able 
                                                                           to do conversion using brackets.
      
     */
    class Program
    {
        static void personOpn(Person personobj) {
            Console.WriteLine("Select the operattion to perform on " + personobj.name + "\n" +
                "1 Add money \n" +
                "2 Withdraw money\n" +
                "3 Show availabe balance\n"+
                "4 Exit");
            string selectVal = Console.ReadLine();
            string amt;
            switch (selectVal)
            {
                case "1":
                    Console.WriteLine("Please enter the amt to be added in accound of "+personobj.name);
                    amt = Console.ReadLine();
                    personobj.addAmt(Convert.ToInt32(amt));
                    Console.WriteLine("Available balance is " + personobj.getAmt());
                    break;
                case "2":
                    Console.WriteLine("Please enter the amt to be withdrawn from " + personobj.name + " account");
                    amt = Console.ReadLine();
                    if (Convert.ToInt32(personobj.getAmt()) > Convert.ToInt32(amt))
                    {
                        personobj.removeAmt(Convert.ToInt32(amt));
                        Console.WriteLine("Available balance is " + personobj.getAmt());
                    }
                    else {
                        Console.WriteLine("Insuffecient balance to perform the operation");
                    }
                    break;
                case "3":
                    Console.WriteLine("Available balance is " + personobj.getAmt());
                    break;
                case "4":
                 
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the program \n");
            bool repeatprogram = true;
            while (repeatprogram)
            {
                Console.WriteLine(
                "Please select the person \n" +
                "1 Rishabh \n" +
                "2 Aman \n" +
                "3 Exit");

                Person rishabh = new Person();
                Person aman = new Person();
                string selectPerson = Console.ReadLine();
                int selectPersonVal = Convert.ToInt32(selectPerson);
                switch (selectPersonVal)
                {
                    case 1:
                        Console.WriteLine("You have selected rishabh");
                        personOpn(rishabh);
                        break;
                    case 2:
                        Console.WriteLine("You have selected rishabh");
                        personOpn(rishabh);
                        break;
                    case 3:
                        repeatprogram = false;
                        break;
                    default:
                        Console.WriteLine("You have entered wrong choise");
                        break;
                }
            }
            

        }
        
    }
}
