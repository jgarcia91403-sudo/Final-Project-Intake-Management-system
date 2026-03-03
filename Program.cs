using System;
using System.Collections.Generic;
namespace Final_Project_Intake_Management_system
{
    class Applicant
    {
        public string FirstName;
        public string LastName;
        public string Email;
        public string Phone;
        public string City;
        public string PositionApplied;
        public string EducationLevel;

        public int Age;
        public int YearsExperience;
        public int ExpectedSalary;
        public double TechnicalScore;
        public double CommunicatinScore;
        public double CultureFitScore;
        public double OverallScore;
        public int ApplicationID;

        public bool HasDegree;
        public bool IsWillingToRelocate;
        public bool HasCertifications;
        public bool EligibleForInterview;

        public int PositionChoice;
        public int EmploymentTypeChoice;
        public string EmploymentType;

        public DateTime ApplicationDate;
        public string ExperienceLevel;
        public string salaryCategory;

        public Applicant(int id, string first,string last, string email, string phone, string city, int age, int yearsExp, int salary, double tech, double comm, double culture, bool degree, bool relocate, bool certs, int positionChoice, int employmentChoice)
        {
            ApplicationID = id;
            FirstName = first;
            LastName = last;
            Email = email;
            Phone = phone;
            City = city;
            Age = age;
            YearsExperience = yearsExp;
            ExpectedSalary = salary;
            TechnicalScore = tech;
            CommunicatinScore = comm;
            CultureFitScore = culture;
            HasDegree = degree;
            IsWillingToRelocate = relocate;
            HasCertifications = certs;
            PositionChoice = positionChoice;
            EmploymentTypeChoice = employmentChoice;
            ApplicationDate = DateTime.Now;
            SetSelections();
            CalculateDerivedFields();

        }
        public void SetSelections()
        {
            switch (PositionChoice)
            {
                case 1:
                    PositionApplied = "Software Developer";
                    break;
                case 2:
                    PositionApplied = "Data Analyst";
                    break;
                case 3:
                    PositionApplied = "IT Support";
                    break;
                default:
                    PositionApplied = "Unknown";
                    break;
            }
            switch (EmploymentTypeChoice)
            {
                case 1:
                    EmploymentType = "Full-Time";
                    break;
                case 2:
                    EmploymentType = "Part-Time";
                    break;
                case 3:
                    EmploymentType = "Contract";
                    break;
                default:
                    EmploymentType = "Unknown";
                    break;
            }
        }
        public void CalculateDerivedFields()
        {
            OverallScore = (TechnicalScore + CommunicatinScore + CultureFitScore) / 3;
            if (YearsExperience >= 5)
                ExperienceLevel = "Senior";
            else if (YearsExperience >= 2)
                ExperienceLevel = "Mid-Level";
            else
                ExperienceLevel = "Entry-Level";
            if (ExpectedSalary > 100000)
                salaryCategory = "High";
            else if (ExpectedSalary > 60000)
                salaryCategory = "Medium";
            else
                salaryCategory = "Low";
            if ((OverallScore >= 75 && HasDegree) || HasCertifications)
                EligibleForInterview = true;
            else
                EligibleForInterview = false;
        }
        public void Display()
        {
            Console.WriteLine();
            Console.WriteLine($"ID: {ApplicationID}");
            Console.WriteLine($"Name: {FirstName} {LastName}");
            Console.WriteLine($"Position: {PositionApplied}");
            Console.WriteLine($"Experience Level: {ExperienceLevel}");
            Console.WriteLine($"Overall Score: {OverallScore:F2}");
            Console.WriteLine($"Eligible: {EligibleForInterview}");
            Console.WriteLine();
        }
    }
    internal class Program
    {
        static List<Applicant> applicants = new List<Applicant>();
        static int idCounter = 1;
        static void Main(string[] args)
        {
            int choice = 0;
                Console.WriteLine("\n==== JOB APPLICANT INTAKE SYSTEM ====");
                Console.WriteLine("1. Add New Record");
                Console.WriteLine("2. View All Records");
                Console.WriteLine("3. Search Records");
                Console.WriteLine("4. Display Summary Statistics");
                Console.WriteLine("5. Exit");
            do
            {
                Console.Write("Enter Choice: ");
                Console.WriteLine();
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        AddApplicant();
                        break;
                    case 2:
                        ViewAll();
                        break;
                    case 3:
                        Search();
                        break;
                    case 4:
                        DisplaySummary();
                        break;
                    case 5:
                        Console.WriteLine(" Exiting Program...");
                        break;
                    default:
                        Console.WriteLine("Invalid menu option.");
                            break;
                }
            } while (choice != 5);
            static void AddApplicant()
            {
                try
                {
                Console.Write("First Name:");
                string first = Console.ReadLine();
                Console.Write("Last Name:");
                string last = Console.ReadLine();
                    Console.Write("Email:");
                    string email = Console.ReadLine();
                    Console.Write("Phone:");
                    string phone = Console.ReadLine();
                    Console.Write("City:");
                    string city = Console.ReadLine();
                    Console.Write("Age:");
                    int age = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Years Experience:");
                    int yearsExp = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Expected Salary:");
                    int salary = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Technical score:");
                    double tech = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Communication Score:");
                    double comm = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Culture Fit Score:");
                    double culture = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Has Degree (true/false):");
                    bool degree = Convert.ToBoolean(Console.ReadLine());
                    Console.Write("Willing to Relocate (true/false):");
                    bool relocate = Convert.ToBoolean(Console.ReadLine());
                    Console.Write("Has Certifications (true/false):");
                    bool certs = Convert.ToBoolean(Console.ReadLine());
                    Console.WriteLine("Position: 1-Developer, 2-Analyst, 3-IT Support");
                    int positionChoice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Employment Type:");
                    int employmentChoice = Convert.ToInt32(Console.ReadLine());
                    Applicant app = new Applicant(idCounter++, first, last, email, phone, city, age, yearsExp, salary, tech, comm, culture, degree, relocate, certs, positionChoice, employmentChoice);
                    applicants.Add(app);
                    Console.WriteLine("Applicant successfully added!");
                }
                catch
                {
                    Console.WriteLine("Invalid input detected. Record not added.");
                }
            }
            static void ViewAll()
            {
                if (applicants.Count == 0)
                {
                    Console.WriteLine("No Records Available.");
                    return;
                }
                foreach (Applicant app in applicants)
                {
                    app.Display();
                }
            }
            static void Search()
            {
                Console.WriteLine("Enter last name to search:");
                string search = Console.ReadLine().ToLower();
                bool found = false;
                foreach (Applicant app in applicants)
                {
                    if (app.LastName.ToLower() == search)
                    {
                        app.Display();
                        found = true;
                    }
                }
                if (!found)
                    Console.WriteLine("No matching records found.");
            }
            static void DisplaySummary()
            {
                if (applicants.Count == 0)
                {
                    Console.WriteLine("No records available.");
                    return;
                }
                double totalExperience = 0;
                double totalScore = 0;
                int eligibleCount = 0;
                foreach (Applicant app in applicants)
                {
                    totalExperience += app.YearsExperience;
                    totalScore += app.OverallScore;
                    if (app.EligibleForInterview)
                        eligibleCount++;
                }
                Console.WriteLine("==== SUMMARY ====");
                Console.WriteLine($"Total Applicants: {applicants.Count}");
                Console.WriteLine($"Average Experience: {totalExperience}");
                Console.WriteLine($"Average Overall Score: {totalScore / applicants.Count:F2}");
                Console.WriteLine($"Eligible Percentage: {(eligibleCount * 100.0) / applicants.Count:F2}%");
            }
        }
    }
}
