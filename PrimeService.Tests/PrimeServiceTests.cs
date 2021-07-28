using System;
using Xunit;
using Prime.Services;
using Moq;
using System.Collections.Generic;

namespace Prime.Tests.Services
{
    public class PrimeServiceTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(25)]
        [InlineData(27)]
        [InlineData(36)]
        public void non_prime_numbers_should_return_false(int value)
        {
            var positiveServiceMock = new Mock<PositiveService>();
            var primeService = new PrimeService(positiveServiceMock.Object);
            positiveServiceMock.Setup(x => x.IsPositive(value)).Returns(true);

            var result = primeService.IsPrime(value);
            Assert.False(result, $"{value} should not be prime");
        }

        [Theory]
        [InlineData(2)]
        [InlineData(13)]
        [InlineData(29)]
        [InlineData(31)]
        [InlineData(43)]
        public void prime_numbers_should_return_true(int value)
        {
            var positiveServiceMock = new Mock<PositiveService>();
            var primeService = new PrimeService(positiveServiceMock.Object);
            positiveServiceMock.Setup(x => x.IsPositive(value)).Returns(true);

            var result = primeService.IsPrime(value);
            Assert.True(result, $"{value} should be prime");
        }

        public static IEnumerable<object[]> PersonData()
        {
            yield return new object[] { new Person { Id = 7, Name = "John" } };
            yield return new object[] { new Person { Id = 11, Name = "Doe" } };
        }

        [Theory]
        [MemberData(nameof(PersonData))]
        public void person_should_have_prime_id(Person person)
        {
            var positiveServiceMock = new Mock<PositiveService>();
            var primeService = new PrimeService(positiveServiceMock.Object);
            positiveServiceMock.Setup(x => x.IsPositive(person.Id)).Returns(true);

            var result = primeService.HasPrimeId(person);
            Assert.True(result, $"{person.Name} should have prime id");
        }
    }
}
