using System;
using System.Collections.Generic;

namespace CCGMS
{
    internal class StudentRecord
    {
        // A. Personal Data
        public PersonalData PersonalInfo { get; set; }

        // B. Family Data
        public FamilyData Father { get; set; }
        public FamilyData Mother { get; set; }
        public Sibling sibling { get; set; }

        // C. Educational Data
        public EducationalData Education { get; set; }

        // D. Health Data
        public HealthData Health { get; set; }

        // E. Additional Profile
        public AdditionalProfile AdditionalInfo { get; set; }

        public StudentRecord()
        {
            PersonalInfo = new PersonalData();
            Father = new FamilyData();
            Mother = new FamilyData();
            Education = new EducationalData();
            sibling = new Sibling();
            Health = new HealthData();
            AdditionalInfo = new AdditionalProfile();
        }
        public class AdminAccount
        {
            public int AdminId { get; set; }
            public string AdminName { get; set; }
            public string AdminPassword { get; set; }
        }

        public class IndividualRecord
        {
            public int StudentID { get; set; }
            public string Course { get; set; }
            public int Year { get; set; }
            public bool IsNewStudent { get; set; }
            public bool IsTransferree { get; set; }
            public bool IsReentry { get; set; }
            public bool IsShifter { get; set; }
            public int PersonalDataID { get; set; }
            public int FamilyDataID { get; set; }
            public int SiblingsID { get; set; }
            public int EducationalID { get; set; }
            public int AdditionalProfileID { get; set; }
            public int HealthDataID { get; set; }
        }


        // A. Personal Data
        public class PersonalData
        {
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string Sex { get; set; } // Add sex
            public int Age { get; set; } // Add age
            public string Nickname { get; set; }
            public string Nationality { get; set; }
            public string Citizenship { get; set; }
            public string SpouseName { get; set; } // Add spouse name
            public DateTime DateOfBirth { get; set; }
            public string PlaceOfBirth { get; set; }
            public string CivilStatus { get; set; }
            public string Religion { get; set; }
            public string ContactNumber { get; set; }
            public string CompleteHomeAddress { get; set; }
            public string BoardingHouseAddress { get; set; }
            public string LandlordName { get; set; }
            public string GuardianName { get; set; }
            public string EmergencyContact { get; set; }
            public string Hobbies { get; set; }
        }

        // B. Family Data
        public class FamilyData
        {
            public int FamilyDataId { get; set; }
            public string Parents { get; set; }
            public string Name { get; set; }
            public string TelCellNo { get; set; }
            public string Nationality { get; set; }
            public string EducationalAttainment { get; set; }
            public string Occupation { get; set; }
            public string EmployerAgency { get; set; }
            public string WorkingAbroad { get; set; }
            public string MaritalStatus { get; set; }
            public string MonthlyIncome { get; set; }
            public int NoOfChildren { get; set; }
            public int StudentsBirthOrder { get; set; }
            public string LanguageDialect { get; set; }
            public string FamilyStructure { get; set; }
            public string IndigenousGroup { get; set; }
            public string Beneficiary4Ps { get; set; }
            public string FatherStatus { get; set; } // e.g., Living Together, Separated, Father with Another Partner

            // Mother's status
            public string MotherStatus { get; set; } // e.g., Annulled, Widowed, Mother with Another Parent
        }
        public class EducationalData
        {
            public int EducationalID { get; set; }
            public string ElementaryYearGraduated { get; set; }
            public string ElementaryHonorAwards { get; set; }
            public string Elementary { get; set; }
            public string JuniorHighYearGraduated { get; set; }
            public string JuniorHighHonorAwards { get; set; }
            public string HighSchool { get; set; }
            public string SeniorHighYearGraduated { get; set; }
            public string SeniorHighHonorAwards { get; set; }
            public string SeniorHighSchool { get; set; }
            public string StrandCompleted { get; set; }
            public string VocationalTechnical { get; set; }
            public decimal? SHSAverageGrade { get; set; }
            public string CollegeIfTransferee { get; set; }
            public string FavoriteSubject { get; set; }
            public string WhyFavoriteSubject { get; set; }
            public string LeastFavoriteSubject { get; set; }
            public string WhyLeastFavoriteSubject { get; set; }
            public string SupportForStudies { get; set; }
            public string Membership { get; set; }
            public string LeftRightHanded { get; set; }
        }
        
    }
    // C. Educational Data
        
        public class Sibling
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string School { get; set; }
            public string EducationalAttainment { get; set; }
            public string EmploymentBusinessAgency { get; set; }
        }


    // D. Health Data
    public class HealthData
        {
        public int HealthDataID { get; set; }
        public string SickFrequency { get; set; }
        public string HealthProblems { get; set; }
        public string OtherHealthProblems { get; set; }
        public string PhysicalDisabilities { get; set; }
        public string OtherPhysicalDisabilities { get; set; }
    }

    // E. Additional Profile
    public class AdditionalProfile
    {
        public string GenderIdentity { get; set; }
        public string GenderExpression { get; set; }
        public string GenderSexuallyAttracted { get; set; }
        public bool HasScholarship { get; set; }
        public string ScholarshipName { get; set; }
    }

}

