USE [master]
GO

/****** Object:  Database [EAD_JET]    Script Date: 10/24/2021 10:36:01 PM ******/
DROP DATABASE [EAD_JET]
GO

/****** Object:  Database [EAD_JET]    Script Date: 10/24/2021 10:36:01 PM ******/
CREATE DATABASE [EAD_JET]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EAD_JET', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\EAD_JET.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EAD_JET_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\EAD_JET_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [EAD_JET] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EAD_JET].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [EAD_JET] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [EAD_JET] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [EAD_JET] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [EAD_JET] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [EAD_JET] SET ARITHABORT OFF 
GO

ALTER DATABASE [EAD_JET] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [EAD_JET] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [EAD_JET] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [EAD_JET] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [EAD_JET] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [EAD_JET] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [EAD_JET] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [EAD_JET] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [EAD_JET] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [EAD_JET] SET  DISABLE_BROKER 
GO

ALTER DATABASE [EAD_JET] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [EAD_JET] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [EAD_JET] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [EAD_JET] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [EAD_JET] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [EAD_JET] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [EAD_JET] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [EAD_JET] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [EAD_JET] SET  MULTI_USER 
GO

ALTER DATABASE [EAD_JET] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [EAD_JET] SET DB_CHAINING OFF 
GO

ALTER DATABASE [EAD_JET] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [EAD_JET] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [EAD_JET] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [EAD_JET] SET  READ_WRITE 
GO


USE [EAD_JET]
GO

/****** Object:  Table [dbo].[AIRCRAFTS]    Script Date: 10/24/2021 10:36:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AIRCRAFTS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[QUANTITY] [int] NOT NULL,
	[MANUFACTURER] [nchar](100) NOT NULL,
	[TYPE] [nchar](100) NOT NULL,
	[CREWFLIGHT] [int] NOT NULL,
	[CABIN] [nchar](10) NOT NULL,
	[RANGE_KM] [int] NOT NULL,
	[CAPACITY] [int] NOT NULL,
	[CRUISING_SPEED_KMPH] [int] NOT NULL,
	[ENGINES] [int] NOT NULL,
	[ENGINE_TYPE] [nchar](100) NOT NULL,
	[ANNUAL_FIXED_COST] [float] NULL,
	[HOURLY_COST] [float] NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[AIRCRAFTS] SET (LOCK_ESCALATION = DISABLE)
GO



USE [EAD_JET]
GO

/****** Object:  Table [dbo].[PERSONNEL-COST]    Script Date: 10/24/2021 10:38:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PERSONNEL-COST](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ROLE] [nchar](100) NOT NULL,
	[SALARY] [float] NOT NULL
) ON [PRIMARY]

GO



