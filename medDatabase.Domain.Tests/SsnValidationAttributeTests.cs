using medDatabase.Domain.Validation;
using NUnit.Framework;

namespace medDatabase.Domain.Tests
{
    [TestFixture]
    public class SsnValidationAttributeTests
    {
        [Test]
        public void SsnValidationAttributeIsValidForValues(
            [Values("000000000", "123456789")] string ssn)
        {
            // Arrange
            var ssnValidator = new SsnValidationAttribute();

            // Act
            var isValid = ssnValidator.IsValid(ssn);

            // Assert
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void SsnValidationAttributeIsNotValidForValues(
            [Values("000abc000", "12345678", "123-45-6789")] string ssn)
        {
            // Arrange
            var ssnValidator = new SsnValidationAttribute();

            // Act
            var isValid = ssnValidator.IsValid(ssn);

            // Assert
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void SsnValidationAttributeIsNotValidForNonStrings(
            [Values(null, 32, 16.0d)] object ssn)
        {
            // Arrange
            var ssnValidator = new SsnValidationAttribute();

            // Act
            var isValid = ssnValidator.IsValid(ssn);

            // Assert
            Assert.That(isValid, Is.False);
        }
    }
}
