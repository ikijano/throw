namespace Throw.UnitTests.ValidatableExtensions;

[TestClass]
public class ComparablePropertiesTests
{
    [TestMethod]
    public void ThrowIfPropertyGreaterThan_WhenPropertyGreaterThan_ShouldThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfGreaterThan(v => v.Property, 4);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage(new ArgumentOutOfRangeException(message: "Value should not be greater than 4.", paramName: $"{nameof(value)}: v => v.Property", actualValue: value.Property).Message);
    }

    [TestMethod]
    public void ThrowIfPropertyGreaterThan_WhenPropertyNotGreaterThan_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfGreaterThan(v => v.Property, 6);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyGreaterThan_WhenPropertyEquals_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfGreaterThan(v => v.Property, 5);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyGreaterThanOrEqualTo_WhenPropertyGreaterThan_ShouldThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfGreaterThanOrEqualTo(v => v.Property, 4);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage(new ArgumentOutOfRangeException(message: "Value should not be greater than or equal to 4.", paramName: $"{nameof(value)}: v => v.Property", actualValue: value.Property).Message);
    }

    [TestMethod]
    public void ThrowIfPropertyGreaterThanOrEqualTo_WhenPropertyNotGreaterThan_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfGreaterThanOrEqualTo(v => v.Property, 6);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyGreaterThanOrEqualTo_WhenPropertyEquals_ShouldThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfGreaterThanOrEqualTo(v => v.Property, 5);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage(new ArgumentOutOfRangeException(message: "Value should not be greater than or equal to 5.", paramName: $"{nameof(value)}: v => v.Property", actualValue: value.Property).Message);
    }

    [TestMethod]
    public void ThrowIfPropertyLessThan_WhenPropertyLessThan_ShouldThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfLessThan(v => v.Property, 6);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage(new ArgumentOutOfRangeException(message: "Value should not be less than 6.", paramName: $"{nameof(value)}: v => v.Property", actualValue: value.Property).Message);
    }

    [TestMethod]
    public void ThrowIfPropertyLessThan_WhenPropertyNotLessThan_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfLessThan(v => v.Property, 5);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyLessThan_WhenPropertyEquals_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfLessThan(v => v.Property, 5);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyLessThanOrEqualTo_WhenPropertyLessThan_ShouldThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfLessThanOrEqualTo(v => v.Property, 6);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage(new ArgumentOutOfRangeException(message: "Value should not be less than or equal to 6.", paramName: $"{nameof(value)}: v => v.Property", actualValue: value.Property).Message);
    }

    [TestMethod]
    public void ThrowIfPropertyLessThanOrEqualTo_WhenPropertyNotLessThan_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfLessThanOrEqualTo(v => v.Property, 4);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyLessThanOrEqualTo_WhenPropertyEquals_ShouldThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfLessThanOrEqualTo(v => v.Property, 5);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage(new ArgumentOutOfRangeException(message: "Value should not be less than or equal to 5.", paramName: $"{nameof(value)}: v => v.Property", actualValue: value.Property).Message);
    }

    [TestMethod]
    public void ThrowIfPropertyPositive_WhenPropertyPositive_ShouldThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfPositive(v => v.Property);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage(new ArgumentOutOfRangeException(message: "Value should not be greater than 0.", paramName: $"{nameof(value)}: v => v.Property", actualValue: value.Property).Message);
    }

    [TestMethod]
    public void ThrowIfPropertyPositive_WhenPropertyNegative_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = -5 };

        // Act
        Action action = () => value.Throw().IfPositive(v => v.Property);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyPositive_WhenPropertyZero_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = 0 };

        // Act
        Action action = () => value.Throw().IfPositive(v => v.Property);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyPositiveOrZero_WhenPropertyPositive_ShouldThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfPositiveOrZero(v => v.Property);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage(new ArgumentOutOfRangeException(message: "Value should not be greater than or equal to 0.", paramName: $"{nameof(value)}: v => v.Property", actualValue: value.Property).Message);
    }

    [TestMethod]
    public void ThrowIfPropertyPositiveOrZero_WhenPropertyNegative_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = -5 };

        // Act
        Action action = () => value.Throw().IfPositiveOrZero(v => v.Property);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyPositiveOrZero_WhenPropertyZero_ShouldThrow()
    {
        // Arrange
        var value = new { Property = 0 };

        // Act
        Action action = () => value.Throw().IfPositiveOrZero(v => v.Property);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage(new ArgumentOutOfRangeException(message: "Value should not be greater than or equal to 0.", paramName: $"{nameof(value)}: v => v.Property", actualValue: value.Property).Message);
    }

    [TestMethod]
    public void ThrowIfPropertyNegative_WhenPropertyNegative_ShouldThrow()
    {
        // Arrange
        var value = new { Property = -5 };

        // Act
        Action action = () => value.Throw().IfNegative(v => v.Property);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage(new ArgumentOutOfRangeException(message: "Value should not be less than 0.", paramName: $"{nameof(value)}: v => v.Property", actualValue: value.Property).Message);
    }

    [TestMethod]
    public void ThrowIfPropertyNegative_WhenPropertyPositive_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfNegative(v => v.Property);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyNegative_WhenPropertyZero_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = 0 };

        // Act
        Action action = () => value.Throw().IfNegative(v => v.Property);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyNegativeOrZero_WhenPropertyNegative_ShouldThrow()
    {
        // Arrange
        var value = new { Property = -5 };

        // Act
        Action action = () => value.Throw().IfNegativeOrZero(v => v.Property);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage(new ArgumentOutOfRangeException(message: "Value should not be less than or equal to 0.", paramName: $"{nameof(value)}: v => v.Property", actualValue: value.Property).Message);
    }

    [TestMethod]
    public void ThrowIfPropertyNegativeOrZero_WhenPropertyPositive_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfNegativeOrZero(v => v.Property);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyNegativeOrZero_WhenPropertyZero_ShouldThrow()
    {
        // Arrange
        var value = new { Property = 0 };

        // Act
        Action action = () => value.Throw().IfNegativeOrZero(v => v.Property);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage(new ArgumentOutOfRangeException(message: "Value should not be less than or equal to 0.", paramName: $"{nameof(value)}: v => v.Property", actualValue: value.Property).Message);
    }

    [TestMethod]
    public void ThrowIfPropertyOutOfRange_WhenPropertyOutOfRange_ShouldThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfOutOfRange(v => v.Property, 0, 4);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage(new ArgumentOutOfRangeException(message: "Value should be between 0 and 4.", paramName: $"{nameof(value)}: v => v.Property", actualValue: value.Property).Message);
    }

    [TestMethod]
    public void ThrowIfPropertyOutOfRange_WhenPropertyInRange_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfOutOfRange(v => v.Property, 4, 6);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyOutOfRange_WhenPropertyEqualsLowerBound_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfOutOfRange(v => v.Property, 5, 6);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyOutOfRange_WhenPropertyEqualsUpperBound_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfOutOfRange(v => v.Property, 4, 5);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyInRange_WhenPropertyOutOfRange_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfInRange(v => v.Property, 0, 4);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyInRange_WhenPropertyInRange_ShouldThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfInRange(v => v.Property, 4, 6);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage(new ArgumentOutOfRangeException(message: "Value should not be between 4 and 6.", paramName: $"{nameof(value)}: v => v.Property", actualValue: value.Property).Message);
    }

    [TestMethod]
    public void ThrowIfPropertyInRange_WhenPropertyEqualsLowerBound_ShouldThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfInRange(v => v.Property, 5, 6);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage(new ArgumentOutOfRangeException(message: "Value should not be between 5 and 6.", paramName: $"{nameof(value)}: v => v.Property", actualValue: value.Property).Message);
    }

    [TestMethod]
    public void ThrowIfPropertyInRange_WhenPropertyEqualsUpperBound_ShouldThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfInRange(v => v.Property, 4, 5);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage(new ArgumentOutOfRangeException(message: "Value should not be between 4 and 5.", paramName: $"{nameof(value)}: v => v.Property", actualValue: value.Property).Message);
    }
}
