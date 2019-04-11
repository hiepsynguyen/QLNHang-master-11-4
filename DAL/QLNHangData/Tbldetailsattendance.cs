using System;
using System.Collections.Generic;

namespace DAL.QLNHangData
{
    public partial class Tbldetailsattendance
    {
        public string EmpId { get; set; }
        public DateTime AttDt { get; set; }
        public string DepId { get; set; }
        public string EmpI1 { get; set; }
        public string ShiId { get; set; }
        public string NotOr { get; set; }
        public string NotDr { get; set; }
        public string NotD1 { get; set; }
        public int? NigTm { get; set; }
        public int? Onn01 { get; set; }
        public int? Off01 { get; set; }
        public int? Onn02 { get; set; }
        public int? Off02 { get; set; }
        public int? Onn03 { get; set; }
        public int? Off03 { get; set; }
        public int? Onn04 { get; set; }
        public int? Off04 { get; set; }
        public int? Onn05 { get; set; }
        public int? Off05 { get; set; }
        public double? AttHr { get; set; }
        public double? OttHr { get; set; }
        public double? LatMn { get; set; }
        public int? LatTm { get; set; }
        public double? EarMn { get; set; }
        public int? EarTm { get; set; }
        public double? AbsMn { get; set; }
        public int? AbsTm { get; set; }
        public double? AttDy { get; set; }
        public double? NigDy { get; set; }
        public bool? LocBt { get; set; }
        public bool? LocB1 { get; set; }
        public string UsrCk { get; set; }
        public double? NigHr { get; set; }
        public double? DofHr { get; set; }
        public double? DofNs { get; set; }
        public double? HolHr { get; set; }
        public double? HolNs { get; set; }
        public double? NigOt { get; set; }
        public string LeaI1 { get; set; }
        public double? LeaH1 { get; set; }
        public string LeaI2 { get; set; }
        public double? LeaH2 { get; set; }
        public string LeaI3 { get; set; }
        public double? LeaH3 { get; set; }
        public double? OtrHr { get; set; }
        public double? DofOv { get; set; }
        public bool? HienDien { get; set; }
    }
}
