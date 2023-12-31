CREATE DATABASE [Karaoke_Princesses]
GO
USE [Karaoke_Princesses]
GO
/****** Object:  Table [dbo].[DANHMUC]    Script Date: 11/3/2023 12:16:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DANHMUC](
	[IDDanhMuc] [int] IDENTITY(1,1) NOT NULL,
	[TenDanhMuc] [nvarchar](50) NOT NULL,
	[NgayTao] [datetime] NULL,
	[NgayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDDanhMuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOADONBANHANG]    Script Date: 11/3/2023 12:16:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADONBANHANG](
	[IDHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[IDPhong] [int] NOT NULL,
	[IDMatHang] [int] NOT NULL,
	[ThoiGianBD] [datetime] NULL,
	[ThoiGianKT] [datetime] NULL,
	[Sl] [nvarchar](150) NULL,
	[DonGia] [float] NULL,
	[TenTaiKhoan] [nvarchar](50) NOT NULL,
	[NgayTao] [datetime] NULL,
	[ThanhTien] [decimal](18, 0) NULL,
	[TongHoaDon] [float] NULL,
 CONSTRAINT [PK_HOADONBANHANG] PRIMARY KEY CLUSTERED 
(
	[IDHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 11/3/2023 12:16:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[SDT] [nvarchar](50) NOT NULL,
	[HoTenKH] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[DiaChiKH] [nvarchar](50) NULL,
	[TichLuy] [int] NULL,
	[HangThanhVien] [nvarchar](50) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_KHACHHANG] PRIMARY KEY CLUSTERED 
(
	[SDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAIPHONG]    Script Date: 11/3/2023 12:16:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAIPHONG](
	[IDLoaiPhong] [int] IDENTITY(1,1) NOT NULL,
	[NameLP] [nvarchar](100) NOT NULL,
	[DonGia] [decimal] (18, 0) NULL,
	[NgayCapNhat] [datetime] NULL,
 CONSTRAINT [PK_LOAIPHONG_1] PRIMARY KEY CLUSTERED 
(
	[IDLoaiPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MATHANG]    Script Date: 11/3/2023 12:16:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MATHANG](
	[IDMatHang] [int] IDENTITY(1,1) NOT NULL,
	[TenMatHang] [nvarchar](100) NOT NULL,
	[DonGiaBan] [float] NOT NULL,
	[NgayTao] [datetime] NULL,
	[NgayCapNhat] [datetime] NULL,
	[IDDanhMuc] [int] NULL,
 CONSTRAINT [PK_MATHANG] PRIMARY KEY CLUSTERED 
(
	[IDMatHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 11/3/2023 12:16:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[TenTaiKhoan] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NOT NULL,
	[HoVaTen] [nvarchar](100) NULL,
	[SDT] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[LoaiTaiKhoan] [nvarchar](50) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[TenTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHONG]    Script Date: 11/3/2023 12:16:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHONG](
	[IDPhong] [int] IDENTITY(1,1) NOT NULL,
	[TenPhong] [nvarchar](50) NOT NULL,
	[TrangThai] [nvarchar](100) NOT NULL,
	[IDLoaiPhong] [int] NOT NULL,
	[NgayTao] [datetime] NULL,
	[NgayCapNhat] [datetime] NULL,
 CONSTRAINT [PK_PHONG] PRIMARY KEY CLUSTERED 
(
	[IDPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DANHMUC] ON 

INSERT [dbo].[DANHMUC] ([IDDanhMuc], [TenDanhMuc], [NgayTao], [NgayCapNhat]) VALUES (1, N'Đồ nướng', CAST(N'2023-01-11T00:00:00.000' AS DateTime), CAST(N'2023-01-11T00:00:00.000' AS DateTime))
INSERT [dbo].[DANHMUC] ([IDDanhMuc], [TenDanhMuc], [NgayTao], [NgayCapNhat]) VALUES (2, N'Hải sản', CAST(N'2023-01-11T00:00:00.000' AS DateTime), CAST(N'2023-01-11T00:00:00.000' AS DateTime))
INSERT [dbo].[DANHMUC] ([IDDanhMuc], [TenDanhMuc], [NgayTao], [NgayCapNhat]) VALUES (3, N'Ăn vặt', CAST(N'2023-01-11T00:00:00.000' AS DateTime), CAST(N'2023-01-11T00:00:00.000' AS DateTime))
INSERT [dbo].[DANHMUC] ([IDDanhMuc], [TenDanhMuc], [NgayTao], [NgayCapNhat]) VALUES (4, N'Nước uống', CAST(N'2023-01-11T00:00:00.000' AS DateTime), CAST(N'2023-01-11T00:00:00.000' AS DateTime))
INSERT [dbo].[DANHMUC] ([IDDanhMuc], [TenDanhMuc], [NgayTao], [NgayCapNhat]) VALUES (5, N'Tráng miệng', CAST(N'2023-01-11T00:00:00.000' AS DateTime), CAST(N'2023-01-11T00:00:00.000' AS DateTime))
INSERT [dbo].[DANHMUC] ([IDDanhMuc], [TenDanhMuc], [NgayTao], [NgayCapNhat]) VALUES (6, N'Dịch vụ thêm', CAST(N'2023-01-11T00:00:00.000' AS DateTime), CAST(N'2023-01-11T00:00:00.000' AS DateTime))
INSERT [dbo].[DANHMUC] ([IDDanhMuc], [TenDanhMuc], [NgayTao], [NgayCapNhat]) VALUES (8, N'Jack', CAST(N'2023-11-01T11:00:22.767' AS DateTime), CAST(N'2023-11-01T11:00:49.743' AS DateTime))
SET IDENTITY_INSERT [dbo].[DANHMUC] OFF
GO
SET IDENTITY_INSERT [dbo].[HOADONBANHANG] ON 

INSERT [dbo].[HOADONBANHANG] ([IDHoaDon], [IDPhong], [IDMatHang], [ThoiGianBD], [ThoiGianKT], [Sl], [DonGia], [TenTaiKhoan], [NgayTao], [ThanhTien], [TongHoaDon]) VALUES (9, 12, 1, CAST(N'2023-11-02T05:35:30.960' AS DateTime), NULL, NULL, NULL, N'admin', NULL, NULL, NULL)
INSERT [dbo].[HOADONBANHANG] ([IDHoaDon], [IDPhong], [IDMatHang], [ThoiGianBD], [ThoiGianKT], [Sl], [DonGia], [TenTaiKhoan], [NgayTao], [ThanhTien], [TongHoaDon]) VALUES (23, 4, 1, CAST(N'2023-11-02T21:59:06.950' AS DateTime), NULL, NULL, NULL, N'admin', NULL, NULL, NULL)
INSERT [dbo].[HOADONBANHANG] ([IDHoaDon], [IDPhong], [IDMatHang], [ThoiGianBD], [ThoiGianKT], [Sl], [DonGia], [TenTaiKhoan], [NgayTao], [ThanhTien], [TongHoaDon]) VALUES (24, 7, 1, CAST(N'2023-11-02T21:59:06.950' AS DateTime), NULL, NULL, NULL, N'admin', NULL, NULL, NULL)
INSERT [dbo].[HOADONBANHANG] ([IDHoaDon], [IDPhong], [IDMatHang], [ThoiGianBD], [ThoiGianKT], [Sl], [DonGia], [TenTaiKhoan], [NgayTao], [ThanhTien], [TongHoaDon]) VALUES (25, 8, 1, CAST(N'2023-11-02T21:59:06.950' AS DateTime), NULL, NULL, NULL, N'admin', NULL, NULL, NULL)
INSERT [dbo].[HOADONBANHANG] ([IDHoaDon], [IDPhong], [IDMatHang], [ThoiGianBD], [ThoiGianKT], [Sl], [DonGia], [TenTaiKhoan], [NgayTao], [ThanhTien], [TongHoaDon]) VALUES (26, 9, 1, CAST(N'2023-11-02T21:59:06.950' AS DateTime), NULL, NULL, NULL, N'admin', NULL, NULL, NULL)
INSERT [dbo].[HOADONBANHANG] ([IDHoaDon], [IDPhong], [IDMatHang], [ThoiGianBD], [ThoiGianKT], [Sl], [DonGia], [TenTaiKhoan], [NgayTao], [ThanhTien], [TongHoaDon]) VALUES (28, 8, 8, NULL, NULL, N'1 thùng 19 lon', NULL, N'admin', CAST(N'2023-11-02T21:59:24.903' AS DateTime), CAST(7200000 AS Decimal(18, 0)), NULL)
INSERT [dbo].[HOADONBANHANG] ([IDHoaDon], [IDPhong], [IDMatHang], [ThoiGianBD], [ThoiGianKT], [Sl], [DonGia], [TenTaiKhoan], [NgayTao], [ThanhTien], [TongHoaDon]) VALUES (29, 8, 8, NULL, NULL, N'1 thùng 19 lon', NULL, N'admin', CAST(N'2023-11-02T21:59:31.167' AS DateTime), CAST(7200000 AS Decimal(18, 0)), NULL)
INSERT [dbo].[HOADONBANHANG] ([IDHoaDon], [IDPhong], [IDMatHang], [ThoiGianBD], [ThoiGianKT], [Sl], [DonGia], [TenTaiKhoan], [NgayTao], [ThanhTien], [TongHoaDon]) VALUES (30, 8, 4, NULL, NULL, N'2', NULL, N'admin', CAST(N'2023-11-02T21:59:39.867' AS DateTime), CAST(4608000000 AS Decimal(18, 0)), NULL)
INSERT [dbo].[HOADONBANHANG] ([IDHoaDon], [IDPhong], [IDMatHang], [ThoiGianBD], [ThoiGianKT], [Sl], [DonGia], [TenTaiKhoan], [NgayTao], [ThanhTien], [TongHoaDon]) VALUES (31, 7, 5, NULL, NULL, N'3', NULL, N'admin', CAST(N'2023-11-02T22:06:17.710' AS DateTime), CAST(5292000000 AS Decimal(18, 0)), NULL)
INSERT [dbo].[HOADONBANHANG] ([IDHoaDon], [IDPhong], [IDMatHang], [ThoiGianBD], [ThoiGianKT], [Sl], [DonGia], [TenTaiKhoan], [NgayTao], [ThanhTien], [TongHoaDon]) VALUES (32, 5, 8, NULL, NULL, N'13 thùng 9 lon', NULL, N'admin', CAST(N'2023-11-02T22:41:11.733' AS DateTime), CAST(7920000 AS Decimal(18, 0)), NULL)
SET IDENTITY_INSERT [dbo].[HOADONBANHANG] OFF
GO
SET IDENTITY_INSERT [dbo].[LOAIPHONG] ON 

INSERT [dbo].[LOAIPHONG] ([IDLoaiPhong], [NameLP], [DonGia], [NgayCapNhat]) VALUES (1, N'Thường', CAST(655074 AS Decimal(18, 0)), CAST(N'2023-11-02T05:37:35.083' AS DateTime))
INSERT [dbo].[LOAIPHONG] ([IDLoaiPhong], [NameLP], [DonGia], [NgayCapNhat]) VALUES (2, N'Vip', CAST(130000 AS Decimal(18, 0)), CAST(N'2023-10-31T23:47:28.157' AS DateTime))
SET IDENTITY_INSERT [dbo].[LOAIPHONG] OFF
GO
SET IDENTITY_INSERT [dbo].[MATHANG] ON 

INSERT [dbo].[MATHANG] ([IDMatHang], [TenMatHang], [DonGiaBan], [NgayTao], [NgayCapNhat], [IDDanhMuc]) VALUES (1, N'Mực nướng', 45000, CAST(N'2023-11-01T10:18:58.370' AS DateTime), CAST(N'2023-11-01T10:18:58.370' AS DateTime), 1)
INSERT [dbo].[MATHANG] ([IDMatHang], [TenMatHang], [DonGiaBan], [NgayTao], [NgayCapNhat], [IDDanhMuc]) VALUES (2, N'Gà nướng muối ớt', 150000, CAST(N'2023-11-01T10:19:25.633' AS DateTime), CAST(N'2023-11-01T10:19:25.633' AS DateTime), 1)
INSERT [dbo].[MATHANG] ([IDMatHang], [TenMatHang], [DonGiaBan], [NgayTao], [NgayCapNhat], [IDDanhMuc]) VALUES (3, N'Càng ghẹ rang muối', 55000, CAST(N'2023-11-01T10:19:56.907' AS DateTime), CAST(N'2023-11-01T10:19:56.907' AS DateTime), 2)
INSERT [dbo].[MATHANG] ([IDMatHang], [TenMatHang], [DonGiaBan], [NgayTao], [NgayCapNhat], [IDDanhMuc]) VALUES (4, N'Tôm hấp bia', 48000, CAST(N'2023-11-01T10:21:43.480' AS DateTime), CAST(N'2023-11-01T10:21:43.480' AS DateTime), 2)
INSERT [dbo].[MATHANG] ([IDMatHang], [TenMatHang], [DonGiaBan], [NgayTao], [NgayCapNhat], [IDDanhMuc]) VALUES (5, N'Mì cay hải sản thanh cua', 42000, CAST(N'2023-11-01T10:22:01.270' AS DateTime), CAST(N'2023-11-01T10:22:01.270' AS DateTime), 3)
INSERT [dbo].[MATHANG] ([IDMatHang], [TenMatHang], [DonGiaBan], [NgayTao], [NgayCapNhat], [IDDanhMuc]) VALUES (6, N'Cá viên chiên', 25000, CAST(N'2023-11-01T10:23:25.320' AS DateTime), CAST(N'2023-11-01T10:23:25.320' AS DateTime), 3)
INSERT [dbo].[MATHANG] ([IDMatHang], [TenMatHang], [DonGiaBan], [NgayTao], [NgayCapNhat], [IDDanhMuc]) VALUES (7, N'Bia 333', 15000, CAST(N'2023-11-01T10:38:03.993' AS DateTime), CAST(N'2023-11-01T10:42:02.757' AS DateTime), 4)
INSERT [dbo].[MATHANG] ([IDMatHang], [TenMatHang], [DonGiaBan], [NgayTao], [NgayCapNhat], [IDDanhMuc]) VALUES (8, N'Bia Tiger', 15000, CAST(N'2023-11-01T10:53:35.273' AS DateTime), CAST(N'2023-11-01T10:53:35.273' AS DateTime), 4)
SET IDENTITY_INSERT [dbo].[MATHANG] OFF
GO
INSERT [dbo].[NHANVIEN] ([TenTaiKhoan], [MatKhau], [HoVaTen], [SDT], [DiaChi], [LoaiTaiKhoan], [Status]) VALUES (N'admin', N'admin', N'Lê Quốc Thịnh', N'0123456789', N'Quận Bình Thạnh', N'QTV', 1)
INSERT [dbo].[NHANVIEN] ([TenTaiKhoan], [MatKhau], [HoVaTen], [SDT], [DiaChi], [LoaiTaiKhoan], [Status]) VALUES (N'lee5k', N'12345', N'Lê Trọng Khanh', N'0912345678', N'Hóc Môn', N'NV', 1)
GO
SET IDENTITY_INSERT [dbo].[PHONG] ON 

INSERT [dbo].[PHONG] ([IDPhong], [TenPhong], [TrangThai], [IDLoaiPhong], [NgayTao], [NgayCapNhat]) VALUES (2, N'Phòng 1', N'Phòng trống', 1, CAST(N'2023-10-31T23:58:15.463' AS DateTime), CAST(N'2023-11-02T02:19:19.040' AS DateTime))
INSERT [dbo].[PHONG] ([IDPhong], [TenPhong], [TrangThai], [IDLoaiPhong], [NgayTao], [NgayCapNhat]) VALUES (4, N'Phòng 2', N'Đang thuê', 1, CAST(N'2023-11-01T00:14:57.970' AS DateTime), CAST(N'2023-11-02T21:58:27.673' AS DateTime))
INSERT [dbo].[PHONG] ([IDPhong], [TenPhong], [TrangThai], [IDLoaiPhong], [NgayTao], [NgayCapNhat]) VALUES (5, N'Phòng 3', N'Đang thuê', 1, CAST(N'2023-11-01T00:15:23.763' AS DateTime), CAST(N'2023-11-02T21:58:31.883' AS DateTime))
INSERT [dbo].[PHONG] ([IDPhong], [TenPhong], [TrangThai], [IDLoaiPhong], [NgayTao], [NgayCapNhat]) VALUES (6, N'Phòng 4', N'Phòng trống', 1, CAST(N'2023-11-01T00:00:00.000' AS DateTime), CAST(N'2023-11-02T22:15:04.690' AS DateTime))
INSERT [dbo].[PHONG] ([IDPhong], [TenPhong], [TrangThai], [IDLoaiPhong], [NgayTao], [NgayCapNhat]) VALUES (7, N'Phòng 5', N'Đang thuê', 1, CAST(N'2023-11-01T00:00:00.000' AS DateTime), CAST(N'2023-11-02T21:58:39.520' AS DateTime))
INSERT [dbo].[PHONG] ([IDPhong], [TenPhong], [TrangThai], [IDLoaiPhong], [NgayTao], [NgayCapNhat]) VALUES (8, N'Phòng 6', N'Đang thuê', 1, CAST(N'2023-11-01T00:00:00.000' AS DateTime), CAST(N'2023-11-02T21:58:43.793' AS DateTime))
INSERT [dbo].[PHONG] ([IDPhong], [TenPhong], [TrangThai], [IDLoaiPhong], [NgayTao], [NgayCapNhat]) VALUES (9, N'Phòng 7', N'Đang thuê', 1, CAST(N'2023-11-01T00:00:00.000' AS DateTime), CAST(N'2023-11-02T21:58:47.497' AS DateTime))
INSERT [dbo].[PHONG] ([IDPhong], [TenPhong], [TrangThai], [IDLoaiPhong], [NgayTao], [NgayCapNhat]) VALUES (10, N'Phòng 8', N'Phòng trống', 2, CAST(N'2023-11-01T00:00:00.000' AS DateTime), CAST(N'2023-11-02T21:58:53.333' AS DateTime))
INSERT [dbo].[PHONG] ([IDPhong], [TenPhong], [TrangThai], [IDLoaiPhong], [NgayTao], [NgayCapNhat]) VALUES (11, N'Phòng 9', N'Đang thuê', 2, CAST(N'2023-11-01T00:00:00.000' AS DateTime), CAST(N'2023-11-02T21:58:23.883' AS DateTime))
INSERT [dbo].[PHONG] ([IDPhong], [TenPhong], [TrangThai], [IDLoaiPhong], [NgayTao], [NgayCapNhat]) VALUES (12, N'Phòng 10', N'Đang thuê', 2, CAST(N'2023-11-01T00:00:00.000' AS DateTime), CAST(N'2023-11-02T05:35:16.770' AS DateTime))
INSERT [dbo].[PHONG] ([IDPhong], [TenPhong], [TrangThai], [IDLoaiPhong], [NgayTao], [NgayCapNhat]) VALUES (13, N'Phòng 11', N'Phòng trống', 2, CAST(N'2023-11-01T00:00:00.000' AS DateTime), CAST(N'2023-11-02T05:35:29.187' AS DateTime))
SET IDENTITY_INSERT [dbo].[PHONG] OFF
GO
ALTER TABLE [dbo].[DANHMUC] ADD  CONSTRAINT [DF_DANHMUC_NgayTao]  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[DANHMUC] ADD  CONSTRAINT [DF_DANHMUC_NgayCapNhat]  DEFAULT (getdate()) FOR [NgayCapNhat]
GO
ALTER TABLE [dbo].[LOAIPHONG] ADD  CONSTRAINT [DF_LOAIPHONG_NgayCapNhat]  DEFAULT (getdate()) FOR [NgayCapNhat]
GO
ALTER TABLE [dbo].[MATHANG] ADD  CONSTRAINT [DF_MATHANG_NgayTao]  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[MATHANG] ADD  CONSTRAINT [DF_MATHANG_NgayCapNhat]  DEFAULT (getdate()) FOR [NgayCapNhat]
GO
ALTER TABLE [dbo].[PHONG] ADD  CONSTRAINT [DF_PHONG_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[PHONG] ADD  CONSTRAINT [DF_PHONG_NgayTao]  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[PHONG] ADD  CONSTRAINT [DF_PHONG_NgayCapNhat]  DEFAULT (getdate()) FOR [NgayCapNhat]
GO
ALTER TABLE [dbo].[HOADONBANHANG]  WITH CHECK ADD  CONSTRAINT [FK_HOADONBANHANG_MATHANG] FOREIGN KEY([IDMatHang])
REFERENCES [dbo].[MATHANG] ([IDMatHang])
GO
ALTER TABLE [dbo].[HOADONBANHANG] CHECK CONSTRAINT [FK_HOADONBANHANG_MATHANG]
GO
ALTER TABLE [dbo].[HOADONBANHANG]  WITH CHECK ADD  CONSTRAINT [FK_HOADONBANHANG_NHANVIEN1] FOREIGN KEY([TenTaiKhoan])
REFERENCES [dbo].[NHANVIEN] ([TenTaiKhoan])
GO
ALTER TABLE [dbo].[HOADONBANHANG] CHECK CONSTRAINT [FK_HOADONBANHANG_NHANVIEN1]
GO
ALTER TABLE [dbo].[HOADONBANHANG]  WITH CHECK ADD  CONSTRAINT [FK_HOADONBANHANG_PHONG] FOREIGN KEY([IDPhong])
REFERENCES [dbo].[PHONG] ([IDPhong])
GO
ALTER TABLE [dbo].[HOADONBANHANG] CHECK CONSTRAINT [FK_HOADONBANHANG_PHONG]
GO
ALTER TABLE [dbo].[MATHANG]  WITH CHECK ADD  CONSTRAINT [FK_MATHANG_DANHMUC1] FOREIGN KEY([IDDanhMuc])
REFERENCES [dbo].[DANHMUC] ([IDDanhMuc])
GO
ALTER TABLE [dbo].[MATHANG] CHECK CONSTRAINT [FK_MATHANG_DANHMUC1]
GO
ALTER TABLE [dbo].[PHONG]  WITH CHECK ADD  CONSTRAINT [FK_PHONG_LOAIPHONG1] FOREIGN KEY([IDLoaiPhong])
REFERENCES [dbo].[LOAIPHONG] ([IDLoaiPhong])
GO
ALTER TABLE [dbo].[PHONG] CHECK CONSTRAINT [FK_PHONG_LOAIPHONG1]
GO
SELECT HD.IDHoaDon, HD.IDPhong, HD.ThoiGianBD, HD.ThoiGianKT,P.TenPhong FROM HOADONBANHANG HD JOIN Phong P ON HD.IDPhong = P.IDPhong WHERE HD.ThanhTien IS NULL