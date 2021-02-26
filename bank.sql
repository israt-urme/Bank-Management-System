-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 16, 2019 at 04:11 AM
-- Server version: 10.1.36-MariaDB
-- PHP Version: 7.2.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bank`
--

-- --------------------------------------------------------

--
-- Table structure for table `account_details`
--

CREATE TABLE `account_details` (
  `Account_No` int(11) NOT NULL,
  `Customer_id` int(11) NOT NULL,
  `Account_type` varchar(255) NOT NULL,
  `Description` varchar(255) NOT NULL,
  `Balance` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `account_details`
--

INSERT INTO `account_details` (`Account_No`, `Customer_id`, `Account_type`, `Description`, `Balance`) VALUES
(201, 10001, 'Fixed', 'djxxxxxx', 1300),
(202, 10002, 'Saving', '', 0),
(203, 10003, 'Saving', '', 0),
(204, 10004, 'Saving', '', 2300);

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE `customer` (
  `Customer_id` int(11) NOT NULL,
  `FirstName` varchar(255) NOT NULL,
  `LastName` varchar(255) NOT NULL,
  `Gender` varchar(255) NOT NULL,
  `Date_of_Birth` varchar(255) NOT NULL,
  `Address` varchar(255) NOT NULL,
  `Nationality` varchar(255) NOT NULL,
  `Email_Address` varchar(255) NOT NULL,
  `Occupation` varchar(255) NOT NULL,
  `Phone_No` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `customer`
--

INSERT INTO `customer` (`Customer_id`, `FirstName`, `LastName`, `Gender`, `Date_of_Birth`, `Address`, `Nationality`, `Email_Address`, `Occupation`, `Phone_No`) VALUES
(10001, 'Kamrun', 'Nahar', 'female', 'Tuesday, February 05, 2019', 'Lakshmipur', 'Bangladeshi', 'ka@gmail.com', 'Student', 47923058),
(10002, 'Tanbir', 'Da', 'male', '5/3/2019', '', '', '', '', 0),
(10003, 'Maruf', 'Ahmed', 'male', '6/1/2019', '', '', '', '', 0),
(10004, 'maruf', 'rahad', 'male', '05/02/2019', '', '', '', '', 0);

-- --------------------------------------------------------

--
-- Table structure for table `loan_details`
--

CREATE TABLE `loan_details` (
  `Receipt_no` int(11) NOT NULL,
  `Account_No` int(11) NOT NULL,
  `Date` varchar(255) NOT NULL,
  `Amount` int(11) NOT NULL,
  `Period` int(11) NOT NULL,
  `Payment` int(11) NOT NULL,
  `Due` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `loan_details`
--

INSERT INTO `loan_details` (`Receipt_no`, `Account_No`, `Date`, `Amount`, `Period`, `Payment`, `Due`) VALUES
(100, 202, '08/02/2019', 1000000, 12, 83333, 0),
(102, 203, '08/02/2019', 10000, 6, 1666, 6668),
(103, 204, '08/02/2019', 30000, 12, 2500, 30000);

-- --------------------------------------------------------

--
-- Table structure for table `login`
--

CREATE TABLE `login` (
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `login`
--

INSERT INTO `login` (`username`, `password`) VALUES
('manager', '4567');

-- --------------------------------------------------------

--
-- Table structure for table `transaction`
--

CREATE TABLE `transaction` (
  `Transac_id` int(11) NOT NULL,
  `Account_No` int(11) NOT NULL,
  `Date` varchar(255) NOT NULL,
  `Balance` int(11) NOT NULL,
  `Deposit` int(11) NOT NULL,
  `Withdraw` int(11) NOT NULL,
  `Deposit_status` varchar(255) DEFAULT NULL,
  `Withdraw_status` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `transaction`
--

INSERT INTO `transaction` (`Transac_id`, `Account_No`, `Date`, `Balance`, `Deposit`, `Withdraw`, `Deposit_status`, `Withdraw_status`) VALUES
(4, 200, 'Tuesday, February 05, 2019', 12000, 2000, 0, NULL, NULL),
(5, 200, 'Tuesday, February 05, 2019', 14000, 0, 3000, NULL, NULL),
(6, 202, '2/5/2019', 0, 0, 0, NULL, NULL),
(7, 203, '2/5/2019', 0, 0, 0, NULL, NULL),
(8, 203, '5/3/2019', 0, 0, 0, NULL, NULL),
(9, 204, '05/02/2019', 2000, 100, 0, NULL, NULL),
(10, 205, '07/02/2019', 20000, 0, 400, NULL, NULL),
(11, 0, '', 0, 0, 0, NULL, NULL),
(12, 201, '06/02/2019', 2300, 1000, 0, 'YES', 'NO'),
(13, 205, '06/02/2019', 19600, 200, 0, 'YES', 'NO'),
(14, 205, '06/02/2019', 19800, 0, 1000, NULL, NULL),
(15, 205, '06/02/2019', 18800, 0, 1000, 'NO', 'YES'),
(16, 204, '06/02/2019', 2100, 200, 0, 'YES', 'NO'),
(17, 204, '06/02/2019', 2300, 0, 200, 'NO', 'YES'),
(18, 204, '06/02/2019', 1900, 200, 0, 'YES', 'NO'),
(19, 204, '06/02/2019', 2100, 200, 0, 'YES', 'NO');

-- --------------------------------------------------------

--
-- Table structure for table `transfer`
--

CREATE TABLE `transfer` (
  `Transfer_id` int(11) NOT NULL,
  `From_Account_No` int(11) NOT NULL,
  `To_Account_No` int(11) NOT NULL,
  `Date` varchar(255) NOT NULL,
  `Amount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `transfer`
--

INSERT INTO `transfer` (`Transfer_id`, `From_Account_No`, `To_Account_No`, `Date`, `Amount`) VALUES
(1, 201, 202, '2/6/2019', 2000),
(2, 204, 203, '2/6/2019', 200);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `account_details`
--
ALTER TABLE `account_details`
  ADD PRIMARY KEY (`Account_No`);

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`Customer_id`);

--
-- Indexes for table `loan_details`
--
ALTER TABLE `loan_details`
  ADD PRIMARY KEY (`Receipt_no`);

--
-- Indexes for table `transaction`
--
ALTER TABLE `transaction`
  ADD PRIMARY KEY (`Transac_id`);

--
-- Indexes for table `transfer`
--
ALTER TABLE `transfer`
  ADD PRIMARY KEY (`Transfer_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `account_details`
--
ALTER TABLE `account_details`
  MODIFY `Account_No` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=205;

--
-- AUTO_INCREMENT for table `loan_details`
--
ALTER TABLE `loan_details`
  MODIFY `Receipt_no` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=104;

--
-- AUTO_INCREMENT for table `transaction`
--
ALTER TABLE `transaction`
  MODIFY `Transac_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `transfer`
--
ALTER TABLE `transfer`
  MODIFY `Transfer_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
