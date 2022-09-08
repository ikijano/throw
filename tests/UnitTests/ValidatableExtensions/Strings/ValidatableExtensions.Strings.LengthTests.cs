namespace Throw.UnitTests.ValidatableExtensions.Strings;

[TestClass]
public class StringLengthTests
{
    [TestMethod]
    public void ThrowIfLongerThan_WhenLongerThan_ShouldThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfLongerThan(2);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage(new ArgumentException($"String should not be longer than 2 characters.", nameof(value)).Message);
    }

    [TestMethod]
    public void ThrowIfLongerThan_WhenNotLongerThan_ShouldNotThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfLongerThan(100);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfShorterThan_WhenShorterThan_ShouldThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfShorterThan(100);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage(new ArgumentException($"String should not be shorter than 100 characters.", nameof(value)).Message);
    }

    [TestMethod]
    public void ThrowIfShorterThan_WhenNotShorterThan_ShouldNotThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfShorterThan(2);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfLengthEquals_WhenLengthEquals_ShouldThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfLengthEquals(5);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage(new ArgumentException("String length should not be equal to 5.", nameof(value)).Message);
    }

    [TestMethod]
    public void ThrowIfLengthEquals_WhenLengthNotEquals_ShouldNotThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfLengthEquals(100);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfLengthNotEquals_WhenLengthNotEquals_ShouldThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfLengthNotEquals(100);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage(new ArgumentException($"String length should be equal to 100.", nameof(value)).Message);
    }

    [TestMethod]
    public void ThrowIfLengthNotEquals_WhenLengthEquals_ShouldNotThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfLengthNotEquals(value.Length);

        // Assert
        action.Should().NotThrow();
    }
}
