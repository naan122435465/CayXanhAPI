USE [master]
GO
/****** Object:  Database [CayXanhApi]    Script Date: 9/23/2021 1:41:16 PM ******/
CREATE DATABASE [CayXanhApi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLCX_CatCamTrongHanChe_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QLCX_CatCamTrongHanChe.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLCX_CatCamTrongHanChe_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QLCX_CatCamTrongHanChe.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CayXanhApi] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CayXanhApi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CayXanhApi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CayXanhApi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CayXanhApi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CayXanhApi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CayXanhApi] SET ARITHABORT OFF 
GO
ALTER DATABASE [CayXanhApi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CayXanhApi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CayXanhApi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CayXanhApi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CayXanhApi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CayXanhApi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CayXanhApi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CayXanhApi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CayXanhApi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CayXanhApi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CayXanhApi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CayXanhApi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CayXanhApi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CayXanhApi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CayXanhApi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CayXanhApi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CayXanhApi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CayXanhApi] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CayXanhApi] SET  MULTI_USER 
GO
ALTER DATABASE [CayXanhApi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CayXanhApi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CayXanhApi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CayXanhApi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CayXanhApi] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CayXanhApi] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CayXanhApi] SET QUERY_STORE = OFF
GO
USE [CayXanhApi]
GO
/****** Object:  Table [dbo].[QLCX_CayCamTrongHanChe]    Script Date: 9/23/2021 1:41:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QLCX_CayCamTrongHanChe](
	[ID] [uniqueidentifier] NOT NULL,
	[TenCay] [nvarchar](100) NOT NULL,
	[TenKhoaHoc] [nvarchar](100) NULL,
	[HoThucVat] [nvarchar](100) NULL,
	[MoTa] [nvarchar](100) NULL,
	[CamTrong] [char](1) NULL,
 CONSTRAINT [PK_QLCX_CayCamTrongHanChe] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QLCX_DanhMucDungChung]    Script Date: 9/23/2021 1:41:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QLCX_DanhMucDungChung](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenDanhMuc] [nvarchar](100) NOT NULL,
	[MoTa] [nvarchar](500) NULL,
	[KichHoat] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QLCX_DanhMucDungChungChiTiet]    Script Date: 9/23/2021 1:41:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QLCX_DanhMucDungChungChiTiet](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DanhMucCha] [int] NOT NULL,
	[GiaTri] [int] NOT NULL,
	[HienThi] [nvarchar](100) NOT NULL,
	[KichHoat] [char](1) NULL,
 CONSTRAINT [PK_QLCX_DanhMucDungChungChiTiet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[QLCX_DanhMucDungChungChiTiet]  WITH CHECK ADD  CONSTRAINT [FK_QLCX_DanhMucDungChungChiTiet_QLCX_DanhMucDungChung] FOREIGN KEY([DanhMucCha])
REFERENCES [dbo].[QLCX_DanhMucDungChung] ([ID])
GO
ALTER TABLE [dbo].[QLCX_DanhMucDungChungChiTiet] CHECK CONSTRAINT [FK_QLCX_DanhMucDungChungChiTiet_QLCX_DanhMucDungChung]
GO
/****** Object:  StoredProcedure [dbo].[sp_CayCamTrong_All]    Script Date: 9/23/2021 1:41:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CayCamTrong_All]
	
AS
	BEGIN
		SELECT *
		FROM QLCX_CayCamTrongHanChe
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_CayCamTrong_ChinhSua]    Script Date: 9/23/2021 1:41:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CayCamTrong_ChinhSua]
	@ID uniqueidentifier,
	@TenCay nvarchar(100),
	@TenKhoaHoc nvarchar(100),
	@HoThucVat nvarchar(100),
	@MoTa nvarchar(100),
	@CamTrong char(1)
AS
	BEGIN
		UPDATE QLCX_CayCamTrongHanChe 
		SET  TenCay =@TenCay, TenKhoaHoc= @TenKhoaHoc ,HoThucVat=@HoThucVat, MoTa = @MoTa, CamTrong = @CamTrong 
		output inserted.*
		WHERE ID =@ID 
		
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_CayCamTrong_GetById]    Script Date: 9/23/2021 1:41:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CayCamTrong_GetById]
	@Id uniqueidentifier
AS
	BEGIN
		SELECT *
		FROM QLCX_CayCamTrongHanChe
		WHERE ID = @Id
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_CayCamTrong_ThemMoi]    Script Date: 9/23/2021 1:41:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CayCamTrong_ThemMoi]
	--@ID uniqueidentifier,
	@TenCay nvarchar(100),
	@TenKhoaHoc nvarchar(100),
	@HoThucVat nvarchar(100),
	@MoTa nvarchar(100),
	@CamTrong char(1)

AS
	BEGIN 
		INSERT INTO dbo.QLCX_CayCamTrongHanChe( ID, TenCay, TenKhoaHoc, HoThucVat, MoTa, CamTrong)
		OUTPUT inserted.*
		VALUES(NEWID(), @TenCay, @TenKhoaHoc, @HoThucVat,@MoTa,@CamTrong)
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_CayCamtrong_TimKiem]    Script Date: 9/23/2021 1:41:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CayCamtrong_TimKiem]
	@search nvarchar(100)
AS
		BEGIN
			SELECT 
				*
			FROM 
				QLCX_CayCamTrongHanChe
			WHERE
				(TenCay like '%'+ @search +'%')  or (TenKhoaHoc like '%'+ @search+ '%') or @search IS NULL;
		END
	
	
GO
/****** Object:  StoredProcedure [dbo].[sp_CayCamtrong_Xoa]    Script Date: 9/23/2021 1:41:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CayCamtrong_Xoa]
	@Id uniqueidentifier
AS
	BEGIN
		DELETE 
		FROM QLCX_CayCamTrongHanChe
		WHERE ID = @Id
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_DanhMucDungChung_All]    Script Date: 9/23/2021 1:41:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_DanhMucDungChung_All]
AS
	BEGIN
		SELECT *
		FROM QLCX_DanhMucDungChung
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_DanhMucDungChung_ChinhSua]    Script Date: 9/23/2021 1:41:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_DanhMucDungChung_ChinhSua]
	@ID int,
	@TenDanhMuc nvarchar(100),
	@MoTa nvarchar(500),
	@KichHoat char(1)
AS
	BEGIN
		UPDATE QLCX_DanhMucDungChung 
		SET  TenDanhMuc =@TenDanhMuc, MoTa= @MoTa, KichHoat =@KichHoat
		output inserted.*
		WHERE ID =@ID 
		
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_DanhMucDungChung_GetById]    Script Date: 9/23/2021 1:41:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_DanhMucDungChung_GetById]
@Id int
AS
	BEGIN
		SELECT *
		FROM QLCX_DanhMucDungChung
		WHERE ID = @Id
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_DanhMucDungChung_ThemMoi]    Script Date: 9/23/2021 1:41:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[sp_DanhMucDungChung_ThemMoi]    Script Date: 9/22/2021 9:28:02 AM ******/
CREATE Procedure [dbo].[sp_DanhMucDungChung_ThemMoi]
	@TenDanhMuc nvarchar(100),
	@MoTa nvarchar(500),
	@KichHoat char(1)
