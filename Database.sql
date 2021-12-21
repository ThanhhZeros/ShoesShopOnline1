USE master
GO

-- Drop the database if it already exists
IF  EXISTS (
	SELECT name 
		FROM sys.databases 
		WHERE name = N'Nhom4'
)
DROP DATABASE Nhom4
GO

CREATE DATABASE Nhom4
GO

USE Nhom4
GO

create table DanhMucSP(
	MaDM		varchar(20) not null primary key,
	TenDanhMuc	nvarchar(50) not null,
)

create table SanPham(
	MaSP	varchar(10) not null primary key,
	TenSP	nvarchar(200) not null,
	MaDM	varchar(20) not null foreign key references DanhMucSP(MaDM) on delete cascade on update cascade,
	MoTa	nvarchar(500),
	GiaBan	money not null,
	NgayTao datetime not null,
	NgaySua	datetime not null
)


create table AnhMoTa(
	MaAnh	int identity primary key,
	HinhAnh nvarchar(300),
	MaSP	varchar(10) foreign key references SanPham(MaSP) on delete cascade on update cascade,
)

--drop table ChiTietAnh
---------------------------------
create table ChiTietSanPham(
	MaAnh	int foreign key(MaAnh) references AnhMoTa(MaAnh) on delete cascade on update cascade,
	KichCo	int,
	primary key(KichCo,MaAnh),
)

--drop table PickSP

create table TaiKhoanNguoiDung(
	MaTK		int identity(1,1) not null primary key,
	TenDangNhap nvarchar(100) not null,
	MatKhau		nvarchar(20) not null,
	HoTen		nvarchar(200) not null,
	SDT			char(20) not null,
	DiaChi		nvarchar(500) not null,
	Email		varchar(50),
	TrangThai	bit not null,
)

 create table TaiKhoanQuanTri(
	MaTK			int identity(1,1) not null primary key,
	TenDangNhap	varchar(50) not null,
	MatKhau		varchar(50) not null,
	HoTenUser		nvarchar(50) not null,
	LoaiTK			nvarchar(50) not null,
	TrangThai		bit not null,
 )

create table HoaDon(
	MaHD			int identity(1,1) not null primary key,
	MaTK			int foreign key references TaiKhoanNguoiDung(MaTK) on delete cascade on update cascade,
	HoTenNguoiNhan	nvarchar(50) not null,
	SDTNguoiNhan	varchar(20) not null,
	DiaChiNhan		nvarchar(100) not null,
	EmailNguoiNhan	varchar(50),
	NgayLap			datetime,
	TrangThai		nvarchar(50),
	GhiChu			nvarchar(50),
)
--drop table HoaDon
create table ChiTietHoaDon(
	MaHD		int foreign key references HoaDon(MaHD) on delete cascade on update cascade,
	MaAnh		int,
	KichCo		int,
	foreign key (KichCo,MaAnh) references ChiTietSanPham(KichCo,MaAnh) on delete cascade on update cascade,
	primary key (MaHD,KichCo,MaAnh),
	SoluongMua	int not null,
)

Create table TinTuc(
	MaTin		int identity(1,1) primary key,
	TenTin		nvarchar(100),
	NgayDang	datetime,
	MaTK		int foreign key references TaiKhoanQuanTri(MaTK) on delete cascade on update cascade,
	NoiDung		nvarchar(4000),
)

------
--drop table ChiTietHoaDon


insert into DanhMucSP(MaDM, TenDanhMuc) values
('DM01', N'Giày Nike'),
('DM02', N'Giày Adias'),
('DM03', N'Giày Vans'),
('DM04', N'Giày Converse'),
('DM05', N'Giày Puma'),
('DM06', N'Giày Balenciaga')


