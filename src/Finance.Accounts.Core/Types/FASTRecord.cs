namespace Finance.Accounts.Core.Types
{
    public class FASTRecord
    {
        public string Status { get; set; } = string.Empty;
        public DateTime? EffectiveDateofLastChange { get; set; }
        public DateTime? DateClosed { get; set; }
        public string RedirectFromFlag { get; set; } = string.Empty;
        public string RedirectToSortingCode { get; set; } = string.Empty;
        public string FPSSettlementBankConnectionType { get; set; } = string.Empty;
        public string Padding { get; set; } = string.Empty;
        public string FPSSettlementBankBankCode { get; set; } = string.Empty;
        public string HandlingBankConnectionType { get; set; } = string.Empty;
        public string Padding2 { get; set; } = string.Empty;
        public string HandlingBankBankCode { get; set; } = string.Empty;
        public string AccountsNumberedFlag { get; set; } = string.Empty;
        public string AgencyType { get; set; } = string.Empty;
        public string SpareField { get; set; } = string.Empty;
    }

}
