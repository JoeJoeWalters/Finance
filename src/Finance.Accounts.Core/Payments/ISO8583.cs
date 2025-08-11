namespace Finance.Core.Payments
{
    public class ISO8583
    {
        // Field 2: Primary Account Number (PAN)
        public string? PrimaryAccountNumber { get; set; }
        // Field 3: Processing Code
        public string? ProcessingCode { get; set; }
        // Field 4: Transaction Amount
        public decimal? TransactionAmount { get; set; }
        // Field 5: Settlement Amount
        public decimal? SettlementAmount { get; set; }
        // Field 6: Cardholder Billing Amount
        public decimal? CardholderBillingAmount { get; set; }
        // Field 7: Transmission Date & Time
        public DateTime? TransmissionDateTime { get; set; }
        // Field 8: Cardholder Billing Fee Amount
        public decimal? CardholderBillingFeeAmount { get; set; }
        // Field 9: Conversion Rate, Settlement
        public string? ConversionRateSettlement { get; set; }
        // Field 10: Conversion Rate, Cardholder Billing
        public string? ConversionRateCardholderBilling { get; set; }
        // Field 11: Systems Trace Audit Number
        public int? SystemsTraceAuditNumber { get; set; }
        // Field 12: Local Transaction Time
        public TimeSpan? LocalTransactionTime { get; set; }
        // Field 13: Local Transaction Date
        public DateTime? LocalTransactionDate { get; set; }
        // Field 14: Expiration Date (MMYY)
        public string? ExpirationDate { get; set; }
        // Field 15: Settlement Date
        public DateTime? SettlementDate { get; set; }
        // Field 16: Currency Conversion Date
        public DateTime? CurrencyConversionDate { get; set; }
        // Field 17: Capture Date
        public DateTime? CaptureDate { get; set; }
        // Field 18: Merchant Category Code
        public string? MerchantCategoryCode { get; set; }
        // Field 19: Acquiring Institution Country Code
        public string? AcquiringInstitutionCountryCode { get; set; }
        // Field 20: PAN Extended Country Code
        public string? PanExtendedCountryCode { get; set; }
        // Field 21: Forwarding Institution Country Code
        public string? ForwardingInstitutionCountryCode { get; set; }
        // Field 22: POS Entry Mode
        public string? PosEntryMode { get; set; }
        // Field 23: Card Sequence Number
        public string? CardSequenceNumber { get; set; }
        // Field 24: Network International Identifier (NII)
        public string? NetworkInternationalIdentifier { get; set; }
        // Field 25: POS Condition Code
        public string? PosConditionCode { get; set; }
        // Field 26: POS PIN Capture Code
        public string? PosPinCaptureCode { get; set; }
        // Field 27: Authorization Identification Response Length
        public string? AuthorizationIdentificationResponseLength { get; set; }
        // Field 28: Amount, Transaction Fee
        public decimal? TransactionFeeAmount { get; set; }
        // Field 29: Amount, Settlement Fee
        public decimal? SettlementFeeAmount { get; set; }
        // Field 30: Amount, Transaction Processing Fee
        public decimal? TransactionProcessingFeeAmount { get; set; }
        // Field 31: Amount, Settlement Processing Fee
        public decimal? SettlementProcessingFeeAmount { get; set; }
        // Field 32: Acquiring Institution Identification Code
        public string? AcquiringInstitutionIdCode { get; set; }
        // Field 33: Forwarding Institution Identification Code
        public string? ForwardingInstitutionIdCode { get; set; }
        // Field 34: Primary Account Number, Extended
        public string? PrimaryAccountNumberExtended { get; set; }
        // Field 35: Track 2 Data
        public string? Track2Data { get; set; }
        // Field 36: Track 3 Data
        public string? Track3Data { get; set; }
        // Field 37: Retrieval Reference Number
        public string? RetrievalReferenceNumber { get; set; }
        // Field 38: Authorization Identification Response
        public string? AuthorizationIdentificationResponse { get; set; }
        // Field 39: Response Code
        public string? ResponseCode { get; set; }
        // Field 40: Service Restriction Code
        public string? ServiceRestrictionCode { get; set; }
        // Field 41: Card Acceptor Terminal ID
        public string? CardAcceptorTerminalId { get; set; }
        // Field 42: Card Acceptor ID Code
        public string? CardAcceptorIdCode { get; set; }
        // Field 43: Card Acceptor Name/Location
        public string? CardAcceptorNameLocation { get; set; }
        // Field 44: Additional Response Data
        public string? AdditionalResponseData { get; set; }
        // Field 45: Track 1 Data
        public string? Track1Data { get; set; }
        // Field 46: Additional Data - ISO
        public string? AdditionalDataIso { get; set; }
        // Field 47: Additional Data - National
        public string? AdditionalDataNational { get; set; }
        // Field 48: Additional Data - Private
        public string? AdditionalDataPrivate { get; set; }
        // Field 49: Currency Code, Transaction
        public string? CurrencyCodeTransaction { get; set; }
        // Field 50: Currency Code, Settlement
        public string? CurrencyCodeSettlement { get; set; }
        // Field 51: Currency Code, Cardholder Billing
        public string? CurrencyCodeCardholderBilling { get; set; }
        // Field 52: PIN Data
        public string? PinData { get; set; }
        // Field 53: Security Related Control Information
        public string? SecurityRelatedControlInformation { get; set; }
        // Field 54: Additional Amounts
        public string? AdditionalAmounts { get; set; }
        // Field 55: ICC System Related Data
        public string? IccSystemRelatedData { get; set; }
        // Field 56: Reserved ISO
        public string? ReservedIso { get; set; }
        // Field 57: Reserved National
        public string? ReservedNational { get; set; }
        // Field 58: Reserved National
        public string? ReservedNational2 { get; set; }
        // Field 59: Reserved National
        public string? ReservedNational3 { get; set; }
        // Field 60: Reserved Private
        public string? ReservedPrivate { get; set; }
        // Field 61: Reserved Private
        public string? ReservedPrivate2 { get; set; }
        // Field 62: Reserved Private
        public string? ReservedPrivate3 { get; set; }
        // Field 63: Reserved Private
        public string? ReservedPrivate4 { get; set; }
        // Field 64: Message Authentication Code (MAC)
        public string? MessageAuthenticationCode { get; set; }
        // Field 65: Settlement Code
        public string? SettlementCode { get; set; }
        // Field 66: Extended Payment Code
        public string? ExtendedPaymentCode { get; set; }
        // Field 67: Receiving Institution Country Code
        public string? ReceivingInstitutionCountryCode { get; set; }
        // Field 68: Settlement Institution Country Code
        public string? SettlementInstitutionCountryCode { get; set; }
        // Field 69: Network Management Information Code
        public string? NetworkManagementInformationCode { get; set; }
        // Field 70: Message Number
        public string? MessageNumber { get; set; }
        // Field 71: Message Number (Last)
        public string? MessageNumberLast { get; set; }
        // Field 72: Data Record
        public string? DataRecord { get; set; }
        // Field 73: Date, Action
        public DateTime? DateAction { get; set; }
        // Field 74: Credits, Number
        public int? CreditsNumber { get; set; }
        // Field 75: Credits, Reversal Number
        public int? CreditsReversalNumber { get; set; }
        // Field 76: Debits, Number
        public int? DebitsNumber { get; set; }
        // Field 77: Debits, Reversal Number
        public int? DebitsReversalNumber { get; set; }
        // Field 78: Transfer Number
        public int? TransferNumber { get; set; }
        // Field 79: Transfer Reversal Number
        public int? TransferReversalNumber { get; set; }
        // Field 80: Inquiry Number
        public int? InquiryNumber { get; set; }
        // Field 81: Authorization Number
        public int? AuthorizationNumber { get; set; }
        // Field 82: Credits, Processing Fee Amount
        public decimal? CreditsProcessingFeeAmount { get; set; }
        // Field 83: Credits, Transaction Fee Amount
        public decimal? CreditsTransactionFeeAmount { get; set; }
        // Field 84: Debits, Processing Fee Amount
        public decimal? DebitsProcessingFeeAmount { get; set; }
        // Field 85: Debits, Transaction Fee Amount
        public decimal? DebitsTransactionFeeAmount { get; set; }
        // Field 86: Credits, Amount
        public decimal? CreditsAmount { get; set; }
        // Field 87: Debits, Amount
        public decimal? DebitsAmount { get; set; }
        // Field 88: Credits, Reversal Amount
        public decimal? CreditsReversalAmount { get; set; }
        // Field 89: Debits, Reversal Amount
        public decimal? DebitsReversalAmount { get; set; }
        // Field 90: Original Data Elements
        public string? OriginalDataElements { get; set; }
        // Field 91: File Update Code
        public string? FileUpdateCode { get; set; }
        // Field 92: File Security Code
        public string? FileSecurityCode { get; set; }
        // Field 93: Response Indicator
        public string? ResponseIndicator { get; set; }
        // Field 94: Service Indicator
        public string? ServiceIndicator { get; set; }
        // Field 95: Replacement Amounts
        public string? ReplacementAmounts { get; set; }
        // Field 96: Message Security Code
        public string? MessageSecurityCode { get; set; }
        // Field 97: Amount, Net Settlement
        public decimal? NetSettlementAmount { get; set; }
        // Field 98: Payee
        public string? Payee { get; set; }
        // Field 99: Settlement Institution Identification Code
        public string? SettlementInstitutionIdCode { get; set; }
        // Field 100: Receiving Institution Identification Code
        public string? ReceivingInstitutionIdCode { get; set; }
        // Field 101: File Name
        public string? FileName { get; set; }
        // Field 102: Account Identification 1
        public string? AccountIdentification1 { get; set; }
        // Field 103: Account Identification 2
        public string? AccountIdentification2 { get; set; }
        // Field 104: Transaction Description
        public string? TransactionDescription { get; set; }
        // Field 105: Reserved ISO
        public string? ReservedIso2 { get; set; }
        // Field 106: Reserved ISO
        public string? ReservedIso3 { get; set; }
        // Field 107: Reserved ISO
        public string? ReservedIso4 { get; set; }
        // Field 108: Reserved ISO
        public string? ReservedIso5 { get; set; }
        // Field 109: Reserved ISO
        public string? ReservedIso6 { get; set; }
        // Field 110: Reserved ISO
        public string? ReservedIso7 { get; set; }
        // Field 111: Reserved ISO
        public string? ReservedIso8 { get; set; }
        // Field 112: Reserved National
        public string? ReservedNational4 { get; set; }
        // Field 113: Reserved National
        public string? ReservedNational5 { get; set; }
        // Field 114: Reserved National
        public string? ReservedNational6 { get; set; }
        // Field 115: Reserved National
        public string? ReservedNational7 { get; set; }
        // Field 116: Reserved National
        public string? ReservedNational8 { get; set; }
        // Field 117: Reserved National
        public string? ReservedNational9 { get; set; }
        // Field 118: Reserved National
        public string? ReservedNational10 { get; set; }
        // Field 119: Reserved National
        public string? ReservedNational11 { get; set; }
        // Field 120: Reserved Private
        public string? ReservedPrivate5 { get; set; }
        // Field 121: Reserved Private
        public string? ReservedPrivate6 { get; set; }
        // Field 122: Reserved Private
        public string? ReservedPrivate7 { get; set; }
        // Field 123: Reserved Private
        public string? ReservedPrivate8 { get; set; }
        // Field 124: Reserved Private
        public string? ReservedPrivate9 { get; set; }
        // Field 125: Reserved Private
        public string? ReservedPrivate10 { get; set; }
        // Field 126: Reserved Private
        public string? ReservedPrivate11 { get; set; }
        // Field 127: Reserved Private
        public string? ReservedPrivate12 { get; set; }
        // Field 128: Message Authentication Code (MAC)
        public string? MessageAuthenticationCode2 { get; set; }

        public ISO8583() { }
    }
}
