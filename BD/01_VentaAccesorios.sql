IF DB_ID('VentaAccesorios') IS NULL CREATE DATABASE VentaAccesorios;
GO
USE VentaAccesorios;
GO
CREATE TABLE Marcas (
    IdMarca INT IDENTITY(1,1) PRIMARY KEY,
    Nombre  NVARCHAR(60) NOT NULL
);
CREATE TABLE Productos (
    IdProducto INT IDENTITY(1,1) PRIMARY KEY,
    Nombre     NVARCHAR(100) NOT NULL,
    Categoria  NVARCHAR(50)  NOT NULL,   -- Funda, Cargador, Mica, Audifonos...
    Precio     DECIMAL(10,2) NOT NULL,
    Stock      INT NOT NULL DEFAULT 0,
    IdMarca    INT NOT NULL REFERENCES Marcas(IdMarca)
);
CREATE TABLE Usuarios (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Nombre    NVARCHAR(100) NOT NULL,
    Correo    NVARCHAR(100) NOT NULL,
    Rol       NVARCHAR(30)  NOT NULL     -- Administrador, Vendedor
);
INSERT INTO Marcas (Nombre) VALUES ('Samsung'),('Apple'),('Xiaomi'),('Anker'),('Spigen');
INSERT INTO Productos (Nombre, Categoria, Precio, Stock, IdMarca) VALUES
('Cargador rapido 25W','Cargador',299.00,30,1),
('Cable USB-C a Lightning','Cable',249.00,45,2),
('Audifonos inalambricos','Audifonos',599.00,15,3),
('Power bank 10000 mAh','Bateria externa',449.00,20,4),
('Funda antigolpes','Funda',189.00,60,5),
('Mica de cristal templado','Mica',99.00,100,5);
INSERT INTO Usuarios (Nombre, Correo, Rol) VALUES
('Jonathan','jonathan@correo.com','Administrador'),
('Vendedor 1','vendedor1@correo.com','Vendedor');
GO