insert into SanPham(MaSP, TenSP, MaDM, MoTa, GiaBan, NgayTao, NgaySua) values
('SP001', N'Giày Thể Thao XSPORT Ni.ke air force 1 Rep 1:1','DM01',N'Giày Thể Thao XSPORT Ni.ke air force 1 Rep 1:1 thiết kế đẹp mắt, kiểu dáng hiện đại. Với đôi giày thời trang này chắc chắn bạn sẽ trở nên nổi bật và cuốn hút hơn.','550000','10-12-2021','10-12-2021'),
('SP002', N'Giày Thể Thao XSPORT Ni.ke Jordan 1 F1','DM01',N'Giày Thể Thao XSPORT Ni.ke Jordan 1 F1 chất liệu cao cấp, bền đẹp theo thời gian. Thiết kế thời trang. Kiểu dáng phong cách.Phối màu tinh tế và đẹp mắt. Độ bền cao. Dễ phối đồ. Với đôi giày thời trang này chắc chắn bạn sẽ trở nên nổi bật và cuốn hút hơn.','350000','10-12-2021','10-12-2021'),
('SP003', N'Giày Thể Thao XSPORT Ni.ke Jordan Low REP','DM01',N'Giày Thể Thao XSPORT Ni.ke Jordan Low REP có thiết kế trẻ trung, năng động đến từ thương hiệu Nike nổi tiếng của Mỹ được làm từ chất liệu cao cấp, bền đẹp trong suốt quá trình sử dụng.','750000','10-12-2021','10-12-2021'),
('SP004', N'Giày Thể Thao Nike Air Max Verona','DM01',N'Giày Thể Thao Nike Air Max Verona Pink/Black Màu Đen Hồng thiết kế đẹp mắt, kiểu dáng hiện đại. Với đôi giày thời trang này chắc chắn bạn sẽ trở nên nổi bật và cuốn hút hơn.','325000','10-12-2021','10-12-2021'),
('SP005', N'Giày Thể Thao Nike Air Force 1 Shadow Crimson Tint','DM01',N'Giày Thể Thao Nike Air Force 1 Shadow Crimson Tint CI0919-107 với thiết kế thời trang từ thương hiệu Nike nổi tiếng của Mỹ. Giày Thể Thao Nike Air Force 1 Shadow Crimson Tint CI0919-107  sở hữu gam màu trẻ trung cùng chất liệu cao cấp sẽ cho bạn trải nghiệm tuyệt vời khi đi lên chân.','330000','10-12-2021','10-12-2021'),
('SP006', N'Giày Nike Jordan 1 Mid University','DM01',N'Giày Thể Thao Nike Air Jordan 1 Mid GS  554725-175 có thiết kế trẻ trung, năng động đến từ thương hiệu Nike nổi tiếng của Mỹ. Giày Nike Air Jordan 1 Mid GS  554725-175 được làm từ chất liệu cao cấp, bền đẹp trong suốt quá trình sử dụng.','550000','10-12-2021','10-12-2021'),
('SP007', N'Giày Thể Thao Nike Air Jordan 1','DM01',N'Giày Thể Thao Nike Air Jordan 1 có thiết kế trẻ trung, năng động đến từ thương hiệu Nike nổi tiếng của Mỹ được làm từ chất liệu cao cấp, bền đẹp trong suốt quá trình sử dụng.','5900000','10-12-2021','10-12-2021'),
('SP008', N'Giày Nike Air Jordan 1 Mid Se Union Black Toe','DM01',N'Giày Nike Air Jordan 1 Mid Se Union Black Toe có thiết kế trẻ trung, năng động đến từ thương hiệu Nike nổi tiếng của Mỹ được làm từ chất liệu cao cấp, bền đẹp trong suốt quá trình sử dụng.','590000','10-12-2021','10-12-2021'),
('SP009', N'Giày Nike Dunk Low SE Multi Camo','DM01',N'Giày Nike Dunk Low SE Multi Camocó thiết kế trẻ trung, năng động đến từ thương hiệu Nike nổi tiếng của Mỹ được làm từ chất liệu cao cấp, bền đẹp trong suốt quá trình sử dụng.','720000','10-12-2021','10-12-2021'),
('SP010', N'Giày Thể Thao Nike Air Max 1 Se Volt Rush','DM01',N'Giày Thể Thao Nike Air Max 1 Se Volt Rush có thiết kế trẻ trung, năng động đến từ thương hiệu Nike nổi tiếng của Mỹ được làm từ chất liệu cao cấp, bền đẹp trong suốt quá trình sử dụng.','320000','10-12-2021','10-12-2021'),
('SP011', N'GiàyThể Thao Nike Air Zoom Structure','DM01',N'GiàyThể Thao Nike Air Zoom Structure có thiết kế trẻ trung, năng động đến từ thương hiệu Nike nổi tiếng của Mỹ được làm từ chất liệu cao cấp, bền đẹp trong suốt quá trình sử dụng.','340000','10-12-2021','10-12-2021'),
('SP012', N'Giày Thể Thao Nike Downshifter 10 Running','DM01',N'Giày Thể Thao Nike Downshifter 10 Running có thiết kế trẻ trung, năng động đến từ thương hiệu Nike nổi tiếng của Mỹ được làm từ chất liệu cao cấp, bền đẹp trong suốt quá trình sử dụng.','170000','10-12-2021','10-12-2021'),
('SP013', N'Giày Thể Thao Nike Epic React Infinity Fk Phối Màu','DM01',N'Giày Thể Thao Nike Epic React Infinity Fk Phối Màu có thiết kế trẻ trung, năng động đến từ thương hiệu Nike nổi tiếng của Mỹ được làm từ chất liệu cao cấp, bền đẹp trong suốt quá trình sử dụng.','350000','10-12-2021','10-12-2021'),

