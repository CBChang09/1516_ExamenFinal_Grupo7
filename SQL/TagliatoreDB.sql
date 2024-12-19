CREATE DATABASE TagliatoreDB;
GO

USE TagliatoreDB;
GO


CREATE TABLE Platillos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Ingredientes NVARCHAR(MAX) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Imagen NVARCHAR(MAX) NULL,
    FechaCreacion DATETIME DEFAULT GETDATE()
);
GO


CREATE TABLE Clientes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Correo NVARCHAR(100) NOT NULL,
    Telefono NVARCHAR(20) NOT NULL,
    DNI NVARCHAR(15) NOT NULL,
    FechaRegistro DATETIME DEFAULT GETDATE()
);
GO


CREATE TABLE Ordenes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdMesa INT NOT NULL,
    IdCliente INT NOT NULL,
    Estado NVARCHAR(20) NOT NULL CHECK (Estado IN ('pendiente', 'entregado', 'cancelado')),
    FechaOrden DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (IdCliente) REFERENCES Clientes(Id)
);
GO


CREATE TABLE Ordenes_Detalle (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdOrden INT NOT NULL,
    IdPlatillo INT NOT NULL,
    Cantidad INT NOT NULL CHECK (Cantidad > 0),
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (IdOrden) REFERENCES Ordenes(Id),
    FOREIGN KEY (IdPlatillo) REFERENCES Platillos(Id)
);
GO


CREATE TABLE Usuarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Correo NVARCHAR(100) NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    Eliminado BIT DEFAULT 0
);
GO
