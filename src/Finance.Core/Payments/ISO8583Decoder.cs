using System.Collections;
using System.Globalization;

namespace Finance.Core.Payments
{
    public class ISO8583Decoder
    {
        public ISO8583 Decode(string message)
        {
            if (string.IsNullOrWhiteSpace(message) || message.Length < 20)
                throw new ArgumentException("Message too short to contain MTI and bitmap.");

            var fields = new ISO8583();

            // 1. Parse MTI (first 4 chars)
            fields.MTI = message.Substring(0, 4);
            int pos = 4;

            // 2. Parse bitmap(s)
            string primaryBitmapHex = message.Substring(pos, 16);
            fields.PrimaryBitmap = primaryBitmapHex;
            bool[] bitmap = ParseBitmap(primaryBitmapHex);
            pos += 16;

            // If first bit is set, secondary bitmap is present
            if (bitmap[0])
            {
                string secondaryBitmapHex = message.Substring(pos, 16);
                fields.SecondaryBitmap = secondaryBitmapHex;
                var secondaryBitmap = ParseBitmap(secondaryBitmapHex);
                bool[] combined = new bool[128];
                Array.Copy(bitmap, combined, 64);
                Array.Copy(secondaryBitmap, 0, combined, 64, 64);
                bitmap = combined;
                pos += 16;
            }
            else
            {
                bool[] combined = new bool[128];
                Array.Copy(bitmap, combined, 64);
                bitmap = combined;
            }

            // 3. Parse fields in order
            for (int fieldNum = 2; fieldNum <= 128; fieldNum++)
            {
                if (!bitmap[fieldNum - 1]) continue;

                switch (fieldNum)
                {
                    case 2: // PAN, LLVAR
                        {
                            int len = int.Parse(message.Substring(pos, 2));
                            pos += 2;
                            fields.PrimaryAccountNumber = message.Substring(pos, len);
                            pos += len;
                            break;
                        }
                    case 3: // Processing Code, fixed 6
                        fields.ProcessingCode = message.Substring(pos, 6);
                        pos += 6;
                        break;
                    case 4: // Transaction Amount, fixed 12
                        fields.TransactionAmount = ParseDecimal(message.Substring(pos, 12));
                        pos += 12;
                        break;
                    case 5: // Settlement Amount, fixed 12
                        fields.SettlementAmount = ParseDecimal(message.Substring(pos, 12));
                        pos += 12;
                        break;
                    case 6: // Cardholder Billing Amount, fixed 12
                        fields.CardholderBillingAmount = ParseDecimal(message.Substring(pos, 12));
                        pos += 12;
                        break;
                    case 7: // Transmission Date & Time, fixed 10 (MMddHHmmss)
                        fields.TransmissionDateTime = ParseDateTime(message.Substring(pos, 10), "MMddHHmmss");
                        pos += 10;
                        break;
                    case 8: // Cardholder Billing Fee Amount, fixed 8
                        fields.CardholderBillingFeeAmount = ParseDecimal(message.Substring(pos, 8));
                        pos += 8;
                        break;
                    case 9: // Conversion Rate, Settlement, fixed 8
                        fields.ConversionRateSettlement = message.Substring(pos, 8);
                        pos += 8;
                        break;
                    case 10: // Conversion Rate, Cardholder Billing, fixed 8
                        fields.ConversionRateCardholderBilling = message.Substring(pos, 8);
                        pos += 8;
                        break;
                    case 11: // Systems Trace Audit Number, fixed 6
                        fields.SystemsTraceAuditNumber = ParseInt(message.Substring(pos, 6));
                        pos += 6;
                        break;
                    case 12: // Local Transaction Time, fixed 6 (hhmmss)
                        fields.LocalTransactionTime = ParseTimeSpan(message.Substring(pos, 6), "hhmmss");
                        pos += 6;
                        break;
                    case 13: // Local Transaction Date, fixed 4 (MMdd)
                        fields.LocalTransactionDate = ParseDateTime(message.Substring(pos, 4), "MMdd");
                        pos += 4;
                        break;
                    case 14: // Expiration Date, fixed 4 (MMYY)
                        fields.ExpirationDate = message.Substring(pos, 4);
                        pos += 4;
                        break;
                    case 15: // Settlement Date, fixed 4 (MMdd)
                        fields.SettlementDate = ParseDateTime(message.Substring(pos, 4), "MMdd");
                        pos += 4;
                        break;
                    case 16: // Currency Conversion Date, fixed 4 (MMdd)
                        fields.CurrencyConversionDate = ParseDateTime(message.Substring(pos, 4), "MMdd");
                        pos += 4;
                        break;
                    case 17: // Capture Date, fixed 4 (MMdd)
                        fields.CaptureDate = ParseDateTime(message.Substring(pos, 4), "MMdd");
                        pos += 4;
                        break;
                    case 18: // Merchant Category Code, fixed 4
                        fields.MerchantCategoryCode = message.Substring(pos, 4);
                        pos += 4;
                        break;
                    case 19: // Acquiring Institution Country Code, fixed 3
                        fields.AcquiringInstitutionCountryCode = message.Substring(pos, 3);
                        pos += 3;
                        break;
                    case 20: // PAN Extended Country Code, fixed 3
                        fields.PanExtendedCountryCode = message.Substring(pos, 3);
                        pos += 3;
                        break;
                    case 21: // Forwarding Institution Country Code, fixed 3
                        fields.ForwardingInstitutionCountryCode = message.Substring(pos, 3);
                        pos += 3;
                        break;
                    case 22: // POS Entry Mode, fixed 3
                        fields.PosEntryMode = message.Substring(pos, 3);
                        pos += 3;
                        break;
                    case 23: // Card Sequence Number, fixed 3
                        fields.CardSequenceNumber = message.Substring(pos, 3);
                        pos += 3;
                        break;
                    case 24: // Network International Identifier, fixed 3
                        fields.NetworkInternationalIdentifier = message.Substring(pos, 3);
                        pos += 3;
                        break;
                    case 25: // POS Condition Code, fixed 2
                        fields.PosConditionCode = message.Substring(pos, 2);
                        pos += 2;
                        break;
                    case 26: // POS PIN Capture Code, fixed 2
                        fields.PosPinCaptureCode = message.Substring(pos, 2);
                        pos += 2;
                        break;
                    case 27: // Authorization Identification Response Length, fixed 1
                        fields.AuthorizationIdentificationResponseLength = message.Substring(pos, 1);
                        pos += 1;
                        break;
                    case 28: // Transaction Fee Amount, fixed 9
                        fields.TransactionFeeAmount = ParseDecimal(message.Substring(pos, 9));
                        pos += 9;
                        break;
                    case 29: // Settlement Fee Amount, fixed 9
                        fields.SettlementFeeAmount = ParseDecimal(message.Substring(pos, 9));
                        pos += 9;
                        break;
                    case 30: // Transaction Processing Fee Amount, fixed 9
                        fields.TransactionProcessingFeeAmount = ParseDecimal(message.Substring(pos, 9));
                        pos += 9;
                        break;
                    case 31: // Settlement Processing Fee Amount, fixed 9
                        fields.SettlementProcessingFeeAmount = ParseDecimal(message.Substring(pos, 9));
                        pos += 9;
                        break;
                    case 32: // Acquiring Institution Identification Code, LLVAR
                        {
                            int len = int.Parse(message.Substring(pos, 2));
                            pos += 2;
                            fields.AcquiringInstitutionIdCode = message.Substring(pos, len);
                            pos += len;
                            break;
                        }
                    case 33: // Forwarding Institution Identification Code, LLVAR
                        {
                            int len = int.Parse(message.Substring(pos, 2));
                            pos += 2;
                            fields.ForwardingInstitutionIdCode = message.Substring(pos, len);
                            pos += len;
                            break;
                        }
                    case 34: // Primary Account Number, Extended, LLVAR
                        {
                            int len = int.Parse(message.Substring(pos, 2));
                            pos += 2;
                            fields.PrimaryAccountNumberExtended = message.Substring(pos, len);
                            pos += len;
                            break;
                        }
                    case 35: // Track 2 Data, LLVAR
                        {
                            int len = int.Parse(message.Substring(pos, 2));
                            pos += 2;
                            fields.Track2Data = message.Substring(pos, len);
                            pos += len;
                            break;
                        }
                    case 36: // Track 3 Data, LLLVAR
                        {
                            int len = int.Parse(message.Substring(pos, 3));
                            pos += 3;
                            fields.Track3Data = message.Substring(pos, len);
                            pos += len;
                            break;
                        }
                    case 37: // Retrieval Reference Number, fixed 12
                        fields.RetrievalReferenceNumber = message.Substring(pos, 12);
                        pos += 12;
                        break;
                    case 38: // Authorization Identification Response, fixed 6
                        fields.AuthorizationIdentificationResponse = message.Substring(pos, 6);
                        pos += 6;
                        break;
                    case 39: // Response Code, fixed 2
                        fields.ResponseCode = message.Substring(pos, 2);
                        pos += 2;
                        break;
                    case 40: // Service Restriction Code, fixed 3
                        fields.ServiceRestrictionCode = message.Substring(pos, 3);
                        pos += 3;
                        break;
                    case 41: // Card Acceptor Terminal ID, fixed 8
                        fields.CardAcceptorTerminalId = message.Substring(pos, 8);
                        pos += 8;
                        break;
                    case 42: // Card Acceptor ID Code, fixed 15
                        fields.CardAcceptorIdCode = message.Substring(pos, 15);
                        pos += 15;
                        break;
                    case 43: // Card Acceptor Name/Location, fixed 40
                        fields.CardAcceptorNameLocation = message.Substring(pos, 40);
                        pos += 40;
                        break;
                    case 44: // Additional Response Data, LLVAR
                        {
                            int len = int.Parse(message.Substring(pos, 2));
                            pos += 2;
                            fields.AdditionalResponseData = message.Substring(pos, len);
                            pos += len;
                            break;
                        }
                    case 45: // Track 1 Data, LLVAR
                        {
                            int len = int.Parse(message.Substring(pos, 2));
                            pos += 2;
                            fields.Track1Data = message.Substring(pos, len);
                            pos += len;
                            break;
                        }
                    case 46: // Additional Data - ISO, LLLVAR
                        {
                            int len = int.Parse(message.Substring(pos, 3));
                            pos += 3;
                            fields.AdditionalDataIso = message.Substring(pos, len);
                            pos += len;
                            break;
                        }
                    case 47: // Additional Data - National, LLLVAR
                        {
                            int len = int.Parse(message.Substring(pos, 3));
                            pos += 3;
                            fields.AdditionalDataNational = message.Substring(pos, len);
                            pos += len;
                            break;
                        }
                    case 48: // Additional Data - Private, LLLVAR
                        {
                            int len = int.Parse(message.Substring(pos, 3));
                            pos += 3;
                            fields.AdditionalDataPrivate = message.Substring(pos, len);
                            pos += len;
                            break;
                        }
                    case 49: // Currency Code, Transaction, fixed 3
                        fields.CurrencyCodeTransaction = message.Substring(pos, 3);
                        pos += 3;
                        break;
                    case 50: // Currency Code, Settlement, fixed 3
                        fields.CurrencyCodeSettlement = message.Substring(pos, 3);
                        pos += 3;
                        break;
                    case 51: // Currency Code, Cardholder Billing, fixed 3
                        fields.CurrencyCodeCardholderBilling = message.Substring(pos, 3);
                        pos += 3;
                        break;
                    case 52: // PIN Data, fixed 16
                        fields.PinData = message.Substring(pos, 16);
                        pos += 16;
                        break;
                    case 53: // Security Related Control Information, fixed 16
                        fields.SecurityRelatedControlInformation = message.Substring(pos, 16);
                        pos += 16;
                        break;
                    case 54: // Additional Amounts, LLLVAR
                        {
                            int len = int.Parse(message.Substring(pos, 3));
                            pos += 3;
                            fields.AdditionalAmounts = message.Substring(pos, len);
                            pos += len;
                            break;
                        }
                    case 55: // ICC System Related Data, LLLVAR
                        {
                            int len = int.Parse(message.Substring(pos, 3));
                            pos += 3;
                            fields.IccSystemRelatedData = message.Substring(pos, len);
                            pos += len;
                            break;
                        }
                    // For brevity, treat remaining fields as fixed or LLLVAR string
                    default:
                        // You may want to add more specific parsing for fields 56-128 as needed
                        break;
                }
            }

            return fields;
        }

        private static bool[] ParseBitmap(string bitmapHex)
        {
            if (bitmapHex.Length % 2 != 0)
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", bitmapHex));
            }

            byte[] data = new byte[bitmapHex.Length / 2];
            for (int index = 0; index < data.Length; index++)
            {
                string byteValue = bitmapHex.Substring(index * 2, 2);
                data[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }
            BitArray bitArray = new BitArray(data);
            bool[] boolArray = new bool[bitArray.Length];
            bitArray.CopyTo(boolArray, 0);
            return boolArray;
        }

        private static DateTime? ParseDateTime(string value, string format)
        {
            if (DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt))
                return dt;
            return null;
        }

        private static TimeSpan? ParseTimeSpan(string value, string format)
        {
            if (TimeSpan.TryParseExact(value, format, CultureInfo.InvariantCulture, out var ts))
                return ts;
            return null;
        }

        private static decimal? ParseDecimal(string value)
        {
            if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var d))
                return d;
            return null;
        }

        private static int? ParseInt(string value)
        {
            if (int.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var i))
                return i;
            return null;
        }
    }
}