('SP014', N'Giày Thể Thao XSPORT Adi.das Alpha.bounce Instinct M','DM02',N'Giày Thể Thao XSPORT Adi.das Alpha.bounce Instinct M Phối Màu là đôi giày dành cho các chàng trai đam mê thể thao được thiết kế vô cùng hiện đại đến từ thương hiệu Adidas nổi tiếng. Sở hữu gam màu nổi bật cùng chất liệu cao cấp Adidas Harden Vol5 Futurenatural White FZ1071 mang lại cảm giác thoải mái khi vận động, chạy nhảy nhiều.','350000','10-12-2021','10-12-2021'),
('SP015', N'Giày Thể Thao XSPORT Prophere Rep','DM02',N'Giày Thể Thao XSPORT Prophere Replà mẫu giày hoài niệm phong cách hầm hố lấy cảm hứng từ nền văn hóa đại chúng của thập niên 90 của thương hiệu Adidas nổi tiếng.','500000','10-12-2021','10-12-2021'),
('SP016', N'Giày Thể Thao XSPORT Ultra Boost','DM03',N'Giày Thể Thao XSPORT Ultra Boost là đôi giày cao cấp đến từ thương hiệu Adias nổi tiếng của nước Mỹ. Với đôi giày Vans Classic Sk8-Hi Black/White này chắc chắn bạn sẽ trở nên nổi bật và cuốn hút hơn.','1600000','10-12-2021','10-12-2021'),
('SP017', N'Giày Thể Thao Adidas Runfalcon','DM02',N'Giày Thể Thao Adidas Runfalcon Màu Đen Trắng là đôi giày thể thao dành cho nam đến từ thương hiệu Adidas nổi tiếng của Đức. Adidas Runfalcon được thiết kế mang nét thể thao phóng đại, khỏe khoắn mang đầy nét năng động.','1600000','10-12-2021','10-12-2021'),
('SP018', N'Giày Thể Thao Adidas Original Stan Smith','DM02',N'Giày Thể Thao Adidas Original Stan Smith M20324 Màu Trắng đến từ thương hiệu Adidas nổi tiếng của Đức. Adidas Original Stan Smith được thiết kế mang nét thể thao khỏe khoắn, năng động cho bạn trải nghiệm tuyệt vời khi đi lên chân.','1600000','10-12-2021','10-12-2021'),
('SP019', N'Giày Thể Thao Adidas Neo Cloudfoam Lite Racer Olive','DM02',N'Giày Thể Thao Adidas Neo Cloudfoam Lite Racer Olive Màu Xanh Green là một trong những sản phẩm nổi tiếng của Adidas với thiết kế được tính toán tốt nhất dành cho người dùng: mềm mại, thoải mái, kiểu dáng thể thao trẻ trung, chất liệu bền đẹp. Với đôi giày thời trang này chắc chắn bạn sẽ trở nên nổi bật và cuốn hút hơn.','1500000','10-12-2021','10-12-2021'),
('SP020', N'Giày Thể Thao Adidas Ultraboost 20 USA','DM02',N'Giày Thể Thao Adidas Ultraboost 20 USA Màu Trắng đến từ thương hiệu Adidas nổi tiếng của Đức. Adidas Ultraboost 20 USA được thiết kế mang nét thể thao khỏe khoắn, năng động cho bạn trải nghiệm tuyệt vời nhất khi đi lên chân.','2500000','10-12-2021','10-12-2021'),
('SP021', N'Giày Bóng Rổ Adidas Harden Vol5 Futurenatural','DM02',N'Giày Bóng Rổ Adidas Harden Vol5 Futurenatural White FZ1071 Phối Màu là đôi giày dành cho các chàng trai đam mê thể thao được thiết kế vô cùng hiện đại đến từ thương hiệu Adidas nổi tiếng. Sở hữu gam màu nổi bật cùng chất liệu cao cấp Adidas Harden Vol5 Futurenatural White FZ1071 mang lại cảm giác thoải mái khi vận động, chạy nhảy nhiều.','3500000','10-12-2021','10-12-2021'),
('SP022', N'Giày Thể Thao Adidas Falcon','DM02',N'Giày Thể Thao Adidas Falcon Grey Pink D96698 Màu Xám là mẫu giày hoài niệm phong cách hầm hố lấy cảm hứng từ nền văn hóa đại chúng của thập niên 90 của thương hiệu Adidas nổi tiếng.','1650000','10-12-2021','10-12-2021'),
('SP023', N'Giày Thể Thao Adidas D Rose 11','DM02',N'Giày Thể Thao Adidas D Rose 11 FY9988 Màu Xanh được thiết kế hiện đại đến từ thương hiệu Adidas nổi tiếng. Với gam màu thanh lịch Adidas D Rose 11 FY9988 Màu Xanh cho bạn trở nên sành điệu và thật phong cách khi đi lên chân.','2600000','10-12-2021','10-12-2021'),
('SP024', N'Giày Thể Thao Adidas D Rose 12','DM02',N'Giày Thể Thao Adidas D Rose 12 FY9988 Màu Xanh được thiết kế hiện đại đến từ thương hiệu Adidas nổi tiếng. Với gam màu thanh lịch Adidas D Rose 11 FY9988 Màu Xanh cho bạn trở nên sành điệu và thật phong cách khi đi lên chân.','2600000','10-12-2021','10-12-2021'),
('SP025', N'Giày Thể Thao Adidas Pro Bounce 2019','DM02',N'Giày Thể Thao Adidas Pro Bounce 2019 EE3898 Màu Đỏ được thiết kế hiện đại đến từ thương hiệu Adidas nổi tiếng. Với gam màu thanh lịch Adidas Pro Bounce 2019 EE3898 Màu Đỏ cho bạn trở nên sành điệu và thật phong cách khi đi lên chân.','1790000','10-12-2021','10-12-2021'),
('SP026', N'Giày Thể Thao Adidas X9000L3 H.RDY M','DM02',N'Giày Thể Thao Adidas X9000L3 H.RDY M FY0798 Màu Trắng được thiết kế hiện đại đến từ thương hiệu Adidas nổi tiếng. Với gam màu thanh lịch Adidas X9000L3 H.RDY M FY0798 cho bạn trở nên sành điệu và thật phong cách khi đi lên chân.','1680000','10-12-2021','10-12-2021'),

