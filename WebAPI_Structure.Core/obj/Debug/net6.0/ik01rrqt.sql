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

CREATE TABLE [Category] (
    [CategoryId] bigint NOT NULL IDENTITY,
    [CategoryName] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY ([CategoryId])
);
GO

CREATE TABLE [UserAdmin] (
    [UserId] bigint NOT NULL IDENTITY,
    [FirstName] nvarchar(50) NULL,
    [LastName] nvarchar(50) NULL,
    [Email] nvarchar(50) NULL,
    [Password] nvarchar(500) NULL,
    [CreatedBy] nvarchar(50) NULL,
    [CreatedOn] datetime NULL,
    [ModifiedBy] nvarchar(50) NULL,
    [ModifiedOn] datetime NULL,
    [IsDeleted] bit NULL,
    [IsActive] bit NULL,
    CONSTRAINT [PK_UserAdmin] PRIMARY KEY ([UserId])
);
GO

CREATE TABLE [Products] (
    [ProductId] bigint NOT NULL IDENTITY,
    [ProductName] nvarchar(50) NULL,
    [CategoryId] bigint NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([ProductId]),
    CONSTRAINT [FK_Products_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([CategoryId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Products_CategoryId] ON [Products] ([CategoryId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230721091623_first', N'7.0.9');
GO

COMMIT;
GO

