-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Aug 17, 2023 at 02:59 PM
-- Server version: 8.0.31
-- PHP Version: 8.0.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `proyecto`
--

-- --------------------------------------------------------

--
-- Table structure for table `categoria`
--

DROP TABLE IF EXISTS `categoria`;
CREATE TABLE IF NOT EXISTS `categoria` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `categoria`
--

INSERT INTO `categoria` (`ID`, `Nombre`) VALUES
(1, 'Cervezas'),
(2, 'Refrescos'),
(3, 'Vino'),
(4, 'Minutas'),
(5, 'Frankfruters'),
(6, 'Chivitos'),
(7, 'Sandwichería'),
(8, 'Pizzetas');

-- --------------------------------------------------------

--
-- Table structure for table `empleados`
--

DROP TABLE IF EXISTS `empleados`;
CREATE TABLE IF NOT EXISTS `empleados` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Categoria` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `empleados`
--

INSERT INTO `empleados` (`ID`, `Categoria`) VALUES
(1, 'Empleado'),
(2, 'Administrador');

-- --------------------------------------------------------

--
-- Table structure for table `factura`
--

DROP TABLE IF EXISTS `factura`;
CREATE TABLE IF NOT EXISTS `factura` (
  `Número` int NOT NULL AUTO_INCREMENT,
  `Monto` int DEFAULT NULL,
  `Número_Pedido` int DEFAULT NULL,
  PRIMARY KEY (`Número`),
  KEY `Número_Pedido` (`Número_Pedido`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `llevan`
--

DROP TABLE IF EXISTS `llevan`;
CREATE TABLE IF NOT EXISTS `llevan` (
  `Precio_Unitario` double DEFAULT NULL,
  `Cantidad` int DEFAULT NULL,
  `ID_Plato` int DEFAULT NULL,
  `Numero_Pedido` int DEFAULT NULL,
  KEY `ID_Plato` (`ID_Plato`),
  KEY `Numero_Pedido` (`Numero_Pedido`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `pedidos`
--

DROP TABLE IF EXISTS `pedidos`;
CREATE TABLE IF NOT EXISTS `pedidos` (
  `Número` int NOT NULL AUTO_INCREMENT,
  `Platos` varchar(20) DEFAULT NULL,
  `Fecha` date DEFAULT NULL,
  `ID_Usuario` int DEFAULT NULL,
  PRIMARY KEY (`Número`),
  KEY `ID_Usuario` (`ID_Usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `platos`
--

DROP TABLE IF EXISTS `platos`;
CREATE TABLE IF NOT EXISTS `platos` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(20) DEFAULT NULL,
  `Descripcion` varchar(50) DEFAULT NULL,
  `Precio` int DEFAULT NULL,
  `ID_Categoria` int DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `ID_Categoria` (`ID_Categoria`)
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `platos`
--

INSERT INTO `platos` (`ID`, `Nombre`, `Descripcion`, `Precio`, `ID_Categoria`) VALUES
(3, 'Cerveza Pilsen 1 lt', '', 220, 1),
(4, 'Cerveza Pilsen 1/3 l', '', 95, 1),
(5, 'Cerveza Patricia 1 l', '', 240, 1),
(6, 'Coca Cola 600 ', '', 90, 2),
(9, 'Fanta 600 ', '', 90, 2),
(10, 'Sprite 600 ', '', 90, 2),
(11, 'Coca Cola 1 lt ', '', 140, 2),
(12, 'Fanta 1 lt ', '', 140, 2),
(13, 'Sprite 1 lt ', '', 140, 2),
(14, 'Coca Cola 1 1/2 lt ', '', 180, 2),
(15, 'Pomelo 1 1/2 lt ', '', 180, 2),
(16, 'Agua 600 ', '', 60, 2),
(17, 'Vino de la casa', 'La copa', 90, 3),
(18, 'Vino de la casa', 'Jarra de 1/2 lts', 160, 3),
(19, 'Milanesa picada con ', '', 250, 4),
(20, 'Milanesa picada con ', '', 260, 4),
(21, 'Milanesa con muzzare', '', 280, 4),
(22, 'Milanesa c/ jamón y ', '', 290, 4),
(23, 'Milanesa Napolitana', '', 300, 4),
(24, 'Milanesa al pan', '', 250, 4),
(25, 'Milanesa en 2 panes', '', 280, 4),
(26, 'Milanesa especial en', '', 340, 4),
(27, 'Costilla a la planch', '', 290, 4),
(28, 'Jamon con rusa', '', 250, 4),
(29, 'Papas fritas', '', 150, 4),
(30, 'Ensalada mixta', '', 150, 4),
(31, 'Ensalada rusa', '', 150, 4),
(32, 'Frankfruters', 'Super largo', 80, 5),
(33, 'Frankfruters', 'Super largo c/ muzzarella', 130, 5),
(34, 'Frankfruters', 'Super largo c/ panceta', 170, 5),
(35, 'Frankfruters', 'Super largo c/ panceta y muzzarella', 200, 5),
(36, 'Frankfruters', 'Super largo napolitano', 200, 5),
(37, 'Chivito al pan', 'Lechuga,Tomate,Jamón,Panceta,Churrasco de lomo,Ace', 260, 6),
(38, 'Chivito Canadiense', 'Lechuga,Tomate,Jamón,Panceta,Churrasco de lomo,Ace', 290, 6),
(39, 'Chivito de la Casa', 'C/Muzzarella y Fritas', 340, 6),
(40, 'Chivito al Plato', 'Ensalada rusa, + mixta,Doble churrascos,Huevo duro', 340, 6),
(41, 'Sandwich caliente', 'Plancha', 190, 7),
(42, 'Sandwich caliente', 'C/Muzzarella', 260, 7),
(43, 'Sandwich caliente', 'C/Muzzarella y Aceitunas', 270, 7),
(44, 'Sandwich caliente', 'C/Muzzarella napolitana', 290, 7),
(45, 'Pizzeta con muzzarel', '', 130, 8),
(46, 'Pizzeta con jamon y ', '', 170, 8),
(47, 'Pizzeta Napolitana', '', 190, 8),
(48, 'Pizzeta', 'Jamón,Muzzarella,Aceitunas', 190, 8);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `factura`
--
ALTER TABLE `factura`
  ADD CONSTRAINT `factura_ibfk_1` FOREIGN KEY (`Número_Pedido`) REFERENCES `pedidos` (`Número`),
  ADD CONSTRAINT `factura_ibfk_2` FOREIGN KEY (`Número_Pedido`) REFERENCES `pedidos` (`Número`);

--
-- Constraints for table `pedidos`
--
ALTER TABLE `pedidos`
  ADD CONSTRAINT `pedidos_ibfk_1` FOREIGN KEY (`ID_Usuario`) REFERENCES `empleados` (`ID`);

--
-- Constraints for table `platos`
--
ALTER TABLE `platos`
  ADD CONSTRAINT `platos_ibfk_1` FOREIGN KEY (`ID_Categoria`) REFERENCES `categoria` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
