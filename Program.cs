using System;
using System.IO;

class Program
{
   static void Main(){
       DisplayMenu();
       bool exit = false;
       while (!exit){
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice){
                case "1":
                    TrainingMenu();
                    break;
                case "2":
                    ListingMenu();
                    break;
                case "3":
                    Booking();
                    break;
                case "4":
                    Report();
                    break;

                case "5":
                   exit = true;
                   break;
                default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
            }
        }
    }

   static void DisplayMenu(){
       Console.WriteLine("Welcome to Train Like A Champion - Personal Fitness Menu: ");
       Console.WriteLine("1. Manage Trainer Data");
       Console.WriteLine("2. Manage Listing Data");
       Console.WriteLine("3. Manage Customer Booking Data");
       Console.WriteLine("4. Run Reports");
       Console.WriteLine("5. Exit");
   }
    static void TrainingMenu(){
        Console.WriteLine("Manage Training: ");
        Console.WriteLine("1. Add Trainer");
        Console.WriteLine("2. Edit Trainer");
        Console.WriteLine("3. Delete Trainer");
        Console.WriteLine("4: Exit to main menu");
        string choiceT = Console.ReadLine();
        bool exit01 = false;
    
        while (!exit01){
            switch (choiceT){
               case "1":
                   CreateTrainer();
                   break;
               case "2":
                   EditTrainer();
                   break;
               case "3":
                    DeleteTraining();
                    break;

                case "4":
                    exit01 = true;
                    Main();
                    break;
                 default:
                   Console.WriteLine("Invalid choice. Please try again.");
                   break;
            }
        }
    }    
   static void CreateTrainer(){
       Console.WriteLine("Enter Trainer ID: ");
       string trainerId = Console.ReadLine();

       Console.WriteLine("Enter Trainer Name: ");
       string trainerName = Console.ReadLine();

       Console.WriteLine("Enter Mailing Address: ");
       string mailingAddress = Console.ReadLine();

       Console.WriteLine("Enter Trainer Email Address: ");
       string trainerEmailAddress = Console.ReadLine();

       string trainerInfo = $"{trainerId}#{trainerName}#{mailingAddress}#{trainerEmailAddress}";

       using (StreamWriter sw = File.AppendText("trainers.txt"))
       {
           sw.WriteLine(trainerInfo);
       }

       Console.WriteLine("Trainer created successfully!");
       TrainingMenu();
      
   }
    static void EditTrainer(){
       Console.WriteLine("Enter the trainer ID to edit:");
       int trainerId = int.Parse(Console.ReadLine());

       List<string> lines = new List<string>();
       using (StreamReader sr = new StreamReader("trainers.txt"))
       {
           string line;
           while ((line = sr.ReadLine()) != null){
               string[] parts = line.Split('#');
               if (int.Parse(parts[0]) == trainerId){
                   Console.WriteLine($"Trainer: {parts[1]}");
                   Console.WriteLine($"Trainer Mailing Address: {parts[2]}");
                   Console.WriteLine($"Trainer Email Address: {parts[3]}");


                   Console.WriteLine("Enter the new trainer name (or press Enter to keep the current value):");
                   string newTrainerName = Console.ReadLine();
                   if (!string.IsNullOrEmpty(newTrainerName)){
                       parts[1] = newTrainerName;
                   }

                   Console.WriteLine("Enter the new mailing Address (or press Enter to keep the current value):");
                   string newMailing = Console.ReadLine();
                   if (!string.IsNullOrEmpty(newMailing)){
                       parts[2] = newMailing;
                   }

                   Console.WriteLine("Enter the new Email Address (or press Enter to keep the current value):");
                   string newEmail = Console.ReadLine();
                   if (!string.IsNullOrEmpty(newEmail)){
                       parts[3] = newEmail;
                   }
                    line = string.Join("#", parts);
                }
                lines.Add(line);
            }
        }

        using (StreamWriter sw = File.AppendText("trainers.txt")){
           sw.WriteLine(lines);
        }
        

        Console.WriteLine("Trainer edited successfully.");
        TrainingMenu();
    }
    static void DeleteTraining(){
        Console.WriteLine("Enter the trainer ID to delete:");
        string trainerId = Console.ReadLine();

        List<string> lines = new List<string>();
        using (StreamReader sr = new StreamReader("trainers.txt"))
        {
            string line;
            while ((line = sr.ReadLine()) != null){
                if ((line.Split('#')[0]) != trainerId){
                    lines.Add(line);
                }
            }
        }

        using (StreamWriter sw = new StreamWriter("trainers.txt"))
        {
            foreach (string line in lines){
                sw.WriteLine(line);
            }
        }

        Console.WriteLine("Trainer deleted successfully.");
        TrainingMenu();
    }

    static void ListingMenu(){
        Console.WriteLine("Manage Listing: ");
        Console.WriteLine("1. Add Listing");
        Console.WriteLine("2. Edit Listing");
        Console.WriteLine("3. Delete Listing");
        Console.WriteLine("4. View Listing");
        Console.WriteLine("5: Exit to main menu");
        string choiceL = Console.ReadLine();
        bool exit1 = false;
    
        while (!exit1){
            switch (choiceL)
            {
               case "1":
                   AddListing();
                   break;
               case "2":
                   EditListing();// Implement other menu options (e.g., edit, delete, manage listing data, manage customer booking data, run reports)
                   break;
               case "3":
                    DeleteListing();
                    break;
                case "4":
                    ViewListings();
                    break;
                case "6":
                    exit1 = true;
                    Main();
                    break;
                 default:
                   Console.WriteLine("Invalid choice. Please try again.");
                   break;
            }
        }    

    }
    static void AddListing(){
        Console.WriteLine("Enter the listing ID:");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the trainer name:");
        string trainer = Console.ReadLine();

        Console.WriteLine("Enter the date of the session (mm/dd/yyyy):");
        DateTime date = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter the time of the session (hh:mm AM/PM):");
        DateTime time = DateTime.Parse(Console.ReadLine());

       Console.WriteLine("Enter the cost of the session:");
       decimal cost = decimal.Parse(Console.ReadLine());

       Console.WriteLine("Has the listing been taken? (Y/N):");
       bool taken = Console.ReadLine().ToLower() == "y";

       using (StreamWriter sw = File.AppendText("listings.txt"))
       {
           sw.WriteLine($"{id}#{trainer}#{date.ToString("MM/dd/yyyy")}#{time.ToString("hh:mm tt")}#{cost}#{taken}");
       }

       Console.WriteLine("Listing added successfully.");
       ListingMenu();
    }

   static void EditListing(){
       Console.WriteLine("Enter the listing ID to edit:");
       int id = int.Parse(Console.ReadLine());

       List<string> lines = new List<string>();
       using (StreamReader sr = new StreamReader("listings.txt"))
       {
           string line;
           while ((line = sr.ReadLine()) != null){
               string[] parts = line.Split('#');
               if (int.Parse(parts[0]) == id){
                   Console.WriteLine($"Trainer: {parts[1]}");
                   Console.WriteLine($"Date: {parts[2]}");
                   Console.WriteLine($"Time: {parts[3]}");
                   Console.WriteLine($"Cost: {parts[4]}");
                   Console.WriteLine($"Taken: {parts[5]}");

                   Console.WriteLine("Enter the new trainer name (or press Enter to keep the current value):");
                   string newTrainer = Console.ReadLine();
                   if (!string.IsNullOrEmpty(newTrainer)){
                       parts[1] = newTrainer;
                   }

                   Console.WriteLine("Enter the new date of the session (mm/dd/yyyy) (or press Enter to keep the current value):");
                   string newDate = Console.ReadLine();
                   if (!string.IsNullOrEmpty(newDate)){
                       parts[2] = newDate;
                   }

                   Console.WriteLine("Enter the new time of the session (hh:mm AM/PM) (or press Enter to keep the current value):");
                   string newTime = Console.ReadLine();
                   if (!string.IsNullOrEmpty(newTime)){
                       parts[3] = newTime;
                   }

                   Console.WriteLine("Enter the new cost of the session (or press Enter to keep the current value):");
                   string newCost = Console.ReadLine();
                   if (!string.IsNullOrEmpty(newCost)){
                        parts[4] = newCost;
                    }

                

                    Console.WriteLine("Has the listing been taken? (Y/N) (or press Enter to keep the current value):");
                    string newTaken = Console.ReadLine().ToLower();
                    if (!string.IsNullOrEmpty(newTaken)){
                        parts[5] = newTaken == "y" ? "true" : "false";
                    }

                    line = string.Join("#", parts);
                }
                lines.Add(line);
            }
        }

        using (StreamWriter sw = new StreamWriter("listings.txt")){
            foreach (string line in lines){
                sw.WriteLine(line);
            }
        }

        Console.WriteLine("Listing edited successfully.");
        ListingMenu();
    }

    static void DeleteListing(){
        Console.WriteLine("Enter the listing ID to delete:");
        int id = int.Parse(Console.ReadLine());

        List<string> lines = new List<string>();
        using (StreamReader sr = new StreamReader("listings.txt")){
            string line;
            while ((line = sr.ReadLine()) != null){
                if (int.Parse(line.Split('#')[0]) != id){
                    lines.Add(line);
                }
            }
        }

        using (StreamWriter sw = new StreamWriter("listings.txt")){
            foreach (string line in lines){
                sw.WriteLine(line);
            }
        }

        Console.WriteLine("Listing deleted successfully.");
        ListingMenu();
    }

    static void ViewListings(){
        using (StreamReader sr = new StreamReader("listings.txt"))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split('#');
                Console.WriteLine($"ID: {parts[0]}");
                Console.WriteLine($"Trainer: {parts[1]}");
                Console.WriteLine($"Date: {parts[2]}");
                Console.WriteLine($"Time: {parts[3]}");
                Console.WriteLine($"Cost: {parts[4]}");
                Console.WriteLine($"Taken: {parts[5]}");
                Console.WriteLine();
                ListingMenu();
            }
        }
    }
  


   private const string listingsFile = "listings.txt";
   private const string transactionsFile = "transactions.txt";

   public static void Booking()
   {
       bool exit = false;
       while (!exit)
       {
           Console.WriteLine("Welcome to Train Like A Champion - Booking System");
           Console.WriteLine("1. View available training sessions");
           Console.WriteLine("2. Book a session");
           Console.WriteLine("3. Exit");
           Console.Write("Please enter your choice: ");
           string choice = Console.ReadLine();

           switch (choice)
           {
               case "1":
                   ViewAvailableSessions();
                   break;
               case "2":
                   BookSession();
                   break;
               case "3":
                   exit = true;
                   break;
               default:
                   Console.WriteLine("Invalid choice. Please try again.");
                   break;
           }
       }
   }

   private static void ViewAvailableSessions()
   {
       if (File.Exists(listingsFile))
       {
           string[] sessions = File.ReadAllLines(listingsFile);
           Console.WriteLine("Available training sessions:");
           foreach (string session in sessions)
           {
               Console.WriteLine(session);
           }
       }
       else{
           Console.WriteLine("No training sessions available.");
       }
   }

   private static void BookSession(){
       Console.Write("Enter the session ID: ");
       string sessionId = Console.ReadLine();

       Console.Write("Enter the customer name: ");
       string customerName = Console.ReadLine();

       Console.Write("Enter the customer email: ");
       string customerEmail = Console.ReadLine();

       Console.Write("Enter the training date: ");
       string trainingDate = Console.ReadLine();

       Console.Write("Enter the trainer ID: ");
       string trainerId = Console.ReadLine();

       Console.Write("Enter the trainer name: ");
       string trainerName = Console.ReadLine();

       string transactionData = $"{sessionId}#{customerName}#{customerEmail}#{trainingDate}#{trainerId}#{trainerName}#booked";

       try{
           using (StreamWriter sw = File.AppendText(transactionsFile))
           {
               sw.WriteLine(transactionData);
           }
           Console.WriteLine("Session booked successfully.");
       }
       catch (Exception ex){
           Console.WriteLine($"An error occurred while booking the session: {ex.Message}");
       }
   }

    static void Report(){
        while (true){
            Console.WriteLine("Select a report to generate:");
            Console.WriteLine("1. Individual Customer Sessions");
            Console.WriteLine("2. Historical Customer Sessions");
            Console.WriteLine("3. Historical Revenue Report");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice){
                case "1":
                    GenerateIndividualCustomerSessionsReport();
                    break;
                case "2":
                    GenerateHistoricalCustomerSessionsReport();
                    break;
                case "3":
                    GenerateHistoricalRevenueReport();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void GenerateIndividualCustomerSessionsReport(){
        Console.WriteLine("Enter customer email:");
        string email = Console.ReadLine();

        var sessions = File.ReadAllLines("transactions.txt")
            .Select(line => line.Split(','))
                .Where(parts => parts[2] == email)
                .Select(parts => new
                {
                    SessionId = parts[0],
                    CustomerName = parts[1],
                    CustomerEmail = parts[2],
                    TrainingDate = DateTime.Parse(parts[3]),
                    TrainerId = parts[4],
                    TrainerName = parts[5]
                })
                .OrderBy(session => session.TrainingDate);

            Console.WriteLine($"Individual Customer Sessions for {email}");
            foreach (var session in sessions)
            {
                Console.WriteLine($"Session ID: {session.SessionId}");
                Console.WriteLine($"Training Date: {session.TrainingDate}");
                Console.WriteLine($"Trainer Name: {session.TrainerName}");
                Console.WriteLine();
            }

            SaveReportToFile(sessions);
        }

        static void GenerateHistoricalCustomerSessionsReport()
        {
            var sessions = File.ReadAllLines("transactions.txt")
                .Select(line => line.Split(','))
                .Select(parts => new
                {
                    SessionId = parts[0],
                    CustomerName = parts[1],
                    CustomerEmail = parts[2],
                    TrainingDate = DateTime.Parse(parts[3]),
                    TrainerId = parts[4],
                    TrainerName = parts[5]
                })
                .OrderBy(session => session.CustomerName)
                .ThenBy(session => session.TrainingDate);

            Console.WriteLine("Historical Customer Sessions");
            string currentCustomer = null;
            int totalSessions = 0;
            foreach (var session in sessions)
            {
                if (session.CustomerName != currentCustomer)
                {
                    if (currentCustomer != null)
                    {
                        Console.WriteLine($"Total sessions for {currentCustomer}: {totalSessions}");
                        Console.WriteLine();
                    }

                    Console.WriteLine($"Customer Name: {session.CustomerName}");
                    currentCustomer = session.CustomerName;
                    totalSessions = 0;
                }

                Console.WriteLine($"Session ID: {session.SessionId}");
                Console.WriteLine($"Training Date: {session.TrainingDate}");
                Console.WriteLine($"Trainer Name: {session.TrainerName}");
                Console.WriteLine();
                totalSessions++;
            }

            Console.WriteLine($"Total sessions for {currentCustomer}: {totalSessions}");
            Console.WriteLine();

            SaveReportToFile(sessions);
        }

        static void GenerateHistoricalRevenueReport()
        {
            var sessions = File.ReadAllLines("transactions.txt")
                .Select(line => line.Split(','))
                .Select(parts => new
                {
                    SessionId = parts[0],
                CustomerName = parts[1],
                CustomerEmail = parts[2],
                TrainingDate = DateTime.Parse(parts[3]),
                TrainerId = parts[4],
                TrainerName = parts[5]
            })
            .OrderBy(session => session.TrainingDate);

        var revenueByMonth = sessions
            .GroupBy(session => new { session.TrainingDate.Year, session.TrainingDate.Month })
            .Select(group => new
            {
                Year = group.Key.Year,
                Month = group.Key.Month,
                Revenue = group.Count() 
            })
            .OrderBy(report => report.Year)
            .ThenBy(report => report.Month);

        Console.WriteLine("Historical Revenue Report");
        foreach (var report in revenueByMonth)
        {
            Console.WriteLine($"Year: {report.Year}, Month: {report.Month}, Revenue: ${report.Revenue}");
        }

        SaveReportToFile(revenueByMonth);
    }

    static void SaveReportToFile<T>(IEnumerable<T> data)
    {
        Console.WriteLine("Do you want to save the report to a file? (Y/N)");
        string choice = Console.ReadLine();

        if (choice.ToLower() == "y")
        {
            Console.WriteLine("Enter file name:");
            string fileName = Console.ReadLine();

            using (var writer = new StreamWriter(fileName))
            {
                foreach (var item in data)
                {
                    writer.WriteLine(item.ToString());
                }
            }

            Console.WriteLine($"Report saved to {fileName}");
        }
    }
}