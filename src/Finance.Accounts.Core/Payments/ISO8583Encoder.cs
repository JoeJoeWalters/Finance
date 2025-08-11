using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Finance.Core.Payments
{
    public class ISO8583Encoder
    {
        // 1. Build bitmap (128 bits for full ISO 8583)
        private bool[] bitmap;
        private Dictionary<int, string> fieldValues;

        public ISO8583Encoder() 
        {
            bitmap = new bool[128];
            fieldValues = new Dictionary<int, string>();            
        }

        private void SetField(int field, string? value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                bitmap[field - 1] = true;
                fieldValues[field] = value;
            }
        }

        private void SetField(int field, decimal? value, int length)
        {
            if (value.HasValue)
            {
                bitmap[field - 1] = true;
                fieldValues[field] = value.Value.ToString("F0").PadLeft(length, '0');
            }
        }

        private void SetField(int field, int? value, int length)
        {
            if (value.HasValue)
            {
                bitmap[field - 1] = true;
                fieldValues[field] = value.Value.ToString().PadLeft(length, '0');
            }
        }

        private void SetField(int field, DateTime? value, string format)
        {
            if (value.HasValue)
            {
                bitmap[field - 1] = true;
                fieldValues[field] = value.Value.ToString(format, CultureInfo.InvariantCulture);
            }
        }

        private void SetField(int field, TimeSpan? value, string format)
        {
            if (value.HasValue)
            {
                bitmap[field - 1] = true;
                fieldValues[field] = value.Value.ToString(format, CultureInfo.InvariantCulture);
            }
        }

        // Helper for LLVAR encoding (2-digit length + value)
        private static string? EncodeLLVAR(string? value)
        {
            if (string.IsNullOrEmpty(value)) return null;
            return value.Length.ToString("D2") + value;
        }

        // Helper for LLLVAR encoding (3-digit length + value)
        private static string? EncodeLLLVAR(string? value)
        {
            if (string.IsNullOrEmpty(value)) return null;
            return value.Length.ToString("D3") + value;
        }

        // Example: MTI is required, pass as argument
        public string Encode(ISO8583 fields, string mti)
        {
            // 2. Set all fields (add more as needed)
            SetField(2, EncodeLLVAR(fields.PrimaryAccountNumber));
            SetField(3, fields.ProcessingCode);
            SetField(4, fields.TransactionAmount, 12);
            SetField(5, fields.SettlementAmount, 12);
            SetField(6, fields.CardholderBillingAmount, 12);
            SetField(7, fields.TransmissionDateTime, "MMddHHmmss");
            SetField(8, fields.CardholderBillingFeeAmount, 8);
            SetField(9, fields.ConversionRateSettlement);
            SetField(10, fields.ConversionRateCardholderBilling);
            SetField(11, fields.SystemsTraceAuditNumber, 6);
            SetField(12, fields.LocalTransactionTime, "hhmmss");
            SetField(13, fields.LocalTransactionDate, "MMdd");
            SetField(14, fields.ExpirationDate);
            SetField(15, fields.SettlementDate, "MMdd");
            SetField(16, fields.CurrencyConversionDate, "MMdd");
            SetField(17, fields.CaptureDate, "MMdd");
            SetField(18, fields.MerchantCategoryCode);
            SetField(19, fields.AcquiringInstitutionCountryCode);
            SetField(20, fields.PanExtendedCountryCode);
            SetField(21, fields.ForwardingInstitutionCountryCode);
            SetField(22, fields.PosEntryMode);
            SetField(23, fields.CardSequenceNumber);
            SetField(24, fields.NetworkInternationalIdentifier);
            SetField(25, fields.PosConditionCode);
            SetField(26, fields.PosPinCaptureCode);
            SetField(27, fields.AuthorizationIdentificationResponseLength);
            SetField(28, fields.TransactionFeeAmount, 9);
            SetField(29, fields.SettlementFeeAmount, 9);
            SetField(30, fields.TransactionProcessingFeeAmount, 9);
            SetField(31, fields.SettlementProcessingFeeAmount, 9);
            SetField(32, EncodeLLVAR(fields.AcquiringInstitutionIdCode));
            SetField(33, EncodeLLVAR(fields.ForwardingInstitutionIdCode));
            SetField(34, EncodeLLVAR(fields.PrimaryAccountNumberExtended));
            SetField(35, EncodeLLVAR(fields.Track2Data));
            SetField(36, EncodeLLLVAR(fields.Track3Data));
            SetField(37, fields.RetrievalReferenceNumber);
            SetField(38, fields.AuthorizationIdentificationResponse);
            SetField(39, fields.ResponseCode);
            SetField(40, fields.ServiceRestrictionCode);
            SetField(41, fields.CardAcceptorTerminalId);
            SetField(42, fields.CardAcceptorIdCode);
            SetField(43, fields.CardAcceptorNameLocation);
            SetField(44, EncodeLLVAR(fields.AdditionalResponseData));
            SetField(45, EncodeLLVAR(fields.Track1Data));
            SetField(46, EncodeLLLVAR(fields.AdditionalDataIso));
            SetField(47, EncodeLLLVAR(fields.AdditionalDataNational));
            SetField(48, EncodeLLLVAR(fields.AdditionalDataPrivate));
            SetField(49, fields.CurrencyCodeTransaction);
            SetField(50, fields.CurrencyCodeSettlement);
            SetField(51, fields.CurrencyCodeCardholderBilling);
            SetField(52, fields.PinData);
            SetField(53, fields.SecurityRelatedControlInformation);
            SetField(54, EncodeLLLVAR(fields.AdditionalAmounts));
            SetField(55, EncodeLLLVAR(fields.IccSystemRelatedData));
            SetField(56, fields.ReservedIso);
            SetField(57, fields.ReservedNational);
            SetField(58, fields.ReservedNational2);
            SetField(59, fields.ReservedNational3);
            SetField(60, fields.ReservedPrivate);
            SetField(61, fields.ReservedPrivate2);
            SetField(62, fields.ReservedPrivate3);
            SetField(63, fields.ReservedPrivate4);
            SetField(64, fields.MessageAuthenticationCode);
            SetField(65, fields.SettlementCode);
            SetField(66, fields.ExtendedPaymentCode);
            SetField(67, fields.ReceivingInstitutionCountryCode);
            SetField(68, fields.SettlementInstitutionCountryCode);
            SetField(69, fields.NetworkManagementInformationCode);
            SetField(70, fields.MessageNumber);
            SetField(71, fields.MessageNumberLast);
            SetField(72, fields.DataRecord);
            SetField(73, fields.DateAction, "MMdd");
            SetField(74, fields.CreditsNumber, 10);
            SetField(75, fields.CreditsReversalNumber, 10);
            SetField(76, fields.DebitsNumber, 10);
            SetField(77, fields.DebitsReversalNumber, 10);
            SetField(78, fields.TransferNumber, 10);
            SetField(79, fields.TransferReversalNumber, 10);
            SetField(80, fields.InquiryNumber, 10);
            SetField(81, fields.AuthorizationNumber, 10);
            SetField(82, fields.CreditsProcessingFeeAmount, 12);
            SetField(83, fields.CreditsTransactionFeeAmount, 12);
            SetField(84, fields.DebitsProcessingFeeAmount, 12);
            SetField(85, fields.DebitsTransactionFeeAmount, 12);
            SetField(86, fields.CreditsAmount, 16);
            SetField(87, fields.DebitsAmount, 16);
            SetField(88, fields.CreditsReversalAmount, 16);
            SetField(89, fields.DebitsReversalAmount, 16);
            SetField(90, fields.OriginalDataElements);
            SetField(91, fields.FileUpdateCode);
            SetField(92, fields.FileSecurityCode);
            SetField(93, fields.ResponseIndicator);
            SetField(94, fields.ServiceIndicator);
            SetField(95, fields.ReplacementAmounts);
            SetField(96, fields.MessageSecurityCode);
            SetField(97, fields.NetSettlementAmount, 16);
            SetField(98, fields.Payee);
            SetField(99, fields.SettlementInstitutionIdCode);
            SetField(100, fields.ReceivingInstitutionIdCode);
            SetField(101, fields.FileName);
            SetField(102, fields.AccountIdentification1);
            SetField(103, fields.AccountIdentification2);
            SetField(104, fields.TransactionDescription);
            SetField(105, fields.ReservedIso2);
            SetField(106, fields.ReservedIso3);
            SetField(107, fields.ReservedIso4);
            SetField(108, fields.ReservedIso5);
            SetField(109, fields.ReservedIso6);
            SetField(110, fields.ReservedIso7);
            SetField(111, fields.ReservedIso8);
            SetField(112, fields.ReservedNational4);
            SetField(113, fields.ReservedNational5);
            SetField(114, fields.ReservedNational6);
            SetField(115, fields.ReservedNational7);
            SetField(116, fields.ReservedNational8);
            SetField(117, fields.ReservedNational9);
            SetField(118, fields.ReservedNational10);
            SetField(119, fields.ReservedNational11);
            SetField(120, fields.ReservedPrivate5);
            SetField(121, fields.ReservedPrivate6);
            SetField(122, fields.ReservedPrivate7);
            SetField(123, fields.ReservedPrivate8);
            SetField(124, fields.ReservedPrivate9);
            SetField(125, fields.ReservedPrivate10);
            SetField(126, fields.ReservedPrivate11);
            SetField(127, fields.ReservedPrivate12);
            SetField(128, fields.MessageAuthenticationCode2);

            // 3. Build bitmap hex string (primary and secondary)
            var bitmapHex = new StringBuilder();
            for (int i = 0; i < 128; i += 8)
            {
                byte b = 0;
                for (int j = 0; j < 8; j++)
                {
                    if (bitmap[i + j]) b |= (byte)(1 << (7 - j));
                }
                bitmapHex.Append(b.ToString("X2"));
            }

            // If any field > 64 is present, set bit 1 of primary bitmap
            bool secondaryBitmapNeeded = false;
            for (int i = 64; i < 128; i++)
            {
                if (bitmap[i]) secondaryBitmapNeeded = true;
            }
            if (secondaryBitmapNeeded)
                bitmap[0] = true;

            // 4. Build message string
            var sb = new StringBuilder();
            sb.Append(mti);
            sb.Append(bitmapHex.ToString(0, 16)); // Primary bitmap
            if (secondaryBitmapNeeded)
                sb.Append(bitmapHex.ToString(16, 16)); // Secondary bitmap

            // Append fields in order
            for (int i = 2; i <= 128; i++)
            {
                if (fieldValues.TryGetValue(i, out var value))
                    sb.Append(value);
            }

            return sb.ToString();
        }
    }
}