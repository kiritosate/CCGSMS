using CCGMS.methods;
using DocumentFormat.OpenXml.Bibliography;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CCGMS.StudentRecord;


namespace CCGMS.view
{
    public partial class enrollment : Form
    {
        private List<TextBox> siblingNameTextBoxes = new List<TextBox>();
        private List<TextBox> siblingAgeTextBoxes = new List<TextBox>();
        // Add more lists as needed for other fields
        private int SiblingCount = 0; // Initialize counter
        private IndividualRecord individualRecord;

        private void SaveFamilyData(StudentRecord record)
        {
                int familyId;
            
                using (var connection = MyCon.GetConnection())
                {
                    connection.Open();

                    // Save Father's Data
                    string fatherQuery = @"INSERT INTO tbl_family_data (Sub_Id,
            Parents_Name, Tel_Cell_No, Nationality, Educational_Attainment, Occupation, 
            Employer_Agency, Working_Abroad, Marital_Status, Monthly_Income, 
            No_of_Children, Students_Birth_Order, Language_Dialect, 
            Family_Structure, Indigenous_Group, Beneficiary_4Ps) 
            VALUES (@Sub_Id,@Parents, @Name, @Tel_Cell_No, @Nationality, @Educational_Attainment, 
            @Occupation, @Employer_Agency, @Working_Abroad, @Marital_Status, 
            @Monthly_Income, @No_of_Children, @Students_Birth_Order, @Language_Dialect, 
            @Family_Structure, @Indigenous_Group, @4Ps_Beneficiary);";

                    using (var command = new MySqlCommand(fatherQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Sub_Id", individualRecord.StudentID);
                        command.Parameters.AddWithValue("@Parents_Name", record.Father.Name);
                        command.Parameters.AddWithValue("@Tel_Cell_No", record.Father.TelCellNo);
                        command.Parameters.AddWithValue("@Nationality", record.Father.Nationality);
                        command.Parameters.AddWithValue("@Educational_Attainment", record.Father.EducationalAttainment);
                        command.Parameters.AddWithValue("@Occupation", record.Father.Occupation);
                        command.Parameters.AddWithValue("@Employer_Agency", record.Father.EmployerAgency);
                        command.Parameters.AddWithValue("@Working_Abroad", record.Father.WorkingAbroad);
                        command.Parameters.AddWithValue("@Marital_Status", record.Father.MaritalStatus);
                        command.Parameters.AddWithValue("@Monthly_Income", record.Father.MonthlyIncome);
                        command.Parameters.AddWithValue("@No_of_Children", record.Father.NoOfChildren);
                        command.Parameters.AddWithValue("@Students_Birth_Order", record.Father.StudentsBirthOrder);
                        command.Parameters.AddWithValue("@Language_Dialect", record.Father.LanguageDialect);
                        command.Parameters.AddWithValue("@Family_Structure", record.Father.FamilyStructure);
                        command.Parameters.AddWithValue("@Indigenous_Group", record.Father.IndigenousGroup);
                        command.Parameters.AddWithValue("@4Ps_Beneficiary", record.Father.Beneficiary4Ps);

                        command.ExecuteNonQuery();
                    }


                // Save Mother's Data
                string motherQuery = @"INSERT INTO tbl_family_data (Sub_Id
            Parents_Name, Tel_Cell_No, Nationality, Educational_Attainment, Occupation, 
            Employer_Agency, Working_Abroad, Marital_Status, Monthly_Income, 
            No_of_Children, Students_Birth_Order, Language_Dialect, 
            Family_Structure, Indigenous_Group, Beneficiary_4Ps) 
            VALUES (@Sub_Id,@Parents, @Name, @Tel_Cell_No, @Nationality, @Educational_Attainment, 
            @Occupation, @Employer_Agency, @Working_Abroad, @Marital_Status, 
            @Monthly_Income, @No_of_Children, @Students_Birth_Order, @Language_Dialect, 
            @Family_Structure, @Indigenous_Group, @4Ps_Beneficiary);";

                    using (var command = new MySqlCommand(motherQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Sub_Id", individualRecord.StudentID);
                        command.Parameters.AddWithValue("@Parents_Name", record.Mother.Name);
                        command.Parameters.AddWithValue("@Tel_Cell_No", record.Mother.TelCellNo);
                        command.Parameters.AddWithValue("@Nationality", record.Mother.Nationality);
                        command.Parameters.AddWithValue("@Educational_Attainment", record.Mother.EducationalAttainment);
                        command.Parameters.AddWithValue("@Occupation", record.Mother.Occupation);
                        command.Parameters.AddWithValue("@Employer_Agency", record.Mother.EmployerAgency);
                        command.Parameters.AddWithValue("@Working_Abroad", record.Mother.WorkingAbroad);
                        command.Parameters.AddWithValue("@Marital_Status", record.Mother.MaritalStatus);
                        command.Parameters.AddWithValue("@Monthly_Income", record.Mother.MonthlyIncome);
                        command.Parameters.AddWithValue("@No_of_Children", record.Mother.NoOfChildren);
                        command.Parameters.AddWithValue("@Students_Birth_Order", record.Mother.StudentsBirthOrder);
                        command.Parameters.AddWithValue("@Language_Dialect", record.Mother.LanguageDialect);
                        command.Parameters.AddWithValue("@Family_Structure", record.Mother.FamilyStructure);
                        command.Parameters.AddWithValue("@Indigenous_Group", record.Mother.IndigenousGroup);
                        command.Parameters.AddWithValue("@4Ps_Beneficiary", record.Mother.Beneficiary4Ps);

                        command.ExecuteNonQuery();
                    }

                using (var command = new MySqlCommand("SELECT LAST_INSERT_ID();", connection))
                {
                    individualRecord.FamilyDataID = Convert.ToInt32(command.ExecuteScalar());
                }  
            }
        }
        private void SaveSiblingData(StudentRecord record)
        {

            using (var connection = MyCon.GetConnection())
            {
                connection.Open();
                string query = @"INSERT INTO tbl_brothers_sisters (Sub_Id, Name, Age, School, Educational_Attainment, Employment_Business_Agency) 
                         VALUES (@Name, @Age, @School, @EducationalAttainment, @EmploymentBusinessAgency);";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Sub_Id", individualRecord.StudentID);
                    command.Parameters.AddWithValue("@Name", record.sibling.Name);
                    command.Parameters.AddWithValue("@Age", record.sibling.Age);
                    command.Parameters.AddWithValue("@School", record.sibling.School);
                    command.Parameters.AddWithValue("@EducationalAttainment", record.sibling.EducationalAttainment);
                    command.Parameters.AddWithValue("@EmploymentBusinessAgency", record.sibling.EmploymentBusinessAgency);

                    command.ExecuteNonQuery();
                }
                
