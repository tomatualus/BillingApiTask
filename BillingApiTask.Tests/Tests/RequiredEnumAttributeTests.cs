using BillingApiTask.Models;
using BillingApiTask.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace BillingApiTask.Tests.Tests
{
    public class RequiredEnumAttributeTests : ModelValidationSetup
    {
        [Theory]
        [Trait("Category", "Unit")]
        [InlineData(PaymentGateway.PayPal, true)]
        [InlineData(PaymentGateway.Stripe, true)]
        [InlineData((PaymentGateway)(-100), false)]
        public void ValidatesProperly(PaymentGateway input, bool shouldBeNull)
        {
            // Arrange
            var sut = new RequiredEnumAttribute();

            ValidationContext ctx = this.GetValidationContext("");

            // Act
            ValidationResult result = sut.GetValidationResult(input, ctx);

            // Assert
            Assert.Equal(result.ErrorMessage == null, shouldBeNull);
        }
    }
}