('SP027', N'Giày Vans Mule Checkerboard','DM03',N'Giày Vans Mule Checkerboard Màu Xanh Navy là đôi giày Unisex dành cho cả nam và nữ đến từ thương hiệu Vans nổi tiếng của nước Mỹ. Với đôi giày Vans thời trang này chắc chắn bạn sẽ trở nên nổi bật và cuốn hút hơn.','500000','10-12-2021','10-12-2021'),
('SP028', N'Giày Thể Thao Vans Classic','DM03',N'Giày Thể Thao Vans Classic Sk8-Hi Black/White Màu Đen là đôi giày cao cấp đến từ thương hiệu Vans nổi tiếng của nước Mỹ. Với đôi giày Vans Classic Sk8-Hi Black/White này chắc chắn bạn sẽ trở nên nổi bật và cuốn hút hơn.','1600000','10-12-2021','10-12-2021'),
('SP029', N'Giày Vans Old Skool X J.Crew','DM03',N'Giày Vans Old Skool X J.Crew Reflecting Pond Màu Xanh là đôi giày cao cấp đến từ thương hiệu Vans nổi tiếng của nước Mỹ. Với đôi giày Vans Old Skool X J.Crew Reflecting Pond này chắc chắn bạn sẽ trở nên nổi bật và cuốn hút hơn.','1900000','10-12-2021','10-12-2021'),
('SP030', N'Giày Thể Thao Vans Checkerboard Slip On','DM03',N'Với kiểu dáng Style trẻ trung, đẹp mắt, mang đậm phong cách, cá tính cho người mang. Phần đế giày có độ ma sát cao hạn chế trơn trượt cho người sử dụng.Không chỉ dành cho người yêu sneaker, đôi giày còn phù hợp với những tín đồ đam mê thể thao với phong cách thời trang năng động, đậm nét cá tính.','1300000','10-12-2021','10-12-2021'),
('SP031', N'Giày Vans Asher All White ','DM03',N'Giày Vans Ward Triple White Màu Trắng là đôi giày cao cấp đến từ thương hiệu Vans nổi tiếng của nước Mỹ. Với đôi giày Vans Ward Triple White này chắc chắn bạn sẽ trở nên nổi bật và cuốn hút hơn.','1400000','10-12-2021','10-12-2021'),
('SP032', N'Giày Sneakers Vans Style 36 Marshmallow Blue Màu Trắng','DM03',N'Giày Sneaker Vans Style 36 Marshmallow Blue Màu Trắng Size 41 đến từ thương hiệu Vans nổi tiếng của nước Mỹ. Với đôi giày Sneaker Vans thời trang này chắc chắn bạn sẽ trở nên nổi bật và cuốn hút hơn.','2400000','10-12-2021','10-12-2021'),
('SP033', N'Giày Vans Ward Triple White Màu Trắng','DM03',N'Giày Vans Ward Triple White Màu Trắng là đôi giày cao cấp đến từ thương hiệu Vans nổi tiếng của nước Mỹ. Với đôi giày Vans Ward Triple White này chắc chắn bạn sẽ trở nên nổi bật và cuốn hút hơn.','1500000','10-12-2021','10-12-2021'),
('SP034', N'Giày Vans Vault Old Skool – Marshmallow Multicolor Màu Trắng','DM03',N'Giày Vans Vault Old Skool – Marshmallow Multicolor Màu Trắng đến từ thương hiệu Vans nổi tiếng của nước Mỹ, với thiết kế thời trang đôi giày sẽ cho bạn trải nghiệm tuyệt vời nhất khi đi lên chân.','2600000','10-12-2021','10-12-2021'),

