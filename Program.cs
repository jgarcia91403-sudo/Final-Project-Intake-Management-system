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
        public string postiionApplied;
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
                    positionApplied = "IT Support";
                    break;
                    default;
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
            {

            }
            {

            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
