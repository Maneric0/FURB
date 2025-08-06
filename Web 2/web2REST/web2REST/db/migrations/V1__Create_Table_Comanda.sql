CREATE TABLE IF NOT EXISTS `comanda` (
  `id` INT PRIMARY KEY AUTO_INCREMENT,
  `idUsuario` int NOT NULL,
  `nomeUsuario` varchar(100) NOT NULL,
  `telefoneUsuario` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;