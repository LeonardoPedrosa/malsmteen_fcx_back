# FCx

USE [master]
GO

/****** Object:  Database [fcx]    Script Date: 22/02/2024 23:43:22 ******/
CREATE DATABASE [fcx]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'fcx', FILENAME = N'C:\Users\leonardo.pedrosa\fcx.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'fcx_log', FILENAME = N'C:\Users\leonardo.pedrosa\fcx_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [fcx].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [fcx] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [fcx] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [fcx] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [fcx] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [fcx] SET ARITHABORT OFF 
GO

ALTER DATABASE [fcx] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [fcx] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [fcx] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [fcx] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [fcx] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [fcx] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [fcx] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [fcx] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [fcx] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [fcx] SET  ENABLE_BROKER 
GO

ALTER DATABASE [fcx] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [fcx] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [fcx] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [fcx] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [fcx] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [fcx] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [fcx] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [fcx] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [fcx] SET  MULTI_USER 
GO

ALTER DATABASE [fcx] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [fcx] SET DB_CHAINING OFF 
GO

ALTER DATABASE [fcx] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [fcx] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [fcx] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [fcx] SET QUERY_STORE = OFF
GO

ALTER DATABASE [fcx] SET  READ_WRITE 
GO


USE [fcx]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 22/02/2024 23:44:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Login] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[Phone] [varchar](20) NULL,
	[Document] [varchar](14) NULL,
	[DateBirth] [datetime] NOT NULL,
	[MotherName] [varchar](100) NULL,
	[Status] [bit] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[Generation] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Users] ADD  DEFAULT ((1)) FOR [Status]
GO


INSERT INTO [Users] (Name, Login, Password, Email, Phone, Document, DateBirth, MotherName, Status, CreatedAt, UpdatedAt, Generation)
VALUES 
('John Doe', 'john_doe', 'password123', 'john.doe@example.com', '123-456-7890', '12345678901234', '1990-05-15 00:00:00', 'Jane Doe', 1, '2024-02-22 08:00:00', '2024-02-22 08:00:00', 'Millennials'),
('Alice Smith', 'alice_smith', 'password456', 'alice.smith@example.com', '987-654-3210', '98765432109876', '1985-08-20 00:00:00', 'Emily Smith', 1, '2024-02-22 09:00:00', '2024-02-22 09:00:00', 'Gen Z'),
('Bob Johnson', 'bob_johnson', 'password789', 'bob.johnson@example.com', '111-222-3333', '11122233334444', '1978-03-10 00:00:00', 'Sarah Johnson', 1, '2024-02-22 10:00:00', '2024-02-22 10:00:00', 'Baby Boomers'),
('Emma Davis', 'emma_davis', 'passwordabc', 'emma.davis@example.com', '444-555-6666', '44455566667777', '1995-11-25 00:00:00', 'Olivia Davis', 1, '2024-02-22 11:00:00', '2024-02-22 11:00:00', 'Millennials'),
('Michael Brown', 'michael_brown', 'passworddef', 'michael.brown@example.com', '777-888-9999', '77788899991111', '1980-12-05 00:00:00', 'Jessica Brown', 1, '2024-02-22 12:00:00', '2024-02-22 12:00:00', 'Gen X'),
('Olivia Wilson', 'olivia_wilson', 'passwordghi', 'olivia.wilson@example.com', '222-333-4444', '22233344445555', '2000-09-30 00:00:00', 'Sophia Wilson', 1, '2024-02-22 13:00:00', '2024-02-22 13:00:00', 'Gen Z'),
('David Martinez', 'david_martinez', 'passwordjkl', 'david.martinez@example.com', '666-777-8888', '66677788889999', '1973-07-18 00:00:00', 'Maria Martinez', 1, '2024-02-22 14:00:00', '2024-02-22 14:00:00', 'Baby Boomers'),
('Sophia Rodriguez', 'sophia_rodriguez', 'passwordmno', 'sophia.rodriguez@example.com', '555-666-7777', '55566677770000', '1998-04-12 00:00:00', 'Isabella Rodriguez', 1, '2024-02-22 15:00:00', '2024-02-22 15:00:00', 'Millennials'),
('Matthew Lee', 'matthew_lee', 'passwordpqr', 'matthew.lee@example.com', '999-888-7777', '99988877771111', '1988-01-20 00:00:00', 'Hannah Lee', 1, '2024-02-22 16:00:00', '2024-02-22 16:00:00', 'Gen X'),
('Ava Taylor', 'ava_taylor', 'passwordstu', 'ava.taylor@example.com', '333-444-5555', '33344455556666', '1992-06-08 00:00:00', 'Mia Taylor', 1, '2024-02-22 17:00:00', '2024-02-22 17:00:00', 'Millennials');
