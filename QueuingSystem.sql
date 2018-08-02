CREATE DATABASE  IF NOT EXISTS `osa_queuing` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `osa_queuing`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: osa_queuing
-- ------------------------------------------------------
-- Server version	5.7.14

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `accounts`
--

DROP TABLE IF EXISTS `accounts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `accounts` (
  `account_id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `first_name` varchar(45) DEFAULT NULL,
  `last_name` varchar(45) DEFAULT NULL,
  `department` varchar(45) NOT NULL,
  PRIMARY KEY (`account_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `accounts`
--

LOCK TABLES `accounts` WRITE;
/*!40000 ALTER TABLE `accounts` DISABLE KEYS */;
INSERT INTO `accounts` VALUES (1,'kaiser','prussians','Friedreich','Wilhelm','Service Cubicle'),(2,'joseph','stalin','Joseph','Stalin','Service Cubicle'),(3,'queen','united','Elizabeth','Mary','Service Cubicle'),(4,'cubicleNum4','cubicle4','John','Doe','Service Cubicle'),(5,'admin','admins','Andrew','Macalma','Admin'),(6,'hello','aaa','Triceayn','Prestousa','Admin');
/*!40000 ALTER TABLE `accounts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `queue_stat`
--

DROP TABLE IF EXISTS `queue_stat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `queue_stat` (
  `queue_id` int(11) NOT NULL AUTO_INCREMENT,
  `cubicle_number` int(11) NOT NULL,
  `serving_number` int(11) NOT NULL,
  `timestamp` datetime(1) NOT NULL,
  `deact_flag` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`queue_id`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `queue_stat`
--

LOCK TABLES `queue_stat` WRITE;
/*!40000 ALTER TABLE `queue_stat` DISABLE KEYS */;
INSERT INTO `queue_stat` VALUES (1,3,1,'2018-08-02 16:12:06.9',0),(2,1,2,'2018-08-02 16:12:10.5',0),(3,1,3,'2018-08-02 16:12:14.5',0),(4,1,4,'2018-08-02 16:12:18.2',0),(5,3,5,'2018-08-02 16:12:21.9',0),(7,1,6,'2018-08-02 16:12:46.4',0),(8,1,7,'2018-08-02 16:12:50.0',0),(10,1,8,'2018-08-02 16:14:59.2',0),(11,2,9,'2018-08-02 16:16:50.3',0),(15,2,10,'2018-08-02 16:21:44.7',0),(17,2,11,'2018-08-02 16:23:55.8',0),(22,4,12,'2018-08-02 16:32:17.3',0),(23,4,13,'2018-08-02 16:32:21.5',0),(24,4,14,'2018-08-02 16:32:25.6',0),(26,4,15,'2018-08-02 16:34:21.2',0),(29,2,16,'2018-08-02 16:53:25.7',0),(30,2,17,'2018-08-02 16:53:29.9',0),(31,2,18,'2018-08-02 16:53:36.3',0);
/*!40000 ALTER TABLE `queue_stat` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recalled_records`
--

DROP TABLE IF EXISTS `recalled_records`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `recalled_records` (
  `queue_id` int(11) NOT NULL,
  `cubicle_number` int(11) NOT NULL,
  `serving_number` int(11) NOT NULL,
  `timestamp` datetime(1) NOT NULL,
  PRIMARY KEY (`queue_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recalled_records`
--

LOCK TABLES `recalled_records` WRITE;
/*!40000 ALTER TABLE `recalled_records` DISABLE KEYS */;
/*!40000 ALTER TABLE `recalled_records` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-08-02 17:01:49
