﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CCGMS.methods
{
    internal class MyFetch
    {

        public MySqlDataAdapter GetIndividualDataPending()
        {
            string query = @"
            SELECT 
                ir.Student_ID,
                ir.Course,
                ir.Year,
                pd.Firstname,
                pd.Middlename,
                pd.Lastname,
                pd.Sex
            FROM 
                tbl_Individual_Record ir
            JOIN 
                tbl_Personal_Data pd ON ir.Personal_Data_ID = pd.Personal_Data_ID
             WHERE
                ir.Status = 0;"; // Filtering for active records

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, MyCon.GetConnection());
            return dataAdapter;
        }

        public MySqlDataAdapter GetIndividualData()
        {
            string query = @"
            SELECT 
                ir.Student_ID,
                ir.Course,
                ir.Year,
                pd.Firstname,
                pd.Middlename,
                pd.Lastname,
                pd.Sex
            FROM 
                tbl_Individual_Record ir
            JOIN 
                tbl_Personal_Data pd ON ir.Personal_Data_ID = pd.Personal_Data_ID
             WHERE
                ir.Status = 1;"; // Filtering for active records

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, MyCon.GetConnection());
            return dataAdapter;
        }

        public Dictionary<string, int> GetStudentCountByYearAndSex()
        {
            var studentCountDictionary = new Dictionary<string, int>();

            string query = @"
            SELECT 
                Year,
                Sex,
                COUNT(DISTINCT ir.Student_ID) AS StudentCount
            FROM 
                tbl_Individual_Record ir
            JOIN 
                tbl_Personal_Data pd ON ir.Personal_Data_ID = pd.Personal_Data_ID
            GROUP BY 
                Year, Sex
            ORDER BY 
                Year, Sex;
        ";

            using (var connection = MyCon.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                connection.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string year = reader["Year"].ToString();
                        string sex = reader["Sex"].ToString();
                        int count = Convert.ToInt32(reader["StudentCount"]);

                        // Construct a key using Year and Sex, e.g., "1st Year - Male"
                        string key = $"{year} - {sex}";
                        studentCountDictionary[key] = count;
                    }
                }
            }

            return studentCountDictionary;
        }
        public Dictionary<string, Dictionary<string, object>> GetAllIndividualRecords()
        {
            var records = new Dictionary<string, Dictionary<string, object>>();

            string query = @"
        SELECT 
            ir.Student_ID,
            ir.Course,
            ir.Year,
            ir.IsNewStudent,
            ir.IsTransferree,
            ir.IsReentry,
            ir.IsShifter,

            -- Personal Data
            pd.Firstname,
            pd.Middlename,
            pd.Lastname,
            pd.Nickname,
            pd.Sex,
            pd.Age,
            pd.Nationality,
            pd.Citizenship,
            pd.Date_of_Birth,
            pd.Place_of_Birth,
            pd.Civil_Status,
            pd.Number_of_Children,
            pd.Religion,
            pd.Contact_No,
            pd.E_mail_Address,
            pd.Complete_Home_Address,
            pd.Boarding_House_Address,
            pd.Landlord_Name,
            pd.Person_to_contact,
            pd.Cell_no,
            pd.Hobbies_Skills_Talents,
            pd.Describe_Yourself,

            -- Family Data
            fd.Parents_Name,
            fd.Tel_Cell_No,
            fd.Nationality AS Parent_Nationality,
            fd.Educational_Attainment AS Parent_Education,
            fd.Occupation,
            fd.Employer_Agency,
            fd.Working_Abroad,
            fd.Marital_Status,
            fd.Monthly_Income,
            fd.No_of_Children AS Family_No_of_Children,
            fd.Students_Birth_Order,
            fd.Language_Dialect,
            fd.Family_Structure,
            fd.Indigenous_Group,
            fd.4Ps_Beneficiary,

            -- Sibling Data
            bs.Name AS Sibling_Name,
            bs.Age AS Sibling_Age,
            bs.School AS Sibling_School,
            bs.Educational_Attainment AS Sibling_Education,
            bs.Employment_Business_Agency AS Sibling_Employment,

            -- Educational Data
            ed.Elementary,
            ed.High_School,
            ed.Senior_High_School,
            ed.Strand_Completed,
            ed.Vocational_Technical,
            ed.SHS_Average_Grade,
            ed.College AS College_If_Transferee,
            ed.Favorite_Subject,
            ed.Why_Favorite_Subject,
            ed.Least_Favorite_Subject,
            ed.Why_Least_Favorite_Subject,
            ed.Support_for_Studies,
            ed.Membership,
            ed.Left_Right_Handed,

            -- Health Data
            hd.Health_Data_ID,
            hd.Sick_Frequency,
            hd.Health_Problems,
            hd.Physical_Disabilities,

            -- Additional Profile
            ap.Sexual_Preference,
            ap.Expression_Present,
            ap.Gender_Sexually_Attracted,
            ap.Scholarship,
            ap.Name_of_Scholarship

            FROM 
                tbl_Individual_Record ir
            JOIN 
                tbl_Personal_Data pd ON ir.Personal_Data_ID = pd.Personal_Data_ID
            JOIN 
                tbl_Family_Data fd ON ir.Family_Data_ID = fd.Family_Data_ID
            JOIN 
                tbl_Brothers_Sisters bs ON ir.Siblings_ID = bs.Siblings_ID
            JOIN 
                tbl_Educational_Data ed ON ir.Educational_ID = ed.Educational_ID
            JOIN 
                tbl_Health_Data hd ON ir.Health_Data_ID = hd.Health_Data_ID
            JOIN 
                tbl_Additional_Profile ap ON ir.Additional_Profile_ID = ap.Additional_Profile_ID;
            ";


            using (MySqlConnection connection = MyCon.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                connection.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var studentId = reader["Student_ID"].ToString();

                        var studentData = new Dictionary<string, object>();

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            var columnName = reader.GetName(i);
                            studentData[columnName] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                        }

                        records[studentId] = studentData;
                    }
                }
            }

            return records;
        }

        public string FormatStudentRecords(Dictionary<string, Dictionary<string, object>> records)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var studentRecord in records)
            {
                sb.AppendLine($"Student ID: {studentRecord.Key}");
                foreach (var field in studentRecord.Value)
                {
                    sb.AppendLine($"{field.Key}: {field.Value}");
                }
                sb.AppendLine("--------------------------------------------------\n");
            }

            return sb.ToString();
        }
        
        
    }
}
