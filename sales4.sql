-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 09-02-2017 a las 11:13:42
-- Versión del servidor: 10.1.16-MariaDB
-- Versión de PHP: 5.6.24

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `sales4`
--

DELIMITER $$
--
-- Procedimientos
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteOnProduct` (`pidproduct` INT)  BEGIN
delete  from products where products.idproduct = pidproduct;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertOnProduct` (`pname` VARCHAR(30), `pdescription` VARCHAR(100), `ppurchaseprice` DECIMAL(11,2), `psaleprice` DECIMAL(11,2), `pstock` INT, `pfkprovider` INT)  BEGIN
insert into products (name,description,purchaseprice,saleprice,stock,fkprovider) values (pname,pdescription,ppurchaseprice,psaleprice,pstock,pfkprovider);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertOnPurchase` (OUT `pidout` INT, IN `pdate` DATE, IN `ptotal` DECIMAL(11,2))  BEGIN 
insert into purchase (purchase.datepurchase, purchase.totalpurchase) values (pdate,ptotal);
set pidout = @@IDENTITY;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertOnPurchaseDetail` (IN `pidpurchase` INT, IN `pfkproduct` INT, IN `pquantity` INT)  BEGIN 
insert into detailpurchase (detailpurchase.fkdppuchase,detailpurchase.fkdpproduct,detailpurchase.quantity) values (pidpurchase,pfkproduct,pquantity);
update products set products.stock = products.stock + pquantity;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertOnSale` (OUT `idout` INT, `pdate` DATE, `ptotal` DECIMAL(11,2))  BEGIN
insert into sale (sale.date,sale.total) values (pdate,ptotal);
SET idout = @@IDENTITY;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertOnSaleDetail` (`pfkproduct` INT, `pfksale` INT, `pfkuser` INT, `pquantity` INT)  BEGIN
insert into saledetail (fkproduct,fksale,fkuser,quantity) values (pfkproduct,pfksale,pfkuser,pquantity);
update products set products.stock = products.stock - pquantity where products.idproduct= pfkproduct;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectAllProviders` ()  BEGIN
select * from providers ;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectProductById` (IN `pfk` INT)  BEGIN
select * from products where products.fkprovider =pfk;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectProductByName` (IN `pname` VARCHAR(30))  BEGIN
select * from products WHERE products.name =pname;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectProducts` ()  begin 
select * from products ;
end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectUserByUserPass` (`pusername` VARCHAR(30), `ppassword` VARCHAR(30))  BEGIN
select * from users where users.username = pusername and users.password= ppassword;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateOnProduct` (IN `pname` VARCHAR(30), IN `pdescription` VARCHAR(100), IN `ppurchaseprice` DECIMAL(11,2), IN `psaleprice` DECIMAL(11,2), IN `pstock` INT, IN `pfkprovider` INT, IN `pidproduct` INT)  BEGIN
update products set products.name = pname, products.description = pdescription, products.purchaseprice = ppurchaseprice,products.saleprice = psaleprice, products.stock = pstock, products.fkprovider = pfkprovider
WHERE products.idproduct = pidproduct;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `bill`
--

