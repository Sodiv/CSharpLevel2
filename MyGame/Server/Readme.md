1. Создать БД listingemployee на сервере (localdb)\MSSQLLocalDB

2. В БД выполнить запросы:
CREATE TABLE [dbo].[Department] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE TABLE [dbo].[Employee] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50) NOT NULL,
    [Age]          INT           NOT NULL,
    [DepartmentId] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

3. Для первоначального заполнения расскомментировать регион "Заполнение БД" в файле GetEmployee

4. Выполнить запрос getemployee