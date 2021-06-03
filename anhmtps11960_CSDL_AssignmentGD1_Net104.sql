CREATE DATABASE QuanLyBH
go
USE QuanLyBH
go

CREATE TABLE DanhMuc(
MaDM VARCHAR(20) not null primary key,
LoaiDM NVARCHAR(50) not null
);
go

CREATE TABLE KhachHang(
MaKH VARCHAR(20) NOT NULL PRIMARY KEY,
TenKhach NVARCHAR(50) NOT NULL,
SoDT VARCHAR(15) NOT NULL,
Email VARCHAR(50) NOT NULL,
DiaChi NVARCHAR(100) NOT NULL
);
go

CREATE TABLE SanPham(
MaSP int IDENTITY(1,1) not null,
TenSP NVARCHAR(50) not null,
GiaSP VARCHAR(50) not null,
ThongtinSP NVARCHAR (255),
Hinhanh Nvarchar (100),
LoaiSP VARCHAR (20) not null,
MaDM VARCHAR(20) not null,
constraint FK_SP_DM foreign key (MaDM) references DanhMuc(MaDM),
CONSTRAINT [PK_SP] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
go
CREATE TABLE [dbo].[Account](
	[AccountId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([AccountId], [Name], [Password]) VALUES (1, 'test','123')
INSERT [dbo].[Account] ([AccountId], [Name], [Password]) VALUES (2, 'admin','123')
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT SanPham ON 
insert into DanhMuc values
('001','Laptop'),
('002','Dien Thoai'),
('003','Dong Ho');
insert into KhachHang values
('001','Mai The Anh','0971404710','anhmtps11960@fpt.edu.vn','Quan 11, TP HCM'),
('002','Vu Ngoc Thien','0987654321','thienvnps11111@fpt.edu.vn','Quan 12, TP HCM'),
('003','Dang Thanh Hoang','0977654321','hoangdtps22222@fpt.edu.vn','Quan Go Vap, TP HCM');

insert SanPham (MaSP, TenSP, GiaSP, ThongtinSP, Hinhanh, LoaiSP, MaDM) values 
(1,'IPhone 12 ProMax 256gb','36990000',N'CPU: A14 Bionic / Screen: 6.7" / Ram: 6GB / Pin: 3687 mAh','/images/sp01.jpg','IPHONE','002')
insert SanPham (MaSP, TenSP, GiaSP, ThongtinSP, Hinhanh, LoaiSP, MaDM) values 
(2,'IPhone 12 ProMax 128gb','32990000',N'CPU: A14 Bionic / Screen: 6.7" / Ram: 6GB / Pin: 3687 mAh','/images/sp01.jpg','IPHONE','002')
insert SanPham (MaSP, TenSP, GiaSP, ThongtinSP, Hinhanh, LoaiSP, MaDM) values 
(3,'IPhone 12 ProMax 512gb','41990000',N'CPU: A14 Bionic / Screen: 6.7" / Ram: 6GB / Pin: 3687 mAh','/images/sp01.jpg','IPHONE','002')
insert SanPham (MaSP, TenSP, GiaSP, ThongtinSP, Hinhanh, LoaiSP, MaDM) values 
(4,'IPhone 12 Pro 256gb','33990000',N'CPU: A14 Bionic / Screen: 6.1" / Ram: 6GB / Pin: 2815 mAh','/images/sp02.jpg','IPHONE','002')
insert SanPham (MaSP, TenSP, GiaSP, ThongtinSP, Hinhanh, LoaiSP, MaDM) values 
(5,'IPhone 12 Pro 128gb','29990000',N'CPU: A14 Bionic / Screen: 6.1" / Ram: 6GB / Pin: 2815 mAh','/images/sp02.jpg','IPHONE','002')
insert SanPham (MaSP, TenSP, GiaSP, ThongtinSP, Hinhanh, LoaiSP, MaDM) values 
(6,'IPhone 12 Pro 512gb','38990000',N'CPU: A14 Bionic / Screen: 6.1" / Ram: 6GB / Pin: 2815 mAh','/images/sp02.jpg','IPHONE','002')
insert SanPham (MaSP, TenSP, GiaSP, ThongtinSP, Hinhanh, LoaiSP, MaDM) values 
(7,'IPhone 12 256gb','25990000',N'CPU: A14 Bionic / Screen: 6.1" / Ram: 4GB / Pin: 2815 mAh','/images/sp03.jpg','IPHONE','002')
insert SanPham (MaSP, TenSP, GiaSP, ThongtinSP, Hinhanh, LoaiSP, MaDM) values 
(8,'IPhone 12 64gb','23990000',N'CPU: A14 Bionic / Screen: 6.1" / Ram: 4GB / Pin: 2815 mAh','/images/sp03.jpg','IPHONE','002')
insert SanPham (MaSP, TenSP, GiaSP, ThongtinSP, Hinhanh, LoaiSP, MaDM) values 
(9,'IPhone 12 128gb','25690000',N'CPU: A14 Bionic / Screen: 6.1" / Ram: 4GB / Pin: 2815 mAh','/images/sp03.jpg','IPHONE','002')
insert SanPham (MaSP, TenSP, GiaSP, ThongtinSP, Hinhanh, LoaiSP, MaDM) values 
(10,'IPhone 12 Mini 64gb','18990000',N'CPU: A14 Bionic / Screen: 5.4" / Ram: 4GB / Pin: 2227 mAh','/images/sp04.jpg','IPHONE','002')
insert SanPham (MaSP, TenSP, GiaSP, ThongtinSP, Hinhanh, LoaiSP, MaDM) values 
(11,'IPhone 12 Mini 128gb','20390000',N'CPU: A14 Bionic / Screen: 5.4" / Ram: 4GB / Pin: 2227 mAh','/images/sp04.jpg','IPHONE','002')
insert SanPham (MaSP, TenSP, GiaSP, ThongtinSP, Hinhanh, LoaiSP, MaDM) values 
(12,'IPhone 12 Mini 256gb','23490000',N'CPU: A14 Bionic / Screen: 5.4" / Ram: 4GB / Pin: 2227 mAh','/images/sp04.jpg','IPHONE','002')
insert SanPham (MaSP, TenSP, GiaSP, ThongtinSP, Hinhanh, LoaiSP, MaDM) values 
(13,'Asus TUF FX506LI HN096T Win10 64bit','26990000',N'CPU: i7 10870H / Screen: 15.6" FullHD 144Hz / Ram: DDR4 8GB 3200MHz / Card: GTX 1650Ti 4GB / Pin: 4 Cells, 66WHrs','/images/sp05.jpg','ASUS','001')
insert SanPham (MaSP, TenSP, GiaSP, ThongtinSP, Hinhanh, LoaiSP, MaDM) values 
(14,'MSI Gaming Bravo15 A4DCR-270VN Win10 64bit','19490000',N'CPU: Ryzen5 4600H / Screen: 15.6" FullHD 144Hz / Ram: DDR4 8GB 3200MHz / Card: Radeon RX5300M 3GB / Pin: 3 Cell','/images/sp06.jpg','MSI','001')
insert SanPham (MaSP, TenSP, GiaSP, ThongtinSP, Hinhanh, LoaiSP, MaDM) values 
(15,'Đồng hồ Candino C4488/4','3031000','QUARTZ (PIN) – KÍNH SAPPHIRE – DÂY DA - Chống nước: 5 ATM','/images/sp07.jpg','CANDINO','003')
SET IDENTITY_INSERT SanPham OFF
USE [master]
GO
ALTER DATABASE [QuanLyBH] SET  READ_WRITE 
GO