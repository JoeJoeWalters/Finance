using CsvHelper.Configuration;

namespace Finance.Accounts.Core.Types
{
    internal class SortCodeRecordMap : ClassMap<SortCodeRecord>
    {
        public SortCodeRecordMap()
        {
            // Root Mappings
            Map(m => m.SortingCode).Name("GENERALSortingCode");
            Map(m => m.BIC1).Name("GENERALBIC1");
            Map(m => m.BIC2).Name("GENERALBIC2");
            Map(m => m.SubBranchSuffix).Name("GENERALSubBranchSuffix");
            Map(m => m.ShortBranchTitle).Name("GENERALShortBranchTitle");
            Map(m => m.ShortNameOwningBank).Name("GENERALShortNameOwningBank");
            Map(m => m.FullNameOwningBankLine1).Name("GENERALFullNameOwningBankLine1");
            Map(m => m.FullNameOwningBankLine2).Name("GENERALFullNameOwningBankLine2");
            Map(m => m.BankCodeOwningBank).Name("GENERALBankCodeOwningBank");
            Map(m => m.NationalCentralBankCountryCode).Name("GENERALNationalCentralBankCountryCode");
            Map(m => m.SupervisoryBody).Name("GENERALSupervisoryBody");
            Map(m => m.DeletedDate).Name("GENERALDeletedDate");
            Map(m => m.DateofLastChange).Name("GENERALDateofLastChange");
            Map(m => m.PrintIndicator).Name("GENERALPrintIndicator");

            // BACS Mappings
            Map(m => m.BACS.Status).Name("BACSStatus");
            Map(m => m.BACS.DateofLastChange).Name("BACSDateofLastChange");
            Map(m => m.BACS.DateClosedInBACSClearing).Name("BACSDateClosedInBACSClearing");
            Map(m => m.BACS.RedirectionFromFlag).Name("BACSRedirectionFromFlag");
            Map(m => m.BACS.RedirectToSortcode).Name("BACSRedirectToSortcode");
            Map(m => m.BACS.SettlementBank).Name("BACSSettlementBank");
            Map(m => m.BACS.SettlementSection).Name("BACSSettlementSection");
            Map(m => m.BACS.SettlementSubSectionRALBankCodeOwningBank).Name("BACSSettlementSubSectionRALBankCodeOwningBank");
            Map(m => m.BACS.HandlingBank).Name("BACSHandlingBank");
            Map(m => m.BACS.HandlingBankStream).Name("BACSHandlingBankStream");
            Map(m => m.BACS.AccountsNumberedFlag).Name("BACSAccountsNumberedFlag");
            Map(m => m.BACS.DDIVoucherFlag).Name("BACSDDIVoucherFlag");
            Map(m => m.BACS.TransactionsDisallowedDR).Name("BACSTransactionsDisallowedDR");
            Map(m => m.BACS.TransactionsDisallowedCR).Name("BACSTransactionsDisallowedCR");
            Map(m => m.BACS.TransactionsDisallowedCU).Name("BACSTransactionsDisallowedCU");
            Map(m => m.BACS.TransactionsDisallowedPR).Name("BACSTransactionsDisallowedPR");
            Map(m => m.BACS.TransactionsDisallowedBS).Name("BACSTransactionsDisallowedBS");
            Map(m => m.BACS.TransactionsDisallowedDV).Name("BACSTransactionsDisallowedDV");
            Map(m => m.BACS.TransactionsDisallowedAU).Name("BACSTransactionsDisallowedAU");
            Map(m => m.BACS.TransactionsDisallowedSpare1).Name("BACSTransactionsDisallowedSpare1");
            Map(m => m.BACS.TransactionsDisallowedSpare2).Name("BACSTransactionsDisallowedSpare2");
            Map(m => m.BACS.TransactionsDisallowedSpare3).Name("BACSTransactionsDisallowedSpare3");
            Map(m => m.BACS.Spare1).Name("BACSSpare1");

            // CHAPS Mappings
            Map(m => m.SterlingCHAPS.Status).Name("CHAPSSTERLINGStatus");
            Map(m => m.SterlingCHAPS.EffectiveDateOfLastChange).Name("CHAPSSTERLINGEffectiveDateOfLastChange");
            Map(m => m.SterlingCHAPS.DateClosed).Name("CHAPSSTERLINGDateClosed");
            Map(m => m.SterlingCHAPS.SettlementMember).Name("CHAPSSTERLINGSettlementMember");
            Map(m => m.SterlingCHAPS.RoutingBICField1).Name("CHAPSSTERLINGRoutingBICField1");
            Map(m => m.SterlingCHAPS.RoutingBICField2).Name("CHAPSSTERLINGRoutingBICField2");
            Map(m => m.SterlingCHAPS.ReturnIndicator).Name("CHAPSSTERLINGReturnIndicator");

            Map(m => m.EUROCHAPS.Status).Name("CHAPSEUROStatus");
            Map(m => m.EUROCHAPS.EffectiveDateOfLastChange).Name("CHAPSEUROEffectiveDateOfLastChange");
            Map(m => m.EUROCHAPS.DateClosed).Name("CHAPSEURODateClosed");
            Map(m => m.EUROCHAPS.RoutingBICField1).Name("CHAPSEURORoutingBICField1");
            Map(m => m.EUROCHAPS.RoutingBICField2).Name("CHAPSEURORoutingBICField2");
            Map(m => m.EUROCHAPS.SettlementMember).Name("CHAPSEUROSettlementMember");
            Map(m => m.EUROCHAPS.ReturnIndicator).Name("CHAPSEUROReturnIndicator");
            Map(m => m.EUROCHAPS.SwiftData).Name("CHAPSEUROSwiftData");
            Map(m => m.EUROCHAPS.Spare1).Name("CHAPSEUROSpare1");

            // CCCC Mappings
            Map(m => m.CCCC.Status).Name("CCCCStatus");
            Map(m => m.CCCC.EffectiveDateofLastChange).Name("CCCCeffectiveDateofLastChange");
            Map(m => m.CCCC.DateClosed).Name("CCCCDateClosed");
            Map(m => m.CCCC.SettlementBank).Name("CCCCSettlementBank");
            Map(m => m.CCCC.DebitAgencySortingCode).Name("CCCCDebitAgencySortingCode");
            Map(m => m.CCCC.ReturnIndicator).Name("CCCCReturnIndicator");
            Map(m => m.CCCC.GBNIIndicator).Name("CCCCGBNIIndicator");

            // FAST Mappings
            Map(m => m.FAST.Status).Name("FASTStatus");
            Map(m => m.FAST.EffectiveDateofLastChange).Name("FASTEffectiveDateofLastChange");
            Map(m => m.FAST.DateClosed).Name("FASTDateClosed");
            Map(m => m.FAST.RedirectFromFlag).Name("FASTRedirectFromFlag");
            Map(m => m.FAST.RedirectToSortingCode).Name("FASTRedirectToSortingCode");
            Map(m => m.FAST.FPSSettlementBankConnectionType).Name("FASTFPSSettlementBankConnectionType");
            Map(m => m.FAST.Padding).Name("FASTPadding");
            Map(m => m.FAST.FPSSettlementBankBankCode).Name("FASTFPSSettlementBankBankCode");
            Map(m => m.FAST.HandlingBankConnectionType).Name("FASTHandlingBankConnectionType");
            Map(m => m.FAST.Padding2).Name("FASTPadding2");
            Map(m => m.FAST.HandlingBankBankCode).Name("FASTHandlingBankBankCode");
            Map(m => m.FAST.AccountsNumberedFlag).Name("FASTAccountsNumberedFlag");
            Map(m => m.FAST.AgencyType).Name("FASTAgencyType");
            Map(m => m.FAST.SpareField).Name("FASTSpareField");

            // PRINT Mappings
            Map(m => m.PRINT.BranchTypeIndicator).Name("PRINTBranchTypeIndicator");
            Map(m => m.PRINT.SortcodeOfMainBranch).Name("PRINTSortcodeOfMainBranch");
            Map(m => m.PRINT.MajorLocationName).Name("PRINTMajorLocationName");
            Map(m => m.PRINT.MinorLocationName).Name("PRINTMinorLocationName");
            Map(m => m.PRINT.BranchNameOrPlace).Name("PRINTBranchNameOrPlace");
            Map(m => m.PRINT.SecondEntryIndicator).Name("PRINTSecondEntryIndicator");
            Map(m => m.PRINT.BranchNameForSecondEntry).Name("PRINTBranchNameForSecondEntry");
            Map(m => m.PRINT.FullBranchTitlePart1).Name("PRINTFullBranchTitlePart1");
            Map(m => m.PRINT.FullBranchTitlePart2).Name("PRINTFullBranchTitlePart2");
            Map(m => m.PRINT.FullBranchTitlePart3).Name("PRINTFullBranchTitlePart3");
            Map(m => m.PRINT.AddressLine1).Name("PRINTAddressLine1");
            Map(m => m.PRINT.AddressLine2).Name("PRINTAddressLine2");
            Map(m => m.PRINT.AddressLine3).Name("PRINTAddressLine3");
            Map(m => m.PRINT.AddressLine4).Name("PRINTAddressLine4");
            Map(m => m.PRINT.Town).Name("PRINTTown");
            Map(m => m.PRINT.County).Name("PRINTCounty");
            Map(m => m.PRINT.PostcodeField1).Name("PRINTPostcodeField1");
            Map(m => m.PRINT.PostcodeField2).Name("PRINTPostcodeField2");
            Map(m => m.PRINT.TelephoneArea).Name("PRINTTelephoneArea");
            Map(m => m.PRINT.TelephoneNumber).Name("PRINTTelephoneNumber");
            Map(m => m.PRINT.Telephone2Area).Name("PRINTTelephone2Area");
            Map(m => m.PRINT.Telephone2Number).Name("PRINTTelephone2Number");
        }
    }
}