AS
	BEGIN 
	INSERT INTO dbo.QLCX_DanhMucDungChung( TenDanhMuc ,MoTa,KichHoat)
		OUTPUT inserted.*
		VALUES(  @TenDanhMuc, @MoTa,@KichHoat)
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_DanhMucDungChung_TimKiem]    Script Date: 9/23/2021 1:41:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_DanhMucDungChung_TimKiem]
@search nvarchar(100)
AS
		BEGIN
			SELECT 
				*
			FROM 
				QLCX_DanhMucDungChung
			WHERE
				(TenDanhMuc like '%'+ @search +'%')  or @search IS NULL;
		END
GO
/****** Object:  StoredProcedure [dbo].[sp_DanhMucDungChung_Xoa]    Script Date: 9/23/2021 1:41:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_DanhMucDungChung_Xoa]
@Id int
AS
	BEGIN
		DELETE 
		FROM QLCX_DanhMucDungChung
		WHERE ID = @Id
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_DanhMucDungChungChiTiet_All]    Script Date: 9/23/2021 1:41:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_DanhMucDungChungChiTiet_All]
as
	
	BEGIN
		select *
		from QLCX_DanhMucDungChungChiTiet
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_DanhMucDungChungChiTiet_ChinhSua]    Script Date: 9/23/2021 1:41:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_DanhMucDungChungChiTiet_ChinhSua]
	@ID int,
	@DanhMucCha int,
	@GiaTri int, 
	@HienThi nvarchar(100),
	@KichHoat char(1)
as
	

	BEGIN
		UPDATE QLCX_DanhMucDungChungChiTiet
		SET  DanhMucCha =@DanhMucCha, GiaTri =@GiaTri, HienThi =@HienThi, KichHoat= @KichHoat
		output inserted.*
		WHERE ID = @ID 
		
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_DanhMucDungChungChiTiet_GetById]    Script Date: 9/23/2021 1:41:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_DanhMucDungChungChiTiet_GetById]
	@Id int
as
	
	BEGIN
		select *
		from QLCX_DanhMucDungChungChiTiet
		where ID = @Id
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_DanhMucDungChungChiTiet_ThemMoi]    Script Date: 9/23/2021 1:41:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_DanhMucDungChungChiTiet_ThemMoi]
	@DanhMucCha int,
	@GiaTri int, 
	@HienThi nvarchar(100),
	@KichHoat char(1)
as
	BEGIN 
	INSERT INTO dbo.QLCX_DanhMucDungChungChiTiet( DanhMucCha,GiaTri,HienThi,KichHoat )
		OUTPUT inserted.*
		VALUES( @DanhMucCha, @GiaTri, @HienThi,@KichHoat )
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_DanhMucDungChungChiTiet_TheoMucCha]    Script Date: 9/23/2021 1:41:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_DanhMucDungChungChiTiet_TheoMucCha]
	@DanhMucCha int
as
	
	BEGIN
		select *
		from QLCX_DanhMucDungChungChiTiet
		where DanhMucCha = @DanhMucCha
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_DanhMucDungChungChiTiet_TimKiem]    Script Date: 9/23/2021 1:41:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_DanhMucDungChungChiTiet_TimKiem]
@search nvarchar(100)
as
	
	BEGIN
		select *
		from QLCX_DanhMucDungChungChiTiet
		WHERE
				(HienThi like '%'+ @search +'%')  or @search IS NULL;
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_DanhMucDungChungChiTiet_Xoa]    Script Date: 9/23/2021 1:41:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_DanhMucDungChungChiTiet_Xoa]
	@Id int
as
	
	BEGIN
		DELETE 
		FROM QLCX_DanhMucDungChungChiTiet
		WHERE ID = @Id
	END
GO
USE [master]
GO
ALTER DATABASE [CayXanhApi] SET  READ_WRITE 
GO
