USE [master]
GO
/****** Object:  Database [QLThuVien]    Script Date: 5/14/2018 9:15:16 PM ******/
CREATE DATABASE [QLThuVien]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLThuVien', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QLThuVien.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLThuVien_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QLThuVien_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLThuVien] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLThuVien].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLThuVien] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLThuVien] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLThuVien] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLThuVien] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLThuVien] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLThuVien] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLThuVien] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLThuVien] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLThuVien] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLThuVien] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLThuVien] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLThuVien] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLThuVien] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLThuVien] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLThuVien] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLThuVien] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLThuVien] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLThuVien] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLThuVien] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLThuVien] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLThuVien] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLThuVien] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLThuVien] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLThuVien] SET  MULTI_USER 
GO
ALTER DATABASE [QLThuVien] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLThuVien] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLThuVien] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLThuVien] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QLThuVien] SET DELAYED_DURABILITY = DISABLED 
GO
USE [QLThuVien]
GO
/****** Object:  Table [dbo].[ChiTietPhieuMuon]    Script Date: 5/14/2018 9:15:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuMuon](
	[MaPhieuMuon] [int] NOT NULL,
	[MaSach] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuMuon] ASC,
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DocGia]    Script Date: 5/14/2018 9:15:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocGia](
	[mssv] [nchar](11) NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[GioiTinh] [bit] NULL,
	[NgayMoThe] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[mssv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiSach]    Script Date: 5/14/2018 9:15:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LoaiSach](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pid]  AS ('LS'+right('000'+CONVERT([varchar](5),[id]),(6))) PERSISTED,
	[Ten] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NganhKhoa]    Script Date: 5/14/2018 9:15:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NganhKhoa](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pid]  AS ('NGK'+right('000'+CONVERT([varchar](5),[id]),(6))) PERSISTED,
	[Ten] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 5/14/2018 9:15:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pid]  AS ('NV'+right('000'+CONVERT([varchar](5),[id]),(6))) PERSISTED,
	[Ten] [nvarchar](50) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[GioiTinh] [bit] NULL,
	[ChucVu] [nchar](10) NULL,
	[MatKhau] [nchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhaXuatBan]    Script Date: 5/14/2018 9:15:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhaXuatBan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pid]  AS ('NXB'+right('000'+CONVERT([varchar](5),[id]),(6))) PERSISTED,
	[Ten] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhieuMuonSach]    Script Date: 5/14/2018 9:15:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhieuMuonSach](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pid]  AS ('PMS'+right('000'+CONVERT([varchar](5),[id]),(6))) PERSISTED,
	[NgayMuon] [date] NOT NULL,
	[HanTra] [date] NOT NULL,
	[NguoiLapPhieu] [int] NULL,
	[NguoiMuon] [nchar](11) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 5/14/2018 9:15:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sach](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pid]  AS ('SACH'+right('000'+CONVERT([varchar](5),[id]),(6))) PERSISTED,
	[Ten] [nvarchar](50) NOT NULL,
	[TacGia] [int] NULL,
	[NamXB] [int] NULL,
	[NhaXB] [int] NULL,
	[MoTa] [nvarchar](100) NULL,
	[DuongDanAnh] [nvarchar](200) NULL,
	[LoaiSach] [int] NULL,
	[NganhKhoa] [int] NULL,
	[SoLuongHienCo] [int] NOT NULL,
	[SoLuongDaMuon] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TacGia]    Script Date: 5/14/2018 9:15:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TacGia](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pid]  AS ('TG'+right('000'+CONVERT([varchar](5),[id]),(6))) PERSISTED,
	[Ten] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ViPham]    Script Date: 5/14/2018 9:15:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ViPham](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NoiDung] [nvarchar](100) NULL,
	[mssv] [nchar](11) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ChiTietPhieuMuon]  WITH CHECK ADD FOREIGN KEY([MaPhieuMuon])
REFERENCES [dbo].[PhieuMuonSach] ([id])
GO
ALTER TABLE [dbo].[ChiTietPhieuMuon]  WITH CHECK ADD FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([id])
GO
ALTER TABLE [dbo].[PhieuMuonSach]  WITH CHECK ADD FOREIGN KEY([NguoiLapPhieu])
REFERENCES [dbo].[NhanVien] ([id])
GO
ALTER TABLE [dbo].[PhieuMuonSach]  WITH CHECK ADD FOREIGN KEY([NguoiMuon])
REFERENCES [dbo].[DocGia] ([mssv])
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD FOREIGN KEY([LoaiSach])
REFERENCES [dbo].[LoaiSach] ([id])
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD FOREIGN KEY([NganhKhoa])
REFERENCES [dbo].[NganhKhoa] ([id])
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD FOREIGN KEY([NhaXB])
REFERENCES [dbo].[NhaXuatBan] ([id])
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD FOREIGN KEY([TacGia])
REFERENCES [dbo].[TacGia] ([id])
GO
ALTER TABLE [dbo].[ViPham]  WITH CHECK ADD FOREIGN KEY([mssv])
REFERENCES [dbo].[DocGia] ([mssv])
GO
USE [master]
GO
ALTER DATABASE [QLThuVien] SET  READ_WRITE 
GO