('SP035', N'Giày Thể Thao Converse All-Court - 168785C Màu Đen','DM04',N'Giày Thể Thao Converse All-Court - 168785C Màu Đen sản phẩm đến từ thương hiệu Converse nổi tiếng của Mỹ. Với thiết kế thời trang, đôi giày đang nhận được sự yêu thích của rất nhiều bạn trẻ.','1800000','10-12-2021','10-12-2021'),
('SP036', N'Giày Converse Chuck Taylor All Star Lift Leather Low 561680C','DM04',N'Giày Converse Chuck Taylor All Star Lift Leather Low 561680C Màu Trắng là sản phẩm đến từ thương hiệu Converse nổi tiếng của Mỹ. Với thiết kế thời trang cùng màu sắc thanh lịch đôi giày đang nhận được sự yêu thích của rất nhiều bạn trẻ.','2400000','10-12-2021','10-12-2021'),
('SP037', N'Giày Converse Chuck Taylor All Star 1970s','DM04',N'Giày Converse Chuck Taylor All Star 1970s Colors Vintage Canvas - 168504V Màu Nâu Nhạt với thiết kế Độc - Lạ - Phá cách đến từ thương hiệu Converse nổi tiếng của Mỹ. Với gam màu thanh lịch Converse Chuck Taylor đang là item HOT được nhiều bạn trẻ săn đón.','2500000','10-12-2021','10-12-2021'),
('SP038', N'Giày Converse Chuck Taylor All Star CX 168566C Màu Xanh Navy','DM04',N'Giày Converse Chuck Taylor All Star CX 168566C Màu Xanh Navy sản phẩm đến từ thương hiệu Converse nổi tiếng của Mỹ. Với thiết kế Độc - Lạ - Phá cách, cùng gam màu nổi bật đôi giày đang nhận được sự quan tâm từ rất nhiều các bạn trẻ.','2600000','10-12-2021','10-12-2021'),
('SP039', N'Giày Converse Chuck Taylor All Star 1970s Renew - 168615C Màu Vàng','DM04',N'Giày Converse Chuck Taylor All Star 1970s Renew - 168615C Màu Vàng với thiết kế Độc - Lạ - Phá cách đến từ thương hiệu Converse nổi tiếng của Mỹ. Với gam màu nổi bật Converse Chuck Taylor đang là item HOT được nhiều bạn trẻ săn đón.','2450000','10-12-2021','10-12-2021'),
('SP040', N'Giày Converse Chuck Taylor All Star CX 168568C ','DM04','Giày Converse Chuck Taylor All Star CX 168568C Màu Đen sản phẩm đến từ thương hiệu Converse nổi tiếng của Mỹ. Với thiết kế thời trang, đôi giày đang nhận được sự yêu thích của rất nhiều bạn trẻ.','2450000','10-12-2021','10-12-2021'),
('SP041', N'Giày Converse Chuck Taylor All Star Renew - 168593V Màu Xanh Green','DM04',N'Giày Converse Chuck Taylor All Star Renew - 168593V Màu Xanh Green sản phẩm đến từ thương hiệu Converse nổi tiếng của Mỹ. Với thiết kế Độc - Lạ - Phá cách, cùng gam màu nổi bật đôi giày đang nhận được sự quan tâm từ rất nhiều các bạn trẻ.','1850000','10-12-2021','10-12-2021'),
('SP042', N'Giày Converse CDG Play X Chuck Taylor 1970s Cream White','DM04',N'Giày Converse CDG Play X Chuck Taylor 1970s Cream White 70 Low 150207C Màu Trắng với thiết kế Độc - Lạ - Phá cách đến từ thương hiệu Converse nổi tiếng của Mỹ. Với gam màu thanh lịch Converse CDG Play X Chuck Taylor 1970s Cream White 70 Low 150207C  đang là item HOT được nhiều bạn trẻ săn đón.','3450000','10-12-2021','10-12-2021'),
('SP043', N'Giày Converse Chuck Taylor All Star CX - 168570C Màu Vàng','DM04',N'Giày Converse Chuck Taylor All Star CX - 168570C Màu Vàng sản phẩm đến từ thương hiệu Converse nổi tiếng của Mỹ. Với thiết kế thời trang cùng màu sắc nổi bật đôi giày đang nhận được sự yêu thích của rất nhiều bạn trẻ.','2500000','10-12-2021','10-12-2021'),
('SP044', N'Giày Converse Chuck Taylor All Star CX - 168570C Màu Vàng','DM04',N'Giày Thể Thao Converse 1970s High Black Fire Màu Đen Đỏ sản phẩm đến từ thương hiệu Converse nổi tiếng của Mỹ. Với thiết kế Độc - Lạ - Phá cách,  đôi giày đang nhận được sự quan tâm từ rất nhiều các bạn trẻ.','2700000','10-12-2021','10-12-2021'),

