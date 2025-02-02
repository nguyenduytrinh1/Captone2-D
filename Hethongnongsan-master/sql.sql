USE [master]
GO
/****** Object:  Database [Hethongnongsan]    Script Date: 5/2/2024 10:00:16 PM ******/
CREATE DATABASE [Hethongnongsan]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Hethongnongsan', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.DUYTRINH\MSSQL\DATA\Hethongnongsan.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Hethongnongsan_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.DUYTRINH\MSSQL\DATA\Hethongnongsan_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Hethongnongsan] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Hethongnongsan].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Hethongnongsan] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Hethongnongsan] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Hethongnongsan] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Hethongnongsan] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Hethongnongsan] SET ARITHABORT OFF 
GO
ALTER DATABASE [Hethongnongsan] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Hethongnongsan] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Hethongnongsan] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Hethongnongsan] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Hethongnongsan] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Hethongnongsan] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Hethongnongsan] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Hethongnongsan] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Hethongnongsan] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Hethongnongsan] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Hethongnongsan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Hethongnongsan] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Hethongnongsan] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Hethongnongsan] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Hethongnongsan] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Hethongnongsan] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Hethongnongsan] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Hethongnongsan] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Hethongnongsan] SET  MULTI_USER 
GO
ALTER DATABASE [Hethongnongsan] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Hethongnongsan] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Hethongnongsan] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Hethongnongsan] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Hethongnongsan] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Hethongnongsan] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Hethongnongsan] SET QUERY_STORE = ON
GO
ALTER DATABASE [Hethongnongsan] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Hethongnongsan]
GO
/****** Object:  Table [dbo].[Forum]    Script Date: 5/2/2024 10:00:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forum](
	[iddiendang] [int] IDENTITY(1,1) NOT NULL,
	[context] [text] NULL,
	[ngaydang] [date] NULL,
	[img] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[iddiendang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nguoidung]    Script Date: 5/2/2024 10:00:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nguoidung](
	[idnguoidung] [int] IDENTITY(1,1) NOT NULL,
	[tennguoidung] [nvarchar](255) NULL,
	[diachi] [nvarchar](255) NULL,
	[gioitinh] [nvarchar](10) NULL,
	[idshop] [int] NULL,
	[idshopcart] [int] NULL,
	[TaiKhoan] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](50) NULL,
	[sodienthoai] [nvarchar](20) NULL,
	[ngaysinh] [date] NULL,
	[Roles] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idnguoidung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sanpham]    Script Date: 5/2/2024 10:00:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sanpham](
	[idsanpham] [int] IDENTITY(1,1) NOT NULL,
	[tensanpham] [nvarchar](100) NULL,
	[idshop] [int] NULL,
	[tenloai] [nvarchar](50) NULL,
	[gioithieu] [nvarchar](max) NULL,
	[gia] [decimal](18, 2) NULL,
	[linkhinhanh] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[idsanpham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPhamDaBan]    Script Date: 5/2/2024 10:00:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPhamDaBan](
	[idsanphamdaban] [int] IDENTITY(1,1) NOT NULL,
	[idsp] [nvarchar](150) NULL,
	[ngayban] [date] NULL,
	[idshop] [nvarchar](250) NULL,
	[diachi] [nvarchar](200) NULL,
	[tongtien] [float] NULL,
	[idnguoimua] [int] NULL,
	[tensanpham] [nvarchar](250) NULL,
	[idshopcart] [nvarchar](250) NULL,
 CONSTRAINT [PK__SanPhamD__9B35B4979F7790AD] PRIMARY KEY CLUSTERED 
(
	[idsanphamdaban] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop]    Script Date: 5/2/2024 10:00:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop](
	[idshop] [int] IDENTITY(1,1) NOT NULL,
	[idchusohuu] [int] NULL,
	[ngaythanhlap] [date] NULL,
	[gioithieu] [nvarchar](max) NULL,
	[logo] [nvarchar](255) NULL,
	[tenshop] [nvarchar](100) NULL,
	[diachi] [nvarchar](255) NULL,
	[sdt] [nvarchar](20) NULL,
	[email] [nvarchar](100) NULL,
	[facebook] [nvarchar](255) NULL,
	[instagram] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[idshop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shopcart]    Script Date: 5/2/2024 10:00:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shopcart](
	[idshopcart] [int] IDENTITY(1,1) NOT NULL,
	[idnguoidung] [int] NULL,
	[idsanpham] [int] NULL,
	[soluong] [int] NULL,
	[status] [int] NULL,
	[idshop] [int] NULL,
	[ngaymua] [date] NULL,
	[diemden] [nvarchar](250) NULL,
	[tongtien] [float] NULL,
 CONSTRAINT [PK__shopcart__9EC0A4ADA8DC73CA] PRIMARY KEY CLUSTERED 
(
	[idshopcart] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Hethongnongsan] SET  READ_WRITE 
GO
