using System;

namespace DeviceInsuranceCalculator
{
    class Program
    {
        // Methods and functions
        // Ask user if input is correct if not prints error and ask user if they want to add another device or exit
        static string CheckProceed()
        {
            while (true)
            {
                Console.WriteLine("Press <ENTER> to add another device or type 'x' to exit");
                string CheckProceed = Console.ReadLine();

                CheckProceed = CheckProceed.ToUpper();

                if (CheckProceed.Equals("") || CheckProceed.Equals("X"))
                {
                    return CheckProceed;
                }
                Console.WriteLine("Error Invalid Choice");
            }
            
            


        }
        
        static void OneDevice()
        {

            // Lets user choose device category
            List<string> CATEGORY = new List<string>()
            {
                    "Desktop", "Laptop", "Phone/Drone"
            };
            CATEGORY.AsReadOnly();

            int deviceType = CheckInt("Choose a device type:\n" +
                $"1 = {CATEGORY[0]}\n" +
                $"2 = {CATEGORY[1]}\n" +
                $"3 = {CATEGORY[2]}\n", 1, 3);



            Console.WriteLine($"Enter the name of the device:\n");
                string deviceName = Console.ReadLine();

                    
              
                float Cost = CheckFloat($"Enter the cost of the device {deviceName}:\n", 1f, 10000f);
                  

                float quantity = CheckFloat($"Enter the quantity of {deviceName} to insure:\n",1f, 10000f);





                // Calculate total insurance cost
                float totalInsuranceCost = InsureDevice(quantity, Cost);
                Console.WriteLine(totalInsuranceCost);

                // Print insurance cost for each month
                Console.WriteLine($"Insurance cost breakdown for {quantity} {deviceName} over 6 months:");

                   

                for (int i = 0; i < 6; i++)
                {
                    Cost -= Cost * 0.05f;
                    Console.WriteLine($"\tMonth {i + 1}: ${Cost:F2}");
                }

                
                
            

        }
        //This check if user enters within parameter if not it errors
        static float CheckFloat(string question, float min, float max)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(question);
                    float cost = float.Parse(Console.ReadLine());


                    if (cost >= min && cost <= max)
                    {
                        return cost;


                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(($"ERROR: You must enter an integer between {1} and {10000}"));
                    Console.ForegroundColor = ConsoleColor.DarkGreen;


                }

                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ERROR: You Must Enter a number between 1-10,000");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;


                }
            }

        }
        //Check if user enter in parameter if not error
        static int CheckInt(string question, int min, int max)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(question);
                    int userInt = int.Parse(Console.ReadLine());


                    if (userInt >= min && userInt <= max)
                    {
                        return userInt;

                        
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(($"ERROR: You must enter an integer between {1} and {3}"));
                    Console.ForegroundColor = ConsoleColor.DarkGreen;


                }

                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ERROR: You Must Enter a number between 1-3");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;


                }
            }

        }
        //Insure device check if user has more than 5 as well gives discounted rate
        static float InsureDevice(float quantity, float Cost)
        {
            float deviceInsurance = 0;

            if (quantity < 6)
            {
                deviceInsurance = quantity * Cost;

            }
            else
            {
                deviceInsurance = (quantity - 5) * Cost * 0.90f;
                deviceInsurance += 5 * Cost;
                
            }
            return deviceInsurance;



        }



        // Main process or when run

        static void Main(string[] args)
        {


            Console.ForegroundColor = ConsoleColor.DarkGreen;
            // Display app title
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n    ____            _              ____                                               ______      __           __      __            \n   / __ \\___ _   __(_)_______     /  _/___  _______  ___________ _____  ________     / ____/___ _/ /______  __/ /___ _/ /_____  _____\n  / / / / _ \\ | / / / ___/ _ \\    / // __ \\/ ___/ / / / ___/ __ `/ __ \\/ ___/ _ \\   / /   / __ `/ / ___/ / / / / __ `/ __/ __ \\/ ___/\n / /_/ /  __/ |/ / / /__/  __/  _/ // / / (__  ) /_/ / /  / /_/ / / / / /__/  __/  / /___/ /_/ / / /__/ /_/ / / /_/ / /_/ /_/ / /    \n/_____/\\___/|___/_/\\___/\\___/  /___/_/ /_/____/\\__,_/_/   \\__,_/_/ /_/\\___/\\___/   \\____/\\__,_/_/\\___/\\__,_/_/\\__,_/\\__/\\____/_/     \n                                                                                                                                     \n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            // Welcome the user
            Console.WriteLine("Welcome to the Device Insurance Calculator!\n");

            string proceed = "";

            while (proceed.Equals(""))
            {
                OneDevice();
  
                proceed = CheckProceed();
            }
            
        }


    }
}