('SP045', N'Giày Thể Thao Puma RS-X X3 Puzzle Multi 371570-04','DM05',N'Giày Thể Thao Puma RS-X X3 Puzzle Multi 371570-04 với thiết kế trẻ trung đến từ thương hiệu Puma nổi tiếng của Đức. Giày Puma RS-X X3 sẽ cho bạn những trải nghiệm tuyệt vời khi đi lên chân.','2000000','10-12-2021','10-12-2021'),
('SP046', N'Giày Thể Thao Puma Muse X2 Metallic 37083802 Màu Trắng','DM05',N'Giày Thể Thao Puma Muse X2 Metallic 37083802 Màu Trắng với thiết kế trẻ trung đến từ thương hiệu Puma nổi tiếng của Đức. Giày Puma Muse X2 Metallic Màu Trắng sẽ cho bạn những trải nghiệm tuyệt vời khi đi lên chân.','1700000','10-12-2021','10-12-2021'),
('SP047', N'Giày Thể Thao Puma Oslo-City Lux Màu Trắng','DM05',N'Giày Thể Thao Puma Oslo-City Lux Màu Trắng với thiết kế trẻ trung đến từ thương hiệu Puma nổi tiếng của Đức. Giày Puma Oslo-City Lux được làm từ chất liệu cao cấp sẽ cho bạn trải nghiệm tuyệt vời khi đi lên chân.','1990000','10-12-2021','10-12-2021'),
('SP048', N'Giày Puma Ralph Sampson Màu Trắng ','DM05',N'Giày Puma Ralph Sampson Màu TrắngSize 41 với thiết kế trẻ trung được nhiều tín đồ thời trang săn đón. Với gam màu sang trọng PPuma Ralph Sampson cho bạn thêm năng động và nổi bật.','1700000','10-12-2021','10-12-2021'),
('SP049', N'Giày Thể Thao Puma Caracal Suede Màu Đen','DM05',N'Giày Thể Thao Puma Caracal Suede Màu Đen','1700000','12-12-2020','12-12-2020'),
('SP050', N'Giày Thể Thao Puma Smash V2 Black Màu Đen Trắng ','DM05',N'Giày Thể Thao Puma Smash V2 Black Màu Đen Trắng là mẫu giày mới nhất được đông đảo tín đồ thời trang yêu thích trong thời gian gần đây. Đôi giày được thiết kế kiểu dáng thời trang và được làm từ chất liệu cao cấp bền đẹp trong suốt quá trình sử dụng.','1900000','10-12-2021','10-12-2021'),
('SP051', N'Giày Thể Thao Puma Roma Scuderia Ferrari','DM05',N'Giày Thể Thao Puma Roma Scuderia Ferrari Size 38.5 (Trắng) là mẫu giày nổi bật của hãng Puma phù hợp với các quý ông năng động, trẻ trung.Giày Puma Roma Scuderia Ferrari được thiết kế với phong cách hoàn toàn mới: thanh thoát và giản dị nhưng có nét độc đáo riêng. Sản phẩm kết hợp giữa Puma và Ferrari, những thương hiệu mà tất cả chúng ta đều biết và yêu thích.','1990000','10-12-2021','10-12-2021'),
('SP052', N'Giày Puma Bari Mule Men','DM05',N'Giày Puma Bari Mule Mens Shoes Màu Đen với thiết kế đẹp - độc đáo đến từ thương hiệu Puma nổi tiếng của Đức. Với những tín đồ mê giày hở gót thì Puma Mule Pink sẽ không còn là cái tên xa lạ nữa.','1340000','10-12-2021','10-12-2021'),
('SP053', N'Giày Thể Thao Puma Scuderia Ferrari Speed HYBRID Running','DM05',N'Giày Thể Thao Puma Scuderia Ferrari Speed HYBRID Running Màu Trắng là đôi giàythời trang dành cho nam đến từ thương hiệu Puma nổi tiếng. Với thiết kế hiện đại đôi giày Puma Scuderia Ferrari Speed HYBRID Running sẽ cho bạn trải nghiệm tuyệt vời nhất khi đi lên chân.','1990000','10-12-2021','10-12-2021'),
('SP054', N'Giày Thể Thao Puma Basket 90680 Lux Màu Trắng ','DM05',N'Giày Thể Thao Puma Basket 90680 Lux Màu Trắng Size 40.5 được thiết kế trẻ trung, khỏe khoắn mang đậm phong cách của thương hiệu Puma. Giày Puma Basket 90680 Lux sẽ cho bạn trải nghiệm tuyệt vời nhất khi đi lên chân.','1970000','12-12-2020','12-12-2020')

