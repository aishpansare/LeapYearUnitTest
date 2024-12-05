
using FluentAssertions;

namespace LeapYear
{
    public class LeapYearShould
    {
        [Theory]
        [InlineData(1996)]
        [InlineData(1992)]
        public void ReturnTrue_WhenYearIsDivisibleBy4(int year)
        {
            LeapYear.IsLeapYear(year).Should().BeTrue();
        }

        [Theory]
        [InlineData(2001)]
        [InlineData(2023)]
        public void ReturnFalse_WhenYearIs_NotDivisibleBy4(int year)
        {
            LeapYear.IsLeapYear(year).Should().BeFalse();
        }
         
        [Theory]
        [InlineData(2026)]
        [InlineData(2025)]
        public void ReturnFalse_WhenYearIs_NotDivisibleBy4And100_ButNotBy400(int year)
        {
            LeapYear.IsLeapYear(year).Should().BeFalse();
        }

        [Theory]
        [InlineData(1900)]
        [InlineData(2100)]
        public void ReturnFalse_WhenYearIs_DivisibleBy4And100_ButNotBy400(int year)
        {
            LeapYear.IsLeapYear(year).Should().BeFalse();
        }

        [Theory]
        [InlineData(2000)]
        [InlineData(2400)]
        public void ReturnTrue_WhenYearIs_DivisibleBy4And100_ButAlsoBy400(int year)
        {
            LeapYear.IsLeapYear(year).Should().BeTrue();
        }

        [Fact]
        public void ThrowsArgumentException_NegativeInput()
        {
            Assert.Throws<ArgumentException>(() => LeapYear.IsLeapYear(-1));
        }
    }
    public class LeapYear
    {
        internal static bool IsLeapYear(int year)
        {
            if (year < 0)
            {
                throw new ArgumentException("Year cannot be negative");
            }
            if (year % 4 == 0)
            {
                if(year % 100 == 0)
                {
                    if(year % 400 == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}