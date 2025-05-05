namespace Finance.Accounts.Core.Types
{
    public class SortCodeRecord
    {
        public string SortingCode { get; set; } = string.Empty;
        public string BIC1 { get; set; } = string.Empty;
        public string BIC2 { get; set; } = string.Empty;
        public string SubBranchSuffix { get; set; } = string.Empty;
        public string ShortBranchTitle { get; set; } = string.Empty;
        public string ShortNameOwningBank { get; set; } = string.Empty;
        public string FullNameOwningBankLine1 { get; set; } = string.Empty;
        public string FullNameOwningBankLine2 { get; set; } = string.Empty;
        public string BankCodeOwningBank { get; set; } = string.Empty;
        public string NationalCentralBankCountryCode { get; set; } = string.Empty;
        public string SupervisoryBody { get; set; } = string.Empty;
        public string DeletedDate { get; set; } = string.Empty;
        public DateTime? DateofLastChange { get; set; }
        public string PrintIndicator { get; set; } = string.Empty;

        public BACSRecord BACS { get; set; } = new BACSRecord();
        public CHAPSRecord SterlingCHAPS { get; set; } = new CHAPSRecord();
        public CHAPSRecord EUROCHAPS { get; set; } = new CHAPSRecord();
        public CCCCRecord CCCC { get; set; } = new CCCCRecord();
        public FASTRecord FAST { get; set; } = new FASTRecord();
        public PRINTRecord PRINT { get; set; } = new PRINTRecord();
    }
}