insert into AnhMoTa(MaSP,HinhAnh)values
('SP001',N'nikeairforcexanh.PNG'),
('SP001',N'nikeairforcehong.PNG'),
('SP001',N'nikeairforcexam.PNG'),
('SP002',N'jordancam.PNG'),
('SP002',N'jordanden.PNG'),
('SP002',N'jordando.PNG'),
('SP002',N'jordantim.PNG'),
('SP003',N'jordanlowxanhden.PNG'),
('SP003',N'jordanlowxam.PNG'),
('SP003',N'jordanlowtrang.PNG'),
('SP004',N'NIKE1.jpg'),
('SP005',N'NIKE2.jpg'),
('SP006',N'NIKE3.jpg'),
('SP007',N'NIKE4.jpg'),
('SP008',N'NIKE5.jpg'),
('SP009',N'NIKE6.jpg'),
('SP010',N'NIKE7.jpg'),
('SP011',N'NIKE8.jpg'),
('SP012',N'NIKE9.jpg'),
('SP013',N'NIKE10.jpg'),
('SP014',N'adiasalphaden.PNG'),
('SP014',N'adiasalphado.PNG'),
('SP014',N'adiasalphaxam.PNG'),
('SP014',N'adiasalphaxamden.PNG'),
('SP015',N'prophexanhduong.PNG'),
('SP015',N'prophehong.PNG'),
('SP015',N'prophexanhreu.PNG'),
('SP015',N'prophedo.PNG'),
('SP015',N'propheden.PNG'),
('SP015',N'prophekecam.PNG'),

('SP016',N'ultrahong.PNG'),
('SP016',N'ultratrang.PNG'),
('SP016',N'ultraxam.PNG'),
('SP016',N'ultraden.PNG'),
('SP017',N'AD1.jpg'),
('SP018',N'AD2.jpg'),
('SP019',N'AD3.jpg'),
('SP020',N'AD4.jpg'),
('SP021',N'AD5.jpg'),
('SP022',N'AD6.jpg'),
('SP023',N'AD7.jpg'),
('SP024',N'AD8.jpg'),
('SP025',N'AD9.jpg'),
('SP026',N'AD10.jpg'),

('SP027',N'VA1.jpg'),
('SP027',N'VA1.1.jpg'),
('SP028',N'VA2.jpg'),
('SP029',N'VA3.jpg'),
('SP029',N'VA3.1.jpg'),
('SP030',N'VA4.jpg'),
('SP030',N'VA4.1.jpg'),
('SP031',N'VA5.jpg'),
('SP032',N'VA6.jpg'),
('SP032',N'VA6.1.jpg'),
('SP033',N'VA7.jpg'),
('SP034',N'VA8.jpg'),

('SP035',N'CV1.jpg'),
('SP036',N'CV2.jpg'),
('SP037',N'CV3.jpg'),
('SP037',N'CV3.1.jpg'),
('SP037',N'CV3.2.jpg'),
('SP038',N'CV4.jpg'),
('SP039',N'CV5.jpg'),
('SP040',N'CV6.jpg'),
('SP041',N'CV8.jpg'),
('SP042',N'CV9.jpg'),
('SP043',N'CV10.jpg'),
('SP044',N'CV9.jpg'),

('SP045',N'PA1.jpg'),
('SP046',N'PA2.jpg'),
('SP047',N'PA3.jpg'),
('SP048',N'PA4.jpg'),
('SP049',N'PA5.jpg'),
('SP050',N'PA6.jpg'),
('SP051',N'PA7.jpg'),
('SP052',N'PA8.jpg'),
('SP053',N'PA9.jpg'),
('SP054',N'PA10.jpg')

