namespace Throw.UnitTests.ValidatableMethods;

[TestClass]
public class TypesTests
{
    [TestMethod]
    public void ThrowIfType_WhenCompileTypesEqual_ShouldThrow()
    {
        // Arrange
        string str = "string";

        // Act
        Action action = () => str.Throw().IfType<string>();

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage(new ArgumentException($"Parameter should not be of type '{str.GetType().Name}'.", nameof(str)).Message);
    }

    [TestMethod]
    public void ThrowIfType_WhenRuntimeTypesEqual_ShouldThrow()
    {
        // Arrange
        object list = new List<int>();

        // Act
        Action action = () => list.Throw().IfType<List<int>>();

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage(new ArgumentException($"Parameter should not be of type '{list.GetType().Name}'.", nameof(list)).Message);
    }

    [TestMethod]
    public void ThrowIfType_WhenCompileTimeTypeIsNotType_ShouldNotThrow()
    {
        // Arrange
        List<int> list = new();

        // Act
        Action action2 = () => list.Throw().IfType<int>();

        // Assert
        action2.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfNotType_WhenCompileTimeTypeIsNotType_ShouldThrow()
    {
        // Arrange
        string str = "string";

        // Act
        Action action = () => str.Throw().IfNotType<int>();

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage(new ArgumentException($"Parameter should be of type '{typeof(int).Name}'.", nameof(str)).Message);
    }

    [TestMethod]
    public void ThrowIfNotType_WhenCompileTimeTypesEqual_ShouldNotThrow()
    {
        // Arrange
        List<int> list = new();

        // Act
        Action action = () => list.Throw().IfNotType<List<int>>();

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfNotType_WhenRuntimeTypesEquals_ShouldNotThrow()
    {
        // Arrange
        object list = new List<int>();

        // Act
        Action action = () => list.Throw().IfNotType<List<int>>();

        // Assert
        action.Should().NotThrow();
    }
}