                using (var command = new MySqlCommand("SELECT LAST_INSERT_ID();", connection))
                {
                    individualRecord.SiblingsID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        private void SaveStudentRecord(StudentRecord record)
        {

            using (var connection = MyCon.GetConnection())
            {
                connection.Open();

                string query = @"INSERT INTO tbl_personal_data (
            Firstname, Middlename, Lastname, Sex, Age, Nickname, Nationality, 
            Citizenship, Date_of_Birth, Place_of_Birth, Civil_status, Spouse_Name, 
            Religion, Contact_No, Complete_Home_Address, Boarding_House_Address, 
            Landlord_Name, Person_to_contact, EmergencyContact, Hobbies_Skills_Talents) 
            VALUES (@StudentId, @Course, @Year, @IsNewStudent, @IsTransferee, @IsReEntry, @IsShifter,
            @Firstname, @Middlename, @Lastname, @Sex, @Age, @Nickname, @Nationality, 
            @Citizenship, @DateOfBirth, @PlaceOfBirth, @Civil_status, @Spouse_Name, 
            @Religion, @Contact_No, @CompleteHomeAddress, @BoardingHouseAddress, 
            @LandlordName, @GuardianName, @EmergencyContact, @Hobbies);";

                using (var command = new MySqlCommand(query, connection))
                {
                    // Parameter assignments for existing fields
                    command.Parameters.AddWithValue("@Firstname", record.PersonalInfo.FirstName);
                    command.Parameters.AddWithValue("@Middlename", record.PersonalInfo.MiddleName);
                    command.Parameters.AddWithValue("@Lastname", record.PersonalInfo.LastName);
                    command.Parameters.AddWithValue("@Sex", record.PersonalInfo.Sex);
                    command.Parameters.AddWithValue("@Age", record.PersonalInfo.Age);
                    command.Parameters.AddWithValue("@Nickname", record.PersonalInfo.Nickname);
                    command.Parameters.AddWithValue("@Nationality", record.PersonalInfo.Nationality);
                    command.Parameters.AddWithValue("@Citizenship", record.PersonalInfo.Citizenship);
                    command.Parameters.AddWithValue("@DateOfBirth", record.PersonalInfo.DateOfBirth);
                    command.Parameters.AddWithValue("@PlaceOfBirth", record.PersonalInfo.PlaceOfBirth);
                    command.Parameters.AddWithValue("@Civil_status", record.PersonalInfo.CivilStatus);
                    command.Parameters.AddWithValue("@Spouse_Name", record.PersonalInfo.SpouseName);
                    command.Parameters.AddWithValue("@Religion", record.PersonalInfo.Religion);
                    command.Parameters.AddWithValue("@Contact_No", record.PersonalInfo.ContactNumber);
                    command.Parameters.AddWithValue("@CompleteHomeAddress", record.PersonalInfo.CompleteHomeAddress);
                    command.Parameters.AddWithValue("@BoardingHouseAddress", record.PersonalInfo.BoardingHouseAddress);
                    command.Parameters.AddWithValue("@LandlordName", record.PersonalInfo.LandlordName);
                    command.Parameters.AddWithValue("@GuardianName", record.PersonalInfo.GuardianName);
                    command.Parameters.AddWithValue("@EmergencyContact", record.PersonalInfo.EmergencyContact);
                    command.Parameters.AddWithValue("@Hobbies", record.PersonalInfo.Hobbies);

                    command.ExecuteNonQuery();
                    
                }

                using (var command = new MySqlCommand("SELECT LAST_INSERT_ID();", connection))
                {
                    individualRecord.PersonalDataID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            
            
        }

        private void SaveEducationalRecord(EducationalData Education)
        {

            using (var connection = MyCon.GetConnection())
            {
                connection.Open();

                string query = @"INSERT INTO tbl_educational_data (
             Elementary_Year_Graduated, Elementary_Honor_Awards, Elementary, 
            JuniorHigh_Year_Graduated, JuniorHigh_Honor_Awards, High_School, 
            SeniorHigh_Year_Graduated, SeniorHigh_Honor_Awards, Senior_High_School, 
            Strand_Completed, Vocational_Technical, SHS_Average_Grade, 
            College_if_transferee, Favorite_subject, Why_Favorite_Subject, 
            Least_Favorite_Subject, Why_Least_Favorite_Subject, 
            Support_for_Studies, Membership, Left_Right_Handed) 
            VALUES 
            ( @ElementaryYearGraduated, @ElementaryHonorAwards, @Elementary, 
            @JuniorHighYearGraduated, @JuniorHighHonorAwards, @HighSchool, 
            @SeniorHighYearGraduated, @SeniorHighHonorAwards, @SeniorHighSchool, 
            @StrandCompleted, @VocationalTechnical, @SHSAverageGrade, 
            @CollegeIfTransferee, @FavoriteSubject, @WhyFavoriteSubject, 
            @LeastFavoriteSubject, @WhyLeastFavoriteSubject, 
            @SupportForStudies, @Membership, @LeftRightHanded);";

                using (var command = new MySqlCommand(query, connection))
                {
                    // Parameter assignments for educational data fields
                    command.Parameters.AddWithValue("@ElementaryYearGraduated", Education.ElementaryYearGraduated);
                    command.Parameters.AddWithValue("@ElementaryHonorAwards", Education.ElementaryHonorAwards);
                    command.Parameters.AddWithValue("@Elementary", Education.Elementary);
                    command.Parameters.AddWithValue("@JuniorHighYearGraduated", Education.JuniorHighYearGraduated);
                    command.Parameters.AddWithValue("@JuniorHighHonorAwards", Education.JuniorHighHonorAwards);
                    command.Parameters.AddWithValue("@HighSchool", Education.HighSchool);
                    command.Parameters.AddWithValue("@SeniorHighYearGraduated", Education.SeniorHighYearGraduated);
                    command.Parameters.AddWithValue("@SeniorHighHonorAwards", Education.SeniorHighHonorAwards);
                    command.Parameters.AddWithValue("@SeniorHighSchool", Education.SeniorHighSchool);
                    command.Parameters.AddWithValue("@StrandCompleted", Education.StrandCompleted);
                    command.Parameters.AddWithValue("@VocationalTechnical", Education.VocationalTechnical);
                    command.Parameters.AddWithValue("@SHSAverageGrade", Education.SHSAverageGrade);
                    command.Parameters.AddWithValue("@CollegeIfTransferee", Education.CollegeIfTransferee);
                    command.Parameters.AddWithValue("@FavoriteSubject", Education.FavoriteSubject);
                    command.Parameters.AddWithValue("@WhyFavoriteSubject", Education.WhyFavoriteSubject);
                    command.Parameters.AddWithValue("@LeastFavoriteSubject", Education.LeastFavoriteSubject);
                    command.Parameters.AddWithValue("@WhyLeastFavoriteSubject", Education.WhyLeastFavoriteSubject);
                    command.Parameters.AddWithValue("@SupportForStudies", Education.SupportForStudies);
                    command.Parameters.AddWithValue("@Membership", Education.Membership);
                    command.Parameters.AddWithValue("@LeftRightHanded", Education.LeftRightHanded);

                    command.ExecuteNonQuery();
                }

                using (var command = new MySqlCommand("SELECT LAST_INSERT_ID();", connection))
                {
                    individualRecord.EducationalID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
        private void SaveHealthData(HealthData healthData)
        {

            using (var connection = MyCon.GetConnection())
            {
                connection.Open();

                string query = @"INSERT INTO tbl_health_data (
                                Sick_Frequency, 
                                Health_Problems, 
                                Physical_Disabilities
                            ) 
                            VALUES 
                            ( 
                                @SickFrequency, 
                                @HealthProblems, 
                                @PhysicalDisabilities
                            );";

                using (var command = new MySqlCommand(query, connection))
                {
                    // Parameter assignments for health data fields
                    command.Parameters.AddWithValue("@SickFrequency", healthData.SickFrequency);
                    command.Parameters.AddWithValue("@HealthProblems", healthData.HealthProblems);
                    command.Parameters.AddWithValue("@PhysicalDisabilities", healthData.PhysicalDisabilities);

                    command.ExecuteNonQuery();
                }

                using (var command = new MySqlCommand("SELECT LAST_INSERT_ID();", connection))
                {
                    individualRecord.HealthDataID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        private void SaveAdditionalProfile(AdditionalProfile AdditionalInfo)
        {

            using (var connection = MyCon.GetConnection())
            {
                connection.Open();

                string query = @"INSERT INTO tbl_additional_profile (
            Sexual_Preference, Expression_Present, Gender_Sexually_Attracted, 
            Scholarship, Name_of_Scholarship) 
            VALUES 
            (@GenderIdentity, @GenderExpression, @GenderSexuallyAttracted, 
            @HasScholarship, @ScholarshipName);";

                using (var command = new MySqlCommand(query, connection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@GenderIdentity", AdditionalInfo.GenderIdentity);
                    command.Parameters.AddWithValue("@GenderExpression", AdditionalInfo.GenderExpression);
                    command.Parameters.AddWithValue("@GenderSexuallyAttracted", AdditionalInfo.GenderSexuallyAttracted);
                    command.Parameters.AddWithValue("@HasScholarship", AdditionalInfo.HasScholarship);
                    command.Parameters.AddWithValue("@ScholarshipName", AdditionalInfo.ScholarshipName);

                    command.ExecuteNonQuery();
                }

                using (var command = new MySqlCommand("SELECT LAST_INSERT_ID();", connection))
                {
                    individualRecord.AdditionalProfileID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        private void SaveSiblingsData(StudentRecord record)
        {

            using (var connection = MyCon.GetConnection())
            {
                connection.Open();

                foreach (DataGridViewRow row in dgvSiblings.Rows)
                {
                    if (row.IsNewRow) continue;  // Skip empty row
                    string name = row.Cells["Name"].Value?.ToString();
                    string age = row.Cells["Age"].Value?.ToString();
                    string school = row.Cells["School"].Value?.ToString();
                    string educationalAttainment = row.Cells["Educational_Attainment"].Value?.ToString();
                    string employment = row.Cells["Employment_Business_Agency"].Value?.ToString();

                    if (!string.IsNullOrEmpty(name))  // Only save non-empty rows
                    {
                        string query = @"INSERT INTO tbl_brothers_sisters (Sub_Id
                    Name, Age, School, Educational_Attainment, Employment_Business_Agency) 
                    VALUES 
                    (@Sub_Id, @Name, @Age, @School, @Educational_Attainment, @Employment_Business_Agency)";

                        using (var command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Sub_Id", individualRecord.StudentID.ToString());
                            command.Parameters.AddWithValue("@Name", name);
                            command.Parameters.AddWithValue("@Age", age);
                            command.Parameters.AddWithValue("@School", school);
                            command.Parameters.AddWithValue("@Educational_Attainment", educationalAttainment);
                            command.Parameters.AddWithValue("@Employment_Business_Agency", employment);

                            command.ExecuteNonQuery();
                        }

                        using (var command = new MySqlCommand("SELECT LAST_INSERT_ID();", connection))
                        {
                            individualRecord.SiblingsID= Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
                }
            }
        }



        public enrollment()
        {
            InitializeComponent();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string GetGenderIdentity()
        {
            if (rbMaleindentity.Checked) return "Male";
            if (rbFemaleidentity.Checked) return "Female";
            if (rbLezbian.Checked) return "Lesbian";
            if (rbGay.Checked) return "Gay";
            if (rbBisexual.Checked) return "Bisexual";
            if (rbTransgender.Checked) return "Transgender";

            return null; // Default case
        }

        private string GetGenderExpression()
        {
            if (rbExpressionMasculine.Checked) return "Masculine";
            if (rbExpressionFeminine.Checked) return "Feminine";
            if (rbExpressionAndrogynous.Checked) return "Androgynous";

            return null; // Default case
        }

        private bool GetHasScholarship()
        {
            return rbScholarshipYes.Checked; // Return true if the "Yes" radio button is checked
        }

        private string GetGenderSexuallyAttracted()
        {
            if (rbAttractedToMale.Checked) return "Male";
            if (rbAttractedToFemale.Checked) return "Female";
            if (rbAttractedToLesbian.Checked) return "Lesbian";
            if (rbAttractedToGay.Checked) return "Gay";
            if (rbAttractedToBisexual.Checked) return "Bisexual";
            if (rbAttractedToTransgender.Checked) return "Transgender";


            return null; // Default case
        }

        private string GetFatherMaritalStatus()
        {
            if (rbFatherLivingTogether.Checked)
                return "Living Together";
            if (rbFatherSeparated.Checked)
                return "Separated";
            if (rbFatherWithAnotherPartner.Checked)
                return "Father with Another Partner";

            return "Unknown"; // Default case
        }
        private string Gethand()
        {
            if (LeftHanded.Checked)
                return "Left";
            if (RightHanded.Checked)
                return "Right";

            return "Unknown"; // Default case
        }

        private string GetMotherMaritalStatus()
        {
            if (rbMotherAnnulled.Checked)
                return "Annulled";
            if (rbMotherWidowed.Checked)
                return "Widowed";
            if (rbMotherWithAnotherPartner.Checked)
                return "Mother with Another Partner";

            return "Unknown"; // Default case
        }
        private string GetMonthlyIncome()
        {
            if (rbBelow5000.Checked)
                return "Below 5000";
            if (rb10001To15000.Checked)
                return "5000 - 10,000";
            if (rb10001To15000.Checked)
                return "10,001 - 15,000";
            if (rb15001To20000.Checked)
                return "15,001 - 20,000";
            if (rb20001To25000.Checked)
                return "20,001 - 25,000";
            if (rbAbove25000.Checked)
                return "25,001 and above";

            return "Unknown"; // Default case
        }
        private string GetFamilyStructure()
        {
            if (rbNuclear.Checked)
                return "Nuclear";
            if (rbExtended.Checked)
                return "Extended";

            return null; // Default case
        }

        private string GetIndigenousGroup()
        {
            if (rbIndigenousYes.Checked)
                return "Yes";
            if (rbIndigenousNo.Checked)
                return "No";

            return null; // Default
        }

        private string GetBeneficiary4Ps()
        {
            if (rbBeneficiaryYes.Checked)
                return "Yes";
            if (rbBeneficiaryNo.Checked)
                return "No";

            return null; // Default
        }
        private string GetFatherWorkingAbroad()
        {
            if (rbFatherWorkingAbroadYes.Checked)
                return "Yes";
            if (rbFatherWorkingAbroadNo.Checked)
                return "No";

            return null; // Default case if neither is checked
        }
        private string GetSickFrequency()
        {
            if (rbSickOften.Checked)
                return "Yes";
            if (rbSickNo.Checked)
                return "No";
            if (rbSickSeldom.Checked)
                return "Seldom";
            if (rbSickSometimes.Checked)
                return "Sometimes";
            if (rbSickNever.Checked)
                return "Never";

            return "Unknown"; // Default if none are selected
        }
        private string GetHealthProblems()
        {
            List<string> healthProblems = new List<string>();

            // Check each checkbox and add the value if it's checked
            if (chkDysmenorrhea.Checked) healthProblems.Add("Dysmenorrhea");
            if (chkHeadache.Checked) healthProblems.Add("Headache");
            if (chkAsthma.Checked) healthProblems.Add("Asthma");
            if (chkStomachache.Checked) healthProblems.Add("Stomachache");
            if (chkHeartProblems.Checked) healthProblems.Add("Heart problems");
            if (chkColdsFlu.Checked) healthProblems.Add("Colds/Flu");
            if (chkAbdominalPain.Checked) healthProblems.Add("Abdominal pain");
            if (chkSeizureDisorders.Checked) healthProblems.Add("Seizure disorders");

            // Add the content of the 'Others' textbox if it's not empty
            if (!string.IsNullOrEmpty(txtHealthProblemsOther.Text))
                healthProblems.Add("Other: " + txtHealthProblemsOther.Text);

            // Debug: Check what is in the list before joining
            Console.WriteLine("Selected Health Problems: " + string.Join(", ", healthProblems));

            // Join with comma
            return string.Join(", ", healthProblems);

        }
        private string GetPhysicalDisabilities()
        {
            List<string> physicalDisabilities = new List<string>();

            // Check each checkbox and add the value if it's checked
            if (chkVisualImpairment.Checked) physicalDisabilities.Add("Visual impairment");
            if (chkPolio.Checked) physicalDisabilities.Add("Polio");
            if (chkHearingImpairment.Checked) physicalDisabilities.Add("Hearing impairment");
            if (chkCleftPalate.Checked) physicalDisabilities.Add("Cleft palate");
            if (chkPhysicalDeformities.Checked) physicalDisabilities.Add("Physical deformities caused by accident");
            if (chkSeizureDisorders.Checked) physicalDisabilities.Add("Seizure disorders");

            // Add the content of the 'Others' textbox if it's not empty
            if (!string.IsNullOrEmpty(txtPhysicalDisabilitiesOther.Text))
                physicalDisabilities.Add("Other: " + txtPhysicalDisabilitiesOther.Text);

            return string.Join(", ", physicalDisabilities); // Join with comma
        }





        private void iconsubmit_Click(object sender, EventArgs e)
        {
        }

        private void iconSubmit_Click_1(object sender, EventArgs e)
        {
        
        }

        private void enrollment_Load(object sender, EventArgs e)
        {


        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            var studentRecord = new StudentRecord
            {
               
                PersonalInfo = new PersonalData
                {
                    FirstName = txtFirstName.Text,
                    MiddleName = txtMiddleName.Text,
                    LastName = txtLastName.Text,
                    Sex = rbMale.Checked ? "Male" : rbFemale.Checked ? "Female" : null,
                    Age = int.TryParse(txtAge.Text, out var age) ? age : 0,
                    // Nickname = txtNickname.Text, // Uncomment if needed
                    Nationality = txtNationality.Text,
                    Citizenship = txtCitizenship.Text,
                    DateOfBirth = dtpDateOfBirth.Value,
                    PlaceOfBirth = txtPlaceOfBirth.Text,
                    CivilStatus = txtCivilStatus.Text,
                    SpouseName = txtCivilStatus.Text == "Married" ? txtSpouseName.Text : null, // Update accordingly
                    Religion = txtReligion.Text,
                    ContactNumber = txtContactNumber.Text,
                    CompleteHomeAddress = txtCompleteHomeAddress.Text,
                    BoardingHouseAddress = txtBoardingHouseAddress.Text,
                    LandlordName = txtLandlordName.Text,
                    GuardianName = txtGuardianName.Text,
                    EmergencyContact = txtGuardianphone.Text, // If different, update accordingly
                    Hobbies = txtHobbies.Text,
                    // Skills = txtSkills.Text // Uncomment if needed
                }
            };
            var fatherData = new FamilyData
            {
                Parents = "Father",
                Name = txtFatherName.Text,
                TelCellNo = txtFatherPhone.Text,
                Nationality = txtFatherNationality.Text,
                EducationalAttainment = txtFatherEducationalAttainment.Text,
                Occupation = txtFatherOccupation.Text,
                EmployerAgency = txtFatherEmployerAgency.Text,
                WorkingAbroad = GetFatherWorkingAbroad(), // Assuming you have radio buttons
                MaritalStatus = GetFatherMaritalStatus(), // Implement this to return based on your UI
                MonthlyIncome = GetMonthlyIncome(),
                NoOfChildren = int.TryParse(txtFatherNoOfChildren.Text, out var fatherChildren) ? fatherChildren : 0,
                StudentsBirthOrder = int.TryParse(txtFatherBirthOrder.Text, out var fatherBirthOrder) ? fatherBirthOrder : 0,
                LanguageDialect = txtFatherLanguageDialect.Text,
                FamilyStructure = GetFamilyStructure(),
                IndigenousGroup = GetIndigenousGroup(),
                Beneficiary4Ps = GetBeneficiary4Ps(),
            };

            var motherData = new FamilyData
            {
                Parents = "Mother",
                Name = txtMotherName.Text,
                TelCellNo = txtMotherTelCellNo.Text,
                Nationality = txtMotherNationality.Text,
                EducationalAttainment = txtMotherEducationalAttainment.Text,
                Occupation = txtMotherOccupation.Text,
                EmployerAgency = txtMotherEmployerAgency.Text,
                WorkingAbroad = GetFatherWorkingAbroad(),
                MaritalStatus = GetMotherMaritalStatus(), // Similar function for mother
                MonthlyIncome = GetMonthlyIncome(),
                NoOfChildren = fatherData.NoOfChildren, // Use the same value as the father
                StudentsBirthOrder = fatherData.StudentsBirthOrder, // Use the same value as the father
                LanguageDialect = fatherData.LanguageDialect, // Use the same value as the father
                FamilyStructure = fatherData.FamilyStructure, // Use the same value as the father
                IndigenousGroup = fatherData.IndigenousGroup, // Use the same value as the father
                Beneficiary4Ps = fatherData.Beneficiary4Ps, // Use the same value as the father
            };
            var Education = new EducationalData
            {
                //EducationalID = EducationalID,
                ElementaryYearGraduated = ElementaryYearGraduated.Text,
                ElementaryHonorAwards = ElementaryHonorAwards.Text,
                Elementary = Elementary.Text,
                JuniorHighYearGraduated = JuniorHighYearGraduated.Text,
                JuniorHighHonorAwards = JuniorHighHonorAwards.Text,
                HighSchool = HighSchool.Text,
                SeniorHighYearGraduated = SeniorHighYearGraduated.Text,
                SeniorHighHonorAwards = SeniorHighHonorAwards.Text,
                SeniorHighSchool = SeniorHighSchool.Text,
                StrandCompleted = StrandCompleted.Text,
                VocationalTechnical = VocationalTechnical.Text,
                SHSAverageGrade = int.TryParse(SHSAverageGrade.Text, out var average) ? average : 0,
                CollegeIfTransferee = CollegeIfTransferee.Text,
                FavoriteSubject = FavoriteSubject.Text,
                WhyFavoriteSubject = WhyFavoriteSubject.Text,
                LeastFavoriteSubject = LeastFavoriteSubject.Text,
                WhyLeastFavoriteSubject = WhyLeastFavoriteSubject.Text,
                SupportForStudies = SupportForStudies.Text,
                Membership = Membership.Text,
                LeftRightHanded = Gethand()
            };

            //var siblingdata = new Sibling
            //{
            //    Name = txtSiblingName.Text,
            //    Age = int.TryParse(txtSiblingAge.Text, out var age) ? age : 0,
            //    School = txtSiblingSchool.Text,
            //    EducationalAttainment = txtSiblingEducationalAttainment.Text,
            //    EmploymentBusinessAgency = txtSiblingEmployment.Text
            //};




            // Create health data object
            var healthData = new HealthData
            {
                SickFrequency = GetSickFrequency(),
                HealthProblems = GetHealthProblems(),
                PhysicalDisabilities = GetPhysicalDisabilities()
            };
            var additionalProfileData = new AdditionalProfile
            {
                GenderIdentity = GetGenderIdentity(),
                GenderExpression = GetGenderExpression(),
                GenderSexuallyAttracted = GetGenderSexuallyAttracted(),
                HasScholarship = GetHasScholarship(),
                ScholarshipName = txtScholarshipName.Text,
            };
            //var sibling = new Sibling
            //{

            //};

            individualRecord = new IndividualRecord();

            individualRecord.StudentID = int.TryParse(txtStudentID.Text, out var studentId) ? studentId : 0;
            individualRecord.Course = cmbCourse.Text;
            individualRecord.Year = int.TryParse(cmbYear.Text, out var year) ? year : 0;
            individualRecord.IsNewStudent = chkIsNewStudent.Checked;
            individualRecord.IsTransferree = chkIsTransferee.Checked;
            individualRecord.IsReentry = chkIsReEntry.Checked;
            individualRecord.IsShifter = chkIsShifter.Checked;

            
            SaveStudentRecord(studentRecord);
            SaveFamilyData(new StudentRecord { Father = fatherData, Mother = motherData });
            SaveSiblingsData(studentRecord);  // Save siblings dynamically
            SaveEducationalRecord(Education);
            SaveHealthData(healthData);
            SaveAdditionalProfile(additionalProfileData);
            MessageBox.Show("Record saved successfully!");
           
               // MessageBox.Show($"Error saving student record: {ex.Message}");
            
        }
    }
}