insert into ChiTietSanPham(MaAnh,KichCo) values
(1,35),(1,36),(1,37),(1,38),(1,40),
(2,35),(2,36),(2,37),(2,38),(2,40),
(3,35),(3,36),(3,37),(3,38),(3,40),
(4,36),(4,37),(4,38),(4,39),
(5,36),(5,37),(5,38),(5,39),
(6,36),(6,37),(6,38),(6,39),
(7,36),(7,37),(7,38),(7,39),
(8,36),(8,37),(8,38),(8,39),
(9,36),(9,37),(9,38),(9,39),
(10,36),(10,37),(10,38),(10,39),
(11,37),(11,38),(11,39),(11,40),(11,41),(11,42),(11,43),
(12,37),(12,38),(12,39),(12,40),(12,41),(12,42),(12,43),
(13,37),(13,38),(13,39),(13,40),(13,41),(13,42),(13,43),
(14,37),(14,38),(14,39),(14,40),(14,41),(14,42),(14,43),
(15,37),(15,38),(15,39),(15,40),(15,41),(15,42),(15,43),
(16,36),(16,37),(16,38),(16,39),(16,40),(16,41),
(17,36),(17,37),(17,38),(17,39),(17,40),(17,41),
(18,36),(18,37),(18,38),(18,39),(18,40),(18,41),
(19,36),(19,37),(19,38),(19,39),(19,40),(19,41),
(20,36),(20,37),(20,38),(20,39),(20,40),(20,41),
(21,36),(21,37),(21,38),(21,39),(21,40),(21,41),
(22,36),(22,37),(22,38),(22,39),(22,40),(22,41),
(23,36),(23,37),(23,38),(23,39),(23,40),(23,41),
(24,36),(24,37),(24,38),(24,39),(24,40),(24,41),
(25,36),(25,37),(25,38),(25,39),
(26,36),(26,37),(26,38),(26,39),
(27,36),(27,37),(27,38),(27,39),
(28,36),(28,37),(28,38),(28,39),
(29,36),(29,37),(29,38),(29,39),
(30,36),(30,37),(30,38),(30,39),
(31,35),(31,36),(31,37),(31,38),(31,40),
(32,35),(32,36),(32,37),(32,38),(32,40),
(33,35),(33,36),(33,37),(33,38),(33,40),
(34,35),(34,36),(34,37),(34,38),(34,40),
(35,35),(35,36),(35,37),(35,38),(35,40),
(36,35),(36,36),(36,37),(36,38),(36,40),
(37,35),(37,36),(37,37),(37,38),(37,40),
(38,35),(38,36),(38,37),(38,38),(38,40),
(39,35),(39,36),(39,37),(39,38),(39,40),
(40,36),(40,37),(40,38),(40,39),
(41,36),(41,37),(41,38),(41,39),
(42,36),(42,37),(42,38),(42,39),
(43,36),(43,37),(43,38),(43,39),
(44,36),(44,37),(44,38),(44,39),
(45,36),(45,37),(45,38),(45,39),
(46,36),(46,37),(46,38),(46,39),
(47,36),(47,37),(47,38),(47,39),
(48,36),(48,37),(48,38),(48,39),
(49,36),(49,37),(49,38),(49,39),
(50,37),(50,38),(50,39),(50,40),
(51,37),(51,38),(51,39),(51,40),
(52,37),(52,38),(52,39),(52,40),
(53,37),(53,38),(53,39),(53,40),
(54,37),(54,38),(54,39),(54,40)

insert into TaiKhoanNguoiDung(DiaChi, Email, HoTen, SDT, TenDangNhap,MatKhau, TrangThai) values
('Ha Noi', 'NguyenA@gmail.com', N'Nguyen Van A', '098765543','NguyenA','456', '1'),
('Ha Noi', 'NguyenB@gmail.com', N'Nguyen Van B', '098765543','NguyenB','456', '1')


insert into TaiKhoanQuanTri(HoTenUser,TenDangNhap,MatKhau,LoaiTK,TrangThai) values
(N'Quách Phương Thảo', 'QuachThao','123','QuanLy','1'),
(N'Lê Thị Thanh Mỹ', 'ThanhMy','123','QuanLy','1'),
(N'Phạm Thị Thanh', 'PhamThanh','123','QuanLy','1'),
(N'Vũ Ngọc Tâm', 'NgocTam','123','QuanLy','1')

--insert into LienHe(MaLienHe, )
insert into TinTuc (TenTin,MaTK,NgayDang,NoiDung) values
(N'7 cách bảo quản giày thể thao tốt nhất',1,'2/3/2020','This is a content'),
(N'9 kỹ thuật làm đẹp cho u30',1,'2/3/2020','This is a content')


select * from SanPham

