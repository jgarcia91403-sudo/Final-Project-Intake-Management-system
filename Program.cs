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
            do
            {
                Console.WriteLine("\n==== JOB APPLICANT INTAKE SYSTEM ====");
                Console.WriteLine("1. Add New Record");
                Console.WriteLine("2. View All Records");
                Console.WriteLine("3. Search Records");
                Console.WriteLine("4. Display Summary Statistics");
                Console.WriteLine("5. Exit");
                Console.Write("Enter Choice: ");
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
                        SearchOption();
                        break;
                    case 4:
                        DisplaySummary();
                        break;
                    case 5:
                        Console.WriteLine(" Exiting Program...");
                        break;
                    default:
                        Console.WriteLine("Invalid menu option."),
                            break;
                }
            } while (choice != 5);
        }
    }
}
