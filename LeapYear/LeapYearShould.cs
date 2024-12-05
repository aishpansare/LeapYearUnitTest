
using FluentAssertions;

namespace LeapYear
{
    public class LeapYearShould
    {
        [Theory]
        [InlineData(1996, true)] 
        [InlineData(2001, false)] 
        [InlineData(1900, false)] 
        [InlineData(2000, true)]  
        [InlineData(2024, true)]  
        [InlineData(2023, false)] 
        [InlineData(2100, false)] 
        [InlineData(2400, true)]  
        public void ReturnsCorrectResult_Years(int year, bool expected)
        {
            LeapYear.IsLeapYear(year).Should().Be(expected);
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