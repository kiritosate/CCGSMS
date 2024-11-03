CREATE DATABASE  IF NOT EXISTS `guidancedb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;
USE `guidancedb`;
-- MySQL dump 10.13  Distrib 8.0.38, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: guidancedb
-- ------------------------------------------------------
-- Server version	5.5.5-10.4.32-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tbl_additional_profile`
--

DROP TABLE IF EXISTS `tbl_additional_profile`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_additional_profile` (
  `Additional_Profile_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Sexual_Preference` varchar(50) DEFAULT NULL,
  `Expression_Present` varchar(50) DEFAULT NULL,
  `Gender_Sexually_Attracted` varchar(50) DEFAULT NULL,
  `Scholarship` tinyint(1) DEFAULT NULL,
  `Name_of_Scholarship` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Additional_Profile_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_additional_profile`
--

LOCK TABLES `tbl_additional_profile` WRITE;
/*!40000 ALTER TABLE `tbl_additional_profile` DISABLE KEYS */;
INSERT INTO `tbl_additional_profile` VALUES (1,'Heterosexual','Yes','Female',0,'Academic Excellence Scholarship'),(2,'Homosexual','Yes','Male',0,NULL),(3,'Bisexual','No','Female',0,'Athletic Scholarship'),(4,'Heterosexual','Yes','Male',0,NULL);
/*!40000 ALTER TABLE `tbl_additional_profile` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_admin_account`
--

DROP TABLE IF EXISTS `tbl_admin_account`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_admin_account` (
  `Admin_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Admin_Name` varchar(255) NOT NULL,
  `Admin_Password` varchar(50) NOT NULL,
  PRIMARY KEY (`Admin_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_admin_account`
--

LOCK TABLES `tbl_admin_account` WRITE;
/*!40000 ALTER TABLE `tbl_admin_account` DISABLE KEYS */;
INSERT INTO `tbl_admin_account` VALUES (3,'admin','123');
/*!40000 ALTER TABLE `tbl_admin_account` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_brothers_sisters`
--

DROP TABLE IF EXISTS `tbl_brothers_sisters`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_brothers_sisters` (
  `Siblings_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Sub_Id` varchar(20) NOT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `Age` int(11) DEFAULT NULL,
  `School` varchar(50) DEFAULT NULL,
  `Educational_Attainment` varchar(50) DEFAULT NULL,
  `Employment_Business_Agency` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Siblings_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_brothers_sisters`
--

LOCK TABLES `tbl_brothers_sisters` WRITE;
/*!40000 ALTER TABLE `tbl_brothers_sisters` DISABLE KEYS */;
INSERT INTO `tbl_brothers_sisters` VALUES (1,'','James Doe',NULL,NULL,NULL,NULL),(2,'','Anna Smith',NULL,NULL,NULL,NULL),(3,'','Michael Brown',NULL,NULL,NULL,NULL),(4,'','Sophia Johnson',NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `tbl_brothers_sisters` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_educational_data`
--

DROP TABLE IF EXISTS `tbl_educational_data`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_educational_data` (
  `Educational_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Elementary` varchar(50) DEFAULT NULL,
  `High_School` varchar(50) DEFAULT NULL,
  `Senior_High_School` varchar(50) DEFAULT NULL,
  `Strand_Completed` varchar(50) DEFAULT NULL,
  `Vocational_Technical` varchar(50) DEFAULT NULL,
  `SHS_Average_Grade` decimal(4,2) DEFAULT NULL,
  `College` varchar(50) DEFAULT NULL,
  `Favorite_subject` varchar(50) DEFAULT NULL,
  `Why_Favorite_Subject` text DEFAULT NULL,
  `Least_Favorite_Subject` varchar(50) DEFAULT NULL,
  `Why_Least_Favorite_Subject` text DEFAULT NULL,
  `Support_for_Studies` text DEFAULT NULL,
  `Membership` text DEFAULT NULL,
  `Left_Right_Handed` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`Educational_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_educational_data`
--

LOCK TABLES `tbl_educational_data` WRITE;
/*!40000 ALTER TABLE `tbl_educational_data` DISABLE KEYS */;
INSERT INTO `tbl_educational_data` VALUES (1,'Greenwood Elementary','Central High',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(2,'Hilltop Elementary','Westview High',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(3,'Pine Elementary','Eastside High',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(4,'River Elementary','North High',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `tbl_educational_data` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_family_data`
--

DROP TABLE IF EXISTS `tbl_family_data`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_family_data` (
  `Family_Data_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Sub_Id` varchar(20) NOT NULL,
  `Parents_Name` varchar(50) DEFAULT NULL,
  `Tel_Cell_No` varchar(15) DEFAULT NULL,
  `Nationality` varchar(50) DEFAULT NULL,
  `Educational_Attainment` varchar(50) DEFAULT NULL,
  `Occupation` varchar(50) DEFAULT NULL,
  `Employer_Agency` varchar(50) DEFAULT NULL,
  `Working_Abroad` varchar(10) DEFAULT NULL,
  `Marital_Status` varchar(20) DEFAULT NULL,
  `Monthly_Income` decimal(10,2) DEFAULT NULL,
  `No_of_Children` int(11) DEFAULT NULL,
  `Students_Birth_Order` int(11) DEFAULT NULL,
  `Language_Dialect` varchar(50) DEFAULT NULL,
  `Family_Structure` varchar(50) DEFAULT NULL,
  `Indigenous_Group` varchar(50) DEFAULT NULL,
  `4Ps_Beneficiary` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`Family_Data_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_family_data`
--

LOCK TABLES `tbl_family_data` WRITE;
/*!40000 ALTER TABLE `tbl_family_data` DISABLE KEYS */;
INSERT INTO `tbl_family_data` VALUES (1,'','Mr. and Mrs. Doe',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(2,'','Mr. and Mrs. Smith',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(3,'','Mr. and Mrs. Brown',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(4,'','Mr. and Mrs. Johnson',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `tbl_family_data` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_health_data`
--

DROP TABLE IF EXISTS `tbl_health_data`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_health_data` (
  `Health_Data_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Sick_Frequency` varchar(50) DEFAULT NULL,
  `Health_Problems` text DEFAULT NULL,
  `Physical_Disabilities` text DEFAULT NULL,
  PRIMARY KEY (`Health_Data_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_health_data`
--

LOCK TABLES `tbl_health_data` WRITE;
/*!40000 ALTER TABLE `tbl_health_data` DISABLE KEYS */;
INSERT INTO `tbl_health_data` VALUES (1,'Rarely','None','None'),(2,'Occasionally','Allergies','None'),(3,'Frequently','Asthma','None'),(4,'Rarely','None','Mild Mobility Impairment');
/*!40000 ALTER TABLE `tbl_health_data` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_individual_record`
--

DROP TABLE IF EXISTS `tbl_individual_record`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_individual_record` (
  `Student_ID` varchar(20) NOT NULL,
  `Course` varchar(50) DEFAULT NULL,
  `Year` varchar(50) DEFAULT NULL,
  `IsNewStudent` tinyint(1) DEFAULT NULL,
  `IsTransferree` tinyint(1) DEFAULT NULL,
  `IsReentry` tinyint(1) DEFAULT NULL,
  `IsShifter` tinyint(1) DEFAULT NULL,
  `Personal_Data_ID` int(11) DEFAULT NULL,
  `Family_Data_ID` int(11) DEFAULT NULL,
  `Siblings_ID` int(11) DEFAULT NULL,
  `Educational_ID` int(11) DEFAULT NULL,
  `Additional_Profile_ID` int(11) DEFAULT NULL,
  `Health_Data_ID` int(11) DEFAULT NULL,
  `Status` tinyint(1) NOT NULL DEFAULT 0,
  PRIMARY KEY (`Student_ID`),
  KEY `Personal_Data_ID` (`Personal_Data_ID`),
  KEY `Family_Data_ID` (`Family_Data_ID`),
  KEY `Siblings_ID` (`Siblings_ID`),
  KEY `Educational_ID` (`Educational_ID`),
  KEY `Additional_Profile_ID` (`Additional_Profile_ID`),
  KEY `Health_Data_ID` (`Health_Data_ID`),
  CONSTRAINT `tbl_individual_record_ibfk_1` FOREIGN KEY (`Personal_Data_ID`) REFERENCES `tbl_personal_data` (`Personal_Data_ID`),
  CONSTRAINT `tbl_individual_record_ibfk_2` FOREIGN KEY (`Family_Data_ID`) REFERENCES `tbl_family_data` (`Family_Data_ID`),
  CONSTRAINT `tbl_individual_record_ibfk_3` FOREIGN KEY (`Siblings_ID`) REFERENCES `tbl_brothers_sisters` (`Siblings_ID`),
  CONSTRAINT `tbl_individual_record_ibfk_4` FOREIGN KEY (`Educational_ID`) REFERENCES `tbl_educational_data` (`Educational_ID`),
  CONSTRAINT `tbl_individual_record_ibfk_5` FOREIGN KEY (`Additional_Profile_ID`) REFERENCES `tbl_additional_profile` (`Additional_Profile_ID`),
  CONSTRAINT `tbl_individual_record_ibfk_6` FOREIGN KEY (`Health_Data_ID`) REFERENCES `tbl_health_data` (`Health_Data_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_individual_record`
--

LOCK TABLES `tbl_individual_record` WRITE;
/*!40000 ALTER TABLE `tbl_individual_record` DISABLE KEYS */;
INSERT INTO `tbl_individual_record` VALUES ('21-001','Computer Science','1st Year',1,0,0,0,1,1,1,1,1,1,1),('21-002','Engineering','2nd Year',0,1,0,0,2,2,2,2,2,2,0),('21-003','Mathematics','3rd Year',0,0,1,0,3,3,3,3,3,3,0),('21-004','Business Management','4th Year',0,0,0,1,4,4,4,4,4,4,0);
/*!40000 ALTER TABLE `tbl_individual_record` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_personal_data`
--

DROP TABLE IF EXISTS `tbl_personal_data`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_personal_data` (
  `Personal_Data_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Firstname` varchar(50) DEFAULT NULL,
  `Middlename` varchar(50) DEFAULT NULL,
  `Lastname` varchar(50) DEFAULT NULL,
  `Nickname` varchar(50) DEFAULT NULL,
  `Sex` varchar(10) DEFAULT NULL,
  `Age` int(11) DEFAULT NULL,
  `Nationality` varchar(50) DEFAULT NULL,
  `Citizenship` varchar(50) DEFAULT NULL,
  `Date_of_Birth` date DEFAULT NULL,
  `Place_of_Birth` varchar(100) DEFAULT NULL,
  `Civil_Status` varchar(20) DEFAULT NULL,
  `Number_of_Children` int(11) DEFAULT NULL,
  `Religion` varchar(50) DEFAULT NULL,
  `Contact_No` varchar(15) DEFAULT NULL,
  `E_mail_Address` varchar(100) DEFAULT NULL,
  `Complete_Home_Address` varchar(255) DEFAULT NULL,
  `Boarding_House_Address` varchar(255) DEFAULT NULL,
  `Landlord_Name` varchar(50) DEFAULT NULL,
  `Person_to_contact` varchar(50) DEFAULT NULL,
  `Cell_no` varchar(15) DEFAULT NULL,
  `Hobbies_Skills_Talents` text DEFAULT NULL,
  `Describe_Yourself` text DEFAULT NULL,
  PRIMARY KEY (`Personal_Data_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_personal_data`
--

LOCK TABLES `tbl_personal_data` WRITE;
/*!40000 ALTER TABLE `tbl_personal_data` DISABLE KEYS */;
INSERT INTO `tbl_personal_data` VALUES (1,'John','A','Doe',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(2,'Jane','B','Smith',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(3,'Robert','C','Brown',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(4,'Emily','D','Johnson',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `tbl_personal_data` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_staff_account`
--

DROP TABLE IF EXISTS `tbl_staff_account`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_staff_account` (
  `Staff_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Staff_Name` varchar(255) NOT NULL,
  `Staff_Pass` varchar(50) NOT NULL,
  PRIMARY KEY (`Staff_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_staff_account`
--

LOCK TABLES `tbl_staff_account` WRITE;
/*!40000 ALTER TABLE `tbl_staff_account` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_staff_account` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-11-04  1:37:38
