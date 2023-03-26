using System.Reflection.Metadata;

namespace CabInvoiceGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InvoiceGenerator invoiceGeneratorNORM = new InvoiceGenerator(RideType.NORMAL);
            InvoiceGenerator invoiceGeneratorPRIME = new InvoiceGenerator(RideType.PREMIUM);
            InvoiceSummary totalFare = null;

            bool flag = true;

            while(flag)
            {
                Console.WriteLine("Welcome to Cab Invoice Generator\n");
                Console.WriteLine("1 : Total Fare NORMAL and PREMIUM");
                Console.WriteLine("2 : Total Fare For Multiple Rides NORMAL and PREMIUM");
                Console.WriteLine("3 : Invoice Summery for user id NORMAL and PREMIUM");
                Console.WriteLine("0 : EXIT");
                Console.Write("Enter the Option : ");
               int opt = Convert.ToInt32(Console.ReadLine());

                switch(opt)
                {
                    case 1:
                        

                        double fare = invoiceGeneratorNORM.CalculateFare(2.0, 5);

                        Console.WriteLine(" Normal Fare : " + fare);

                        fare = invoiceGeneratorPRIME.CalculateFare(2.0, 5);

                        Console.WriteLine("Premium Fare : " + fare);

                        Console.ReadKey();

                        break;
                    case 2:
                  
                        
                        Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

                        

                        totalFare = invoiceGeneratorNORM.CalculateFare(rides);

                        Console.WriteLine("\n\tFOR Normal Customer\n");
                        Console.WriteLine("\nTotal Numbers of Journey for multiple rides : " + totalFare.numberOfRides);
                        Console.WriteLine("\nTotal Fare Of Journey for multiple rides : " + totalFare.totalFare);
                        Console.WriteLine("\nTotal Averge Fare Of Journey for multiple rides : " + totalFare.averageFare);


                        totalFare = invoiceGeneratorPRIME.CalculateFare(rides);

                        Console.WriteLine("\n\tFOR Premium Customer\n");
                        Console.WriteLine("\nTotal Numbers of Journey for multiple rides : " + totalFare.numberOfRides);
                        Console.WriteLine("\nTotal Fare Of Journey for multiple rides : " + totalFare.totalFare);
                        Console.WriteLine("\nTotal Averge Fare Of Journey for multiple rides : " + totalFare.averageFare);
                        
                        Console.ReadKey();  
                        break;

                    case 3:
                        int user = 2;
                        Ride[] rides3 = { new Ride(2.0, 5), new Ride(0.1, 1), new Ride(0.4, 9), new Ride(0.14, 4) };
                        totalFare = invoiceGeneratorNORM.CalculateFare(rides3);
                        invoiceGeneratorNORM.AddRides(rides3);

                        Ride[] rides4 = { new Ride(2.0, 5), new Ride(0.1, 1), new Ride(0.4, 9), new Ride(0.14, 4) };
                        totalFare = invoiceGeneratorNORM.CalculateFare(rides4);
                        invoiceGeneratorNORM.AddRides(rides4);

                        Ride[] rides5 = { new Ride(2.0, 75), new Ride(0.1, 21), new Ride(0.4, 91), new Ride(0.14, 40) };
                        totalFare = invoiceGeneratorNORM.CalculateFare(rides5);
                        invoiceGeneratorNORM.AddRides(rides5);


                        Console.WriteLine("==== Rides Done ====");
                        invoiceGeneratorNORM.DisplayRides();
                        Console.WriteLine("====================");

                        totalFare = invoiceGeneratorNORM.GetInvoiceSummarsy(user);

                        Console.WriteLine("Total Summary of all Rides of User ID {0} is {1}",user,totalFare.GetHashCode());
                        Console.ReadKey();
                        break;

                    case 0:
                        flag= false;
                        break;
                }

            }
           
        }
    }
}