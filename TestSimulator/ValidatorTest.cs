using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class ValidatorTest
{
    [Theory]
    [InlineData(5, 1, 10, 5)]
    [InlineData(0, 1, 10, 1)]
    [InlineData(15, 1, 10, 10)]
    public void Limiter_ShouldReturnClampedValue(int value, int min, int max, int expected)
    {
        // Act
        var result = Validator.Limiter(value, min, max);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", 3, 10, '-', "Unknown")]
    [InlineData("a", 3, 10, '-', "A--")]
    [InlineData("abc", 3, 10, '-', "Abc")]
    [InlineData(" abc", 3, 10, '-', "Abc")]
    [InlineData("abcdefghij", 3, 10, '-', "Abcdefghij")]
    [InlineData("abcdefghijkl", 3, 10, '-', "Abcdefghij")]
    [InlineData("abc         ", 3, 10, '-', "Abc")]
    [InlineData("abc         f", 3, 10, '-', "Abc")]
    [InlineData("abc           f", 3, 10, '-', "Abc")]
    [InlineData("a             f", 3, 10, '-', "A--")]
    [InlineData("a      f       d         d", 3, 10, '-', "A      f")]
    public void Shortener_ShouldReturnCorrectString(string name, int min, int max, char placeholder, string expected)
    {
        // Act
        var result = Validator.Shortener(name, min, max, placeholder);

        // Assert
        Assert.Equal(expected, result);
    }
}