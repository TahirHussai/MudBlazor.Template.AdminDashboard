using System;

namespace AdminDashboard.Server
{
    public class JobDTO
    {
        public int JobID { get; set; }
		public string Req { get; set; }
		public bool Active { get; set; }
		public DateTime dtCreated { get; set; }
		public string CRJobTitle { get; set; }
		public string ClientJobTitle { get; set; }
		public int NumOpenings { get; set; }
		public int RemainingOpenings { get; set; }
		public string Responsibilities { get; set; }
		public string Requirements { get; set; }
		public int ReqDegree { get; set; }
		public int ReqMajor { get; set; }
		public string Education { get; set; }
		public string Miscellaneous { get; set; }
		public int CatID { get; set; }
		public int CatID2 { get; set; }
		public int SectorID { get; set; }
		public int RegionId { get; set; }
		public int SubRegionID { get; set; }
		public int CreatedByID { get; set; }
		public int AddressID { get; set; }
		public decimal DLR1 { get; set; }
		public decimal DLR2 { get; set; }
		public decimal DLR { get; set; }
		public decimal BR { get; set; }
		public decimal BR1 { get; set; }
		public decimal BR2 { get; set; }
		public decimal TargetRate { get; set; }
		public bool btClientAltRate { get; set; }
		public decimal MUR { get; set; }
		public decimal OTBR { get; set; }
		public decimal OTR { get; set; }
		public DateTime JobStartDT { get; set; }
		public DateTime JobEndDT { get; set; }
		public string Shift { get; set; }
		public DateTime FirstDayShiftStartTime { get; set; }
		public string ShiftStartTimeDT { get; set; }
		public string ShiftEndTimeDT { get; set; }
    }
}
