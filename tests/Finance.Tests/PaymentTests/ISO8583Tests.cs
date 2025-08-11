using AwesomeAssertions;
using Finance.Core.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Tests.PaymentTests
{
    public class ISO8583Tests
    {
        private const string testLine = "020042000400000000021612345678901234560609173030123456789ABC012345678901234567890123456789012345678901234567891234567890123456789012345678901234567890123456789021";

        /*
        [Fact]
        public void ParseISO8583Message_ShouldReturnCorrectFields()
        {
            // Arrange
            var decoder = new ISO8583Decoder();

            // Act
            var parsedFields = decoder.Decode(testLine);

            // Assert
            parsedFields.MTI.Should().Be("0200");
            parsedFields.PrimaryBitmap.Should().Be("4200040000000002");
            parsedFields.SecondaryBitmap.Should().Be("161234567890123456");
            parsedFields.NetworkManagementInformationCode.Should().Be("021");
        }
        */
    }
}
