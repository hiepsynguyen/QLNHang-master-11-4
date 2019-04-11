using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.QLNHangData
{
    public partial class QLNhaHangContext : DbContext
    {
        public QLNhaHangContext()
        {
        }

        public QLNhaHangContext(DbContextOptions<QLNhaHangContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tbltypeshift> Tbltypeshift { get; set; }
        public virtual DbSet<Tbldeparment> Tbldeparment { get; set; }
        public virtual DbSet<Tbldetailsattendance> Tbldetailsattendance { get; set; }
        public virtual DbSet<Tbldetailsroster> Tbldetailsroster { get; set; }
        public virtual DbSet<Tblemployee> Tblemployee { get; set; }
        public virtual DbSet<Tblleave> Tblleave { get; set; }
        public virtual DbSet<Tblmonthattendance> Tblmonthattendance { get; set; }
        public virtual DbSet<Tblmonthshift> Tblmonthshift { get; set; }
        public virtual DbSet<Tblpayroll> Tblpayroll { get; set; }
        public virtual DbSet<Tblroster> Tblroster { get; set; }
        public virtual DbSet<Tblsalary> Tblsalary { get; set; }
        public virtual DbSet<Tbltypeleave> Tbltypeleave { get; set; }
        public virtual DbSet<Tblcarddata> Tblcarddata { get; set; }

        public virtual DbSet<Tblbookdetail> Tblbookdetail { get; set; }
        public virtual DbSet<Tblbooking> Tblbooking { get; set; }
        public virtual DbSet<Tblbookingstatus> Tblbookingstatus { get; set; }
        public virtual DbSet<Tblcomment> Tblcomment { get; set; }
        public virtual DbSet<Tblfood> Tblfood { get; set; }
        public virtual DbSet<Tblfoodcategory> Tblfoodcategory { get; set; }
        public virtual DbSet<Tbltablecategory> Tbltablecategory { get; set; }
        public virtual DbSet<Tbltablefood> Tbltablefood { get; set; }
        public virtual DbSet<Tbluser> Tbluser { get; set; }
        public virtual DbSet<Tblusertype> Tblusertype { get; set; }

        //public static string GetConnectionString() {
        //    return Startup.ConnectionString;
        //}

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//                //var con = optionsBuilder;
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                //optionsBuilder.UseSqlServer("Server=.\\;Database=QLNhaHang;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Tbldeparment>(entity =>
            {
                entity.HasKey(e => e.DepId);

                entity.ToTable("TBLDEPARMENT");

                entity.Property(e => e.DepId)
                    .HasColumnName("DEP_ID")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.ColNo)
                    .HasColumnName("COL_NO")
                    .HasMaxLength(20);

                entity.Property(e => e.DepHg)
                    .HasColumnName("DEP_HG")
                    .HasMaxLength(200);

                entity.Property(e => e.DepN1)
                    .HasColumnName("DEP_N1")
                    .HasMaxLength(100);

                entity.Property(e => e.DepNm)
                    .HasColumnName("DEP_NM")
                    .HasMaxLength(100);

                entity.Property(e => e.DirDp).HasColumnName("DIR_DP");

                entity.Property(e => e.PeoTt).HasColumnName("PEO_TT");

                entity.Property(e => e.RemDr)
                    .HasColumnName("REM_DR")
                    .HasMaxLength(50);

                entity.Property(e => e.RouMn).HasColumnName("ROU_MN");

                entity.Property(e => e.SegHr).HasColumnName("SEG_HR");

                entity.Property(e => e.SeqNo).HasColumnName("SEQ_NO");
            });

            modelBuilder.Entity<Tbldetailsattendance>(entity =>
            {
                entity.HasKey(e => new { e.EmpId, e.AttDt });

                entity.ToTable("TBLDETAILSATTENDANCE");

                entity.Property(e => e.EmpId)
                    .HasColumnName("EMP_ID")
                    .HasMaxLength(20);

                entity.Property(e => e.AttDt)
                    .HasColumnName("ATT_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.AbsMn)
                    .HasColumnName("ABS_MN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AbsTm)
                    .HasColumnName("ABS_TM")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AttDy)
                    .HasColumnName("ATT_DY")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AttHr)
                    .HasColumnName("ATT_HR")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DepId)
                    .HasColumnName("DEP_ID")
                    .HasMaxLength(10);

                entity.Property(e => e.DofHr)
                    .HasColumnName("DOF_HR")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DofNs)
                    .HasColumnName("DOF_NS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DofOv).HasColumnName("DOF_OV");

                entity.Property(e => e.EarMn)
                    .HasColumnName("EAR_MN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EarTm)
                    .HasColumnName("EAR_TM")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EmpI1)
                    .HasColumnName("EMP_I1")
                    .HasMaxLength(20);

                entity.Property(e => e.HolHr)
                    .HasColumnName("HOL_HR")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HolNs)
                    .HasColumnName("HOL_NS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LatMn)
                    .HasColumnName("LAT_MN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LatTm)
                    .HasColumnName("LAT_TM")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LeaH1)
                    .HasColumnName("LEA_H1")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LeaH2)
                    .HasColumnName("LEA_H2")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LeaH3)
                    .HasColumnName("LEA_H3")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LeaI1)
                    .HasColumnName("LEA_I1")
                    .HasMaxLength(10);

                entity.Property(e => e.LeaI2)
                    .HasColumnName("LEA_I2")
                    .HasMaxLength(10);

                entity.Property(e => e.LeaI3)
                    .HasColumnName("LEA_I3")
                    .HasMaxLength(10);

                entity.Property(e => e.LocB1).HasColumnName("LOC_B1");

                entity.Property(e => e.LocBt).HasColumnName("LOC_BT");

                entity.Property(e => e.NigDy)
                    .HasColumnName("NIG_DY")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NigHr)
                    .HasColumnName("NIG_HR")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NigOt)
                    .HasColumnName("NIG_OT")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NigTm)
                    .HasColumnName("NIG_TM")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NotD1)
                    .HasColumnName("NOT_D1")
                    .HasMaxLength(500);

                entity.Property(e => e.NotDr)
                    .HasColumnName("NOT_DR")
                    .HasMaxLength(500);

                entity.Property(e => e.NotOr)
                    .HasColumnName("NOT_OR")
                    .HasMaxLength(500);

                entity.Property(e => e.Off01).HasColumnName("OFF_01");

                entity.Property(e => e.Off02).HasColumnName("OFF_02");

                entity.Property(e => e.Off03).HasColumnName("OFF_03");

                entity.Property(e => e.Off04).HasColumnName("OFF_04");

                entity.Property(e => e.Off05).HasColumnName("OFF_05");

                entity.Property(e => e.Onn01).HasColumnName("ONN_01");

                entity.Property(e => e.Onn02).HasColumnName("ONN_02");

                entity.Property(e => e.Onn03).HasColumnName("ONN_03");

                entity.Property(e => e.Onn04).HasColumnName("ONN_04");

                entity.Property(e => e.Onn05).HasColumnName("ONN_05");

                entity.Property(e => e.OtrHr).HasColumnName("OTR_HR");

                entity.Property(e => e.OttHr)
                    .HasColumnName("OTT_HR")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ShiId)
                    .HasColumnName("SHI_ID")
                    .HasMaxLength(20);

                entity.Property(e => e.UsrCk)
                    .HasColumnName("USR_CK")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Tbldetailsroster>(entity =>
            {
                entity.HasKey(e => new { e.ShiId, e.SeqN1 });

                entity.ToTable("TBLDETAILSROSTER");

                entity.Property(e => e.ShiId)
                    .HasColumnName("SHI_ID")
                    .HasMaxLength(20);

                entity.Property(e => e.SeqN1).HasColumnName("SEQ_N1");

                entity.Property(e => e.BltDt)
                    .HasColumnName("BLT_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.BltNm)
                    .HasColumnName("BLT_NM")
                    .HasMaxLength(50);

                entity.Property(e => e.LatBt).HasColumnName("LAT_BT");

                entity.Property(e => e.LstDt)
                    .HasColumnName("LST_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.LstNm)
                    .HasColumnName("LST_NM")
                    .HasMaxLength(50);

                entity.Property(e => e.ManIn).HasColumnName("MAN_IN");

                entity.Property(e => e.ManOu).HasColumnName("MAN_OU");

                entity.Property(e => e.MinSt).HasColumnName("MIN_ST");

                entity.Property(e => e.OffBt).HasColumnName("OFF_BT");

                entity.Property(e => e.OffRd)
                    .HasColumnName("OFF_RD")
                    .HasMaxLength(5);

                entity.Property(e => e.OffTm).HasColumnName("OFF_TM");

                entity.Property(e => e.OnnBt).HasColumnName("ONN_BT");

                entity.Property(e => e.OnnRd)
                    .HasColumnName("ONN_RD")
                    .HasMaxLength(5);

                entity.Property(e => e.OnnTm).HasColumnName("ONN_TM");

                entity.Property(e => e.SeqNo)
                    .HasColumnName("SEQ_NO")
                    .HasMaxLength(2);

                entity.Property(e => e.TypId)
                    .HasColumnName("TYP_ID")
                    .HasMaxLength(10);

                entity.Property(e => e.WrkHr).HasColumnName("WRK_HR");
            });

            modelBuilder.Entity<Tblemployee>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.ToTable("TBLEMPLOYEE");

                entity.Property(e => e.EmpId)
                    .HasColumnName("EMP_ID")
                    .HasMaxLength(20)
                    .ValueGeneratedNever();

                entity.Property(e => e.AccNm)
                    .HasColumnName("ACC_NM")
                    .HasMaxLength(50);

                entity.Property(e => e.AccNo)
                    .HasColumnName("ACC_NO")
                    .HasMaxLength(20);

                entity.Property(e => e.AddD1)
                    .HasColumnName("ADD_D1")
                    .HasMaxLength(255);

                entity.Property(e => e.AddDr)
                    .HasColumnName("ADD_DR")
                    .HasMaxLength(255);

                entity.Property(e => e.AttBt)
                    .HasColumnName("ATT_BT")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BhxBt).HasColumnName("BHX_BT");

                entity.Property(e => e.BirDt)
                    .HasColumnName("BIR_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.BltDt)
                    .HasColumnName("BLT_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.BltNm)
                    .HasColumnName("BLT_NM")
                    .HasMaxLength(50);

                entity.Property(e => e.BnkNm)
                    .HasColumnName("BNK_NM")
                    .HasMaxLength(100);

                entity.Property(e => e.CitId)
                    .HasColumnName("CIT_ID")
                    .HasMaxLength(10);

                entity.Property(e => e.CouId)
                    .HasColumnName("COU_ID")
                    .HasMaxLength(10);

                entity.Property(e => e.CrdDt)
                    .HasColumnName("CRD_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CrdId)
                    .HasColumnName("CRD_ID")
                    .HasMaxLength(50);

                entity.Property(e => e.CrdLc)
                    .HasColumnName("CRD_LC")
                    .HasMaxLength(255);

                entity.Property(e => e.CrdNo)
                    .HasColumnName("CRD_NO")
                    .HasMaxLength(20);

                entity.Property(e => e.DelBt)
                    .HasColumnName("DEL_BT")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DepId)
                    .HasColumnName("DEP_ID")
                    .HasMaxLength(10);

                entity.Property(e => e.DirBt).HasColumnName("DIR_BT");

                entity.Property(e => e.EduId)
                    .HasColumnName("EDU_ID")
                    .HasMaxLength(10);

                entity.Property(e => e.EmpI1)
                    .HasColumnName("EMP_I1")
                    .HasMaxLength(20);

                entity.Property(e => e.EmpN1)
                    .HasColumnName("EMP_N1")
                    .HasMaxLength(50);

                entity.Property(e => e.EmpNm)
                    .HasColumnName("EMP_NM")
                    .HasMaxLength(50);

                entity.Property(e => e.FirDt)
                    .HasColumnName("FIR_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.GraId)
                    .HasColumnName("GRA_ID")
                    .HasMaxLength(10);

                entity.Property(e => e.GrpId)
                    .HasColumnName("GRP_ID")
                    .HasMaxLength(10);

                entity.Property(e => e.GrtId)
                    .HasColumnName("GRT_ID")
                    .HasMaxLength(10);

                entity.Property(e => e.InhDt)
                    .HasColumnName("INH_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.LckBt)
                    .HasColumnName("LCK_BT")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LevId)
                    .HasColumnName("LEV_ID")
                    .HasMaxLength(10);

                entity.Property(e => e.LstDt)
                    .HasColumnName("LST_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.LstNm)
                    .HasColumnName("LST_NM")
                    .HasMaxLength(50);

                entity.Property(e => e.MarBt).HasColumnName("MAR_BT");

                entity.Property(e => e.MeaBt).HasColumnName("MEA_BT");

                entity.Property(e => e.MstDr)
                    .HasColumnName("MST_DR")
                    .HasMaxLength(20);

                entity.Property(e => e.NatCo)
                    .HasColumnName("NAT_CO")
                    .HasMaxLength(50);

                entity.Property(e => e.NewBt)
                    .HasColumnName("NEW_BT")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PosId)
                    .HasColumnName("POS_ID")
                    .HasMaxLength(10);

                entity.Property(e => e.ProId)
                    .HasColumnName("PRO_ID")
                    .HasMaxLength(10);

                entity.Property(e => e.RacNm)
                    .HasColumnName("RAC_NM")
                    .HasMaxLength(50);

                entity.Property(e => e.RelDr)
                    .HasColumnName("REL_DR")
                    .HasMaxLength(50);

                entity.Property(e => e.RemD2)
                    .HasColumnName("REM_D2")
                    .HasMaxLength(255);

                entity.Property(e => e.RemDr)
                    .HasColumnName("REM_DR")
                    .HasMaxLength(255);

                entity.Property(e => e.SalBt)
                    .HasColumnName("SAL_BT")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SenDt)
                    .HasColumnName("SEN_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.SexBt).HasColumnName("SEX_BT");

                entity.Property(e => e.TelNo)
                    .HasColumnName("TEL_NO")
                    .HasMaxLength(50);

                entity.Property(e => e.TypId)
                    .HasColumnName("TYP_ID")
                    .HasMaxLength(10);

                entity.Property(e => e.VacBt)
                    .HasColumnName("VAC_BT")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Tblleave>(entity =>
            {
                entity.HasKey(e => e.SeqNo);

                entity.ToTable("TBLLEAVE");

                entity.Property(e => e.SeqNo)
                    .HasColumnName("SEQ_NO")
                    .ValueGeneratedNever();

                entity.Property(e => e.BltDt)
                    .HasColumnName("BLT_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.BltNm)
                    .HasColumnName("BLT_NM")
                    .HasMaxLength(50);

                entity.Property(e => e.DayBt).HasColumnName("DAY_BT");

                entity.Property(e => e.DayTt).HasColumnName("DAY_TT");

                entity.Property(e => e.EmpId)
                    .HasColumnName("EMP_ID")
                    .HasMaxLength(20);

                entity.Property(e => e.EndDt)
                    .HasColumnName("END_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndTm).HasColumnName("END_TM");

                entity.Property(e => e.HouDy).HasColumnName("HOU_DY");

                entity.Property(e => e.HouTt).HasColumnName("HOU_TT");

                entity.Property(e => e.LeaId)
                    .HasColumnName("LEA_ID")
                    .HasMaxLength(3);

                entity.Property(e => e.LstDt)
                    .HasColumnName("LST_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.LstNm)
                    .HasColumnName("LST_NM")
                    .HasMaxLength(50);

                entity.Property(e => e.NotDr)
                    .HasColumnName("NOT_DR")
                    .HasMaxLength(100);

                entity.Property(e => e.StrDt)
                    .HasColumnName("STR_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.StrTm).HasColumnName("STR_TM");
            });

            modelBuilder.Entity<Tblmonthattendance>(entity =>
            {
                entity.HasKey(e => new { e.EmpId, e.YyyMm, e.SeqNo });

                entity.ToTable("TBLMONTHATTENDANCE");

                entity.Property(e => e.EmpId)
                    .HasColumnName("EMP_ID")
                    .HasMaxLength(20);

                entity.Property(e => e.YyyMm)
                    .HasColumnName("YYY_MM")
                    .HasMaxLength(6);

                entity.Property(e => e.SeqNo).HasColumnName("SEQ_NO");

                entity.Property(e => e.AbsMn)
                    .HasColumnName("ABS_MN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AbsTm)
                    .HasColumnName("ABS_TM")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AttDy)
                    .HasColumnName("ATT_DY")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AttHr)
                    .HasColumnName("ATT_HR")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BltDt)
                    .HasColumnName("BLT_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.BltNm)
                    .HasColumnName("BLT_NM")
                    .HasMaxLength(50);

                entity.Property(e => e.BosAm)
                    .HasColumnName("BOS_AM")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DepI1)
                    .HasColumnName("DEP_I1")
                    .HasMaxLength(50);

                entity.Property(e => e.DofHr)
                    .HasColumnName("DOF_HR")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DofNs)
                    .HasColumnName("DOF_NS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DofOv).HasColumnName("DOF_OV");

                entity.Property(e => e.EarMn)
                    .HasColumnName("EAR_MN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EarTm)
                    .HasColumnName("EAR_TM")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EmpDw)
                    .HasColumnName("EMP_DW")
                    .HasMaxLength(20);

                entity.Property(e => e.FinAm)
                    .HasColumnName("FIN_AM")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HolHr)
                    .HasColumnName("HOL_HR")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HolNs)
                    .HasColumnName("HOL_NS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HolTt)
                    .HasColumnName("HOL_TT")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LatMn)
                    .HasColumnName("LAT_MN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LatTm)
                    .HasColumnName("LAT_TM")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lea001)
                    .HasColumnName("LEA_001")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lea002)
                    .HasColumnName("LEA_002")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lea003)
                    .HasColumnName("LEA_003")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lea004)
                    .HasColumnName("LEA_004")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lea005)
                    .HasColumnName("LEA_005")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lea006)
                    .HasColumnName("LEA_006")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lea007)
                    .HasColumnName("LEA_007")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lea008)
                    .HasColumnName("LEA_008")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lea009)
                    .HasColumnName("LEA_009")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lea010)
                    .HasColumnName("LEA_010")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lea011)
                    .HasColumnName("LEA_011")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lea012)
                    .HasColumnName("LEA_012")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lea013)
                    .HasColumnName("LEA_013")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lea014)
                    .HasColumnName("LEA_014")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lea015)
                    .HasColumnName("LEA_015")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lea016)
                    .HasColumnName("LEA_016")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lea017)
                    .HasColumnName("LEA_017")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lea018)
                    .HasColumnName("LEA_018")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lea019)
                    .HasColumnName("LEA_019")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lea020)
                    .HasColumnName("LEA_020")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LeaQt)
                    .HasColumnName("LEA_QT")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LocB1).HasColumnName("LOC_B1");

                entity.Property(e => e.LstDt)
                    .HasColumnName("LST_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.LstNm)
                    .HasColumnName("LST_NM")
                    .HasMaxLength(50);

                entity.Property(e => e.NigDy)
                    .HasColumnName("NIG_DY")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NigHr)
                    .HasColumnName("NIG_HR")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NigOt)
                    .HasColumnName("NIG_OT")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NotDr)
                    .HasColumnName("NOT_DR")
                    .HasMaxLength(50);

                entity.Property(e => e.OtrHr)
                    .HasColumnName("OTR_HR")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OttHr)
                    .HasColumnName("OTT_HR")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OvoHr)
                    .HasColumnName("OVO_HR")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Tblmonthshift>(entity =>
            {
                entity.HasKey(e => new { e.EmpId, e.YyyMm });

                entity.ToTable("TBLMONTHSHIFT");

                entity.Property(e => e.EmpId)
                    .HasColumnName("EMP_ID")
                    .HasMaxLength(20);

                entity.Property(e => e.YyyMm)
                    .HasColumnName("YYY_MM")
                    .HasMaxLength(6);

                entity.Property(e => e.BltDt)
                    .HasColumnName("BLT_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.BltNm)
                    .HasColumnName("BLT_NM")
                    .HasMaxLength(50);

                entity.Property(e => e.Day01)
                    .HasColumnName("DAY_01")
                    .HasMaxLength(20);

                entity.Property(e => e.Day02)
                    .HasColumnName("DAY_02")
                    .HasMaxLength(20);

                entity.Property(e => e.Day03)
                    .HasColumnName("DAY_03")
                    .HasMaxLength(20);

                entity.Property(e => e.Day04)
                    .HasColumnName("DAY_04")
                    .HasMaxLength(20);

                entity.Property(e => e.Day05)
                    .HasColumnName("DAY_05")
                    .HasMaxLength(20);

                entity.Property(e => e.Day06)
                    .HasColumnName("DAY_06")
                    .HasMaxLength(20);

                entity.Property(e => e.Day07)
                    .HasColumnName("DAY_07")
                    .HasMaxLength(20);

                entity.Property(e => e.Day08)
                    .HasColumnName("DAY_08")
                    .HasMaxLength(20);

                entity.Property(e => e.Day09)
                    .HasColumnName("DAY_09")
                    .HasMaxLength(20);

                entity.Property(e => e.Day10)
                    .HasColumnName("DAY_10")
                    .HasMaxLength(20);

                entity.Property(e => e.Day11)
                    .HasColumnName("DAY_11")
                    .HasMaxLength(20);

                entity.Property(e => e.Day12)
                    .HasColumnName("DAY_12")
                    .HasMaxLength(20);

                entity.Property(e => e.Day13)
                    .HasColumnName("DAY_13")
                    .HasMaxLength(20);

                entity.Property(e => e.Day14)
                    .HasColumnName("DAY_14")
                    .HasMaxLength(20);

                entity.Property(e => e.Day15)
                    .HasColumnName("DAY_15")
                    .HasMaxLength(20);

                entity.Property(e => e.Day16)
                    .HasColumnName("DAY_16")
                    .HasMaxLength(20);

                entity.Property(e => e.Day17)
                    .HasColumnName("DAY_17")
                    .HasMaxLength(20);

                entity.Property(e => e.Day18)
                    .HasColumnName("DAY_18")
                    .HasMaxLength(20);

                entity.Property(e => e.Day19)
                    .HasColumnName("DAY_19")
                    .HasMaxLength(20);

                entity.Property(e => e.Day20)
                    .HasColumnName("DAY_20")
                    .HasMaxLength(20);

                entity.Property(e => e.Day21)
                    .HasColumnName("DAY_21")
                    .HasMaxLength(20);

                entity.Property(e => e.Day22)
                    .HasColumnName("DAY_22")
                    .HasMaxLength(20);

                entity.Property(e => e.Day23)
                    .HasColumnName("DAY_23")
                    .HasMaxLength(20);

                entity.Property(e => e.Day24)
                    .HasColumnName("DAY_24")
                    .HasMaxLength(20);

                entity.Property(e => e.Day25)
                    .HasColumnName("DAY_25")
                    .HasMaxLength(20);

                entity.Property(e => e.Day26)
                    .HasColumnName("DAY_26")
                    .HasMaxLength(20);

                entity.Property(e => e.Day27)
                    .HasColumnName("DAY_27")
                    .HasMaxLength(20);

                entity.Property(e => e.Day28)
                    .HasColumnName("DAY_28")
                    .HasMaxLength(20);

                entity.Property(e => e.Day29)
                    .HasColumnName("DAY_29")
                    .HasMaxLength(20);

                entity.Property(e => e.Day30)
                    .HasColumnName("DAY_30")
                    .HasMaxLength(20);

                entity.Property(e => e.Day31)
                    .HasColumnName("DAY_31")
                    .HasMaxLength(20);

                entity.Property(e => e.LstDt)
                    .HasColumnName("LST_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.LstNm)
                    .HasColumnName("LST_NM")
                    .HasMaxLength(50);
            });



            modelBuilder.Entity<Tblroster>(entity =>
            {
                entity.HasKey(e => e.ShiId);

                entity.ToTable("TBLROSTER");

                entity.Property(e => e.ShiId)
                    .HasColumnName("SHI_ID")
                    .HasMaxLength(20)
                    .ValueGeneratedNever();

                entity.Property(e => e.AddH1).HasColumnName("ADD_H1");

                entity.Property(e => e.AddH2).HasColumnName("ADD_H2");

                entity.Property(e => e.BltDt)
                    .HasColumnName("BLT_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.BltNm)
                    .HasColumnName("BLT_NM")
                    .HasMaxLength(50);

                entity.Property(e => e.ConH1).HasColumnName("CON_H1");

                entity.Property(e => e.ConH2).HasColumnName("CON_H2");

                entity.Property(e => e.LstDt)
                    .HasColumnName("LST_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.LstNm)
                    .HasColumnName("LST_NM")
                    .HasMaxLength(50);

                entity.Property(e => e.MaxHr).HasColumnName("MAX_HR");

                entity.Property(e => e.MinHr).HasColumnName("MIN_HR");

                entity.Property(e => e.NigSh).HasColumnName("NIG_SH");

                entity.Property(e => e.OffTm).HasColumnName("OFF_TM");

                entity.Property(e => e.OnnOt).HasColumnName("ONN_OT");

                entity.Property(e => e.OnnTm).HasColumnName("ONN_TM");

                entity.Property(e => e.ShiNm)
                    .HasColumnName("SHI_NM")
                    .HasMaxLength(50);

                entity.Property(e => e.Tim02).HasColumnName("TIM_02");
            });

            modelBuilder.Entity<Tblsalary>(entity =>
            {
                entity.HasKey(e => new { e.EmpId, e.SeqNo });

                entity.ToTable("TBLSALARY");

                entity.Property(e => e.EmpId)
                    .HasColumnName("EMP_ID")
                    .HasMaxLength(20);

                entity.Property(e => e.SeqNo).HasColumnName("SEQ_NO");

                entity.Property(e => e.BltDt)
                    .HasColumnName("BLT_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.BltNm)
                    .HasColumnName("BLT_NM")
                    .HasMaxLength(50);

                entity.Property(e => e.ChaDt)
                    .HasColumnName("CHA_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.DonAp).HasColumnName("DON_AP");

                entity.Property(e => e.Lcb).HasColumnName("LCB");

                entity.Property(e => e.LstDt)
                    .HasColumnName("LST_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.LstNm)
                    .HasColumnName("LST_NM")
                    .HasMaxLength(50);

                entity.Property(e => e.NotDr)
                    .HasColumnName("NOT_DR")
                    .HasMaxLength(50);

                entity.Property(e => e.ReaDr)
                    .HasColumnName("REA_DR")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Tbltypeleave>(entity =>
            {
                entity.HasKey(e => e.LeaId);

                entity.ToTable("TBLTYPELEAVE");

                entity.Property(e => e.LeaId)
                    .HasColumnName("LEA_ID")
                    .HasMaxLength(3)
                    .ValueGeneratedNever();

                entity.Property(e => e.ColNm)
                    .HasColumnName("COL_NM")
                    .HasMaxLength(50);

                entity.Property(e => e.DayMm).HasColumnName("DAY_MM");

                entity.Property(e => e.DayQt).HasColumnName("DAY_QT");

                entity.Property(e => e.DayTm).HasColumnName("DAY_TM");

                entity.Property(e => e.DayYy).HasColumnName("DAY_YY");

                entity.Property(e => e.HolBt).HasColumnName("HOL_BT");

                entity.Property(e => e.LeaNm)
                    .HasColumnName("LEA_NM")
                    .HasMaxLength(50);

                entity.Property(e => e.SalCk).HasColumnName("SAL_CK");

                entity.Property(e => e.SeqNo)
                    .HasColumnName("SEQ_NO")
                    .HasMaxLength(3);

                entity.Property(e => e.ShrNm)
                    .HasColumnName("SHR_NM")
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<Tbltypeshift>(entity =>
            {
                entity.HasKey(e => e.TypId);

                entity.ToTable("TBLTYPESHIFT");

                entity.Property(e => e.TypId)
                    .HasColumnName("TYP_ID")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.RouDr)
                    .HasColumnName("ROU_DR")
                    .HasMaxLength(5);

                entity.Property(e => e.TypCh)
                    .HasColumnName("TYP_CH")
                    .HasMaxLength(50);

                entity.Property(e => e.TypEn)
                    .HasColumnName("TYP_EN")
                    .HasMaxLength(50);

                entity.Property(e => e.TypNm)
                    .HasColumnName("TYP_NM")
                    .HasMaxLength(50);

                entity.Property(e => e.TypTt)
                    .HasColumnName("TYP_TT")
                    .HasMaxLength(50);

                entity.Property(e => e.TypVn)
                    .HasColumnName("TYP_VN")
                    .HasMaxLength(50);
            });
            modelBuilder.Entity<Tblcarddata>(entity =>
            {
                entity.HasKey(e => new { e.CrdDt, e.CrdTm, e.CrdNo });

                entity.ToTable("TBLCARDDATA");

                entity.Property(e => e.CrdDt)
                    .HasColumnName("CRD_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CrdTm).HasColumnName("CRD_TM");

                entity.Property(e => e.CrdNo)
                    .HasColumnName("CRD_NO")
                    .HasMaxLength(20);

                entity.Property(e => e.DatTm).HasColumnName("DAT_TM");

                entity.Property(e => e.EmpId)
                    .HasColumnName("EMP_ID")
                    .HasMaxLength(20);

                entity.Property(e => e.FilNm)
                    .HasColumnName("FIL_NM")
                    .HasMaxLength(100);

                entity.Property(e => e.ReaNo)
                    .HasColumnName("REA_NO")
                    .HasMaxLength(10);

                entity.Property(e => e.StaDr)
                    .HasColumnName("STA_DR")
                    .HasMaxLength(10);

                entity.Property(e => e.SwiDt)
                    .HasColumnName("SWI_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsrNm)
                    .HasColumnName("USR_NM")
                    .HasMaxLength(50);

                entity.Property(e => e.YsdBt).HasColumnName("YSD_BT");
            });
            modelBuilder.Entity<Tblpayroll>(entity =>
            {
                entity.HasKey(e => new { e.EmpId, e.YyyMm, e.SeqNo });

                entity.ToTable("TBLPAYROll");

                entity.Property(e => e.EmpId)
                    .HasColumnName("EMP_ID")
                    .HasMaxLength(20);

                entity.Property(e => e.YyyMm)
                    .HasColumnName("YYY_MM")
                    .HasMaxLength(6);

                entity.Property(e => e.SeqNo).HasColumnName("SEQ_NO");

                entity.Property(e => e.Bhtn)
                    .HasColumnName("BHTN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Bhxh)
                    .HasColumnName("BHXH")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Bhyt)
                    .HasColumnName("BHYT")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BltDt)
                    .HasColumnName("BLT_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.BltNm)
                    .HasColumnName("BLT_NM")
                    .HasMaxLength(20);

                entity.Property(e => e.CaCn)
                    .HasColumnName("CaCN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CaDem).HasDefaultValueSql("((0))");

                entity.Property(e => e.CaDemCn)
                    .HasColumnName("CaDemCN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CaNgay).HasDefaultValueSql("((0))");

                entity.Property(e => e.DepId)
                    .HasColumnName("DEP_ID")
                    .HasMaxLength(10);

                entity.Property(e => e.DoanPhi).HasDefaultValueSql("((0))");

                entity.Property(e => e.EmpDw)
                    .HasColumnName("EMP_DW")
                    .HasMaxLength(20);

                entity.Property(e => e.KhaoHach1).HasDefaultValueSql("((0))");
                

                entity.Property(e => e.KhaoHach2).HasDefaultValueSql("((0))");

                entity.Property(e => e.Lcb)
                    .HasColumnName("LCB")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LckBt).HasColumnName("LCK_BT");

                entity.Property(e => e.LstDt)
                    .HasColumnName("LST_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.LstNm)
                    .HasColumnName("LST_NM")
                    .HasMaxLength(20);

                entity.Property(e => e.LuongBhtn)
                    .HasColumnName("LuongBHTN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LuongBhxh)
                    .HasColumnName("LuongBHXH")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MucChucVu).HasDefaultValueSql("((0))");

                entity.Property(e => e.MucDocHai).HasDefaultValueSql("((0))");

                entity.Property(e => e.MucThamNien).HasDefaultValueSql("((0))");

                entity.Property(e => e.NgayLe).HasDefaultValueSql("((0))");

                entity.Property(e => e.PhepCoLuong).HasDefaultValueSql("((0))");

                entity.Property(e => e.PhepNam).HasDefaultValueSql("((0))");

                entity.Property(e => e.Tc)
                    .HasColumnName("TC")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Tccn)
                    .HasColumnName("TCCN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Tccndem)
                    .HasColumnName("TCCNDem")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Tcdem)
                    .HasColumnName("TCDem")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ThucLanh).HasDefaultValueSql("((0))");

                entity.Property(e => e.ThucLanhTron).HasDefaultValueSql("((0))");

                entity.Property(e => e.ThuongSanLuong).HasDefaultValueSql("((0))");

                entity.Property(e => e.TienCaCn)
                    .HasColumnName("TienCaCN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TienCaDem).HasDefaultValueSql("((0))");

                entity.Property(e => e.TienCaDemCn)
                    .HasColumnName("TienCaDemCN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TienCaNgay).HasDefaultValueSql("((0))");

                entity.Property(e => e.TienCom).HasDefaultValueSql("((0))");

                entity.Property(e => e.TienNgayLe).HasDefaultValueSql("((0))");

                entity.Property(e => e.TienPhepCoLuong).HasDefaultValueSql("((0))");

                entity.Property(e => e.TienPhepNam).HasDefaultValueSql("((0))");

                entity.Property(e => e.TienTc)
                    .HasColumnName("TienTC")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TienTccn)
                    .HasColumnName("TienTCCN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TienTccndem)
                    .HasColumnName("TienTCCNDem")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TienTcdem)
                    .HasColumnName("TienTCDem")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TienXe).HasDefaultValueSql("((0))");

                entity.Property(e => e.TongLcb)
                    .HasColumnName("TongLCB")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TongLuong).HasDefaultValueSql("((0))");

                entity.Property(e => e.TruKhac).HasDefaultValueSql("((0))");

                entity.Property(e => e.XepLoai)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Tblbookdetail>(entity =>
            {
                entity.HasKey(e => e.BokdetId);

                entity.ToTable("TBLBOOKDETAIL");

                entity.Property(e => e.BokdetId).HasColumnName("BOKDET_ID");

                entity.Property(e => e.BokId).HasColumnName("BOK_ID");

                entity.Property(e => e.FodId).HasColumnName("FOD_ID");

                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

                entity.HasOne(d => d.Bok)
                    .WithMany(p => p.Tblbookdetail)
                    .HasForeignKey(d => d.BokId)
                    .HasConstraintName("FK_TBLBOOKDETAIL_TBLBOOK");

                entity.HasOne(d => d.Fod)
                    .WithMany(p => p.Tblbookdetail)
                    .HasForeignKey(d => d.FodId)
                    .HasConstraintName("FK_TBLBOOKDETAIL_TBLFOOD");
            });

            modelBuilder.Entity<Tblbooking>(entity =>
            {
                entity.HasKey(e => e.BokId);

                entity.ToTable("TBLBOOKING");

                entity.Property(e => e.BokId)
                    .HasColumnName("BOK_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BokDate)
                    .HasColumnName("BOK_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.BokstaId).HasColumnName("BOKSTA_ID");

                entity.Property(e => e.BoktblDate)
                    .HasColumnName("BOKTBL_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.TbfodId).HasColumnName("TBFOD_ID");

                entity.Property(e => e.TotalPrice).HasColumnName("TOTAL_PRICE");

                entity.Property(e => e.UsLogin)
                    .HasColumnName("US_LOGIN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bok)
                    .WithOne(p => p.Tblbooking)
                    .HasForeignKey<Tblbooking>(d => d.BokId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBLBOOKING_TBLTABLEFOOD");

                entity.HasOne(d => d.Boksta)
                    .WithMany(p => p.Tblbooking)
                    .HasForeignKey(d => d.BokstaId)
                    .HasConstraintName("FK_TBLBOOKING_TBLBOOKINGSTATUS");

                entity.HasOne(d => d.UsLoginNavigation)
                    .WithMany(p => p.Tblbooking)
                    .HasForeignKey(d => d.UsLogin)
                    .HasConstraintName("FK_TBLBOOKING_TBLUSER");
            });

            modelBuilder.Entity<Tblbookingstatus>(entity =>
            {
                entity.HasKey(e => e.BokstaId);

                entity.ToTable("TBLBOOKINGSTATUS");

                entity.Property(e => e.BokstaId).HasColumnName("BOKSTA_ID");

                entity.Property(e => e.BokstaName)
                    .IsRequired()
                    .HasColumnName("BOKSTA_NAME")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Tblcomment>(entity =>
            {
                entity.HasKey(e => e.CmtId);

                entity.ToTable("TBLCOMMENT");

                entity.Property(e => e.CmtId).HasColumnName("CMT_ID");

                entity.Property(e => e.CmtContent)
                    .HasColumnName("CMT_CONTENT")
                    .HasMaxLength(400);

                entity.Property(e => e.Del).HasColumnName("DEL");

                entity.Property(e => e.FodId).HasColumnName("FOD_ID");

                entity.Property(e => e.Rate).HasColumnName("RATE");

                entity.Property(e => e.Time)
                    .HasColumnName("TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.Usercmt)
                    .HasColumnName("USERCMT")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Fod)
                    .WithMany(p => p.Tblcomment)
                    .HasForeignKey(d => d.FodId)
                    .HasConstraintName("FK_TBLCOMMENT_TBLFOOD");
            });

            modelBuilder.Entity<Tblfood>(entity =>
            {
                entity.HasKey(e => e.FodId);

                entity.ToTable("TBLFOOD");

                entity.Property(e => e.FodId).HasColumnName("FOD_ID");

                entity.Property(e => e.Del).HasColumnName("DEL");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(400);

                entity.Property(e => e.FodAvailable).HasColumnName("FOD_AVAILABLE");

                entity.Property(e => e.FodName)
                    .HasColumnName("FOD_NAME")
                    .HasMaxLength(150);

                entity.Property(e => e.FodcaId).HasColumnName("FODCA_ID");

                entity.Property(e => e.Pic)
                    .HasColumnName("PIC")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("PRICE");

                entity.Property(e => e.Rate).HasColumnName("RATE");

                entity.HasOne(d => d.Fodca)
                    .WithMany(p => p.Tblfood)
                    .HasForeignKey(d => d.FodcaId)
                    .HasConstraintName("FK_TBLFOOD_TBLFOODCATEGORY");
            });

            modelBuilder.Entity<Tblfoodcategory>(entity =>
            {
                entity.HasKey(e => e.FodcaId);

                entity.ToTable("TBLFOODCATEGORY");

                entity.Property(e => e.FodcaId).HasColumnName("FODCA_ID");

                entity.Property(e => e.Del).HasColumnName("DEL");

                entity.Property(e => e.FodcaName)
                    .HasColumnName("FODCA_NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.Pic)
                    .HasColumnName("PIC")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tbltablecategory>(entity =>
            {
                entity.HasKey(e => e.TabcaId);

                entity.ToTable("TBLTABLECATEGORY");

                entity.Property(e => e.TabcaId).HasColumnName("TABCA_ID");

                entity.Property(e => e.Del).HasColumnName("DEL");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(400);

                entity.Property(e => e.Pic)
                    .HasColumnName("PIC")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TabcaName)
                    .HasColumnName("TABCA_NAME")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Tbltablefood>(entity =>
            {
                entity.HasKey(e => e.TbfodId);

                entity.ToTable("TBLTABLEFOOD");

                entity.Property(e => e.TbfodId).HasColumnName("TBFOD_ID");

                entity.Property(e => e.Del).HasColumnName("DEL");

                entity.Property(e => e.Pic)
                    .HasColumnName("PIC")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TabcaId).HasColumnName("TABCA_ID");

                entity.Property(e => e.TbfodAvi).HasColumnName("TBFOD_AVI");

                entity.Property(e => e.TbfodName)
                    .HasColumnName("TBFOD_NAME")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Tabca)
                    .WithMany(p => p.Tbltablefood)
                    .HasForeignKey(d => d.TabcaId)
                    .HasConstraintName("FK_TBLTABLEFOOD_TBLTABLECATEGORY");
            });

            modelBuilder.Entity<Tbluser>(entity =>
            {
                entity.HasKey(e => e.UsLogin);

                entity.ToTable("TBLUSER");

                entity.Property(e => e.UsLogin)
                    .HasColumnName("US_LOGIN")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Del).HasColumnName("DEL");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasColumnName("PASS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("PHONE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pic)
                    .HasColumnName("PIC")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UsId).HasColumnName("US_ID");

                entity.HasOne(d => d.Us)
                    .WithMany(p => p.Tbluser)
                    .HasForeignKey(d => d.UsId)
                    .HasConstraintName("PK_TBLUSER_TBLUSERTYPE");
            });

            modelBuilder.Entity<Tblusertype>(entity =>
            {
                entity.HasKey(e => e.UsId);

                entity.ToTable("TBLUSERTYPE");

                entity.Property(e => e.UsId).HasColumnName("US_ID");

                entity.Property(e => e.UsName)
                    .IsRequired()
                    .HasColumnName("US_NAME")
                    .HasMaxLength(50);
            });
        }
    }
}