CREATE TABLE `bill` (
  `idbill` int(11) NOT NULL,
  `fkbsale` int(11) DEFAULT NULL,
  `fkbclient` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clients`
--

CREATE TABLE `clients` (
  `idclient` int(11) NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `type` varchar(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detailpurchase`
--

CREATE TABLE `detailpurchase` (
  `idpurchasedetail` int(11) NOT NULL,
  `fkdppuchase` int(11) DEFAULT NULL,
  `fkdpproduct` int(11) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `detailpurchase`
--

INSERT INTO `detailpurchase` (`idpurchasedetail`, `fkdppuchase`, `fkdpproduct`, `quantity`) VALUES
(1, 1, 2, 4);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `products`
--

CREATE TABLE `products` (
  `idproduct` int(11) NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `description` varchar(100) DEFAULT NULL,
  `purchaseprice` decimal(11,2) DEFAULT NULL,
  `saleprice` decimal(11,2) DEFAULT NULL,
  `stock` int(11) DEFAULT NULL,
  `fkprovider` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `products`
--

INSERT INTO `products` (`idproduct`, `name`, `description`, `purchaseprice`, `saleprice`, `stock`, `fkprovider`) VALUES
(2, 'Mayonnaise2', '160 ml', '15.00', '25.00', 12, 1),
(3, 'coco2', '1kg', '55.00', '105.00', 9, 1),
(4, 'Charola 855', '50 pzas', '14.50', '16.90', 59, 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `providers`
--

CREATE TABLE `providers` (
  `idprovider` int(11) NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `surnames` varchar(100) DEFAULT NULL,
  `direction` varchar(100) DEFAULT NULL,
  `type` varchar(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `providers`
--

INSERT INTO `providers` (`idprovider`, `name`, `surnames`, `direction`, `type`) VALUES
(1, 'Daniel', 'Ramirez Martinez', 'Calle primavera # 13', 'Fisica'),
(2, 'Edgar', 'Ramirez Martinez', 'Calle doctor belloso # 33', 'Fisica');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `purchase`
--

CREATE TABLE `purchase` (
  `idpurchase` int(11) NOT NULL,
  `datepurchase` date DEFAULT NULL,
  `totalpurchase` decimal(11,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `purchase`
--

INSERT INTO `purchase` (`idpurchase`, `datepurchase`, `totalpurchase`) VALUES
(1, '2016-12-11', '69.60');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sale`
--

CREATE TABLE `sale` (
  `idsale` int(11) NOT NULL,
  `date` date DEFAULT NULL,
  `total` decimal(11,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sale`
--

INSERT INTO `sale` (`idsale`, `date`, `total`) VALUES
(1, '2016-11-04', '179.80');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `saledetail`
--

CREATE TABLE `saledetail` (
  `idsaledetail` int(11) NOT NULL,
  `fkproduct` int(11) DEFAULT NULL,
  `fksale` int(11) DEFAULT NULL,
  `fkuser` int(11) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `saledetail`
--

INSERT INTO `saledetail` (`idsaledetail`, `fkproduct`, `fksale`, `fkuser`, `quantity`) VALUES
(1, 2, 1, 1, 2),
(2, 3, 1, 1, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `users`
--

CREATE TABLE `users` (
  `iduser` int(11) NOT NULL,
  `username` varchar(30) DEFAULT NULL,
  `password` varchar(30) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `surnames` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `users`
--

INSERT INTO `users` (`iduser`, `username`, `password`, `name`, `surnames`) VALUES
(1, 'dany', '123', 'Daniel', 'Ramirez Martinez'),
(2, 'alicia', '123456', 'Alicia', ' Martiez Gonzalez');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `bill`
--
ALTER TABLE `bill`
  ADD PRIMARY KEY (`idbill`),
  ADD KEY `fk_fksale_sale_idx` (`fkbsale`),
  ADD KEY `fk_fkclient_clients_idx` (`fkbclient`);

--
-- Indices de la tabla `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`idclient`);

--
-- Indices de la tabla `detailpurchase`
--
ALTER TABLE `detailpurchase`
  ADD PRIMARY KEY (`idpurchasedetail`),
  ADD KEY `fk_fkproduct_products_idx` (`fkdpproduct`),
  ADD KEY `fk_fkpurchase_purchase_idx` (`fkdppuchase`);

--
-- Indices de la tabla `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`idproduct`),
  ADD KEY `fk_fkprovider_providers_idx` (`fkprovider`);

--
-- Indices de la tabla `providers`
--
ALTER TABLE `providers`
  ADD PRIMARY KEY (`idprovider`);

--
-- Indices de la tabla `purchase`
--
ALTER TABLE `purchase`
  ADD PRIMARY KEY (`idpurchase`);

--
-- Indices de la tabla `sale`
--
ALTER TABLE `sale`
  ADD PRIMARY KEY (`idsale`);

--
-- Indices de la tabla `saledetail`
--
ALTER TABLE `saledetail`
  ADD PRIMARY KEY (`idsaledetail`),
  ADD KEY `fk_fkproduct_products_idx` (`fkproduct`),
  ADD KEY `fk_fksale_sale_idx` (`fksale`),
  ADD KEY `fk_fkuser_users_idx` (`fkuser`);

--
-- Indices de la tabla `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`iduser`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `bill`
--
ALTER TABLE `bill`
  MODIFY `idbill` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `clients`
--
ALTER TABLE `clients`
  MODIFY `idclient` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `detailpurchase`
--
ALTER TABLE `detailpurchase`
  MODIFY `idpurchasedetail` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT de la tabla `products`
--
ALTER TABLE `products`
  MODIFY `idproduct` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT de la tabla `providers`
--
ALTER TABLE `providers`
  MODIFY `idprovider` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT de la tabla `purchase`
--
ALTER TABLE `purchase`
  MODIFY `idpurchase` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT de la tabla `sale`
--
ALTER TABLE `sale`
  MODIFY `idsale` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT de la tabla `saledetail`
--
ALTER TABLE `saledetail`
  MODIFY `idsaledetail` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT de la tabla `users`
--
ALTER TABLE `users`
  MODIFY `iduser` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `bill`
--
ALTER TABLE `bill`
  ADD CONSTRAINT `fk_fkbclient_clients` FOREIGN KEY (`fkbclient`) REFERENCES `clients` (`idclient`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_fkbsale_sale` FOREIGN KEY (`fkbsale`) REFERENCES `sale` (`idsale`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `detailpurchase`
--
ALTER TABLE `detailpurchase`
  ADD CONSTRAINT `fk_fkdpproduct_products` FOREIGN KEY (`fkdpproduct`) REFERENCES `products` (`idproduct`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_fkdppurchase_purchase` FOREIGN KEY (`fkdppuchase`) REFERENCES `purchase` (`idpurchase`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `products`
--
ALTER TABLE `products`
  ADD CONSTRAINT `fk_fkprovider_providers` FOREIGN KEY (`fkprovider`) REFERENCES `providers` (`idprovider`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `saledetail`
--
ALTER TABLE `saledetail`
  ADD CONSTRAINT `fk_fkproduct_products` FOREIGN KEY (`fkproduct`) REFERENCES `products` (`idproduct`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_fksale_sale` FOREIGN KEY (`fksale`) REFERENCES `sale` (`idsale`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_fkuser_users` FOREIGN KEY (`fkuser`) REFERENCES `users` (`iduser`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
