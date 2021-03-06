USE [master]
GO
/****** Object:  Database [QLNhaHang]    Script Date: 3/14/2019 17:27:16 ******/
CREATE DATABASE [QLNhaHang]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLNhaHang', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QLNhaHang.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLNhaHang_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QLNhaHang_log.ldf' , SIZE = 1856KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLNhaHang] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLNhaHang].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLNhaHang] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLNhaHang] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLNhaHang] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLNhaHang] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLNhaHang] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLNhaHang] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLNhaHang] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLNhaHang] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLNhaHang] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLNhaHang] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLNhaHang] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLNhaHang] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLNhaHang] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLNhaHang] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLNhaHang] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLNhaHang] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLNhaHang] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLNhaHang] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLNhaHang] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLNhaHang] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLNhaHang] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLNhaHang] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLNhaHang] SET RECOVERY FULL 
GO
ALTER DATABASE [QLNhaHang] SET  MULTI_USER 
GO
ALTER DATABASE [QLNhaHang] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLNhaHang] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLNhaHang] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLNhaHang] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLNhaHang] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLNhaHang', N'ON'
GO
USE [QLNhaHang]
GO
/****** Object:  UserDefinedFunction [dbo].[fnHourAddToHour]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create FUNCTION [dbo].[fnHourAddToHour](@HOUR1 INT, @HOUR2 INT)
RETURNS FLOAT
WITH EXECUTE AS CALLER
AS
BEGIN
	DECLARE @h int, @m int
	
	SET @h = @HOUR1/100 + @HOUR2/100
	SET @m = @HOUR1%100 + @HOUR2%100
	
	SET @h = @h + @m/60
	SET @m = @m%60

	RETURN @h * 100 + @m
END
GO
/****** Object:  UserDefinedFunction [dbo].[fnHourToFloat]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create FUNCTION [dbo].[fnHourToFloat](@HOUR INT)
RETURNS FLOAT
WITH EXECUTE AS CALLER
AS
BEGIN
	RETURN (@HOUR/100+@HOUR%100/60.0)
END
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BANAN]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BANAN](
	[MaBan] [int] IDENTITY(1,1) NOT NULL,
	[TenBan] [nvarchar](50) NULL,
	[MaDMBanAn] [int] NULL,
	[Anh] [varchar](150) NULL,
	[DaXoa] [bit] NULL,
	[ConBan] [bit] NULL,
 CONSTRAINT [PK_BANAn] PRIMARY KEY CLUSTERED 
(
	[MaBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BINHLUAN]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BINHLUAN](
	[MaBinhLuan] [int] IDENTITY(1,1) NOT NULL,
	[NoiDung] [nvarchar](400) NULL,
	[DanhGia] [int] NULL,
	[NguoiBinhLuan] [nvarchar](50) NULL,
	[ThoiGian] [datetime] NULL,
	[DaXoa] [bit] NULL,
	[MaMonAn] [int] NULL,
 CONSTRAINT [PK_BINHLUAN] PRIMARY KEY CLUSTERED 
(
	[MaBinhLuan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CHITIETPHIEU]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETPHIEU](
	[MaChiTietPhieu] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieu] [int] NULL,
	[MaMonAn] [int] NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_CHITIETPHIEU] PRIMARY KEY CLUSTERED 
(
	[MaChiTietPhieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DANHMUCBANAN]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DANHMUCBANAN](
	[MaDMBanAn] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NULL,
	[Anh] [varchar](150) NULL,
	[DaXoa] [bit] NULL,
	[MoTa] [nvarchar](400) NULL,
 CONSTRAINT [PK_DANHMUCBANAN] PRIMARY KEY CLUSTERED 
(
	[MaDMBanAn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DANHMUCMONAN]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DANHMUCMONAN](
	[MaDMMonAn] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NULL,
	[Anh] [varchar](150) NULL,
	[DaXoa] [bit] NULL,
 CONSTRAINT [PK_DANHMUCMONAN] PRIMARY KEY CLUSTERED 
(
	[MaDMMonAn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOAINGUOIDUNG]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAINGUOIDUNG](
	[MaLoaiNguoiDung] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiNguoiDung] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LOAINGUOIDUNG] PRIMARY KEY CLUSTERED 
(
	[MaLoaiNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MONAN]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MONAN](
	[MaMonAn] [int] IDENTITY(1,1) NOT NULL,
	[TenMonAn] [nvarchar](150) NULL,
	[MoTa] [nvarchar](400) NULL,
	[Gia] [float] NULL,
	[MaDMMonAn] [int] NULL,
	[Anh] [varchar](150) NULL,
	[DanhGia] [int] NULL,
	[DaXoa] [bit] NULL,
	[ConMon] [bit] NULL,
 CONSTRAINT [PK_MONAN] PRIMARY KEY CLUSTERED 
(
	[MaMonAn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NGUOIDUNG]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NGUOIDUNG](
	[TenDangNhap] [varchar](50) NOT NULL,
	[MatKhau] [varchar](50) NOT NULL,
	[Email] [varchar](50) NULL,
	[DienThoai] [varchar](50) NULL,
	[Anh] [varchar](150) NULL,
	[DaXoa] [bit] NULL,
	[MaLoaiNguoiDung] [int] NULL,
 CONSTRAINT [PK_NGUOIDUNG] PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Allowable] [bit] NOT NULL,
	[RoleId] [nvarchar](450) NULL,
	[WebActionId] [int] NOT NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHIEUDATCHO]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PHIEUDATCHO](
	[MaPhieu] [int] IDENTITY(1,1) NOT NULL,
	[MaBanAn] [int] NULL,
	[TenDangNhap] [varchar](50) NULL,
	[NgayTaoPhieu] [datetime] NULL,
	[NgayDatBan] [datetime] NULL,
	[MaTinhTrangPhieu] [int] NULL,
	[TongTien] [float] NULL,
 CONSTRAINT [PK_PHIEUDATCHO] PRIMARY KEY CLUSTERED 
(
	[MaPhieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBLATTSYSSETTING]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLATTSYSSETTING](
	[SEQ_NO] [int] NOT NULL,
	[ONN_MN] [int] NULL,
	[ONN_BT] [bit] NULL,
	[OFF_MN] [int] NULL,
	[OFF_BT] [bit] NULL,
	[ASB_MN] [int] NULL,
	[CRD_MN] [int] NULL,
	[MEA_QT] [int] NULL,
	[SLI_OT] [bit] NULL,
	[MAX_WK] [int] NULL,
	[MAX_YR] [int] NULL,
	[SEQ_HR] [int] NULL,
	[ROU_MN] [int] NULL,
	[ROU_NO] [bit] NULL,
 CONSTRAINT [PK_GP_SYS_SETTING] PRIMARY KEY CLUSTERED 
(
	[SEQ_NO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBLCARDDATA]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLCARDDATA](
	[DAT_TM] [float] NULL,
	[EMP_ID] [nvarchar](20) NULL,
	[SWI_DT] [datetime] NULL,
	[USR_NM] [nvarchar](50) NULL,
	[CRD_DT] [datetime] NOT NULL,
	[CRD_TM] [float] NOT NULL,
	[CRD_NO] [nvarchar](20) NOT NULL,
	[REA_NO] [nvarchar](10) NULL,
	[STA_DR] [nvarchar](10) NULL,
	[FIL_NM] [nvarchar](100) NULL,
	[YSD_BT] [bit] NULL,
 CONSTRAINT [PK_FILC01A] PRIMARY KEY CLUSTERED 
(
	[CRD_DT] ASC,
	[CRD_TM] ASC,
	[CRD_NO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBLDEPARMENT]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLDEPARMENT](
	[DEP_ID] [nvarchar](10) NOT NULL,
	[DEP_NM] [nvarchar](100) NULL,
	[DEP_N1] [nvarchar](100) NULL,
	[DEP_HG] [nvarchar](200) NULL,
	[COL_NO] [nvarchar](20) NULL,
	[PEO_TT] [int] NULL,
	[SEG_HR] [int] NULL,
	[ROU_MN] [int] NULL,
	[REM_DR] [nvarchar](50) NULL,
	[SEQ_NO] [int] NULL,
	[DIR_DP] [bit] NULL,
 CONSTRAINT [PK_FILA02A] PRIMARY KEY CLUSTERED 
(
	[DEP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBLDETAILSATTENDANCE]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLDETAILSATTENDANCE](
	[EMP_ID] [nvarchar](20) NOT NULL,
	[ATT_DT] [datetime] NOT NULL,
	[DEP_ID] [nvarchar](10) NULL,
	[EMP_I1] [nvarchar](20) NULL,
	[SHI_ID] [nvarchar](20) NULL,
	[NOT_OR] [nvarchar](500) NULL,
	[NOT_DR] [nvarchar](500) NULL,
	[NOT_D1] [nvarchar](500) NULL,
	[NIG_TM] [int] NULL DEFAULT ((0)),
	[ONN_01] [int] NULL,
	[OFF_01] [int] NULL,
	[ONN_02] [int] NULL,
	[OFF_02] [int] NULL,
	[ONN_03] [int] NULL,
	[OFF_03] [int] NULL,
	[ONN_04] [int] NULL,
	[OFF_04] [int] NULL,
	[ONN_05] [int] NULL,
	[OFF_05] [int] NULL,
	[ATT_HR] [float] NULL DEFAULT ((0)),
	[OTT_HR] [float] NULL DEFAULT ((0)),
	[LAT_MN] [float] NULL DEFAULT ((0)),
	[LAT_TM] [int] NULL DEFAULT ((0)),
	[EAR_MN] [float] NULL DEFAULT ((0)),
	[EAR_TM] [int] NULL DEFAULT ((0)),
	[ABS_MN] [float] NULL DEFAULT ((0)),
	[ABS_TM] [int] NULL DEFAULT ((0)),
	[ATT_DY] [float] NULL DEFAULT ((0)),
	[NIG_DY] [float] NULL DEFAULT ((0)),
	[LOC_BT] [bit] NULL,
	[LOC_B1] [bit] NULL,
	[USR_CK] [nvarchar](50) NULL,
	[NIG_HR] [float] NULL DEFAULT ((0)),
	[DOF_HR] [float] NULL DEFAULT ((0)),
	[DOF_NS] [float] NULL DEFAULT ((0)),
	[HOL_HR] [float] NULL DEFAULT ((0)),
	[HOL_NS] [float] NULL DEFAULT ((0)),
	[NIG_OT] [float] NULL DEFAULT ((0)),
	[LEA_I1] [nvarchar](10) NULL,
	[LEA_H1] [float] NULL DEFAULT ((0)),
	[LEA_I2] [nvarchar](10) NULL,
	[LEA_H2] [float] NULL DEFAULT ((0)),
	[LEA_I3] [nvarchar](10) NULL,
	[LEA_H3] [float] NULL DEFAULT ((0)),
	[OTR_HR] [float] NULL,
	[DOF_OV] [float] NULL,
	[HienDien] [bit] NULL,
 CONSTRAINT [PK_FILC06A] PRIMARY KEY CLUSTERED 
(
	[EMP_ID] ASC,
	[ATT_DT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBLDETAILSROSTER]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLDETAILSROSTER](
	[SHI_ID] [nvarchar](20) NOT NULL,
	[SEQ_N1] [int] NOT NULL,
	[SEQ_NO] [nvarchar](2) NULL,
	[ONN_TM] [float] NULL,
	[ONN_RD] [nvarchar](5) NULL,
	[ONN_BT] [bit] NULL,
	[OFF_TM] [float] NULL,
	[OFF_RD] [nvarchar](5) NULL,
	[OFF_BT] [bit] NULL,
	[TYP_ID] [nvarchar](10) NULL,
	[MIN_ST] [float] NULL,
	[WRK_HR] [float] NULL,
	[LAT_BT] [bit] NULL,
	[BLT_NM] [nvarchar](50) NULL,
	[BLT_DT] [datetime] NULL,
	[LST_NM] [nvarchar](50) NULL,
	[LST_DT] [datetime] NULL,
	[MAN_IN] [float] NULL,
	[MAN_OU] [float] NULL,
 CONSTRAINT [PK_FILC02B] PRIMARY KEY CLUSTERED 
(
	[SHI_ID] ASC,
	[SEQ_N1] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBLEMPLOYEE]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLEMPLOYEE](
	[EMP_ID] [nvarchar](20) NOT NULL,
	[EMP_I1] [nvarchar](20) NULL,
	[EMP_NM] [nvarchar](50) NULL,
	[EMP_N1] [nvarchar](50) NULL,
	[MST_DR] [nvarchar](20) NULL,
	[BIR_DT] [datetime] NULL,
	[SEX_BT] [bit] NULL,
	[MAR_BT] [bit] NULL,
	[DEP_ID] [nvarchar](10) NULL,
	[COU_ID] [nvarchar](10) NULL,
	[CRD_NO] [nvarchar](20) NULL,
	[POS_ID] [nvarchar](10) NULL,
	[ADD_DR] [nvarchar](255) NULL,
	[ADD_D1] [nvarchar](255) NULL,
	[INH_DT] [datetime] NULL,
	[CRD_ID] [nvarchar](50) NULL,
	[CRD_DT] [datetime] NULL,
	[CRD_LC] [nvarchar](255) NULL,
	[CIT_ID] [nvarchar](10) NULL,
	[RAC_NM] [nvarchar](50) NULL,
	[NAT_CO] [nvarchar](50) NULL,
	[EDU_ID] [nvarchar](10) NULL,
	[PRO_ID] [nvarchar](10) NULL,
	[GRA_ID] [nvarchar](10) NULL,
	[TEL_NO] [nvarchar](50) NULL,
	[TYP_ID] [nvarchar](10) NULL,
	[ACC_NO] [nvarchar](20) NULL,
	[ACC_NM] [nvarchar](50) NULL,
	[BNK_NM] [nvarchar](100) NULL,
	[REL_DR] [nvarchar](50) NULL,
	[NEW_BT] [bit] NULL CONSTRAINT [DF__FILB01A__NEW_BT__2E1BDC42]  DEFAULT ((0)),
	[MEA_BT] [bit] NULL,
	[REM_DR] [nvarchar](255) NULL,
	[ATT_BT] [bit] NULL CONSTRAINT [DF__FILB01A__ATT_BT__2F10007B]  DEFAULT ((0)),
	[SAL_BT] [bit] NULL CONSTRAINT [DF__FILB01A__SAL_BT__300424B4]  DEFAULT ((0)),
	[VAC_BT] [bit] NULL CONSTRAINT [DF__FILB01A__VAC_BT__30F848ED]  DEFAULT ((0)),
	[DEL_BT] [bit] NULL CONSTRAINT [DF__FILB01A__DEL_BT__31EC6D26]  DEFAULT ((0)),
	[GRT_ID] [nvarchar](10) NULL,
	[GRP_ID] [nvarchar](10) NULL,
	[LEV_ID] [nvarchar](10) NULL,
	[LCK_BT] [bit] NULL CONSTRAINT [DF__FILB01A__LCK_BT__32E0915F]  DEFAULT ((0)),
	[BHX_BT] [bit] NULL,
	[DIR_BT] [bit] NULL,
	[BLT_NM] [nvarchar](50) NULL,
	[BLT_DT] [datetime] NULL,
	[LST_NM] [nvarchar](50) NULL,
	[LST_DT] [datetime] NULL,
	[SEN_DT] [datetime] NULL,
	[REM_D2] [nvarchar](255) NULL,
	[FIR_DT] [datetime] NULL,
 CONSTRAINT [PK_FILB01A] PRIMARY KEY CLUSTERED 
(
	[EMP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBLEXCOLATTENDANCE]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLEXCOLATTENDANCE](
	[COL_NM] [nvarchar](10) NOT NULL,
	[COL_MM] [nvarchar](50) NULL,
	[COL_EN] [nvarchar](50) NULL,
	[COL_VN] [nvarchar](50) NULL,
	[COL_CH] [nvarchar](50) NULL,
	[COL_TT] [nvarchar](50) NULL,
	[MON_BT] [bit] NULL,
	[FOR_DR] [nvarchar](50) NULL,
	[GIO_BT] [bit] NULL,
	[HID_BT] [bit] NULL,
 CONSTRAINT [PK_FILC07A] PRIMARY KEY CLUSTERED 
(
	[COL_NM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBLHOLIDAY]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLHOLIDAY](
	[YYY_YY] [nvarchar](4) NOT NULL,
	[MMM_MM] [int] NOT NULL,
	[h1] [bit] NULL,
	[h2] [bit] NULL,
	[h3] [bit] NULL,
	[h4] [bit] NULL,
	[h5] [bit] NULL,
	[h6] [bit] NULL,
	[h7] [bit] NULL,
	[h8] [bit] NULL,
	[h9] [bit] NULL,
	[h10] [bit] NULL,
	[h11] [bit] NULL,
	[h12] [bit] NULL,
	[h13] [bit] NULL,
	[h14] [bit] NULL,
	[h15] [bit] NULL,
	[h16] [bit] NULL,
	[h17] [bit] NULL,
	[h18] [bit] NULL,
	[h19] [bit] NULL,
	[h20] [bit] NULL,
	[h21] [bit] NULL,
	[h22] [bit] NULL,
	[h23] [bit] NULL,
	[h24] [bit] NULL,
	[h25] [bit] NULL,
	[h26] [bit] NULL,
	[h27] [bit] NULL,
	[h28] [bit] NULL,
	[h29] [bit] NULL,
	[h30] [bit] NULL,
	[h31] [bit] NULL,
 CONSTRAINT [PK_FILA16A] PRIMARY KEY CLUSTERED 
(
	[YYY_YY] ASC,
	[MMM_MM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBLLEAVE]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLLEAVE](
	[SEQ_NO] [int] NOT NULL,
	[EMP_ID] [nvarchar](20) NULL,
	[STR_DT] [datetime] NULL,
	[END_DT] [datetime] NULL,
	[HOU_DY] [float] NULL,
	[STR_TM] [int] NULL,
	[END_TM] [int] NULL,
	[HOU_TT] [float] NULL,
	[LEA_ID] [nvarchar](3) NULL,
	[DAY_TT] [float] NULL,
	[DAY_BT] [bit] NULL,
	[NOT_DR] [nvarchar](100) NULL,
	[BLT_NM] [nvarchar](50) NULL,
	[BLT_DT] [datetime] NULL,
	[LST_NM] [nvarchar](50) NULL,
	[LST_DT] [datetime] NULL,
 CONSTRAINT [PK_FILC04A] PRIMARY KEY CLUSTERED 
(
	[SEQ_NO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBLMONTHATTENDANCE]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLMONTHATTENDANCE](
	[EMP_ID] [nvarchar](20) NOT NULL,
	[YYY_MM] [nvarchar](6) NOT NULL,
	[SEQ_NO] [int] NOT NULL,
	[DEP_I1] [nvarchar](50) NULL,
	[EMP_DW] [nvarchar](20) NULL,
	[NOT_DR] [nvarchar](50) NULL,
	[BLT_NM] [nvarchar](50) NULL,
	[BLT_DT] [datetime] NULL,
	[LST_NM] [nvarchar](50) NULL,
	[LST_DT] [datetime] NULL,
	[LOC_B1] [bit] NULL,
	[HOL_TT] [float] NULL CONSTRAINT [DF__FILC06AA__HOL_TT__114A936A]  DEFAULT ((0)),
	[ATT_HR] [float] NULL CONSTRAINT [DF__FILC06AA__ATT_HR__123EB7A3]  DEFAULT ((0)),
	[OTT_HR] [float] NULL CONSTRAINT [DF__FILC06AA__OTT_HR__1332DBDC]  DEFAULT ((0)),
	[OVO_HR] [float] NULL CONSTRAINT [DF__FILC06AA__OVO_HR__14270015]  DEFAULT ((0)),
	[LAT_MN] [float] NULL CONSTRAINT [DF__FILC06AA__LAT_MN__151B244E]  DEFAULT ((0)),
	[LAT_TM] [int] NULL CONSTRAINT [DF__FILC06AA__LAT_TM__160F4887]  DEFAULT ((0)),
	[EAR_MN] [float] NULL CONSTRAINT [DF__FILC06AA__EAR_MN__17036CC0]  DEFAULT ((0)),
	[EAR_TM] [int] NULL CONSTRAINT [DF__FILC06AA__EAR_TM__17F790F9]  DEFAULT ((0)),
	[ABS_MN] [float] NULL CONSTRAINT [DF__FILC06AA__ABS_MN__18EBB532]  DEFAULT ((0)),
	[ABS_TM] [int] NULL CONSTRAINT [DF__FILC06AA__ABS_TM__19DFD96B]  DEFAULT ((0)),
	[LEA_QT] [float] NULL CONSTRAINT [DF__FILC06AA__LEA_QT__1AD3FDA4]  DEFAULT ((0)),
	[ATT_DY] [float] NULL CONSTRAINT [DF__FILC06AA__ATT_DY__1BC821DD]  DEFAULT ((0)),
	[NIG_DY] [float] NULL CONSTRAINT [DF__FILC06AA__NIG_DY__1CBC4616]  DEFAULT ((0)),
	[NIG_HR] [float] NULL CONSTRAINT [DF__FILC06AA__NIG_HR__1DB06A4F]  DEFAULT ((0)),
	[DOF_HR] [float] NULL CONSTRAINT [DF__FILC06AA__DOF_HR__1EA48E88]  DEFAULT ((0)),
	[DOF_NS] [float] NULL CONSTRAINT [DF__FILC06AA__DOF_OV__208CD6FA]  DEFAULT ((0)),
	[HOL_HR] [float] NULL CONSTRAINT [DF__FILC06AA__HOL_HR__2180FB33]  DEFAULT ((0)),
	[HOL_NS] [float] NULL CONSTRAINT [DF__FILC06AA__HOL_OT__22751F6C]  DEFAULT ((0)),
	[NIG_OT] [float] NULL CONSTRAINT [DF__FILC06AA__NIG_OT__245D67DE]  DEFAULT ((0)),
	[OTR_HR] [float] NULL CONSTRAINT [DF__FILC06AA__OTR_HR__282DF8C2]  DEFAULT ((0)),
	[LEA_001] [float] NULL CONSTRAINT [DF__FILC06AA__LEA_00__29221CFB]  DEFAULT ((0)),
	[LEA_002] [float] NULL CONSTRAINT [DF__FILC06AA__LEA_00__2A164134]  DEFAULT ((0)),
	[LEA_003] [float] NULL CONSTRAINT [DF__FILC06AA__LEA_00__2B0A656D]  DEFAULT ((0)),
	[LEA_004] [float] NULL CONSTRAINT [DF__FILC06AA__LEA_00__2BFE89A6]  DEFAULT ((0)),
	[LEA_005] [float] NULL CONSTRAINT [DF__FILC06AA__LEA_00__2CF2ADDF]  DEFAULT ((0)),
	[LEA_006] [float] NULL CONSTRAINT [DF__FILC06AA__LEA_00__2DE6D218]  DEFAULT ((0)),
	[LEA_007] [float] NULL CONSTRAINT [DF__FILC06AA__LEA_00__2EDAF651]  DEFAULT ((0)),
	[LEA_008] [float] NULL CONSTRAINT [DF__FILC06AA__LEA_00__2FCF1A8A]  DEFAULT ((0)),
	[LEA_009] [float] NULL CONSTRAINT [DF__FILC06AA__LEA_00__30C33EC3]  DEFAULT ((0)),
	[LEA_010] [float] NULL CONSTRAINT [DF__FILC06AA__LEA_01__31B762FC]  DEFAULT ((0)),
	[LEA_011] [float] NULL CONSTRAINT [DF__FILC06AA__LEA_01__32AB8735]  DEFAULT ((0)),
	[LEA_012] [float] NULL CONSTRAINT [DF__FILC06AA__LEA_01__339FAB6E]  DEFAULT ((0)),
	[LEA_013] [float] NULL CONSTRAINT [DF__FILC06AA__LEA_01__3493CFA7]  DEFAULT ((0)),
	[LEA_014] [float] NULL CONSTRAINT [DF__FILC06AA__LEA_01__3587F3E0]  DEFAULT ((0)),
	[LEA_015] [float] NULL CONSTRAINT [DF__FILC06AA__LEA_01__367C1819]  DEFAULT ((0)),
	[LEA_016] [float] NULL CONSTRAINT [DF__FILC06AA__LEA_01__37703C52]  DEFAULT ((0)),
	[LEA_017] [float] NULL CONSTRAINT [DF__FILC06AA__LEA_01__3864608B]  DEFAULT ((0)),
	[LEA_018] [float] NULL CONSTRAINT [DF__FILC06AA__LEA_01__395884C4]  DEFAULT ((0)),
	[LEA_019] [float] NULL CONSTRAINT [DF__FILC06AA__LEA_01__3A4CA8FD]  DEFAULT ((0)),
	[LEA_020] [float] NULL CONSTRAINT [DF__FILC06AA__LEA_02__3B40CD36]  DEFAULT ((0)),
	[BOS_AM] [float] NULL CONSTRAINT [DF__FILC06AA__BOS_AM__3C34F16F]  DEFAULT ((0)),
	[FIN_AM] [float] NULL CONSTRAINT [DF__FILC06AA__FIN_AM__3D2915A8]  DEFAULT ((0)),
	[DOF_OV] [float] NULL,
	[HienDien] [int] NULL,
 CONSTRAINT [PK_FILC06AA] PRIMARY KEY CLUSTERED 
(
	[EMP_ID] ASC,
	[YYY_MM] ASC,
	[SEQ_NO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBLMONTHSHIFT]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLMONTHSHIFT](
	[EMP_ID] [nvarchar](20) NOT NULL,
	[YYY_MM] [nvarchar](6) NOT NULL,
	[DAY_01] [nvarchar](20) NULL,
	[DAY_02] [nvarchar](20) NULL,
	[DAY_03] [nvarchar](20) NULL,
	[DAY_04] [nvarchar](20) NULL,
	[DAY_05] [nvarchar](20) NULL,
	[DAY_06] [nvarchar](20) NULL,
	[DAY_07] [nvarchar](20) NULL,
	[DAY_08] [nvarchar](20) NULL,
	[DAY_09] [nvarchar](20) NULL,
	[DAY_10] [nvarchar](20) NULL,
	[DAY_11] [nvarchar](20) NULL,
	[DAY_12] [nvarchar](20) NULL,
	[DAY_13] [nvarchar](20) NULL,
	[DAY_14] [nvarchar](20) NULL,
	[DAY_15] [nvarchar](20) NULL,
	[DAY_16] [nvarchar](20) NULL,
	[DAY_17] [nvarchar](20) NULL,
	[DAY_18] [nvarchar](20) NULL,
	[DAY_19] [nvarchar](20) NULL,
	[DAY_20] [nvarchar](20) NULL,
	[DAY_21] [nvarchar](20) NULL,
	[DAY_22] [nvarchar](20) NULL,
	[DAY_23] [nvarchar](20) NULL,
	[DAY_24] [nvarchar](20) NULL,
	[DAY_25] [nvarchar](20) NULL,
	[DAY_26] [nvarchar](20) NULL,
	[DAY_27] [nvarchar](20) NULL,
	[DAY_28] [nvarchar](20) NULL,
	[DAY_29] [nvarchar](20) NULL,
	[DAY_30] [nvarchar](20) NULL,
	[DAY_31] [nvarchar](20) NULL,
	[BLT_NM] [nvarchar](50) NULL,
	[BLT_DT] [datetime] NULL,
	[LST_NM] [nvarchar](50) NULL,
	[LST_DT] [datetime] NULL,
 CONSTRAINT [PK_FILC03A] PRIMARY KEY CLUSTERED 
(
	[EMP_ID] ASC,
	[YYY_MM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBLPAYROLL]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLPAYROLL](
	[EMP_ID] [nvarchar](20) NOT NULL,
	[YYY_MM] [nvarchar](6) NOT NULL,
	[SEQ_NO] [int] NOT NULL,
	[DEP_ID] [nvarchar](10) NULL,
	[EMP_DW] [nvarchar](20) NULL,
	[LCK_BT] [bit] NULL,
	[BLT_NM] [nvarchar](20) NULL,
	[BLT_DT] [datetime] NULL,
	[LST_NM] [nvarchar](20) NULL,
	[LST_DT] [datetime] NULL,
	[LCB] [float] NULL,
	[TongLuongHD] [float] NULL,
	[NgayCong] [float] NULL,
	[TienNgayCong] [float] NULL,
	[NgayLe] [float] NULL,
	[TienNgayLe] [float] NULL,
	[NgayNgungViec] [float] NULL,
	[TienNgungViec] [float] NULL,
	[TC] [float] NULL,
	[TCCN] [float] NULL,
	[TCDem] [float] NULL,
	[TCCNDem] [float] NULL,
	[TCLe] [float] NULL,
	[TCLeDem] [float] NULL,
	[CongKhac] [float] NULL,
	[TruKhac] [float] NULL,
	[ChuyenCan] [float] NULL,
	[TongLuong] [float] NULL,
	[BHXH] [float] NULL,
	[BHYT] [float] NULL,
	[BHTN] [float] NULL,
	[TongBH] [float] NULL,
	[DoanPhi] [float] NULL,
	[BanThan] [float] NULL,
	[SoNguoiPhuThuoc] [float] NULL,
	[TienPhuThuoc] [float] NULL,
	[TienTCHeSo1] [float] NULL,
	[TNTinhThue] [float] NULL,
	[ThueThuNhap] [float] NULL,
	[ThucLanh] [float] NULL,
	[TienTC] [float] NULL,
	[TienTCDem] [float] NULL,
	[TienTCCN] [float] NULL,
	[TienTCCNDem] [float] NULL,
	[TienTCLe] [float] NULL,
	[TienTCLeDem] [float] NULL,
	[NCChuan] [float] NULL,
	[PhepCoLuong] [float] NULL,
	[TienPhepCoLuong] [float] NULL,
	[PhepVR] [float] NULL,
	[PhepThaiSan] [float] NULL,
	[PhepDuongSuc] [float] NULL,
	[PhepOm] [float] NULL,
	[KhongPhep] [float] NULL,
	[TienPhepKoLuong] [float] NULL,
	[TongTienTC] [float] NULL,
	[TongGioTC] [float] NULL,
	[ThuongNangSuat] [float] NULL,
	[ThuongCuoiNam] [float] NULL,
	[PhepNamConLai] [float] NULL,
	[TienPhepNamConLai] [float] NULL,
	[BHXH_CT] [float] NULL,
	[BHYT_CT] [float] NULL,
	[BHTN_CT] [float] NULL,
	[BHTNNN_CT] [float] NULL,
	[DoanPhi_CT] [float] NULL,
	[TongBH_CT] [float] NULL,
	[Temp] [float] NULL,
	[LuongBH] [float] NULL,
	[ATVSV] [float] NULL,
	[PCConNho6T] [float] NULL,
	[MLAnToanVeSinh] [float] NULL,
	[ThuongGTNhanLuc] [float] NULL,
	[PhepCuoi] [float] NULL,
	[PhepTang] [float] NULL,
	[PhepKhamThai] [float] NULL,
	[PhepKHHGD] [float] NULL,
	[PhepSayThai] [float] NULL,
	[ThuongCBDatSL] [float] NULL,
	[ThuongSL] [float] NULL,
	[ThuongCGBC] [float] NULL,
	[SoGioTK] [float] NULL,
	[ThuongTKGioCong] [float] NULL,
	[ThuongSXuat] [float] NULL,
	[TNChiuThue] [float] NULL,
	[TienPhepCuoi] [float] NULL,
	[TienPhepTang] [float] NULL,
 CONSTRAINT [PK_FILD02A] PRIMARY KEY CLUSTERED 
(
	[EMP_ID] ASC,
	[YYY_MM] ASC,
	[SEQ_NO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBLROSTER]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLROSTER](
	[SHI_ID] [nvarchar](20) NOT NULL,
	[SHI_NM] [nvarchar](50) NULL,
	[MAX_HR] [float] NULL,
	[MIN_HR] [float] NULL,
	[CON_H1] [float] NULL,
	[ADD_H1] [float] NULL,
	[CON_H2] [float] NULL,
	[ADD_H2] [float] NULL,
	[BLT_NM] [nvarchar](50) NULL,
	[BLT_DT] [datetime] NULL,
	[LST_NM] [nvarchar](50) NULL,
	[LST_DT] [datetime] NULL,
	[TIM_02] [bit] NULL,
	[ONN_TM] [float] NULL,
	[OFF_TM] [float] NULL,
	[NIG_SH] [bit] NULL,
	[ONN_OT] [float] NULL,
 CONSTRAINT [PK_FILC02A] PRIMARY KEY CLUSTERED 
(
	[SHI_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBLSALARY]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLSALARY](
	[EMP_ID] [nvarchar](20) NOT NULL,
	[SEQ_NO] [int] NOT NULL,
	[CHA_DT] [datetime] NULL,
	[NOT_DR] [nvarchar](50) NULL,
	[BLT_NM] [nvarchar](50) NULL,
	[BLT_DT] [datetime] NULL,
	[LST_NM] [nvarchar](50) NULL,
	[LST_DT] [datetime] NULL,
	[DON_AP] [bit] NULL,
	[REA_DR] [nvarchar](50) NULL,
	[LCB] [float] NULL,
 CONSTRAINT [PK_FILD03A] PRIMARY KEY CLUSTERED 
(
	[EMP_ID] ASC,
	[SEQ_NO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBLTYPELEAVE]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLTYPELEAVE](
	[LEA_ID] [nvarchar](3) NOT NULL,
	[SEQ_NO] [nvarchar](3) NULL,
	[COL_NM] [nvarchar](50) NULL,
	[LEA_NM] [nvarchar](50) NULL,
	[SHR_NM] [nvarchar](5) NULL,
	[DAY_MM] [int] NULL,
	[DAY_YY] [int] NULL,
	[DAY_QT] [int] NULL,
	[DAY_TM] [int] NULL,
	[SAL_CK] [bit] NULL,
	[HOL_BT] [bit] NULL,
 CONSTRAINT [PK_FILA15A] PRIMARY KEY CLUSTERED 
(
	[LEA_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBLTYPESHIFT]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLTYPESHIFT](
	[TYP_ID] [nvarchar](10) NOT NULL,
	[TYP_NM] [nvarchar](50) NULL,
	[TYP_EN] [nvarchar](50) NULL,
	[TYP_CH] [nvarchar](50) NULL,
	[TYP_VN] [nvarchar](50) NULL,
	[TYP_TT] [nvarchar](50) NULL,
	[ROU_DR] [nvarchar](5) NULL,
 CONSTRAINT [PK_GP_SYS_SHIFT] PRIMARY KEY CLUSTERED 
(
	[TYP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TINHTRANGPHIEU]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TINHTRANGPHIEU](
	[MaTinhTrangPhieu] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TINHTRANGPHIEU] PRIMARY KEY CLUSTERED 
(
	[MaTinhTrangPhieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WebActions]    Script Date: 3/14/2019 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WebActions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Controller] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_WebActions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170420142747_m1', N'1.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170420142919_m2', N'1.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170528135908_m1', N'1.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170528140122_m2', N'1.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170626152450_m_', N'1.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170626153510_m1', N'1.0.1')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'21698b32-9d47-413f-83c6-845e10c43d43', N'2933bdf0-7c01-46e8-84fa-43f22cbef313', N'Users', N'USERS')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'2a77373c-e059-4bd2-8565-d3b78033d0c2', N'10e3a627-262e-499d-95cb-f8735456324e', N'Administrators', N'ADMINISTRATORS')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'ee6990b9-485e-4fe3-8f11-f0369a3777a7', N'36abe3df-f454-4747-ab22-5ebdbc559c10', N'Supervisors', N'SUPERVISORS')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b7458474-d431-4503-87e6-879c11a41a1e', N'2a77373c-e059-4bd2-8565-d3b78033d0c2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b7458474-d431-4503-87e6-879c11a41a1e', N'ee6990b9-485e-4fe3-8f11-f0369a3777a7')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'b7458474-d431-4503-87e6-879c11a41a1e', 0, N'f46bc2ba-6c8e-4967-aa55-e1fb4e7cb613', N'trunglu885@gmail.com', 0, 1, NULL, N'TRUNGLU885@GMAIL.COM', N'TRUNGLU885@GMAIL.COM', N'AQAAAAEAACcQAAAAEBiHlu3z1fbMKk364MoYpsH+FzUggLOO1A6d0RjkYdA/7FGTkizy7EoLT3JlqNURvQ==', NULL, 0, N'7fb5ae9c-0324-428a-9b1d-703e2b03e1d5', 0, N'trunglu885@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'f780153c-62c6-4064-8683-c8ae0e4f6e53', 0, N'4494b099-b9c9-4180-8cc5-4be2dbbfdcc9', N'trunglu755@gmail.com', 0, 1, NULL, N'TRUNGLU755@GMAIL.COM', N'TRUNGLU755@GMAIL.COM', N'AQAAAAEAACcQAAAAEH7rROpebvwumQqPuvwDS2wYHY+5Q6R1UqAANObUDrecEuCbaXm9K77KJrECa1Sl/g==', NULL, 0, N'0a69fca9-66f5-4d83-8aae-ab1c607067d8', 0, N'trunglu755@gmail.com')
SET IDENTITY_INSERT [dbo].[BINHLUAN] ON 

INSERT [dbo].[BINHLUAN] ([MaBinhLuan], [NoiDung], [DanhGia], [NguoiBinhLuan], [ThoiGian], [DaXoa], [MaMonAn]) VALUES (1, N'Chà, phở này ăn ngon đó chứ, ăn là ghiền.', 4, N'nhocbexiu', CAST(N'2012-05-02 08:05:00.000' AS DateTime), 0, 1)
INSERT [dbo].[BINHLUAN] ([MaBinhLuan], [NoiDung], [DanhGia], [NguoiBinhLuan], [ThoiGian], [DaXoa], [MaMonAn]) VALUES (2, N'Đúng rồi, mình cũng đã từng ăn ở đây. Ngon lắm đó các bạn.', 5, N'heoconxauxi', CAST(N'2012-05-02 08:19:00.000' AS DateTime), 0, 1)
INSERT [dbo].[BINHLUAN] ([MaBinhLuan], [NoiDung], [DanhGia], [NguoiBinhLuan], [ThoiGian], [DaXoa], [MaMonAn]) VALUES (3, N'Chà, nghe các bác quảng cáo dữ quá. Bữa nào đi thử mới được.', 2, N'vitdeptrai', CAST(N'2012-05-03 10:07:00.000' AS DateTime), 0, 1)
INSERT [dbo].[BINHLUAN] ([MaBinhLuan], [NoiDung], [DanhGia], [NguoiBinhLuan], [ThoiGian], [DaXoa], [MaMonAn]) VALUES (4, N'Bạn nào đi nhớ rủ mình nha. Mình cũng muốn thử', 3, N'tuicondocthan', CAST(N'2012-05-08 04:01:00.000' AS DateTime), 0, 1)
INSERT [dbo].[BINHLUAN] ([MaBinhLuan], [NoiDung], [DanhGia], [NguoiBinhLuan], [ThoiGian], [DaXoa], [MaMonAn]) VALUES (5, N'Món này cùi bắp. Ăn làm gì cho tốn tiền.', 1, N'nguoidocbao', CAST(N'2012-05-08 09:04:00.000' AS DateTime), 0, 1)
INSERT [dbo].[BINHLUAN] ([MaBinhLuan], [NoiDung], [DanhGia], [NguoiBinhLuan], [ThoiGian], [DaXoa], [MaMonAn]) VALUES (6, N'Đã ăn rồi. Cũng tạm được.', 3, N'sieunhancanhsat', CAST(N'2012-05-08 09:10:00.000' AS DateTime), 0, 1)
INSERT [dbo].[BINHLUAN] ([MaBinhLuan], [NoiDung], [DanhGia], [NguoiBinhLuan], [ThoiGian], [DaXoa], [MaMonAn]) VALUES (7, N'Nhìn hình là thấy ngon rồi.', 4, N'hocsinhducon', CAST(N'2012-05-10 16:45:00.000' AS DateTime), 0, 1)
INSERT [dbo].[BINHLUAN] ([MaBinhLuan], [NoiDung], [DanhGia], [NguoiBinhLuan], [ThoiGian], [DaXoa], [MaMonAn]) VALUES (8, N'Nhà hàng này làm đồ ăn ngon lắm. Không riêng gì món này đâu các bác.', 5, N'onglao', CAST(N'2012-05-10 20:08:00.000' AS DateTime), 0, 1)
INSERT [dbo].[BINHLUAN] ([MaBinhLuan], [NoiDung], [DanhGia], [NguoiBinhLuan], [ThoiGian], [DaXoa], [MaMonAn]) VALUES (9, N'sdfsd', 4, N'sdfsd', CAST(N'2019-02-23 18:44:54.643' AS DateTime), 0, 6)
INSERT [dbo].[BINHLUAN] ([MaBinhLuan], [NoiDung], [DanhGia], [NguoiBinhLuan], [ThoiGian], [DaXoa], [MaMonAn]) VALUES (10, N' hbh
', 5, N'sdfsd', CAST(N'2019-02-23 18:45:25.913' AS DateTime), 0, 7)
SET IDENTITY_INSERT [dbo].[BINHLUAN] OFF
SET IDENTITY_INSERT [dbo].[DANHMUCBANAN] ON 

INSERT [dbo].[DANHMUCBANAN] ([MaDMBanAn], [Ten], [Anh], [DaXoa], [MoTa]) VALUES (1, N'Bàn VIP A', N'images/DanhMucBan/VipA.jpg', 0, N'15-20 người')
INSERT [dbo].[DANHMUCBANAN] ([MaDMBanAn], [Ten], [Anh], [DaXoa], [MoTa]) VALUES (2, N'Bàn VIP B', N'images/DanhMucBan/VipB.jpg', 0, N'8-14 người')
INSERT [dbo].[DANHMUCBANAN] ([MaDMBanAn], [Ten], [Anh], [DaXoa], [MoTa]) VALUES (3, N'Bàn VIP C', N'images/DanhMucBan/VipC.jpg', 0, N'1-7 người')
INSERT [dbo].[DANHMUCBANAN] ([MaDMBanAn], [Ten], [Anh], [DaXoa], [MoTa]) VALUES (4, N'Bàn thường', N'images/DanhMucBan/BanThuong.jpg', 0, N'1-4 người')
INSERT [dbo].[DANHMUCBANAN] ([MaDMBanAn], [Ten], [Anh], [DaXoa], [MoTa]) VALUES (5, N'Bàn ngoài trời', N'images/DanhMucBan/BanNgoaiTroi.jpg', 0, N'1-4 người')
SET IDENTITY_INSERT [dbo].[DANHMUCBANAN] OFF
SET IDENTITY_INSERT [dbo].[DANHMUCMONAN] ON 

INSERT [dbo].[DANHMUCMONAN] ([MaDMMonAn], [Ten], [Anh], [DaXoa]) VALUES (1, N'Lẩu', NULL, 0)
INSERT [dbo].[DANHMUCMONAN] ([MaDMMonAn], [Ten], [Anh], [DaXoa]) VALUES (2, N'Món nướng', NULL, 0)
INSERT [dbo].[DANHMUCMONAN] ([MaDMMonAn], [Ten], [Anh], [DaXoa]) VALUES (3, N'Món chay', NULL, 0)
INSERT [dbo].[DANHMUCMONAN] ([MaDMMonAn], [Ten], [Anh], [DaXoa]) VALUES (4, N'Món mặn', NULL, 0)
INSERT [dbo].[DANHMUCMONAN] ([MaDMMonAn], [Ten], [Anh], [DaXoa]) VALUES (5, N'Buffet', NULL, 0)
INSERT [dbo].[DANHMUCMONAN] ([MaDMMonAn], [Ten], [Anh], [DaXoa]) VALUES (6, N'Nước ngọt', NULL, 0)
INSERT [dbo].[DANHMUCMONAN] ([MaDMMonAn], [Ten], [Anh], [DaXoa]) VALUES (7, N'Bia', NULL, 0)
INSERT [dbo].[DANHMUCMONAN] ([MaDMMonAn], [Ten], [Anh], [DaXoa]) VALUES (8, N'Rượu', NULL, 0)
INSERT [dbo].[DANHMUCMONAN] ([MaDMMonAn], [Ten], [Anh], [DaXoa]) VALUES (9, N'Kem', NULL, 0)
INSERT [dbo].[DANHMUCMONAN] ([MaDMMonAn], [Ten], [Anh], [DaXoa]) VALUES (10, N'Cocktail', NULL, 0)
SET IDENTITY_INSERT [dbo].[DANHMUCMONAN] OFF
SET IDENTITY_INSERT [dbo].[LOAINGUOIDUNG] ON 

INSERT [dbo].[LOAINGUOIDUNG] ([MaLoaiNguoiDung], [TenLoaiNguoiDung]) VALUES (1, N'Admin')
INSERT [dbo].[LOAINGUOIDUNG] ([MaLoaiNguoiDung], [TenLoaiNguoiDung]) VALUES (2, N'Moderator')
INSERT [dbo].[LOAINGUOIDUNG] ([MaLoaiNguoiDung], [TenLoaiNguoiDung]) VALUES (3, N'Người dùng cao cấp')
INSERT [dbo].[LOAINGUOIDUNG] ([MaLoaiNguoiDung], [TenLoaiNguoiDung]) VALUES (4, N'Người dùng trung cấp')
INSERT [dbo].[LOAINGUOIDUNG] ([MaLoaiNguoiDung], [TenLoaiNguoiDung]) VALUES (5, N'Người dùng thường')
SET IDENTITY_INSERT [dbo].[LOAINGUOIDUNG] OFF
SET IDENTITY_INSERT [dbo].[MONAN] ON 

INSERT [dbo].[MONAN] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [MaDMMonAn], [Anh], [DanhGia], [DaXoa], [ConMon]) VALUES (1, N'Phở Bắc Hải', N'Phở nóng hổi vừa thổi vừa ăn, giá rẻ bất ngờ. Đa số người Bắc đang sống ở Sài Gòn vẫn tìm đến phở Hà Nội vì quen gu. Hiện nay khó tìm được một tiệm phở đúng nghĩa, không bị lai tạp. Dù là chín hay tái thì nước phở Bắc Hải rất trong, có rau, có tương và đủ loại hương vị.', 30000, 4, N'images/MonAn/PhoBacHai.jpg', 4, 0, 1)
INSERT [dbo].[MONAN] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [MaDMMonAn], [Anh], [DanhGia], [DaXoa], [ConMon]) VALUES (2, N'Thịt nguội xắt lát', N'Thịt nguội xắt lát là một trong những món thường có trong các buổi nhậu lai rai của các quý ông sau giờ tan ca. Cùng nhau ngồi lại để thưởng thức món ăn bình dân sau một ngày mệt nhọc.', 150000, 4, N'images/MonAn/ThitNguoiXatLat.jpg', 5, 0, 1)
INSERT [dbo].[MONAN] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [MaDMMonAn], [Anh], [DanhGia], [DaXoa], [ConMon]) VALUES (3, N'Bánh nướng sốt thịt', N'Hương vị bánh nướng thơm phức làm ngất ngay biết bao người. Mùi vị sốt thịt làm cho ai đã ngửi thấy mùi này cũng phải dừng chân để thưởng thức.', 80000, 4, N'images/MonAn/BanhNuongSotThit.jpg', 3, 0, 1)
INSERT [dbo].[MONAN] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [MaDMMonAn], [Anh], [DanhGia], [DaXoa], [ConMon]) VALUES (4, N'Cơm chiên Dương Châu', N'Món cơm chiên quá đặc trưng, với cái tên Dương Châu bắt nguồn từ Trung Hoa. Món ăn này không mấy xa lạ với người dân chúng ta.', 30000, 4, N'images/MonAn/ComChienDuongChau.jpg', 5, 0, 1)
INSERT [dbo].[MONAN] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [MaDMMonAn], [Anh], [DanhGia], [DaXoa], [ConMon]) VALUES (5, N'Chả giò tôm', N'Miếng chả giò bọc bên ngoài con tôm đem lại cảm giác khó tả. Mùi vị thơm lừng khi cắn từng miếng chả giò khiến bạn không thể dừng lại.', 60000, 4, N'images/MonAn/ChaGioTom.jpg', 3, 0, 1)
INSERT [dbo].[MONAN] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [MaDMMonAn], [Anh], [DanhGia], [DaXoa], [ConMon]) VALUES (6, N'Cơm tấm', N'Thật lạ, cái thứ hương nhàn nhạt, thơm dịu của hạt gạo gãy nát trong khi xay xát mà khiến bao người khi đi xa, trong lúc vội lòng thưởng thức ẩm thực xứ người mà phải tìm cho bằng được hương vị của món “cơm quê”', 20000, 4, N'images/MonAn/ComTam.jpg', 4, 0, 1)
INSERT [dbo].[MONAN] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [MaDMMonAn], [Anh], [DanhGia], [DaXoa], [ConMon]) VALUES (7, N'Hủ tiếu', N'Hủ tiếu vốn là món ăn của người Tàu phiêu bạt mang theo vào vùng đồng bằng sông Cửu Long. Họ phát âm là “cổ chéo” có nghĩa là sợi bột gạo nhỏ và dài, lâu ngày Việt hóa mà thành hủ tiếu.', 18000, 4, N'images/MonAn/HuTieu.jpg', 3, 0, 1)
INSERT [dbo].[MONAN] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [MaDMMonAn], [Anh], [DanhGia], [DaXoa], [ConMon]) VALUES (8, N'Tàu hủ óc cá', N'Hương vị tàu hủ ở các gánh hàng rong pha trộn mùi của cá không lẫn vào đâu làm cho món ăn này không thể bỏ qua. Ngoài ra mùi thơm của gừng làm cho người qua đường phải dừng chân cũng nói lên sức cuốn hút của món ăn này.', 28000, 4, N'images/MonAn/TauHuOcCa.jpg', 3, 0, 1)
INSERT [dbo].[MONAN] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [MaDMMonAn], [Anh], [DanhGia], [DaXoa], [ConMon]) VALUES (12, N'Tiết canh vịt', N'Sài Gòn có không biết bao nơi bán tiết canh vịt. Món mát bổ này cứ tưởng dân ngoài Bắc mê, ngờ đâu dân miền Nam cũng say đắm lạ. Dân ghiền thứ “huyết” này không còn nhớ nổi tên chủ quán nữa, nên chỉ gọi tắt bằng cách ghép ngay sau tên món bổ âm dương này vào tên đường, tên phố chẳng hạn như tiết canh Võ Văn Tần, tiết canh Mạc Thị Bưởi, tiết canh Thanh Đa, v.v và v.v… ', 40000, 4, N'images/MonAn/TietCanhVit.jpg', 2, 0, 1)
SET IDENTITY_INSERT [dbo].[MONAN] OFF
INSERT [dbo].[NGUOIDUNG] ([TenDangNhap], [MatKhau], [Email], [DienThoai], [Anh], [DaXoa], [MaLoaiNguoiDung]) VALUES (N'Admin', N'Admin', N'admin@gmail.com', N'0909888666', NULL, 0, 1)
INSERT [dbo].[NGUOIDUNG] ([TenDangNhap], [MatKhau], [Email], [DienThoai], [Anh], [DaXoa], [MaLoaiNguoiDung]) VALUES (N'alice', N'alice', N'alice@gmail.com', N'0909789987', NULL, 0, 5)
INSERT [dbo].[NGUOIDUNG] ([TenDangNhap], [MatKhau], [Email], [DienThoai], [Anh], [DaXoa], [MaLoaiNguoiDung]) VALUES (N'bill', N'bill', N'bill@gmail.com', N'0908123321', NULL, 0, 5)
INSERT [dbo].[NGUOIDUNG] ([TenDangNhap], [MatKhau], [Email], [DienThoai], [Anh], [DaXoa], [MaLoaiNguoiDung]) VALUES (N'casper', N'casper', N'casper@gmail.com', N'0909456654', NULL, 0, 2)
INSERT [dbo].[NGUOIDUNG] ([TenDangNhap], [MatKhau], [Email], [DienThoai], [Anh], [DaXoa], [MaLoaiNguoiDung]) VALUES (N'david', N'david', N'david@gmail.com', N'0909987412', NULL, 0, 3)
INSERT [dbo].[NGUOIDUNG] ([TenDangNhap], [MatKhau], [Email], [DienThoai], [Anh], [DaXoa], [MaLoaiNguoiDung]) VALUES (N'emily', N'emily', N'emily@gmail.com', N'0909741147', NULL, 0, 4)
INSERT [dbo].[TBLATTSYSSETTING] ([SEQ_NO], [ONN_MN], [ONN_BT], [OFF_MN], [OFF_BT], [ASB_MN], [CRD_MN], [MEA_QT], [SLI_OT], [MAX_WK], [MAX_YR], [SEQ_HR], [ROU_MN], [ROU_NO]) VALUES (1, 6, 1, 6, 1, 31, 4, 2, 1, 20, 300, 2, 6, 0)
INSERT [dbo].[TBLCARDDATA] ([DAT_TM], [EMP_ID], [SWI_DT], [USR_NM], [CRD_DT], [CRD_TM], [CRD_NO], [REA_NO], [STA_DR], [FIL_NM], [YSD_BT]) VALUES (201903080725, N'000000001', CAST(N'2019-03-09 09:04:00.000' AS DateTime), N'{UserID}', CAST(N'2019-03-08 00:00:00.000' AS DateTime), 725, N'0007069087', N'002', NULL, N'no file', NULL)
INSERT [dbo].[TBLCARDDATA] ([DAT_TM], [EMP_ID], [SWI_DT], [USR_NM], [CRD_DT], [CRD_TM], [CRD_NO], [REA_NO], [STA_DR], [FIL_NM], [YSD_BT]) VALUES (201903081640, N'000000001', CAST(N'2019-03-09 09:04:00.000' AS DateTime), N'{UserID}', CAST(N'2019-03-08 00:00:00.000' AS DateTime), 1640, N'0007069087', N'002', NULL, N'no file', NULL)
INSERT [dbo].[TBLDEPARMENT] ([DEP_ID], [DEP_NM], [DEP_N1], [DEP_HG], [COL_NO], [PEO_TT], [SEG_HR], [ROU_MN], [REM_DR], [SEQ_NO], [DIR_DP]) VALUES (N'100', N'Bảo vệ', N'', N'', NULL, 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[TBLDEPARMENT] ([DEP_ID], [DEP_NM], [DEP_N1], [DEP_HG], [COL_NO], [PEO_TT], [SEG_HR], [ROU_MN], [REM_DR], [SEQ_NO], [DIR_DP]) VALUES (N'1001', N'Pha chế', N'', N'', NULL, 0, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[TBLDEPARMENT] ([DEP_ID], [DEP_NM], [DEP_N1], [DEP_HG], [COL_NO], [PEO_TT], [SEG_HR], [ROU_MN], [REM_DR], [SEQ_NO], [DIR_DP]) VALUES (N'1002', N'Nấu ăn', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[TBLDEPARMENT] ([DEP_ID], [DEP_NM], [DEP_N1], [DEP_HG], [COL_NO], [PEO_TT], [SEG_HR], [ROU_MN], [REM_DR], [SEQ_NO], [DIR_DP]) VALUES (N'1003', N'Dịch vụ', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[TBLDEPARMENT] ([DEP_ID], [DEP_NM], [DEP_N1], [DEP_HG], [COL_NO], [PEO_TT], [SEG_HR], [ROU_MN], [REM_DR], [SEQ_NO], [DIR_DP]) VALUES (N'1004', N'Tiếp tân', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TBLDETAILSATTENDANCE] ([EMP_ID], [ATT_DT], [DEP_ID], [EMP_I1], [SHI_ID], [NOT_OR], [NOT_DR], [NOT_D1], [NIG_TM], [ONN_01], [OFF_01], [ONN_02], [OFF_02], [ONN_03], [OFF_03], [ONN_04], [OFF_04], [ONN_05], [OFF_05], [ATT_HR], [OTT_HR], [LAT_MN], [LAT_TM], [EAR_MN], [EAR_TM], [ABS_MN], [ABS_TM], [ATT_DY], [NIG_DY], [LOC_BT], [LOC_B1], [USR_CK], [NIG_HR], [DOF_HR], [DOF_NS], [HOL_HR], [HOL_NS], [NIG_OT], [LEA_I1], [LEA_H1], [LEA_I2], [LEA_H2], [LEA_I3], [LEA_H3], [OTR_HR], [DOF_OV], [HienDien]) VALUES (N'000000001', CAST(N'2019-03-08 00:00:00.000' AS DateTime), N'1002', N'', N'HC', NULL, N'{UserLogin} Sign; Late;', N'00', 0, 736, 1640, 0, 0, 0, 0, 0, 0, 0, 0, 754, 0, 6, 1, 0, 0, 0, 0, 0.9875, 0, NULL, NULL, NULL, 0, 0, 0, 0, 0, 0, NULL, 0, NULL, 0, NULL, 0, 0, 0, NULL)
INSERT [dbo].[TBLDETAILSATTENDANCE] ([EMP_ID], [ATT_DT], [DEP_ID], [EMP_I1], [SHI_ID], [NOT_OR], [NOT_DR], [NOT_D1], [NIG_TM], [ONN_01], [OFF_01], [ONN_02], [OFF_02], [ONN_03], [OFF_03], [ONN_04], [OFF_04], [ONN_05], [OFF_05], [ATT_HR], [OTT_HR], [LAT_MN], [LAT_TM], [EAR_MN], [EAR_TM], [ABS_MN], [ABS_TM], [ATT_DY], [NIG_DY], [LOC_BT], [LOC_B1], [USR_CK], [NIG_HR], [DOF_HR], [DOF_NS], [HOL_HR], [HOL_NS], [NIG_OT], [LEA_I1], [LEA_H1], [LEA_I2], [LEA_H2], [LEA_I3], [LEA_H3], [OTR_HR], [DOF_OV], [HienDien]) VALUES (N'000000002', CAST(N'2019-03-04 00:00:00.000' AS DateTime), N'100', N'', N'HC', NULL, N'{UserLogin} Sign; Early;', N'01', 0, 729, 1124, 0, 0, 0, 0, 0, 0, 0, 0, 354, 0, 0, 0, 6, 1, 0, 0, 0.4875, 0, NULL, NULL, NULL, 0, 0, 0, 0, 0, 0, NULL, 0, NULL, 0, NULL, 0, 0, 0, 1)
INSERT [dbo].[TBLDETAILSROSTER] ([SHI_ID], [SEQ_N1], [SEQ_NO], [ONN_TM], [ONN_RD], [ONN_BT], [OFF_TM], [OFF_RD], [OFF_BT], [TYP_ID], [MIN_ST], [WRK_HR], [LAT_BT], [BLT_NM], [BLT_DT], [LST_NM], [LST_DT], [MAN_IN], [MAN_OU]) VALUES (N'HC', 1, N'01', 730, NULL, NULL, 1130, NULL, NULL, N'ATT_HR', NULL, 400, 1, N'my', CAST(N'2017-09-12 13:48:00.000' AS DateTime), N'my', CAST(N'2017-09-12 13:48:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[TBLDETAILSROSTER] ([SHI_ID], [SEQ_N1], [SEQ_NO], [ONN_TM], [ONN_RD], [ONN_BT], [OFF_TM], [OFF_RD], [OFF_BT], [TYP_ID], [MIN_ST], [WRK_HR], [LAT_BT], [BLT_NM], [BLT_DT], [LST_NM], [LST_DT], [MAN_IN], [MAN_OU]) VALUES (N'HC', 2, N'02', 1230, NULL, NULL, 1630, NULL, NULL, N'ATT_HR', NULL, 400, 1, N'my', CAST(N'2017-09-12 13:48:00.000' AS DateTime), N'hrcb', CAST(N'2017-10-17 10:48:00.000' AS DateTime), NULL, 1530)
INSERT [dbo].[TBLEMPLOYEE] ([EMP_ID], [EMP_I1], [EMP_NM], [EMP_N1], [MST_DR], [BIR_DT], [SEX_BT], [MAR_BT], [DEP_ID], [COU_ID], [CRD_NO], [POS_ID], [ADD_DR], [ADD_D1], [INH_DT], [CRD_ID], [CRD_DT], [CRD_LC], [CIT_ID], [RAC_NM], [NAT_CO], [EDU_ID], [PRO_ID], [GRA_ID], [TEL_NO], [TYP_ID], [ACC_NO], [ACC_NM], [BNK_NM], [REL_DR], [NEW_BT], [MEA_BT], [REM_DR], [ATT_BT], [SAL_BT], [VAC_BT], [DEL_BT], [GRT_ID], [GRP_ID], [LEV_ID], [LCK_BT], [BHX_BT], [DIR_BT], [BLT_NM], [BLT_DT], [LST_NM], [LST_DT], [SEN_DT], [REM_D2], [FIR_DT]) VALUES (N'000000001', NULL, N'Nguyễn Đức Toàn', NULL, NULL, CAST(N'1986-03-12 00:00:00.000' AS DateTime), 1, 0, N'1002', NULL, N'0007069087', N'004', NULL, NULL, CAST(N'2015-06-17 00:00:00.000' AS DateTime), N'212728879', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'TT', NULL, NULL, NULL, NULL, 1, 0, NULL, 1, 1, 0, 0, NULL, NULL, NULL, 0, 0, 0, N'admin', CAST(N'2017-11-04 11:17:00.000' AS DateTime), N'admin', CAST(N'2017-11-04 11:17:00.000' AS DateTime), NULL, NULL, CAST(N'2015-07-17 00:00:00.000' AS DateTime))
INSERT [dbo].[TBLEMPLOYEE] ([EMP_ID], [EMP_I1], [EMP_NM], [EMP_N1], [MST_DR], [BIR_DT], [SEX_BT], [MAR_BT], [DEP_ID], [COU_ID], [CRD_NO], [POS_ID], [ADD_DR], [ADD_D1], [INH_DT], [CRD_ID], [CRD_DT], [CRD_LC], [CIT_ID], [RAC_NM], [NAT_CO], [EDU_ID], [PRO_ID], [GRA_ID], [TEL_NO], [TYP_ID], [ACC_NO], [ACC_NM], [BNK_NM], [REL_DR], [NEW_BT], [MEA_BT], [REM_DR], [ATT_BT], [SAL_BT], [VAC_BT], [DEL_BT], [GRT_ID], [GRP_ID], [LEV_ID], [LCK_BT], [BHX_BT], [DIR_BT], [BLT_NM], [BLT_DT], [LST_NM], [LST_DT], [SEN_DT], [REM_D2], [FIR_DT]) VALUES (N'000000002', NULL, N'Huỳnh Văn Tỉnh', NULL, NULL, CAST(N'1990-10-09 00:00:00.000' AS DateTime), 1, 0, N'100', NULL, N'0007069088', N'004', NULL, NULL, CAST(N'2015-06-25 00:00:00.000' AS DateTime), N'212748466', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'GT', NULL, NULL, NULL, NULL, 1, 0, NULL, 1, 1, 0, 0, NULL, NULL, NULL, 0, 0, 0, N'admin', CAST(N'2017-11-04 11:30:00.000' AS DateTime), N'admin', CAST(N'2017-11-04 11:31:00.000' AS DateTime), NULL, NULL, CAST(N'2015-07-25 00:00:00.000' AS DateTime))
INSERT [dbo].[TBLEMPLOYEE] ([EMP_ID], [EMP_I1], [EMP_NM], [EMP_N1], [MST_DR], [BIR_DT], [SEX_BT], [MAR_BT], [DEP_ID], [COU_ID], [CRD_NO], [POS_ID], [ADD_DR], [ADD_D1], [INH_DT], [CRD_ID], [CRD_DT], [CRD_LC], [CIT_ID], [RAC_NM], [NAT_CO], [EDU_ID], [PRO_ID], [GRA_ID], [TEL_NO], [TYP_ID], [ACC_NO], [ACC_NM], [BNK_NM], [REL_DR], [NEW_BT], [MEA_BT], [REM_DR], [ATT_BT], [SAL_BT], [VAC_BT], [DEL_BT], [GRT_ID], [GRP_ID], [LEV_ID], [LCK_BT], [BHX_BT], [DIR_BT], [BLT_NM], [BLT_DT], [LST_NM], [LST_DT], [SEN_DT], [REM_D2], [FIR_DT]) VALUES (N'000000003', NULL, N'Ngô Quang Cường', NULL, NULL, CAST(N'1991-02-06 00:00:00.000' AS DateTime), 1, 0, N'1002', NULL, N'0007069089', N'004', NULL, NULL, CAST(N'2015-06-25 00:00:00.000' AS DateTime), N'212756153', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'GT', NULL, NULL, NULL, NULL, 1, 0, NULL, 1, 1, 0, 0, NULL, NULL, NULL, 0, 0, 0, N'admin', CAST(N'2017-11-04 11:26:00.000' AS DateTime), N'admin', CAST(N'2017-11-04 11:26:00.000' AS DateTime), NULL, NULL, CAST(N'2015-07-25 00:00:00.000' AS DateTime))
INSERT [dbo].[TBLEMPLOYEE] ([EMP_ID], [EMP_I1], [EMP_NM], [EMP_N1], [MST_DR], [BIR_DT], [SEX_BT], [MAR_BT], [DEP_ID], [COU_ID], [CRD_NO], [POS_ID], [ADD_DR], [ADD_D1], [INH_DT], [CRD_ID], [CRD_DT], [CRD_LC], [CIT_ID], [RAC_NM], [NAT_CO], [EDU_ID], [PRO_ID], [GRA_ID], [TEL_NO], [TYP_ID], [ACC_NO], [ACC_NM], [BNK_NM], [REL_DR], [NEW_BT], [MEA_BT], [REM_DR], [ATT_BT], [SAL_BT], [VAC_BT], [DEL_BT], [GRT_ID], [GRP_ID], [LEV_ID], [LCK_BT], [BHX_BT], [DIR_BT], [BLT_NM], [BLT_DT], [LST_NM], [LST_DT], [SEN_DT], [REM_D2], [FIR_DT]) VALUES (N'000000004', NULL, N'Đỗ Thị Vân Kiều', NULL, NULL, CAST(N'1992-02-24 00:00:00.000' AS DateTime), 0, 0, N'1004', NULL, N'0007069090', N'004', NULL, NULL, CAST(N'2015-08-04 00:00:00.000' AS DateTime), N'212313569', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'TT', NULL, NULL, NULL, NULL, 1, 0, NULL, 1, 1, 0, 0, NULL, NULL, NULL, 0, 0, 0, N'admin', CAST(N'2017-11-04 11:04:00.000' AS DateTime), N'admin', CAST(N'2017-11-04 11:07:00.000' AS DateTime), NULL, NULL, CAST(N'2015-09-03 00:00:00.000' AS DateTime))
INSERT [dbo].[TBLEMPLOYEE] ([EMP_ID], [EMP_I1], [EMP_NM], [EMP_N1], [MST_DR], [BIR_DT], [SEX_BT], [MAR_BT], [DEP_ID], [COU_ID], [CRD_NO], [POS_ID], [ADD_DR], [ADD_D1], [INH_DT], [CRD_ID], [CRD_DT], [CRD_LC], [CIT_ID], [RAC_NM], [NAT_CO], [EDU_ID], [PRO_ID], [GRA_ID], [TEL_NO], [TYP_ID], [ACC_NO], [ACC_NM], [BNK_NM], [REL_DR], [NEW_BT], [MEA_BT], [REM_DR], [ATT_BT], [SAL_BT], [VAC_BT], [DEL_BT], [GRT_ID], [GRP_ID], [LEV_ID], [LCK_BT], [BHX_BT], [DIR_BT], [BLT_NM], [BLT_DT], [LST_NM], [LST_DT], [SEN_DT], [REM_D2], [FIR_DT]) VALUES (N'000000005', NULL, N'Võ Thị Mến Thương', NULL, NULL, CAST(N'1992-08-08 00:00:00.000' AS DateTime), 0, 0, N'1001', NULL, N'0007069091', N'008', NULL, NULL, CAST(N'2015-09-07 00:00:00.000' AS DateTime), N'212327003', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'NV', NULL, NULL, NULL, NULL, 1, 0, NULL, 1, 1, 0, 0, NULL, NULL, NULL, 0, 0, 0, N'admin', CAST(N'2017-11-04 11:37:00.000' AS DateTime), N'admin', CAST(N'2017-11-04 11:37:00.000' AS DateTime), NULL, NULL, CAST(N'2015-11-06 00:00:00.000' AS DateTime))
INSERT [dbo].[TBLEXCOLATTENDANCE] ([COL_NM], [COL_MM], [COL_EN], [COL_VN], [COL_CH], [COL_TT], [MON_BT], [FOR_DR], [GIO_BT], [HID_BT]) VALUES (N'HienDien', NULL, N'HienDien', N'HienDien', N'HienDien', N'HienDien', 1, N'', 0, 0)
INSERT [dbo].[TBLHOLIDAY] ([YYY_YY], [MMM_MM], [h1], [h2], [h3], [h4], [h5], [h6], [h7], [h8], [h9], [h10], [h11], [h12], [h13], [h14], [h15], [h16], [h17], [h18], [h19], [h20], [h21], [h22], [h23], [h24], [h25], [h26], [h27], [h28], [h29], [h30], [h31]) VALUES (N'2019', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TBLHOLIDAY] ([YYY_YY], [MMM_MM], [h1], [h2], [h3], [h4], [h5], [h6], [h7], [h8], [h9], [h10], [h11], [h12], [h13], [h14], [h15], [h16], [h17], [h18], [h19], [h20], [h21], [h22], [h23], [h24], [h25], [h26], [h27], [h28], [h29], [h30], [h31]) VALUES (N'2019', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TBLHOLIDAY] ([YYY_YY], [MMM_MM], [h1], [h2], [h3], [h4], [h5], [h6], [h7], [h8], [h9], [h10], [h11], [h12], [h13], [h14], [h15], [h16], [h17], [h18], [h19], [h20], [h21], [h22], [h23], [h24], [h25], [h26], [h27], [h28], [h29], [h30], [h31]) VALUES (N'2019', 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TBLHOLIDAY] ([YYY_YY], [MMM_MM], [h1], [h2], [h3], [h4], [h5], [h6], [h7], [h8], [h9], [h10], [h11], [h12], [h13], [h14], [h15], [h16], [h17], [h18], [h19], [h20], [h21], [h22], [h23], [h24], [h25], [h26], [h27], [h28], [h29], [h30], [h31]) VALUES (N'2019', 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TBLLEAVE] ([SEQ_NO], [EMP_ID], [STR_DT], [END_DT], [HOU_DY], [STR_TM], [END_TM], [HOU_TT], [LEA_ID], [DAY_TT], [DAY_BT], [NOT_DR], [BLT_NM], [BLT_DT], [LST_NM], [LST_DT]) VALUES (1, N'000000001', CAST(N'2019-03-07 00:00:00.000' AS DateTime), CAST(N'2019-03-07 00:00:00.000' AS DateTime), 8, NULL, NULL, 8, N'006', 1, 1, N'nghỉ việc riêng đã sửa lần 2', N'trunglu885@gmail.com', CAST(N'2019-03-07 16:33:00.000' AS DateTime), N'trunglu885@gmail.com', CAST(N'2019-03-07 16:59:20.000' AS DateTime))
INSERT [dbo].[TBLMONTHATTENDANCE] ([EMP_ID], [YYY_MM], [SEQ_NO], [DEP_I1], [EMP_DW], [NOT_DR], [BLT_NM], [BLT_DT], [LST_NM], [LST_DT], [LOC_B1], [HOL_TT], [ATT_HR], [OTT_HR], [OVO_HR], [LAT_MN], [LAT_TM], [EAR_MN], [EAR_TM], [ABS_MN], [ABS_TM], [LEA_QT], [ATT_DY], [NIG_DY], [NIG_HR], [DOF_HR], [DOF_NS], [HOL_HR], [HOL_NS], [NIG_OT], [OTR_HR], [LEA_001], [LEA_002], [LEA_003], [LEA_004], [LEA_005], [LEA_006], [LEA_007], [LEA_008], [LEA_009], [LEA_010], [LEA_011], [LEA_012], [LEA_013], [LEA_014], [LEA_015], [LEA_016], [LEA_017], [LEA_018], [LEA_019], [LEA_020], [BOS_AM], [FIN_AM], [DOF_OV], [HienDien]) VALUES (N'000000001', N'201903', 2, N'1002', N'', N'2019/03/01~2019/03/31', N'{User Login}', CAST(N'2019-03-14 17:09:00.000' AS DateTime), NULL, NULL, NULL, 0, 7.9, 0, 0, 0.1, 1, 0, 0, 0, 0, 0, 0.9875, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[TBLMONTHSHIFT] ([EMP_ID], [YYY_MM], [DAY_01], [DAY_02], [DAY_03], [DAY_04], [DAY_05], [DAY_06], [DAY_07], [DAY_08], [DAY_09], [DAY_10], [DAY_11], [DAY_12], [DAY_13], [DAY_14], [DAY_15], [DAY_16], [DAY_17], [DAY_18], [DAY_19], [DAY_20], [DAY_21], [DAY_22], [DAY_23], [DAY_24], [DAY_25], [DAY_26], [DAY_27], [DAY_28], [DAY_29], [DAY_30], [DAY_31], [BLT_NM], [BLT_DT], [LST_NM], [LST_DT]) VALUES (N'000000001', N'201903', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'HC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TBLROSTER] ([SHI_ID], [SHI_NM], [MAX_HR], [MIN_HR], [CON_H1], [ADD_H1], [CON_H2], [ADD_H2], [BLT_NM], [BLT_DT], [LST_NM], [LST_DT], [TIM_02], [ONN_TM], [OFF_TM], [NIG_SH], [ONN_OT]) VALUES (N'cn', N'ca chủ nhật', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TBLROSTER] ([SHI_ID], [SHI_NM], [MAX_HR], [MIN_HR], [CON_H1], [ADD_H1], [CON_H2], [ADD_H2], [BLT_NM], [BLT_DT], [LST_NM], [LST_DT], [TIM_02], [ONN_TM], [OFF_TM], [NIG_SH], [ONN_OT]) VALUES (N'HC', N'Ca Hành chính', 2400, 600, NULL, NULL, NULL, NULL, N'my', CAST(N'2017-09-12 13:48:00.000' AS DateTime), N'hr02', CAST(N'2018-06-09 08:47:00.000' AS DateTime), NULL, 530, 1630, NULL, 1630)
INSERT [dbo].[TBLTYPELEAVE] ([LEA_ID], [SEQ_NO], [COL_NM], [LEA_NM], [SHR_NM], [DAY_MM], [DAY_YY], [DAY_QT], [DAY_TM], [SAL_CK], [HOL_BT]) VALUES (N'001', N'001', NULL, N'Phép năm', N'PN', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[TBLTYPELEAVE] ([LEA_ID], [SEQ_NO], [COL_NM], [LEA_NM], [SHR_NM], [DAY_MM], [DAY_YY], [DAY_QT], [DAY_TM], [SAL_CK], [HOL_BT]) VALUES (N'006', N'005', NULL, N'Việc Riêng', N'VR', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[TBLTYPELEAVE] ([LEA_ID], [SEQ_NO], [COL_NM], [LEA_NM], [SHR_NM], [DAY_MM], [DAY_YY], [DAY_QT], [DAY_TM], [SAL_CK], [HOL_BT]) VALUES (N'007', N'006', NULL, N'Nghỉ Bệnh', N'NB', NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[TBLTYPESHIFT] ([TYP_ID], [TYP_NM], [TYP_EN], [TYP_CH], [TYP_VN], [TYP_TT], [ROU_DR]) VALUES (N'ATT_HR', N'Normal-Bình Thường', N'Normal-Bình Thường', N'正常工時', N'Normal-Bình Thường', N'正常工时', N'02-05')
INSERT [dbo].[TBLTYPESHIFT] ([TYP_ID], [TYP_NM], [TYP_EN], [TYP_CH], [TYP_VN], [TYP_TT], [ROU_DR]) VALUES (N'DOF_HR', N'Ca Ngày Nghỉ', N'Ca Ngày Nghỉ', N'週日班', N'Ca Ngày Nghỉ', N'假日班', N'02-05')
INSERT [dbo].[TBLTYPESHIFT] ([TYP_ID], [TYP_NM], [TYP_EN], [TYP_CH], [TYP_VN], [TYP_TT], [ROU_DR]) VALUES (N'DOF_NS', N'Ca Đêm Ngày Nghỉ', N'Ca Đêm Ngày Nghỉ', N'週日夜班', N'Ca Đêm Ngày Nghỉ', N'假日夜班', N'02-05')
INSERT [dbo].[TBLTYPESHIFT] ([TYP_ID], [TYP_NM], [TYP_EN], [TYP_CH], [TYP_VN], [TYP_TT], [ROU_DR]) VALUES (N'DOF_OV', N'TCa Đêm Ngày Nghỉ', N'TCa Đêm Ngày Nghỉ', N'週日夜班加班', N'TCa Đêm Ngày Nghỉ', N'假日夜班加班', N'02-05')
INSERT [dbo].[TBLTYPESHIFT] ([TYP_ID], [TYP_NM], [TYP_EN], [TYP_CH], [TYP_VN], [TYP_TT], [ROU_DR]) VALUES (N'HOL_HR', N'Ca Ngày Lễ', N'Ca Ngày Lễ', N'節日班', N'Ca Ngày Lễ', N'节日班', N'02-05')
INSERT [dbo].[TBLTYPESHIFT] ([TYP_ID], [TYP_NM], [TYP_EN], [TYP_CH], [TYP_VN], [TYP_TT], [ROU_DR]) VALUES (N'HOL_NS', N'Ca Đêm Ngày Lễ', N'Ca Đêm Ngày Lễ', N'節日夜班', N'Ca Đêm Ngày Lễ', N'節日夜班', N'02-05')
INSERT [dbo].[TBLTYPESHIFT] ([TYP_ID], [TYP_NM], [TYP_EN], [TYP_CH], [TYP_VN], [TYP_TT], [ROU_DR]) VALUES (N'NIG_HR', N'Ca Đêm', N'Ca Đêm', N'正常夜班', N'Ca Đêm', N'夜班', N'02-05')
INSERT [dbo].[TBLTYPESHIFT] ([TYP_ID], [TYP_NM], [TYP_EN], [TYP_CH], [TYP_VN], [TYP_TT], [ROU_DR]) VALUES (N'NIG_OT', N'Tăng Ca Đêm', N'Tăng Ca Ca Đêm', N'夜班加班', N'Tăng Ca Ca Đêm', N'夜班加班', N'02-05')
INSERT [dbo].[TBLTYPESHIFT] ([TYP_ID], [TYP_NM], [TYP_EN], [TYP_CH], [TYP_VN], [TYP_TT], [ROU_DR]) VALUES (N'OTT_HR', N'OT', N'OT- Tăng Ca', N'正常加班', N'OT- Tăng Ca', N'OT-加班', N'02-05')
SET IDENTITY_INSERT [dbo].[TINHTRANGPHIEU] ON 

INSERT [dbo].[TINHTRANGPHIEU] ([MaTinhTrangPhieu], [Ten]) VALUES (1, N'Đã đặt')
INSERT [dbo].[TINHTRANGPHIEU] ([MaTinhTrangPhieu], [Ten]) VALUES (2, N'Đang xác nhận')
INSERT [dbo].[TINHTRANGPHIEU] ([MaTinhTrangPhieu], [Ten]) VALUES (3, N'Đã xác nhận')
INSERT [dbo].[TINHTRANGPHIEU] ([MaTinhTrangPhieu], [Ten]) VALUES (4, N'Đã hủy')
INSERT [dbo].[TINHTRANGPHIEU] ([MaTinhTrangPhieu], [Ten]) VALUES (5, N'Đang lưu tạm')
SET IDENTITY_INSERT [dbo].[TINHTRANGPHIEU] OFF
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [LCB]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TongLuongHD]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [NgayCong]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TienNgayCong]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [NgayLe]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TienNgayLe]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [NgayNgungViec]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TienNgungViec]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TC]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TCCN]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TCDem]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TCCNDem]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TCLe]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TCLeDem]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [CongKhac]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TruKhac]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [ChuyenCan]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TongLuong]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [BHXH]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [BHYT]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [BHTN]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TongBH]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [DoanPhi]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [BanThan]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [SoNguoiPhuThuoc]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TienPhuThuoc]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TienTCHeSo1]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TNTinhThue]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [ThueThuNhap]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [ThucLanh]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TienTC]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TienTCDem]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TienTCCN]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TienTCCNDem]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TienTCLe]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TienTCLeDem]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [NCChuan]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [PhepCoLuong]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TienPhepCoLuong]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [PhepVR]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [PhepThaiSan]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [PhepDuongSuc]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [PhepOm]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [KhongPhep]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TienPhepKoLuong]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TongTienTC]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TongGioTC]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [ThuongNangSuat]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [ThuongCuoiNam]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [PhepNamConLai]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TienPhepNamConLai]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [BHXH_CT]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [BHYT_CT]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [BHTN_CT]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [BHTNNN_CT]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [DoanPhi_CT]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TongBH_CT]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [Temp]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [LuongBH]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [ATVSV]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [PCConNho6T]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [MLAnToanVeSinh]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [ThuongGTNhanLuc]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [PhepCuoi]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [PhepTang]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [PhepKhamThai]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [PhepKHHGD]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [PhepSayThai]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [ThuongCBDatSL]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [ThuongSL]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [ThuongCGBC]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [SoGioTK]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [ThuongTKGioCong]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [ThuongSXuat]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TNChiuThue]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TienPhepCuoi]
GO
ALTER TABLE [dbo].[TBLPAYROLL] ADD  DEFAULT ((0)) FOR [TienPhepTang]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[BANAN]  WITH CHECK ADD  CONSTRAINT [FK_BANAN_DANHMUCBANAN] FOREIGN KEY([MaDMBanAn])
REFERENCES [dbo].[DANHMUCBANAN] ([MaDMBanAn])
GO
ALTER TABLE [dbo].[BANAN] CHECK CONSTRAINT [FK_BANAN_DANHMUCBANAN]
GO
ALTER TABLE [dbo].[BINHLUAN]  WITH CHECK ADD  CONSTRAINT [FK_BINHLUAN_MONAN] FOREIGN KEY([MaMonAn])
REFERENCES [dbo].[MONAN] ([MaMonAn])
GO
ALTER TABLE [dbo].[BINHLUAN] CHECK CONSTRAINT [FK_BINHLUAN_MONAN]
GO
ALTER TABLE [dbo].[CHITIETPHIEU]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETPHIEU_MONAN] FOREIGN KEY([MaMonAn])
REFERENCES [dbo].[MONAN] ([MaMonAn])
GO
ALTER TABLE [dbo].[CHITIETPHIEU] CHECK CONSTRAINT [FK_CHITIETPHIEU_MONAN]
GO
ALTER TABLE [dbo].[CHITIETPHIEU]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETPHIEU_PHIEUDATCHO] FOREIGN KEY([MaPhieu])
REFERENCES [dbo].[PHIEUDATCHO] ([MaPhieu])
GO
ALTER TABLE [dbo].[CHITIETPHIEU] CHECK CONSTRAINT [FK_CHITIETPHIEU_PHIEUDATCHO]
GO
ALTER TABLE [dbo].[MONAN]  WITH CHECK ADD  CONSTRAINT [FK_MONAN_DANHMUCMONAN] FOREIGN KEY([MaDMMonAn])
REFERENCES [dbo].[DANHMUCMONAN] ([MaDMMonAn])
GO
ALTER TABLE [dbo].[MONAN] CHECK CONSTRAINT [FK_MONAN_DANHMUCMONAN]
GO
ALTER TABLE [dbo].[NGUOIDUNG]  WITH CHECK ADD  CONSTRAINT [FK_NGUOIDUNG_LOAINGUOIDUNG] FOREIGN KEY([MaLoaiNguoiDung])
REFERENCES [dbo].[LOAINGUOIDUNG] ([MaLoaiNguoiDung])
GO
ALTER TABLE [dbo].[NGUOIDUNG] CHECK CONSTRAINT [FK_NGUOIDUNG_LOAINGUOIDUNG]
GO
ALTER TABLE [dbo].[Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Permissions_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[Permissions] CHECK CONSTRAINT [FK_Permissions_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Permissions_WebActions_WebActionId] FOREIGN KEY([WebActionId])
REFERENCES [dbo].[WebActions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Permissions] CHECK CONSTRAINT [FK_Permissions_WebActions_WebActionId]
GO
ALTER TABLE [dbo].[PHIEUDATCHO]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUDATCHO_BANAN] FOREIGN KEY([MaBanAn])
REFERENCES [dbo].[BANAN] ([MaBan])
GO
ALTER TABLE [dbo].[PHIEUDATCHO] CHECK CONSTRAINT [FK_PHIEUDATCHO_BANAN]
GO
ALTER TABLE [dbo].[PHIEUDATCHO]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUDATCHO_NGUOIDUNG] FOREIGN KEY([TenDangNhap])
REFERENCES [dbo].[NGUOIDUNG] ([TenDangNhap])
GO
ALTER TABLE [dbo].[PHIEUDATCHO] CHECK CONSTRAINT [FK_PHIEUDATCHO_NGUOIDUNG]
GO
ALTER TABLE [dbo].[PHIEUDATCHO]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUDATCHO_TINHTRANGPHIEU] FOREIGN KEY([MaTinhTrangPhieu])
REFERENCES [dbo].[TINHTRANGPHIEU] ([MaTinhTrangPhieu])
GO
ALTER TABLE [dbo].[PHIEUDATCHO] CHECK CONSTRAINT [FK_PHIEUDATCHO_TINHTRANGPHIEU]
GO
USE [master]
GO
ALTER DATABASE [QLNhaHang] SET  READ_WRITE 
GO
