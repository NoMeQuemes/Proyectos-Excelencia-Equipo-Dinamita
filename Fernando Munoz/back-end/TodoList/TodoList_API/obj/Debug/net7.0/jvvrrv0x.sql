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

CREATE TABLE [Tareas] (
    [Id] int NOT NULL IDENTITY,
    [Titulo] nvarchar(max) NOT NULL,
    [Detalle] nvarchar(max) NOT NULL,
    [UsuarioCreador] int NOT NULL,
    [FechaCreacion] datetime2 NOT NULL,
    [FechaActualizacion] datetime2 NOT NULL,
    [FechaEliminacion] datetime2 NOT NULL,
    CONSTRAINT [PK_Tareas] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240423115542_CreacionDb', N'7.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Detalle', N'FechaActualizacion', N'FechaCreacion', N'FechaEliminacion', N'Titulo', N'UsuarioCreador') AND [object_id] = OBJECT_ID(N'[Tareas]'))
    SET IDENTITY_INSERT [Tareas] ON;
INSERT INTO [Tareas] ([Id], [Detalle], [FechaActualizacion], [FechaCreacion], [FechaEliminacion], [Titulo], [UsuarioCreador])
VALUES (1, N'hola', '2024-04-23T09:14:30.4034903-03:00', '2024-04-23T09:14:30.4034889-03:00', '2024-04-23T09:14:30.4034904-03:00', N'Sacar a pasear perros', 1),
(2, N'hola', '2024-04-23T09:14:30.4034907-03:00', '2024-04-23T09:14:30.4034906-03:00', '2024-04-23T09:14:30.4034908-03:00', N'Ir a hacer las compras', 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Detalle', N'FechaActualizacion', N'FechaCreacion', N'FechaEliminacion', N'Titulo', N'UsuarioCreador') AND [object_id] = OBJECT_ID(N'[Tareas]'))
    SET IDENTITY_INSERT [Tareas] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240423121430_SeCreaDatos', N'7.0.12');
GO

COMMIT;
GO

