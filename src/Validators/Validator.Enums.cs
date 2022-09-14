namespace Throw;

internal static partial class Validator
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfOutOfRange<TValue>(
        TValue value,
        string paramName,
        ExceptionCustomizations? exceptionCustomizations = null)
        where TValue : struct, Enum
    {
        if (!Enum.IsDefined(typeof(TValue), value))
        {
            ExceptionThrower.ThrowOutOfRange(paramName, value, exceptionCustomizations, "Value should be defined in enum.");
        }
    }
}
