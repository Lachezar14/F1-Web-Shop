-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 19, 2022 at 08:32 PM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `storedb`
--

-- --------------------------------------------------------

--
-- Table structure for table `clothes`
--

CREATE TABLE `clothes` (
  `Product_Id` int(11) NOT NULL,
  `Size` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `clothes`
--

INSERT INTO `clothes` (`Product_Id`, `Size`) VALUES
(1, 'S'),
(13, 'XS');

-- --------------------------------------------------------

--
-- Table structure for table `orders`
--

CREATE TABLE `orders` (
  `Id` int(11) NOT NULL,
  `Product_Id` int(11) NOT NULL,
  `Buyer_Id` int(11) NOT NULL,
  `Address` varchar(200) NOT NULL,
  `City` varchar(200) NOT NULL,
  `Postcode` varchar(200) NOT NULL,
  `Revenue` decimal(10,0) NOT NULL,
  `Shipped` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `orders`
--

INSERT INTO `orders` (`Id`, `Product_Id`, `Buyer_Id`, `Address`, `City`, `Postcode`, `Revenue`, `Shipped`) VALUES
(17, 1, 12, 'zz', 'zz', 'zz', '60', 1),
(18, 1, 2, 'Johannes van der Waalswg 82', 'EINDHOVEN', '5612JD', '60', 0),
(19, 1, 15, 'dd', 'dd', 'ff', '60', 0),
(26, 1, 23, 'Johannes van der Waalswg', 'EINDHOVEN', '5612JD', '60', 0),
(27, 1, 2, 'Johannes van der Waalswg 82', 'EINDHOVEN', '5612JD', '60', 0),
(28, 1, 2, 'Johannes van der Waalswg 82', 'EINDHOVEN', '5612JD', '60', 0);

-- --------------------------------------------------------

--
-- Table structure for table `posters`
--

CREATE TABLE `posters` (
  `Product_Id` int(11) NOT NULL,
  `Length` int(11) NOT NULL,
  `Height` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `posters`
--

INSERT INTO `posters` (`Product_Id`, `Length`, `Height`) VALUES
(14, 134, 564),
(15, 150, 300);

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `Id` int(11) NOT NULL,
  `Description` varchar(200) NOT NULL,
  `Stock` int(11) NOT NULL,
  `Price` decimal(10,0) NOT NULL,
  `Type` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`Id`, `Description`, `Stock`, `Price`, `Type`) VALUES
(1, 'Red T-shirt', 43, '60', 'Clothing'),
(13, 'Blue T-shirt', 60, '45', 'Clothing'),
(14, 'RebBull Poster', 45, '56', 'Poster'),
(15, 'Ferrari poster', 50, '80', 'Poster');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `Id` int(11) NOT NULL,
  `FirstName` varchar(200) NOT NULL,
  `LastName` varchar(200) NOT NULL,
  `Email` varchar(200) NOT NULL,
  `PhoneNumber` varchar(200) NOT NULL,
  `Address` varchar(200) NOT NULL,
  `City` varchar(200) NOT NULL,
  `Postcode` varchar(200) NOT NULL,
  `Type` varchar(200) NOT NULL,
  `Username` varchar(200) NOT NULL,
  `Password` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`Id`, `FirstName`, `LastName`, `Email`, `PhoneNumber`, `Address`, `City`, `Postcode`, `Type`, `Username`, `Password`) VALUES
(1, 'dd', 'ddd', 'dd', 'dd', 'dd', 'dd', 'dd', 'Admin', 'dd', 'ddd'),
(2, 'Lachezar', 'Mitov', 'lach1@gmail.com', '0641209653', 'Johannes van der Waalswg 82', 'EINDHOVEN', '5612JD', 'Customer', 'gigi', 'gigi'),
(4, 'me', 'we', 'de', 'de', 'de', 'de', 'de', '', 'we', 'we'),
(5, 'for', 'for', 'rffr', 'rfr', 'rfrf', 'rfrf', 'rfrf', 'Customer', 'rfrf', 'rfr'),
(6, 'dew', 'dwe', 'wed', 'dwe', 'dwe', 'dew', 'dwe', 'Customer', 'edw', 'dwe'),
(7, 'Lachi', 'Mitovic', 'rfgdvspam1@gmail.com', '56434568754', 'Johannes van der Waalswg', 'EINDHOVEN', '5232JD', 'Customer', 'luc', 'luc'),
(8, 'dcssdc', 'dscdsc', 'sdcdsc', 'sddsc', 'sdcdsc', 'sdcsdc', 'sdcsd', 'Customer', 'dscdsc', 'sdcdsc'),
(9, 'qqq', 'qqq', 'ewfew', 'qqq', 'qqq', 'qqq', 'qqq', 'Customer', 'qqq', 'qqq'),
(11, 'dsdsds', 'dsdssd', 'dssdsdds', 'ddsds', 'ddssd', 'dssdds', 'dsdsds', 'Customer', 'dsdsd', 'dsdsdsd'),
(12, 'zz', 'zz', 'zz', 'zz', 'zz', 'zz', 'zz', 'Customer', 'zz', 'zz'),
(14, 'S', 'SD', 'SD', 'sa', 'sdasd', 'dsfsfd', 'aa', 'Customer', 'asdds', 'asad'),
(15, '', '', '', '', '', '', '', '', '', ''),
(23, 'Mr', 'Mitov', 'lachomitov2609@gmail.com', '0878641150', 'Johannes van der Waalswg', 'EINDHOVEN', '5612JD', 'Customer', 'fofi', 'fofi');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clothes`
--
ALTER TABLE `clothes`
  ADD KEY `clothes_ibfk_1` (`Product_Id`);

--
-- Indexes for table `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `orders_ibfk_1` (`Product_Id`),
  ADD KEY `orders_ibfk_2` (`Buyer_Id`);

--
-- Indexes for table `posters`
--
ALTER TABLE `posters`
  ADD KEY `posters_ibfk_1` (`Product_Id`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `orders`
--
ALTER TABLE `orders`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `clothes`
--
ALTER TABLE `clothes`
  ADD CONSTRAINT `clothes_ibfk_1` FOREIGN KEY (`Product_Id`) REFERENCES `products` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`Product_Id`) REFERENCES `products` (`Id`),
  ADD CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`Buyer_Id`) REFERENCES `users` (`Id`);

--
-- Constraints for table `posters`
--
ALTER TABLE `posters`
  ADD CONSTRAINT `posters_ibfk_1` FOREIGN KEY (`Product_Id`) REFERENCES `products` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
