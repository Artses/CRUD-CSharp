CREATE DATABASE BdExemplo;

USE BdExemplo;

CREATE TABLE tblProduto(
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    descricao VARCHAR(20) NOT NULL,
    quantidade INT NOT NULL,
	dtValidade DATE NOT NULL
);

