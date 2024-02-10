IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Products] (
    [ProductId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [StatusName] nvarchar(1) NULL,
    [Stock] nvarchar(40) NULL,
    [Descripcion] nvarchar(max) NULL,
    [Price] nvarchar(40) NULL,
    [Discount] nvarchar(40) NULL,
    [FinalPrice] nvarchar(40) NULL,
    [DateCreated] datetime2 NOT NULL,
    [LastModified] datetime2 NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([ProductId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231105045823_initial', N'7.0.13');
GO

COMMIT;
GO

