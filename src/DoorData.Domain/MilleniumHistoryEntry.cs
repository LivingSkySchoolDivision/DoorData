using System;

namespace DoorData.Domain
{
    public class MilleniumHistoryEntry 
    {
        public int Id { get;set; }
        public DateTime TransactionTimestamp { get; set;  }
        public DateTime HistoryTimestamp { get; set;  }
        public string SiteName { get; set; }
        public int SiteId { get; set; }
        public int ActionId { get; set; }
        public string ActionDescription { get; set; }
        public string OutputColumnA { get; set; }
        public string OutputColumnB { get; set; }
        public string OutputcolumnC { get; set; }
        public string DeviceName { get; set; }
        public int UserCodeHi { get; set; }
        public int UserCodeLo { get; set; } 
        public string CodeDisplayText { get; set; }
        public string Operator { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public int ExtraId { get; set; }
        public string ExtraData { get; set; }
        public int PrevUserCodeHi { get; set; } 
        public int PrevUserCodeLo { get; set; }
        public DateTime ChangeTimestamp { get; set; }
        public int UserId { get; set ; }



    }
}
