USE [QLThuVien]
GO
/****** Object:  Table [dbo].[ChiTietPhieuMuon]    Script Date: 6/17/2018 9:41:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuMuon](
	[MaPhieuMuon] [int] NOT NULL,
	[MaSach] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
 CONSTRAINT [PK__ChiTietP__0FEB7560B9FC1552] PRIMARY KEY CLUSTERED 
(
	[MaPhieuMuon] ASC,
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DocGia]    Script Date: 6/17/2018 9:41:41 PM ******/
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
	[Disable] [bit] NOT NULL,
 CONSTRAINT [PK__DocGia__763F1CDDB882C2B3] PRIMARY KEY CLUSTERED 
(
	[mssv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiSach]    Script Date: 6/17/2018 9:41:41 PM ******/
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
	[Disable] [bit] NOT NULL,
 CONSTRAINT [PK__LoaiSach__3213E83F7EB61E61] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NganhKhoa]    Script Date: 6/17/2018 9:41:41 PM ******/
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
	[Disable] [bit] NOT NULL,
 CONSTRAINT [PK__NganhKho__3213E83F787481C0] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 6/17/2018 9:41:41 PM ******/
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
	[Disable] [bit] NOT NULL,
 CONSTRAINT [PK__NhanVien__3213E83F405DBA8C] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhaXuatBan]    Script Date: 6/17/2018 9:41:41 PM ******/
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
	[Disable] [bit] NOT NULL,
 CONSTRAINT [PK__NhaXuatB__3213E83F8EECC26E] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhieuMuonSach]    Script Date: 6/17/2018 9:41:41 PM ******/
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
	[Disable] [bit] NOT NULL,
	[TinhTrang] [nvarchar](11) NULL,
 CONSTRAINT [PK__PhieuMuo__3213E83FED7BBBCF] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 6/17/2018 9:41:41 PM ******/
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
	[TacGia] [nvarchar](70) NULL,
	[NamXB] [int] NULL,
	[NhaXB] [int] NULL,
	[MoTa] [nvarchar](100) NULL,
	[DuongDanAnh] [nvarchar](200) NULL,
	[LoaiSach] [int] NULL,
	[NganhKhoa] [int] NULL,
	[SoLuongHienCo] [int] NOT NULL,
	[SoLuongDaMuon] [int] NOT NULL,
	[Disable] [bit] NOT NULL,
 CONSTRAINT [PK__Sach__3213E83F34990CDE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ViPham]    Script Date: 6/17/2018 9:41:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ViPham](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NoiDung] [nvarchar](100) NULL,
	[mssv] [nchar](11) NOT NULL,
	[Disable] [bit] NOT NULL,
 CONSTRAINT [PK__ViPham__3213E83FC4E2C183] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ChiTietPhieuMuon]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietPh__MaPhi__34C8D9D1] FOREIGN KEY([MaPhieuMuon])
REFERENCES [dbo].[PhieuMuonSach] ([id])
GO
ALTER TABLE [dbo].[ChiTietPhieuMuon] CHECK CONSTRAINT [FK__ChiTietPh__MaPhi__34C8D9D1]
GO
ALTER TABLE [dbo].[ChiTietPhieuMuon]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietPh__MaSac__35BCFE0A] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([id])
GO
ALTER TABLE [dbo].[ChiTietPhieuMuon] CHECK CONSTRAINT [FK__ChiTietPh__MaSac__35BCFE0A]
GO
ALTER TABLE [dbo].[PhieuMuonSach]  WITH CHECK ADD  CONSTRAINT [FK__PhieuMuon__Nguoi__30F848ED] FOREIGN KEY([NguoiLapPhieu])
REFERENCES [dbo].[NhanVien] ([id])
GO
ALTER TABLE [dbo].[PhieuMuonSach] CHECK CONSTRAINT [FK__PhieuMuon__Nguoi__30F848ED]
GO
ALTER TABLE [dbo].[PhieuMuonSach]  WITH CHECK ADD  CONSTRAINT [FK__PhieuMuon__Nguoi__31EC6D26] FOREIGN KEY([NguoiMuon])
REFERENCES [dbo].[DocGia] ([mssv])
GO
ALTER TABLE [dbo].[PhieuMuonSach] CHECK CONSTRAINT [FK__PhieuMuon__Nguoi__31EC6D26]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK__Sach__LoaiSach__267ABA7A] FOREIGN KEY([LoaiSach])
REFERENCES [dbo].[LoaiSach] ([id])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK__Sach__LoaiSach__267ABA7A]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK__Sach__NganhKhoa__276EDEB3] FOREIGN KEY([NganhKhoa])
REFERENCES [dbo].[NganhKhoa] ([id])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK__Sach__NganhKhoa__276EDEB3]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK__Sach__NhaXB__25869641] FOREIGN KEY([NhaXB])
REFERENCES [dbo].[NhaXuatBan] ([id])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK__Sach__NhaXB__25869641]
GO
ALTER TABLE [dbo].[ViPham]  WITH CHECK ADD  CONSTRAINT [FK__ViPham__mssv__2C3393D0] FOREIGN KEY([mssv])
REFERENCES [dbo].[DocGia] ([mssv])
GO
ALTER TABLE [dbo].[ViPham] CHECK CONSTRAINT [FK__ViPham__mssv__2C3393D0]
GO
