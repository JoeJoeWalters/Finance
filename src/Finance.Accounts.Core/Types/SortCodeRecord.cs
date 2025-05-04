namespace Finance.Accounts.Core.Types
{
    public class SortCodeRecord
    {
        public string GENERALSortingCode { get; set; } = string.Empty;
        public string GENERALBIC1 { get; set; } = string.Empty;
        public string GENERALBIC2 { get; set; } = string.Empty;
        public string GENERALSubBranchSuffix { get; set; } = string.Empty;
        public string GENERALShortBranchTitle { get; set; } = string.Empty;
        public string GENERALShortNameOwningBank { get; set; } = string.Empty;
        public string GENERALFullNameOwningBankLine1 { get; set; } = string.Empty;
        public string GENERALFullNameOwningBankLine2 { get; set; } = string.Empty;
        public string GENERALBankCodeOwningBank { get; set; } = string.Empty;
        public string GENERALNationalCentralBankCountryCode { get; set; } = string.Empty;
        public string GENERALSupervisoryBody { get; set; } = string.Empty;
        public string GENERALDeletedDate { get; set; } = string.Empty;
        public DateTime? GENERALDateofLastChange { get; set; }
        public string GENERALPrintIndicator { get; set; } = string.Empty;
        public string BACSStatus { get; set; } = string.Empty;
        public DateTime? BACSDateofLastChange { get; set; }
        public string BACSDateClosedInBACSClearing { get; set; } = string.Empty;
        public string BACSRedirectionFromFlag { get; set; } = string.Empty;
        public string BACSRedirectToSortcode { get; set; } = string.Empty;
        public string BACSSettlementBank { get; set; } = string.Empty;
        public string BACSSettlementSection { get; set; } = string.Empty;
        public string BACSSettlementSubSectionRALBankCodeOwningBank { get; set; } = string.Empty;
        public string BACSHandlingBank { get; set; } = string.Empty;
        public string BACSHandlingBankStream { get; set; } = string.Empty;
        public string BACSAccountsNumberedFlag { get; set; } = string.Empty;
        public string BACSDDIVoucherFlag { get; set; } = string.Empty;
        public string BACSTransactionsDisallowedDR { get; set; } = string.Empty;
        public string BACSTransactionsDisallowedCR { get; set; } = string.Empty;
        public string BACSTransactionsDisallowedCU { get; set; } = string.Empty;
        public string BACSTransactionsDisallowedPR { get; set; } = string.Empty;
        public string BACSTransactionsDisallowedBS { get; set; } = string.Empty;
        public string BACSTransactionsDisallowedDV { get; set; } = string.Empty;
        public string BACSTransactionsDisallowedAU { get; set; } = string.Empty;
        public string BACSTransactionsDisallowedSpare1 { get; set; } = string.Empty;
        public string BACSTransactionsDisallowedSpare2 { get; set; } = string.Empty;
        public string BACSTransactionsDisallowedSpare3 { get; set; } = string.Empty;
        public string BACSSpare1 { get; set; } = string.Empty;
        public string CHAPSSTERLINGReturnIndicator { get; set; } = string.Empty;
        public string CHAPSSTERLINGStatus { get; set; } = string.Empty;
        public DateTime? CHAPSSTERLINGEffectiveDateOfLastChange { get; set; }
        public DateTime? CHAPSSTERLINGDateClosed { get; set; }
        public string CHAPSSTERLINGSettlementMember { get; set; } = string.Empty;
        public string CHAPSSTERLINGRoutingBICField1 { get; set; } = string.Empty;
        public string CHAPSSTERLINGRoutingBICField2 { get; set; } = string.Empty;
        public string CHAPSEUROStatus { get; set; } = string.Empty;
        public DateTime? CHAPSEUROEffectiveDateOfLastChange { get; set; }
        public DateTime? CHAPSEURODateClosed { get; set; }
        public string CHAPSEURORoutingBICField1 { get; set; } = string.Empty;
        public string CHAPSEURORoutingBICField2 { get; set; } = string.Empty;
        public string CHAPSEUROSettlementMember { get; set; } = string.Empty;
        public string CHAPSEUROReturnIndicator { get; set; } = string.Empty;
        public string CHAPSEUROSwiftData { get; set; } = string.Empty;
        public string CHAPSEUROSpare1 { get; set; } = string.Empty;
        public string CCCCStatus { get; set; } = string.Empty;
        public DateTime? CCCCeffectiveDateofLastChange { get; set; }
        public string CCCCDateClosed { get; set; } = string.Empty;
        public string CCCCSettlementBank { get; set; } = string.Empty;
        public string CCCCDebitAgencySortingCode { get; set; } = string.Empty;
        public string CCCCReturnIndicator { get; set; } = string.Empty;
        public string CCCCGBNIIndicator { get; set; } = string.Empty;
        public string FASTStatus { get; set; } = string.Empty;
        public DateTime? FASTEffectiveDateofLastChange { get; set; }
        public DateTime? FASTDateClosed { get; set; }
        public string FASTRedirectFromFlag { get; set; } = string.Empty;
        public string FASTRedirectToSortingCode { get; set; } = string.Empty;
        public string FASTFPSSettlementBankConnectionType { get; set; } = string.Empty;
        public string FASTPadding { get; set; } = string.Empty;
        public string FASTFPSSettlementBankBankCode { get; set; } = string.Empty;
        public string FASTHandlingBankConnectionType { get; set; } = string.Empty;
        public string FASTPadding2 { get; set; } = string.Empty;
        public string FASTHandlingBankBankCode { get; set; } = string.Empty;
        public string FASTAccountsNumberedFlag { get; set; } = string.Empty;
        public string FASTAgencyType { get; set; } = string.Empty;
        public string FASTSpareField { get; set; } = string.Empty;
        public string PRINTBranchTypeIndicator { get; set; } = string.Empty;
        public string PRINTSortcodeOfMainBranch { get; set; } = string.Empty;
        public string PRINTMajorLocationName { get; set; } = string.Empty;
        public string PRINTMinorLocationName { get; set; } = string.Empty;
        public string PRINTBranchNameOrPlace { get; set; } = string.Empty;
        public string PRINTSecondEntryIndicator { get; set; } = string.Empty;
        public string PRINTBranchNameForSecondEntry { get; set; } = string.Empty;
        public string PRINTFullBranchTitlePart1 { get; set; } = string.Empty;
        public string PRINTFullBranchTitlePart2 { get; set; } = string.Empty;
        public string PRINTFullBranchTitlePart3 { get; set; } = string.Empty;
        public string PRINTAddressLine1 { get; set; } = string.Empty;
        public string PRINTAddressLine2 { get; set; } = string.Empty;
        public string PRINTAddressLine3 { get; set; } = string.Empty;
        public string PRINTAddressLine4 { get; set; } = string.Empty;
        public string PRINTTown { get; set; } = string.Empty;
        public string PRINTCounty { get; set; } = string.Empty;
        public string PRINTPostcodeField1 { get; set; } = string.Empty;
        public string PRINTPostcodeField2 { get; set; } = string.Empty;
        public string PRINTTelephoneArea { get; set; } = string.Empty;
        public string PRINTTelephoneNumber { get; set; } = string.Empty;
        public string PRINTTelephone2Area { get; set; } = string.Empty;
        public string PRINTTelephone2Number { get; set; } = string.Empty;
    }
}
