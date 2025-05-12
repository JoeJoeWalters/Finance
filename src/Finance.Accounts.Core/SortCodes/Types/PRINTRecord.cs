namespace Finance.Core.SortCodes.Types
{
    public class PRINTRecord
    {
        public string BranchTypeIndicator { get; set; } = string.Empty;
        public string SortcodeOfMainBranch { get; set; } = string.Empty;
        public string MajorLocationName { get; set; } = string.Empty;
        public string MinorLocationName { get; set; } = string.Empty;
        public string BranchNameOrPlace { get; set; } = string.Empty;
        public string SecondEntryIndicator { get; set; } = string.Empty;
        public string BranchNameForSecondEntry { get; set; } = string.Empty;
        public string FullBranchTitlePart1 { get; set; } = string.Empty;
        public string FullBranchTitlePart2 { get; set; } = string.Empty;
        public string FullBranchTitlePart3 { get; set; } = string.Empty;
        public string AddressLine1 { get; set; } = string.Empty;
        public string AddressLine2 { get; set; } = string.Empty;
        public string AddressLine3 { get; set; } = string.Empty;
        public string AddressLine4 { get; set; } = string.Empty;
        public string Town { get; set; } = string.Empty;
        public string County { get; set; } = string.Empty;
        public string PostcodeField1 { get; set; } = string.Empty;
        public string PostcodeField2 { get; set; } = string.Empty;
        public string TelephoneArea { get; set; } = string.Empty;
        public string TelephoneNumber { get; set; } = string.Empty;
        public string Telephone2Area { get; set; } = string.Empty;
        public string Telephone2Number { get; set; } = string.Empty;
    }
}
