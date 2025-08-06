CREATE TABLE `produto` (
  `id` int primary key AUTO_INCREMENT,
  `nome` varchar(100) NOT NULL,
  `preco` decimal(10,2) NOT NULL,
  `comandaId` int NOT NULL,
  FOREIGN KEY (comandaId) REFERENCES comanda(id) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
