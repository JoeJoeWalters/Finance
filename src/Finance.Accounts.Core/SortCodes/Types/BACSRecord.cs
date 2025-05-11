namespace Finance.Accounts.Core.SortCodes.Types
{
    public class BACSRecord
    {
        public string Status { get; set; } = string.Empty;
        public DateTime? DateofLastChange { get; set; }
        public string DateClosedInBACSClearing { get; set; } = string.Empty;
        public string RedirectionFromFlag { get; set; } = string.Empty;
        public string RedirectToSortcode { get; set; } = string.Empty;
        public string SettlementBank { get; set; } = string.Empty;
        public string SettlementSection { get; set; } = string.Empty;
        public string SettlementSubSectionRALBankCodeOwningBank { get; set; } = string.Empty;
        public string HandlingBank { get; set; } = string.Empty;
        public string HandlingBankStream { get; set; } = string.Empty;
        public string AccountsNumberedFlag { get; set; } = string.Empty;
        public string DDIVoucherFlag { get; set; } = string.Empty;
        public string TransactionsDisallowedDR { get; set; } = string.Empty;
        public string TransactionsDisallowedCR { get; set; } = string.Empty;
        public string TransactionsDisallowedCU { get; set; } = string.Empty;
        public string TransactionsDisallowedPR { get; set; } = string.Empty;
        public string TransactionsDisallowedBS { get; set; } = string.Empty;
        public string TransactionsDisallowedDV { get; set; } = string.Empty;
        public string TransactionsDisallowedAU { get; set; } = string.Empty;
        public string TransactionsDisallowedSpare1 { get; set; } = string.Empty;
        public string TransactionsDisallowedSpare2 { get; set; } = string.Empty;
        public string TransactionsDisallowedSpare3 { get; set; } = string.Empty;
        public string Spare1 { get; set; } = string.Empty;
    }
}
