namespace Throw.UnitTests.ValidatableExtensions;

[TestClass]
public class CollectionsTests
{
    [TestMethod]
    public void ThrowIfCollectionEmpty_WhenCollectionIsEmpty_ShouldThrow()
    {
        // Arrange
        var collection = Array.Empty<int>();

        // Act
        Action action = () => collection.Throw().IfEmpty();

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage(new ArgumentException("Collection should not be empty.", nameof(collection)).Message);
    }

    [TestMethod]
    public void ThrowIfCollectionEmpty_WhenCollectionIsNotEmpty_ShouldNotThrow()
    {
        // Arrange
        var collection = new[] { 1 };

        // Act
        Action action = () => collection.Throw().IfEmpty();

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionNotEmpty_WhenCollectionIsNotEmpty_ShouldThrow()
    {
        // Arrange
        var collection = new[] { 1 };

        // Act
        Action action = () => collection.Throw().IfNotEmpty();

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage(new ArgumentException("Collection should be empty.", nameof(collection)).Message);
    }

    [TestMethod]
    public void ThrowIfCollectionNotEmpty_WhenCollectionIsEmpty_ShouldNotThrow()
    {
        // Arrange
        var collection = Array.Empty<string>();

        // Act
        Action action = () => collection.Throw().IfNotEmpty();

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionCountEquals_WhenCollectionCountEquals_ShouldThrow()
    {
        // Arrange
        var collection = new[] { 1 };

        // Act
        Action action = () => collection.Throw().IfCountEquals(1);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage(new ArgumentException("Collection count should not be equal to 1.", nameof(collection)).Message);
    }

    [TestMethod]
    public void ThrowIfCollectionCountEquals_WhenCollectionCountNotEquals_ShouldNotThrow()
    {
        // Arrange
        var collection = new[] { 1 };

        // Act
        Action action = () => collection.Throw().IfCountEquals(2);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionCountNotEquals_WhenCollectionCountNotEquals_ShouldThrow()
    {
        // Arrange
        var collection = new[] { 1 };

        // Act
        Action action = () => collection.Throw().IfCountNotEquals(2);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage(new ArgumentException("Collection count should be equal to 2.", nameof(collection)).Message);
    }

    [TestMethod]
    public void ThrowIfCollectionCountNotEquals_WhenCollectionCountEquals_ShouldNotThrow()
    {
        // Arrange
        var collection = new[] { 1 };

        // Act
        Action action = () => collection.Throw().IfCountNotEquals(1);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionCountGreaterThan_WhenCollectionCountGreaterThan_ShouldThrow()
    {
        // Arrange
        var collection = new[] { 1 };

        // Act
        Action action = () => collection.Throw().IfCountGreaterThan(0);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage(new ArgumentException("Collection count should not be greater than 0.", nameof(collection)).Message);
    }

    [TestMethod]
    public void ThrowIfCollectionCountGreaterThan_WhenCollectionCountNotGreaterThan_ShouldNotThrow()
    {
        // Arrange
        var collection = new[] { 1 };

        // Act
        Action action = () => collection.Throw().IfCountGreaterThan(2);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionCountGreaterThan_WhenCollectionCountEquals_ShouldNotThrow()
    {
        // Arrange
        var collection = new[] { 1 };

        // Act
        Action action = () => collection.Throw().IfCountGreaterThan(1);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionCountLessThan_WhenCollectionCountLessThan_ShouldThrow()
    {
        // Arrange
        var collection = new[] { 1 };

        // Act
        Action action = () => collection.Throw().IfCountLessThan(2);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage(new ArgumentException("Collection count should not be less than 2.", nameof(collection)).Message);
    }

    [TestMethod]
    public void ThrowIfCollectionCountLessThan_WhenCollectionCountNotLessThan_ShouldNotThrow()
    {
        // Arrange
        var collection = new[] { 1 };

        // Act
        Action action = () => collection.Throw().IfCountLessThan(0);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionCountLessThan_WhenCollectionCountEquals_ShouldNotThrow()
    {
        // Arrange
        var collection = new[] { 1 };

        // Act
        Action action = () => collection.Throw().IfCountLessThan(1);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionHasNullElements_WhenCollectionHasNullElements_ShouldThrow()
    {
        // Arrange
        var collection = new[] { "hey", null };

        // Act
        Action action = () => collection.Throw().IfHasNullElements();

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage(new ArgumentException("Collection should not have null elements.", nameof(collection)).Message);
    }

    [TestMethod]
    public void ThrowIfCollectionHasNullElements_WhenCollectionHasNoNullElements_ShouldNotThrow()
    {
        // Arrange
        var collection = new[] { "hey", "ho" };

        // Act
        Action action = () => collection.Throw().IfHasNullElements();

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionContains_WhenCollectionContainsElement_ShouldThrow()
    {
        // Arrange
        var collection = new[] { "hey", null, "ho" };
        var collection2 = new[] { 1, 2 };

        // Act
        Action action = () => collection.Throw().IfContains("ho");
        Action action2 = () => collection2.Throw().IfContains(1);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage(new ArgumentException("Collection should not contain element.", nameof(collection)).Message);
        action2.Should().ThrowExactly<ArgumentException>()
            .WithMessage(new ArgumentException("Collection should not contain element.", nameof(collection2)).Message);
    }

    [TestMethod]
    public void ThrowIfCollectionContains_WhenCollectionNotContainsElement_ShouldNotThrow()
    {
        // Arrange
        var collection = new[] { "hey", null, "ho" };
        var collection2 = new[] { 1, 2 };

        // Act
        Action action = () => collection.Throw().IfContains("ho1");
        Action action2 = () => collection2.Throw().IfContains(3);

        // Assert
        action.Should().NotThrow();
        action2.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionNotContains_WhenCollectionNotContainsElement_ShouldThrow()
    {
        // Arrange
        var collection = new[] { "hey", null, "ho" };
        var collection2 = new[] { 1, 2 };

        // Act
        Action action = () => collection.Throw().IfNotContains("ho1");
        Action action2 = () => collection2.Throw().IfNotContains(3);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage(new ArgumentException("Collection should contain element.", nameof(collection)).Message);
        action2.Should().ThrowExactly<ArgumentException>()
            .WithMessage(new ArgumentException("Collection should contain element.", nameof(collection2)).Message);
    }

    [TestMethod]
    public void ThrowIfCollectionNotContains_WhenCollectionContainsElement_ShouldNotThrow()
    {
        // Arrange
        var collection = new[] { "hey", null, "ho" };
        var collection2 = new[] { 1, 2 };

        // Act
        Action action = () => collection.Throw().IfNotContains("hey");
        Action action2 = () => collection2.Throw().IfNotContains(1);

        // Assert
        action.Should().NotThrow();
        action2.Should().NotThrow();
    }
}
